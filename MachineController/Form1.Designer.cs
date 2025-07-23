namespace MachineController
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            grpBoxInitialization = new GroupBox();
            chkVerbose = new CheckBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            cmbBoxBaud = new ComboBox();
            btnRefresh = new Button();
            cmbBoxPort = new ComboBox();
            btnPause = new Button();
            btnPrint = new Button();
            btnConnect = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            btnRunSelectedGCode = new Button();
            btnRemoveFromLibrary = new Button();
            btnAddToLibrary = new Button();
            dgvGCodeLibrary = new DataGridView();
            tabPage2 = new TabPage();
            lstViewResponse = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            btnLookup = new Button();
            cmbGCodes = new ComboBox();
            chkPingWithCommand = new CheckBox();
            btnClear = new Button();
            btnSendMultipleCommands = new Button();
            btnSend = new Button();
            txtBoxSend = new TextBox();
            tabPage3 = new TabPage();
            temperatureChart1 = new MachineController.Controls.TemperatureChart();
            btnClearPlot = new Button();
            chkMonitorTemperatures = new CheckBox();
            tabPage4 = new TabPage();
            btnHomrAll = new Button();
            groupBox2 = new GroupBox();
            chkKeyboardControl = new CheckBox();
            groupBox8 = new GroupBox();
            button25 = new Button();
            button26 = new Button();
            button27 = new Button();
            button28 = new Button();
            button73 = new Button();
            button72 = new Button();
            button71 = new Button();
            button70 = new Button();
            button69 = new Button();
            button68 = new Button();
            button67 = new Button();
            button66 = new Button();
            button65 = new Button();
            button64 = new Button();
            button63 = new Button();
            btnPosYPosX100 = new Button();
            button40 = new Button();
            button39 = new Button();
            btnNegXPosY10 = new Button();
            btnNegXPosY100 = new Button();
            button36 = new Button();
            button35 = new Button();
            button34 = new Button();
            button33 = new Button();
            button32 = new Button();
            button31 = new Button();
            button30 = new Button();
            button29 = new Button();
            button24 = new Button();
            button23 = new Button();
            button22 = new Button();
            button21 = new Button();
            btnPosX100 = new Button();
            btnPosX10 = new Button();
            button18 = new Button();
            btnPosX1 = new Button();
            button16 = new Button();
            btnNegX1 = new Button();
            btnNegX10 = new Button();
            btnNegX100 = new Button();
            btnNegY100 = new Button();
            btnNegY10 = new Button();
            btnNegY1 = new Button();
            btnNegY01 = new Button();
            btnPosY100 = new Button();
            btnPosY01 = new Button();
            btnPosY10 = new Button();
            btnPosY1 = new Button();
            label30 = new Label();
            label31 = new Label();
            label28 = new Label();
            label29 = new Label();
            groupBox3 = new GroupBox();
            label16 = new Label();
            label15 = new Label();
            nudExtruder = new NumericUpDown();
            nudZAxis = new NumericUpDown();
            nudXYAxis = new NumericUpDown();
            label5 = new Label();
            label4 = new Label();
            btnHomeX = new Button();
            btnHomeZ = new Button();
            btnHomeY = new Button();
            pnlWelcome = new Panel();
            label6 = new Label();
            lblWelcome = new Label();
            grpBoxPositionReadout = new GroupBox();
            panel3 = new Panel();
            lblZPosition = new Label();
            panel2 = new Panel();
            lblYPosition = new Label();
            panel1 = new Panel();
            lblXPosition = new Label();
            lblPositionReadoutZ = new Label();
            lblPositionReadoutY = new Label();
            lblPositionReadoutX = new Label();
            btnZeroZ = new Button();
            btnZeroY = new Button();
            btnZeroX = new Button();
            grpBoxAccessoryControl = new GroupBox();
            pnlHeatedBed = new Panel();
            lblHeatedBed = new Label();
            lblExtruderTemperature = new Label();
            pnlExtruder = new Panel();
            label10 = new Label();
            panel5 = new Panel();
            lblBTemperature = new Label();
            panel4 = new Panel();
            lblETemperature = new Label();
            nudHeatedBedTemperature = new NumericUpDown();
            nudExtruderTemperature = new NumericUpDown();
            trkBarSetFanSpeed = new TrackBar();
            btnHeatedBedOn = new Button();
            btnExtruderOn = new Button();
            label13 = new Label();
            label12 = new Label();
            cmbActiveToolhead = new ComboBox();
            label9 = new Label();
            grpBoxCustomCommands = new GroupBox();
            btnSDCardStatus = new Button();
            btnUploadToSDCard = new Button();
            btnPauseCurrentSDPrint = new Button();
            btnPrintFromSDCard = new Button();
            btnEnableMotors = new Button();
            btnDisableMotors = new Button();
            button52 = new Button();
            grpBoxOverrideSettings = new GroupBox();
            label24 = new Label();
            label23 = new Label();
            label22 = new Label();
            label21 = new Label();
            trkBarExtrusion = new TrackBar();
            trkBarNovement = new TrackBar();
            label20 = new Label();
            lblExtrusion = new Label();
            label18 = new Label();
            lblMovement = new Label();
            nubExtrusion = new NumericUpDown();
            nudMovement = new NumericUpDown();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            grpBoxPrintTime = new GroupBox();
            lblPrintTimer = new Label();
            grpBoxInitialization.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGCodeLibrary).BeginInit();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)temperatureChart1).BeginInit();
            tabPage4.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox8.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudExtruder).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudZAxis).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudXYAxis).BeginInit();
            pnlWelcome.SuspendLayout();
            grpBoxPositionReadout.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            grpBoxAccessoryControl.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudHeatedBedTemperature).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudExtruderTemperature).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trkBarSetFanSpeed).BeginInit();
            grpBoxCustomCommands.SuspendLayout();
            grpBoxOverrideSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trkBarExtrusion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trkBarNovement).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nubExtrusion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMovement).BeginInit();
            statusStrip1.SuspendLayout();
            grpBoxPrintTime.SuspendLayout();
            SuspendLayout();
            // 
            // grpBoxInitialization
            // 
            grpBoxInitialization.Controls.Add(chkVerbose);
            grpBoxInitialization.Controls.Add(label3);
            grpBoxInitialization.Controls.Add(label2);
            grpBoxInitialization.Controls.Add(label1);
            grpBoxInitialization.Controls.Add(cmbBoxBaud);
            grpBoxInitialization.Controls.Add(btnRefresh);
            grpBoxInitialization.Controls.Add(cmbBoxPort);
            grpBoxInitialization.Controls.Add(btnPause);
            grpBoxInitialization.Controls.Add(btnPrint);
            grpBoxInitialization.Controls.Add(btnConnect);
            grpBoxInitialization.Font = new Font("Microsoft Sans Serif", 8.25F);
            grpBoxInitialization.Location = new Point(8, 10);
            grpBoxInitialization.Name = "grpBoxInitialization";
            grpBoxInitialization.Size = new Size(436, 111);
            grpBoxInitialization.TabIndex = 0;
            grpBoxInitialization.TabStop = false;
            grpBoxInitialization.Text = "Initialization";
            // 
            // chkVerbose
            // 
            chkVerbose.AutoSize = true;
            chkVerbose.Font = new Font("Microsoft Sans Serif", 8.25F);
            chkVerbose.Location = new Point(370, 83);
            chkVerbose.Name = "chkVerbose";
            chkVerbose.Size = new Size(65, 17);
            chkVerbose.TabIndex = 9;
            chkVerbose.Text = "Verbose";
            chkVerbose.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 8.25F);
            label3.Location = new Point(312, 84);
            label3.Name = "label3";
            label3.Size = new Size(45, 13);
            label3.TabIndex = 8;
            label3.Text = "bits/sec";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 8.25F);
            label2.Location = new Point(9, 82);
            label2.Name = "label2";
            label2.Size = new Size(58, 13);
            label2.TabIndex = 7;
            label2.Text = "Baud Rate";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 8.25F);
            label1.Location = new Point(9, 57);
            label1.Name = "label1";
            label1.Size = new Size(26, 13);
            label1.TabIndex = 6;
            label1.Text = "Port";
            // 
            // cmbBoxBaud
            // 
            cmbBoxBaud.Font = new Font("Microsoft Sans Serif", 8.25F);
            cmbBoxBaud.FormattingEnabled = true;
            cmbBoxBaud.Location = new Point(69, 80);
            cmbBoxBaud.Name = "cmbBoxBaud";
            cmbBoxBaud.Size = new Size(229, 21);
            cmbBoxBaud.TabIndex = 5;
            // 
            // btnRefresh
            // 
            btnRefresh.Font = new Font("Microsoft Sans Serif", 8.25F);
            btnRefresh.Location = new Point(363, 57);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(64, 20);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += BtnRefresh_Click;
            // 
            // cmbBoxPort
            // 
            cmbBoxPort.Font = new Font("Microsoft Sans Serif", 8.25F);
            cmbBoxPort.FormattingEnabled = true;
            cmbBoxPort.Location = new Point(69, 55);
            cmbBoxPort.Name = "cmbBoxPort";
            cmbBoxPort.Size = new Size(284, 21);
            cmbBoxPort.TabIndex = 3;
            // 
            // btnPause
            // 
            btnPause.Enabled = false;
            btnPause.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            btnPause.ForeColor = SystemColors.ControlDarkDark;
            btnPause.Location = new Point(293, 18);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(135, 30);
            btnPause.TabIndex = 2;
            btnPause.Text = "Pause";
            btnPause.UseVisualStyleBackColor = true;
            btnPause.Click += BtnPause_Click;
            // 
            // btnPrint
            // 
            btnPrint.Enabled = false;
            btnPrint.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            btnPrint.ForeColor = SystemColors.ControlDarkDark;
            btnPrint.Location = new Point(151, 18);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(137, 30);
            btnPrint.TabIndex = 1;
            btnPrint.Text = "Print";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += BtnPrint_Click;
            // 
            // btnConnect
            // 
            btnConnect.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            btnConnect.Location = new Point(9, 18);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(136, 30);
            btnConnect.TabIndex = 0;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += BtnConnect_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Enabled = false;
            tabControl1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControl1.Location = new Point(8, 127);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(436, 404);
            tabControl1.TabIndex = 1;
            tabControl1.Visible = false;
            tabControl1.KeyDown += TabControl1_KeyDown;
            // 
            // tabPage1
            // 
            tabPage1.BorderStyle = BorderStyle.Fixed3D;
            tabPage1.Controls.Add(btnRunSelectedGCode);
            tabPage1.Controls.Add(btnRemoveFromLibrary);
            tabPage1.Controls.Add(btnAddToLibrary);
            tabPage1.Controls.Add(dgvGCodeLibrary);
            tabPage1.ForeColor = SystemColors.ControlText;
            tabPage1.Location = new Point(4, 22);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(428, 378);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "G-Code Library";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnRunSelectedGCode
            // 
            btnRunSelectedGCode.Font = new Font("Segoe UI", 9F);
            btnRunSelectedGCode.Location = new Point(290, 354);
            btnRunSelectedGCode.Name = "btnRunSelectedGCode";
            btnRunSelectedGCode.Size = new Size(133, 20);
            btnRunSelectedGCode.TabIndex = 3;
            btnRunSelectedGCode.Text = "Run Selected G-Code";
            btnRunSelectedGCode.UseVisualStyleBackColor = true;
            btnRunSelectedGCode.Click += BtnRunSelectedGCode_Click;
            // 
            // btnRemoveFromLibrary
            // 
            btnRemoveFromLibrary.Location = new Point(147, 354);
            btnRemoveFromLibrary.Name = "btnRemoveFromLibrary";
            btnRemoveFromLibrary.Size = new Size(133, 20);
            btnRemoveFromLibrary.TabIndex = 2;
            btnRemoveFromLibrary.Text = "Remove from Library";
            btnRemoveFromLibrary.UseVisualStyleBackColor = true;
            btnRemoveFromLibrary.Click += BtnRemoveFromLibrary;
            // 
            // btnAddToLibrary
            // 
            btnAddToLibrary.Location = new Point(5, 354);
            btnAddToLibrary.Name = "btnAddToLibrary";
            btnAddToLibrary.Size = new Size(133, 20);
            btnAddToLibrary.TabIndex = 1;
            btnAddToLibrary.Text = "Add to Library";
            btnAddToLibrary.UseVisualStyleBackColor = true;
            btnAddToLibrary.Click += BtnAddToLibrary_Click;
            // 
            // dgvGCodeLibrary
            // 
            dgvGCodeLibrary.AllowUserToAddRows = false;
            dgvGCodeLibrary.AllowUserToOrderColumns = true;
            dgvGCodeLibrary.AllowUserToResizeRows = false;
            dgvGCodeLibrary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGCodeLibrary.Dock = DockStyle.Top;
            dgvGCodeLibrary.Location = new Point(3, 3);
            dgvGCodeLibrary.Name = "dgvGCodeLibrary";
            dgvGCodeLibrary.ReadOnly = true;
            dgvGCodeLibrary.Size = new Size(418, 344);
            dgvGCodeLibrary.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.BorderStyle = BorderStyle.Fixed3D;
            tabPage2.Controls.Add(lstViewResponse);
            tabPage2.Controls.Add(btnLookup);
            tabPage2.Controls.Add(cmbGCodes);
            tabPage2.Controls.Add(chkPingWithCommand);
            tabPage2.Controls.Add(btnClear);
            tabPage2.Controls.Add(btnSendMultipleCommands);
            tabPage2.Controls.Add(btnSend);
            tabPage2.Controls.Add(txtBoxSend);
            tabPage2.ForeColor = SystemColors.ControlText;
            tabPage2.Location = new Point(4, 22);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(428, 378);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Communication";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // lstViewResponse
            // 
            lstViewResponse.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            lstViewResponse.Dock = DockStyle.Top;
            lstViewResponse.Font = new Font("Courier New", 7.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstViewResponse.FullRowSelect = true;
            lstViewResponse.GridLines = true;
            lstViewResponse.HeaderStyle = ColumnHeaderStyle.None;
            lstViewResponse.HideSelection = true;
            lstViewResponse.LabelWrap = false;
            lstViewResponse.Location = new Point(3, 3);
            lstViewResponse.Name = "lstViewResponse";
            lstViewResponse.Size = new Size(418, 313);
            lstViewResponse.TabIndex = 10;
            lstViewResponse.UseCompatibleStateImageBehavior = false;
            lstViewResponse.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Type";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Data";
            // 
            // btnLookup
            // 
            btnLookup.Location = new Point(355, 324);
            btnLookup.Name = "btnLookup";
            btnLookup.Size = new Size(64, 20);
            btnLookup.TabIndex = 9;
            btnLookup.Text = "Lookup";
            btnLookup.UseVisualStyleBackColor = true;
            btnLookup.Click += BtnLookup_Click;
            // 
            // cmbGCodes
            // 
            cmbGCodes.FormattingEnabled = true;
            cmbGCodes.Items.AddRange(new object[] { "M105" });
            cmbGCodes.Location = new Point(218, 350);
            cmbGCodes.Name = "cmbGCodes";
            cmbGCodes.Size = new Size(131, 21);
            cmbGCodes.TabIndex = 8;
            cmbGCodes.SelectedValueChanged += cmbGCodes_SelectedValueChanged;
            // 
            // chkPingWithCommand
            // 
            chkPingWithCommand.AutoSize = true;
            chkPingWithCommand.Location = new Point(355, 352);
            chkPingWithCommand.Name = "chkPingWithCommand";
            chkPingWithCommand.Size = new Size(53, 17);
            chkPingWithCommand.TabIndex = 7;
            chkPingWithCommand.Text = "Ping?";
            chkPingWithCommand.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(285, 324);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(64, 20);
            btnClear.TabIndex = 6;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += BtnClear_Click;
            // 
            // btnSendMultipleCommands
            // 
            btnSendMultipleCommands.Enabled = false;
            btnSendMultipleCommands.Location = new Point(5, 351);
            btnSendMultipleCommands.Name = "btnSendMultipleCommands";
            btnSendMultipleCommands.Size = new Size(207, 20);
            btnSendMultipleCommands.TabIndex = 5;
            btnSendMultipleCommands.Text = "Send Multiple Commands";
            btnSendMultipleCommands.UseVisualStyleBackColor = true;
            btnSendMultipleCommands.Click += btnSendMultipleCommands_Click;
            // 
            // btnSend
            // 
            btnSend.Enabled = false;
            btnSend.Location = new Point(218, 325);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(64, 20);
            btnSend.TabIndex = 2;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += BtnSend_Click;
            // 
            // txtBoxSend
            // 
            txtBoxSend.Enabled = false;
            txtBoxSend.Location = new Point(5, 325);
            txtBoxSend.Name = "txtBoxSend";
            txtBoxSend.Size = new Size(207, 20);
            txtBoxSend.TabIndex = 1;
            txtBoxSend.KeyDown += TxtBoxSend_KeyDown;
            // 
            // tabPage3
            // 
            tabPage3.BorderStyle = BorderStyle.Fixed3D;
            tabPage3.Controls.Add(temperatureChart1);
            tabPage3.Controls.Add(btnClearPlot);
            tabPage3.Controls.Add(chkMonitorTemperatures);
            tabPage3.ForeColor = SystemColors.ControlText;
            tabPage3.Location = new Point(4, 22);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(428, 378);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Temperature Plot";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // temperatureChart1
            // 
            temperatureChart1.Dock = DockStyle.Top;
            temperatureChart1.Location = new Point(3, 3);
            temperatureChart1.Name = "temperatureChart1";
            temperatureChart1.Size = new Size(418, 350);
            temperatureChart1.TabIndex = 3;
            temperatureChart1.TabStop = false;
            temperatureChart1.Text = "temperatureChart1";
            // 
            // btnClearPlot
            // 
            btnClearPlot.Location = new Point(236, 356);
            btnClearPlot.Name = "btnClearPlot";
            btnClearPlot.Size = new Size(84, 20);
            btnClearPlot.TabIndex = 2;
            btnClearPlot.Text = "Clear Plot Data";
            btnClearPlot.UseVisualStyleBackColor = true;
            btnClearPlot.Click += BtnClearPlot_Click;
            // 
            // chkMonitorTemperatures
            // 
            chkMonitorTemperatures.AutoSize = true;
            chkMonitorTemperatures.Location = new Point(101, 359);
            chkMonitorTemperatures.Name = "chkMonitorTemperatures";
            chkMonitorTemperatures.Size = new Size(129, 17);
            chkMonitorTemperatures.TabIndex = 1;
            chkMonitorTemperatures.Text = "Monitor Temperatures";
            chkMonitorTemperatures.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.BorderStyle = BorderStyle.Fixed3D;
            tabPage4.Controls.Add(btnHomrAll);
            tabPage4.Controls.Add(groupBox2);
            tabPage4.Controls.Add(groupBox3);
            tabPage4.Controls.Add(btnHomeX);
            tabPage4.Controls.Add(btnHomeZ);
            tabPage4.Controls.Add(btnHomeY);
            tabPage4.ForeColor = SystemColors.ControlText;
            tabPage4.Location = new Point(4, 22);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(428, 378);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Jog Controls";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnHomrAll
            // 
            btnHomrAll.Location = new Point(324, 353);
            btnHomrAll.Name = "btnHomrAll";
            btnHomrAll.Size = new Size(98, 20);
            btnHomrAll.TabIndex = 41;
            btnHomrAll.Text = "Home All";
            btnHomrAll.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(chkKeyboardControl);
            groupBox2.Controls.Add(groupBox8);
            groupBox2.Controls.Add(button73);
            groupBox2.Controls.Add(button72);
            groupBox2.Controls.Add(button71);
            groupBox2.Controls.Add(button70);
            groupBox2.Controls.Add(button69);
            groupBox2.Controls.Add(button68);
            groupBox2.Controls.Add(button67);
            groupBox2.Controls.Add(button66);
            groupBox2.Controls.Add(button65);
            groupBox2.Controls.Add(button64);
            groupBox2.Controls.Add(button63);
            groupBox2.Controls.Add(btnPosYPosX100);
            groupBox2.Controls.Add(button40);
            groupBox2.Controls.Add(button39);
            groupBox2.Controls.Add(btnNegXPosY10);
            groupBox2.Controls.Add(btnNegXPosY100);
            groupBox2.Controls.Add(button36);
            groupBox2.Controls.Add(button35);
            groupBox2.Controls.Add(button34);
            groupBox2.Controls.Add(button33);
            groupBox2.Controls.Add(button32);
            groupBox2.Controls.Add(button31);
            groupBox2.Controls.Add(button30);
            groupBox2.Controls.Add(button29);
            groupBox2.Controls.Add(button24);
            groupBox2.Controls.Add(button23);
            groupBox2.Controls.Add(button22);
            groupBox2.Controls.Add(button21);
            groupBox2.Controls.Add(btnPosX100);
            groupBox2.Controls.Add(btnPosX10);
            groupBox2.Controls.Add(button18);
            groupBox2.Controls.Add(btnPosX1);
            groupBox2.Controls.Add(button16);
            groupBox2.Controls.Add(btnNegX1);
            groupBox2.Controls.Add(btnNegX10);
            groupBox2.Controls.Add(btnNegX100);
            groupBox2.Controls.Add(btnNegY100);
            groupBox2.Controls.Add(btnNegY10);
            groupBox2.Controls.Add(btnNegY1);
            groupBox2.Controls.Add(btnNegY01);
            groupBox2.Controls.Add(btnPosY100);
            groupBox2.Controls.Add(btnPosY01);
            groupBox2.Controls.Add(btnPosY10);
            groupBox2.Controls.Add(btnPosY1);
            groupBox2.Controls.Add(label30);
            groupBox2.Controls.Add(label31);
            groupBox2.Controls.Add(label28);
            groupBox2.Controls.Add(label29);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Font = new Font("Microsoft Sans Serif", 8.25F);
            groupBox2.Location = new Point(3, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(418, 270);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Control";
            // 
            // chkKeyboardControl
            // 
            chkKeyboardControl.AutoSize = true;
            chkKeyboardControl.Checked = true;
            chkKeyboardControl.CheckState = CheckState.Checked;
            chkKeyboardControl.Location = new Point(298, 251);
            chkKeyboardControl.Name = "chkKeyboardControl";
            chkKeyboardControl.Size = new Size(107, 17);
            chkKeyboardControl.TabIndex = 58;
            chkKeyboardControl.Text = "Keyboard Control";
            chkKeyboardControl.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(button25);
            groupBox8.Controls.Add(button26);
            groupBox8.Controls.Add(button27);
            groupBox8.Controls.Add(button28);
            groupBox8.Font = new Font("Microsoft Sans Serif", 8.25F);
            groupBox8.Location = new Point(261, 127);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(80, 119);
            groupBox8.TabIndex = 57;
            groupBox8.TabStop = false;
            groupBox8.Text = "Move Z Down";
            // 
            // button25
            // 
            button25.BackColor = Color.DimGray;
            button25.Font = new Font("Candara", 9F, FontStyle.Bold);
            button25.Location = new Point(9, 15);
            button25.Name = "button25";
            button25.Size = new Size(64, 20);
            button25.TabIndex = 20;
            button25.Text = "-0.1";
            button25.UseVisualStyleBackColor = false;
            // 
            // button26
            // 
            button26.BackColor = Color.Gray;
            button26.Font = new Font("Candara", 9F, FontStyle.Bold);
            button26.Location = new Point(9, 41);
            button26.Name = "button26";
            button26.Size = new Size(64, 20);
            button26.TabIndex = 21;
            button26.Text = "-1";
            button26.UseVisualStyleBackColor = false;
            // 
            // button27
            // 
            button27.BackColor = Color.DarkGray;
            button27.Font = new Font("Candara", 9F, FontStyle.Bold);
            button27.Location = new Point(9, 66);
            button27.Name = "button27";
            button27.Size = new Size(64, 20);
            button27.TabIndex = 22;
            button27.Text = "-10";
            button27.UseVisualStyleBackColor = false;
            // 
            // button28
            // 
            button28.BackColor = Color.DarkGray;
            button28.Font = new Font("Candara", 9F, FontStyle.Bold);
            button28.Location = new Point(9, 91);
            button28.Name = "button28";
            button28.Size = new Size(64, 20);
            button28.TabIndex = 23;
            button28.Text = "-100";
            button28.UseVisualStyleBackColor = false;
            // 
            // button73
            // 
            button73.BackColor = Color.Black;
            button73.Cursor = Cursors.PanSW;
            button73.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            button73.Location = new Point(87, 159);
            button73.Name = "button73";
            button73.Size = new Size(21, 22);
            button73.TabIndex = 48;
            button73.UseVisualStyleBackColor = false;
            // 
            // button72
            // 
            button72.BackColor = Color.Black;
            button72.Cursor = Cursors.PanSW;
            button72.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            button72.Location = new Point(65, 181);
            button72.Name = "button72";
            button72.Size = new Size(21, 22);
            button72.TabIndex = 47;
            button72.UseVisualStyleBackColor = false;
            // 
            // button71
            // 
            button71.BackColor = Color.Black;
            button71.Cursor = Cursors.PanSW;
            button71.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            button71.Location = new Point(44, 203);
            button71.Name = "button71";
            button71.Size = new Size(21, 22);
            button71.TabIndex = 46;
            button71.UseVisualStyleBackColor = false;
            // 
            // button70
            // 
            button70.BackColor = Color.Black;
            button70.Cursor = Cursors.PanSW;
            button70.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            button70.Location = new Point(22, 224);
            button70.Name = "button70";
            button70.Size = new Size(21, 22);
            button70.TabIndex = 45;
            button70.UseVisualStyleBackColor = false;
            // 
            // button69
            // 
            button69.BackColor = Color.Black;
            button69.Cursor = Cursors.PanSE;
            button69.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            button69.Location = new Point(151, 159);
            button69.Name = "button69";
            button69.Size = new Size(21, 22);
            button69.TabIndex = 44;
            button69.UseVisualStyleBackColor = false;
            // 
            // button68
            // 
            button68.BackColor = Color.Black;
            button68.Cursor = Cursors.PanSE;
            button68.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            button68.Location = new Point(172, 181);
            button68.Name = "button68";
            button68.Size = new Size(21, 22);
            button68.TabIndex = 43;
            button68.UseVisualStyleBackColor = false;
            // 
            // button67
            // 
            button67.BackColor = Color.Black;
            button67.Cursor = Cursors.PanSE;
            button67.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            button67.Location = new Point(194, 203);
            button67.Name = "button67";
            button67.Size = new Size(21, 22);
            button67.TabIndex = 42;
            button67.UseVisualStyleBackColor = false;
            // 
            // button66
            // 
            button66.BackColor = Color.Black;
            button66.Cursor = Cursors.PanSE;
            button66.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            button66.Location = new Point(215, 224);
            button66.Name = "button66";
            button66.Size = new Size(21, 22);
            button66.TabIndex = 41;
            button66.UseVisualStyleBackColor = false;
            // 
            // button65
            // 
            button65.BackColor = Color.Black;
            button65.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            button65.Location = new Point(151, 94);
            button65.Name = "button65";
            button65.Size = new Size(21, 22);
            button65.TabIndex = 40;
            button65.UseVisualStyleBackColor = false;
            // 
            // button64
            // 
            button64.BackColor = Color.Black;
            button64.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            button64.Location = new Point(172, 73);
            button64.Name = "button64";
            button64.Size = new Size(21, 22);
            button64.TabIndex = 39;
            button64.UseVisualStyleBackColor = false;
            // 
            // button63
            // 
            button63.BackColor = Color.Black;
            button63.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            button63.Location = new Point(194, 51);
            button63.Name = "button63";
            button63.Size = new Size(21, 22);
            button63.TabIndex = 38;
            button63.UseVisualStyleBackColor = false;
            // 
            // btnPosYPosX100
            // 
            btnPosYPosX100.BackColor = Color.Black;
            btnPosYPosX100.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            btnPosYPosX100.Location = new Point(215, 29);
            btnPosYPosX100.Name = "btnPosYPosX100";
            btnPosYPosX100.Size = new Size(21, 22);
            btnPosYPosX100.TabIndex = 37;
            btnPosYPosX100.UseVisualStyleBackColor = false;
            btnPosYPosX100.Click += BtnPosYPosX100;
            // 
            // button40
            // 
            button40.BackColor = Color.Black;
            button40.Cursor = Cursors.PanNW;
            button40.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            button40.Location = new Point(87, 94);
            button40.Name = "button40";
            button40.Size = new Size(21, 22);
            button40.TabIndex = 36;
            button40.UseVisualStyleBackColor = false;
            // 
            // button39
            // 
            button39.BackColor = Color.Black;
            button39.Cursor = Cursors.PanNW;
            button39.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            button39.Location = new Point(65, 73);
            button39.Name = "button39";
            button39.Size = new Size(21, 22);
            button39.TabIndex = 35;
            button39.UseVisualStyleBackColor = false;
            // 
            // btnNegXPosY10
            // 
            btnNegXPosY10.BackColor = Color.Black;
            btnNegXPosY10.Cursor = Cursors.PanNW;
            btnNegXPosY10.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            btnNegXPosY10.Location = new Point(44, 51);
            btnNegXPosY10.Name = "btnNegXPosY10";
            btnNegXPosY10.Size = new Size(21, 22);
            btnNegXPosY10.TabIndex = 34;
            btnNegXPosY10.UseVisualStyleBackColor = false;
            btnNegXPosY10.Click += BtnNegXPosY10;
            // 
            // btnNegXPosY100
            // 
            btnNegXPosY100.BackColor = Color.Black;
            btnNegXPosY100.Cursor = Cursors.PanNW;
            btnNegXPosY100.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            btnNegXPosY100.Location = new Point(22, 29);
            btnNegXPosY100.Name = "btnNegXPosY100";
            btnNegXPosY100.Size = new Size(21, 22);
            btnNegXPosY100.TabIndex = 33;
            btnNegXPosY100.UseVisualStyleBackColor = false;
            btnNegXPosY100.Click += BtnNegXPosY100;
            // 
            // button36
            // 
            button36.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            button36.Location = new Point(343, 224);
            button36.Name = "button36";
            button36.Size = new Size(64, 20);
            button36.TabIndex = 31;
            button36.Text = "-100";
            button36.UseVisualStyleBackColor = true;
            // 
            // button35
            // 
            button35.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            button35.Location = new Point(343, 198);
            button35.Name = "button35";
            button35.Size = new Size(64, 20);
            button35.TabIndex = 30;
            button35.Text = "-10";
            button35.UseVisualStyleBackColor = true;
            // 
            // button34
            // 
            button34.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            button34.Location = new Point(343, 172);
            button34.Name = "button34";
            button34.Size = new Size(64, 20);
            button34.TabIndex = 29;
            button34.Text = "-1";
            button34.UseVisualStyleBackColor = true;
            // 
            // button33
            // 
            button33.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            button33.Location = new Point(343, 147);
            button33.Name = "button33";
            button33.Size = new Size(64, 20);
            button33.TabIndex = 28;
            button33.Text = "-0.1";
            button33.UseVisualStyleBackColor = true;
            // 
            // button32
            // 
            button32.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            button32.Location = new Point(343, 103);
            button32.Name = "button32";
            button32.Size = new Size(64, 20);
            button32.TabIndex = 27;
            button32.Text = "0.1";
            button32.UseVisualStyleBackColor = true;
            // 
            // button31
            // 
            button31.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            button31.Location = new Point(343, 78);
            button31.Name = "button31";
            button31.Size = new Size(64, 20);
            button31.TabIndex = 26;
            button31.Text = "1";
            button31.UseVisualStyleBackColor = true;
            // 
            // button30
            // 
            button30.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            button30.Location = new Point(343, 55);
            button30.Name = "button30";
            button30.Size = new Size(64, 20);
            button30.TabIndex = 25;
            button30.Text = "10";
            button30.UseVisualStyleBackColor = true;
            // 
            // button29
            // 
            button29.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            button29.Location = new Point(343, 29);
            button29.Name = "button29";
            button29.Size = new Size(64, 20);
            button29.TabIndex = 24;
            button29.Text = "100";
            button29.UseVisualStyleBackColor = true;
            // 
            // button24
            // 
            button24.BackColor = Color.DimGray;
            button24.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            button24.Location = new Point(273, 103);
            button24.Name = "button24";
            button24.Size = new Size(64, 20);
            button24.TabIndex = 19;
            button24.Text = "0.1";
            button24.UseVisualStyleBackColor = false;
            // 
            // button23
            // 
            button23.BackColor = Color.Gray;
            button23.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            button23.Location = new Point(273, 78);
            button23.Name = "button23";
            button23.Size = new Size(64, 20);
            button23.TabIndex = 18;
            button23.Text = "1";
            button23.UseVisualStyleBackColor = false;
            // 
            // button22
            // 
            button22.BackColor = Color.DarkGray;
            button22.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            button22.Location = new Point(273, 55);
            button22.Name = "button22";
            button22.Size = new Size(64, 20);
            button22.TabIndex = 17;
            button22.Text = "10";
            button22.UseVisualStyleBackColor = false;
            // 
            // button21
            // 
            button21.BackColor = Color.DarkGray;
            button21.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            button21.Location = new Point(273, 29);
            button21.Name = "button21";
            button21.Size = new Size(64, 20);
            button21.TabIndex = 16;
            button21.Text = "100";
            button21.UseVisualStyleBackColor = false;
            // 
            // btnPosX100
            // 
            btnPosX100.BackColor = Color.Silver;
            btnPosX100.Cursor = Cursors.PanEast;
            btnPosX100.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            btnPosX100.Location = new Point(215, 51);
            btnPosX100.Name = "btnPosX100";
            btnPosX100.Size = new Size(21, 173);
            btnPosX100.TabIndex = 15;
            btnPosX100.Text = "1 0 0";
            btnPosX100.UseVisualStyleBackColor = false;
            btnPosX100.Click += BtnPosX100_Click;
            // 
            // btnPosX10
            // 
            btnPosX10.BackColor = Color.DarkGray;
            btnPosX10.Cursor = Cursors.PanEast;
            btnPosX10.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            btnPosX10.Location = new Point(194, 73);
            btnPosX10.Name = "btnPosX10";
            btnPosX10.Size = new Size(21, 130);
            btnPosX10.TabIndex = 14;
            btnPosX10.Text = "1 0";
            btnPosX10.UseVisualStyleBackColor = false;
            btnPosX10.Click += BtnPosX10_Click;
            // 
            // button18
            // 
            button18.BackColor = Color.Gray;
            button18.Cursor = Cursors.PanEast;
            button18.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            button18.Location = new Point(172, 94);
            button18.Name = "button18";
            button18.Size = new Size(21, 87);
            button18.TabIndex = 13;
            button18.Text = "1";
            button18.UseVisualStyleBackColor = false;
            // 
            // btnPosX1
            // 
            btnPosX1.BackColor = Color.DimGray;
            btnPosX1.Cursor = Cursors.PanEast;
            btnPosX1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            btnPosX1.ForeColor = SystemColors.ControlText;
            btnPosX1.Location = new Point(151, 116);
            btnPosX1.Name = "btnPosX1";
            btnPosX1.Size = new Size(21, 43);
            btnPosX1.TabIndex = 12;
            btnPosX1.Text = "0.1";
            btnPosX1.UseVisualStyleBackColor = false;
            btnPosX1.Click += BtnPosX1_Click;
            // 
            // button16
            // 
            button16.BackColor = Color.DimGray;
            button16.Cursor = Cursors.PanWest;
            button16.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            button16.Location = new Point(87, 116);
            button16.Name = "button16";
            button16.Size = new Size(21, 43);
            button16.TabIndex = 11;
            button16.Text = "-0.1";
            button16.UseVisualStyleBackColor = false;
            // 
            // btnNegX1
            // 
            btnNegX1.BackColor = Color.Gray;
            btnNegX1.Cursor = Cursors.PanWest;
            btnNegX1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            btnNegX1.Location = new Point(65, 94);
            btnNegX1.Name = "btnNegX1";
            btnNegX1.Size = new Size(21, 87);
            btnNegX1.TabIndex = 10;
            btnNegX1.Text = "-1";
            btnNegX1.UseVisualStyleBackColor = false;
            btnNegX1.Click += BtnNegX1_Click;
            // 
            // btnNegX10
            // 
            btnNegX10.BackColor = Color.DarkGray;
            btnNegX10.Cursor = Cursors.PanWest;
            btnNegX10.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            btnNegX10.Location = new Point(44, 73);
            btnNegX10.Name = "btnNegX10";
            btnNegX10.Size = new Size(21, 130);
            btnNegX10.TabIndex = 9;
            btnNegX10.Text = "-1 0";
            btnNegX10.UseVisualStyleBackColor = false;
            btnNegX10.Click += BtnNegX10_Click;
            // 
            // btnNegX100
            // 
            btnNegX100.BackColor = Color.Silver;
            btnNegX100.Cursor = Cursors.PanWest;
            btnNegX100.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            btnNegX100.Location = new Point(22, 51);
            btnNegX100.Name = "btnNegX100";
            btnNegX100.Size = new Size(21, 173);
            btnNegX100.TabIndex = 8;
            btnNegX100.Text = "-1 0 0";
            btnNegX100.UseVisualStyleBackColor = false;
            btnNegX100.Click += BtnNegX100_Click;
            // 
            // btnNegY100
            // 
            btnNegY100.BackColor = Color.Silver;
            btnNegY100.Cursor = Cursors.PanSouth;
            btnNegY100.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            btnNegY100.Location = new Point(44, 224);
            btnNegY100.Name = "btnNegY100";
            btnNegY100.Size = new Size(171, 22);
            btnNegY100.TabIndex = 7;
            btnNegY100.Text = "-100";
            btnNegY100.UseVisualStyleBackColor = false;
            // 
            // btnNegY10
            // 
            btnNegY10.BackColor = Color.DarkGray;
            btnNegY10.Cursor = Cursors.PanSouth;
            btnNegY10.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            btnNegY10.Location = new Point(65, 203);
            btnNegY10.Name = "btnNegY10";
            btnNegY10.Size = new Size(129, 22);
            btnNegY10.TabIndex = 6;
            btnNegY10.Text = "-10";
            btnNegY10.UseVisualStyleBackColor = false;
            // 
            // btnNegY1
            // 
            btnNegY1.BackColor = Color.Gray;
            btnNegY1.Cursor = Cursors.PanSouth;
            btnNegY1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            btnNegY1.Location = new Point(82, 181);
            btnNegY1.Name = "btnNegY1";
            btnNegY1.Size = new Size(86, 22);
            btnNegY1.TabIndex = 5;
            btnNegY1.Text = "-1";
            btnNegY1.UseVisualStyleBackColor = false;
            // 
            // btnNegY01
            // 
            btnNegY01.BackColor = Color.DimGray;
            btnNegY01.Cursor = Cursors.PanSouth;
            btnNegY01.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            btnNegY01.Location = new Point(108, 159);
            btnNegY01.Name = "btnNegY01";
            btnNegY01.Size = new Size(43, 22);
            btnNegY01.TabIndex = 4;
            btnNegY01.Text = "-0.1";
            btnNegY01.UseVisualStyleBackColor = false;
            // 
            // btnPosY100
            // 
            btnPosY100.BackColor = Color.Silver;
            btnPosY100.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            btnPosY100.Location = new Point(44, 29);
            btnPosY100.Name = "btnPosY100";
            btnPosY100.Size = new Size(171, 22);
            btnPosY100.TabIndex = 0;
            btnPosY100.Text = "100";
            btnPosY100.UseVisualStyleBackColor = false;
            btnPosY100.Click += BtnPosY100;
            // 
            // btnPosY01
            // 
            btnPosY01.BackColor = Color.DimGray;
            btnPosY01.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            btnPosY01.Location = new Point(108, 94);
            btnPosY01.Name = "btnPosY01";
            btnPosY01.Size = new Size(43, 22);
            btnPosY01.TabIndex = 3;
            btnPosY01.Text = "0.1";
            btnPosY01.UseVisualStyleBackColor = false;
            // 
            // btnPosY10
            // 
            btnPosY10.BackColor = Color.DarkGray;
            btnPosY10.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            btnPosY10.Location = new Point(65, 51);
            btnPosY10.Name = "btnPosY10";
            btnPosY10.Size = new Size(129, 22);
            btnPosY10.TabIndex = 1;
            btnPosY10.Text = "10";
            btnPosY10.UseVisualStyleBackColor = false;
            btnPosY10.Click += BtnPosY10;
            // 
            // btnPosY1
            // 
            btnPosY1.BackColor = Color.Gray;
            btnPosY1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            btnPosY1.Location = new Point(87, 73);
            btnPosY1.Name = "btnPosY1";
            btnPosY1.Size = new Size(86, 22);
            btnPosY1.TabIndex = 2;
            btnPosY1.Text = "1";
            btnPosY1.UseVisualStyleBackColor = false;
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            label30.Location = new Point(233, 126);
            label30.Name = "label30";
            label30.Size = new Size(22, 13);
            label30.TabIndex = 51;
            label30.Text = "+X";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            label31.Location = new Point(2, 126);
            label31.Name = "label31";
            label31.Size = new Size(19, 13);
            label31.TabIndex = 52;
            label31.Text = "-X";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            label28.Location = new Point(113, 10);
            label28.Name = "label28";
            label28.Size = new Size(22, 13);
            label28.TabIndex = 49;
            label28.Text = "+Y";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            label29.Location = new Point(118, 244);
            label29.Name = "label29";
            label29.Size = new Size(19, 13);
            label29.TabIndex = 50;
            label29.Text = "-Y";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label16);
            groupBox3.Controls.Add(label15);
            groupBox3.Controls.Add(nudExtruder);
            groupBox3.Controls.Add(nudZAxis);
            groupBox3.Controls.Add(nudXYAxis);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(label4);
            groupBox3.Location = new Point(12, 288);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(412, 60);
            groupBox3.TabIndex = 32;
            groupBox3.TabStop = false;
            groupBox3.Text = "Jog Speeds";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(312, 15);
            label16.Name = "label16";
            label16.Size = new Size(46, 13);
            label16.TabIndex = 9;
            label16.Text = "Extruder";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(208, 15);
            label15.Name = "label15";
            label15.Size = new Size(36, 13);
            label15.TabIndex = 8;
            label15.Text = "Z Axis";
            // 
            // nudExtruder
            // 
            nudExtruder.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            nudExtruder.Location = new Point(312, 32);
            nudExtruder.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            nudExtruder.Name = "nudExtruder";
            nudExtruder.Size = new Size(97, 20);
            nudExtruder.TabIndex = 7;
            // 
            // nudZAxis
            // 
            nudZAxis.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            nudZAxis.Location = new Point(209, 32);
            nudZAxis.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            nudZAxis.Name = "nudZAxis";
            nudZAxis.Size = new Size(98, 20);
            nudZAxis.TabIndex = 6;
            // 
            // nudXYAxis
            // 
            nudXYAxis.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            nudXYAxis.Location = new Point(105, 32);
            nudXYAxis.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            nudXYAxis.Name = "nudXYAxis";
            nudXYAxis.Size = new Size(98, 20);
            nudXYAxis.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(104, 14);
            label5.Name = "label5";
            label5.Size = new Size(48, 13);
            label5.TabIndex = 4;
            label5.Text = "X/Y Axis";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 32);
            label4.Name = "label4";
            label4.Size = new Size(73, 13);
            label4.TabIndex = 3;
            label4.Text = "Speed (mm/s)";
            // 
            // btnHomeX
            // 
            btnHomeX.Location = new Point(12, 353);
            btnHomeX.Name = "btnHomeX";
            btnHomeX.Size = new Size(99, 20);
            btnHomeX.TabIndex = 38;
            btnHomeX.Text = "Home X";
            btnHomeX.UseVisualStyleBackColor = true;
            // 
            // btnHomeZ
            // 
            btnHomeZ.Location = new Point(220, 353);
            btnHomeZ.Name = "btnHomeZ";
            btnHomeZ.Size = new Size(99, 20);
            btnHomeZ.TabIndex = 40;
            btnHomeZ.Text = "Home Z";
            btnHomeZ.UseVisualStyleBackColor = true;
            // 
            // btnHomeY
            // 
            btnHomeY.Location = new Point(116, 353);
            btnHomeY.Name = "btnHomeY";
            btnHomeY.Size = new Size(99, 20);
            btnHomeY.TabIndex = 39;
            btnHomeY.Text = "Home Y";
            btnHomeY.UseVisualStyleBackColor = true;
            // 
            // pnlWelcome
            // 
            pnlWelcome.BackColor = SystemColors.ControlDarkDark;
            pnlWelcome.BorderStyle = BorderStyle.Fixed3D;
            pnlWelcome.Controls.Add(label6);
            pnlWelcome.Controls.Add(lblWelcome);
            pnlWelcome.Location = new Point(687, 57);
            pnlWelcome.Name = "pnlWelcome";
            pnlWelcome.Size = new Size(40, 46);
            pnlWelcome.TabIndex = 45;
            // 
            // label6
            // 
            label6.ForeColor = SystemColors.Control;
            label6.Location = new Point(13, 48);
            label6.Name = "label6";
            label6.Size = new Size(357, 150);
            label6.TabIndex = 1;
            label6.Text = resources.GetString("label6.Text");
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.ForeColor = SystemColors.ControlLight;
            lblWelcome.Location = new Point(3, 9);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(129, 29);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome!";
            // 
            // grpBoxPositionReadout
            // 
            grpBoxPositionReadout.Controls.Add(panel3);
            grpBoxPositionReadout.Controls.Add(panel2);
            grpBoxPositionReadout.Controls.Add(panel1);
            grpBoxPositionReadout.Controls.Add(lblPositionReadoutZ);
            grpBoxPositionReadout.Controls.Add(lblPositionReadoutY);
            grpBoxPositionReadout.Controls.Add(lblPositionReadoutX);
            grpBoxPositionReadout.Controls.Add(btnZeroZ);
            grpBoxPositionReadout.Controls.Add(btnZeroY);
            grpBoxPositionReadout.Controls.Add(btnZeroX);
            grpBoxPositionReadout.ForeColor = SystemColors.ControlText;
            grpBoxPositionReadout.Location = new Point(449, 10);
            grpBoxPositionReadout.Name = "grpBoxPositionReadout";
            grpBoxPositionReadout.Size = new Size(232, 111);
            grpBoxPositionReadout.TabIndex = 2;
            grpBoxPositionReadout.TabStop = false;
            grpBoxPositionReadout.Text = "Position Readout";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Black;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(lblZPosition);
            panel3.Font = new Font("Candara", 9F);
            panel3.Location = new Point(29, 69);
            panel3.Name = "panel3";
            panel3.Size = new Size(125, 24);
            panel3.TabIndex = 9;
            // 
            // lblZPosition
            // 
            lblZPosition.AutoSize = true;
            lblZPosition.Dock = DockStyle.Right;
            lblZPosition.Font = new Font("Candara", 8.25F);
            lblZPosition.ForeColor = Color.White;
            lblZPosition.Location = new Point(76, 0);
            lblZPosition.Name = "lblZPosition";
            lblZPosition.Size = new Size(47, 13);
            lblZPosition.TabIndex = 0;
            lblZPosition.Text = "12345.00";
            lblZPosition.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(lblYPosition);
            panel2.Font = new Font("Candara", 9F);
            panel2.Location = new Point(30, 43);
            panel2.Name = "panel2";
            panel2.Size = new Size(125, 24);
            panel2.TabIndex = 8;
            // 
            // lblYPosition
            // 
            lblYPosition.AutoSize = true;
            lblYPosition.Dock = DockStyle.Right;
            lblYPosition.Font = new Font("Candara", 8.25F);
            lblYPosition.ForeColor = Color.White;
            lblYPosition.Location = new Point(76, 0);
            lblYPosition.Name = "lblYPosition";
            lblYPosition.Size = new Size(47, 13);
            lblYPosition.TabIndex = 0;
            lblYPosition.Text = "12345.00";
            lblYPosition.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblXPosition);
            panel1.Font = new Font("Candara", 9F);
            panel1.Location = new Point(30, 18);
            panel1.Name = "panel1";
            panel1.Size = new Size(125, 24);
            panel1.TabIndex = 7;
            // 
            // lblXPosition
            // 
            lblXPosition.AutoSize = true;
            lblXPosition.Dock = DockStyle.Right;
            lblXPosition.Font = new Font("Candara", 8.25F);
            lblXPosition.ForeColor = Color.White;
            lblXPosition.Location = new Point(76, 0);
            lblXPosition.Name = "lblXPosition";
            lblXPosition.Size = new Size(47, 13);
            lblXPosition.TabIndex = 0;
            lblXPosition.Text = "12345.00";
            lblXPosition.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPositionReadoutZ
            // 
            lblPositionReadoutZ.AutoSize = true;
            lblPositionReadoutZ.Font = new Font("Candara", 15.75F, FontStyle.Bold);
            lblPositionReadoutZ.Location = new Point(9, 69);
            lblPositionReadoutZ.Name = "lblPositionReadoutZ";
            lblPositionReadoutZ.Size = new Size(23, 26);
            lblPositionReadoutZ.TabIndex = 8;
            lblPositionReadoutZ.Text = "Z";
            // 
            // lblPositionReadoutY
            // 
            lblPositionReadoutY.AutoSize = true;
            lblPositionReadoutY.Font = new Font("Candara", 15.75F, FontStyle.Bold);
            lblPositionReadoutY.Location = new Point(9, 44);
            lblPositionReadoutY.Name = "lblPositionReadoutY";
            lblPositionReadoutY.Size = new Size(24, 26);
            lblPositionReadoutY.TabIndex = 7;
            lblPositionReadoutY.Text = "Y";
            // 
            // lblPositionReadoutX
            // 
            lblPositionReadoutX.AutoSize = true;
            lblPositionReadoutX.Font = new Font("Candara", 15.75F, FontStyle.Bold);
            lblPositionReadoutX.Location = new Point(9, 19);
            lblPositionReadoutX.Name = "lblPositionReadoutX";
            lblPositionReadoutX.Size = new Size(24, 26);
            lblPositionReadoutX.TabIndex = 6;
            lblPositionReadoutX.Text = "X";
            // 
            // btnZeroZ
            // 
            btnZeroZ.Font = new Font("Candara", 9F);
            btnZeroZ.Location = new Point(159, 69);
            btnZeroZ.Name = "btnZeroZ";
            btnZeroZ.Size = new Size(64, 20);
            btnZeroZ.TabIndex = 3;
            btnZeroZ.Text = "Zero Z";
            btnZeroZ.UseVisualStyleBackColor = true;
            btnZeroZ.Click += BtnZeroZ_Click;
            // 
            // btnZeroY
            // 
            btnZeroY.Font = new Font("Candara", 9F);
            btnZeroY.Location = new Point(159, 46);
            btnZeroY.Name = "btnZeroY";
            btnZeroY.Size = new Size(64, 20);
            btnZeroY.TabIndex = 2;
            btnZeroY.Text = "Zero Y";
            btnZeroY.UseVisualStyleBackColor = true;
            btnZeroY.Click += BtnZeroY_Click;
            // 
            // btnZeroX
            // 
            btnZeroX.Font = new Font("Candara", 9F);
            btnZeroX.Location = new Point(159, 21);
            btnZeroX.Name = "btnZeroX";
            btnZeroX.Size = new Size(64, 20);
            btnZeroX.TabIndex = 1;
            btnZeroX.Text = "Zero X";
            btnZeroX.UseVisualStyleBackColor = true;
            btnZeroX.Click += BtnZeroX_Click;
            // 
            // grpBoxAccessoryControl
            // 
            grpBoxAccessoryControl.Controls.Add(pnlHeatedBed);
            grpBoxAccessoryControl.Controls.Add(lblHeatedBed);
            grpBoxAccessoryControl.Controls.Add(lblExtruderTemperature);
            grpBoxAccessoryControl.Controls.Add(pnlExtruder);
            grpBoxAccessoryControl.Controls.Add(label10);
            grpBoxAccessoryControl.Controls.Add(panel5);
            grpBoxAccessoryControl.Controls.Add(panel4);
            grpBoxAccessoryControl.Controls.Add(nudHeatedBedTemperature);
            grpBoxAccessoryControl.Controls.Add(nudExtruderTemperature);
            grpBoxAccessoryControl.Controls.Add(trkBarSetFanSpeed);
            grpBoxAccessoryControl.Controls.Add(btnHeatedBedOn);
            grpBoxAccessoryControl.Controls.Add(btnExtruderOn);
            grpBoxAccessoryControl.Controls.Add(label13);
            grpBoxAccessoryControl.Controls.Add(label12);
            grpBoxAccessoryControl.Controls.Add(cmbActiveToolhead);
            grpBoxAccessoryControl.Controls.Add(label9);
            grpBoxAccessoryControl.Enabled = false;
            grpBoxAccessoryControl.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpBoxAccessoryControl.ForeColor = SystemColors.ControlText;
            grpBoxAccessoryControl.Location = new Point(449, 127);
            grpBoxAccessoryControl.Name = "grpBoxAccessoryControl";
            grpBoxAccessoryControl.Size = new Size(318, 167);
            grpBoxAccessoryControl.TabIndex = 3;
            grpBoxAccessoryControl.TabStop = false;
            grpBoxAccessoryControl.Text = "Accessory Control";
            // 
            // pnlHeatedBed
            // 
            pnlHeatedBed.BackColor = Color.DarkGray;
            pnlHeatedBed.BorderStyle = BorderStyle.FixedSingle;
            pnlHeatedBed.Cursor = Cursors.Hand;
            pnlHeatedBed.Location = new Point(10, 77);
            pnlHeatedBed.Name = "pnlHeatedBed";
            pnlHeatedBed.Size = new Size(19, 20);
            pnlHeatedBed.TabIndex = 47;
            pnlHeatedBed.Click += PnlHeatedBed_Click;
            // 
            // lblHeatedBed
            // 
            lblHeatedBed.AutoSize = true;
            lblHeatedBed.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeatedBed.ForeColor = Color.DarkGray;
            lblHeatedBed.Location = new Point(30, 80);
            lblHeatedBed.Name = "lblHeatedBed";
            lblHeatedBed.Size = new Size(82, 15);
            lblHeatedBed.TabIndex = 49;
            lblHeatedBed.Text = "Heated Bed";
            // 
            // lblExtruderTemperature
            // 
            lblExtruderTemperature.AutoSize = true;
            lblExtruderTemperature.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblExtruderTemperature.ForeColor = Color.DarkGray;
            lblExtruderTemperature.Location = new Point(30, 51);
            lblExtruderTemperature.Name = "lblExtruderTemperature";
            lblExtruderTemperature.Size = new Size(61, 15);
            lblExtruderTemperature.TabIndex = 48;
            lblExtruderTemperature.Text = "Extruder";
            // 
            // pnlExtruder
            // 
            pnlExtruder.BackColor = Color.DarkGray;
            pnlExtruder.BorderStyle = BorderStyle.FixedSingle;
            pnlExtruder.Cursor = Cursors.Hand;
            pnlExtruder.Location = new Point(10, 48);
            pnlExtruder.Name = "pnlExtruder";
            pnlExtruder.Size = new Size(19, 20);
            pnlExtruder.TabIndex = 46;
            pnlExtruder.Click += PnlExtruder_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(9, 130);
            label10.Name = "label10";
            label10.Size = new Size(78, 13);
            label10.TabIndex = 22;
            label10.Text = "Set Fan Speed";
            // 
            // panel5
            // 
            panel5.BackColor = Color.Black;
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(lblBTemperature);
            panel5.Font = new Font("Candara", 9F);
            panel5.Location = new Point(168, 77);
            panel5.Name = "panel5";
            panel5.Size = new Size(57, 20);
            panel5.TabIndex = 10;
            // 
            // lblBTemperature
            // 
            lblBTemperature.AutoSize = true;
            lblBTemperature.Dock = DockStyle.Right;
            lblBTemperature.Font = new Font("Candara", 8.25F);
            lblBTemperature.ForeColor = Color.White;
            lblBTemperature.Location = new Point(19, 0);
            lblBTemperature.Name = "lblBTemperature";
            lblBTemperature.Size = new Size(36, 13);
            lblBTemperature.TabIndex = 0;
            lblBTemperature.Text = "123.00";
            lblBTemperature.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Black;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(lblETemperature);
            panel4.Font = new Font("Candara", 9F);
            panel4.Location = new Point(168, 48);
            panel4.Name = "panel4";
            panel4.Size = new Size(57, 20);
            panel4.TabIndex = 9;
            // 
            // lblETemperature
            // 
            lblETemperature.AutoSize = true;
            lblETemperature.Dock = DockStyle.Right;
            lblETemperature.Font = new Font("Candara", 8.25F);
            lblETemperature.ForeColor = Color.White;
            lblETemperature.Location = new Point(19, 0);
            lblETemperature.Name = "lblETemperature";
            lblETemperature.Size = new Size(36, 13);
            lblETemperature.TabIndex = 0;
            lblETemperature.Text = "123.00";
            lblETemperature.TextAlign = ContentAlignment.MiddleRight;
            // 
            // nudHeatedBedTemperature
            // 
            nudHeatedBedTemperature.ForeColor = SystemColors.ControlText;
            nudHeatedBedTemperature.Location = new Point(115, 77);
            nudHeatedBedTemperature.Name = "nudHeatedBedTemperature";
            nudHeatedBedTemperature.Size = new Size(51, 20);
            nudHeatedBedTemperature.TabIndex = 16;
            // 
            // nudExtruderTemperature
            // 
            nudExtruderTemperature.ForeColor = SystemColors.ControlText;
            nudExtruderTemperature.Location = new Point(115, 48);
            nudExtruderTemperature.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            nudExtruderTemperature.Name = "nudExtruderTemperature";
            nudExtruderTemperature.Size = new Size(51, 20);
            nudExtruderTemperature.TabIndex = 8;
            // 
            // trkBarSetFanSpeed
            // 
            trkBarSetFanSpeed.Cursor = Cursors.Hand;
            trkBarSetFanSpeed.LargeChange = 15;
            trkBarSetFanSpeed.Location = new Point(88, 116);
            trkBarSetFanSpeed.Maximum = 255;
            trkBarSetFanSpeed.Name = "trkBarSetFanSpeed";
            trkBarSetFanSpeed.Size = new Size(224, 45);
            trkBarSetFanSpeed.TabIndex = 15;
            trkBarSetFanSpeed.TickFrequency = 15;
            trkBarSetFanSpeed.TickStyle = TickStyle.Both;
            trkBarSetFanSpeed.Scroll += TrkBarSetFanSpeed;
            // 
            // btnHeatedBedOn
            // 
            btnHeatedBedOn.Font = new Font("Segoe UI", 8F);
            btnHeatedBedOn.Location = new Point(245, 75);
            btnHeatedBedOn.Name = "btnHeatedBedOn";
            btnHeatedBedOn.Size = new Size(68, 20);
            btnHeatedBedOn.TabIndex = 13;
            btnHeatedBedOn.Text = "On";
            btnHeatedBedOn.UseVisualStyleBackColor = true;
            btnHeatedBedOn.Click += BtnHeatedBedOn_Click;
            // 
            // btnExtruderOn
            // 
            btnExtruderOn.Font = new Font("Segoe UI", 8F);
            btnExtruderOn.Location = new Point(245, 50);
            btnExtruderOn.Name = "btnExtruderOn";
            btnExtruderOn.Size = new Size(68, 20);
            btnExtruderOn.TabIndex = 12;
            btnExtruderOn.Text = "On";
            btnExtruderOn.UseVisualStyleBackColor = true;
            btnExtruderOn.Click += BtnExtruderOn_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.Location = new Point(226, 80);
            label13.Name = "label13";
            label13.Size = new Size(18, 13);
            label13.TabIndex = 11;
            label13.Text = "°C";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(226, 52);
            label12.Name = "label12";
            label12.Size = new Size(18, 13);
            label12.TabIndex = 10;
            label12.Text = "°C";
            // 
            // cmbActiveToolhead
            // 
            cmbActiveToolhead.FormattingEnabled = true;
            cmbActiveToolhead.Location = new Point(116, 15);
            cmbActiveToolhead.Name = "cmbActiveToolhead";
            cmbActiveToolhead.Size = new Size(196, 21);
            cmbActiveToolhead.TabIndex = 2;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 19);
            label9.Name = "label9";
            label9.Size = new Size(85, 13);
            label9.TabIndex = 1;
            label9.Text = "Active Toolhead";
            // 
            // grpBoxCustomCommands
            // 
            grpBoxCustomCommands.Controls.Add(btnSDCardStatus);
            grpBoxCustomCommands.Controls.Add(btnUploadToSDCard);
            grpBoxCustomCommands.Controls.Add(btnPauseCurrentSDPrint);
            grpBoxCustomCommands.Controls.Add(btnPrintFromSDCard);
            grpBoxCustomCommands.Controls.Add(btnEnableMotors);
            grpBoxCustomCommands.Controls.Add(btnDisableMotors);
            grpBoxCustomCommands.Enabled = false;
            grpBoxCustomCommands.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpBoxCustomCommands.ForeColor = SystemColors.ControlText;
            grpBoxCustomCommands.Location = new Point(449, 300);
            grpBoxCustomCommands.Name = "grpBoxCustomCommands";
            grpBoxCustomCommands.Size = new Size(318, 100);
            grpBoxCustomCommands.TabIndex = 4;
            grpBoxCustomCommands.TabStop = false;
            grpBoxCustomCommands.Text = "Custom Commands";
            // 
            // btnSDCardStatus
            // 
            btnSDCardStatus.Location = new Point(156, 69);
            btnSDCardStatus.Name = "btnSDCardStatus";
            btnSDCardStatus.Size = new Size(137, 20);
            btnSDCardStatus.TabIndex = 5;
            btnSDCardStatus.Text = "SD Card Status";
            btnSDCardStatus.UseVisualStyleBackColor = true;
            btnSDCardStatus.Click += BtnSDCardStatus;
            // 
            // btnUploadToSDCard
            // 
            btnUploadToSDCard.Location = new Point(10, 70);
            btnUploadToSDCard.Name = "btnUploadToSDCard";
            btnUploadToSDCard.Size = new Size(141, 20);
            btnUploadToSDCard.TabIndex = 4;
            btnUploadToSDCard.Text = "Upload to SD Card";
            btnUploadToSDCard.UseVisualStyleBackColor = true;
            btnUploadToSDCard.Click += BtnUploadToSDCard;
            // 
            // btnPauseCurrentSDPrint
            // 
            btnPauseCurrentSDPrint.Location = new Point(156, 44);
            btnPauseCurrentSDPrint.Name = "btnPauseCurrentSDPrint";
            btnPauseCurrentSDPrint.Size = new Size(137, 20);
            btnPauseCurrentSDPrint.TabIndex = 3;
            btnPauseCurrentSDPrint.Text = "Pause Current SD Print";
            btnPauseCurrentSDPrint.UseVisualStyleBackColor = true;
            btnPauseCurrentSDPrint.Click += BtnPauseCurrentSDPrint;
            // 
            // btnPrintFromSDCard
            // 
            btnPrintFromSDCard.Location = new Point(10, 44);
            btnPrintFromSDCard.Name = "btnPrintFromSDCard";
            btnPrintFromSDCard.Size = new Size(141, 20);
            btnPrintFromSDCard.TabIndex = 2;
            btnPrintFromSDCard.Text = "Print form SD Card";
            btnPrintFromSDCard.UseVisualStyleBackColor = true;
            btnPrintFromSDCard.Click += BtnPrintFromSDCard;
            // 
            // btnEnableMotors
            // 
            btnEnableMotors.Location = new Point(156, 21);
            btnEnableMotors.Name = "btnEnableMotors";
            btnEnableMotors.Size = new Size(137, 20);
            btnEnableMotors.TabIndex = 1;
            btnEnableMotors.Text = "Enable Motors";
            btnEnableMotors.UseVisualStyleBackColor = true;
            btnEnableMotors.Click += BtnEnableMotors;
            // 
            // btnDisableMotors
            // 
            btnDisableMotors.Location = new Point(9, 21);
            btnDisableMotors.Name = "btnDisableMotors";
            btnDisableMotors.Size = new Size(141, 20);
            btnDisableMotors.TabIndex = 0;
            btnDisableMotors.Text = "Disable Motors";
            btnDisableMotors.UseVisualStyleBackColor = true;
            btnDisableMotors.Click += BtnDisableMotors_Click;
            // 
            // button52
            // 
            button52.Font = new Font("Candara", 9F);
            button52.Location = new Point(602, 450);
            button52.Name = "button52";
            button52.Size = new Size(7, 7);
            button52.TabIndex = 5;
            button52.Text = "button52";
            button52.UseVisualStyleBackColor = true;
            // 
            // grpBoxOverrideSettings
            // 
            grpBoxOverrideSettings.Controls.Add(label24);
            grpBoxOverrideSettings.Controls.Add(label23);
            grpBoxOverrideSettings.Controls.Add(label22);
            grpBoxOverrideSettings.Controls.Add(label21);
            grpBoxOverrideSettings.Controls.Add(trkBarExtrusion);
            grpBoxOverrideSettings.Controls.Add(trkBarNovement);
            grpBoxOverrideSettings.Controls.Add(label20);
            grpBoxOverrideSettings.Controls.Add(lblExtrusion);
            grpBoxOverrideSettings.Controls.Add(label18);
            grpBoxOverrideSettings.Controls.Add(lblMovement);
            grpBoxOverrideSettings.Controls.Add(nubExtrusion);
            grpBoxOverrideSettings.Controls.Add(nudMovement);
            grpBoxOverrideSettings.Enabled = false;
            grpBoxOverrideSettings.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            grpBoxOverrideSettings.ForeColor = SystemColors.ControlText;
            grpBoxOverrideSettings.Location = new Point(449, 406);
            grpBoxOverrideSettings.Name = "grpBoxOverrideSettings";
            grpBoxOverrideSettings.Size = new Size(318, 125);
            grpBoxOverrideSettings.TabIndex = 6;
            grpBoxOverrideSettings.TabStop = false;
            grpBoxOverrideSettings.Text = "Override Settings";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.ForeColor = SystemColors.ControlText;
            label24.Location = new Point(270, 102);
            label24.Name = "label24";
            label24.Size = new Size(33, 13);
            label24.TabIndex = 28;
            label24.Text = "100%";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.ForeColor = SystemColors.ControlText;
            label23.Location = new Point(164, 102);
            label23.Name = "label23";
            label23.Size = new Size(21, 13);
            label23.TabIndex = 27;
            label23.Text = "1%";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.ForeColor = SystemColors.ControlText;
            label22.Location = new Point(117, 102);
            label22.Name = "label22";
            label22.Size = new Size(33, 13);
            label22.TabIndex = 26;
            label22.Text = "100%";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.ForeColor = SystemColors.ControlText;
            label21.Location = new Point(6, 102);
            label21.Name = "label21";
            label21.Size = new Size(21, 13);
            label21.TabIndex = 25;
            label21.Text = "1%";
            // 
            // trkBarExtrusion
            // 
            trkBarExtrusion.Cursor = Cursors.Hand;
            trkBarExtrusion.LargeChange = 10;
            trkBarExtrusion.Location = new Point(164, 63);
            trkBarExtrusion.Maximum = 200;
            trkBarExtrusion.Minimum = 1;
            trkBarExtrusion.Name = "trkBarExtrusion";
            trkBarExtrusion.Size = new Size(141, 45);
            trkBarExtrusion.TabIndex = 24;
            trkBarExtrusion.TickFrequency = 25;
            trkBarExtrusion.TickStyle = TickStyle.Both;
            trkBarExtrusion.Value = 100;
            trkBarExtrusion.Scroll += TrkBarExtrusion_Scroll;
            // 
            // trkBarNovement
            // 
            trkBarNovement.Cursor = Cursors.Hand;
            trkBarNovement.LargeChange = 10;
            trkBarNovement.Location = new Point(6, 63);
            trkBarNovement.Maximum = 200;
            trkBarNovement.Minimum = 1;
            trkBarNovement.Name = "trkBarNovement";
            trkBarNovement.Size = new Size(141, 45);
            trkBarNovement.TabIndex = 23;
            trkBarNovement.TickFrequency = 25;
            trkBarNovement.TickStyle = TickStyle.Both;
            trkBarNovement.Value = 100;
            trkBarNovement.Scroll += TrkBarNovement_Scroll;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.ForeColor = SystemColors.ControlText;
            label20.Location = new Point(245, 20);
            label20.Name = "label20";
            label20.Size = new Size(33, 13);
            label20.TabIndex = 22;
            label20.Text = "100%";
            // 
            // lblExtrusion
            // 
            lblExtrusion.AutoSize = true;
            lblExtrusion.ForeColor = SystemColors.ControlText;
            lblExtrusion.Location = new Point(168, 20);
            lblExtrusion.Name = "lblExtrusion";
            lblExtrusion.Size = new Size(53, 13);
            lblExtrusion.TabIndex = 21;
            lblExtrusion.Text = "Extrusion:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.ForeColor = SystemColors.ControlText;
            label18.Location = new Point(88, 20);
            label18.Name = "label18";
            label18.Size = new Size(33, 13);
            label18.TabIndex = 20;
            label18.Text = "100%";
            // 
            // lblMovement
            // 
            lblMovement.AutoSize = true;
            lblMovement.ForeColor = SystemColors.ControlText;
            lblMovement.Location = new Point(12, 20);
            lblMovement.Name = "lblMovement";
            lblMovement.Size = new Size(60, 13);
            lblMovement.TabIndex = 19;
            lblMovement.Text = "Movement:";
            // 
            // nubExtrusion
            // 
            nubExtrusion.Enabled = false;
            nubExtrusion.ForeColor = SystemColors.ControlText;
            nubExtrusion.Location = new Point(200, 39);
            nubExtrusion.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            nubExtrusion.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nubExtrusion.Name = "nubExtrusion";
            nubExtrusion.Size = new Size(51, 20);
            nubExtrusion.TabIndex = 18;
            nubExtrusion.Value = new decimal(new int[] { 100, 0, 0, 0 });
            nubExtrusion.ValueChanged += NubExtrusion_ValueChanged;
            // 
            // nudMovement
            // 
            nudMovement.ForeColor = SystemColors.ControlText;
            nudMovement.Location = new Point(17, 39);
            nudMovement.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            nudMovement.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudMovement.Name = "nudMovement";
            nudMovement.Size = new Size(51, 20);
            nudMovement.TabIndex = 17;
            nudMovement.Value = new decimal(new int[] { 100, 0, 0, 0 });
            nudMovement.ValueChanged += NudMovement_ValueChanged;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 533);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 12, 0);
            statusStrip1.Size = new Size(776, 22);
            statusStrip1.TabIndex = 7;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(79, 17);
            toolStripStatusLabel1.Text = "Disconnected";
            // 
            // grpBoxPrintTime
            // 
            grpBoxPrintTime.Controls.Add(lblPrintTimer);
            grpBoxPrintTime.Location = new Point(687, 10);
            grpBoxPrintTime.Name = "grpBoxPrintTime";
            grpBoxPrintTime.Size = new Size(86, 41);
            grpBoxPrintTime.TabIndex = 8;
            grpBoxPrintTime.TabStop = false;
            grpBoxPrintTime.Text = "Print Time";
            // 
            // lblPrintTimer
            // 
            lblPrintTimer.AutoSize = true;
            lblPrintTimer.Location = new Point(13, 22);
            lblPrintTimer.Name = "lblPrintTimer";
            lblPrintTimer.Size = new Size(16, 13);
            lblPrintTimer.TabIndex = 0;
            lblPrintTimer.Text = "...";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(776, 555);
            Controls.Add(pnlWelcome);
            Controls.Add(grpBoxPrintTime);
            Controls.Add(statusStrip1);
            Controls.Add(grpBoxOverrideSettings);
            Controls.Add(button52);
            Controls.Add(grpBoxCustomCommands);
            Controls.Add(grpBoxAccessoryControl);
            Controls.Add(grpBoxPositionReadout);
            Controls.Add(tabControl1);
            Controls.Add(grpBoxInitialization);
            Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Printer Controller";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            grpBoxInitialization.ResumeLayout(false);
            grpBoxInitialization.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvGCodeLibrary).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)temperatureChart1).EndInit();
            tabPage4.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox8.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudExtruder).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudZAxis).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudXYAxis).EndInit();
            pnlWelcome.ResumeLayout(false);
            pnlWelcome.PerformLayout();
            grpBoxPositionReadout.ResumeLayout(false);
            grpBoxPositionReadout.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            grpBoxAccessoryControl.ResumeLayout(false);
            grpBoxAccessoryControl.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudHeatedBedTemperature).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudExtruderTemperature).EndInit();
            ((System.ComponentModel.ISupportInitialize)trkBarSetFanSpeed).EndInit();
            grpBoxCustomCommands.ResumeLayout(false);
            grpBoxOverrideSettings.ResumeLayout(false);
            grpBoxOverrideSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trkBarExtrusion).EndInit();
            ((System.ComponentModel.ISupportInitialize)trkBarNovement).EndInit();
            ((System.ComponentModel.ISupportInitialize)nubExtrusion).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMovement).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            grpBoxPrintTime.ResumeLayout(false);
            grpBoxPrintTime.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpBoxInitialization;
        private Label label2;
        private Label label1;
        private ComboBox cmbBoxBaud;
        private Button btnRefresh;
        private ComboBox cmbBoxPort;
        private Button btnPause;
        private Button btnPrint;
        private Button btnConnect;
        private CheckBox chkVerbose;
        private Label label3;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private DataGridView dgvGCodeLibrary;
        private Button btnPosY10;
        private Button btnPosY100;
        private GroupBox groupBox2;
        private Button btnNegY100;
        private Button btnNegY10;
        private Button btnNegY1;
        private Button btnNegY01;
        private Button btnPosY01;
        private Button btnPosY1;
        private Button btnNegX10;
        private Button btnNegX100;
        private Button button16;
        private Button btnNegX1;
        private Button button18;
        private Button btnPosX1;
        private Button button36;
        private Button button35;
        private Button button34;
        private Button button33;
        private Button button32;
        private Button button31;
        private Button button30;
        private Button button29;
        private Button button28;
        private Button button27;
        private Button button26;
        private Button button25;
        private Button button24;
        private Button button23;
        private Button button22;
        private Button button21;
        private Button btnPosX100;
        private Button btnPosX10;
        private GroupBox groupBox3;
        private Label label5;
        private Label label4;
        private Button btnNegXPosY100;
        private Button btnPosYPosX100;
        private Button button40;
        private Button button39;
        private Button btnNegXPosY10;
        private Button btnHomrAll;
        private Button btnHomeZ;
        private Button btnHomeY;
        private Button btnHomeX;
        private GroupBox grpBoxPositionReadout;
        private Label lblPositionReadoutZ;
        private Label lblPositionReadoutY;
        private Label lblPositionReadoutX;
        private Button btnZeroZ;
        private Button btnZeroY;
        private Button btnZeroX;
        private GroupBox grpBoxAccessoryControl;
        private ComboBox cmbActiveToolhead;
        private Label label9;
        private TrackBar trkBarSetFanSpeed;
        private Button btnHeatedBedOn;
        private Button btnExtruderOn;
        private Label label13;
        private Label label12;
        private GroupBox grpBoxCustomCommands;
        private Button btnSDCardStatus;
        private Button btnUploadToSDCard;
        private Button btnPauseCurrentSDPrint;
        private Button btnPrintFromSDCard;
        private Button btnEnableMotors;
        private Button btnDisableMotors;
        private Button button52;
        private GroupBox grpBoxOverrideSettings;
        private Button btnRunSelectedGCode;
        private Button btnRemoveFromLibrary;
        private Button btnAddToLibrary;
        private Button btnSend;
        private TextBox txtBoxSend;
        private Button btnClearPlot;
        private CheckBox chkMonitorTemperatures;
        private Button button73;
        private Button button72;
        private Button button71;
        private Button button70;
        private Button button69;
        private Button button68;
        private Button button67;
        private Button button66;
        private Button button65;
        private Button button64;
        private Button button63;
        private Label label16;
        private Label label15;
        private NumericUpDown nudExtruder;
        private NumericUpDown nudZAxis;
        private NumericUpDown nudXYAxis;
        private NumericUpDown nudHeatedBedTemperature;
        private Label label20;
        private Label lblExtrusion;
        private Label label18;
        private Label lblMovement;
        private NumericUpDown nubExtrusion;
        private NumericUpDown nudMovement;
        private TrackBar trkBarExtrusion;
        private TrackBar trkBarNovement;
        private Label label24;
        private Label label23;
        private Label label22;
        private Label label21;
        private Panel panel1;
        private Label lblXPosition;
        private Panel panel3;
        private Label lblZPosition;
        private Panel panel2;
        private Label lblYPosition;
        private Label label30;
        private Label label29;
        private Label label28;
        private Label label31;
        private GroupBox groupBox8;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Button btnSendMultipleCommands;
        private Button btnClear;
        private CheckBox chkPingWithCommand;
        private ComboBox cmbGCodes;
        private CheckBox chkKeyboardControl;
        private Panel panel4;
        private Label lblETemperature;
        private Panel panel5;
        private Label lblBTemperature;
        private Button btnLookup;
        private ListView lstViewResponse;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private CheckBox chkHeatedBed;
        private CheckBox chkExtruder;
        private Label label10;
        private NumericUpDown nudExtruderTemperature;
        private Panel pnlWelcome;
        private Label lblWelcome;
        private Panel panel7;
        private Panel pnlExtruder;
        private Label lblHeatedBed;
        private Label lblExtruderTemperature;
        private Panel pnlHeatedBed;
        private Label label6;
        private GroupBox grpBoxPrintTime;
        private Label lblPrintTimer;
        private Controls.TemperatureChart temperatureChart1;
    }
}
