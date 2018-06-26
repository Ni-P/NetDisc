namespace NetDisc
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ListBoxResults = new System.Windows.Forms.ListBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonPing = new System.Windows.Forms.Button();
            this.labelIP4 = new System.Windows.Forms.Label();
            this.labelIP6 = new System.Windows.Forms.Label();
            this.richTextBoxIP4 = new System.Windows.Forms.RichTextBox();
            this.richTextBoxIP6 = new System.Windows.Forms.RichTextBox();
            this.richTextBoxMAC = new System.Windows.Forms.RichTextBox();
            this.labelMAC = new System.Windows.Forms.Label();
            this.richTextBoxSubnet = new System.Windows.Forms.RichTextBox();
            this.labelSubnetMask = new System.Windows.Forms.Label();
            this.richTextBoxGateway = new System.Windows.Forms.RichTextBox();
            this.labelGateway = new System.Windows.Forms.Label();
            this.labelTarget = new System.Windows.Forms.Label();
            this.textBoxTarget = new System.Windows.Forms.TextBox();
            this.backgroundPinger = new System.ComponentModel.BackgroundWorker();
            this.textBoxTargetSubnet = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSubnetIdentifier = new System.Windows.Forms.TextBox();
            this.textBoxTargetSubnetIdentifier = new System.Windows.Forms.TextBox();
            this.textBoxRangeMin = new System.Windows.Forms.TextBox();
            this.textBoxRangeMax = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTTL = new System.Windows.Forms.TextBox();
            this.labelTTL = new System.Windows.Forms.Label();
            this.labelTimeut = new System.Windows.Forms.Label();
            this.textBoxTimeout = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxIPonly = new System.Windows.Forms.CheckBox();
            this.checkBoxShowFailedPings = new System.Windows.Forms.CheckBox();
            this.textBoxBufferSize = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBoxNetworkInterface = new System.Windows.Forms.GroupBox();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.labelRepeatTimes = new System.Windows.Forms.Label();
            this.textBoxRepeats = new System.Windows.Forms.TextBox();
            this.labelRepeats = new System.Windows.Forms.Label();
            this.groupBoxPing = new System.Windows.Forms.GroupBox();
            this.textBoxIPv4_3 = new System.Windows.Forms.TextBox();
            this.textBoxIPv4_2 = new System.Windows.Forms.TextBox();
            this.textBoxIPv4_1 = new System.Windows.Forms.TextBox();
            this.textBoxIPv4_0 = new System.Windows.Forms.TextBox();
            this.labelIPv4Target = new System.Windows.Forms.Label();
            this.checkBoxRepeat = new System.Windows.Forms.CheckBox();
            this.buttonDetectInterface = new System.Windows.Forms.Button();
            this.buttonDisplayAll = new System.Windows.Forms.Button();
            this.buttonClearFailed = new System.Windows.Forms.Button();
            this.buttonClearAll = new System.Windows.Forms.Button();
            this.groupBoxSubnet = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxNetworkInterface.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
            this.groupBoxPing.SuspendLayout();
            this.groupBoxSubnet.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListBoxResults
            // 
            this.ListBoxResults.FormattingEnabled = true;
            this.ListBoxResults.Location = new System.Drawing.Point(12, 12);
            this.ListBoxResults.Name = "ListBoxResults";
            this.ListBoxResults.ScrollAlwaysVisible = true;
            this.ListBoxResults.Size = new System.Drawing.Size(364, 394);
            this.ListBoxResults.TabIndex = 0;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(272, 69);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(129, 23);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "Scan Subnet";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonPing
            // 
            this.buttonPing.Location = new System.Drawing.Point(272, 73);
            this.buttonPing.Name = "buttonPing";
            this.buttonPing.Size = new System.Drawing.Size(129, 22);
            this.buttonPing.TabIndex = 2;
            this.buttonPing.Text = "Send Ping";
            this.buttonPing.UseVisualStyleBackColor = true;
            this.buttonPing.Click += new System.EventHandler(this.buttonPing_Click);
            // 
            // labelIP4
            // 
            this.labelIP4.AutoSize = true;
            this.labelIP4.Location = new System.Drawing.Point(6, 22);
            this.labelIP4.Name = "labelIP4";
            this.labelIP4.Size = new System.Drawing.Size(54, 13);
            this.labelIP4.TabIndex = 3;
            this.labelIP4.Text = "Host IPv4";
            this.labelIP4.Click += new System.EventHandler(this.labelIP4_Click);
            // 
            // labelIP6
            // 
            this.labelIP6.AutoSize = true;
            this.labelIP6.Location = new System.Drawing.Point(6, 48);
            this.labelIP6.Name = "labelIP6";
            this.labelIP6.Size = new System.Drawing.Size(54, 13);
            this.labelIP6.TabIndex = 4;
            this.labelIP6.Text = "Host IPv6";
            // 
            // richTextBoxIP4
            // 
            this.richTextBoxIP4.Location = new System.Drawing.Point(74, 19);
            this.richTextBoxIP4.Multiline = false;
            this.richTextBoxIP4.Name = "richTextBoxIP4";
            this.richTextBoxIP4.ReadOnly = true;
            this.richTextBoxIP4.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBoxIP4.Size = new System.Drawing.Size(136, 20);
            this.richTextBoxIP4.TabIndex = 5;
            this.richTextBoxIP4.Text = "0.0.0.0";
            // 
            // richTextBoxIP6
            // 
            this.richTextBoxIP6.Location = new System.Drawing.Point(74, 45);
            this.richTextBoxIP6.Name = "richTextBoxIP6";
            this.richTextBoxIP6.ReadOnly = true;
            this.richTextBoxIP6.Size = new System.Drawing.Size(319, 20);
            this.richTextBoxIP6.TabIndex = 6;
            this.richTextBoxIP6.Text = "::0";
            // 
            // richTextBoxMAC
            // 
            this.richTextBoxMAC.Location = new System.Drawing.Point(252, 19);
            this.richTextBoxMAC.Multiline = false;
            this.richTextBoxMAC.Name = "richTextBoxMAC";
            this.richTextBoxMAC.ReadOnly = true;
            this.richTextBoxMAC.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBoxMAC.Size = new System.Drawing.Size(141, 20);
            this.richTextBoxMAC.TabIndex = 8;
            this.richTextBoxMAC.Text = "00000000";
            // 
            // labelMAC
            // 
            this.labelMAC.AutoSize = true;
            this.labelMAC.Location = new System.Drawing.Point(216, 22);
            this.labelMAC.Name = "labelMAC";
            this.labelMAC.Size = new System.Drawing.Size(30, 13);
            this.labelMAC.TabIndex = 7;
            this.labelMAC.Text = "MAC";
            // 
            // richTextBoxSubnet
            // 
            this.richTextBoxSubnet.Location = new System.Drawing.Point(74, 71);
            this.richTextBoxSubnet.Name = "richTextBoxSubnet";
            this.richTextBoxSubnet.ReadOnly = true;
            this.richTextBoxSubnet.Size = new System.Drawing.Size(278, 20);
            this.richTextBoxSubnet.TabIndex = 10;
            this.richTextBoxSubnet.Text = "255.255.255.255";
            // 
            // labelSubnetMask
            // 
            this.labelSubnetMask.AutoSize = true;
            this.labelSubnetMask.Location = new System.Drawing.Point(6, 74);
            this.labelSubnetMask.Name = "labelSubnetMask";
            this.labelSubnetMask.Size = new System.Drawing.Size(70, 13);
            this.labelSubnetMask.TabIndex = 9;
            this.labelSubnetMask.Text = "Subnet Mask";
            // 
            // richTextBoxGateway
            // 
            this.richTextBoxGateway.Location = new System.Drawing.Point(74, 97);
            this.richTextBoxGateway.Name = "richTextBoxGateway";
            this.richTextBoxGateway.ReadOnly = true;
            this.richTextBoxGateway.Size = new System.Drawing.Size(319, 20);
            this.richTextBoxGateway.TabIndex = 12;
            this.richTextBoxGateway.Text = "0.0.0.0";
            this.richTextBoxGateway.TextChanged += new System.EventHandler(this.richTextBoxGateway_TextChanged);
            // 
            // labelGateway
            // 
            this.labelGateway.AutoSize = true;
            this.labelGateway.Location = new System.Drawing.Point(6, 100);
            this.labelGateway.Name = "labelGateway";
            this.labelGateway.Size = new System.Drawing.Size(49, 13);
            this.labelGateway.TabIndex = 11;
            this.labelGateway.Text = "Gateway";
            // 
            // labelTarget
            // 
            this.labelTarget.AutoSize = true;
            this.labelTarget.Location = new System.Drawing.Point(6, 19);
            this.labelTarget.Name = "labelTarget";
            this.labelTarget.Size = new System.Drawing.Size(63, 13);
            this.labelTarget.TabIndex = 13;
            this.labelTarget.Text = "Target Host";
            // 
            // textBoxTarget
            // 
            this.textBoxTarget.Location = new System.Drawing.Point(81, 16);
            this.textBoxTarget.Name = "textBoxTarget";
            this.textBoxTarget.Size = new System.Drawing.Size(320, 20);
            this.textBoxTarget.TabIndex = 14;
            this.textBoxTarget.Text = "localhost";
            this.textBoxTarget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxTarget.TextChanged += new System.EventHandler(this.textBoxTarget_TextChanged);
            this.textBoxTarget.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxTarget_Validating);
            // 
            // backgroundPinger
            // 
            this.backgroundPinger.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundPinger_DoWork);
            this.backgroundPinger.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundPinger_RunWorkerCompleted);
            // 
            // textBoxTargetSubnet
            // 
            this.textBoxTargetSubnet.Location = new System.Drawing.Point(86, 20);
            this.textBoxTargetSubnet.Name = "textBoxTargetSubnet";
            this.textBoxTargetSubnet.Size = new System.Drawing.Size(143, 20);
            this.textBoxTargetSubnet.TabIndex = 15;
            this.textBoxTargetSubnet.Text = "192.168.1.0";
            this.textBoxTargetSubnet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Select subnet";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxSubnetIdentifier
            // 
            this.textBoxSubnetIdentifier.Location = new System.Drawing.Point(358, 71);
            this.textBoxSubnetIdentifier.Name = "textBoxSubnetIdentifier";
            this.textBoxSubnetIdentifier.ReadOnly = true;
            this.textBoxSubnetIdentifier.Size = new System.Drawing.Size(35, 20);
            this.textBoxSubnetIdentifier.TabIndex = 17;
            this.textBoxSubnetIdentifier.Text = "WIP";
            // 
            // textBoxTargetSubnetIdentifier
            // 
            this.textBoxTargetSubnetIdentifier.Location = new System.Drawing.Point(231, 20);
            this.textBoxTargetSubnetIdentifier.Name = "textBoxTargetSubnetIdentifier";
            this.textBoxTargetSubnetIdentifier.Size = new System.Drawing.Size(27, 20);
            this.textBoxTargetSubnetIdentifier.TabIndex = 18;
            this.textBoxTargetSubnetIdentifier.Text = "WIP";
            // 
            // textBoxRangeMin
            // 
            this.textBoxRangeMin.Location = new System.Drawing.Point(86, 42);
            this.textBoxRangeMin.MaxLength = 3;
            this.textBoxRangeMin.Name = "textBoxRangeMin";
            this.textBoxRangeMin.Size = new System.Drawing.Size(50, 20);
            this.textBoxRangeMin.TabIndex = 19;
            this.textBoxRangeMin.Text = "0";
            this.textBoxRangeMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxRangeMin.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxRangeMin_Validating);
            // 
            // textBoxRangeMax
            // 
            this.textBoxRangeMax.Location = new System.Drawing.Point(86, 66);
            this.textBoxRangeMax.MaxLength = 3;
            this.textBoxRangeMax.Name = "textBoxRangeMax";
            this.textBoxRangeMax.Size = new System.Drawing.Size(50, 20);
            this.textBoxRangeMax.TabIndex = 20;
            this.textBoxRangeMax.Text = "255";
            this.textBoxRangeMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxRangeMax.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxRangeMax_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Range from:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "to:";
            // 
            // textBoxTTL
            // 
            this.textBoxTTL.Location = new System.Drawing.Point(84, 14);
            this.textBoxTTL.Name = "textBoxTTL";
            this.textBoxTTL.Size = new System.Drawing.Size(50, 20);
            this.textBoxTTL.TabIndex = 23;
            this.textBoxTTL.Text = "30";
            this.textBoxTTL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxTTL.WordWrap = false;
            this.textBoxTTL.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxTTL_Validating);
            // 
            // labelTTL
            // 
            this.labelTTL.AutoSize = true;
            this.labelTTL.Location = new System.Drawing.Point(8, 18);
            this.labelTTL.Name = "labelTTL";
            this.labelTTL.Size = new System.Drawing.Size(69, 13);
            this.labelTTL.TabIndex = 24;
            this.labelTTL.Text = "Time To Live";
            // 
            // labelTimeut
            // 
            this.labelTimeut.AutoSize = true;
            this.labelTimeut.Location = new System.Drawing.Point(8, 44);
            this.labelTimeut.Name = "labelTimeut";
            this.labelTimeut.Size = new System.Drawing.Size(45, 13);
            this.labelTimeut.TabIndex = 26;
            this.labelTimeut.Text = "Timeout";
            // 
            // textBoxTimeout
            // 
            this.textBoxTimeout.Location = new System.Drawing.Point(84, 40);
            this.textBoxTimeout.Name = "textBoxTimeout";
            this.textBoxTimeout.Size = new System.Drawing.Size(50, 20);
            this.textBoxTimeout.TabIndex = 25;
            this.textBoxTimeout.Text = "4000";
            this.textBoxTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxTimeout.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxTimeout_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(140, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "hops";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(140, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "milliseconds";
            // 
            // checkBoxIPonly
            // 
            this.checkBoxIPonly.AutoSize = true;
            this.checkBoxIPonly.Location = new System.Drawing.Point(225, 44);
            this.checkBoxIPonly.Name = "checkBoxIPonly";
            this.checkBoxIPonly.Size = new System.Drawing.Size(70, 17);
            this.checkBoxIPonly.TabIndex = 29;
            this.checkBoxIPonly.Text = "Use IPv4";
            this.checkBoxIPonly.UseVisualStyleBackColor = true;
            this.checkBoxIPonly.CheckedChanged += new System.EventHandler(this.checkBoxIPonly_CheckedChanged);
            // 
            // checkBoxShowFailedPings
            // 
            this.checkBoxShowFailedPings.AutoSize = true;
            this.checkBoxShowFailedPings.Location = new System.Drawing.Point(11, 92);
            this.checkBoxShowFailedPings.Name = "checkBoxShowFailedPings";
            this.checkBoxShowFailedPings.Size = new System.Drawing.Size(116, 17);
            this.checkBoxShowFailedPings.TabIndex = 30;
            this.checkBoxShowFailedPings.Text = "Display failed pings";
            this.checkBoxShowFailedPings.UseVisualStyleBackColor = true;
            this.checkBoxShowFailedPings.CheckStateChanged += new System.EventHandler(this.checkBoxShowFailedPings_CheckStateChanged);
            // 
            // textBoxBufferSize
            // 
            this.textBoxBufferSize.Location = new System.Drawing.Point(309, 40);
            this.textBoxBufferSize.Name = "textBoxBufferSize";
            this.textBoxBufferSize.Size = new System.Drawing.Size(50, 20);
            this.textBoxBufferSize.TabIndex = 31;
            this.textBoxBufferSize.Text = "32";
            this.textBoxBufferSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxBufferSize.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxBufferSize_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(234, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Bytes to send";
            // 
            // groupBoxNetworkInterface
            // 
            this.groupBoxNetworkInterface.Controls.Add(this.richTextBoxMAC);
            this.groupBoxNetworkInterface.Controls.Add(this.labelIP4);
            this.groupBoxNetworkInterface.Controls.Add(this.richTextBoxIP4);
            this.groupBoxNetworkInterface.Controls.Add(this.labelMAC);
            this.groupBoxNetworkInterface.Controls.Add(this.richTextBoxIP6);
            this.groupBoxNetworkInterface.Controls.Add(this.labelIP6);
            this.groupBoxNetworkInterface.Controls.Add(this.richTextBoxSubnet);
            this.groupBoxNetworkInterface.Controls.Add(this.labelSubnetMask);
            this.groupBoxNetworkInterface.Controls.Add(this.textBoxSubnetIdentifier);
            this.groupBoxNetworkInterface.Controls.Add(this.richTextBoxGateway);
            this.groupBoxNetworkInterface.Controls.Add(this.labelGateway);
            this.groupBoxNetworkInterface.Location = new System.Drawing.Point(382, 12);
            this.groupBoxNetworkInterface.Name = "groupBoxNetworkInterface";
            this.groupBoxNetworkInterface.Size = new System.Drawing.Size(406, 125);
            this.groupBoxNetworkInterface.TabIndex = 33;
            this.groupBoxNetworkInterface.TabStop = false;
            this.groupBoxNetworkInterface.Text = "Network Interface";
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.labelRepeatTimes);
            this.groupBoxOptions.Controls.Add(this.textBoxRepeats);
            this.groupBoxOptions.Controls.Add(this.labelRepeats);
            this.groupBoxOptions.Controls.Add(this.labelTTL);
            this.groupBoxOptions.Controls.Add(this.textBoxTTL);
            this.groupBoxOptions.Controls.Add(this.checkBoxShowFailedPings);
            this.groupBoxOptions.Controls.Add(this.label6);
            this.groupBoxOptions.Controls.Add(this.label4);
            this.groupBoxOptions.Controls.Add(this.textBoxBufferSize);
            this.groupBoxOptions.Controls.Add(this.textBoxTimeout);
            this.groupBoxOptions.Controls.Add(this.labelTimeut);
            this.groupBoxOptions.Controls.Add(this.label5);
            this.groupBoxOptions.Location = new System.Drawing.Point(382, 143);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(406, 115);
            this.groupBoxOptions.TabIndex = 34;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Options";
            // 
            // labelRepeatTimes
            // 
            this.labelRepeatTimes.AutoSize = true;
            this.labelRepeatTimes.Location = new System.Drawing.Point(365, 18);
            this.labelRepeatTimes.Name = "labelRepeatTimes";
            this.labelRepeatTimes.Size = new System.Drawing.Size(35, 13);
            this.labelRepeatTimes.TabIndex = 35;
            this.labelRepeatTimes.Text = "Times";
            // 
            // textBoxRepeats
            // 
            this.textBoxRepeats.Location = new System.Drawing.Point(309, 14);
            this.textBoxRepeats.Name = "textBoxRepeats";
            this.textBoxRepeats.Size = new System.Drawing.Size(50, 20);
            this.textBoxRepeats.TabIndex = 34;
            this.textBoxRepeats.Text = "4";
            this.textBoxRepeats.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelRepeats
            // 
            this.labelRepeats.AutoSize = true;
            this.labelRepeats.Location = new System.Drawing.Point(261, 18);
            this.labelRepeats.Name = "labelRepeats";
            this.labelRepeats.Size = new System.Drawing.Size(42, 13);
            this.labelRepeats.TabIndex = 33;
            this.labelRepeats.Text = "Repeat";
            // 
            // groupBoxPing
            // 
            this.groupBoxPing.Controls.Add(this.textBoxIPv4_3);
            this.groupBoxPing.Controls.Add(this.textBoxIPv4_2);
            this.groupBoxPing.Controls.Add(this.textBoxIPv4_1);
            this.groupBoxPing.Controls.Add(this.textBoxIPv4_0);
            this.groupBoxPing.Controls.Add(this.labelIPv4Target);
            this.groupBoxPing.Controls.Add(this.checkBoxRepeat);
            this.groupBoxPing.Controls.Add(this.buttonPing);
            this.groupBoxPing.Controls.Add(this.labelTarget);
            this.groupBoxPing.Controls.Add(this.textBoxTarget);
            this.groupBoxPing.Controls.Add(this.checkBoxIPonly);
            this.groupBoxPing.Location = new System.Drawing.Point(382, 264);
            this.groupBoxPing.Name = "groupBoxPing";
            this.groupBoxPing.Size = new System.Drawing.Size(407, 101);
            this.groupBoxPing.TabIndex = 35;
            this.groupBoxPing.TabStop = false;
            this.groupBoxPing.Text = "Ping";
            // 
            // textBoxIPv4_3
            // 
            this.textBoxIPv4_3.Location = new System.Drawing.Point(189, 42);
            this.textBoxIPv4_3.Name = "textBoxIPv4_3";
            this.textBoxIPv4_3.Size = new System.Drawing.Size(30, 20);
            this.textBoxIPv4_3.TabIndex = 35;
            this.textBoxIPv4_3.Text = "0";
            // 
            // textBoxIPv4_2
            // 
            this.textBoxIPv4_2.Location = new System.Drawing.Point(153, 42);
            this.textBoxIPv4_2.Name = "textBoxIPv4_2";
            this.textBoxIPv4_2.Size = new System.Drawing.Size(30, 20);
            this.textBoxIPv4_2.TabIndex = 34;
            this.textBoxIPv4_2.Text = "0";
            // 
            // textBoxIPv4_1
            // 
            this.textBoxIPv4_1.Location = new System.Drawing.Point(117, 42);
            this.textBoxIPv4_1.Name = "textBoxIPv4_1";
            this.textBoxIPv4_1.Size = new System.Drawing.Size(30, 20);
            this.textBoxIPv4_1.TabIndex = 33;
            this.textBoxIPv4_1.Text = "0";
            // 
            // textBoxIPv4_0
            // 
            this.textBoxIPv4_0.Location = new System.Drawing.Point(81, 42);
            this.textBoxIPv4_0.Name = "textBoxIPv4_0";
            this.textBoxIPv4_0.Size = new System.Drawing.Size(30, 20);
            this.textBoxIPv4_0.TabIndex = 32;
            this.textBoxIPv4_0.Text = "0";
            // 
            // labelIPv4Target
            // 
            this.labelIPv4Target.AutoSize = true;
            this.labelIPv4Target.Location = new System.Drawing.Point(6, 45);
            this.labelIPv4Target.Name = "labelIPv4Target";
            this.labelIPv4Target.Size = new System.Drawing.Size(70, 13);
            this.labelIPv4Target.TabIndex = 31;
            this.labelIPv4Target.Text = "IPv4 Address";
            // 
            // checkBoxRepeat
            // 
            this.checkBoxRepeat.AutoSize = true;
            this.checkBoxRepeat.Location = new System.Drawing.Point(340, 45);
            this.checkBoxRepeat.Name = "checkBoxRepeat";
            this.checkBoxRepeat.Size = new System.Drawing.Size(61, 17);
            this.checkBoxRepeat.TabIndex = 30;
            this.checkBoxRepeat.Text = "Repeat";
            this.checkBoxRepeat.UseVisualStyleBackColor = true;
            // 
            // buttonDetectInterface
            // 
            this.buttonDetectInterface.Location = new System.Drawing.Point(227, 4);
            this.buttonDetectInterface.Name = "buttonDetectInterface";
            this.buttonDetectInterface.Size = new System.Drawing.Size(134, 23);
            this.buttonDetectInterface.TabIndex = 36;
            this.buttonDetectInterface.Text = "Detect Interface";
            this.buttonDetectInterface.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDetectInterface.UseVisualStyleBackColor = true;
            this.buttonDetectInterface.Click += new System.EventHandler(this.buttonDetectInterface_Click);
            // 
            // buttonDisplayAll
            // 
            this.buttonDisplayAll.Location = new System.Drawing.Point(226, 32);
            this.buttonDisplayAll.Name = "buttonDisplayAll";
            this.buttonDisplayAll.Size = new System.Drawing.Size(135, 23);
            this.buttonDisplayAll.TabIndex = 37;
            this.buttonDisplayAll.Text = "Display all Interfaces";
            this.buttonDisplayAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDisplayAll.UseVisualStyleBackColor = true;
            this.buttonDisplayAll.Click += new System.EventHandler(this.buttonDisplayAll_Click);
            // 
            // buttonClearFailed
            // 
            this.buttonClearFailed.Enabled = false;
            this.buttonClearFailed.Location = new System.Drawing.Point(3, 4);
            this.buttonClearFailed.Name = "buttonClearFailed";
            this.buttonClearFailed.Size = new System.Drawing.Size(134, 23);
            this.buttonClearFailed.TabIndex = 38;
            this.buttonClearFailed.Text = "Clear failed pings";
            this.buttonClearFailed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonClearFailed.UseVisualStyleBackColor = true;
            this.buttonClearFailed.Click += new System.EventHandler(this.buttonClearFailed_Click);
            // 
            // buttonClearAll
            // 
            this.buttonClearAll.Location = new System.Drawing.Point(3, 32);
            this.buttonClearAll.Name = "buttonClearAll";
            this.buttonClearAll.Size = new System.Drawing.Size(134, 23);
            this.buttonClearAll.TabIndex = 39;
            this.buttonClearAll.Text = "Clear all results";
            this.buttonClearAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonClearAll.UseVisualStyleBackColor = true;
            this.buttonClearAll.Click += new System.EventHandler(this.buttonClearAll_Click);
            // 
            // groupBoxSubnet
            // 
            this.groupBoxSubnet.Controls.Add(this.buttonSearch);
            this.groupBoxSubnet.Controls.Add(this.label1);
            this.groupBoxSubnet.Controls.Add(this.textBoxTargetSubnetIdentifier);
            this.groupBoxSubnet.Controls.Add(this.label3);
            this.groupBoxSubnet.Controls.Add(this.textBoxTargetSubnet);
            this.groupBoxSubnet.Controls.Add(this.textBoxRangeMin);
            this.groupBoxSubnet.Controls.Add(this.label2);
            this.groupBoxSubnet.Controls.Add(this.textBoxRangeMax);
            this.groupBoxSubnet.Location = new System.Drawing.Point(382, 371);
            this.groupBoxSubnet.Name = "groupBoxSubnet";
            this.groupBoxSubnet.Size = new System.Drawing.Size(407, 100);
            this.groupBoxSubnet.TabIndex = 40;
            this.groupBoxSubnet.TabStop = false;
            this.groupBoxSubnet.Text = "Subnet Scanner";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonDetectInterface);
            this.panel1.Controls.Add(this.buttonDisplayAll);
            this.panel1.Controls.Add(this.buttonClearAll);
            this.panel1.Controls.Add(this.buttonClearFailed);
            this.panel1.Location = new System.Drawing.Point(12, 413);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 58);
            this.panel1.TabIndex = 41;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(799, 480);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBoxSubnet);
            this.Controls.Add(this.groupBoxPing);
            this.Controls.Add(this.groupBoxOptions);
            this.Controls.Add(this.groupBoxNetworkInterface);
            this.Controls.Add(this.ListBoxResults);
            this.Name = "MainForm";
            this.Text = "NetDisc";
            this.groupBoxNetworkInterface.ResumeLayout(false);
            this.groupBoxNetworkInterface.PerformLayout();
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            this.groupBoxPing.ResumeLayout(false);
            this.groupBoxPing.PerformLayout();
            this.groupBoxSubnet.ResumeLayout(false);
            this.groupBoxSubnet.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListBoxResults;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonPing;
        private System.Windows.Forms.Label labelIP4;
        private System.Windows.Forms.Label labelIP6;
        private System.Windows.Forms.RichTextBox richTextBoxIP4;
        private System.Windows.Forms.RichTextBox richTextBoxIP6;
        private System.Windows.Forms.RichTextBox richTextBoxMAC;
        private System.Windows.Forms.Label labelMAC;
        private System.Windows.Forms.RichTextBox richTextBoxSubnet;
        private System.Windows.Forms.Label labelSubnetMask;
        private System.Windows.Forms.RichTextBox richTextBoxGateway;
        private System.Windows.Forms.Label labelGateway;
        private System.Windows.Forms.Label labelTarget;
        private System.Windows.Forms.TextBox textBoxTarget;
        private System.ComponentModel.BackgroundWorker backgroundPinger;
        private System.Windows.Forms.TextBox textBoxTargetSubnet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSubnetIdentifier;
        private System.Windows.Forms.TextBox textBoxTargetSubnetIdentifier;
        private System.Windows.Forms.TextBox textBoxRangeMin;
        private System.Windows.Forms.TextBox textBoxRangeMax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTTL;
        private System.Windows.Forms.Label labelTTL;
        private System.Windows.Forms.Label labelTimeut;
        private System.Windows.Forms.TextBox textBoxTimeout;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxIPonly;
        private System.Windows.Forms.CheckBox checkBoxShowFailedPings;
        private System.Windows.Forms.TextBox textBoxBufferSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBoxNetworkInterface;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.GroupBox groupBoxPing;
        private System.Windows.Forms.CheckBox checkBoxRepeat;
        private System.Windows.Forms.Button buttonDetectInterface;
        private System.Windows.Forms.Button buttonDisplayAll;
        private System.Windows.Forms.TextBox textBoxRepeats;
        private System.Windows.Forms.Label labelRepeats;
        private System.Windows.Forms.Label labelRepeatTimes;
        private System.Windows.Forms.Button buttonClearFailed;
        private System.Windows.Forms.Button buttonClearAll;
        private System.Windows.Forms.GroupBox groupBoxSubnet;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxIPv4_3;
        private System.Windows.Forms.TextBox textBoxIPv4_2;
        private System.Windows.Forms.TextBox textBoxIPv4_1;
        private System.Windows.Forms.TextBox textBoxIPv4_0;
        private System.Windows.Forms.Label labelIPv4Target;
    }
}

