﻿namespace Main {
    partial class MainForm {
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.bMainShowDebug = new System.Windows.Forms.Button();
            this.TickTimer = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDebug = new System.Windows.Forms.TabPage();
            this.dgvDebugWatch = new System.Windows.Forms.DataGridView();
            this.bResetWatches = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lChartPosition = new System.Windows.Forms.Label();
            this.chartControl = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tpTrader = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbTraderStatus = new System.Windows.Forms.TextBox();
            this.cbTraderLive = new System.Windows.Forms.CheckBox();
            this.lTraderStatus = new System.Windows.Forms.Label();
            this.gbTraderDllSettings = new System.Windows.Forms.GroupBox();
            this.cbAutoLoadTrader = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTraderDllFilename = new System.Windows.Forms.TextBox();
            this.bReloadTrader = new System.Windows.Forms.Button();
            this.tabStats = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lStartPortoBTC = new System.Windows.Forms.Label();
            this.lStartPortoEUR = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.cbAutoLoadSimPorto = new System.Windows.Forms.CheckBox();
            this.bSetSimPorto = new System.Windows.Forms.Button();
            this.tbSimPortoEUR = new System.Windows.Forms.TextBox();
            this.tbSimPortoBTC = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lSimPortoBTC = new System.Windows.Forms.Label();
            this.lSimPortoEUR = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lCurPortoBTC = new System.Windows.Forms.Label();
            this.lCurPortoEUR = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabHelp = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lHelpMemoryUsed = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lHelpVersion = new System.Windows.Forms.Label();
            this.lHelpCompileDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvTradeHistory = new System.Windows.Forms.DataGridView();
            this.tabApi = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbAutoLoadTickerApi = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbApiDllPath = new System.Windows.Forms.TextBox();
            this.bApiLoad = new System.Windows.Forms.Button();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.nudMaxChartPoints = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cbCandleIntervall = new System.Windows.Forms.ComboBox();
            this.tabDetailSettings = new System.Windows.Forms.TabPage();
            this.dgvDetailSettings = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssTraderInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssApiInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tradeItFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitcoinavaragecomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitcoinchartcomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.resetDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDebugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lTotalBTC = new System.Windows.Forms.Label();
            this.lTotalEUR = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabDebug.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDebugWatch)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).BeginInit();
            this.tpTrader.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbTraderDllSettings.SuspendLayout();
            this.tabStats.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabHelp.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTradeHistory)).BeginInit();
            this.tabApi.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxChartPoints)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.tabDetailSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailSettings)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.SuspendLayout();
            // 
            // bMainShowDebug
            // 
            this.bMainShowDebug.Location = new System.Drawing.Point(6, 6);
            this.bMainShowDebug.Name = "bMainShowDebug";
            this.bMainShowDebug.Size = new System.Drawing.Size(147, 23);
            this.bMainShowDebug.TabIndex = 0;
            this.bMainShowDebug.Text = "Show Debug";
            this.bMainShowDebug.UseVisualStyleBackColor = true;
            this.bMainShowDebug.Click += new System.EventHandler(this.bMainShowDebug_Click);
            // 
            // TickTimer
            // 
            this.TickTimer.Enabled = true;
            this.TickTimer.Interval = 1000;
            this.TickTimer.Tick += new System.EventHandler(this.TickTimer_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabDebug);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tpTrader);
            this.tabControl1.Controls.Add(this.tabStats);
            this.tabControl1.Controls.Add(this.tabHelp);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabApi);
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Controls.Add(this.tabDetailSettings);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(681, 451);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabDebug
            // 
            this.tabDebug.Controls.Add(this.dgvDebugWatch);
            this.tabDebug.Controls.Add(this.bResetWatches);
            this.tabDebug.Controls.Add(this.bMainShowDebug);
            this.tabDebug.Location = new System.Drawing.Point(4, 22);
            this.tabDebug.Name = "tabDebug";
            this.tabDebug.Padding = new System.Windows.Forms.Padding(3);
            this.tabDebug.Size = new System.Drawing.Size(673, 425);
            this.tabDebug.TabIndex = 0;
            this.tabDebug.Text = "Debug";
            this.tabDebug.UseVisualStyleBackColor = true;
            // 
            // dgvDebugWatch
            // 
            this.dgvDebugWatch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDebugWatch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDebugWatch.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDebugWatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDebugWatch.Location = new System.Drawing.Point(6, 35);
            this.dgvDebugWatch.Name = "dgvDebugWatch";
            this.dgvDebugWatch.Size = new System.Drawing.Size(661, 384);
            this.dgvDebugWatch.TabIndex = 1;
            // 
            // bResetWatches
            // 
            this.bResetWatches.Location = new System.Drawing.Point(159, 6);
            this.bResetWatches.Name = "bResetWatches";
            this.bResetWatches.Size = new System.Drawing.Size(93, 23);
            this.bResetWatches.TabIndex = 0;
            this.bResetWatches.Text = "Reset Watches";
            this.bResetWatches.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bResetWatches.UseVisualStyleBackColor = true;
            this.bResetWatches.Click += new System.EventHandler(this.bResetWatches_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lChartPosition);
            this.tabPage2.Controls.Add(this.chartControl);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(673, 425);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Chart";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lChartPosition
            // 
            this.lChartPosition.AutoSize = true;
            this.lChartPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lChartPosition.Location = new System.Drawing.Point(3, 4);
            this.lChartPosition.Name = "lChartPosition";
            this.lChartPosition.Size = new System.Drawing.Size(51, 20);
            this.lChartPosition.TabIndex = 1;
            this.lChartPosition.Text = "label9";
            // 
            // chartControl
            // 
            chartArea1.Name = "ChartArea1";
            this.chartControl.ChartAreas.Add(chartArea1);
            this.chartControl.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartControl.Legends.Add(legend1);
            this.chartControl.Location = new System.Drawing.Point(3, 3);
            this.chartControl.Name = "chartControl";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartControl.Series.Add(series1);
            this.chartControl.Size = new System.Drawing.Size(667, 419);
            this.chartControl.TabIndex = 0;
            this.chartControl.Text = "chart1";
            this.chartControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chartControl_MouseMove);
            // 
            // tpTrader
            // 
            this.tpTrader.Controls.Add(this.groupBox3);
            this.tpTrader.Controls.Add(this.gbTraderDllSettings);
            this.tpTrader.Location = new System.Drawing.Point(4, 22);
            this.tpTrader.Name = "tpTrader";
            this.tpTrader.Padding = new System.Windows.Forms.Padding(3);
            this.tpTrader.Size = new System.Drawing.Size(673, 425);
            this.tpTrader.TabIndex = 2;
            this.tpTrader.Text = "Trader";
            this.tpTrader.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbTraderStatus);
            this.groupBox3.Controls.Add(this.cbTraderLive);
            this.groupBox3.Controls.Add(this.lTraderStatus);
            this.groupBox3.Location = new System.Drawing.Point(6, 97);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(315, 322);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Status";
            // 
            // tbTraderStatus
            // 
            this.tbTraderStatus.Location = new System.Drawing.Point(6, 50);
            this.tbTraderStatus.Multiline = true;
            this.tbTraderStatus.Name = "tbTraderStatus";
            this.tbTraderStatus.Size = new System.Drawing.Size(303, 266);
            this.tbTraderStatus.TabIndex = 6;
            // 
            // cbTraderLive
            // 
            this.cbTraderLive.AutoSize = true;
            this.cbTraderLive.Location = new System.Drawing.Point(6, 28);
            this.cbTraderLive.Name = "cbTraderLive";
            this.cbTraderLive.Size = new System.Drawing.Size(46, 17);
            this.cbTraderLive.TabIndex = 5;
            this.cbTraderLive.Text = "Live";
            this.cbTraderLive.UseVisualStyleBackColor = true;
            this.cbTraderLive.CheckedChanged += new System.EventHandler(this.cbTraderLive_CheckedChanged);
            // 
            // lTraderStatus
            // 
            this.lTraderStatus.AutoSize = true;
            this.lTraderStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTraderStatus.Location = new System.Drawing.Point(58, 16);
            this.lTraderStatus.Name = "lTraderStatus";
            this.lTraderStatus.Size = new System.Drawing.Size(86, 31);
            this.lTraderStatus.TabIndex = 0;
            this.lTraderStatus.Text = "label5";
            // 
            // gbTraderDllSettings
            // 
            this.gbTraderDllSettings.Controls.Add(this.cbAutoLoadTrader);
            this.gbTraderDllSettings.Controls.Add(this.label1);
            this.gbTraderDllSettings.Controls.Add(this.tbTraderDllFilename);
            this.gbTraderDllSettings.Controls.Add(this.bReloadTrader);
            this.gbTraderDllSettings.Location = new System.Drawing.Point(6, 6);
            this.gbTraderDllSettings.Name = "gbTraderDllSettings";
            this.gbTraderDllSettings.Size = new System.Drawing.Size(488, 85);
            this.gbTraderDllSettings.TabIndex = 3;
            this.gbTraderDllSettings.TabStop = false;
            this.gbTraderDllSettings.Text = "Dll Settings";
            // 
            // cbAutoLoadTrader
            // 
            this.cbAutoLoadTrader.AutoSize = true;
            this.cbAutoLoadTrader.Location = new System.Drawing.Point(288, 55);
            this.cbAutoLoadTrader.Name = "cbAutoLoadTrader";
            this.cbAutoLoadTrader.Size = new System.Drawing.Size(71, 17);
            this.cbAutoLoadTrader.TabIndex = 5;
            this.cbAutoLoadTrader.Text = "Auto load";
            this.cbAutoLoadTrader.UseVisualStyleBackColor = true;
            this.cbAutoLoadTrader.CheckedChanged += new System.EventHandler(this.checkBox_StateChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Path";
            // 
            // tbTraderDllFilename
            // 
            this.tbTraderDllFilename.Location = new System.Drawing.Point(41, 19);
            this.tbTraderDllFilename.Name = "tbTraderDllFilename";
            this.tbTraderDllFilename.Size = new System.Drawing.Size(441, 20);
            this.tbTraderDllFilename.TabIndex = 3;
            this.tbTraderDllFilename.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            this.tbTraderDllFilename.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FilenameTextBoxMouseDoubleClick);
            // 
            // bReloadTrader
            // 
            this.bReloadTrader.Location = new System.Drawing.Point(365, 51);
            this.bReloadTrader.Name = "bReloadTrader";
            this.bReloadTrader.Size = new System.Drawing.Size(117, 23);
            this.bReloadTrader.TabIndex = 2;
            this.bReloadTrader.Text = "LoadTrader";
            this.bReloadTrader.UseVisualStyleBackColor = true;
            this.bReloadTrader.Click += new System.EventHandler(this.bReloadTrader_Click);
            // 
            // tabStats
            // 
            this.tabStats.Controls.Add(this.groupBox11);
            this.tabStats.Controls.Add(this.groupBox2);
            this.tabStats.Controls.Add(this.groupBox10);
            this.tabStats.Controls.Add(this.groupBox9);
            this.tabStats.Controls.Add(this.groupBox1);
            this.tabStats.Location = new System.Drawing.Point(4, 22);
            this.tabStats.Name = "tabStats";
            this.tabStats.Padding = new System.Windows.Forms.Padding(3);
            this.tabStats.Size = new System.Drawing.Size(673, 425);
            this.tabStats.TabIndex = 3;
            this.tabStats.Text = "Stats";
            this.tabStats.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lStartPortoBTC);
            this.groupBox2.Controls.Add(this.lStartPortoEUR);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(6, 172);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(202, 77);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Start Portoflio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "EUR:";
            // 
            // lStartPortoBTC
            // 
            this.lStartPortoBTC.AutoSize = true;
            this.lStartPortoBTC.Location = new System.Drawing.Point(45, 25);
            this.lStartPortoBTC.Name = "lStartPortoBTC";
            this.lStartPortoBTC.Size = new System.Drawing.Size(31, 13);
            this.lStartPortoBTC.TabIndex = 0;
            this.lStartPortoBTC.Text = "BTC:";
            // 
            // lStartPortoEUR
            // 
            this.lStartPortoEUR.AutoSize = true;
            this.lStartPortoEUR.Location = new System.Drawing.Point(45, 50);
            this.lStartPortoEUR.Name = "lStartPortoEUR";
            this.lStartPortoEUR.Size = new System.Drawing.Size(31, 13);
            this.lStartPortoEUR.TabIndex = 0;
            this.lStartPortoEUR.Text = "BTC:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "BTC:";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.cbAutoLoadSimPorto);
            this.groupBox10.Controls.Add(this.bSetSimPorto);
            this.groupBox10.Controls.Add(this.tbSimPortoEUR);
            this.groupBox10.Controls.Add(this.tbSimPortoBTC);
            this.groupBox10.Controls.Add(this.label12);
            this.groupBox10.Controls.Add(this.label16);
            this.groupBox10.Location = new System.Drawing.Point(214, 6);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(244, 77);
            this.groupBox10.TabIndex = 0;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Simulate Portoflio";
            // 
            // cbAutoLoadSimPorto
            // 
            this.cbAutoLoadSimPorto.AutoSize = true;
            this.cbAutoLoadSimPorto.Location = new System.Drawing.Point(154, 49);
            this.cbAutoLoadSimPorto.Name = "cbAutoLoadSimPorto";
            this.cbAutoLoadSimPorto.Size = new System.Drawing.Size(71, 17);
            this.cbAutoLoadSimPorto.TabIndex = 5;
            this.cbAutoLoadSimPorto.Text = "Auto load";
            this.cbAutoLoadSimPorto.UseVisualStyleBackColor = true;
            this.cbAutoLoadSimPorto.CheckedChanged += new System.EventHandler(this.checkBox_StateChanged);
            // 
            // bSetSimPorto
            // 
            this.bSetSimPorto.Location = new System.Drawing.Point(155, 19);
            this.bSetSimPorto.Name = "bSetSimPorto";
            this.bSetSimPorto.Size = new System.Drawing.Size(83, 23);
            this.bSetSimPorto.TabIndex = 2;
            this.bSetSimPorto.Text = "Set";
            this.bSetSimPorto.UseVisualStyleBackColor = true;
            this.bSetSimPorto.Click += new System.EventHandler(this.bSetSimPorto_Click);
            // 
            // tbSimPortoEUR
            // 
            this.tbSimPortoEUR.Location = new System.Drawing.Point(48, 47);
            this.tbSimPortoEUR.Name = "tbSimPortoEUR";
            this.tbSimPortoEUR.Size = new System.Drawing.Size(100, 20);
            this.tbSimPortoEUR.TabIndex = 1;
            this.tbSimPortoEUR.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // tbSimPortoBTC
            // 
            this.tbSimPortoBTC.Location = new System.Drawing.Point(48, 22);
            this.tbSimPortoBTC.Name = "tbSimPortoBTC";
            this.tbSimPortoBTC.Size = new System.Drawing.Size(100, 20);
            this.tbSimPortoBTC.TabIndex = 1;
            this.tbSimPortoBTC.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "EUR:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 25);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(31, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "BTC:";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label11);
            this.groupBox9.Controls.Add(this.lSimPortoBTC);
            this.groupBox9.Controls.Add(this.lSimPortoEUR);
            this.groupBox9.Controls.Add(this.label14);
            this.groupBox9.Location = new System.Drawing.Point(214, 159);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(202, 77);
            this.groupBox9.TabIndex = 0;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Simulate Portoflio";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "EUR:";
            // 
            // lSimPortoBTC
            // 
            this.lSimPortoBTC.AutoSize = true;
            this.lSimPortoBTC.Location = new System.Drawing.Point(45, 25);
            this.lSimPortoBTC.Name = "lSimPortoBTC";
            this.lSimPortoBTC.Size = new System.Drawing.Size(31, 13);
            this.lSimPortoBTC.TabIndex = 0;
            this.lSimPortoBTC.Text = "BTC:";
            // 
            // lSimPortoEUR
            // 
            this.lSimPortoEUR.AutoSize = true;
            this.lSimPortoEUR.Location = new System.Drawing.Point(45, 50);
            this.lSimPortoEUR.Name = "lSimPortoEUR";
            this.lSimPortoEUR.Size = new System.Drawing.Size(31, 13);
            this.lSimPortoEUR.TabIndex = 0;
            this.lSimPortoEUR.Text = "BTC:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 25);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "BTC:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lCurPortoBTC);
            this.groupBox1.Controls.Add(this.lCurPortoEUR);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Portoflio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "EUR:";
            // 
            // lCurPortoBTC
            // 
            this.lCurPortoBTC.AutoSize = true;
            this.lCurPortoBTC.Location = new System.Drawing.Point(45, 25);
            this.lCurPortoBTC.Name = "lCurPortoBTC";
            this.lCurPortoBTC.Size = new System.Drawing.Size(31, 13);
            this.lCurPortoBTC.TabIndex = 0;
            this.lCurPortoBTC.Text = "BTC:";
            // 
            // lCurPortoEUR
            // 
            this.lCurPortoEUR.AutoSize = true;
            this.lCurPortoEUR.Location = new System.Drawing.Point(45, 50);
            this.lCurPortoEUR.Name = "lCurPortoEUR";
            this.lCurPortoEUR.Size = new System.Drawing.Size(31, 13);
            this.lCurPortoEUR.TabIndex = 0;
            this.lCurPortoEUR.Text = "BTC:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "BTC:";
            // 
            // tabHelp
            // 
            this.tabHelp.Controls.Add(this.groupBox5);
            this.tabHelp.Controls.Add(this.groupBox4);
            this.tabHelp.Location = new System.Drawing.Point(4, 22);
            this.tabHelp.Name = "tabHelp";
            this.tabHelp.Padding = new System.Windows.Forms.Padding(3);
            this.tabHelp.Size = new System.Drawing.Size(673, 425);
            this.tabHelp.TabIndex = 4;
            this.tabHelp.Text = "Help";
            this.tabHelp.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.lHelpMemoryUsed);
            this.groupBox5.Location = new System.Drawing.Point(6, 88);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 100);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Prozess Infos";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Memory used: ";
            // 
            // lHelpMemoryUsed
            // 
            this.lHelpMemoryUsed.AutoSize = true;
            this.lHelpMemoryUsed.Location = new System.Drawing.Point(90, 16);
            this.lHelpMemoryUsed.Name = "lHelpMemoryUsed";
            this.lHelpMemoryUsed.Size = new System.Drawing.Size(30, 13);
            this.lHelpMemoryUsed.TabIndex = 0;
            this.lHelpMemoryUsed.Text = "Date";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lHelpVersion);
            this.groupBox4.Controls.Add(this.lHelpCompileDate);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(224, 76);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Compile Infos";
            // 
            // lHelpVersion
            // 
            this.lHelpVersion.AutoSize = true;
            this.lHelpVersion.Location = new System.Drawing.Point(54, 39);
            this.lHelpVersion.Name = "lHelpVersion";
            this.lHelpVersion.Size = new System.Drawing.Size(30, 13);
            this.lHelpVersion.TabIndex = 0;
            this.lHelpVersion.Text = "Date";
            // 
            // lHelpCompileDate
            // 
            this.lHelpCompileDate.AutoSize = true;
            this.lHelpCompileDate.Location = new System.Drawing.Point(54, 16);
            this.lHelpCompileDate.Name = "lHelpCompileDate";
            this.lHelpCompileDate.Size = new System.Drawing.Size(30, 13);
            this.lHelpCompileDate.TabIndex = 0;
            this.lHelpCompileDate.Text = "Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Version";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Date";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgvTradeHistory);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(673, 425);
            this.tabPage4.TabIndex = 5;
            this.tabPage4.Text = "Trade History";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvTradeHistory
            // 
            this.dgvTradeHistory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgvTradeHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTradeHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTradeHistory.Location = new System.Drawing.Point(3, 3);
            this.dgvTradeHistory.Name = "dgvTradeHistory";
            this.dgvTradeHistory.ReadOnly = true;
            this.dgvTradeHistory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvTradeHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTradeHistory.Size = new System.Drawing.Size(667, 419);
            this.dgvTradeHistory.TabIndex = 0;
            // 
            // tabApi
            // 
            this.tabApi.Controls.Add(this.groupBox6);
            this.tabApi.Location = new System.Drawing.Point(4, 22);
            this.tabApi.Name = "tabApi";
            this.tabApi.Padding = new System.Windows.Forms.Padding(3);
            this.tabApi.Size = new System.Drawing.Size(673, 425);
            this.tabApi.TabIndex = 6;
            this.tabApi.Text = "Api";
            this.tabApi.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cbAutoLoadTickerApi);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.tbApiDllPath);
            this.groupBox6.Controls.Add(this.bApiLoad);
            this.groupBox6.Location = new System.Drawing.Point(6, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(488, 85);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Dll Settings";
            // 
            // cbAutoLoadTickerApi
            // 
            this.cbAutoLoadTickerApi.AutoSize = true;
            this.cbAutoLoadTickerApi.Location = new System.Drawing.Point(288, 55);
            this.cbAutoLoadTickerApi.Name = "cbAutoLoadTickerApi";
            this.cbAutoLoadTickerApi.Size = new System.Drawing.Size(71, 17);
            this.cbAutoLoadTickerApi.TabIndex = 5;
            this.cbAutoLoadTickerApi.Text = "Auto load";
            this.cbAutoLoadTickerApi.UseVisualStyleBackColor = true;
            this.cbAutoLoadTickerApi.CheckedChanged += new System.EventHandler(this.checkBox_StateChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Path";
            // 
            // tbApiDllPath
            // 
            this.tbApiDllPath.Location = new System.Drawing.Point(41, 19);
            this.tbApiDllPath.Name = "tbApiDllPath";
            this.tbApiDllPath.Size = new System.Drawing.Size(441, 20);
            this.tbApiDllPath.TabIndex = 3;
            this.tbApiDllPath.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            this.tbApiDllPath.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FilenameTextBoxMouseDoubleClick);
            // 
            // bApiLoad
            // 
            this.bApiLoad.Location = new System.Drawing.Point(365, 51);
            this.bApiLoad.Name = "bApiLoad";
            this.bApiLoad.Size = new System.Drawing.Size(117, 23);
            this.bApiLoad.TabIndex = 2;
            this.bApiLoad.Text = "Load Api";
            this.bApiLoad.UseVisualStyleBackColor = true;
            this.bApiLoad.Click += new System.EventHandler(this.bApiLoad_Click);
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.groupBox8);
            this.tabSettings.Controls.Add(this.groupBox7);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(673, 425);
            this.tabSettings.TabIndex = 7;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.nudMaxChartPoints);
            this.groupBox8.Controls.Add(this.label10);
            this.groupBox8.Location = new System.Drawing.Point(6, 77);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(180, 69);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Candle Intervall";
            // 
            // nudMaxChartPoints
            // 
            this.nudMaxChartPoints.Location = new System.Drawing.Point(99, 25);
            this.nudMaxChartPoints.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudMaxChartPoints.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudMaxChartPoints.Name = "nudMaxChartPoints";
            this.nudMaxChartPoints.Size = new System.Drawing.Size(69, 20);
            this.nudMaxChartPoints.TabIndex = 1;
            this.nudMaxChartPoints.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudMaxChartPoints.ValueChanged += new System.EventHandler(this.nudMaxChartPoints_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Max Chart Points";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.cbCandleIntervall);
            this.groupBox7.Location = new System.Drawing.Point(6, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(145, 55);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Candle Intervall";
            // 
            // cbCandleIntervall
            // 
            this.cbCandleIntervall.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCandleIntervall.FormattingEnabled = true;
            this.cbCandleIntervall.Items.AddRange(new object[] {
            "Test",
            "Test2"});
            this.cbCandleIntervall.Location = new System.Drawing.Point(6, 19);
            this.cbCandleIntervall.Name = "cbCandleIntervall";
            this.cbCandleIntervall.Size = new System.Drawing.Size(121, 21);
            this.cbCandleIntervall.TabIndex = 0;
            this.cbCandleIntervall.SelectedIndexChanged += new System.EventHandler(this.cbCandleIntervall_SelectedIndexChanged);
            // 
            // tabDetailSettings
            // 
            this.tabDetailSettings.Controls.Add(this.dgvDetailSettings);
            this.tabDetailSettings.Location = new System.Drawing.Point(4, 22);
            this.tabDetailSettings.Name = "tabDetailSettings";
            this.tabDetailSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetailSettings.Size = new System.Drawing.Size(673, 425);
            this.tabDetailSettings.TabIndex = 8;
            this.tabDetailSettings.Text = "Detail Settings";
            this.tabDetailSettings.UseVisualStyleBackColor = true;
            // 
            // dgvDetailSettings
            // 
            this.dgvDetailSettings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDetailSettings.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDetailSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetailSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetailSettings.Location = new System.Drawing.Point(3, 3);
            this.dgvDetailSettings.Name = "dgvDetailSettings";
            this.dgvDetailSettings.Size = new System.Drawing.Size(667, 419);
            this.dgvDetailSettings.TabIndex = 0;
            this.dgvDetailSettings.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetailSettings_CellValueChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssTraderInfo,
            this.toolStripSplitButton1,
            this.toolStripStatusLabel1,
            this.tssApiInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 481);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(705, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssTraderInfo
            // 
            this.tssTraderInfo.Name = "tssTraderInfo";
            this.tssTraderInfo.Size = new System.Drawing.Size(61, 17);
            this.tssTraderInfo.Text = "TraderInfo";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(0, 17);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // tssApiInfo
            // 
            this.tssApiInfo.Name = "tssApiInfo";
            this.tssApiInfo.Size = new System.Drawing.Size(46, 17);
            this.tssApiInfo.Text = "ApiInfo";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.showDebugToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(705, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.toolStripSeparator1,
            this.resetDatabaseToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tradeItFileToolStripMenuItem,
            this.bitcoinavaragecomToolStripMenuItem,
            this.bitcoinchartcomToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // tradeItFileToolStripMenuItem
            // 
            this.tradeItFileToolStripMenuItem.Name = "tradeItFileToolStripMenuItem";
            this.tradeItFileToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.tradeItFileToolStripMenuItem.Text = "TradeIt File...";
            this.tradeItFileToolStripMenuItem.Click += new System.EventHandler(this.tradeItFileToolStripMenuItem_Click);
            // 
            // bitcoinavaragecomToolStripMenuItem
            // 
            this.bitcoinavaragecomToolStripMenuItem.Name = "bitcoinavaragecomToolStripMenuItem";
            this.bitcoinavaragecomToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.bitcoinavaragecomToolStripMenuItem.Text = "Bitcoinavarage.com...";
            this.bitcoinavaragecomToolStripMenuItem.Click += new System.EventHandler(this.bitcoinavaragecomToolStripMenuItem_Click);
            // 
            // bitcoinchartcomToolStripMenuItem
            // 
            this.bitcoinchartcomToolStripMenuItem.Name = "bitcoinchartcomToolStripMenuItem";
            this.bitcoinchartcomToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.bitcoinchartcomToolStripMenuItem.Text = "Bitcoinchart.com...";
            this.bitcoinchartcomToolStripMenuItem.Click += new System.EventHandler(this.bitcoinchartcomToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.exportToolStripMenuItem.Text = "Export...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(150, 6);
            // 
            // resetDatabaseToolStripMenuItem
            // 
            this.resetDatabaseToolStripMenuItem.Name = "resetDatabaseToolStripMenuItem";
            this.resetDatabaseToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.resetDatabaseToolStripMenuItem.Text = "Reset Database";
            this.resetDatabaseToolStripMenuItem.Click += new System.EventHandler(this.resetDatabaseToolStripMenuItem_Click);
            // 
            // showDebugToolStripMenuItem
            // 
            this.showDebugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem});
            this.showDebugToolStripMenuItem.Name = "showDebugToolStripMenuItem";
            this.showDebugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.showDebugToolStripMenuItem.Text = "Debug";
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.bMainShowDebug_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.label13);
            this.groupBox11.Controls.Add(this.lTotalBTC);
            this.groupBox11.Controls.Add(this.lTotalEUR);
            this.groupBox11.Controls.Add(this.label18);
            this.groupBox11.Location = new System.Drawing.Point(6, 89);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(202, 77);
            this.groupBox11.TabIndex = 0;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Total Portfolio";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 50);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "EUR:";
            // 
            // lTotalBTC
            // 
            this.lTotalBTC.AutoSize = true;
            this.lTotalBTC.Location = new System.Drawing.Point(45, 25);
            this.lTotalBTC.Name = "lTotalBTC";
            this.lTotalBTC.Size = new System.Drawing.Size(31, 13);
            this.lTotalBTC.TabIndex = 0;
            this.lTotalBTC.Text = "BTC:";
            // 
            // lTotalEUR
            // 
            this.lTotalEUR.AutoSize = true;
            this.lTotalEUR.Location = new System.Drawing.Point(45, 50);
            this.lTotalEUR.Name = "lTotalEUR";
            this.lTotalEUR.Size = new System.Drawing.Size(31, 13);
            this.lTotalEUR.TabIndex = 0;
            this.lTotalEUR.Text = "BTC:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 25);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(31, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "BTC:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 503);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "TradeIt";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabDebug.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDebugWatch)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl)).EndInit();
            this.tpTrader.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbTraderDllSettings.ResumeLayout(false);
            this.gbTraderDllSettings.PerformLayout();
            this.tabStats.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabHelp.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTradeHistory)).EndInit();
            this.tabApi.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxChartPoints)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.tabDetailSettings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailSettings)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bMainShowDebug;
        private System.Windows.Forms.Timer TickTimer;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDebug;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartControl;
        private System.Windows.Forms.Button bReloadTrader;
        private System.Windows.Forms.TabPage tpTrader;
        private System.Windows.Forms.GroupBox gbTraderDllSettings;
        private System.Windows.Forms.CheckBox cbTraderLive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTraderDllFilename;
        private System.Windows.Forms.TabPage tabStats;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lStartPortoBTC;
        private System.Windows.Forms.Label lStartPortoEUR;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lCurPortoBTC;
        private System.Windows.Forms.Label lCurPortoEUR;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lTraderStatus;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tradeItFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bitcoinavaragecomToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem resetDatabaseToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripStatusLabel tssTraderInfo;
        private System.Windows.Forms.TabPage tabHelp;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lHelpVersion;
        private System.Windows.Forms.Label lHelpCompileDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lHelpMemoryUsed;
        private System.Windows.Forms.Label lChartPosition;
        private System.Windows.Forms.ToolStripStatusLabel tssApiInfo;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dgvTradeHistory;
        private System.Windows.Forms.TabPage tabApi;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbApiDllPath;
        private System.Windows.Forms.Button bApiLoad;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.ComboBox cbCandleIntervall;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.NumericUpDown nudMaxChartPoints;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripMenuItem showDebugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.TabPage tabDetailSettings;
        private System.Windows.Forms.DataGridView dgvDetailSettings;
        private System.Windows.Forms.TextBox tbTraderStatus;
        private System.Windows.Forms.DataGridView dgvDebugWatch;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button bSetSimPorto;
        private System.Windows.Forms.TextBox tbSimPortoEUR;
        private System.Windows.Forms.TextBox tbSimPortoBTC;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lSimPortoBTC;
        private System.Windows.Forms.Label lSimPortoEUR;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ToolStripMenuItem bitcoinchartcomToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbAutoLoadTrader;
        private System.Windows.Forms.CheckBox cbAutoLoadSimPorto;
        private System.Windows.Forms.CheckBox cbAutoLoadTickerApi;
        private System.Windows.Forms.ToolStripStatusLabel toolStripSplitButton1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button bResetWatches;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lTotalBTC;
        private System.Windows.Forms.Label lTotalEUR;
        private System.Windows.Forms.Label label18;
    }
}

