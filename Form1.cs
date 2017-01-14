// Feel free to re-use concepts and actual code from this project, attribution if you make something similiar from these here bones is all I ask

// Robert Marshall - 2016 - Enterprise Mobility MVP

// A fully compiled (release profile) version of the tool can be obtained from the TechNet Gallery - https://gallery.technet.microsoft.com/LogLauncher-61ba5c99

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.ServiceProcess;

namespace LogLauncher
{
    public partial class Form1 : Form
    {
        private const string c_productVersion = "V2.2 - Robert Marshall";

        public static readonly string[] c_colourWheel = {"FF2D3AF7", "FF3E4AF7", "FF4F5AF7", "FF606BF7", "FF7C84F7", "FF9299F7", "FFC6C9F7", "FFDFE0F7", "FFE6E7F5"};

        private static readonly List<string> c_Sayings = new List<string>()
        {
            "A log a day helps with rest, work and play",
            "All logs and no play makes Jack a dull admin",
            "All play and no log reading makes Jack work overtime",
            "Red and Yellow make a real admins belly turn",
            "Looking at logs can be considered a sport",
            "I'm sorry Dave, I'm afraid I can't do that",
            "Of all the gin joints in all the towns in all the world, the logs walks into mine.",
            "A log walks into a bar, asks for an Error with a good head, and a few shots of Warning",
            "Here to kick log and chew bubblegum, and I'm all out of gum",
            "50 years from now, when you're looking back at your life, don't you want to be able to say you had the guts to look at a log?",
            "Conan on life: To crush your enemies, to see their logs driven before you, and to hear the lamentations of their admins",
            "The scientists of today think deeply instead of clearly. One must be sane to think clearly, but one can think deeply and be quite insane - Tesla.",
            "The harness of waterfalls is the most economical method known for drawing energy from the sun - Tesla",
            "The ear is the avenue to the heart - Voltaire",
            "No problem can withstand the assault of sustained thinking - Voltaire",
            "The single biggest problem in communication is the illusion that it has taken place - Shaw",
            "No question is so difficult to answer as that to which the answer is obvious - Shaw",
            "Success does not consist in never making mistakes but in never making the same one a second time - Shaw",
            "He who does not understand your silence will probably not understand your words, or your logs - Elbert Hubbard",
            "One machine can do the work of fifty ordinary men. No machine can do the work of one extraordinary man - Elbert Hubbard",
            "Any sufficiently advanced technology is indistinguishable from magic - Arthur C. Clarke",
            "We are in an electronic technology age now and it's about time we put away the old stuff - Monica Edwards",
            "A new broom sweeps clean but an old broom knows the corners.",
            "Common sense is genius dressed in its working clothes - Ralph Waldo Emerson",
            "Give a man a fish and you feed him for a day; teach a man to fish and he'll eat forever.",
            "Just because something is common sense doesn't mean it's common practice",
            "When in Rome, do as the Romans",
            "The squeaky wheel gets the grease",
            "The pen is mightier than the sword",
            "Two wrongs don't make a right",
            "When the going gets tough, the tough get going",
            "No man is an island",
            "Fortune favors the bold",
            "People who live in glass houses should not throw stones",
            "Hope for the best, but prepare for the worst",
            "Better late than never",
            "Birds of a feather flock together",
            "Keep your friends close and your enemies closer",
            "A picture is worth a thousand words",
            "There's no such thing as a free lunch",
            "There's no place like home",
            "Discretion is the greater part of valor",
            "The early bird catches the worm",
            "Never look a gift horse in the mouth",
            "You can't make an omelet without breaking a few eggs",
            "You can't always get what you want",
            "A watched pot never boils",
            "Beggars can't be choosers",
            "Actions speak louder than words",
            "If it ain't broke, don't fix it",
            "Practice makes perfect",
            "Too many cooks spoil the broth",
            "Easy come, easy go",
            "Don't bite the hand that feeds you",
            "All good things must come to an end",
            "If you can't beat 'em, join 'em",
            "One man's trash is another man's treasure",
            "There's no time like the present",
            "Beauty is in the eye of the beholder",
            "Necessity is the mother of invention",
            "A penny saved is a penny earned",
            "Familiarity breeds contempt",
            "You can't judge a book by its cover",
            "Good things come to those who wait",
            "Don't put all your eggs in one basket",
            "Two heads are better than one",
            "The grass is always greener on the other side of the hill",
            "Do unto others as you would have them do unto you",
            "A chain is only as strong as its weakest link",
            "Honesty is the best policy",
            "Absence makes the heart grow fonder",
            "You can lead a horse to water, but you can't make him drink",
            "Don't count your chickens before they hatch",
            "If you want something done right, you have to do it yourself",
            "A broken clock is right twice a day"
        };

        private logitemCollection thelogitemCollection = new logitemCollection();

        private string cmtracePath = null;

        private bool disabletreeView = false;        

        private bool switches_monitorLogs = false;

        public bool switches_threadRunning = false;

        public bool switches_logging_threadRunning = false;

        private bool switches_hide_archiveLogs = false;
        private bool switches_open_multipleLogs = true;

        private const string c_archiveLog = "Archive Log";
        private const string c_activeLog = "Active Log";

        private const string c_activelog_Extension = ".log";

        private const string c_archivelog_Extension = ".lo_";

        private const string c_Notification = "Notification";
        private const string c_Diagnostic = "Diagnostic";

        private List<string> logpathHistory = new List<string>();

        private int throttleDelay = 0;

        private bool switches_scan_threadRunning = false;

        private Color gradientcolourStart = new Color();
        private Color gradientcolourEnd = new Color();

        private bool siteserverDetected = false;

        private bool clientDetected = false;

        private List<Color> colourList = new List<Color>();

        public class servicecycleMessage
        {
            public string remoteServer { get; set; }
            public string serviceName { get; set; }
        }

        public class loggingMessage
        {
            public string messageType { get; set; }
            public string messageText { get; set; }
        }

        public class reportSuffixUpdatedRows
        {
            public string suffixText { get; set; }
            public logitemCollection updatedRows { get; set; }
        }

        public class messageObject
        {
            public string logType { get; set; }
            public string logMessage { get; set; }            
        }

        public class controlConfig
        {
            public string remoteServer { get; set; }
            public string pathAppend { get; set; }
            public string pathFilter { get; set; }
            public bool recurseDirectory { get; set; }
            public string fileMask { get; set; }
            public bool disregardduplicatePath{ get; set; }
           public string fileextensionOverride { get; set; }
            public string logClass { get; set; }
            public string logProduct { get; set; }
        }

        public class custombladeConfig
        {
            public string logPath { get; set; }
        }

        public class registrybladeConfig
        {
            public string registryHive { get; set; }
            public string registryvalidationPath { get; set; }
            public string registryvalidationkey { get; set; }
            public string registryPath { get; set; }
            public string registryValue { get; set; }            
        }

        public class xmlbladeConfig
        {
            public string configfilePath { get; set; }
            public string searchPattern { get; set; }
            public string searchProperty{ get; set; }
            public bool searchcaseSensitive { get; set; }
        }

        public class combinedConfig
        {
            public object abladeConfig { get; set; }
            public controlConfig acontrolConfig { get; set; }            
        }

        public class combinedconfigCollection : System.Collections.CollectionBase
        {
            public void Add(combinedConfig acombinedConfig)
            {
                List.Add(acombinedConfig);
            }

            public void RemoveAll()
            {
                for (int i = 0; i <= List.Count; i++)
                {
                    List.RemoveAt(i);
                }
            }

            public void Remove(int index)
            {
                if (index > Count - 1 || index < 0)
                {
                }
                else
                {
                    List.RemoveAt(index);
                }
            }

            public combinedConfig Item(int Index)
            {
                return (combinedConfig)List[Index];
            }
        }


        public class loggingItem
        {
            public string componentName{ get; set; }
            public bool debugLogging { get; set; }
            public bool Enabled { get; set; }
            public int loggingLevel { get; set; }
            public int logmaxHistory { get; set; }
            public int maxfileSize { get; set; }            
        }

        public class loggingitemCollection : System.Collections.CollectionBase
        {
            public void Add(loggingItem aloggingItem)
            {
                List.Add(aloggingItem);
            }

            public void RemoveAll()
            {
                for (int i = 0; i <= List.Count; i++)
                {
                    List.RemoveAt(i);
                }
            }

            public void Remove(int index)
            {
                if (index > Count - 1 || index < 0)
                {
                }
                else
                {
                    List.RemoveAt(index);
                }
            }

            public loggingItem Item(int Index)
            {
                return (loggingItem)List[Index];
            }
        }        

        public class logItem
        {
            public string logProduct { get; set; }
            public string fulllogName{ get; set; }
            public string logClass { get; set; } 
            public string LogName { get; set; } 
            public string logType { get; set; }
            public string logLocation { get; set; }
            public long logSize { get; set; } 
            public DateTime loglastModified { get; set; }
        }

        public class logitemCollection : System.Collections.CollectionBase
        {
            public void Add(logItem alogItem)
            {
                List.Add(alogItem);
            }

            public void RemoveAll()
            {
                for (int i = 0; i <= List.Count; i++)
                {
                    List.RemoveAt(i);
                }
            }

            public void Remove(int index)
            {
                if (index > Count - 1 || index < 0)
                {
                }
                else
                {
                    List.RemoveAt(index);
                }
            }

            public logItem Item(int Index)
            {
                return (logItem)List[Index];
            }
        }

        private void dispatchMessage(string theType, string theMessage, object sender)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            messageObject amessageObject = new messageObject();

            amessageObject.logType = theType;

            amessageObject.logMessage = theMessage;                       

            worker.ReportProgress(0, amessageObject);
        }

        private void notificationMessage(string theMessage)
        {
            toolStripStatusLabel1.Text = theMessage;

            statusStrip1.Refresh();
        }

        private void diagnosticMessage(string theMessage)
        {
            try
            {
                DataGridViewRow newRow = (DataGridViewRow)dgv_Diagnostics.Rows[0].Clone(); // Stack overflow happened here

                newRow.Cells[0].Value = theMessage;

                dgv_Diagnostics.Rows.Add(newRow);
            }
            catch (Exception ee) // Handle this being the first row in the DGV
            {
                // Create a row so we can clone it then alter its properties, before clearing the rows and adding it again (we get the row with correct columns)

                try
                {
                    dgv_Diagnostics.Rows.Add(theMessage);

                    DataGridViewRow newRow = (DataGridViewRow)dgv_Diagnostics.Rows[0].Clone();

                    dgv_Diagnostics.Rows.Clear();

                    newRow.Cells[0].Value = theMessage;

                    dgv_Diagnostics.Rows.Add(newRow);
                }
                catch (Exception eee)
                {

                }
            }
        }

        private void getcommandlineParameters()
        {
            // If a parameter is specified, treat it as if it is a server name

            string[] theArguments = Environment.GetCommandLineArgs();            

            foreach (string anArgument in theArguments)
            {
                Console.WriteLine("Argument: " + anArgument);

                if (!anArgument.Contains(".exe"))
                {
                    cb_remoteServer.Text = anArgument;
                }
            }
        }

        private void getloglauncherSettings()
        {
            try
            {
                if (!regkeyExist("", "HKEY_LOCAL_MACHINE", @"Software\SMSMarshall"))
                {
                    RegistryKey companyReg = Registry.LocalMachine.OpenSubKey("Software", true);

                    companyReg.CreateSubKey("SMSMarshall");
                }

                if (!regkeyExist("", "HKEY_LOCAL_MACHINE", @"Software\SMSMarshall\LogLauncher"))
                {
                    RegistryKey logLauncherKey = Registry.LocalMachine.OpenSubKey(@"Software\SMSMarshall", true);

                    logLauncherKey.CreateSubKey("LogLauncher");
                }
            }
            catch (Exception)
            {

            }

            try
            {
                if (!regkeyExist("", "HKEY_CURRENT_USER", @"Software\SMSMarshall"))
                {
                    RegistryKey companyReg = Registry.CurrentUser.OpenSubKey("Software", true);

                    companyReg.CreateSubKey("SMSMarshall");
                }

                if (!regkeyExist("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher"))
                {
                    RegistryKey logLauncherKey = Registry.CurrentUser.OpenSubKey(@"Software\SMSMarshall", true);

                    logLauncherKey.CreateSubKey("LogLauncher");
                }
            }
            catch (Exception ee)
            {
                diagnosticMessage("Could not create the LogLauncher registry keys to store your preferences");
            }

            // Recent servers list

            try
            {
                if (regkeyvalueExist("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "RecentServers"))
                {
                    string[] recentServers = (string[])getregkeyValue("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher","RecentServers");

                    try
                    {
                        cb_remoteServer.Items.Clear();

                        foreach (string recentServer in recentServers)
                        {
                            cb_remoteServer.Items.Add(recentServer);
                        }

                        cb_remoteServer.SelectedIndex = cb_remoteServer.Items.Count -1;

                        cb_remoteServer.Refresh();
                    }

                    catch (Exception ee)
                    {

                    }
                    
                                     
                }
            }
            catch (Exception ee)
            {

            }

            // Monitoring Timer Duration

            try
            {                
                if (regkeyvalueExist("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "MonitoringTimerDuration"))
                {
                    nup_Delay.Value = Convert.ToInt16(getregkeyValue("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "MonitoringTimerDuration"));
                }
                else
                {
                    nup_Delay.Value = 5;

                    updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"),"MonitoringTimerDuration", "5");
                }
            }
            catch (Exception ee)
            {

            }

            // Gradient Start Colour

            try
            {
                if (regkeyvalueExist("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "GradientStartColour"))
                {
                    pb_colourpickerStart.BackColor = Color.FromArgb(Convert.ToInt32(getregkeyValue("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "GradientStartColour")));
                }
                else
                {                    
                    pb_colourpickerStart.BackColor = Color.FromArgb(Convert.ToInt32("ff1dacf1", 16));                    

                    updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"),"GradientStartColour", pb_colourpickerStart.BackColor.ToArgb().ToString());
                }
            }
            catch (Exception ee)
            {

            }

            // Gradient End Colour

            try
            {
                if (regkeyvalueExist("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "GradientEndColour"))
                {
                    pb_colourpickerEnd.BackColor = Color.FromArgb(Convert.ToInt32(getregkeyValue("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "GradientEndColour")));                    
                }
                else
                {
                    pb_colourpickerEnd.BackColor = Color.FromArgb(Convert.ToInt32("ffeeffff", 16));

                    updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"),"GradientEndColour", pb_colourpickerEnd.BackColor.ToArgb().ToString());
                }
            }
            catch (Exception ee)
            {

            }

            // Multiple Logs Single CMTrace

            try
            {
                if (regkeyvalueExist("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "MultipleLogsSingleCMTrace"))
                {
                    cb_openLogsMulti.Checked = Convert.ToBoolean(getregkeyValue("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "MultipleLogsSingleCMTrace"));
                }
                else
                {
                    cb_openLogsMulti.Checked = true;

                    updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"),"MultipleLogsSingleCMTrace", cb_openLogsMulti.Checked.ToString());
                }
            }
            catch (Exception ee)
            {

            }

            // Hide Archive Logs

            try
            {
                if (regkeyvalueExist("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "HideArchiveLogs"))
                {
                    cb_hidearchiveLogs.Checked = Convert.ToBoolean(getregkeyValue("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "HideArchiveLogs"));
                }
                else
                {
                    cb_hidearchiveLogs.Checked = true;

                    updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"),"HideArchiveLogs", cb_hidearchiveLogs.Checked.ToString());
                }
            }
            catch (Exception ee)
            {

            }
        }

        private void updateloglauncherSettings(RegistryHive regHive, string regvalueName, string regvalueValue)
        {
            if (regHive == RegistryHive.LocalMachine)
            {
                try
                {
                    RegistryKey aregKey = Registry.LocalMachine.OpenSubKey(@"Software\SMSMarshall\LogLauncher", true);

                    aregKey.SetValue(regvalueName, regvalueValue);
                }
                catch (Exception ee)
                {
                    diagnosticMessage("Could not create preferences registry key value " + regvalueName + " - " + ee.Message);
                }
            }
            else
            {
                try
                {
                    RegistryKey aregKey = Registry.CurrentUser.OpenSubKey(@"Software\SMSMarshall\LogLauncher", true);

                    aregKey.SetValue(regvalueName, regvalueValue);
                }
                catch (Exception ee)
                {
                    diagnosticMessage("Could not create preferences registry key value " + regvalueName + " - " + ee.Message);
                }
            }          
        }

        private bool regkeyvalueExist(string remoteServer, string regClass, string regKey, string regValue)
        {
            try
            {
                RegistryKey remoteHK = RegistryKey.OpenRemoteBaseKey(returnregistryHive(regClass), remoteServer);

                remoteHK = remoteHK.OpenSubKey(regKey);

                Object regResult = remoteHK.GetValue(regValue);

                remoteHK.Close();

                if (regResult == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ee)
            {
                return false;
            }
 
            return false;

        }

        private bool regkeyExist(string remoteServer, string regClass, string regKey)
        {
            try
            {
                string regPath = regKey.Substring(regKey.LastIndexOf(@"\") + 1, (regKey.Length) - regKey.LastIndexOf(@"\") - 1);

                string regName = regKey.Substring(0, regKey.LastIndexOf(@"\"));

                RegistryKey remoteHK = RegistryKey.OpenRemoteBaseKey(returnregistryHive(regClass), remoteServer);

                remoteHK = remoteHK.OpenSubKey(regKey);

                if (remoteHK == null)
                {
                    return false;
                }
                else
                {
                    remoteHK.Close();

                    return true;
                }
            }
            catch (Exception ee)
            {
                return false;
            }

            return false;
        }

        private void dgvAdd(string logProduct, string fulllogName, string logClass, string cleanedlogName, string cmagentlogLocation, string logType, long logfileSize, DateTime loglastModified, bool isVisible)
        {
            try
            {
                DataGridViewRow newRow = (DataGridViewRow)dgv_Logs.Rows[0].Clone();

                newRow.Cells[0].Value = fulllogName;
                newRow.Cells[1].Value = cleanedlogName;
                newRow.Cells[2].Value = logClass;
                newRow.Cells[3].Value = logType;
                newRow.Cells[4].Value = logfileSize;
                newRow.Cells[5].Value = logfileSize / 1024 / 1024;
                newRow.Cells[6].Value = loglastModified;

                string cleanedlogLocation = fulllogName.Substring(0, fulllogName.LastIndexOf(@"\"));

                newRow.Cells[7].Value = cleanedlogLocation;

                newRow.Cells[8].Value = logProduct;

                newRow.Visible = true;

                dgv_Logs.Rows.Add(newRow);
            }
            catch (Exception ee) // Handle this being the first row in the DGV
            {
                // Create a row so we can clone it then alter its properties, before clearing the rows and adding it again

                dgv_Logs.Rows.Add(fulllogName, logClass, cleanedlogName, cmagentlogLocation, logType, logfileSize, logfileSize / 1024 / 1024, loglastModified);

                DataGridViewRow newRow = (DataGridViewRow)dgv_Logs.Rows[0].Clone();

                dgv_Logs.Rows.Clear();

                newRow.Cells[0].Value = fulllogName;
                newRow.Cells[1].Value = cleanedlogName;
                newRow.Cells[2].Value = logClass;
                newRow.Cells[3].Value = logType;
                newRow.Cells[4].Value = logfileSize;
                newRow.Cells[5].Value = logfileSize / 1024 / 1024;
                newRow.Cells[6].Value = loglastModified;

                string cleanedlogLocation = fulllogName.Substring(0, fulllogName.LastIndexOf(@"\"));

                newRow.Cells[7].Value = cleanedlogLocation;
                newRow.Cells[8].Value = logProduct;

                if (isVisible)
                {
                    newRow.Visible = true;
                }
                else
                {
                    newRow.Visible = false;
                }

                dgv_Logs.Rows.Add(newRow);
            }
        }


        private string getcmtraceregkeyValue()
        {
            try
            {
                List<string> traceSources = new List<string>();

                RegistryKey hkcuV1 = RegistryKey.OpenRemoteBaseKey(RegistryHive.CurrentUser, System.Environment.MachineName);

                diagnosticMessage("Locating CMTrace");

                RegistryKey hkcuV2 = RegistryKey.OpenRemoteBaseKey(RegistryHive.CurrentUser, System.Environment.MachineName);

                if (hkcuV2 != null)
                {
                    hkcuV2 = hkcuV2.OpenSubKey(@"SOFTWARE\Classes\Log.File\shell\open\command");

                    string cmtraceunformattedPath = hkcuV2.GetValue(null).ToString(); // Get the default value                    

                    string cmtraceformattedPath = cmtraceunformattedPath.Replace("%1", "").Replace((char)34, (char)32).Trim();

                    if ((cmtraceformattedPath != null) && (cmtraceformattedPath.ToLower().Contains("cmtrace.exe")))
                    {
                        traceSources.Add(cmtraceformattedPath.ToLower());

                        diagnosticMessage(" CMTrace location found: " + cmtraceunformattedPath);
                    }
                }

                if (traceSources.Count != 0) // Find the first CMtrace.exe file that exists and return it
                {
                    foreach (string foundcmtracePath in traceSources)
                    {
                        if (File.Exists(foundcmtracePath))
                        {
                            return foundcmtracePath;
                        }
                    }
                } 
                else
                {
                    diagnosticMessage(" CMTrace binary not found");
                }            
            }
            catch (Exception ee)
            {
                diagnosticMessage(" Error looking for CMTrace - " + ee.Message);
            }

            diagnosticMessage(" CMTrace not found");

            return null;
        }

        private string[] getregkeyValues(string remoteServer, string regClass, string regPath)
        {
            try
            {
                RegistryKey hk = RegistryKey.OpenRemoteBaseKey(returnregistryHive(regClass), remoteServer);

                if (hk != null)
                {
                    hk = hk.OpenSubKey(regPath);

                    if (hk != null)
                    {
                        string[] regResult = hk.GetValueNames();

                        if (regResult != null)
                        {
                            return regResult;
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                return null;
            }

            return null;
        }

        private bool setregkeyValues(string remoteServer, string regClass, string regPath, string regValue, string[] regValues)
        {
            try
            {
                RegistryKey hk = RegistryKey.OpenRemoteBaseKey(returnregistryHive(regClass), remoteServer);

                if (hk != null)
                {
                    hk = hk.OpenSubKey(regPath, true);

                    if (hk != null)
                    {
                        hk.SetValue(regValue, regValues, RegistryValueKind.MultiString);
                    }
                }
            }
            catch (Exception ee)
            {
                return false;
            }

            return true;
        }


        private RegistryHive returnregistryHive(string registryClass)
        {
            if (registryClass == "HKEY_LOCAL_MACHINE")
            {
                return RegistryHive.LocalMachine;
            }

            if (registryClass == "HKEY_CURRENT_USER")
            {
                return RegistryHive.CurrentUser;
            }

            return RegistryHive.LocalMachine; // Fallback to HKLM 
        }

        private object getregkeyValue(string remoteServer, string regClass, string regPath, string regKey)
        {
            try
            {
                RegistryKey hk = RegistryKey.OpenRemoteBaseKey(returnregistryHive(regClass), remoteServer);

                if (hk != null)
                {
                    hk = hk.OpenSubKey(regPath);

                    if (hk != null)
                    {
                        Object regResult = hk.GetValue(regKey);

                        if (regResult != null)
                        {
                            return regResult;
                        }
                    }
                }
            }
            catch (Exception ee)
            {

            }

            return null;
        }

        private logitemCollection refreshlogsinView(logitemCollection thelogItems)
        {
            try
            {
                foreach (logItem alogItem in thelogItems)
                {
                    FileInfo thelogFile = new System.IO.FileInfo(alogItem.fulllogName);                        

                    if (alogItem.loglastModified.ToString() != thelogFile.LastWriteTime.ToString())
                    {
                        alogItem.logSize = thelogFile.Length;

                        alogItem.loglastModified = thelogFile.LastWriteTime;
                    }
                }
            }
            catch (Exception ee)
            {

            }

            return thelogItems;
        }

        private logitemCollection fetchLogs(combinedconfigCollection acombinedconfigCollection, logitemCollection existinglogitemCollection, object sender)
        {            
            try
            {
                foreach (combinedConfig acombinedConfig in acombinedconfigCollection)
                {
                    try
                    {
                        List<string> fetchedlogLocations = new List<string>();

                        controlConfig acontrolConfig = new controlConfig();

                        xmlbladeConfig axmlbladeConfig = new xmlbladeConfig();

                        registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                        if (acombinedConfig.acontrolConfig is controlConfig) // Handle the Control blade
                        {
                            acontrolConfig = (controlConfig)acombinedConfig.acontrolConfig;
                        }

                        if (acombinedConfig.abladeConfig is xmlbladeConfig) // Handle the XML Blade - Note that I don't deal with XML in an orthodox way, I do it Conan style, brute force using pattern matching
                        {
                            axmlbladeConfig = (xmlbladeConfig)acombinedConfig.abladeConfig;
                            
                            object systembootDrive = getregkeyValue(acontrolConfig.remoteServer, "HKEY_LOCAL_MACHINE", @"Software\Microsoft\Windows\CurrentVersion\Setup", "BootDir");

                            var configfileContent = File.ReadLines(axmlbladeConfig.configfilePath);

                            foreach (string currentLine in configfileContent)
                            {
                                bool triggerScan = false; // Our trigger for determining if we have to look for the property

                                if (axmlbladeConfig.searchcaseSensitive)
                                {
                                    if (currentLine.Contains(axmlbladeConfig.searchPattern))
                                        triggerScan = true;
                                }
                                else
                                {
                                    if (currentLine.ToLower().Contains(axmlbladeConfig.searchPattern.ToLower()))
                                        triggerScan = true;
                                }

                                if (triggerScan)
                                {
                                    triggerScan = false; // Reset so we can have another go

                                    if (axmlbladeConfig.searchcaseSensitive)
                                    {
                                        if (currentLine.Contains(axmlbladeConfig.searchPattern))
                                            triggerScan = true;
                                    }
                                    else
                                    {
                                        if (currentLine.ToLower().Contains(axmlbladeConfig.searchProperty.ToLower()))
                                            triggerScan = true;
                                    }

                                    if (triggerScan)
                                    {
                                        // We've got a property match

                                        string iislogfilePath = "";

                                        int findProperty = currentLine.IndexOf(axmlbladeConfig.searchProperty) + axmlbladeConfig.searchProperty.Length + 1; // +2 gets rid of the =" string                                

                                        string cut1 = currentLine.Substring(findProperty, currentLine.Length - findProperty);

                                        for (int i = 0; i < cut1.Length; i++)
                                        {
                                            if (cut1.Substring(i, 1) == ((char)34).ToString())
                                            {
                                                iislogfilePath = cut1.Substring(0, i);

                                                break;
                                            }
                                        }

                                        iislogfilePath = iislogfilePath.ToLower().Replace(@"%systemdrive%\", systembootDrive.ToString());

                                        if (iislogfilePath != "" || iislogfilePath != null)
                                        {
                                            if (!fetchedlogLocations.Contains(iislogfilePath))
                                            {
                                                if (acontrolConfig.remoteServer != "") // Convert to UNC
                                                {
                                                    if (!fetchedlogLocations.Contains(@"\\" + acontrolConfig.remoteServer + @"\" + iislogfilePath.Substring(0, 1) + @"$\" + iislogfilePath.Substring(3, iislogfilePath.Length - 3)))
                                                    {
                                                        fetchedlogLocations.Add(@"\\" + acontrolConfig.remoteServer + @"\" + iislogfilePath.Substring(0, 1) + @"$\" + iislogfilePath.Substring(3, iislogfilePath.Length - 3)); // ????
                                                    }
                                                }
                                                else
                                                {
                                                    fetchedlogLocations.Add(iislogfilePath);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        } // Epic nesting!

                        if (acombinedConfig.abladeConfig is custombladeConfig) // Handle the custom Blade
                        {
                            custombladeConfig acustombladeConfig = (custombladeConfig)acombinedConfig.abladeConfig;

                            if (acontrolConfig.remoteServer != "") // Convert to UNC
                            {
                                if (acustombladeConfig.logPath != "" || acustombladeConfig.logPath != null)
                                {
                                    fetchedlogLocations.Add(@"\\" + acontrolConfig.remoteServer + @"\" + acustombladeConfig.logPath.Substring(0, 1) + @"$\" + acustombladeConfig.logPath.Substring(3, acustombladeConfig.logPath.Length - 3)); // ????
                                }
                            }
                            else
                            {                                
                                fetchedlogLocations.Add(acustombladeConfig.logPath);
                            }
                        }

                        if (acombinedConfig.abladeConfig is registrybladeConfig) // Handle the Registry Blade
                        {
                            aregistrybladeConfig = (registrybladeConfig)acombinedConfig.abladeConfig;

                            if (regkeyExist(acontrolConfig.remoteServer, aregistrybladeConfig.registryHive, aregistrybladeConfig.registryvalidationPath))
                            {
                                if (regkeyvalueExist(acontrolConfig.remoteServer, aregistrybladeConfig.registryHive, aregistrybladeConfig.registryPath, aregistrybladeConfig.registryValue))
                                {
                                    string afetchedlogLocation = getregkeyValue(acontrolConfig.remoteServer, aregistrybladeConfig.registryHive, aregistrybladeConfig.registryPath, aregistrybladeConfig.registryValue).ToString();

                                    if (acontrolConfig.remoteServer != "") // Convert to UNC
                                    {
                                        if (afetchedlogLocation != "" || afetchedlogLocation != null)
                                        {
                                            fetchedlogLocations.Add(@"\\" + acontrolConfig.remoteServer + @"\" + afetchedlogLocation.Substring(0, 1) + @"$\" + afetchedlogLocation.Substring(3, afetchedlogLocation.Length - 3)); // ????
                                        }
                                    }
                                    else
                                    {
                                        fetchedlogLocations.Add(afetchedlogLocation);
                                    }
                                }
                            }
                        }

                        foreach (string fetchedloglocationValue in fetchedlogLocations)
                        {
                            string fetchedlogLocation = fetchedloglocationValue;

                            if (acontrolConfig.logClass.ToString().ToLower().EndsWith("logs"))
                            {
                                dispatchMessage(c_Notification, "Fetching " + acontrolConfig.logClass + " for product " + acontrolConfig.logProduct, sender);
                            }
                            else
                            {
                                dispatchMessage(c_Notification, "Fetching " + acontrolConfig.logClass + " logs for product " + acontrolConfig.logProduct, sender);
                            }                          

                            // Apply functions defined in Control

                            if (acontrolConfig.pathFilter != "")
                            {
                                fetchedlogLocation = fetchedlogLocation.ToLower().Replace(acontrolConfig.pathFilter.ToLower(), "");
                            }

                            if (fetchedlogLocation.EndsWith(@"\"))
                            {
                                fetchedlogLocation = fetchedlogLocation.Substring(0, fetchedlogLocation.Length - 1);
                            }

                            if (acontrolConfig.pathAppend != "")
                            {
                                fetchedlogLocation = Path.Combine(fetchedlogLocation, acontrolConfig.pathAppend);
                            }

                            if (!logpathHistory.Contains(fetchedlogLocation.ToLower()) || acontrolConfig.disregardduplicatePath)
                            {
                                logpathHistory.Add(fetchedlogLocation.ToLower());

                                var searchOptions = new SearchOption();

                                if (acontrolConfig.recurseDirectory)
                                {
                                    searchOptions = SearchOption.AllDirectories;
                                }
                                else
                                {
                                    searchOptions = SearchOption.TopDirectoryOnly;
                                }

                                //

                                if (fetchedlogLocation != null && fetchedlogLocation != "") // If we have a Directory, proceed
                                {
                                    try
                                    {
                                        // Retrieve the logs

                                        foreach (string fulllogName in Directory.EnumerateFiles(fetchedlogLocation, acontrolConfig.fileMask, searchOptions))
                                        {
                                            FileInfo thelogFile = new System.IO.FileInfo(fulllogName);

                                            var logfileSize = thelogFile.Length;

                                            DateTime loglastModified = thelogFile.LastWriteTime;

                                            string logtypeFilter = "";

                                            if (!fulllogName.EndsWith("_"))
                                            {
                                                logtypeFilter = c_activelog_Extension;
                                            }
                                            else
                                            {
                                                logtypeFilter = c_archivelog_Extension; // This should only apply to CM logs, as they use the .lo_ format for archive logs
                                            }

                                            string cleanedlogName = fulllogName.ToLower().Replace(logtypeFilter.ToLower(), "").Replace(fetchedlogLocation.ToLower() + @"\", "");

                                            cleanedlogName = cleanedlogName.Substring(cleanedlogName.LastIndexOf(@"\") + 1, cleanedlogName.Length - cleanedlogName.LastIndexOf(@"\") - 1);

                                            logItem newlogItem = new logItem();

                                            newlogItem.logProduct = acontrolConfig.logProduct;
                                            newlogItem.fulllogName = fulllogName;
                                            newlogItem.logClass = acontrolConfig.logClass;
                                            newlogItem.LogName = cleanedlogName;
                                            newlogItem.logLocation = fetchedlogLocation;

                                            if (logtypeFilter == c_activelog_Extension)
                                            {
                                                newlogItem.logType = c_activeLog;
                                            }
                                            else
                                            {
                                                newlogItem.logType = c_archiveLog;
                                            }

                                            newlogItem.logSize = logfileSize;
                                            newlogItem.loglastModified = loglastModified;

                                            existinglogitemCollection.Add(newlogItem);
                                        }
                                    }
                                    catch (Exception ee)
                                    {
                                        dispatchMessage(c_Diagnostic, ee.Message, sender);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ee)
                    {
                        dispatchMessage(c_Diagnostic, ee.Message, sender);
                    }
                }
            }
            catch (Exception ee)
            {
                dispatchMessage(c_Diagnostic, ee.Message, sender);
            }

            return existinglogitemCollection;
        }


        private logitemCollection logDiscovery(string remoteServer, object sender)
        {
            logitemCollection alogitemCollection = new logitemCollection();

            logpathHistory.Clear();

            // Prepare the collections

            combinedconfigCollection acombinedconfigCollection = new combinedconfigCollection();

            // Site logs            

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = "Site";
                acontrolConfig.logProduct = "ConfigMgr";
                acontrolConfig.pathAppend = @"Logs";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\SMS\Identification";
                aregistrybladeConfig.registryvalidationkey = @"Installation Directory";

                aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\SMS\Identification";
                aregistrybladeConfig.registryValue = @"Installation Directory";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);                
            }
            catch (Exception ee)
            {

            }

            // Site setup logs

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "ConfigMgr*.lo*";
                acontrolConfig.logClass = "Site Setup";
                acontrolConfig.logProduct = "ConfigMgr";
                acontrolConfig.pathAppend = @"";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = false;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Setup";
                aregistrybladeConfig.registryvalidationkey = @"BootDir";

                aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Setup";
                aregistrybladeConfig.registryValue = @"BootDir";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);                
            }
            catch (Exception ee)
            {

            }

            //// Agent logs and Management Point

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = @"Agent\MP";
                acontrolConfig.logProduct = "ConfigMgr";
                acontrolConfig.pathAppend = @"";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"Software\Microsoft\CCM\Logging\@Global";
                aregistrybladeConfig.registryvalidationkey = @"LogDirectory";

                aregistrybladeConfig.registryPath = @"Software\Microsoft\CCM\Logging\@Global";
                aregistrybladeConfig.registryValue = @"LogDirectory";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception ee)
            {

            }

            // Check alternative location path

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = @"Agent\MP";
                acontrolConfig.logProduct = "ConfigMgr";
                acontrolConfig.pathAppend = @"Logs";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"software\Microsoft\sms\client\configuration\client properties";
                aregistrybladeConfig.registryvalidationkey = @"Local SMS Path";

                aregistrybladeConfig.registryPath = @"software\Microsoft\sms\client\configuration\client properties";
                aregistrybladeConfig.registryValue = @"Local SMS Path";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception ee)
            {

            }

            //// CCMSETUP

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = @"Agent Setup";
                acontrolConfig.logProduct = "ConfigMgr";
                acontrolConfig.pathAppend = @"CCMSETUP\Logs";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                aregistrybladeConfig.registryvalidationkey = @"SystemRoot";

                aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                aregistrybladeConfig.registryValue = @"SystemRoot";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception ee)
            {

            }

            //// DP logs
            
            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = @"Distribution Point";
                acontrolConfig.logProduct = "ConfigMgr";
                acontrolConfig.pathAppend = @"";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\SMS\DP\Logging\@Global";
                aregistrybladeConfig.registryvalidationkey = @"LogDirectory";

                aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\SMS\DP\Logging\@Global";
                aregistrybladeConfig.registryValue = @"LogDirectory";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception ee)
            {

            }

            //// Console logs

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = @"Console";
                acontrolConfig.logProduct = "ConfigMgr";
                acontrolConfig.pathAppend = @"";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Wow6432Node\Microsoft\ConfigMgr10\AdminUI";
                aregistrybladeConfig.registryvalidationkey = @"AdminUILog";

                aregistrybladeConfig.registryPath = @"SOFTWARE\Wow6432Node\Microsoft\ConfigMgr10\AdminUI";
                aregistrybladeConfig.registryValue = @"AdminUILog";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception ee)
            {

            }

            // 2Pint Software

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = @"2Pint Stifler";
                acontrolConfig.logProduct = "2Pint";
                acontrolConfig.pathAppend = @"";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders";
                aregistrybladeConfig.registryvalidationkey = @"Common AppData";

                aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders";
                aregistrybladeConfig.registryValue = @"Common AppData";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception ee)
            {

            }

            //// 1e Nomad

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = @"Nomad";
                acontrolConfig.logProduct = "1e";
                acontrolConfig.pathAppend = @"";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"software\1e\NomadBranch";
                aregistrybladeConfig.registryvalidationkey = @"LogDirectory";

                aregistrybladeConfig.registryPath = @"software\1e\NomadBranch";
                aregistrybladeConfig.registryValue = @"LogDirectory";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception ee)
            {

            }

            //// Adaptiva Onesite
           
            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = @"OneSite";
                acontrolConfig.logProduct = "Adaptiva";
                acontrolConfig.pathAppend = @"";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"Software\Wow6432Node\Adaptiva\client";
                aregistrybladeConfig.registryvalidationkey = @"LogDirectory";

                aregistrybladeConfig.registryPath = @"Software\Wow6432Node\Adaptiva\client";
                aregistrybladeConfig.registryValue = @"LogDirectory";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception ee)
            {

            }

            //// IIS

            try
            {
                // First get the path to IIS installation and form the full path to the config file

                Object iisinstallPath = getregkeyValue(remoteServer, "HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\InetStp", "InstallPath");

                string configfilePath = iisinstallPath + @"\Config\applicationHost.config";           

                configfilePath = @"\\" + remoteServer + @"\" + configfilePath.Replace(@":","$");

                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                xmlbladeConfig axmlbladeConfig = new xmlbladeConfig();


                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = @"Web Server";
                acontrolConfig.logProduct = "IIS";
                acontrolConfig.pathAppend = @"";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                axmlbladeConfig.configfilePath = configfilePath;
                axmlbladeConfig.searchPattern = "log";
                axmlbladeConfig.searchcaseSensitive = false;
                axmlbladeConfig.searchProperty = "directory=";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = axmlbladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception ee)
            {

            }

            //// Windows

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = @"Windows Temp Logs";
                acontrolConfig.logProduct = "Windows";
                acontrolConfig.pathAppend = @"Temp";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                aregistrybladeConfig.registryvalidationkey = @"PathName";

                aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                aregistrybladeConfig.registryValue = @"PathName";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception ee)
            {

            }

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = @"Windows Logs";
                acontrolConfig.logProduct = "Windows";
                acontrolConfig.pathAppend = @"Logs";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                aregistrybladeConfig.registryvalidationkey = @"PathName";

                aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                aregistrybladeConfig.registryValue = @"PathName";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception ee)
            {

            }

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = @"Windows System Log";
                acontrolConfig.logProduct = "Windows";
                acontrolConfig.pathAppend = @"System32\LogFiles";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                aregistrybladeConfig.registryvalidationkey = @"PathName";

                aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                aregistrybladeConfig.registryValue = @"PathName";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception ee)
            {

            }

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = @"Windows Setup Logs";
                acontrolConfig.logProduct = "Windows";
                acontrolConfig.pathAppend = @"Panther";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                aregistrybladeConfig.registryvalidationkey = @"SystemRoot";

                aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                aregistrybladeConfig.registryValue = @"SystemRoot";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception ee)
            {

            }

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = @"Windows Sysprep Logs";
                acontrolConfig.logProduct = "Windows";
                acontrolConfig.pathAppend = @"System32\Sysprep\Panther";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                aregistrybladeConfig.registryvalidationkey = @"SystemRoot";

                aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                aregistrybladeConfig.registryValue = @"SystemRoot";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception ee)
            {

            }

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = @"Windows Directory";
                acontrolConfig.logProduct = "Windows";
                acontrolConfig.pathAppend = @"";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = false;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                aregistrybladeConfig.registryvalidationkey = @"SystemRoot";

                aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                aregistrybladeConfig.registryValue = @"SystemRoot";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception ee)
            {

            }

            // WSUS Server logs

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.logClass = @"WSUS Server Logs";
                acontrolConfig.logProduct = "WSUS Server";
                acontrolConfig.pathAppend = @"Update Services\LogFiles";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion";
                aregistrybladeConfig.registryvalidationkey = @"ProgramFilesDir";

                aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion";
                aregistrybladeConfig.registryValue = @"ProgramFilesDir";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception ee)
            {

            }

            //// SQL

            try
            {
                // First get the path to SQL installation paths for each instance of RS and SQL Engine 

                string[] sqlserverInstances = getregkeyValues(remoteServer, @"HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL");

                string[] rsserverInstances = getregkeyValues(remoteServer, @"HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\RS");

                foreach (string instanceName in sqlserverInstances)
                {
                    try
                    {
                        string correctinstanceName = (string)getregkeyValue(remoteServer, @"HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", instanceName);

                        combinedConfig acombinedConfig = new combinedConfig();
                        controlConfig acontrolConfig = new controlConfig();
                        registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                        acontrolConfig.remoteServer = remoteServer;
                        acontrolConfig.fileextensionOverride = "";
                        acontrolConfig.fileMask = "SQLAGENT*";
                        acontrolConfig.disregardduplicatePath = false;
                        acontrolConfig.logClass = @"SQL Database Services";
                        acontrolConfig.logProduct = "SQL Server";
                        acontrolConfig.pathAppend = @"Log";
                        acontrolConfig.pathFilter = "";
                        acontrolConfig.recurseDirectory = true;

                        aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                        aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\Microsoft SQL Server\" + correctinstanceName + @"\Setup";
                        aregistrybladeConfig.registryvalidationkey = @"SQLDataRoot";

                        aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\Microsoft SQL Server\" + correctinstanceName + @"\Setup";
                        aregistrybladeConfig.registryValue = @"SQLDataRoot";

                        acombinedConfig.acontrolConfig = acontrolConfig;
                        acombinedConfig.abladeConfig = aregistrybladeConfig;

                        acombinedconfigCollection.Add(acombinedConfig);
                    }
                    catch (Exception ee)
                    {

                    }

                    try
                    {
                        string correctinstanceName = (string)getregkeyValue(remoteServer, @"HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", instanceName);

                        combinedConfig acombinedConfig = new combinedConfig();
                        controlConfig acontrolConfig = new controlConfig();
                        registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                        acontrolConfig.remoteServer = remoteServer;
                        acontrolConfig.fileextensionOverride = "";
                        acontrolConfig.fileMask = "ERRORLOG*";
                        acontrolConfig.disregardduplicatePath = true;
                        acontrolConfig.logClass = @"SQL Database Services";
                        acontrolConfig.logProduct = "SQL Server";
                        acontrolConfig.pathAppend = @"Log";
                        acontrolConfig.pathFilter = "";
                        acontrolConfig.recurseDirectory = true;

                        aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                        aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\Microsoft SQL Server\" + correctinstanceName + @"\Setup";
                        aregistrybladeConfig.registryvalidationkey = @"SQLDataRoot";

                        aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\Microsoft SQL Server\" + correctinstanceName + @"\Setup";
                        aregistrybladeConfig.registryValue = @"SQLDataRoot";

                        acombinedConfig.acontrolConfig = acontrolConfig;
                        acombinedConfig.abladeConfig = aregistrybladeConfig;

                        acombinedconfigCollection.Add(acombinedConfig);
                    }
                    catch (Exception ee)
                    {

                    }
                }

                foreach (string instanceName in rsserverInstances)
                {
                    try
                    {
                        string correctinstanceName = (string)getregkeyValue(remoteServer, @"HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\RS", instanceName);

                        combinedConfig acombinedConfig = new combinedConfig();
                        controlConfig acontrolConfig = new controlConfig();
                        registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                        acontrolConfig.remoteServer = remoteServer;
                        acontrolConfig.fileextensionOverride = "";
                        acontrolConfig.fileMask = "*.lo*";
                        acontrolConfig.logClass = @"SQL Reporting Services";
                        acontrolConfig.logProduct = "SQL Server";
                        acontrolConfig.pathAppend = @"LogFiles";
                        acontrolConfig.pathFilter = "";
                        acontrolConfig.recurseDirectory = true;

                        aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                        aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\Microsoft SQL Server\" + correctinstanceName + @"\Setup";
                        aregistrybladeConfig.registryvalidationkey = @"SQLPath";

                        aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\Microsoft SQL Server\" + correctinstanceName + @"\Setup";
                        aregistrybladeConfig.registryValue = @"SQLPath";

                        acombinedConfig.acontrolConfig = acontrolConfig;
                        acombinedConfig.abladeConfig = aregistrybladeConfig;

                        acombinedconfigCollection.Add(acombinedConfig);
                    }
                    catch (Exception ee)
                    {

                    }
                }
            }
            catch (Exception ee)
            {

            }

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.disregardduplicatePath = false;
                acontrolConfig.logClass = @"SQL Setup Logs";
                acontrolConfig.logProduct = "SQL Server";
                acontrolConfig.pathAppend = @"Log";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\Microsoft SQL Server\120\Bootstrap";
                aregistrybladeConfig.registryvalidationkey = @"BootStrapDir";

                aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\Microsoft SQL Server\120\Bootstrap";
                aregistrybladeConfig.registryValue = @"BootStrapDir";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception ee)
            {

            }

            // Powershell Application Deployment Toolkit

            try
            {
                combinedConfig acombinedConfig = new combinedConfig();
                controlConfig acontrolConfig = new controlConfig();
                registrybladeConfig aregistrybladeConfig = new registrybladeConfig();

                acontrolConfig.remoteServer = remoteServer;
                acontrolConfig.fileextensionOverride = "";
                acontrolConfig.fileMask = "*.lo*";
                acontrolConfig.disregardduplicatePath = false;
                acontrolConfig.logClass = @"PADT Logs";
                acontrolConfig.logProduct = "PowerShell Application Deployment Toolkit";
                acontrolConfig.pathAppend = @"Logs\Software";
                acontrolConfig.pathFilter = "";
                acontrolConfig.recurseDirectory = true;

                aregistrybladeConfig.registryHive = "HKEY_LOCAL_MACHINE";

                aregistrybladeConfig.registryvalidationPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                aregistrybladeConfig.registryvalidationkey = @"SystemRoot";

                aregistrybladeConfig.registryPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
                aregistrybladeConfig.registryValue = @"SystemRoot";

                acombinedConfig.acontrolConfig = acontrolConfig;
                acombinedConfig.abladeConfig = aregistrybladeConfig;

                acombinedconfigCollection.Add(acombinedConfig);
            }
            catch (Exception ee)
            {

            }

            // Retrieve any custom log locations along with their log file suffixes and whether to recurse the directories

            try
            {
                string[] customlogLocations = (string[])getregkeyValue("", "HKEY_CURRENT_USER", @"SOFTWARE\SMSMarshall\LogLauncher", "CustomLogLocations");

                foreach (string customlogLocation in customlogLocations)
                {
                    try
                    {
                        string[] splitElements = customlogLocation.Split('|');

                        combinedConfig acombinedConfig = new combinedConfig();
                        controlConfig acontrolConfig = new controlConfig();
                        custombladeConfig acustombladeConfig = new custombladeConfig();

                        acontrolConfig.remoteServer = remoteServer;
                        acontrolConfig.fileextensionOverride = "";
                        acontrolConfig.fileMask = splitElements[1];
                        acontrolConfig.disregardduplicatePath = false;
                        acontrolConfig.logClass = splitElements[4];
                        acontrolConfig.logProduct = splitElements[3];
                        acontrolConfig.pathAppend = @"";
                        acontrolConfig.pathFilter = "";
                        acontrolConfig.recurseDirectory = Convert.ToBoolean(splitElements[2]);

                        acustombladeConfig.logPath = splitElements[0];                        

                        acombinedConfig.acontrolConfig = acontrolConfig;
                        acombinedConfig.abladeConfig = acustombladeConfig;

                        acombinedconfigCollection.Add(acombinedConfig);
                    }
                    catch (Exception ee)
                    {

                    }
                }
            }
            catch (Exception ee)
            {
                
            }            

            return fetchLogs(acombinedconfigCollection, alogitemCollection, sender);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private List<string> getlogProducts(logitemCollection logCollection)
        {
            try
            {
                List<string> productNames = new List<string>();

                foreach (logItem alogItem in logCollection)
                {
                    if (!productNames.Contains(alogItem.logProduct))
                    {
                        productNames.Add(alogItem.logProduct);
                    }
                }

                return productNames;
            }
            catch (Exception ee)
            {
                diagnosticMessage("Failure to lookup log products");
            }

            return null;
        }

        private logitemCollection getlogClasses(logitemCollection logCollection)
        {
            logitemCollection alogitemCollection = new logitemCollection();

            List<string> classNames = new List<string>();

            foreach (logItem alogItem in logCollection)
            {
                if (!classNames.Contains(alogItem.logClass))
                {
                    classNames.Add(alogItem.logClass);

                    alogitemCollection.Add(alogItem);
                }
            }

            return alogitemCollection;
        }

        private void buildtreeView(logitemCollection theLogs)
        {
            // Helper for Site server detection

            siteserverDetected = false;

            clientDetected = false;

            disabletreeView = true;

            tv_Logs.BeginUpdate();

            tv_Logs.Nodes.Clear();

            tv_Logs.Nodes.Add("All");
            
            TreeNode parentNode = tv_Logs.Nodes[0];

            List<string> productList = getlogProducts(theLogs);

            try
            {
                foreach (string productName in productList)
                {
                    parentNode.Nodes.Add(productName);                    

                    TreeNode childNode = parentNode.Nodes[parentNode.Nodes.Count - 1];

                    logitemCollection logClasses = getlogClasses(theLogs);

                    foreach (logItem alogItem in logClasses)
                    {
                        try
                        {
                            if (alogItem.logProduct == productName)
                            {
                                if (alogItem.logClass == "Site") // Detect if a Site is being added
                                {
                                    siteserverDetected = true;
                                }

                                if (alogItem.logClass == @"Agent\MP") // Detect if a ConfigMgr Agent is being added
                                {
                                    clientDetected = true;
                                }

                                childNode.Nodes.Add(alogItem.logClass);
                            }
                        }
                        catch (Exception ee)
                        {
                            diagnosticMessage("Logic implosion during build of TreeView - " + ee.Message);
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                diagnosticMessage("Logic implosion during build of TreeView - " + ee.Message);
            }

            tv_Logs.ExpandAll();

            try
            {
                TreeNode selectedtvNode = tv_Logs.Nodes[0];

                tv_Logs.SelectedNode = selectedtvNode;
            }
            catch (Exception ee)
            {
                diagnosticMessage("Logic implosion getting selected TreeView node - " + ee.Message);
            }

            tv_Logs.EndUpdate();

            disabletreeView = false;
        }

        private void renderLogs(logitemCollection theLogs, bool ignoretreeView)
        {
            // Clear DGV rows

            dgv_Logs.Rows.Clear();

            // Build tree view

            if (!ignoretreeView)
            {
                buildtreeView(theLogs);
            }

            // Add the row if it meets criteria

            try
            {
                foreach (logItem thelogItem in theLogs)
                {
                    if (thelogItem.logType == c_archiveLog && switches_hide_archiveLogs)
                    {

                    }
                    else
                    {                     
                        if (thelogItem.logClass == this.tv_Logs.SelectedNode.Text || this.tv_Logs.SelectedNode.Text == "All" || thelogItem.logProduct == this.tv_Logs.SelectedNode.Text)
                        {
                            dgvAdd(thelogItem.logProduct, thelogItem.fulllogName, thelogItem.logClass, thelogItem.LogName, thelogItem.logLocation, thelogItem.logType, thelogItem.logSize, thelogItem.loglastModified, true);
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                // diagnosticMessage("No logs found");
            }
        }
        
        private void updateGradient()
        {
            colourList.Clear();

            colourList.Add(pb_colourpickerStart.BackColor); // Add the starting Color

            // Attribution to Steinwolfe on Stackoverflow for the below Color gradient code

            double aStep = (pb_colourpickerEnd.BackColor.A - pb_colourpickerStart.BackColor.A) / 10;
            double rStep = (pb_colourpickerEnd.BackColor.R - pb_colourpickerStart.BackColor.R) / 10;
            double gStep = (pb_colourpickerEnd.BackColor.G - pb_colourpickerStart.BackColor.G) / 10;
            double bStep = (pb_colourpickerEnd.BackColor.B - pb_colourpickerStart.BackColor.B) / 10;

            for (int i = 1; i < 10; i++)
            {
                var a = pb_colourpickerStart.BackColor.A + (int)(aStep * i);
                var r = pb_colourpickerStart.BackColor.R + (int)(rStep * i);
                var g = pb_colourpickerStart.BackColor.G + (int)(gStep * i);
                var b = pb_colourpickerStart.BackColor.B + (int)(bStep * i);

                colourList.Add(Color.FromArgb(a, r, g, b));

                // Attribution to Steinwolfe on Stackoverflow for the above Color gradient code
            }

            colourList.Add(pb_colourpickerEnd.BackColor); // Add the ending Color
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            switches_startupPhase = true;

            getcommandlineParameters();

            getloglauncherSettings();

            updateGradient();

            // Set throttle value

            throttleDelay = Convert.ToInt16(nup_Delay.Value);

            // Add context menu strip

            dgv_Logs.ContextMenuStrip = contextMenuStrip1;
            
            // Set version in status strip

            toolStripStatusLabel2.Text = c_productVersion;

            // Handle CMTrace lookup fallback, and last resort, Notepad

            notificationMessage("Discovering CMTrace ...");

            cmtracePath = getcmtraceregkeyValue();
            
            if (cmtracePath == null)
            {
                if (regkeyvalueExist("", "HKEY_LOCAL_MACHINE", @"Software\SMSMarshall\LogLauncher", "CMTracePath"))
                {
                    cmtracePath = getregkeyValue("", "HKEY_LOCAL_MACHINE", @"Software\SMSMarshall\LogLauncher", "CMTracePath").ToString();
                }

                if (File.Exists(cmtracePath))
                {
                    diagnosticMessage("CMTrace fallback specified in preferences " + cmtracePath + ", using that ...");
                }
                else
                {
                    diagnosticMessage("No trace of CMTrace found in HKCU registry hive ... has it been run before?");

                    cmtracePath = Environment.GetFolderPath(Environment.SpecialFolder.Windows) + @"\notepad.exe";

                    DialogResult adialogResult = MessageBox.Show("Do you want to locate CMTrace manually?", "CMTrace Missing", MessageBoxButtons.YesNo);

                    if (adialogResult == DialogResult.Yes)
                    {
                        openFileDialog1.InitialDirectory = Environment.SystemDirectory;
                        openFileDialog1.Filter = "CMTrace (CMTrace.exe)|CMTrace.exe";
                        openFileDialog1.FileName = "";

                        DialogResult result = openFileDialog1.ShowDialog();

                        if (result == DialogResult.OK) // Set for current session, and store in registry
                        {
                            diagnosticMessage(" Located manually, storing path in preferences");

                            cmtracePath = openFileDialog1.FileName;

                            updateloglauncherSettings(returnregistryHive("HKEY_LOCAL_MACHINE"),"CMTracePath", cmtracePath);                            
                        }

                        if (result == DialogResult.Cancel)
                        {
                            diagnosticMessage("No CMTrace found, using Notepad instead ...");
                        }
                    }

                    if (adialogResult == DialogResult.No)
                    {
                        diagnosticMessage("Ok, using Notepad instead ...");
                    }
                }            
            }
            else
            {
                diagnosticMessage("CMTrace found " + cmtracePath + ", using that ...");
            }

            // Perform log discovery

            notificationMessage("Discovering Logs ...");

            dgv_Logs.Sort(this.dgv_Logs.Columns["dgv_c_lastWritten"], ListSortDirection.Descending);

            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;
            bw.DoWork +=
                new DoWorkEventHandler(bw_scan_DoWork);
            bw.ProgressChanged +=
                new ProgressChangedEventHandler(bw_scan_ProgressChanged);
            bw.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(bw_scan_RunWorkerCompleted);

            bw.RunWorkerAsync(cb_remoteServer.Text);            
        }

        private void launchLogs(DataGridViewSelectedRowCollection dgvRows)
        {
            List<string> logList = new List<string>();

            foreach (DataGridViewRow dgvRow in dgvRows)
            {
                string logName = dgvRow.Cells[0].Value.ToString();

                logList.Add((char)34 + logName + (char)34);                            
            }

            if (!switches_open_multipleLogs)
            {
                foreach (string logtoOpen in logList)
                {
                    ProcessStartInfo newProcess = new ProcessStartInfo();

                    newProcess.FileName = cmtracePath;

                    newProcess.Arguments = logtoOpen;

                    newProcess.CreateNoWindow = false;

                    newProcess.UseShellExecute = false;

                    try
                    {
                        Process.Start(newProcess);
                    }
                    catch (Exception ee)
                    {
                        notificationMessage("Could not start CMTrace " + ee.Message);
                    }
                }
            }

            if (switches_open_multipleLogs)
            {
                // cmtracePath

                ProcessStartInfo newProcess = new ProcessStartInfo();

                newProcess.FileName = cmtracePath;

                newProcess.Arguments = string.Join(" ", logList.ToArray());

                newProcess.CreateNoWindow = false;

                newProcess.UseShellExecute = false;

                try
                {
                    Process.Start(newProcess);
                }
                catch (Exception ee)
                {
                    notificationMessage("Could not start CMTrace " + ee.Message);
                }
            }
        }

        private void dgv_Logs_DoubleClick(object sender, EventArgs e)
        { 
                launchLogs(dgv_Logs.SelectedRows);
        }

        private void dgv_Logs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                launchLogs(dgv_Logs.SelectedRows);

                e.Handled = true;
            }

            if (!e.Handled && (e.KeyValue >= 65 && e.KeyValue <= 90)) // Higher than or equal too 'a' and lower than or equal too 'z'
            {
                bool foundaSelection = false;

                // Store currently selected Rows

                int currentIndex = 0;

                foreach (DataGridViewRow adgvRow in dgv_Logs.SelectedRows)
                {
                    currentIndex = adgvRow.Index;

                    break;
                }

                try
                {
                    foreach (DataGridViewRow adgvRow in dgv_Logs.Rows)
                    {
                        if (!foundaSelection)
                        {
                            if (adgvRow.Cells["dgv_c_logName"].Value.ToString().ToLower().StartsWith(e.KeyCode.ToString().ToLower()))
                            {
                                adgvRow.Selected = true;

                                dgv_Logs.FirstDisplayedScrollingRowIndex = adgvRow.Index;

                                foundaSelection = true;

                                e.Handled = true;
                            }
                            else
                            {
                                adgvRow.Selected = false;
                            }
                        }
                        else
                        {
                            adgvRow.Selected = false;
                        }
                    }
                }
                catch (Exception ee)
                {
                    diagnosticMessage("Error during Logs datagrid meddling - " + ee.Message);
                }

                if (!e.Handled) // Handle not finding a selection
                {
                    foreach (DataGridViewRow adgvRow in dgv_Logs.Rows)
                    {
                        if (adgvRow.Index == currentIndex)
                        {
                            adgvRow.Selected = true;

                            dgv_Logs.FirstDisplayedScrollingRowIndex = currentIndex;
                        }
                    }

                    e.Handled = true;
                }                        
            }      
        }

        private void tv_Logs_AfterSelect(object sender, TreeViewEventArgs e)
        {
            p_Logging.Visible = false;
            dgv_Diagnostics.Visible = false;
            dgv_Logs.Visible = true;

            try
            {
                if (switches_monitorLogs) // Stop monitoring the log view contents
                {
                    switches_monitorLogs = false;

                    cb_Monitor.Checked = false;

                    notificationMessage("");

                    diagnosticMessage("Stopped monitoring logs due to new log category being selected");                    
                }

                if (!disabletreeView)
                {
                    renderLogs(thelogitemCollection, true);
                }

                notificationMessage(this.tv_Logs.SelectedNode.Text + " contains " + dgv_Logs.Rows.Count.ToString() + " logs - " + getSaying());                
            }
            catch (Exception ee)
            {
                diagnosticMessage("Error during tv_Logs_afterSelect - " + ee.Message);
            }
        }

        private void populateclientPanel(string remoteServer)
        {
            try
            {
                int logEnabled = (int)getregkeyValue(remoteServer, @"HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\CCM\Logging\@Global", "LogEnabled");
                int logLevel = (int)getregkeyValue(remoteServer, @"HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\CCM\Logging\@Global", "LogLevel");
                int logmaxHistory = (int)getregkeyValue(remoteServer, @"HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\CCM\Logging\@Global", "LogMaxHistory");
                int logmaxSize = (int)getregkeyValue(remoteServer, @"HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\CCM\Logging\@Global", "LogMaxSize");

                if (Convert.ToInt16(logEnabled) != 0)
                {
                    cb_client_Logging.Checked = true;
                }
                else
                {
                    cb_client_Logging.Checked = false;
                }

                nud_client_logLevel.Value = logLevel;
                nud_client_logmaxHistory.Value = logmaxHistory;
                nud_client_logmaxSize.Value = logmaxSize;

                if (regkeyExist(remoteServer, "HKEY_LOCAL_MACHINE", @"Software\Microsoft\CCM\Logging\@Global\DebugLogging"))
                {
                    cb_client_debugLogging.Checked = true;
                }
                else
                {
                    cb_client_debugLogging.Checked = false;
                }
            }
            catch (Exception ee)
            {
                diagnosticMessage("Error while obtaining client logging properties - " + ee.Message);
            }
        }

        private void populateserverPanel(string remoteServer)
        {
            try
            {
                int logEnabled = (int)getregkeyValue(remoteServer, @"HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\SMS\Tracing", "Enabled");
                int sqlLogging = (int)getregkeyValue(remoteServer, @"HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\SMS\Tracing", "SqlEnabled");
                int archiveEnabled = (int)getregkeyValue(remoteServer, @"HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\SMS\Tracing", "ArchiveEnabled");

                if (logEnabled != 0)
                {
                    cb_site_siteLogging.Checked = true;
                }
                else
                {
                    cb_site_siteLogging.Checked = false;
                }

                if (sqlLogging != 0)
                {
                    cb_site_sqlLogging.Checked = true;
                }
                else
                {
                    cb_site_sqlLogging.Checked = false;
                }

                if (archiveEnabled != 0)
                {
                    cb_site_archiveLogs.Checked = true;
                }
                else
                {
                    cb_site_archiveLogs.Checked = false;
                }

                int providerlogLevel = (int)getregkeyValue(remoteServer, @"HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\SMS\Providers", "Logging Level");
                int providersqlCache = (int)getregkeyValue(remoteServer, @"HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\SMS\Providers", "SQL Cache Logging Level");
                int providerlogSize = (int)getregkeyValue(remoteServer, @"HKEY_LOCAL_MACHINE", @"SOFTWARE\Microsoft\SMS\Providers", "Log Size Mb");

                num_provider_loggingLevel.Value = providerlogLevel;
                num_provider_sqlcacheloggingLevel.Value = providersqlCache;
                num_provider_logsizeMb.Value = providerlogSize;                
            }
            catch (Exception ee)
            {
                diagnosticMessage("Error while obtaining client logging properties - " + ee.Message);
            }
        }

        private void b_scanLogs_Click(object sender, EventArgs e)
        {
            b_logSettings.Visible = false;
            p_Logging.Visible = false;
            dgv_Diagnostics.Visible = false;
            dgv_Logs.Visible = true;

            dgv_Logging.Rows.Clear();

            try
            {
                if (!switches_scan_threadRunning && !switches_threadRunning)
                {
                    // Check if destination exists, query a basic registry key

                    if (regkeyExist(cb_remoteServer.Text, "HKEY_LOCAL_MACHINE", @"Software\Microsoft\Windows\CurrentVersion\Setup"))
                    {
                        BackgroundWorker bw = new BackgroundWorker();
                        bw.WorkerSupportsCancellation = true;
                        bw.WorkerReportsProgress = true;
                        bw.DoWork +=
                            new DoWorkEventHandler(bw_scan_DoWork);
                        bw.ProgressChanged +=
                            new ProgressChangedEventHandler(bw_scan_ProgressChanged);
                        bw.RunWorkerCompleted +=
                            new RunWorkerCompletedEventHandler(bw_scan_RunWorkerCompleted);

                        bw.RunWorkerAsync(cb_remoteServer.Text);


                        // Manage the Recent Server entries

                        if (!cb_remoteServer.Items.Contains(cb_remoteServer.Text))
                        {
                            try
                            {
                                cb_remoteServer.Items.Remove(cb_remoteServer.Items.Count);

                                cb_remoteServer.Items.Add(cb_remoteServer.Text);

                                // Store recent servers back to registry

                                String[] recentserverArray = new String[cb_remoteServer.Items.Count];

                                cb_remoteServer.Items.CopyTo(recentserverArray, 0);

                                setregkeyValues("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "RecentServers", recentserverArray);

                                if (regkeyvalueExist("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "RecentServers"))
                                {
                                    string[] recentServers = (string[])getregkeyValue("", "HKEY_CURRENT_USER", @"Software\SMSMarshall\LogLauncher", "RecentServers");

                                    cb_remoteServer.Items.Clear();

                                    foreach (string recentServer in recentServers)
                                    {
                                        cb_remoteServer.Items.Add(recentServer);
                                    }
                                }
                            }
                            catch (Exception ee)
                            {

                            }

                        }
                    }
                    else
                    {
                        notificationMessage("Destination does not respond");

                        diagnosticMessage("Destination does not respond");
                    }
                }
                else
                {
                    if (switches_scan_threadRunning)
                    {
                        diagnosticMessage("Scan thread is already running");
                    }

                    if (switches_threadRunning)
                    {
                        diagnosticMessage("Turn off monitoring before scanning for logs again");
                    }
                }
            }
            catch (Exception ee)
            {
                diagnosticMessage("Error during scanning of logs - " + ee.Message);
            }            
        }
        private string getSaying()
        {
            try
            {
                var spacedistortionField = new Random((int)DateTime.Now.Ticks);

                var distortedfieldInteger = spacedistortionField.Next(0, c_Sayings.Count);

                return c_Sayings[distortedfieldInteger];
            }
            catch (Exception ee)
            {
                diagnosticMessage("Error producing a saying" + ee.Message);
            }

            return "";
        }

        private void bw_logging_DoWork(object sender, DoWorkEventArgs e)
        {
            string remoteServer = (string)e.Argument;

            switches_logging_threadRunning = true;

            loggingitemCollection aloggingitemCollection = new loggingitemCollection();

            RegistryKey componentKeys = RegistryKey.OpenRemoteBaseKey(returnregistryHive("HKEY_LOCAL_MACHINE"), remoteServer); // ***

            componentKeys = componentKeys.OpenSubKey(@"SOFTWARE\Microsoft\SMS\Tracing");

            foreach (string asubkeyName in componentKeys.GetSubKeyNames())
            {
                loggingItem aloggingItem = new loggingItem();

                aloggingItem.componentName = asubkeyName;

                RegistryKey componentKey = componentKeys.OpenSubKey(asubkeyName, true);

                if (componentKey != null)
                {
                    foreach (string valueName in componentKey.GetValueNames())
                    {
                        if (valueName == "DebugLogging")
                        {
                            if (componentKey.GetValue(valueName).ToString() != "")
                            {
                                try
                                {
                                    aloggingItem.debugLogging = Convert.ToBoolean(componentKey.GetValue(valueName).ToString());
                                }
                                catch (Exception)
                                {
                                    aloggingItem.debugLogging = false;
                                }
                            }
                        }

                        if (valueName == "Enabled")
                        {
                            if (componentKey.GetValue(valueName).ToString() != "")
                            {
                                try
                                {
                                    object enabledState = componentKey.GetValue(valueName);

                                    aloggingItem.Enabled = Convert.ToBoolean(enabledState);
                                }
                                catch (Exception)
                                {
                                    aloggingItem.Enabled = false;
                                }
                            }
                        }

                        if (valueName == "LoggingLevel")
                        {
                            if (componentKey.GetValue(valueName).ToString() != "")
                            {
                                try
                                {
                                    aloggingItem.loggingLevel = (int)componentKey.GetValue(valueName);
                                }
                                catch (Exception)
                                {
                                    aloggingItem.loggingLevel = 0;
                                }
                            }
                        }

                        if (valueName == "LogMaxHistory")
                        {
                            if (componentKey.GetValue(valueName).ToString() != "")
                            {
                                try
                                {
                                    aloggingItem.logmaxHistory = (int)componentKey.GetValue(valueName);
                                }
                                catch (Exception)
                                {
                                    aloggingItem.logmaxHistory = 0;
                                }
                            }
                        }

                        if (valueName == "MaxFileSize")
                        {
                            if (componentKey.GetValue(valueName).ToString() != "")
                            {
                                try
                                {
                                    aloggingItem.maxfileSize = (int)componentKey.GetValue(valueName);
                                }
                                catch (Exception)
                                {
                                    aloggingItem.maxfileSize = 0;
                                }
                            }
                        }
                    }

                    try
                    {
                        // componentKey.Close();
                    }
                    catch (Exception)
                    {

                    }
                }

                aloggingitemCollection.Add(aloggingItem);
            }

            e.Result = aloggingitemCollection;
        }

        private void bw_logging_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == false)
            {
                loggingitemCollection aloggingitemCollection = (loggingitemCollection)e.Result;

                foreach (loggingItem aloggingItem in aloggingitemCollection)
                {
                    dgv_Logging.Rows.Add(aloggingItem.componentName, aloggingItem.debugLogging, aloggingItem.Enabled, aloggingItem.loggingLevel, aloggingItem.logmaxHistory, aloggingItem.maxfileSize);
                }

                dgv_Logging.Sort(this.dgv_Logging.Columns["c_dgv_logging_componentName"], ListSortDirection.Ascending);

                dgv_Logging.Refresh();
            }
        }        

        private void bw_logging_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }        

        private void bw_serviceCycle_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            servicecycleMessage aservicecycleMessage = (servicecycleMessage)e.Argument;

            try
            {
                ServiceController sc = new ServiceController(aservicecycleMessage.serviceName, aservicecycleMessage.remoteServer);

                try
                {
                    loggingMessage aloggingMessage = new loggingMessage();

                    aloggingMessage.messageType = "Notification";
                    aloggingMessage.messageText = "Stopping " + aservicecycleMessage.serviceName + " - This can take a while";

                    worker.ReportProgress(0, aloggingMessage);

                    sc.Stop();

                    sc.WaitForStatus(ServiceControllerStatus.Stopped);
                }
                catch (Exception ee)
                {
                    loggingMessage aloggingMessage = new loggingMessage();

                    aloggingMessage.messageType = "Diagnostic";
                    aloggingMessage.messageText = "Error when stopping " + aservicecycleMessage.serviceName + " - " + ee.Message;

                    worker.ReportProgress(0, aloggingMessage);
                }

                if (sc.Status.ToString() == "Stopped")
                {
                    try
                    {
                        loggingMessage aloggingMessage = new loggingMessage();

                        aloggingMessage.messageType = "Notification";
                        aloggingMessage.messageText = "Starting " + aservicecycleMessage.serviceName + " - This can take a while";

                        worker.ReportProgress(0, aloggingMessage);

                        sc.Start();

                        aloggingMessage.messageText = aservicecycleMessage.serviceName + " started";

                        worker.ReportProgress(0, aloggingMessage);
                    }
                    catch (Exception ee)
                    {
                        loggingMessage aloggingMessage = new loggingMessage();

                        aloggingMessage.messageType = "Diagnostic";
                        aloggingMessage.messageText = "Error starting " + aservicecycleMessage.serviceName;

                        worker.ReportProgress(0, aloggingMessage);
                    }
                }
            }
            catch (Exception ee)
            {
                loggingMessage aloggingMessage = new loggingMessage();

                aloggingMessage.messageType = "Notification";
                aloggingMessage.messageText = "Failed handling " + aservicecycleMessage.serviceName;

                worker.ReportProgress(0, aloggingMessage);

                aloggingMessage.messageType = "Diagnostic";
                aloggingMessage.messageText = "Could not cycle " + aservicecycleMessage.serviceName + " - " + ee.Message;

                worker.ReportProgress(0, aloggingMessage);
            }

            e.Result = aservicecycleMessage.serviceName;
        }

        private void bw_serviceCycle_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {            
            if (e.Cancelled == false)
            {
            }

            string serviceName = (string)e.Result;

            if (serviceName == "SMS_EXECUTIVE")
            {
                b_cycleSMSEXEC.Enabled = true; 
            }
            else
            {
                b_cycleCCMEXEC.Enabled = true;
            }
        }

        private void bw_serviceCycle_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            loggingMessage aloggingMessage = (loggingMessage)e.UserState;

            if (aloggingMessage.messageType == "Diagnostic")
            {
                diagnosticMessage(aloggingMessage.messageText);
            }
            else
            {
                notificationMessage(aloggingMessage.messageText);
            }
        }

        private void bw_scan_DoWork(object sender, DoWorkEventArgs e)
        {
            switches_scan_threadRunning = true;

            logitemCollection theLogs = logDiscovery(e.Argument.ToString(), sender); // Discover logs

            e.Result = theLogs;
        }     

        private void bw_scan_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == false)
            {
                renderLogs((logitemCollection)e.Result, false);

                thelogitemCollection = (logitemCollection)e.Result; // Store the returned logs into the global logs collection for reuse            

                notificationMessage(thelogitemCollection.Count + " total logs found - " + getSaying());
            }

            if (siteserverDetected) // Populate dgv_Logging
            {
                populateserverPanel(cb_remoteServer.Text);

                BackgroundWorker bw = new BackgroundWorker();
                bw.WorkerSupportsCancellation = true;
                bw.WorkerReportsProgress = true;
                bw.DoWork +=
                    new DoWorkEventHandler(bw_logging_DoWork);
                bw.ProgressChanged +=
                    new ProgressChangedEventHandler(bw_logging_ProgressChanged);
                bw.RunWorkerCompleted +=
                    new RunWorkerCompletedEventHandler(bw_logging_RunWorkerCompleted);

                bw.RunWorkerAsync(cb_remoteServer.Text);

                dgv_Logging.Visible = true;

                p_Site.Visible = true;

                b_logSettings.Visible = true;

                // Get those site logging details
            }

            if (clientDetected)
            {
                // Populate the elements on the p_Client panel

                populateclientPanel(cb_remoteServer.Text);

                b_logSettings.Visible = true;
                p_Client.Visible = true;
            }

            switches_scan_threadRunning = false;

            switches_startupPhase = false;
        }

        private void bw_scan_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            messageObject amessageObject = (messageObject)e.UserState;
            
            if (amessageObject.logType == c_Notification)
            {
                notificationMessage(amessageObject.logMessage);
            }

            if (amessageObject.logType == c_Diagnostic)
            {
                diagnosticMessage(amessageObject.logMessage);
            }
        }        

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                logitemCollection thelogItems = (logitemCollection)e.Argument;

                switches_threadRunning = true;

                BackgroundWorker worker = sender as BackgroundWorker;

                string dottedSuffix = ".";

                while (true == true)
                {
                    if (switches_monitorLogs) // This lets us abandon the loop
                    {
                        if (dottedSuffix.Length == 3)
                        {
                            dottedSuffix = "..";
                        }
                        else if (dottedSuffix.Length == 2)
                        {
                            dottedSuffix = ".";

                        }
                        else if (dottedSuffix.Length == 1)
                        {
                            dottedSuffix = "";
                        }
                        else if (dottedSuffix.Length == 0)
                        {
                            dottedSuffix = "...";
                        }

                        thelogItems = refreshlogsinView(thelogItems);

                        reportSuffixUpdatedRows suffixRowsPayload = new reportSuffixUpdatedRows();

                        suffixRowsPayload.suffixText = dottedSuffix;

                        suffixRowsPayload.updatedRows = thelogItems;

                        worker.ReportProgress(0, suffixRowsPayload);

                        for(int i = 1; i < throttleDelay; i++)
                        {
                            if (!switches_monitorLogs)
                            {
                                break;
                            }

                            Thread.Sleep(1000);
                        }                        
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch (Exception ee)
            {

            }

            e.Result = "";
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == false)
            {
                switches_monitorLogs = false;

                cb_Monitor.Checked = false;

                notificationMessage("");

                switches_threadRunning = false;

                diagnosticMessage("Stopped monitoring logs thread");
            }
        }

        private void updatedgvRows(logitemCollection alotitemCollection)
        {            
            foreach (DataGridViewRow aRow in dgv_Logs.Rows)
            {
                foreach (logItem alogItem in alotitemCollection)
                {
                    if (alogItem.fulllogName == aRow.Cells[0].Value.ToString())
                    {
                        if (aRow.Cells[6].Value.ToString() != alogItem.loglastModified.ToString()) // Row needs updating
                        {
                            aRow.Cells[4].Value = alogItem.logSize;
                            aRow.Cells[5].Value = alogItem.logSize / 1024 / 1024;
                            aRow.Cells[6].Value = alogItem.loglastModified;

                            aRow.DefaultCellStyle.BackColor = colourList[0];
                        }
                        else
                        {
                            for (int i = 0; i < colourList.Count; i++)
                            {
                                if (aRow.DefaultCellStyle.BackColor.Name.ToLower() == colourList[i].Name.ToLower())
                                {
                                    if (i < colourList.Count - 1)
                                    {
                                        aRow.DefaultCellStyle.BackColor = colourList[i + 1];

                                        break;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }

                        break; // Since we found a match no longer need to process the inside foreach loop (logItems)
                    }
                }
            }

            try // Sort the DGV on last modified
            {
                this.dgv_Logs.Sort(this.dgv_c_lastWritten, ListSortDirection.Descending);
            }
            catch (Exception ee)
            {

            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            dgv_Logs.SuspendLayout();

            reportSuffixUpdatedRows suffixRowsPayload = (reportSuffixUpdatedRows)e.UserState;

            logitemCollection thelogItems = (logitemCollection)suffixRowsPayload.updatedRows; // Obtain updated logitem Collection

            updatedgvRows(thelogItems); // Render the updated logitem Collection

            thelogitemCollection = thelogItems; // ***            

            notificationMessage("Monitoring visible logs " + suffixRowsPayload.suffixText);
            
            dgv_Logs.ResumeLayout();
        }

        private logitemCollection convertdgvtologItems(DataGridViewRowCollection theRows)
        {
            logitemCollection alogitemCollection = new logitemCollection();

            foreach (DataGridViewRow dgvRow in theRows)
            {
                try
                {
                    logItem alogItem = new logItem();

                    alogItem.fulllogName = dgvRow.Cells[0].Value.ToString();
                    alogItem.LogName = dgvRow.Cells[1].Value.ToString();
                    alogItem.logClass = dgvRow.Cells[2].Value.ToString();
                    alogItem.logType = dgvRow.Cells[3].Value.ToString();
                    alogItem.logSize = (long)dgvRow.Cells[4].Value;
                    alogItem.loglastModified = (DateTime)dgvRow.Cells[6].Value;
                    alogItem.logLocation = dgvRow.Cells[7].Value.ToString();
                    alogItem.logProduct = dgvRow.Cells[8].Value.ToString();

                    alogitemCollection.Add(alogItem);
                }
                catch (Exception ee)
                {

                }
            }

            return alogitemCollection;
        }

        private void cb_Monitor_CheckedChanged(object sender, EventArgs e)
        {
            // Update the cached data with the row data

            try
            {
                if (cb_Monitor.Checked)
                {
                    if (!switches_threadRunning)
                    {
                        if (!switches_monitorLogs)
                        {
                            // Run the timer thread

                            switches_monitorLogs = true;

                            // Refresh the stale view in dgv_Logs

                            logitemCollection alogitemCollection = refreshlogsinView(convertdgvtologItems(dgv_Logs.Rows));

                            renderLogs(alogitemCollection, true);

                            thelogitemCollection = alogitemCollection;

                            // Start the monitoring thread

                            BackgroundWorker bw = new BackgroundWorker();
                            bw.WorkerSupportsCancellation = true;
                            bw.WorkerReportsProgress = true;
                            bw.DoWork +=
                                new DoWorkEventHandler(bw_DoWork);
                            bw.ProgressChanged +=
                                new ProgressChangedEventHandler(bw_ProgressChanged);
                            bw.RunWorkerCompleted +=
                                new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
                            
                            logitemCollection tosendlogitemCollection = convertdgvtologItems(dgv_Logs.Rows);                            

                            bw.RunWorkerAsync(tosendlogitemCollection);

                            diagnosticMessage("Monitoring thread started");
                        }
                    }
                }
                else
                {
                    switches_monitorLogs = false; // Tell the thread to terminate

                    diagnosticMessage("Closing thread");

                    Thread.Sleep(100);
                }
            }
            catch (Exception ee)
            {
                diagnosticMessage("Could not spawn the timer thread - " + ee.Message);
            }
        }

        private void cb_hidearchiveLogs_CheckedChanged(object sender, EventArgs e)
        {
            updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"),"HideArchiveLogs", Convert.ToString(cb_hidearchiveLogs.Checked)); 

            if (cb_hidearchiveLogs.Checked)
            {
                switches_hide_archiveLogs = true;

                dgv_Logs.Columns["dgv_c_Type"].Visible = false;

                renderLogs(thelogitemCollection, true);
            }
            else
            {
                switches_hide_archiveLogs = false;

                dgv_Logs.Columns["dgv_c_Type"].Visible = true;

                renderLogs(thelogitemCollection, true);
            }
        }

        private void cb_openLogsMulti_CheckedChanged(object sender, EventArgs e)
        {
            updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"),"MultipleLogsSingleCMTrace", Convert.ToString(cb_openLogsMulti.Checked));

            if (cb_openLogsMulti.Checked)
            {
                switches_open_multipleLogs = true;
            }
            else
            {
                switches_open_multipleLogs = false;
            }            
        }

        private void b_About_Click(object sender, EventArgs e)
        {
            // Launch about dialog

            Form newaboutForm = new aboutForm();

            newaboutForm.ShowDialog(this);
        }

        private void openLogFolderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Open log folder

            try
            {
                List<string> historicallogpathList = new List<string>();

                foreach (DataGridViewRow alogRow in dgv_Logs.SelectedRows)
                {
                    string logPath = alogRow.Cells["dgv_c_logPath"].Value.ToString(); ;

                    if (!historicallogpathList.Contains(logPath))
                    {
                        historicallogpathList.Add(logPath);

                        ProcessStartInfo newProcess = new ProcessStartInfo();

                        newProcess.FileName = logPath;

                        newProcess.Arguments = "";

                        newProcess.CreateNoWindow = false;

                        newProcess.UseShellExecute = true;

                        try
                        {
                            Process.Start(newProcess);
                        }
                        catch (Exception ee)
                        {
                            notificationMessage("Could not open folder " + ee.Message);
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                diagnosticMessage("Logic implosion opening log folder - " + ee.Message);
            }            
        }

        private void b_debugWindow_Click(object sender, EventArgs e)
        {
            if (dgv_Diagnostics.Visible)
            {
                dgv_Diagnostics.Visible = false;
                p_Logging.Visible = false;
                dgv_Logs.Visible = true;                
            }
            else
            {
                dgv_Diagnostics.Visible = true;
                p_Logging.Visible = false;
                dgv_Logs.Visible = false;
            }
        }

        private void b_refreshLogs_Click(object sender, EventArgs e)
        {
            if (!switches_scan_threadRunning && !switches_threadRunning)
            {
                logitemCollection tosendlogitemCollection = convertdgvtologItems(dgv_Logs.Rows);

                tosendlogitemCollection = refreshlogsinView(tosendlogitemCollection);

                updatedgvRows(tosendlogitemCollection); // Render the updated logitem Collection
            }
            else
            {
                if (switches_scan_threadRunning)
                {
                    diagnosticMessage("Scan thread is already running");
                }

                if (switches_threadRunning)
                {
                    diagnosticMessage("Turn off monitoring before refreshing the view");
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            throttleDelay = Convert.ToInt16(nup_Delay.Value);

            updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"),"MonitoringTimerDuration", Convert.ToString(nup_Delay.Value));
        }

        private void pb_colourpickerStart_Click(object sender, EventArgs e)
        {
            ColorDialog colourDialog = new ColorDialog();

            colourDialog.Color = pb_colourpickerStart.BackColor;

            if (colourDialog.ShowDialog() == DialogResult.OK)
            {
                pb_colourpickerStart.BackColor = colourDialog.Color;

                gradientcolourStart = colourDialog.Color;
            }

            updateGradient();

            updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"),"GradientStartColour", Convert.ToString(pb_colourpickerStart.BackColor.ToArgb()));
        }

        private void pb_colourpickerEnd_Click(object sender, EventArgs e)
        {
            ColorDialog colourDialog = new ColorDialog();

            colourDialog.Color = pb_colourpickerEnd.BackColor;

            if (colourDialog.ShowDialog() == DialogResult.OK)
            {
                pb_colourpickerEnd.BackColor = colourDialog.Color;

                gradientcolourEnd = colourDialog.Color;
            }

            updateGradient();

            updateloglauncherSettings(returnregistryHive("HKEY_CURRENT_USER"),"GradientEndColour", Convert.ToString(pb_colourpickerEnd.BackColor.ToArgb()));
        }

        private void openLogFolderToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            launchLogs(dgv_Logs.SelectedRows);
        }

        private void b_launchconfigcustomLocations_Click(object sender, EventArgs e)
        {
            Form newconfigForm = new configurecustomLocations();

            newconfigForm.ShowDialog(this);
        }

        private void b_launchLogs_Click(object sender, EventArgs e)
        {
            launchLogs(dgv_Logs.SelectedRows);
        }

        private void b_logSettings_Click(object sender, EventArgs e)
        {
            if (p_Logging.Visible)
            {
                dgv_Diagnostics.Visible = false;
                dgv_Logs.Visible = true;
                p_Logging.Visible = false;
            }
            else
            {
                dgv_Diagnostics.Visible = false;
                dgv_Logs.Visible = false;
                p_Logging.Visible = true;
            }
        }

        private void dgv_Logging_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!switches_startupPhase)
            {
                try
                {
                    string componentName = dgv_Logging.Rows[e.RowIndex].Cells["c_dgv_logging_componentName"].Value.ToString();

                    RegistryKey remoteHK = RegistryKey.OpenRemoteBaseKey(returnregistryHive("HKEY_LOCAL_MACHINE"), cb_remoteServer.Text);

                    remoteHK = remoteHK.OpenSubKey(@"Software\Microsoft\SMS\Tracing\" + componentName, true);

                    string dfdew = dgv_Logging.Rows[e.RowIndex].Cells["c_dgv_logging_debugLogging"].Value.ToString().ToLower();

                    for (int i = 1; i < dgv_Logging.ColumnCount; i++)
                    {
                        switch (dgv_Logging.Columns[i].Name)
                        {
                            case "c_dgv_logging_debugLogging":

                                if (dgv_Logging.Rows[e.RowIndex].Cells["c_dgv_logging_debugLogging"].Value.ToString().ToLower() == "true")
                                {
                                    remoteHK.SetValue("DebugLogging", "1", RegistryValueKind.DWord);
                                }
                                else
                                {
                                    remoteHK.SetValue("DebugLogging", "0", RegistryValueKind.DWord);
                                }

                                break;

                            case "c_dgv_logging_Enabled":

                                if (dgv_Logging.Rows[e.RowIndex].Cells["c_dgv_logging_Enabled"].Value.ToString().ToLower() == "true")
                                {
                                    remoteHK.SetValue("Enabled", "1", RegistryValueKind.DWord);
                                }
                                else
                                {
                                    remoteHK.SetValue("Enabled", "0", RegistryValueKind.DWord);
                                }

                                break;
                            case "c_dgv_logging_loggingLevel":

                                int logginglevelValue;

                                if (int.TryParse(dgv_Logging.Rows[e.RowIndex].Cells["c_dgv_logging_loggingLevel"].Value.ToString(), out logginglevelValue))
                                {
                                    remoteHK.SetValue("LoggingLevel", logginglevelValue, RegistryValueKind.DWord);
                                }

                                break;

                            case "c_dgv_logging_logmaxHistory":

                                int logmaxhistoryValue;

                                if (int.TryParse(dgv_Logging.Rows[e.RowIndex].Cells["c_dgv_logging_logmaxHistory"].Value.ToString(), out logmaxhistoryValue))
                                {
                                    remoteHK.SetValue("LogMaxHistory", logmaxhistoryValue, RegistryValueKind.DWord);
                                }

                                break;

                            case "c_dgv_logging_maxfileSize":

                                int maxfilesizeValue;

                                if (int.TryParse(dgv_Logging.Rows[e.RowIndex].Cells["c_dgv_logging_maxfileSize"].Value.ToString(), out maxfilesizeValue))
                                {
                                    remoteHK.SetValue("MaxFileSize", maxfilesizeValue, RegistryValueKind.DWord);
                                }

                                break;
                        }
                    }
                }
                catch (Exception ee)
                {
                    diagnosticMessage("Could not set Sites logging settings - " + ee.Message);
                }
            }
        }

        private void cb_site_siteLogging_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RegistryKey remoteHK = RegistryKey.OpenRemoteBaseKey(returnregistryHive("HKEY_LOCAL_MACHINE"), cb_remoteServer.Text);

                remoteHK = remoteHK.OpenSubKey(@"Software\Microsoft\SMS\Tracing", true);

                if (cb_site_siteLogging.Checked)
                {
                    remoteHK.SetValue("Enabled", "1", RegistryValueKind.DWord);
                }
                else
                {
                    remoteHK.SetValue("Enabled", "0", RegistryValueKind.DWord);
                }
            }
            catch (Exception ee)
            {
                diagnosticMessage("Could not set Sites Logging Enabled property - " + ee.Message);
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RegistryKey remoteHK = RegistryKey.OpenRemoteBaseKey(returnregistryHive("HKEY_LOCAL_MACHINE"), cb_remoteServer.Text);

                remoteHK = remoteHK.OpenSubKey(@"Software\Microsoft\SMS\Tracing", true);

                if (cb_site_sqlLogging.Checked)
                {
                    remoteHK.SetValue("SqlEnabled", "1", RegistryValueKind.DWord);
                }
                else
                {
                    remoteHK.SetValue("SqlEnabled", "0", RegistryValueKind.DWord);
                }
            }
            catch (Exception ee)
            {
                diagnosticMessage("Could not set Sites SQL Enabled property - " + ee.Message);
            }
        }

        private void cb_site_archiveLogs_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RegistryKey remoteHK = RegistryKey.OpenRemoteBaseKey(returnregistryHive("HKEY_LOCAL_MACHINE"), cb_remoteServer.Text);

                remoteHK = remoteHK.OpenSubKey(@"Software\Microsoft\SMS\Tracing", true);

                if (cb_site_archiveLogs.Checked)
                {
                    remoteHK.SetValue("ArchiveEnabled", "1", RegistryValueKind.DWord);
                }
                else
                {
                    remoteHK.SetValue("ArchiveEnabled", "0", RegistryValueKind.DWord);
                }
            }
            catch (Exception ee)
            {
                diagnosticMessage("Could not set Sites Archive Enabled property - " + ee.Message);
            }
        }

        private void num_provider_loggingLevel_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                RegistryKey remoteHK = RegistryKey.OpenRemoteBaseKey(returnregistryHive("HKEY_LOCAL_MACHINE"), cb_remoteServer.Text);

                remoteHK = remoteHK.OpenSubKey(@"Software\Microsoft\SMS\Providers", true);

                remoteHK.SetValue("Logging Level", num_provider_loggingLevel.Value, RegistryValueKind.DWord);
            }
            catch (Exception ee)
            {
                diagnosticMessage("Could not set Site Providers Logging Level property - " + ee.Message);
            }
        }

        private void num_provider_sqlcacheloggingLevel_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                RegistryKey remoteHK = RegistryKey.OpenRemoteBaseKey(returnregistryHive("HKEY_LOCAL_MACHINE"), cb_remoteServer.Text);

                remoteHK = remoteHK.OpenSubKey(@"Software\Microsoft\SMS\Providers", true);

                remoteHK.SetValue("SQL Cache Logging Level", num_provider_sqlcacheloggingLevel.Value, RegistryValueKind.DWord);
            }
            catch (Exception ee)
            {
                diagnosticMessage("Could not set Site Providers SQL Cache Logging Level property - " + ee.Message);
            }
        }

        private void num_provider_logsizeMb_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                RegistryKey remoteHK = RegistryKey.OpenRemoteBaseKey(returnregistryHive("HKEY_LOCAL_MACHINE"), cb_remoteServer.Text);

                remoteHK = remoteHK.OpenSubKey(@"Software\Microsoft\SMS\Providers", true);

                remoteHK.SetValue("Log Size Mb", num_provider_logsizeMb.Value, RegistryValueKind.DWord);
            }
            catch (Exception ee)
            {
                diagnosticMessage("Could not set Site Providers Log Size Mb property - " + ee.Message);
            }
        }

        private void cb_client_debugLogging_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RegistryKey remoteHK = RegistryKey.OpenRemoteBaseKey(returnregistryHive("HKEY_LOCAL_MACHINE"), cb_remoteServer.Text);

                remoteHK = remoteHK.OpenSubKey(@"Software\Microsoft\CCM\Logging\@Global", true);

                if (cb_client_Logging.Checked)
                {
                    remoteHK.SetValue("LogEnabled", "1", RegistryValueKind.DWord);
                }
                else
                {
                    remoteHK.SetValue("LogEnabled", "0", RegistryValueKind.DWord);
                }
            }
            catch (Exception ee)
            {
                diagnosticMessage("Could not set Clients Logging property - " + ee.Message);
            }
        }

        private void cb_client_debugLogging_CheckedChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (cb_client_debugLogging.Checked)
                {

                    if (!regkeyExist(cb_remoteServer.Text, "HKEY_LOCAL_MACHINE", @"Software\Microsoft\CCM\Logging\@Global\DebugLogging"))
                    {
                        RegistryKey remoteHK = RegistryKey.OpenRemoteBaseKey(returnregistryHive("HKEY_LOCAL_MACHINE"), cb_remoteServer.Text);

                        remoteHK = remoteHK.OpenSubKey(@"Software\Microsoft\CCM\Logging\@Global", true);

                        remoteHK.CreateSubKey("DebugLogging");

                        nud_client_logLevel.Value = 0;
                    }
                }
                else
                {
                    if (regkeyExist(cb_remoteServer.Text, "HKEY_LOCAL_MACHINE", @"Software\Microsoft\CCM\Logging\@Global\DebugLogging"))
                    {
                        RegistryKey remoteHK = RegistryKey.OpenRemoteBaseKey(returnregistryHive("HKEY_LOCAL_MACHINE"), cb_remoteServer.Text);

                        remoteHK = remoteHK.OpenSubKey(@"Software\Microsoft\CCM\Logging\@Global", true);

                        remoteHK.DeleteSubKey("DebugLogging");

                        nud_client_logLevel.Value = 1;
                    }
                }                    
            }
            catch (Exception ee)
            {
                diagnosticMessage("Could not set Clients Debug Logging property - " + ee.Message);
            }
        }

        private void nud_client_logLevel_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                RegistryKey remoteHK = RegistryKey.OpenRemoteBaseKey(returnregistryHive("HKEY_LOCAL_MACHINE"), cb_remoteServer.Text);

                remoteHK = remoteHK.OpenSubKey(@"Software\Microsoft\CCM\Logging\@Global", true);

                remoteHK.SetValue("LogLevel", nud_client_logLevel.Value, RegistryValueKind.DWord);
            }
            catch (Exception ee)
            {
                diagnosticMessage("Could not set Clients Log Level property - " + ee.Message);
            }
        }

        private void nud_client_logmaxHistory_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                RegistryKey remoteHK = RegistryKey.OpenRemoteBaseKey(returnregistryHive("HKEY_LOCAL_MACHINE"), cb_remoteServer.Text);

                remoteHK = remoteHK.OpenSubKey(@"Software\Microsoft\CCM\Logging\@Global", true);

                remoteHK.SetValue("LogMaxHistory", nud_client_logmaxHistory.Value, RegistryValueKind.DWord);
            }
            catch (Exception ee)
            {
                diagnosticMessage("Could not set Clients Log Max History property - " + ee.Message);
            }
        }

        private void nud_client_logmaxSize_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                RegistryKey remoteHK = RegistryKey.OpenRemoteBaseKey(returnregistryHive("HKEY_LOCAL_MACHINE"), cb_remoteServer.Text);

                remoteHK = remoteHK.OpenSubKey(@"Software\Microsoft\CCM\Logging\@Global", true);

                remoteHK.SetValue("LogMaxSize", nud_client_logmaxSize.Value, RegistryValueKind.DWord);
            }
            catch (Exception ee)
            {
                diagnosticMessage("Could not set Clients Log Max Size property - " + ee.Message);
            }
        }

        private void b_cycleCCMEXEC_Click(object sender, EventArgs e)
        {
            servicecycleMessage aservicecycleMessage = new servicecycleMessage();

            aservicecycleMessage.remoteServer = cb_remoteServer.Text;
            aservicecycleMessage.serviceName = "CCMEXEC";

            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;
            bw.DoWork +=
                new DoWorkEventHandler(bw_serviceCycle_DoWork);
            bw.ProgressChanged +=
                new ProgressChangedEventHandler(bw_serviceCycle_ProgressChanged);
            bw.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(bw_serviceCycle_RunWorkerCompleted);

            b_cycleCCMEXEC.Enabled = false;

            bw.RunWorkerAsync(aservicecycleMessage);
                                   
        }

        private void b_cycleSMSEXEC_Click(object sender, EventArgs e)
        {
            servicecycleMessage aservicecycleMessage = new servicecycleMessage();

            aservicecycleMessage.remoteServer = cb_remoteServer.Text;
            aservicecycleMessage.serviceName = "SMS_EXECUTIVE";

            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;
            bw.DoWork +=
                new DoWorkEventHandler(bw_serviceCycle_DoWork);
            bw.ProgressChanged +=
                new ProgressChangedEventHandler(bw_serviceCycle_ProgressChanged);
            bw.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(bw_serviceCycle_RunWorkerCompleted);

            b_cycleSMSEXEC.Enabled = false;

            bw.RunWorkerAsync(aservicecycleMessage);
        }
    }
}
