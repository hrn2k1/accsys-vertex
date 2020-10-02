using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Accounting.UI
{
    public partial class frmAdminstratorSetUp : Form
    {
        public string sName = "";
        public string sPass = "";
        public frmAdminstratorSetUp()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if ((txtConfirmPass.Text.Trim() == txtPassword.Text.Trim()) && txtAdminName.Text.Trim() != "") { sName = txtAdminName.Text.Trim(); sPass = txtPassword.Text.Trim(); this.Close(); }
            else
            {
                MessageBox.Show("Either Super Administrator Name is not Given or Password does not match");
                sName = string.Empty;
                sPass = string.Empty;
                return;
            }
        }

        private void frmAdminstratorSetUp_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAdminName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtConfirmPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true); 
        }

        private void txtAdminName_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtConfirmPass_Enter(object sender, EventArgs e)
        {
            TextBox conl = (TextBox)sender;
            conl.BackColor = Color.Black;
            conl.ForeColor = Color.White;
            conl.SelectAll();
        }

        private void txtAdminName_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }

        private void txtConfirmPass_Leave(object sender, EventArgs e)
        {
            Control crl = (Control)sender;
            crl.ForeColor = Color.Black;
            crl.BackColor = Color.White;
        }
    }
}
