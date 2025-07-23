using MachineController.Controls;
using MachineController.Functions;
using MachineController.Objects;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace MachineController
{
    public partial class Form1 : Form
    {
        public ConnectToMachineSingleThread? con = null;

        System.Windows.Forms.Timer tmrSendContinuousCommands;
        System.Windows.Forms.Timer tmrBlinkTemperatures;

        private bool IsConnected = false;
        private bool IsExtruderOn = false;
        private bool IsHeatedBedOn = false;
        private bool IsExtruderAtTemperature = false;
        private bool IsHeatedBedAtTemperature = false;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true; // Enable form to capture key events

            Random random = new();

            // Timers
            tmrSendContinuousCommands = new System.Windows.Forms.Timer
            {
                Interval = 500,
                Enabled = true
            };
            tmrSendContinuousCommands.Tick += TmrSendContinuousCommands_Tick;

            tmrBlinkTemperatures = new System.Windows.Forms.Timer
            {
                Interval = 500,
                Enabled = true
            };
            tmrBlinkTemperatures.Tick += TmrBlinkTemperatures_Tick;
        }

        #region --- Timers Events ---

        private void TmrSendContinuousCommands_Tick(object? sender, EventArgs e)
        {
            if (IsConnected && chkPingWithCommand.Checked && cmbGCodes.Text != "") con.Send(cmbGCodes.Text);
        }

        private void TmrBlinkTemperatures_Tick(object? sender, EventArgs e)
        {
            if (IsExtruderOn)
            {
                if (pnlExtruder.BackColor == Color.Red)
                    pnlExtruder.BackColor = Color.DarkGray;
                else
                    pnlExtruder.BackColor = Color.Red;
            }
            if (IsHeatedBedOn)
            {
                if (pnlHeatedBed.BackColor == Color.Red)
                    pnlHeatedBed.BackColor = Color.DarkGray;
                else
                    pnlHeatedBed.BackColor = Color.Red;
            }
        }
        #endregion

        #region --- Methods ---

        private void HandleFormControls()
        {

            // Handle Controls
            foreach (Control control in this.Controls)
            {
                if (control.Equals(grpBoxInitialization)) continue; // Skip Initialization Controls
                if (IsConnected)
                    control.ForeColor = Color.Black;
                else
                    control.ForeColor = Color.LightGray;

                control.Enabled = IsConnected;
            }
        }

        public async void Connect()
        {
            try
            {
                if (!IsConnected) // not connected to the machine
                {
                    lstViewResponse.Items.Clear();

                    con = new ConnectToMachineSingleThread((text) =>
                    {
                        if (lstViewResponse.InvokeRequired)
                            lstViewResponse.Invoke((MethodInvoker)delegate
                            {
                                Recieve(text);
                            });
                        else
                        {
                            Recieve(text);
                        }
                    })
                    {
                        PortName = cmbBoxPort.Text,
                        BaudRate = Convert.ToInt32(cmbBoxBaud.Text)
                    };

                    await Task.Run(() => con.Connect());

                    IsConnected = true;
                    btnConnect.Text = "Disconnect";
                    toolStripStatusLabel1.Text = $"Connected to {cmbBoxPort.Text} at {cmbBoxBaud.Text} baud";
                    pnlWelcome.Visible = false;
                    tabControl1.Visible = true;

                    // set position reporting
                    con.Send("M154 S2");

                    // set temperature reporting
                    con.Send("M155 S2");

                    if (!lstViewResponse.IsDisposed)
                        AddLineToListView("[info]", "Connected", Color.DarkGray);
                }
                else
                {
                    await Task.Run(() => con.Disconnect());

                    IsConnected = false;
                    btnConnect.Text = "Connect";
                    toolStripStatusLabel1.Text = $"Disconnected";
                    pnlWelcome.Visible = true;
                    tabControl1.Visible = false;

                    if (!lstViewResponse.IsDisposed)
                        AddLineToListView("[info]", "Disconnected", Color.DarkGray);
                }

                // Handle Controls
                HandleFormControls();
                tabControl1.SelectedIndex = 1;

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
                if (IsConnected)
                {
                    await Task.Run(() => con.Disconnect());
                    IsConnected = false;
                    btnConnect.Text = "Connect";
                    toolStripStatusLabel1.Text = "Disconnected";
                    if (!lstViewResponse.IsDisposed)
                        AddLineToListView("[info]", "Disconnected", Color.DarkGray);
                }
            }
            catch (Exception ex)
            {
                GenericFunctions.ShowErrorMessage(ex);
            }
        }

        public async void Send(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                MessageBox.Show("Please enter a command to send.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsConnected)
            {
                MessageBox.Show("Please connect to the machine first.", "Connection Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                data = data.ToUpper().TrimStart().TrimEnd();

                PreProcessCommand(data);

                await Task.Run(() => con.Send(data));

                if (!lstViewResponse.IsDisposed)
                {
                    txtBoxSend.Text = data;
                }
            }
            catch (Exception ex)
            {
                GenericFunctions.ShowErrorMessage(ex);
            }
        }
        private void Recieve(string text)
        {
            PostProcessResponse(text);
        }

        private void PreProcessCommand(string text)
        {
            string[] code = text.Split([' ', '\t'], 3);
            switch (code[0])
            {
                case var _ when code[0].Equals("G0"):
                    break;
                case var _ when code[0].Equals("G1"):
                    break;
                default:
                    break;
            }
        }

        private void PostProcessResponse(string text)
        {
            //string[] code = text.Split([' ', '\t'], 3);

            //switch (code[0])
            //{
            //    case var _ when code[0].Equals("G0"):
            //        break;
            //    case var _ when code[0].Equals("G1"):
            //        break;

            //    default:
            //        break;
            //}

            if (!chkVerbose.Checked) return;

            Color textColor = Color.Black;

            //if (text.StartsWith("ok", StringComparison.CurrentCultureIgnoreCase) ||
            //    text.StartsWith("busy", StringComparison.CurrentCultureIgnoreCase) ||
            //    text.StartsWith("echo", StringComparison.CurrentCultureIgnoreCase))
            //{
            //    textColor = Color.DarkGray;
            //}

            if (text.StartsWith("ok", StringComparison.CurrentCultureIgnoreCase))
            {
                textColor = Color.Green;

            }

            if (text.StartsWith("error", StringComparison.CurrentCultureIgnoreCase))
            {
                textColor = Color.Red;
            }

            if (text.StartsWith("cap:", StringComparison.CurrentCultureIgnoreCase))
            {
                textColor = Color.Blue;
            }

            // ok T:-15.00 /0.00 B:-15.00 /0.00 @:0 B@:0
            if (text.StartsWith("ok t:", StringComparison.CurrentCultureIgnoreCase) ||
                text.StartsWith("ok t:", StringComparison.CurrentCultureIgnoreCase))
            {
                textColor = Color.Purple;

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
                            {
                                //lblETemperature.Text = $"{tempParts[1]}°C";
                                lblETemperature.Text = tempParts[1];
                            }
                            else if (tempParts[0].Equals("b", StringComparison.CurrentCultureIgnoreCase))
                            {
                                //lblBTemperature.Text = $"{tempParts[1]}°C";
                                lblBTemperature.Text = tempParts[1];
                            }
                        }
                    }
                }
            }

            //X:0.00 Y:0.00 Z:100.00 E:0.00 Count X:0 Y:0 Z:40000
            if (text.StartsWith("x:", StringComparison.CurrentCultureIgnoreCase))
            {
                textColor = Color.Purple;

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
            }

            if (text.StartsWith("cap:", StringComparison.CurrentCultureIgnoreCase))
            {
                textColor = Color.Brown;
            }

            // FIRMWARE_NAME:Marlin 2.1.2.5 (Jul 11 2025 20:12:55)
            // SOURCE_CODE_URL:github.com/MarlinFirmware/Marlin
            // PROTOCOL_VERSION:1.0
            // MACHINE_TYPE:Ender3 1.1.5
            // EXTRUDER_COUNT:1
            // UUID:cede2a2f-41a2-4748-9b12-

            if (text.StartsWith("FIRMWARE_NAME:", StringComparison.CurrentCultureIgnoreCase))
            {
                textColor = Color.Chocolate;
            }

            AddLineToListView("[recv]", text, textColor);

            DatabaseFunctions.ExecuteNonQueryWithSQL($"" +
                $"INSERT INTO [commands] ([type], [data], [timestamp]) " +
                $"VALUES ('RECV', '{text}', '{DateTime.Now}')");
        }

        private void AddLineToListView(string type, string response, Color forecolor)
        {
            ListViewItem listViewItem = new ListViewItem();
            ListViewItem.ListViewSubItem listViewSubItem = new ListViewItem.ListViewSubItem();

            listViewItem.Text = type;
            listViewItem.ForeColor = forecolor;
            listViewItem.BackColor = Color.White;
            listViewItem.UseItemStyleForSubItems = false;

            listViewSubItem.Text = response;
            listViewSubItem.ForeColor = forecolor;
            listViewSubItem.BackColor = Color.White;

            lstViewResponse.Items.Add(listViewItem);
            listViewItem.SubItems.Add(listViewSubItem);

            lstViewResponse.TopItem = lstViewResponse.Items[lstViewResponse.Items.Count - 1];
        }

        public void Print(string filePath)
        {
            if (IsConnected)
            {
                con.SendDataToMachine($"M23 {filePath}");
                con.SendDataToMachine("M24"); // Start printing

                AddLineToListView("[info]", $"Printing from {filePath}", Color.DarkGray);
            }
            else
            {
                MessageBox.Show("Please connect to the machine first.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSettings()
        {
            try
            {
                // Set the location of the form
                Top = Convert.ToInt32(DatabaseFunctions.GetSetting("LocationTop", "100").Value);
                Left = Convert.ToInt32(DatabaseFunctions.GetSetting("LocationLeft", "100").Value);

                // Set the font for the digital readouts
                PrivateFontCollection pfc = new();
                pfc.AddFontFile(Path.Combine(System.Windows.Forms.Application.StartupPath, "Fonts\\digital-7.ttf"));
                lblXPosition.Font = new System.Drawing.Font(pfc.Families[0], 17, FontStyle.Regular);
                lblYPosition.Font = new System.Drawing.Font(pfc.Families[0], 17, FontStyle.Regular);
                lblZPosition.Font = new System.Drawing.Font(pfc.Families[0], 17, FontStyle.Regular);
                lblETemperature.Font = new System.Drawing.Font(pfc.Families[0], 13, FontStyle.Bold);
                lblBTemperature.Font = new System.Drawing.Font(pfc.Families[0], 13, FontStyle.Bold);

                // Set the initial values for the digital readouts
                label12.Text = string.Format("{0}°C", 22);
                label13.Text = string.Format("{0}°C", 23);

                // Set the initial values for the controls
                chkVerbose.Checked = Convert.ToBoolean(DatabaseFunctions.GetSetting("VerboseCheck", "true").Value);
                nudXYAxis.Value = Convert.ToDecimal(DatabaseFunctions.GetSetting("XYAxisSpeedValue", "0").Value);
                nudZAxis.Value = Convert.ToDecimal(DatabaseFunctions.GetSetting("ZAxisSpeedValue", "0").Value);
                nudExtruder.Value = Convert.ToDecimal(DatabaseFunctions.GetSetting("ExtruderSpeedValue", "0").Value);
                nudExtruder.Value = Convert.ToDecimal(DatabaseFunctions.GetSetting("ExtruderTemperatureValue", "0").Value);
                nudExtruder.Value = Convert.ToDecimal(DatabaseFunctions.GetSetting("HeatedBedTemperatureValue", "0").Value);
                nudExtruderTemperature.Value = Convert.ToDecimal(DatabaseFunctions.GetSetting("MovementOverrideValue", "0").Value);
                nudHeatedBedTemperature.Value = Convert.ToDecimal(DatabaseFunctions.GetSetting("ExtrusionOverrideValue", "0").Value);
                trkBarNovement.Value = Convert.ToInt32(DatabaseFunctions.GetSetting("MovementSliderValue", "100").Value);
                trkBarExtrusion.Value = Convert.ToInt32(DatabaseFunctions.GetSetting("ExtrusionSliderValue", "100").Value);
                tabControl1.SelectedIndex = Convert.ToInt32(DatabaseFunctions.GetSetting("CurrentTabPageIndex", "3").Value);
                txtBoxSend.Text = DatabaseFunctions.GetSetting("CommandText").Value;

                // Set the ListView properties
                lstViewResponse.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
                lstViewResponse.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
                lstViewResponse.Columns[0].Width = 50; // Set a fixed width for the first column
                lstViewResponse.Columns[1].Width = lstViewResponse.ClientSize.Width - lstViewResponse.Columns[0].Width;

                cmbGCodes.SelectedIndex = 0;
                cmbGCodes.DataSource = DatabaseFunctions.GetGCodeCommands();

                pnlWelcome.Location = new Point(8, 127);
                pnlWelcome.Size = new Size(436, 404);

                // Load the combo boxes with COM data
                cmbBoxPort.DataSource = SerialConnection.GetComPorts();
                if (cmbBoxPort.Items.Count > 0)
                {
                    cmbBoxPort.SelectedIndex = Int32.Parse(DatabaseFunctions.GetSetting("ComPortIndex", "0").Value);
                }
                else
                {
                    cmbBoxPort.Text = "No COM Ports Found";
                }

                // Load the combo boxes with Baud Rates data
                cmbBoxBaud.DataSource = SerialConnection.GetBaudRates();
                if (cmbBoxBaud.Items.Count > 0)
                {
                    cmbBoxBaud.SelectedIndex = Int32.TryParse(DatabaseFunctions.GetSetting("BaudRateIndex", "0").Value, out int y) ? y : 0;
                }
                else
                {
                    cmbBoxBaud.Text = "No Baud Rates Found";
                }

                // Load the combo boxes with Toolhead data
                cmbActiveToolhead.DataSource = SerialConnection.GetToolheads();
                if (cmbActiveToolhead.Items.Count > 0)
                {
                    cmbActiveToolhead.SelectedIndex = Int32.TryParse(DatabaseFunctions.GetSetting("ToolheadIndex", "0").Value, out int z) ? z : 0;
                }
                else
                {
                    cmbActiveToolhead.Text = "No Toolheads Found";
                }

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

                // Handle Controls
                HandleFormControls();
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
                DatabaseFunctions.SetSetting("ExtrusionOverrideValue", nudHeatedBedTemperature.Value.ToString());
                DatabaseFunctions.SetSetting("MovementSliderValue", trkBarNovement.Value.ToString());
                DatabaseFunctions.SetSetting("ExtrusionSliderValue", trkBarExtrusion.Value.ToString());
                DatabaseFunctions.SetSetting("CurrentTabPageIndex", tabControl1.SelectedIndex.ToString());
                DatabaseFunctions.SetSetting("CommandText", txtBoxSend.Text.ToString());
            }
            catch (Exception ex)
            {
                GenericFunctions.ShowErrorMessage(ex);
            }
        }

        #endregion

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

        #endregion --- Main Form ---

        #region --- Initialization ---

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
                Print(openFileDialog.FileName);
            }
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            Send("M25"); // Pause printing
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            cmbBoxPort.DataSource = SerialConnection.GetComPorts();
        }

        #endregion --- Initialization ---

        #region --- Position Readout ---

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

        #endregion --- Position Readout ---

        #region --- Accessory Control ---

        private void BtnExtruderOn_Click(object sender, EventArgs e)
        {
            if (IsExtruderOn && !IsExtruderAtTemperature)
            {
                con.Send($@"M104 T{cmbActiveToolhead.SelectedIndex + 1} S0");

                IsExtruderOn = false;
                btnExtruderOn.Text = "On";
                pnlExtruder.BackColor = Color.DarkGray;
            }
            else
            {
                con.Send($@"M104 T{cmbActiveToolhead.SelectedIndex + 1} S{nudExtruderTemperature.Value}");

                IsExtruderOn = true;
                btnExtruderOn.Text = "Off";
                pnlExtruder.BackColor = Color.Red;
            }
        }

        private void BtnHeatedBedOn_Click(object sender, EventArgs e)
        {
            if (IsHeatedBedOn && !IsHeatedBedAtTemperature)
            {
                con.Send($@"M140 S{nudHeatedBedTemperature.Value}");

                IsHeatedBedOn = false;
                btnHeatedBedOn.Text = "On";
                pnlHeatedBed.BackColor = Color.DarkGray;
            }
            else
            {
                con.Send($@"M140 S0");

                IsHeatedBedOn = true;
                btnHeatedBedOn.Text = "Off";
                pnlHeatedBed.BackColor = Color.Red;
            }
        }

        private void TrkBarSetFanSpeed(object sender, EventArgs e)
        {
            con.Send($@"M106 P0 S{trkBarSetFanSpeed.Value}");
        }

        private void PnlExtruder_Click(object sender, EventArgs e)
        {
            BtnExtruderOn_Click(sender, e);
        }

        private void PnlHeatedBed_Click(object sender, EventArgs e)
        {
            BtnHeatedBedOn_Click(sender, e);
        }

        #endregion --- Accessory Control ---

        #region --- Custom Commands ---

        private void BtnDisableMotors_Click(object sender, EventArgs e)
        {
            Send("M18"); // M18, M84 - Disable steppers
        }

        private void BtnEnableMotors(object sender, EventArgs e)
        {
            Send("M17"); // M17 - Enable Steppers
        }

        private void BtnPrintFromSDCard(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "G-Code Files (*.gcode)|*.gcode|All Files (*.*)|*.*",
                Title = "Select G-Code File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Print(openFileDialog.FileName);
            }
        }

        private void BtnPauseCurrentSDPrint(object sender, EventArgs e)
        {
            Send("M25"); // M25 - Pause SD print
        }

        private void BtnUploadToSDCard(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "G-Code Files (*.gcode)|*.gcode|All Files (*.*)|*.*",
                Title = "Select G-Code File to Upload"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Send the command to upload the file to the SD card
            }

            // TODO
        }

        private void BtnSDCardStatus(object sender, EventArgs e)
        {
            Send("M27"); // M27 - Report SD print status
        }

        #endregion --- Custom Commands ---

        #region --- Override Settings ---

        private void NudMovement_ValueChanged(object sender, EventArgs e)
        {
            nudMovement.Value = (int)nudMovement.Value;
            Send("M220 S" + nudMovement.Value); // M220 - Set movement speed override
        }

        private void NubExtrusion_ValueChanged(object sender, EventArgs e)
        {
            trkBarExtrusion.Value = (int)nubExtrusion.Value;
            Send("M221 S" + nubExtrusion.Value); // M221 - Set extrusion speed override
        }

        private void TrkBarNovement_Scroll(object sender, EventArgs e)
        {
            nudMovement.Value = trkBarNovement.Value;
            Send("M220 S" + nudMovement.Value); // M220 - Set movement speed override
        }

        private void TrkBarExtrusion_Scroll(object sender, EventArgs e)
        {
            nubExtrusion.Value = trkBarExtrusion.Value;
            Send("M221 S" + nubExtrusion.Value); // M221 - Set extrusion speed override
        }

        #endregion --- Override Settings ---

        #region --- Tabs [GCode Library] ---

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
            // TODO
            string? filepath = dgvGCodeLibrary.CurrentRow.Cells["FilePath"].Value.ToString();

            if (File.Exists(filepath))
            {
                MessageBox.Show("The selected file no longer exists.", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("All your base are belongs to us!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion --- Tabs [GCode Library] ---

        #region --- Tabs [Communication] ---

        private void BtnSend_Click(object sender, EventArgs e)
        {
            Send(txtBoxSend.Text);
            DatabaseFunctions.SetGCodeCommands(txtBoxSend.Text);

            // Update the GCode combobox with the new command
            cmbGCodes.DataSource = DatabaseFunctions.GetGCodeCommands();

            // Select the last item (the newly added command)
            cmbGCodes.SelectedIndex = cmbGCodes.Items.Count - 1;
        }

        private void BtnLookup_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe",
                $@"https://marlinfw.org/docs/gcode/{txtBoxSend.Text}.html");
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            lstViewResponse.Items.Clear();
        }

        private void TxtBoxSend_KeyDown(object sender, KeyEventArgs e)
        {
            Send(txtBoxSend.Text);
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
                    Send("M108 R0");
                    Send("M112");
                    break;
            }
            e.Handled = true;
        }

        //private void LstBoxCommunication_DrawItem(object sender, DrawItemEventArgs e)
        //{
        //    if (e.Index < 0) return;

        //    // If the item is selected them change the back color.
        //    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
        //        e = new DrawItemEventArgs(e.Graphics,
        //                                  e.Font,
        //                                  e.Bounds,
        //                                  e.Index,
        //                                  e.State ^ DrawItemState.Selected,
        //                                  e.ForeColor,
        //                                  Color.YellowGreen); // Choose the color.

        //    // Draw the background of the ListBox control for each item.
        //    e.DrawBackground();

        //    // Draw the current item text
        //    e.Graphics.DrawString(lstBoxCommunication.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);

        //    // If the ListBox has focus, draw a focus rectangle around the selected item.
        //    e.DrawFocusRectangle();
        //}

        private void btnSendMultipleCommands_Click(object sender, EventArgs e)
        {
            // Create an instance of Form2 and show it as a dialog
            Form2 form2 = new Form2();
            form2.ShowDialog(this);
        }

        private void cmbGCodes_SelectedValueChanged(object sender, EventArgs e)
        {
            txtBoxSend.Text = cmbGCodes.SelectedItem?.ToString() ?? string.Empty;
        }

        #endregion --- Tabs [Communication] ---

        #region --- Tabs [Temperature Plot] ---

        private void BtnClearPlot_Click(object sender, EventArgs e)
        {
            temperatureChart1.PlotTemperature();
        }

        #endregion --- Tabs [Temperature Plot] ---

        #region --- Tabs [Jog Controls] ---

        private void BtnNegXPosY100(object sender, EventArgs e)
        {
            // TODO
        }

        private void BtnPosY100(object sender, EventArgs e)
        {
            // TODO
        }

        private void BtnPosYPosX100(object sender, EventArgs e)
        {
            // TODO
        }

        private void BtnNegXPosY10(object sender, EventArgs e)
        {
            // TODO
        }

        private void BtnPosY10(object sender, EventArgs e)
        {
            // TODO
        }

        private void BtnNegX1_Click(object sender, EventArgs e)
        {
            // TODO - move X axis -1
            MessageBox.Show("Move X axis -1?", "Confirm Move",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void BtnNegX10_Click(object sender, EventArgs e)
        {
            // TODO - move X axis -10
            MessageBox.Show("Move X axis -10?", "Confirm Move",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            string gcode = GeometryCode.G1(10, 10, 0, 15, 1000);
            Send(gcode);
        }

        private void BtnNegX100_Click(object sender, EventArgs e)
        {
            // TODO - move X axis -100
            MessageBox.Show("Move X axis -100?", "Confirm Move",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void BtnPosX1_Click(object sender, EventArgs e)
        {
            // ToDO - move X axis +1
            MessageBox.Show("Move X axis +1?", "Confirm Move",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void BtnPosX10_Click(object sender, EventArgs e)
        {
            // TODO - move X axis +10
            MessageBox.Show("Move X axis +10?", "Confirm Move",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void BtnPosX100_Click(object sender, EventArgs e)
        {
            // TODO - move X axis +100
            MessageBox.Show("Move X axis +100?", "Confirm Move",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        #endregion --- Tabs [Jog Controls] ---
    }
}