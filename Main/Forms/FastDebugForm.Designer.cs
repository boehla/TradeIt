namespace TradeIt.Forms {
    partial class FastDebugForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.btGotToEnd = new System.Windows.Forms.Button();
            this.fctb = new FastColoredTextBoxNS.FastColoredTextBox();
            this.bClear = new System.Windows.Forms.Button();
            this.tRefresh = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fctb)).BeginInit();
            this.SuspendLayout();
            // 
            // btGotToEnd
            // 
            this.btGotToEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btGotToEnd.Location = new System.Drawing.Point(0, 403);
            this.btGotToEnd.Name = "btGotToEnd";
            this.btGotToEnd.Size = new System.Drawing.Size(401, 25);
            this.btGotToEnd.TabIndex = 6;
            this.btGotToEnd.Text = "Go to end";
            this.btGotToEnd.UseVisualStyleBackColor = true;
            this.btGotToEnd.Click += new System.EventHandler(this.btGotToEnd_Click);
            // 
            // fctb
            // 
            this.fctb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fctb.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fctb.AutoScrollMinSize = new System.Drawing.Size(25, 12);
            this.fctb.BackBrush = null;
            this.fctb.CharHeight = 12;
            this.fctb.CharWidth = 7;
            this.fctb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctb.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctb.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.fctb.IsReplaceMode = false;
            this.fctb.Location = new System.Drawing.Point(0, 0);
            this.fctb.Name = "fctb";
            this.fctb.Paddings = new System.Windows.Forms.Padding(0);
            this.fctb.ReadOnly = true;
            this.fctb.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctb.Size = new System.Drawing.Size(483, 404);
            this.fctb.TabIndex = 5;
            this.fctb.Zoom = 100;
            this.fctb.Scroll += new System.Windows.Forms.ScrollEventHandler(this.fctb_Scroll);
            // 
            // bClear
            // 
            this.bClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bClear.Location = new System.Drawing.Point(398, 403);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(85, 25);
            this.bClear.TabIndex = 6;
            this.bClear.Text = "Clear";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // tRefresh
            // 
            this.tRefresh.Enabled = true;
            this.tRefresh.Tick += new System.EventHandler(this.tRefresh_Tick);
            // 
            // FastDebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 427);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.btGotToEnd);
            this.Controls.Add(this.fctb);
            this.Name = "FastDebugForm";
            this.Text = "LoggerSample";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FastDebugForm_FormClosing);
            this.Load += new System.EventHandler(this.FastDebugForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fctb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox fctb;
        private System.Windows.Forms.Button btGotToEnd;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Timer tRefresh;
    }
}