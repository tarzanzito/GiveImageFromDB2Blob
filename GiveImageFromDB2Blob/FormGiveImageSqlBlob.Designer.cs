namespace Common
{
    partial class FormGiveImageSqlBlob
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGiveImageSqlBlob));
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelMsg = new System.Windows.Forms.Label();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.buttonImg3Next = new System.Windows.Forms.Button();
            this.buttonImg3Previous = new System.Windows.Forms.Button();
            this.buttonImg3 = new System.Windows.Forms.Button();
            this.buttonImg2 = new System.Windows.Forms.Button();
            this.buttonImg1 = new System.Windows.Forms.Button();
            this.buttonGet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxImageID = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.textBoxConnString = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.panelFill = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelTop.SuspendLayout();
            this.panelFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panelTop.Controls.Add(this.labelMsg);
            this.panelTop.Controls.Add(this.buttonDisconnect);
            this.panelTop.Controls.Add(this.buttonImg3Next);
            this.panelTop.Controls.Add(this.buttonImg3Previous);
            this.panelTop.Controls.Add(this.buttonImg3);
            this.panelTop.Controls.Add(this.buttonImg2);
            this.panelTop.Controls.Add(this.buttonImg1);
            this.panelTop.Controls.Add(this.buttonGet);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.textBoxImageID);
            this.panelTop.Controls.Add(this.label12);
            this.panelTop.Controls.Add(this.buttonClose);
            this.panelTop.Controls.Add(this.textBoxConnString);
            this.panelTop.Controls.Add(this.buttonConnect);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(10);
            this.panelTop.Size = new System.Drawing.Size(767, 134);
            this.panelTop.TabIndex = 65;
            // 
            // labelMsg
            // 
            this.labelMsg.AutoSize = true;
            this.labelMsg.ForeColor = System.Drawing.Color.Red;
            this.labelMsg.Location = new System.Drawing.Point(13, 107);
            this.labelMsg.Name = "labelMsg";
            this.labelMsg.Size = new System.Drawing.Size(55, 13);
            this.labelMsg.TabIndex = 94;
            this.labelMsg.Text = "Messages";
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDisconnect.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonDisconnect.Location = new System.Drawing.Point(650, 43);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(105, 24);
            this.buttonDisconnect.TabIndex = 93;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // buttonImg3Next
            // 
            this.buttonImg3Next.Location = new System.Drawing.Point(549, 73);
            this.buttonImg3Next.Name = "buttonImg3Next";
            this.buttonImg3Next.Size = new System.Drawing.Size(30, 27);
            this.buttonImg3Next.TabIndex = 92;
            this.buttonImg3Next.Text = ">";
            this.buttonImg3Next.UseVisualStyleBackColor = true;
            this.buttonImg3Next.Click += new System.EventHandler(this.buttonImg3Next_Click);
            // 
            // buttonImg3Previous
            // 
            this.buttonImg3Previous.Location = new System.Drawing.Point(473, 73);
            this.buttonImg3Previous.Name = "buttonImg3Previous";
            this.buttonImg3Previous.Size = new System.Drawing.Size(30, 27);
            this.buttonImg3Previous.TabIndex = 91;
            this.buttonImg3Previous.Text = "<";
            this.buttonImg3Previous.UseVisualStyleBackColor = true;
            this.buttonImg3Previous.Click += new System.EventHandler(this.buttonImg3Previous_Click);
            // 
            // buttonImg3
            // 
            this.buttonImg3.Location = new System.Drawing.Point(509, 74);
            this.buttonImg3.Name = "buttonImg3";
            this.buttonImg3.Size = new System.Drawing.Size(30, 26);
            this.buttonImg3.TabIndex = 90;
            this.buttonImg3.Text = "3";
            this.buttonImg3.UseVisualStyleBackColor = true;
            this.buttonImg3.Click += new System.EventHandler(this.buttonImg3_Click);
            // 
            // buttonImg2
            // 
            this.buttonImg2.Location = new System.Drawing.Point(427, 76);
            this.buttonImg2.Name = "buttonImg2";
            this.buttonImg2.Size = new System.Drawing.Size(30, 25);
            this.buttonImg2.TabIndex = 89;
            this.buttonImg2.Text = "2";
            this.buttonImg2.UseVisualStyleBackColor = true;
            this.buttonImg2.Click += new System.EventHandler(this.buttonImg2_Click);
            // 
            // buttonImg1
            // 
            this.buttonImg1.Location = new System.Drawing.Point(391, 75);
            this.buttonImg1.Name = "buttonImg1";
            this.buttonImg1.Size = new System.Drawing.Size(30, 25);
            this.buttonImg1.TabIndex = 88;
            this.buttonImg1.Text = "1";
            this.buttonImg1.UseVisualStyleBackColor = true;
            this.buttonImg1.Click += new System.EventHandler(this.buttonImg1_Click);
            // 
            // buttonGet
            // 
            this.buttonGet.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonGet.Location = new System.Drawing.Point(303, 76);
            this.buttonGet.Name = "buttonGet";
            this.buttonGet.Size = new System.Drawing.Size(45, 24);
            this.buttonGet.TabIndex = 2;
            this.buttonGet.Text = "Get";
            this.buttonGet.UseVisualStyleBackColor = true;
            this.buttonGet.Click += new System.EventHandler(this.buttonGet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 72;
            this.label1.Text = "Connection String";
            // 
            // textBoxImageID
            // 
            this.textBoxImageID.Location = new System.Drawing.Point(107, 79);
            this.textBoxImageID.Name = "textBoxImageID";
            this.textBoxImageID.Size = new System.Drawing.Size(190, 20);
            this.textBoxImageID.TabIndex = 1;
            this.textBoxImageID.Text = "16180006400013";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 70;
            this.label12.Text = "Image ID:";
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonClose.Location = new System.Drawing.Point(650, 101);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(105, 24);
            this.buttonClose.TabIndex = 70;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // textBoxConnString
            // 
            this.textBoxConnString.Location = new System.Drawing.Point(107, 13);
            this.textBoxConnString.Multiline = true;
            this.textBoxConnString.Name = "textBoxConnString";
            this.textBoxConnString.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxConnString.Size = new System.Drawing.Size(472, 54);
            this.textBoxConnString.TabIndex = 51;
            this.textBoxConnString.Text = "Server=xpto.dev.com:3358;Database=myDadabase;UID=myUser;PWD=myPass;";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConnect.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonConnect.Location = new System.Drawing.Point(650, 10);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(105, 24);
            this.buttonConnect.TabIndex = 63;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // panelFill
            // 
            this.panelFill.BackColor = System.Drawing.SystemColors.Window;
            this.panelFill.Controls.Add(this.pictureBox1);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 134);
            this.panelFill.Name = "panelFill";
            this.panelFill.Padding = new System.Windows.Forms.Padding(5);
            this.panelFill.Size = new System.Drawing.Size(767, 338);
            this.panelFill.TabIndex = 79;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(757, 328);
            this.pictureBox1.TabIndex = 68;
            this.pictureBox1.TabStop = false;
            // 
            // FormGiveImageSqlBlob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 472);
            this.Controls.Add(this.panelFill);
            this.Controls.Add(this.panelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormGiveImageSqlBlob";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Give Image From DB2";
            this.Load += new System.EventHandler(this.FormGiveImageSqlBlob_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button buttonGet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxImageID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TextBox textBoxConnString;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Panel panelFill;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonImg3Next;
        private System.Windows.Forms.Button buttonImg3Previous;
        private System.Windows.Forms.Button buttonImg3;
        private System.Windows.Forms.Button buttonImg2;
        private System.Windows.Forms.Button buttonImg1;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.Label labelMsg;
    }
}