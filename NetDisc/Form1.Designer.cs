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
            this.SuspendLayout();
            // 
            // ListBoxResults
            // 
            this.ListBoxResults.FormattingEnabled = true;
            this.ListBoxResults.Location = new System.Drawing.Point(12, 12);
            this.ListBoxResults.Name = "ListBoxResults";
            this.ListBoxResults.Size = new System.Drawing.Size(364, 329);
            this.ListBoxResults.TabIndex = 0;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(647, 159);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(141, 23);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonPing
            // 
            this.buttonPing.Location = new System.Drawing.Point(647, 130);
            this.buttonPing.Name = "buttonPing";
            this.buttonPing.Size = new System.Drawing.Size(141, 23);
            this.buttonPing.TabIndex = 2;
            this.buttonPing.Text = "Ping";
            this.buttonPing.UseVisualStyleBackColor = true;
            this.buttonPing.Click += new System.EventHandler(this.buttonPing_Click);
            // 
            // labelIP4
            // 
            this.labelIP4.AutoSize = true;
            this.labelIP4.Location = new System.Drawing.Point(393, 13);
            this.labelIP4.Name = "labelIP4";
            this.labelIP4.Size = new System.Drawing.Size(54, 13);
            this.labelIP4.TabIndex = 3;
            this.labelIP4.Text = "Host IPv4";
            // 
            // labelIP6
            // 
            this.labelIP6.AutoSize = true;
            this.labelIP6.Location = new System.Drawing.Point(393, 40);
            this.labelIP6.Name = "labelIP6";
            this.labelIP6.Size = new System.Drawing.Size(54, 13);
            this.labelIP6.TabIndex = 4;
            this.labelIP6.Text = "Host IPv6";
            // 
            // richTextBoxIP4
            // 
            this.richTextBoxIP4.Location = new System.Drawing.Point(469, 14);
            this.richTextBoxIP4.Multiline = false;
            this.richTextBoxIP4.Name = "richTextBoxIP4";
            this.richTextBoxIP4.ReadOnly = true;
            this.richTextBoxIP4.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBoxIP4.Size = new System.Drawing.Size(136, 20);
            this.richTextBoxIP4.TabIndex = 5;
            this.richTextBoxIP4.Text = "Tbox 1 test text";
            // 
            // richTextBoxIP6
            // 
            this.richTextBoxIP6.Location = new System.Drawing.Point(469, 37);
            this.richTextBoxIP6.Name = "richTextBoxIP6";
            this.richTextBoxIP6.ReadOnly = true;
            this.richTextBoxIP6.Size = new System.Drawing.Size(319, 20);
            this.richTextBoxIP6.TabIndex = 6;
            this.richTextBoxIP6.Text = "Tbox 2 test text";
            // 
            // richTextBoxMAC
            // 
            this.richTextBoxMAC.Location = new System.Drawing.Point(647, 14);
            this.richTextBoxMAC.Multiline = false;
            this.richTextBoxMAC.Name = "richTextBoxMAC";
            this.richTextBoxMAC.ReadOnly = true;
            this.richTextBoxMAC.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBoxMAC.Size = new System.Drawing.Size(141, 20);
            this.richTextBoxMAC.TabIndex = 8;
            this.richTextBoxMAC.Text = "Tbox 1 test text";
            // 
            // labelMAC
            // 
            this.labelMAC.AutoSize = true;
            this.labelMAC.Location = new System.Drawing.Point(611, 14);
            this.labelMAC.Name = "labelMAC";
            this.labelMAC.Size = new System.Drawing.Size(30, 13);
            this.labelMAC.TabIndex = 7;
            this.labelMAC.Text = "MAC";
            // 
            // richTextBoxSubnet
            // 
            this.richTextBoxSubnet.Location = new System.Drawing.Point(469, 63);
            this.richTextBoxSubnet.Name = "richTextBoxSubnet";
            this.richTextBoxSubnet.ReadOnly = true;
            this.richTextBoxSubnet.Size = new System.Drawing.Size(278, 20);
            this.richTextBoxSubnet.TabIndex = 10;
            this.richTextBoxSubnet.Text = "Tbox 2 test text";
            // 
            // labelSubnetMask
            // 
            this.labelSubnetMask.AutoSize = true;
            this.labelSubnetMask.Location = new System.Drawing.Point(393, 66);
            this.labelSubnetMask.Name = "labelSubnetMask";
            this.labelSubnetMask.Size = new System.Drawing.Size(70, 13);
            this.labelSubnetMask.TabIndex = 9;
            this.labelSubnetMask.Text = "Subnet Mask";
            // 
            // richTextBoxGateway
            // 
            this.richTextBoxGateway.Location = new System.Drawing.Point(469, 89);
            this.richTextBoxGateway.Name = "richTextBoxGateway";
            this.richTextBoxGateway.ReadOnly = true;
            this.richTextBoxGateway.Size = new System.Drawing.Size(319, 20);
            this.richTextBoxGateway.TabIndex = 12;
            this.richTextBoxGateway.Text = "Tbox 2 test text";
            this.richTextBoxGateway.TextChanged += new System.EventHandler(this.richTextBoxGateway_TextChanged);
            // 
            // labelGateway
            // 
            this.labelGateway.AutoSize = true;
            this.labelGateway.Location = new System.Drawing.Point(393, 92);
            this.labelGateway.Name = "labelGateway";
            this.labelGateway.Size = new System.Drawing.Size(49, 13);
            this.labelGateway.TabIndex = 11;
            this.labelGateway.Text = "Gateway";
            // 
            // labelTarget
            // 
            this.labelTarget.AutoSize = true;
            this.labelTarget.Location = new System.Drawing.Point(398, 135);
            this.labelTarget.Name = "labelTarget";
            this.labelTarget.Size = new System.Drawing.Size(38, 13);
            this.labelTarget.TabIndex = 13;
            this.labelTarget.Text = "Target";
            // 
            // textBoxTarget
            // 
            this.textBoxTarget.Location = new System.Drawing.Point(469, 132);
            this.textBoxTarget.Name = "textBoxTarget";
            this.textBoxTarget.Size = new System.Drawing.Size(143, 20);
            this.textBoxTarget.TabIndex = 14;
            this.textBoxTarget.Text = "localhost";
            this.textBoxTarget.TextChanged += new System.EventHandler(this.textBoxTarget_TextChanged);
            // 
            // backgroundPinger
            // 
            this.backgroundPinger.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundPinger_DoWork);
            this.backgroundPinger.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundPinger_RunWorkerCompleted);
            // 
            // textBoxTargetSubnet
            // 
            this.textBoxTargetSubnet.Location = new System.Drawing.Point(469, 160);
            this.textBoxTargetSubnet.Name = "textBoxTargetSubnet";
            this.textBoxTargetSubnet.Size = new System.Drawing.Size(143, 20);
            this.textBoxTargetSubnet.TabIndex = 15;
            this.textBoxTargetSubnet.Text = "192.168.1.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(391, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Select subnet";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxSubnetIdentifier
            // 
            this.textBoxSubnetIdentifier.Location = new System.Drawing.Point(753, 63);
            this.textBoxSubnetIdentifier.Name = "textBoxSubnetIdentifier";
            this.textBoxSubnetIdentifier.ReadOnly = true;
            this.textBoxSubnetIdentifier.Size = new System.Drawing.Size(35, 20);
            this.textBoxSubnetIdentifier.TabIndex = 17;
            this.textBoxSubnetIdentifier.Text = "WIP";
            // 
            // textBoxTargetSubnetIdentifier
            // 
            this.textBoxTargetSubnetIdentifier.Location = new System.Drawing.Point(614, 160);
            this.textBoxTargetSubnetIdentifier.Name = "textBoxTargetSubnetIdentifier";
            this.textBoxTargetSubnetIdentifier.Size = new System.Drawing.Size(27, 20);
            this.textBoxTargetSubnetIdentifier.TabIndex = 18;
            this.textBoxTargetSubnetIdentifier.Text = "WIP";
            // 
            // textBoxRangeMin
            // 
            this.textBoxRangeMin.Location = new System.Drawing.Point(469, 185);
            this.textBoxRangeMin.Name = "textBoxRangeMin";
            this.textBoxRangeMin.Size = new System.Drawing.Size(49, 20);
            this.textBoxRangeMin.TabIndex = 19;
            this.textBoxRangeMin.Text = "0";
            // 
            // textBoxRangeMax
            // 
            this.textBoxRangeMax.Location = new System.Drawing.Point(563, 185);
            this.textBoxRangeMax.Name = "textBoxRangeMax";
            this.textBoxRangeMax.Size = new System.Drawing.Size(49, 20);
            this.textBoxRangeMax.TabIndex = 20;
            this.textBoxRangeMax.Text = "255";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(393, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Range    from:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(538, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "to:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 410);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxRangeMax);
            this.Controls.Add(this.textBoxRangeMin);
            this.Controls.Add(this.textBoxTargetSubnetIdentifier);
            this.Controls.Add(this.textBoxSubnetIdentifier);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTargetSubnet);
            this.Controls.Add(this.textBoxTarget);
            this.Controls.Add(this.labelTarget);
            this.Controls.Add(this.richTextBoxGateway);
            this.Controls.Add(this.labelGateway);
            this.Controls.Add(this.richTextBoxSubnet);
            this.Controls.Add(this.labelSubnetMask);
            this.Controls.Add(this.richTextBoxMAC);
            this.Controls.Add(this.labelMAC);
            this.Controls.Add(this.richTextBoxIP6);
            this.Controls.Add(this.richTextBoxIP4);
            this.Controls.Add(this.labelIP6);
            this.Controls.Add(this.labelIP4);
            this.Controls.Add(this.buttonPing);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.ListBoxResults);
            this.Name = "MainForm";
            this.Text = "NetDisc";
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

