namespace Skype_Customizer
{
	partial class Main
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.mainPanel = new System.Windows.Forms.TabControl();
			this.statusTab = new System.Windows.Forms.TabPage();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.statusExampleLbl = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.statusFormat = new System.Windows.Forms.TextBox();
			this.showSpotify = new System.Windows.Forms.CheckBox();
			this.adsTab = new System.Windows.Forms.TabPage();
			this.disableAds = new System.Windows.Forms.CheckBox();
			this.aboutTab = new System.Windows.Forms.TabPage();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.aboutText = new System.Windows.Forms.TextBox();
			this.productNameLbl = new System.Windows.Forms.Label();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.saveBtn = new System.Windows.Forms.Button();
			this.refresh = new System.Windows.Forms.Timer(this.components);
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadingPanel = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.mainPanel.SuspendLayout();
			this.statusTab.SuspendLayout();
			this.adsTab.SuspendLayout();
			this.aboutTab.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.loadingPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.Controls.Add(this.statusTab);
			this.mainPanel.Controls.Add(this.adsTab);
			this.mainPanel.Controls.Add(this.aboutTab);
			this.mainPanel.Location = new System.Drawing.Point(6, 5);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.SelectedIndex = 0;
			this.mainPanel.Size = new System.Drawing.Size(372, 233);
			this.mainPanel.TabIndex = 1;
			// 
			// statusTab
			// 
			this.statusTab.Controls.Add(this.label6);
			this.statusTab.Controls.Add(this.label5);
			this.statusTab.Controls.Add(this.label3);
			this.statusTab.Controls.Add(this.label2);
			this.statusTab.Controls.Add(this.statusExampleLbl);
			this.statusTab.Controls.Add(this.label1);
			this.statusTab.Controls.Add(this.statusFormat);
			this.statusTab.Controls.Add(this.showSpotify);
			this.statusTab.Location = new System.Drawing.Point(4, 22);
			this.statusTab.Name = "statusTab";
			this.statusTab.Padding = new System.Windows.Forms.Padding(3);
			this.statusTab.Size = new System.Drawing.Size(364, 207);
			this.statusTab.TabIndex = 0;
			this.statusTab.Text = "Status";
			this.statusTab.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(12, 115);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(96, 13);
			this.label6.TabIndex = 11;
			this.label6.Text = "Status example";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(234, 133);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(82, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "{song}      Song";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(233, 151);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(121, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "{status}    Skype status";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(234, 115);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(91, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "{author}   Author";
			// 
			// statusExampleLbl
			// 
			this.statusExampleLbl.Location = new System.Drawing.Point(13, 134);
			this.statusExampleLbl.Name = "statusExampleLbl";
			this.statusExampleLbl.Size = new System.Drawing.Size(213, 49);
			this.statusExampleLbl.TabIndex = 6;
			this.statusExampleLbl.Text = "Loading...";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 53);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(160, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Song playing status format";
			// 
			// statusFormat
			// 
			this.statusFormat.Location = new System.Drawing.Point(15, 75);
			this.statusFormat.Name = "statusFormat";
			this.statusFormat.Size = new System.Drawing.Size(339, 21);
			this.statusFormat.TabIndex = 4;
			this.statusFormat.Text = "{status} - {song}";
			// 
			// showSpotify
			// 
			this.showSpotify.AutoSize = true;
			this.showSpotify.Location = new System.Drawing.Point(15, 22);
			this.showSpotify.Name = "showSpotify";
			this.showSpotify.Size = new System.Drawing.Size(197, 17);
			this.showSpotify.TabIndex = 3;
			this.showSpotify.Text = "Show song information from Spotify";
			this.showSpotify.UseVisualStyleBackColor = true;
			// 
			// adsTab
			// 
			this.adsTab.Controls.Add(this.disableAds);
			this.adsTab.Location = new System.Drawing.Point(4, 22);
			this.adsTab.Name = "adsTab";
			this.adsTab.Padding = new System.Windows.Forms.Padding(3);
			this.adsTab.Size = new System.Drawing.Size(364, 207);
			this.adsTab.TabIndex = 1;
			this.adsTab.Text = "Ads";
			this.adsTab.UseVisualStyleBackColor = true;
			// 
			// disableAds
			// 
			this.disableAds.AutoSize = true;
			this.disableAds.Location = new System.Drawing.Point(15, 22);
			this.disableAds.Name = "disableAds";
			this.disableAds.Size = new System.Drawing.Size(80, 17);
			this.disableAds.TabIndex = 0;
			this.disableAds.Text = "Disable ads";
			this.disableAds.UseVisualStyleBackColor = true;
			// 
			// aboutTab
			// 
			this.aboutTab.Controls.Add(this.pictureBox1);
			this.aboutTab.Controls.Add(this.aboutText);
			this.aboutTab.Controls.Add(this.productNameLbl);
			this.aboutTab.Controls.Add(this.pictureBox2);
			this.aboutTab.Location = new System.Drawing.Point(4, 22);
			this.aboutTab.Name = "aboutTab";
			this.aboutTab.Size = new System.Drawing.Size(364, 207);
			this.aboutTab.TabIndex = 2;
			this.aboutTab.Text = "About";
			this.aboutTab.UseVisualStyleBackColor = true;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::SkypeCustomizer.Properties.Resources.dickbutt;
			this.pictureBox1.Location = new System.Drawing.Point(240, 5);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(113, 174);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// aboutText
			// 
			this.aboutText.BackColor = System.Drawing.Color.White;
			this.aboutText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.aboutText.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.aboutText.Location = new System.Drawing.Point(66, 40);
			this.aboutText.Multiline = true;
			this.aboutText.Name = "aboutText";
			this.aboutText.ReadOnly = true;
			this.aboutText.Size = new System.Drawing.Size(168, 151);
			this.aboutText.TabIndex = 3;
			this.aboutText.Text = "Developed by Simon Sessingø";
			// 
			// productNameLbl
			// 
			this.productNameLbl.AutoSize = true;
			this.productNameLbl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.productNameLbl.Location = new System.Drawing.Point(65, 19);
			this.productNameLbl.Name = "productNameLbl";
			this.productNameLbl.Size = new System.Drawing.Size(109, 13);
			this.productNameLbl.TabIndex = 2;
			this.productNameLbl.Text = "Skype Customizer";
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = global::SkypeCustomizer.Properties.Resources.icon_png;
			this.pictureBox2.Location = new System.Drawing.Point(8, 19);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(51, 37);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 1;
			this.pictureBox2.TabStop = false;
			// 
			// saveBtn
			// 
			this.saveBtn.Location = new System.Drawing.Point(302, 243);
			this.saveBtn.Name = "saveBtn";
			this.saveBtn.Size = new System.Drawing.Size(75, 23);
			this.saveBtn.TabIndex = 2;
			this.saveBtn.Text = "Save";
			this.saveBtn.UseVisualStyleBackColor = true;
			this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
			// 
			// refresh
			// 
			this.refresh.Interval = 1000;
			this.refresh.Tick += new System.EventHandler(this.refresh_Tick);
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "Skype Customizer";
			this.notifyIcon1.Visible = true;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(104, 48);
			// 
			// showToolStripMenuItem
			// 
			this.showToolStripMenuItem.Name = "showToolStripMenuItem";
			this.showToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.showToolStripMenuItem.Text = "Show";
			this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// loadingPanel
			// 
			this.loadingPanel.Controls.Add(this.label4);
			this.loadingPanel.Location = new System.Drawing.Point(6, 5);
			this.loadingPanel.Name = "loadingPanel";
			this.loadingPanel.Size = new System.Drawing.Size(372, 261);
			this.loadingPanel.TabIndex = 3;
			this.loadingPanel.Visible = false;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(0, 112);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(371, 23);
			this.label4.TabIndex = 0;
			this.label4.Text = "Connecting to Skype...";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(384, 273);
			this.Controls.Add(this.saveBtn);
			this.Controls.Add(this.mainPanel);
			this.Controls.Add(this.loadingPanel);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Skype Customizer";
			this.Load += new System.EventHandler(this.Main_Load);
			this.mainPanel.ResumeLayout(false);
			this.statusTab.ResumeLayout(false);
			this.statusTab.PerformLayout();
			this.adsTab.ResumeLayout(false);
			this.adsTab.PerformLayout();
			this.aboutTab.ResumeLayout(false);
			this.aboutTab.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.loadingPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl mainPanel;
		private System.Windows.Forms.TabPage statusTab;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox statusFormat;
		private System.Windows.Forms.CheckBox showSpotify;
		private System.Windows.Forms.TabPage adsTab;
		private System.Windows.Forms.CheckBox disableAds;
		private System.Windows.Forms.Button saveBtn;
		private System.Windows.Forms.Timer refresh;
		private System.Windows.Forms.Label statusExampleLbl;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.TabPage aboutTab;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TextBox aboutText;
		private System.Windows.Forms.Label productNameLbl;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.Panel loadingPanel;
		private System.Windows.Forms.Label label4;

	}
}

