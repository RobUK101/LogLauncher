// Feel free to re-use concepts and actual code from this project, attribution if you make something similiar from these here bones is all I ask

// Robert Marshall - 2016 - Enterprise Mobility MVP

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace LogLauncher
{
    public partial class configurecustomLocations : Form
    {
        public configurecustomLocations()
        {
            InitializeComponent();
        }

        private object getregkeyValue(string remoteServer, string regClass, string regPath, string regKey)
        {
            try
            {
                Microsoft.Win32.RegistryHive reghiveSelected = new Microsoft.Win32.RegistryHive();

                if (regClass == "HKEY_LOCAL_MACHINE")
                {
                    reghiveSelected = RegistryHive.LocalMachine;
                }

                if (regClass == "HKEY_CURRENT_USER")
                {
                    reghiveSelected = RegistryHive.CurrentUser;
                }

                RegistryKey hk = RegistryKey.OpenRemoteBaseKey(reghiveSelected, remoteServer);

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
            catch (Exception)
            {
                return null;
            }

            return null;
        }

        public string[] getregkeyValues(string remoteServer, string regClass, string regPath)
        {
            try
            {
                Microsoft.Win32.RegistryHive reghiveSelected = new Microsoft.Win32.RegistryHive();

                if (regClass == "HKEY_LOCAL_MACHINE")
                {
                    reghiveSelected = RegistryHive.LocalMachine;
                }

                if (regClass == "HKEY_CURRENT_USER")
                {
                    reghiveSelected = RegistryHive.CurrentUser;
                }

                RegistryKey hk = RegistryKey.OpenRemoteBaseKey(reghiveSelected, remoteServer);

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
            catch (Exception)
            {
                return null;
            }

            return null;
        }

        private void renderDGV()
        {
            try
            {
                // Get custom log locations and populate the datagridview

                string[] customlogLocations = (string[])getregkeyValue("", "HKEY_CURRENT_USER", @"SOFTWARE\SMSMarshall\LogLauncher", "CustomLogLocations");

                dgv_customLocations.Rows.Clear();

                if (customlogLocations != null)
                {
                    foreach (string customlogLocation in customlogLocations)
                    {
                        try
                        {
                            string[] splitElements = customlogLocation.Split('|');

                            try
                            {
                                if (splitElements.Count() == 5)
                                {
                                    DataGridViewRow newRow = (DataGridViewRow)dgv_customLocations.Rows[0].Clone();

                                    newRow.Cells[0].Value = splitElements[0];
                                    newRow.Cells[1].Value = splitElements[1];
                                    newRow.Cells[2].Value = splitElements[2];
                                    newRow.Cells[3].Value = splitElements[3];
                                    newRow.Cells[4].Value = splitElements[4];

                                    newRow.Visible = true;

                                    dgv_customLocations.Rows.Add(newRow);
                                }
                            }
                            catch (Exception) // Handle this being the first row in the DGV
                            {
                                // Create a row so we can clone it then alter its properties, before clearing the rows and adding it again

                                if (splitElements.Count() == 5)
                                {
                                    dgv_customLocations.Rows.Add("", "", "", "");

                                    DataGridViewRow newRow = (DataGridViewRow)dgv_customLocations.Rows[0].Clone();

                                    dgv_customLocations.Rows.Clear();

                                    newRow.Cells[0].Value = splitElements[0];
                                    newRow.Cells[1].Value = splitElements[1];
                                    newRow.Cells[2].Value = splitElements[2];
                                    newRow.Cells[3].Value = splitElements[3];
                                    newRow.Cells[4].Value = splitElements[4];

                                    newRow.Visible = true;

                                    dgv_customLocations.Rows.Add(newRow);
                                }
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void configurecustomLocations_Load(object sender, EventArgs e)
        {
            renderDGV();
        }

        private void b_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void b_addupdateLocation_Click(object sender, EventArgs e)
        {
            if (tb_customLocation.Text != "" && tb_fileMask.Text != "" && tb_logCategory.Text != "" && tb_logProduct.Text != "")
            {
                try
                {
                    string[] customlogLocations = (string[])getregkeyValue("", "HKEY_CURRENT_USER", @"SOFTWARE\SMSMarshall\LogLauncher", "CustomLogLocations");

                    bool updatedTrigger = false;

                    // Does entry already exist, update it

                    List<string> writebackList = new List<string>();

                    if (customlogLocations != null)
                    {
                        foreach (string customlogLocation in customlogLocations)
                        {
                            try
                            {
                                string[] splitElements = customlogLocation.Split('|');

                                string newcustomlogLocation = customlogLocation;

                                if (splitElements[0] == tb_customLocation.Text) // Found a match
                                {
                                    updatedTrigger = true;

                                    newcustomlogLocation = tb_customLocation.Text + "|" + tb_fileMask.Text + "|" + Convert.ToString(cb_recurseFolder.Text) + "|" + tb_logCategory.Text + "|" + tb_logProduct.Text;
                                }

                                if (newcustomlogLocation != "" || newcustomlogLocation != null)
                                {
                                    writebackList.Add(newcustomlogLocation);
                                }
                            }
                            catch (Exception)
                            {

                            }
                        }


                        // Put the customLogLocations value back

                        if (!updatedTrigger)
                        {
                            writebackList.Add(tb_customLocation.Text + "|" + tb_fileMask.Text + "|" + Convert.ToString(cb_recurseFolder.Text) + "|" + tb_logCategory.Text + "|" + tb_logProduct.Text);
                        }
                    }
                    else
                    {
                        writebackList.Add(tb_customLocation.Text + "|" + tb_fileMask.Text + "|" + Convert.ToString(cb_recurseFolder.Text) + "|" + tb_logCategory.Text + "|" + tb_logProduct.Text);
                    }

                    try
                    {
                        RegistryKey hkcucustomLocations = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SMSMarshall\LogLauncher", true);

                        if (hkcucustomLocations != null)
                        {
                            hkcucustomLocations.SetValue("CustomLogLocations", writebackList.ToArray());
                        }
                    }
                    catch (Exception)
                    {

                    }

                    renderDGV();
                }
                catch (Exception)
                {

                }
            }
            else
            {
                notificationMessage("All fields must be populated");
            }
        }
    

        private void notificationMessage(string theMessage)
        {
            toolStripStatusLabel1.Text = theMessage;

            statusStrip1.Refresh();
        }

        private void dgv_customLocations_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection selectedRows = dgv_customLocations.SelectedRows;

                foreach (DataGridViewRow theRow in selectedRows)
                {
                    tb_customLocation.Text = (string)theRow.Cells[0].Value;
                    tb_fileMask.Text = (string)theRow.Cells[1].Value;
                    cb_recurseFolder.Text = (string)theRow.Cells[2].Value;
                    tb_logCategory.Text = (string)theRow.Cells[3].Value; ;
                    tb_logProduct.Text = (string)theRow.Cells[4].Value;
                }
            }
            catch (Exception)
            {

            }
        }

        private void b_deleteLocation_Click(object sender, EventArgs e)
        {
            if (tb_customLocation.Text != "")
            {
                try
                {
                    string[] customlogLocations = (string[])getregkeyValue("", "HKEY_CURRENT_USER", @"SOFTWARE\SMSMarshall\LogLauncher", "CustomLogLocations");

                    List<string> writebackList = new List<string>();

                    foreach (DataGridViewRow theRows in dgv_customLocations.SelectedRows)
                    {
                        foreach (string customlogLocation in customlogLocations)
                        {
                            string[] splitElements = customlogLocation.Split('|');

                            if (splitElements[0].ToLower() != theRows.Cells[0].Value.ToString().ToLower())
                            {
                                writebackList.Add(splitElements[0] + "|" + splitElements[1] + "|" + Convert.ToString(splitElements[2]) + "|" + splitElements[3] + "|" + splitElements[4]);
                            }
                        }
                    }

                    try
                    {
                        RegistryKey hkcucustomLocations = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SMSMarshall\LogLauncher", true);

                        if (hkcucustomLocations != null)
                        {
                            hkcucustomLocations.SetValue("CustomLogLocations", writebackList.ToArray());
                        }
                    }
                    catch (Exception)
                    {

                    }

                    renderDGV();
                }
                catch (Exception)
                {

                }
            }
            else
            {
                notificationMessage("Custom Location field has to be populated");
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
