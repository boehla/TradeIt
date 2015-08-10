﻿using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TradeIt.Forms {
    public partial class FastDebugForm : Form {
        private int maxChars = 1000000;
        private int curLength = 0;

        TextStyle debugStyle = new TextStyle(Brushes.Black, null, FontStyle.Regular);
        TextStyle infoStyle = new TextStyle(Brushes.Green, null, FontStyle.Regular);
        TextStyle warningStyle = new TextStyle(Brushes.DarkOrange, null, FontStyle.Regular);
        TextStyle errorStyle = new TextStyle(Brushes.Red, null, FontStyle.Regular);
        TextStyle importandStyle = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
        TextStyle traderStyle = new TextStyle(Brushes.DarkViolet, null, FontStyle.Bold);

        DateTime lastLog = new DateTime(0);

        public FastDebugForm() {
            InitializeComponent();
        }
        public void stopUpdate() {
            fctb.BeginUpdate();
            fctb.Selection.BeginUpdate();
        }
        public void startUpdate() {
            fctb.Selection.EndUpdate();
            fctb.EndUpdate();
        }
        private void Log(string text, Style style) {
            //remember user selection
            var userSelection = fctb.Selection.Clone();
            //add text with predefined style
            fctb.TextSource.CurrentTB = fctb;
            if (curLength > maxChars) {
                fctb.Clear();
                curLength = 0;
            }
            curLength += text.Length;
            fctb.AppendText(text, style);
            //restore user selection
            if (lastLog.AddSeconds(5) < DateTime.Now) {

                if (!userSelection.IsEmpty || userSelection.Start.iLine < fctb.LinesCount - 2) {
                    fctb.Selection.Start = userSelection.Start;
                    fctb.Selection.End = userSelection.End;
                } else {
                    fctb.GoEnd();//scroll to end of the text
                }
            }
            lastLog = DateTime.Now;
        }

        private void btGotToEnd_Click(object sender, EventArgs e) {
            fctb.GoEnd();
        }

        
        public void logDebug(string text) {
            Log(text, debugStyle);
        }
        public void logInfo(string text) {
            Log(text, infoStyle);
        }
        public void logError(string text) {
            Log(text, errorStyle);
        }
        public void logWarning(string text) {
            Log(text, warningStyle);
        }
        public void logImportand(string text) {
            Log(text, importandStyle);
        }
        public void logTrader(string text) {
            Log(text, traderStyle);
            Color c = Color.Black;
            if (text.Contains("SELL")) c = Color.Red;
            if (text.Contains("BUY")) c = Color.Green;
            //Log(text, infoStyle);
        }

        private void DebugForm_FormClosing(object sender, FormClosingEventArgs e) {
            this.Hide();
            e.Cancel = true; // this cancels the close event.
        }

        private void FastDebugForm_Load(object sender, EventArgs e) {

        }

        private void FastDebugForm_FormClosing(object sender, FormClosingEventArgs e) {
            this.Hide();
            e.Cancel = true; // this cancels the close event.
        }
    }
}
