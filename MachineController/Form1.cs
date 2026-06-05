//using MachineController.Functions;
//using MachineController.Objects;
//using System.Drawing.Text;
//using System.Reflection;
//using System.Windows.Forms;
using MachineController.Functions;
using MachineController.Objects;
using System.Drawing.Text;
using System.Windows.Forms;

//using System.Reflection;
//using static System.Net.Mime.MediaTypeNames;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace MachineController
{
    public partial class Form1 : Form
    {
        public ConnectToMachineSingleThread? con = null;

        private readonly System.Windows.Forms.Timer tmrUpdateTemperatures;
        private readonly System.Windows.Forms.Timer tmrSendContinuousCommands;
        private readonly System.Windows.Forms.Timer tmrBlinkExtruderLight;
        private readonly System.Windows.Forms.Timer tmrBlinkHeatBedLight;

        #region --- Initialization ---

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true; // Enable form to capture key events

            Random random = new();

            // Timers
            tmrUpdateTemperatures = new System.Windows.Forms.Timer
            {
                Interval = 1000,
                Enabled = false
            };
            tmrUpdateTemperatures.Tick += TmrUpdateTemperatures_Tick;

            tmrSendContinuousCommands = new System.Windows.Forms.Timer
            {
                Interval = 500,
                Enabled = false
            };
            tmrSendContinuousCommands.Tick += TmrSendContinuousCommands_Tick;

            tmrBlinkExtruderLight = new System.Windows.Forms.Timer
            {
                Interval = 500,
                Enabled = false
            };
            tmrBlinkExtruderLight.Tick += TmrBlinkTemperatures_Tick;

            tmrBlinkHeatBedLight = new System.Windows.Forms.Timer
            {
                Interval = 500,
                Enabled = false
            };
            tmrBlinkHeatBedLight.Tick += TmrBlinkTemperatures_Tick;
        }

        #endregion --- Initialization ---

        #region --- Main Form ---

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                DatabaseFunctions.CreateDatabase();
                LoadSettings();
            }
            catch (Exception ex)
            {
                GenericFunctions.ShowErrorMessage(ex);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
            Disconnect();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void imgEmergencyStop_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("You have triggered an Emergency Stop! This will disconnect the machine " +
                "and the printer will have to be reset. \n\nAre you sure you want to continue?", "Error",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No) return;

            SendData("M112");
        }

        #endregion --- Main Form ---

        #region --- Group Box [Initialization} ---

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "G-Code Files (*.gcode)|*.gcode|All Files (*.*)|*.*",
                Title = "Select G-Code File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                PrintGCodeFile(openFileDialog.FileName);
            }
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            SendData("M25"); // Pause printing
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void chkAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = chkAlwaysOnTop.Checked;
        }

        #endregion --- Group Box [Initialization} ---

        #region --- Group Box [Position Readout] ---

        private void BtnZeroX_Click(object sender, EventArgs e)
        {
            con.Send($@"G29 X0");
        }

        private void BtnZeroY_Click(object sender, EventArgs e)
        {
            con.Send($@"G29 Y0");
        }

        private void BtnZeroZ_Click(object sender, EventArgs e)
        {
            con.Send($@"G29 X0");
        }

        #endregion --- Group Box [Position Readout] ---

        #region --- Group Box [Accessory Control] ---

        private void BtnExtruderOn_Click(object sender, EventArgs e)
        {
            SendData($@"M104 S{nudExtruderTemperature.Value}");

            Globals.IsExtruderOn = true;
            tmrBlinkExtruderLight.Enabled = true; tmrBlinkExtruderLight.Start();
            //tmrUpdateTemperatures.Enabled = true; tmrUpdateTemperatures.Start();
        }

        private void btnExtruderOff_Click(object sender, EventArgs e)
        {
            SendData($@"M104 S0");

            Globals.IsExtruderOn = false;
            tmrBlinkExtruderLight.Stop(); tmrBlinkExtruderLight.Enabled = false;
            tmrUpdateTemperatures.Stop(); tmrUpdateTemperatures.Enabled = false;
        }

        private void BtnHeatBedOn_Click(object sender, EventArgs e)
        {
            SendData($@"M140 S{nudHeatBedTemperature.Value}");

            Globals.IsHeatBedOn = true;
            tmrBlinkHeatBedLight.Enabled = true; tmrBlinkHeatBedLight.Start();
        }

        private void btnHeatBedOff_Click(object sender, EventArgs e)
        {
            SendData($@"M140 S0");

            Globals.IsHeatBedOn = false;
            tmrBlinkHeatBedLight.Stop(); tmrBlinkHeatBedLight.Enabled = false;
        }

        private void TrkBarSetFanSpeed(object sender, EventArgs e)
        {
            if (trkBarSetFanSpeed.InvokeRequired)
            {
                trkBarSetFanSpeed.BeginInvoke(new Action(() =>
                    TrkBarSetFanSpeed(sender, e)
                ));

                System.Windows.Forms.Application.DoEvents();
                Thread.Sleep(5);
            }
            else
            {
                con.Send($@"M106 P0 S{trkBarSetFanSpeed.Value}");
            }
        }

        #endregion --- Group Box [Accessory Control] ---

        #region --- Group Box [Custom Commands] ---

        private void BtnDisableMotors_Click(object sender, EventArgs e)
        {
            SendData("M18"); // M18, M84 - Disable steppers
        }

        private void BtnEnableMotors(object sender, EventArgs e)
        {
            SendData("M17"); // M17 - Enable Steppers
        }

        private void BtnMacro_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Macro macro = DatabaseFunctions.GetMacroGcode(Convert.ToInt32(button.Tag));
        }

        private void BtnMacroEdit_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Macro macro = DatabaseFunctions.GetMacroGcode(Convert.ToInt32(button.Tag));

            this.Visible = false;
            Form2 form = new(macro);
            form.ShowDialog(this);
            this.Visible = true;

            LoadMacros();
        }

        #endregion --- Group Box [Custom Commands] ---

        #region --- Group Box [Override Settings] ---

        private void NudMovement_ValueChanged(object sender, EventArgs e)
        {
            nudMovement.Value = (int)nudMovement.Value;
            SendData("M220 S" + nudMovement.Value); // M220 - Set movement speed override
        }

        private void NubExtrusion_ValueChanged(object sender, EventArgs e)
        {
            trkBarExtrusion.Value = (int)nubExtrusion.Value;
            SendData("M221 S" + nubExtrusion.Value); // M221 - Set extrusion speed override
        }

        private void TrkBarNovement_Scroll(object sender, EventArgs e)
        {
            nudMovement.Value = trkBarNovement.Value;
            SendData("M220 S" + nudMovement.Value); // M220 - Set movement speed override
        }

        private void TrkBarExtrusion_Scroll(object sender, EventArgs e)
        {
            nubExtrusion.Value = trkBarExtrusion.Value;
            SendData("M221 S" + nubExtrusion.Value); // M221 - Set extrusion speed override
        }

        #endregion --- Group Box [Override Settings] ---

        #region --- Tab [GCode Library] ---

        private void BtnAddToLibrary_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = "G-Code Files (*.gcode)|*.gcode|All Files (*.*)|*.*",
                Title = "Select G-Code File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileName(openFileDialog.FileName);
                string filePath = openFileDialog.FileName;

                // Check if the file already exists in the library
                foreach (DataGridViewRow row in dgvGCodeLibrary.Rows)
                {
                    if (row.Cells["Filename"].Value.ToString() == fileName)
                    {
                        MessageBox.Show("This file is already in the library.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Add the file to the database first to get an ID for the entry
                LibraryEntry libraryEntry = new()
                {
                    FileName = fileName,
                    FilePath = filePath,
                    RunTime = GenericFunctions.ParseRunTime(filePath),
                    //MaterialUsed = GenericFunctions.ParseMaterialUsed(filePath)
                };

                // If the file does not exist, add it to the library
                DatabaseFunctions.CreateLibraryEntry(libraryEntry);

                // Refresh the DataGridView to show the new entry
                dgvGCodeLibrary.DataSource = DatabaseFunctions.ReadAllLibraryEntries();
            }
        }

        private void BtnRemoveFromLibrary(object sender, EventArgs e)
        {
            string? strValue = dgvGCodeLibrary.CurrentRow.Cells["Id"].Value.ToString();
            int intValue = int.TryParse(strValue, out intValue) ? intValue : 0;

            DatabaseFunctions.DeleteLibraryEntry(intValue);
            dgvGCodeLibrary.DataSource = DatabaseFunctions.ReadAllLibraryEntries();
        }

        private void BtnRunSelectedGCode_Click(object sender, EventArgs e)
        {
            // TODO - Add code to run the selected G-Code file on the machine
            string? filepath = dgvGCodeLibrary.CurrentRow.Cells["FilePath"].Value.ToString();

            if (File.Exists(filepath))
            {
                MessageBox.Show("The selected file no longer exists.", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("All your base are belongs to us!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion --- Tab [GCode Library] ---

        #region --- Tab [Communication] ---

        private void BtnSend_Click(object sender, EventArgs e)
        {
            string gcode = txtBoxSend.Text.ToUpper().TrimStart().TrimEnd();

            SendData(gcode);

            // save command to the database
            DatabaseFunctions.SetGCodeCommands(gcode);

            // Update the GCode combobox with the new command
            cmbGCodes.DataSource = DatabaseFunctions.GetGCodeCommands();

            // Select the last item (the newly added command)
            foreach (string item in cmbGCodes.Items)
            {
                if (item == gcode)
                {
                    cmbGCodes.SelectedIndex = cmbGCodes.Items.IndexOf(item);
                    return;
                }
            }
        }

        private void BtnLookup_Click(object sender, EventArgs e)
        {
            string[] gcode = txtBoxSend.Text.Split(' ');
            string definition = GCodeDictionary.GetDescription(gcode[0]);

            if (gcode.Length == 0)
            {
                MessageBox.Show($"Could not parse [{txtBoxSend.Text}] into a G-Code command.", "Definition", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show($"The definition for [{txtBoxSend.Text}] is ...\n\n{definition}", "Definition", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            //lstViewResponse.Items.Clear();
            rtbResponse.Text = string.Empty;
        }

        private void BtnClearCommands_Click(object sender, EventArgs e)
        {
            cmbGCodes.Items.Clear();
        }

        private void TxtBoxSend_KeyDown(object sender, KeyEventArgs e)
        {
            SendData(txtBoxSend.Text);
        }

        private void TabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!chkKeyboardControl.Checked) return;

            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (e.Modifiers == Keys.Alt)
                        btnNegX10.PerformClick();
                    else if (e.Modifiers == Keys.Control)
                        btnNegX100.PerformClick();
                    else
                        btnNegX1.PerformClick();
                    break;

                case Keys.Right:
                    btnPosY1.PerformClick();
                    break;

                case Keys.Up:
                    btnPosY1.PerformClick();
                    break;

                case Keys.Down:
                    btnNegY1.PerformClick();
                    break;

                case Keys.Escape:
                    SendData("M108 R0");
                    SendData("M112");
                    break;
            }
            e.Handled = true;
        }

        private void btnSendMultipleCommands_Click(object sender, EventArgs e)
        {
            // Create an instance of Form2 and show it as a dialog
            //Form2 form2 = new Form2();
            //form2.ShowDialog(this);
        }

        private void cmbGCodes_SelectedValueChanged(object sender, EventArgs e)
        {
            txtBoxSend.Text = cmbGCodes.SelectedItem?.ToString() ?? string.Empty;
        }

        #endregion --- Tab [Communication] ---

        #region --- Tab [Temperature Plot] ---

        private void BtnClearPlot_Click(object sender, EventArgs e)
        {
            pnlTempChart.Invalidate();

            using (Graphics g = pnlTempChart.CreateGraphics())
            {
                g.DrawLine(new Pen(Color.White, 1), new Point(0, 50), new Point(700, 50));
                g.DrawLine(new Pen(Color.White, 1), new Point(0, 100), new Point(700, 100));
            }

            Globals.CurrentSeconds = 0;
            Globals.CurrentPosition = new Point(0, Globals.CurrentExtruderTemp);
        }

        #endregion --- Tab [Temperature Plot] ---

        #region --- Tab [Jog Controls] ---

        // G91          ; Set to relative positioning
        // G1 X1 F3600  ; Move X +1 mm at 3600 mm/min
        // G90          ; Return to absolute positioning

        private void JogControls(object sender, EventArgs e)
        {
            //MessageBox.Show("Are you sure you want to jog the printer hot end?", "Confirm Move",
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            System.Windows.Forms.Button button = sender as System.Windows.Forms.Button;

            string gcode = button.Tag.ToString();

            SendData("G91");
            SendData($"G1 {gcode} F3600");
            SendData("G90");
        }

        private void btnHomeX_Click(object sender, EventArgs e)
        {
            SendData("G28 X0");
        }

        private void btnHomeY_Click(object sender, EventArgs e)
        {
            SendData("G28 Y0");
        }

        private void btnHomeZ_Click(object sender, EventArgs e)
        {
            SendData("G28 Z0");
        }

        private void btnHomrAll_Click(object sender, EventArgs e)
        {
            SendData("G28 X0 Y0 Z0");
        }

        #endregion --- Tab [Jog Controls] ---

        #region --- Tab [Machine Settings] ---

        private void BtnDeploy_Click(object sender, EventArgs e)
        {
            // Deploy and activate the probe
            con.Send("M401");

            // Enable BLTouch High Speed Mode
            con.Send("M401 S1");

            // Deploy the probe and remain in place
            con.Send("M401 R1");
        }

        private void BtnStow_Click(object sender, EventArgs e)
        {
            // Deactivate and stow the probe
            con.Send("M402");

            // Deactivate and stow, remaining in place
            con.Send("M402 R1");
        }

        private void btnSetXHome_Click(object sender, EventArgs e)
        {
            con.Send($@"M206 X{txtBoxXHomeOffset.Text}");
        }

        private void btnSetYHome_Click(object sender, EventArgs e)
        {
            con.Send($@"M206 Y{txtBoxYHomeOffset.Text}");
        }

        private void btnSetZHome_Click(object sender, EventArgs e)
        {
            con.Send($@"M206 Z{txtBoxZHomeOffset.Text}");
        }

        private void BtnRestoreSettings_Click(object sender, EventArgs e)
        {
            con.Send($@"M501");
        }

        private void BtnSaveSettings_Click(object sender, EventArgs e)
        {
            con.Send($@"M500");
        }

        private void BtnFactoryReset_Click(object sender, EventArgs e)
        {
            //if (DialogResult.Yes == MessageBox.Show("This will reset all settings to factory defaults. Are you sure you want to continue?",
            //    "Factory Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            //{
            //    con.Send($@"M502");
            //    con.Send($@"M500");
            //};
        }

        private void BtnSetPinState_Click(object sender, EventArgs e)
        {
            // Set the pin state to 1 (on)
            //con.Send($@"M42 P{} S1");

            //// Set the pin state to 128 (PWM)
            //con.Send($@"M42 P{} S128");
        }

        #endregion --- Tab [Machine Settings] ---

        #region --- Timer Events ---

        private void TmrUpdateTemperatures_Tick(object? sender, EventArgs e)
        {
            int seconds = Globals.CurrentSeconds;
            int temperature = Globals.CurrentExtruderTemp;

            Point start = Globals.CurrentPosition;
            Point end = new(seconds * 50, 420 - temperature);

            using (Graphics g = pnlTempChart.CreateGraphics())
            {
                g.DrawLine(new Pen(Color.Red, 2), start, end);
            }

            Globals.CurrentPosition = end;

            if (Globals.CurrentPosition.X > pnlTempChart.Width)
            {
                ResetTempChart();
            }

            Globals.CurrentSeconds++;
        }

        private void ResetTempChart()
        {

            //for (int i = 0; i < pnlTempChart.Width; i++)
            //{

            //}
            using (Graphics g = pnlTempChart.CreateGraphics())
            {
                g.DrawLine(new Pen(Color.White, 1), new Point(0, 50), new Point(700, 50));
                g.DrawLine(new Pen(Color.White, 1), new Point(0, 100), new Point(700, 100));
            }

            Globals.CurrentSeconds = 0;
            Globals.CurrentPosition = new Point(0, Globals.CurrentExtruderTemp);
        }

        private void TmrSendContinuousCommands_Tick(object? sender, EventArgs e)
        {
            if (Globals.IsConnected && ChkContinuously.Checked && cmbGCodes.Text != "")
                SendData(cmbGCodes.Text);
        }

        private void TmrBlinkTemperatures_Tick(object? sender, EventArgs e)
        {
            if (Globals.IsExtruderOn)
                picExtruderOn.Visible = !picExtruderOn.Visible;
            else
                picExtruderOn.Visible = false;

            if (Convert.ToDecimal(lblETemperature.Text) >= nudExtruderTemperature.Value)
                picExtruderOn.Visible = true;

            if (Globals.IsHeatBedOn)
                picHeatBedOn.Visible = !picHeatBedOn.Visible;
            else
                picHeatBedOn.Visible = false;

            if (Convert.ToDecimal(lblBTemperature.Text) >= nudHeatBedTemperature.Value)
                picHeatBedOn.Visible = true;

            //string text = $@"ok T:{DateTime.Now.Second}.00 /0.00 B:22.00 /0.00 @:0 B@:0";
            //temperatureChart1.SetHeatedBedTemperature(DateTime.Now.Second, DateTime.Now.Second);
        }

        #endregion --- Timer Events ---

        #region --- Connection Methods ---

        public async void Connect()
        {
            try
            {
                if (!Globals.IsConnected) // not connected to the machine
                {
                    rtbResponse.Text = string.Empty;

                    con = new ConnectToMachineSingleThread((text) =>
                    {
                        if (rtbResponse.InvokeRequired)
                            rtbResponse.Invoke((MethodInvoker)delegate
                            {
                                DataReceived(text);
                            });
                        else
                        {
                            DataReceived(text);
                        }
                    })
                    {
                        PortName = cmbBoxPort.Text,
                        BaudRate = Convert.ToInt32(cmbBoxBaud.Text)
                    };

                    UpdateRichTextBoxSafe("[info]", $"Attemting to Connect ...", Color.DimGray);
                    Globals.IsConnected = Task.Run(() => con.Connect()).GetAwaiter().GetResult();

                    if (Globals.IsConnected)
                    {
                        btnConnect.Text = "Disconnect";
                        btnConnect.Image = LoadImages("pow_1");
                        toolStripStatusLabel1.Text = $"Connected to {cmbBoxPort.Text} at {cmbBoxBaud.Text} baud";
                        tabControl1.Visible = true;

                        if (!rtbResponse.IsDisposed)
                            UpdateRichTextBoxSafe("[info]", $"Connected to {cmbBoxPort.Text} at {cmbBoxBaud.Text} baud", Color.DimGray);
                    }
                    else
                    {
                        UpdateRichTextBoxSafe("[info]", $"Failed to Connect!", Color.Red);
                    }
                }
                else
                {
                    await Task.Run(() => con.Disconnect());

                    Globals.IsConnected = false;
                    btnConnect.Text = "Connect";
                    btnConnect.Image = LoadImages("pow_0");
                    toolStripStatusLabel1.Text = $"Disconnected";

                    if (!rtbResponse.IsDisposed)
                    {
                        rtbResponse.Text = string.Empty;
                        UpdateRichTextBoxSafe("[info]", "Disconnected", Color.DimGray);
                    }
                }

                // Handle Controls
                UpdateFormControls();
                //tabControl1.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                GenericFunctions.ShowErrorMessage(ex);
            }
        }

        public async void Disconnect()
        {
            try
            {
                if (Globals.IsConnected)
                {
                    await Task.Run(() => con.Disconnect());
                    Globals.IsConnected = false;
                    btnConnect.Text = "Connect";

                    if (!rtbResponse.IsDisposed)
                        UpdateRichTextBoxSafe("[info]", "Disconnected", Color.DimGray);
                }
            }
            catch (Exception ex)
            {
                GenericFunctions.ShowErrorMessage(ex);
            }
        }

        public async void SendData(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                MessageBox.Show("Please enter a command to send.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Globals.IsConnected)
            {
                MessageBox.Show("Please connect to the machine first.", "Connection Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                data = data.Trim();

                UpdateRichTextBoxSafe("[send]", data, Color.Blue);

                await Task.Run(() => con.Send(data));

                if (!rtbResponse.IsDisposed)
                {
                    txtBoxSend.Text = data;
                }
            }
            catch (Exception ex)
            {
                GenericFunctions.ShowErrorMessage(ex);
            }
        }

        private void DataReceived(string text)
        {
            try
            {
                if (!chkVerbose.Checked) { return; }

                // ok T:-15.00 /0.00 B:-15.00 /0.00 @:0 B@:0
                else if (text.StartsWith("T:", StringComparison.CurrentCultureIgnoreCase))
                {
                    string[] parts = text.Split(' ');
                    foreach (string part in parts)
                    {
                        if (part.StartsWith("t:", StringComparison.CurrentCultureIgnoreCase) ||
                            part.StartsWith("b:", StringComparison.CurrentCultureIgnoreCase))
                        {
                            string[] tempParts = part.Split(':');
                            if (tempParts.Length == 2)
                            {
                                if (tempParts[0].Equals("t", StringComparison.CurrentCultureIgnoreCase))
                                    lblETemperature.Text = Math.Round(Convert.ToDecimal(tempParts[1]), 0).ToString();
                                else if (tempParts[0].Equals("b", StringComparison.CurrentCultureIgnoreCase))
                                    lblBTemperature.Text = Math.Round(Convert.ToDecimal(tempParts[1]), 0).ToString();
                            }
                        }
                    }
                    UpdateRichTextBoxSafe("[temp]", text, Color.Green);
                    Globals.CurrentExtruderTemp = Convert.ToInt32(lblETemperature.Text);
                }

                //X:0.00 Y:0.00 Z:100.00 E:0.00 Count X:0 Y:0 Z:40000
                else if (text.StartsWith("x:", StringComparison.CurrentCultureIgnoreCase))
                {
                    string[] parts = text.Split(' ');
                    foreach (string part in parts)
                    {
                        switch (part)
                        {
                            case var _ when part.StartsWith("x:", StringComparison.CurrentCultureIgnoreCase):
                                string[] xParts = part.Split(':');
                                if (xParts.Length == 2)
                                {
                                    lblXPosition.Text = xParts[1];
                                }
                                break;

                            case var _ when part.StartsWith("y:", StringComparison.CurrentCultureIgnoreCase):
                                string[] yParts = part.Split(':');
                                if (yParts.Length == 2)
                                {
                                    lblYPosition.Text = yParts[1];
                                }
                                break;

                            case var _ when part.StartsWith("z:", StringComparison.CurrentCultureIgnoreCase):
                                string[] zParts = part.Split(':');
                                if (zParts.Length == 2)
                                {
                                    lblZPosition.Text = zParts[1];
                                }
                                break;

                            case var _ when part.StartsWith("e:", StringComparison.CurrentCultureIgnoreCase):
                                string[] eParts = part.Split(':');
                                if (eParts.Length == 2)
                                {
                                    // lblExtruderPosition.Text = eParts[1];
                                }
                                break;

                            case var _ when part.StartsWith("count", StringComparison.CurrentCultureIgnoreCase):
                                break;

                            default:
                                break;
                        }
                    }
                    UpdateRichTextBoxSafe("[move]", text, Color.Purple);
                }
                else if (text.StartsWith("cap:", StringComparison.CurrentCultureIgnoreCase))
                {
                    UpdateRichTextBoxSafe("[info]", text, Color.DimGray);
                }

                // FIRMWARE_NAME:Marlin 2.1.2.5 (Jul 11 2025 20:12:55)
                // SOURCE_CODE_URL:github.com/MarlinFirmware/Marlin
                // PROTOCOL_VERSION:1.0
                // MACHINE_TYPE:Ender3 1.1.5
                // EXTRUDER_COUNT:1
                // UUID:cede2a2f-41a2-4748-9b12-
                else if (text.StartsWith("FIRMWARE_NAME:", StringComparison.CurrentCultureIgnoreCase))
                {
                    UpdateRichTextBoxSafe("[firm]", text, Color.Brown);
                }
                else
                    UpdateRichTextBoxSafe("[recv]", text, Color.Orange);

                DatabaseFunctions.ExecuteNonQueryWithSQL($"" +
                        $"INSERT INTO [commands] ([type], [data], [timestamp]) " +
                        $"VALUES ('RECV', '{text}', '{DateTime.Now}')");
            }
            catch (Exception ex)
            {
                GenericFunctions.ShowErrorMessage(ex);
            }
        }

        public void PrintGCodeFile(string filePath)
        {
            if (Globals.IsConnected)
            {
                con.SendDataToMachine($"M23 {filePath}");
                con.SendDataToMachine("M24"); // Start printing

                UpdateRichTextBoxSafe("[info]", $"Printing from {filePath}", Color.DimGray);
            }
            else
            {
                MessageBox.Show("Please connect to the machine first.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion --- Connection Methods ---

        #region --- General Methods ---

        private void LoadSettings()
        {
            try
            {
                // Set the location of the form
                Top = Convert.ToInt32(DatabaseFunctions.GetSetting("LocationTop", "100").Value);
                Left = Convert.ToInt32(DatabaseFunctions.GetSetting("LocationLeft", "100").Value);

                // Set the Temperature images location
                picExtruderOn.Location = picExtruderOff.Location;
                picHeatBedOn.Location = picHeatBedOff.Location;

                //  Set the button image
                btnConnect.Image = LoadImages("pow_0");
                imgEmergencyStop.BackgroundImage = LoadImages("estop");

                // Set the font for the digital readouts
                PrivateFontCollection pfc = new();
                pfc.AddFontFile(Path.Combine(System.Windows.Forms.Application.StartupPath, "Fonts\\digital-7.ttf"));
                lblXPosition.Font = new System.Drawing.Font(pfc.Families[0], 17, FontStyle.Regular);
                lblYPosition.Font = new System.Drawing.Font(pfc.Families[0], 17, FontStyle.Regular);
                lblZPosition.Font = new System.Drawing.Font(pfc.Families[0], 17, FontStyle.Regular);
                lblETemperature.Font = new System.Drawing.Font(pfc.Families[0], 13, FontStyle.Bold);
                lblBTemperature.Font = new System.Drawing.Font(pfc.Families[0], 13, FontStyle.Bold);

                // Set the initial values for the digital readouts
                lblETemperature.Text = "0";
                lblBTemperature.Text = "0";

                lblXPosition.Text = "0.00";
                lblYPosition.Text = "0.00";
                lblZPosition.Text = "0.00";

                // Set the initial values for the controls
                chkVerbose.Checked = Convert.ToBoolean(DatabaseFunctions.GetSetting("VerboseCheck", "true").Value);
                chkAlwaysOnTop.Checked = Convert.ToBoolean(DatabaseFunctions.GetSetting("AlwaysOnTop", "true").Value);
                nudXYAxis.Value = Convert.ToDecimal(DatabaseFunctions.GetSetting("XYAxisSpeedValue", "0").Value);
                nudZAxis.Value = Convert.ToDecimal(DatabaseFunctions.GetSetting("ZAxisSpeedValue", "0").Value);
                nudExtruder.Value = Convert.ToDecimal(DatabaseFunctions.GetSetting("ExtruderSpeedValue", "0").Value);
                nudExtruder.Value = Convert.ToDecimal(DatabaseFunctions.GetSetting("ExtruderTemperatureValue", "0").Value);
                nudExtruder.Value = Convert.ToDecimal(DatabaseFunctions.GetSetting("HeatedBedTemperatureValue", "0").Value);
                nudExtruderTemperature.Value = Convert.ToDecimal(DatabaseFunctions.GetSetting("MovementOverrideValue", "0").Value);
                nudHeatBedTemperature.Value = Convert.ToDecimal(DatabaseFunctions.GetSetting("ExtrusionOverrideValue", "0").Value);
                trkBarNovement.Value = Convert.ToInt32(DatabaseFunctions.GetSetting("MovementSliderValue", "100").Value);
                trkBarExtrusion.Value = Convert.ToInt32(DatabaseFunctions.GetSetting("ExtrusionSliderValue", "100").Value);
                tabControl1.SelectedIndex = Convert.ToInt32(DatabaseFunctions.GetSetting("CurrentTabPageIndex", "3").Value);
                txtBoxSend.Text = DatabaseFunctions.GetSetting("CommandText").Value;

                // Load the combo boxes with GCode data
                cmbGCodes.SelectedIndex = 0;
                cmbGCodes.DataSource = DatabaseFunctions.GetGCodeCommands();

                // Load the combo boxes with COM data
                cmbBoxPort.DataSource = SerialConnection.GetComPorts();
                if (cmbBoxPort.Items.Count > 0)
                    cmbBoxPort.SelectedIndex = Int32.Parse(DatabaseFunctions.GetSetting("ComPortIndex", "0").Value);
                else
                    cmbBoxPort.Text = "No COM Ports Found";

                // Load the combo boxes with Baud Rates data
                cmbBoxBaud.DataSource = SerialConnection.GetBaudRates();
                if (cmbBoxBaud.Items.Count > 0)
                    cmbBoxBaud.SelectedIndex = Int32.TryParse(DatabaseFunctions.GetSetting("BaudRateIndex", "0").Value, out int y) ? y : 0;
                else
                    cmbBoxBaud.Text = "No Baud Rates Found";

                // Load the combo boxes with Toolhead data
                cmbActiveToolhead.DataSource = SerialConnection.GetToolheads();
                if (cmbActiveToolhead.Items.Count > 0)
                    cmbActiveToolhead.SelectedIndex = Int32.TryParse(DatabaseFunctions.GetSetting("ToolheadIndex", "0").Value, out int z) ? z : 0;
                else
                    cmbActiveToolhead.Text = "No Toolheads Found";

                // Load the G-Code library entries into the DataGridView
                dgvGCodeLibrary.DataSource = DatabaseFunctions.ReadAllLibraryEntries();
                dgvGCodeLibrary.Columns["filename"].HeaderText = "Filename";
                dgvGCodeLibrary.Columns["filepath"].HeaderText = "File Path";
                dgvGCodeLibrary.Columns["runtime"].HeaderText = "Run Time";
                dgvGCodeLibrary.Columns["materialused"].HeaderText = "Material";
                dgvGCodeLibrary.Columns["id"].Visible = false;
                dgvGCodeLibrary.Columns["filepath"].Visible = false;
                dgvGCodeLibrary.Columns["materialused"].Visible = false;
                dgvGCodeLibrary.Columns["filename"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // Version
                toolStripStatusLabel2.Text = System.Windows.Forms.Application.ProductVersion;

                // Handle Controls
                UpdateFormControls();

                // Handle Tooltips
                HandleToolTips();

                // Load the Macro Buttons
                LoadMacros();

                // Reset the temp chart
                ResetTempChart();
            }
            catch (Exception ex)
            {
                GenericFunctions.ShowErrorMessage(ex);
            }
        }

        private void SaveSettings()
        {
            try
            {
                DatabaseFunctions.SetSetting("LocationTop", Top.ToString());
                DatabaseFunctions.SetSetting("LocationLeft", Left.ToString());
                DatabaseFunctions.SetSetting("ComPort", cmbBoxPort.Text);
                DatabaseFunctions.SetSetting("BaudRate", cmbBoxBaud.Text);
                DatabaseFunctions.SetSetting("Toolhead", cmbActiveToolhead.Text);
                DatabaseFunctions.SetSetting("ComPortIndex", cmbBoxPort.SelectedIndex.ToString());
                DatabaseFunctions.SetSetting("BaudRateIndex", cmbBoxBaud.SelectedIndex.ToString());
                DatabaseFunctions.SetSetting("ToolheadIndex", cmbActiveToolhead.SelectedIndex.ToString());
                DatabaseFunctions.SetSetting("VerboseCheck", chkVerbose.Checked.ToString());
                DatabaseFunctions.SetSetting("XYAxisSpeedValue", nudXYAxis.Value.ToString());
                DatabaseFunctions.SetSetting("ZAxisSpeedValue", nudZAxis.Value.ToString());
                DatabaseFunctions.SetSetting("ExtruderSpeedValue", nudExtruder.Value.ToString());
                DatabaseFunctions.SetSetting("ExtruderTemperatureValue", nudExtruder.Value.ToString());
                DatabaseFunctions.SetSetting("HeatedBedTemperatureValue", nudExtruder.Value.ToString());
                DatabaseFunctions.SetSetting("MovementOverrideValue", nudExtruderTemperature.Value.ToString());
                DatabaseFunctions.SetSetting("ExtrusionOverrideValue", nudHeatBedTemperature.Value.ToString());
                DatabaseFunctions.SetSetting("MovementSliderValue", trkBarNovement.Value.ToString());
                DatabaseFunctions.SetSetting("ExtrusionSliderValue", trkBarExtrusion.Value.ToString());
                DatabaseFunctions.SetSetting("CurrentTabPageIndex", tabControl1.SelectedIndex.ToString());
                DatabaseFunctions.SetSetting("CommandText", txtBoxSend.Text.ToString());
                DatabaseFunctions.SetSetting("AlwaysOnTop", chkAlwaysOnTop.Checked.ToString());
            }
            catch (Exception ex)
            {
                GenericFunctions.ShowErrorMessage(ex);
            }
        }

        private Image LoadImages(string image)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream($@"MachineController.Resources.{image}.png"))
            {
                switch (image)
                {
                    case "estop":
                        if (stream != null) return Image.FromStream(stream);
                        break;

                    case "led_0":
                        if (stream != null) return Image.FromStream(stream);
                        break;

                    case "led_1":
                        if (stream != null) return Image.FromStream(stream);
                        break;

                    case "pow_0":
                        if (stream != null) return Image.FromStream(stream);
                        break;

                    case "pow_1":
                        if (stream != null) return Image.FromStream(stream);
                        break;

                    default:
                        break;
                }
            }
            return null;
        }

        private void LoadMacros()
        {
            foreach (Button button in grpBoxCustomCommands.Controls.OfType<Button>())
            {
                if (button.Name != "btnDisableMotors" && button.Name != "btnEnableMotors" && button.Text != "...")
                {
                    Macro macro = DatabaseFunctions.GetMacroGcode(Convert.ToInt32(button.Tag));
                    button.Text = macro.Name;
                }
            }
        }

        private void UpdateFormControls()
        {
            foreach (Control control in this.Controls)
            {
                if (control.Equals(grpBoxInitialization)) continue;

                control.ForeColor = Globals.IsConnected ? Color.Black : Color.LightGray;

                // TODO - Handle Exception Thrown a little better
                try { control.Enabled = Globals.IsConnected; }
                catch (Exception ex) { }
            }
        }

        private void HandleToolTips()
        {
            // TODO - Set tooltips for controls
            System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
            toolTip.SetToolTip(btnConnect, "Initialize a serial connection to a machine.");
            toolTip.SetToolTip(btnPrint, "Execute a G-Code file on the attached machine.");
            toolTip.SetToolTip(btnPause, "Pause the current print job.");
            toolTip.SetToolTip(btnRefresh, "Refresh COM ports.");
            toolTip.SetToolTip(cmbBoxPort, "Select COM port.");
            toolTip.SetToolTip(cmbBoxBaud, "Select the baud rate for transmission (needs to match the machines configuration).");
            toolTip.SetToolTip(chkVerbose, "Display all serial communication to and from the machine.");
            toolTip.SetToolTip(grpBoxInitialization, "Initialization commands.");
        }

        private void UpdateRichTextBoxSafe(string type, string text, Color color)
        {
            if (rtbResponse.InvokeRequired)
            {
                rtbResponse.BeginInvoke(new Action(() =>
                    UpdateRichTextBoxSafe(type, text, color)
                ));

                System.Windows.Forms.Application.DoEvents();
                Thread.Sleep(5);
            }
            else
            {
                rtbResponse.SelectionFont = new System.Drawing.Font(rtbResponse.Font, FontStyle.Bold);
                rtbResponse.SelectionStart = rtbResponse.TextLength;
                rtbResponse.SelectionLength = 0;
                rtbResponse.SelectionColor = color;
                rtbResponse.AppendText(type + " ");

                rtbResponse.SelectionFont = new System.Drawing.Font(rtbResponse.Font, FontStyle.Regular);
                rtbResponse.SelectionStart = rtbResponse.TextLength;
                rtbResponse.SelectionLength = 0;
                rtbResponse.SelectionColor = Color.Black;
                rtbResponse.AppendText(text);

                rtbResponse.AppendText(Environment.NewLine);
                rtbResponse.SelectionStart = rtbResponse.Text.Length;
                rtbResponse.ScrollToCaret();
            }
        }

        #endregion --- General Methods ---

        private void pnlTempChart_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show($"Clicked at X: {e.X}, Y: {e.Y}");
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            ResetTempChart();
        }
    }
}