using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using Accounting.Utility;

namespace Accounting.UI
{
    public partial class frmBackup : Form
    {
        public frmBackup()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            sfBackupFile.FileName = (rbERP.Checked? "ERP":"RTA") + DateTime.Now.ToString("ddMMyyyy");
            if (sfBackupFile.ShowDialog() == DialogResult.OK)

                txtBKfile.Text = sfBackupFile.FileName;
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
           
            SqlConnection con = null;
            string qstr = "";
            try
            {
                //if (File.Exists(txtBKfile.Text) == false)
                //{
                //    MessageBox.Show("Invalid file name");
                //    return;
                //}
                con = ConnectionHelper.getConnection();

                qstr ="BACKUP DATABASE "+ (rbERP.Checked? con.Database:"RTA") + "  TO DISK = '"+txtBKfile.Text+"'  WITH FORMAT";
               
                SqlCommand cmd = new SqlCommand(qstr, con);
                cmd.CommandTimeout = 7200;
                //cmd.ExecuteNonQuery();
                prgbar.Visible = true;
                btnClose.Enabled = false;
                IAsyncResult result = cmd.BeginExecuteNonQuery();

                DateTime dt1 = DateTime.Now;
                while (!result.IsCompleted)
                {
                    if (prgbar.Value >= prgbar.Maximum)
                        dt1 = DateTime.Now;
                    TimeSpan t = DateTime.Now - dt1;

                    prgbar.Value = t.Hours * 3600 + t.Minutes * 60 + t.Seconds;

                }


                cmd.EndExecuteNonQuery(result);
                prgbar.Value = prgbar.Maximum;

              
                MessageBox.Show("Database Backup Complete Successfully", "DBA");

                prgbar.Visible = false;
                btnClose.Enabled = true;
            }
            catch (Exception ex)
            {
               
                MessageBox.Show(ex.Message);
                prgbar.Visible = false;
                btnClose.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmBackup_Paint(object sender, PaintEventArgs e)
        {
            FormColorClass.ColorForm(this, e);
        }
    }
}
