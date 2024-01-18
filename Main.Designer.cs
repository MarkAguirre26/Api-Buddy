﻿namespace Api_Buddy
{
    partial class Main
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            splitContainer1 = new SplitContainer();
            panel1 = new Panel();
            treeView = new TreeView();
            imageList1 = new ImageList(components);
            txtSearchNode = new TextBox();
            panel2 = new Panel();
            panel4 = new Panel();
            splitContainer2 = new SplitContainer();
            tabControl1 = new TabControl();
            HeaderTab = new TabPage();
            txtHeader = new RichTextBox();
            BodyTab = new TabPage();
            txtBody = new RichTextBox();
            CurlTab = new TabPage();
            txtCurl = new RichTextBox();
            txtResponse = new RichTextBox();
            panel3 = new Panel();
            cmdSend = new Button();
            txtUrl = new TextBox();
            cboMethod = new ComboBox();
            HostPanel = new FlowLayoutPanel();
            statusStrip1 = new StatusStrip();
            lblErrors = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            tabControl1.SuspendLayout();
            HeaderTab.SuspendLayout();
            BodyTab.SuspendLayout();
            CurlTab.SuspendLayout();
            panel3.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(5, 5);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel2);
            splitContainer1.Size = new Size(989, 554);
            splitContainer1.SplitterDistance = 351;
            splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.AppWorkspace;
            panel1.Controls.Add(treeView);
            panel1.Controls.Add(txtSearchNode);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(351, 554);
            panel1.TabIndex = 0;
            // 
            // treeView
            // 
            treeView.Dock = DockStyle.Fill;
            treeView.ImageIndex = 0;
            treeView.ImageList = imageList1;
            treeView.Location = new Point(0, 23);
            treeView.Name = "treeView";
            treeView.SelectedImageIndex = 0;
            treeView.ShowLines = false;
            treeView.ShowPlusMinus = false;
            treeView.Size = new Size(351, 531);
            treeView.TabIndex = 1;
            treeView.AfterCollapse += treeView_AfterCollapse;
            treeView.AfterExpand += treeView_AfterExpand;
            treeView.NodeMouseHover += treeView_NodeMouseHover;
            treeView.AfterSelect += treeView_AfterSelect;
            treeView.NodeMouseDoubleClick += treeView_NodeMouseDoubleClick;
            treeView.KeyDown += treeView_KeyDown;
            treeView.MouseLeave += treeView_MouseLeave;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "get_icon.png");
            imageList1.Images.SetKeyName(1, "post_icon.png");
            imageList1.Images.SetKeyName(2, "down_icon.png");
            imageList1.Images.SetKeyName(3, "next_icon.png");
            imageList1.Images.SetKeyName(4, "folder_icons.png");
            imageList1.Images.SetKeyName(5, "folder_open.png");
            // 
            // txtSearchNode
            // 
            txtSearchNode.Dock = DockStyle.Top;
            txtSearchNode.Location = new Point(0, 0);
            txtSearchNode.Name = "txtSearchNode";
            txtSearchNode.Size = new Size(351, 23);
            txtSearchNode.TabIndex = 0;
            txtSearchNode.TextChanged += textBox1_TextChanged;
            txtSearchNode.KeyDown += txtSearchNode_KeyDown;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Controls.Add(panel4);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(634, 554);
            panel2.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.AutoScroll = true;
            panel4.AutoSize = true;
            panel4.Controls.Add(splitContainer2);
            panel4.Controls.Add(panel3);
            panel4.Controls.Add(HostPanel);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(634, 554);
            panel4.TabIndex = 0;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 57);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(tabControl1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(txtResponse);
            splitContainer2.Size = new Size(634, 497);
            splitContainer2.SplitterDistance = 179;
            splitContainer2.TabIndex = 8;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(HeaderTab);
            tabControl1.Controls.Add(BodyTab);
            tabControl1.Controls.Add(CurlTab);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(634, 179);
            tabControl1.TabIndex = 4;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // HeaderTab
            // 
            HeaderTab.Controls.Add(txtHeader);
            HeaderTab.Location = new Point(4, 24);
            HeaderTab.Name = "HeaderTab";
            HeaderTab.Padding = new Padding(3);
            HeaderTab.Size = new Size(626, 151);
            HeaderTab.TabIndex = 0;
            HeaderTab.Text = "Header";
            HeaderTab.UseVisualStyleBackColor = true;
            // 
            // txtHeader
            // 
            txtHeader.BorderStyle = BorderStyle.None;
            txtHeader.Dock = DockStyle.Fill;
            txtHeader.Location = new Point(3, 3);
            txtHeader.Name = "txtHeader";
            txtHeader.Size = new Size(620, 145);
            txtHeader.TabIndex = 3;
            txtHeader.Text = "";
            // 
            // BodyTab
            // 
            BodyTab.Controls.Add(txtBody);
            BodyTab.Location = new Point(4, 24);
            BodyTab.Name = "BodyTab";
            BodyTab.Padding = new Padding(3);
            BodyTab.Size = new Size(626, 151);
            BodyTab.TabIndex = 1;
            BodyTab.Text = "Body";
            BodyTab.UseVisualStyleBackColor = true;
            // 
            // txtBody
            // 
            txtBody.BorderStyle = BorderStyle.None;
            txtBody.Dock = DockStyle.Fill;
            txtBody.Location = new Point(3, 3);
            txtBody.Name = "txtBody";
            txtBody.Size = new Size(620, 145);
            txtBody.TabIndex = 0;
            txtBody.Text = "";
            // 
            // CurlTab
            // 
            CurlTab.Controls.Add(txtCurl);
            CurlTab.Location = new Point(4, 24);
            CurlTab.Name = "CurlTab";
            CurlTab.Size = new Size(626, 151);
            CurlTab.TabIndex = 2;
            CurlTab.Text = "Curl";
            CurlTab.UseVisualStyleBackColor = true;
            // 
            // txtCurl
            // 
            txtCurl.BorderStyle = BorderStyle.None;
            txtCurl.Dock = DockStyle.Fill;
            txtCurl.Location = new Point(0, 0);
            txtCurl.Name = "txtCurl";
            txtCurl.Size = new Size(626, 151);
            txtCurl.TabIndex = 1;
            txtCurl.Text = "";
            // 
            // txtResponse
            // 
            txtResponse.Dock = DockStyle.Fill;
            txtResponse.Location = new Point(0, 0);
            txtResponse.Name = "txtResponse";
            txtResponse.Size = new Size(634, 314);
            txtResponse.TabIndex = 5;
            txtResponse.Text = "";
            // 
            // panel3
            // 
            panel3.Controls.Add(cmdSend);
            panel3.Controls.Add(txtUrl);
            panel3.Controls.Add(cboMethod);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 25);
            panel3.Name = "panel3";
            panel3.Size = new Size(634, 32);
            panel3.TabIndex = 1;
            // 
            // cmdSend
            // 
            cmdSend.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmdSend.Cursor = Cursors.Hand;
            cmdSend.Location = new Point(557, 4);
            cmdSend.Name = "cmdSend";
            cmdSend.Size = new Size(74, 25);
            cmdSend.TabIndex = 2;
            cmdSend.Text = "Send";
            cmdSend.UseVisualStyleBackColor = true;
            cmdSend.Click += cmdSend_Click;
            // 
            // txtUrl
            // 
            txtUrl.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtUrl.Location = new Point(86, 5);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(465, 23);
            txtUrl.TabIndex = 1;
            // 
            // cboMethod
            // 
            cboMethod.FormattingEnabled = true;
            cboMethod.Items.AddRange(new object[] { "GET", "POST" });
            cboMethod.Location = new Point(3, 5);
            cboMethod.Name = "cboMethod";
            cboMethod.Size = new Size(78, 23);
            cboMethod.TabIndex = 0;
            // 
            // HostPanel
            // 
            HostPanel.Dock = DockStyle.Top;
            HostPanel.Location = new Point(0, 0);
            HostPanel.Name = "HostPanel";
            HostPanel.Size = new Size(634, 25);
            HostPanel.TabIndex = 7;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblErrors });
            statusStrip1.Location = new Point(5, 562);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(989, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblErrors
            // 
            lblErrors.Name = "lblErrors";
            lblErrors.Size = new Size(12, 17);
            lblErrors.Text = "-";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(999, 589);
            Controls.Add(statusStrip1);
            Controls.Add(splitContainer1);
            KeyPreview = true;
            Name = "Main";
            Padding = new Padding(5);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Api Buddy";
            Load += Main_Load;
            KeyDown += Main_KeyDown;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            HeaderTab.ResumeLayout(false);
            BodyTab.ResumeLayout(false);
            CurlTab.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SplitContainer splitContainer1;
        private Panel panel1;
        private Panel panel2;
        private TreeView treeView;
        private TextBox txtSearchNode;
        private Panel panel3;
        private Button cmdSend;
        private TextBox txtUrl;
        private ComboBox cboMethod;
        private Panel panel4;
        private RichTextBox txtResponse;
        private RichTextBox txtHeader;
        private FlowLayoutPanel HostPanel;
        private SplitContainer splitContainer2;
        private ImageList imageList1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblErrors;
        private TabControl tabControl1;
        private TabPage HeaderTab;
        private TabPage BodyTab;
        private RichTextBox txtBody;
        private TabPage CurlTab;
        private RichTextBox txtCurl;
    }
}