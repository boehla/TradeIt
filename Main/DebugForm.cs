using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main {
    public partial class DebugForm : Form {
        private int maxChars = 100000;
        public DebugForm() {
            InitializeComponent();
        }

        public void logDebug(string text) {
            addTextToBox(text, Color.Black, rtbDebug);
        }
        public void logInfo(string text) {
            addTextToBox(text, Color.Green, rtbDebug);
        }
        public void logError(string text) {
            addTextToBox(text, Color.Red, rtbDebug);
        }
        public void logWarning(string text) {
            addTextToBox(text, Color.DarkOrange, rtbDebug);
        }
        public void logImportand(string text) {
            addTextToBox(text, Color.Blue, rtbDebug);
        }
        public void logTrader(string text) {
            addTextToBox(text, Color.DarkCyan, rtbDebug);
            Color c = Color.Black;
            if (text.Contains("SELL")) c = Color.Red;
            if (text.Contains("BUY")) c = Color.Green;
            addTextToBox(text, c, rtbTrader);
        }

        private void addTextToBox(string text, Color col, RichTextBox rtb) {
            if (rtb.Text.Length > maxChars) rtb.Text = "";
            int start = rtb.TextLength;

            rtb.AppendText(text);
            int end = rtb.TextLength;
            rtb.Select(start, end - start);
            rtb.SelectionColor = col;
            rtb.SelectionLength = 0;

            rtb.SelectionStart = rtb.Text.Length;
            rtb.ScrollToCaret();
        }

        private void DebugForm_FormClosing(object sender, FormClosingEventArgs e) {
            this.Hide();
            e.Cancel = true; // this cancels the close event.
        }

        private void DebugForm_Load(object sender, EventArgs e) {
        }
    }
}
