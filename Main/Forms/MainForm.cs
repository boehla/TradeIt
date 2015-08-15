using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Main.Api;
using TradeIt.Forms;

namespace Main {
    public partial class MainForm : Form {
        public const string MAINVERSION = "0.1.1";

        public static FastDebugForm df = null;
        public Api.ApiHelp kh = new ApiHelp();
        public CandleManager cm = new CandleManager();
        public Trader tr;
        public static System.Windows.Forms.DataVisualization.Charting.Chart chartcont = null;

        public bool disableEvents = false;

        public CandleInterval candleInter = CandleInterval._5m;

        public MainForm() {
            df = new FastDebugForm();
            InitializeComponent();
            Logging.log("Application started...", LogPrior.Info);
            chartcont = chartControl;
            chartcont.ChartAreas[0].AxisX.LabelStyle.Format = "dd.MM HH:mm";
            chartcont.ChartAreas[0].AxisY.IsStartedFromZero = false;
            chartcont.ChartAreas[0].Name = "0";
            chartControl.Series.Clear();

            Settings.load();
            tbTraderDllFilename.Text = Settings.getString(SettKeys.TRADER_DLL_FILE);

            lHelpCompileDate.Text = RetrieveLinkerTimestamp().ToString(Lib.Const.DATE_TIME_FORMAT);
            lHelpVersion.Text = MAINVERSION;

            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |BindingFlags.Instance | BindingFlags.SetProperty, null,dgvTradeHistory, new object[] { true });
        }

        private void MainForm_Load(object sender, EventArgs e) {
            cm.generateNew();
            //cm.generateNew();
            cm.loadFromFile("data\\backup.data", false);

            //tr = loadTraderFromDll(Settings.getString(SettKeys.TRADER_DLL_FILE));
            //if (tr != null) tr.Initiale();

            cbCandleIntervall.Items.Clear();
            foreach (CandleInterval item in Enum.GetValues(typeof(CandleInterval))) {
                cbCandleIntervall.Items.Add(item);
            }

            LoadSettings();

            cm.CandleList[(int)candleInter].OnNewCandle += new NewCandleEventHandler(OnNewCandleReceived);
            //cm.loadFromFile(@"data\backup.data", true);

            //cm.loadFromBitcoinAvarage(@"C:\New folder\bitavaM.csv", true);
            //cm.loadFromFile(@"C:\New folder\backup.data", true);
            //cm.loadFromBitcoinAvarage(@"C:\New folder\bitava2.csv", true);
            //cm.loadFromFile(Settings.getString(SettKeys.DATA_FILE), true)
            //if (!CandleTest.testCandels()) {
            //    MessageBox.Show("Test Failed, Please check CandelListClass!!!!!");
            //    this.Close();
            //}

            
        }

        private void LoadSettings() {
            cbCandleIntervall.SelectedItem = (CandleInterval)Settings.getInt(SettKeys.CANDLE_INTERVALL);
            candleInter = (CandleInterval)Settings.getInt(SettKeys.CANDLE_INTERVALL);
            if (candleInter <= 0) candleInter = CandleInterval._1h;
            nudMaxChartPoints.Value = Settings.getInt(SettKeys.MAX_CHART_POINTS);

            foreach (string key in Settings.Data.Keys) {
                if (key.StartsWith(Lib.Const.IDS.TEXTBOX)) {
                    string tbname = key.Substring(Lib.Const.IDS.TEXTBOX.Length);
                    Control[] tb = this.Controls.Find(tbname, true);
                    foreach (Control item in tb) {
                        disableEvents = true;
                        item.Text = Lib.Converter.toString(Settings.Data[key]);
                        disableEvents = false;
                    }
                    
                }
            }
        }

        private void bMainShowDebug_Click(object sender, EventArgs e) {
            try {
                if (df.IsDisposed) df = new FastDebugForm();
                df.Show();
                df.Focus();
            } catch (Exception ex) {
                Logging.logException("failed at showdebugclick", ex);
            }
        }

        private int timercounter = 0;
        private int tryagain = -1;
        private void TickTimer_Tick(object sender, EventArgs e) {
            try {
                if (timercounter % 60 == 0 || timercounter % 60 == tryagain) {
                    try {
                        ApiTicker tp = kh.getTicker("XXBTZEUR");
                        cm.archiveTick(tp);
                        cm.addToAllNewTicker(tp, DateTime.Now);
                        tryagain = -1;
                    } catch (Exception ex) {
                        Logging.logException("Failed to getTicker:", ex);
                        if (tryagain == -1) tryagain = 5;
                    }
                    refreshTraderStatus();
                }
                if (timercounter % 120 == 2) {
                    kh.refreshPortfolio();
                }
                if (timercounter % 600 == 5) {
                    cm.saveToFile(Settings.getString(SettKeys.DATA_FILE));
                }
                if (timercounter % 900 == 30) {
                    ApiTradeHistory trd = kh.getTrades();
                    dgvTradeHistory.DataSource = trd.getDataTable();
                    dgvTradeHistory.Refresh();
                }

                if (tabControl1.SelectedTab == tabDebug) {
                    dgvDebugWatch.DataSource = Lib.Performance.getTable();
                } else if (tabControl1.SelectedTab == tabHelp) {
                    refreshMemoryStats();
                } else if (tabControl1.SelectedTab == tabStats) {
                    refreshPortfolio();
                }
                if (Settings.HasChange) Settings.save();
                
            } catch (Exception ex) {
                Logging.logException("Failed at Timercounter: " + timercounter, ex);
            } finally {
                timercounter++;
            }
        }

        private void OnNewCandleReceived(object source, NewCandleArgs e) {
            try {
                Logging.log("New Candle received: " + Lib.Converter.toString(e.Candle.dt) + "; Data=" + e.Candle.value.ToString(), LogPrior.Info);
                if (tr != null) tr.Update();
            } catch (Exception ex) {
                Logging.logException("Failed to updateEvent Trader: ", ex);
            }
        }

        #region pluginHandling (api & trader)
        private Trader loadTraderFromDll(string path) {
            try {
                if (!File.Exists(path)) {
                    Logging.log("FileNotFound: " + path, LogPrior.Warning);
                    return null;
                }
                Trader ret = null;
                Assembly assembly = Assembly.Load(System.IO.File.ReadAllBytes(path));

                foreach (Type type in assembly.GetExportedTypes()) {
                    if (type == null || type.BaseType == null) continue;
                    if (type.BaseType.Name == "Trader") {
                        ret = (Trader)Activator.CreateInstance(type);
                        if (ret.Active) {
                            ret.init(kh, candleInter, cm);
                            ret.Live = false;
                            cbTraderLive.Checked = false;
                            return ret;
                        }
                    }
                }

                Logging.log("No active Trader Class found in dll....", LogPrior.Warning);
            } catch (Exception ex) {
                Logging.logException("Failed at load dll: " + path, ex);
            }
            return null;
        }
        private ApiHelp loadApiFromDll(string path) {
            try {
                if (!File.Exists(path)) {
                    Logging.log("FileNotFound: " + path, LogPrior.Warning);
                    return null;
                }
                ApiHelp ret = null;
                Assembly assembly = Assembly.Load(System.IO.File.ReadAllBytes(path));

                foreach (Type type in assembly.GetExportedTypes()) {
                    if (type == null || type.BaseType == null) continue;
                    if (type.BaseType.Name == "ApiHelp") {
                        ret = (ApiHelp)Activator.CreateInstance(type);
                        ret.init();
                        tssApiInfo.Text = ret.Name;
                        return ret;

                    }
                }

                Logging.log("No active Trader Class found in dll....", LogPrior.Warning);
            } catch (Exception ex) {
                Logging.logException("Failed at load dll: " + path, ex);
            }
            return null;
        }
        private void bReloadTrader_Click(object sender, EventArgs e) {
            chartControl.Series.Clear();

            tr = loadTraderFromDll(tbTraderDllFilename.Text);
            refreshTraderStatus();
            if (tr != null) tr.Initiale();

            cm.generateNew();
            cm.CandleList[(int)candleInter].OnNewCandle += new NewCandleEventHandler(OnNewCandleReceived);
            //cm.loadFromFile(@"data\backup.data", false);
        }
        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult dr = MessageBox.Show("Really close?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.No) {
                e.Cancel = true;
            } else {
                cm.saveToFile(Settings.getString(SettKeys.DATA_FILE));
                Settings.save();
            }
            

        }



        private void refreshPortfolio() {


            lCurPortoBTC.Text = kh.Portfolio.btc.ToString(Lib.Const.NUMBER_FORMAT);
            lCurPortoEUR.Text = kh.Portfolio.eur.ToString(Lib.Const.NUMBER_FORMAT);
            if (tr != null) {
                lStartPortoBTC.Text = tr.StartPortfolio.btc.ToString(Lib.Const.NUMBER_FORMAT);
                lStartPortoEUR.Text = tr.StartPortfolio.eur.ToString(Lib.Const.NUMBER_FORMAT);

                lSimPortoBTC.Text = tr.SimulatePortfolio.btc.ToString(Lib.Const.NUMBER_FORMAT);
                lSimPortoEUR.Text = tr.SimulatePortfolio.eur.ToString(Lib.Const.NUMBER_FORMAT);
            }

        }

        private void cbTraderLive_CheckedChanged(object sender, EventArgs e) {
            if (cbTraderLive.Checked) {
                if (tr != null && !tr.Live) {
                    Logging.log("Starting Live Trading!", LogPrior.Info);
                    tr.Live = true;
                } else if (tr == null) {
                    MessageBox.Show("No Trader active, please start!");
                }
            } else {
                if (tr != null && tr.Live) {
                    Logging.log("Stopped Live Trading!", LogPrior.Info);
                    tr.Live = true;
                }
            }
        }
        private void refreshTraderStatus() {
            Color c = Color.Black;
            string text = "";
            if (tr != null && tr.Live) {
                c = Color.Green;
                text = "Live";
            } else if (tr != null && !tr.Live) {
                c = Color.DarkOrange;
                text = "Simulate";
            } else if (tr == null) {
                c = Color.Red;
                text = "Not Initialised";
            }
            lTraderStatus.Text = text;
            lTraderStatus.ForeColor = c;

            if (tr != null) {
                tssTraderInfo.Text = string.Format("Trader: {0} (V: {1})", tr.Name, tr.Version);
                if (!tbTraderStatus.Text.Equals(tr.Status)) tbTraderStatus.Text = tr.Status;
            } else {
                tssTraderInfo.Text = string.Format("Trader: None");
            }
            
        }

        private void tradeItFileToolStripMenuItem_Click(object sender, EventArgs e) {
            string initFolderId = "FILEDIALOG_INIT_DATAFILE";
            string[] files = showFileDialog(initFolderId);
            if (files == null || files.Length <= 0) return;
            foreach (string file in files) {
                cm.loadFromFile(file, true);
            }
        }

        private void bitcoinavaragecomToolStripMenuItem_Click(object sender, EventArgs e) {
            string initFolderId = "FILEDIALOG_INIT_DATAFILE_BITCOINAVARAGE";
            string[] files = showFileDialog(initFolderId);
            if (files == null || files.Length <= 0) return;
            foreach (string file in files) {
                cm.loadFromBitcoinAvarage(file, true);
            }
        }

        private string[] showFileDialog(string initFolderId) {
            string initFolder = Settings.getString(initFolderId);
            if(initFolder.Length > 0 && !Directory.Exists(initFolder)) initFolder = "";
            openFileDialog.InitialDirectory = initFolder;
            DialogResult dr = openFileDialog.ShowDialog();
            if (dr == DialogResult.OK) {
                Settings.set(initFolderId, Path.GetDirectoryName(openFileDialog.FileName));
                return openFileDialog.FileNames;
            }
            return null;
        }

        private void resetDatabaseToolStripMenuItem_Click(object sender, EventArgs e) {
            cm.generateNew();
            chartControl.Series.Clear();
            cm.CandleList[(int)candleInter].OnNewCandle += new NewCandleEventHandler(OnNewCandleReceived);
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e) {
            saveFileDialog.FileName = Settings.getString(SettKeys.DATA_FILE);
            DialogResult dr = saveFileDialog.ShowDialog();
            if (dr == DialogResult.OK) {
                cm.saveToFile(saveFileDialog.FileName);
            }
        }

        #region proginfo
        private DateTime RetrieveLinkerTimestamp() {
            string filePath = System.Reflection.Assembly.GetCallingAssembly().Location;
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;
            byte[] b = new byte[2048];
            System.IO.Stream s = null;

            try {
                s = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                s.Read(b, 0, 2048);
            } finally {
                if (s != null) {
                    s.Close();
                }
            }

            int i = System.BitConverter.ToInt32(b, c_PeHeaderOffset);
            int secondsSince1970 = System.BitConverter.ToInt32(b, i + c_LinkerTimestampOffset);
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            dt = dt.AddSeconds(secondsSince1970);
            dt = dt.ToLocalTime();
            return dt;
        }
        private void refreshMemoryStats() {
            long memory;
            Process thisproc;
            thisproc = Process.GetCurrentProcess();
            memory = thisproc.PrivateMemorySize64;
            lHelpMemoryUsed.Text = Lib.Tools.formatSpace(memory);
        }
        #endregion

        private void FilenameTextBoxMouseDoubleClick(object sender, MouseEventArgs e) {
            if (sender is TextBox) {
                TextBox tb = (TextBox)sender;
                openFileDialog.FileName = Path.GetFileName(tb.Text);
                try {
                    openFileDialog.InitialDirectory = Path.GetDirectoryName(tb.Text);
                } catch {

                }
                DialogResult dr = openFileDialog.ShowDialog();
                if (dr == DialogResult.OK) {
                    tb.Text = openFileDialog.FileName;
                }
            }
        }

        private void chartControl_MouseMove(object sender, MouseEventArgs e) {
            try {
                chartcont.ChartAreas[0].CursorX.SetCursorPixelPosition(new Point(e.X, e.Y), false);
                chartcont.ChartAreas[0].CursorY.SetCursorPixelPosition(new Point(e.X, e.Y), false);

                double xValue = chartcont.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
                double yValue = chartcont.ChartAreas[0].AxisY.PixelPositionToValue(e.Y);

                double pX = chartcont.ChartAreas[0].CursorX.Position; //X Axis Coordinate of your mouse cursor
                double pY = chartcont.ChartAreas[0].CursorY.Position; //Y Axis Coordinate of your mouse cursor

                DateTime dt = DateTime.FromOADate(xValue);
                lChartPosition.Text = string.Format("{0:dd.MM HH:mm} / {1}", dt, pY);
            } catch (Exception ex) {
                Logging.logException("chart error", ex);
            }
        }

        private void bApiLoad_Click(object sender, EventArgs e) {
            kh = loadApiFromDll(tbApiDllPath.Text);
        }


        private void changeCandleIntervall(CandleInterval newintervall) {
            if (newintervall == candleInter) return;
            cm.CandleList[(int)candleInter].OnNewCandle -= new NewCandleEventHandler(OnNewCandleReceived);
            candleInter = newintervall;
            if (tr != null) tr.init(kh, candleInter, cm);
            cm.CandleList[(int)candleInter].OnNewCandle += new NewCandleEventHandler(OnNewCandleReceived);
            Settings.set(SettKeys.CANDLE_INTERVALL, (int)candleInter);
        }

        private void cbCandleIntervall_SelectedIndexChanged(object sender, EventArgs e) {
            changeCandleIntervall((CandleInterval)cbCandleIntervall.SelectedItem);
        }

        private void nudMaxChartPoints_ValueChanged(object sender, EventArgs e) {
            if (tr != null) {
                tr.MaxChartPoints = (int)nudMaxChartPoints.Value;
            } 
            Settings.set(SettKeys.MAX_CHART_POINTS, (int)nudMaxChartPoints.Value);
        }

        private void dgvDetailSettings_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            Settings.fromTable(dgvDetailSettings);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {
            if (tabControl1.SelectedTab == tabDetailSettings) {
                dgvDetailSettings.DataSource = Settings.getDataTable();
            }
        }
        private void saveTextBox(TextBox tb) {
            Settings.set(Lib.Const.IDS.TEXTBOX + tb.Name, tb.Text);
        }

        private void textbox_TextChanged(object sender, EventArgs e) {
            if (disableEvents) return;
            if (sender != null && sender is TextBox) {
                saveTextBox((TextBox)sender);
            }
        }

        private void tbSetSimPorto_Click(object sender, EventArgs e) {
            if (tr != null) {
                ApiPortfolio sim = new ApiPortfolio();
                sim.btc = Lib.Converter.toDecimal(tbSimPortoBTC.Text);
                sim.eur = Lib.Converter.toDecimal(tbSimPortoEUR.Text);
                tr.SimulatePortfolio = sim;
                refreshPortfolio();
            }
            
        }
    }
}
