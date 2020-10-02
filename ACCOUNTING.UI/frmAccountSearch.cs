using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Accounting.Utility;
using Accounting.DataAccess;
using Accounting.Entity;

namespace Accounting.UI
{
    public partial class frmAccountSearch : Form
    {
        public frmAccountSearch()
        {
            InitializeComponent();
        }
        private string filterExpr = string.Empty;
        int PreSelectedAccID = 0;
        public Account SelectedAccount = null;
        SqlConnection formCon=null;
        BindingSource bcAccounts = null;
        DataTable dtAccount = null;
        private void frmAccountSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) this.Close();
            
        }

        private void frmAccountSearch_Load(object sender, EventArgs e)
        {
            try
            {
                formCon = ConnectionHelper.getConnection();
                loadAccounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ShowDialog(string FilterExpression)
        {
            this.filterExpr = FilterExpression;
            this.ShowDialog();
        }
        public void ShowDialog(string FilterExpression,int PreSelectedAccountID)
        {
            this.filterExpr = FilterExpression;
            this.PreSelectedAccID = PreSelectedAccountID;
            this.ShowDialog();
        }
        public void ShowDialog( int PreSelectedAccountID)
        {
           
            this.PreSelectedAccID = PreSelectedAccountID;
            this.ShowDialog();
        }
        private void loadAccounts()
        {
            try
            {
                dtAccount = new DaAccount().GetAccounts(formCon, "AccountID,AccountNo,AccountTitle,CurrentBalance,Parent", this.filterExpr, "AccountTitle");
                bcAccounts = new BindingSource();
                bcAccounts.DataSource = dtAccount;
                ctldgvAccounts.DataSource = bcAccounts;
                ctldgvAccounts.Columns["AccountID"].Visible = false;
                //ctlDaraGridView1.Columns["AccountTitle"].Width = 300;
                ctldgvAccounts.Columns["CurrentBalance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                ctldgvAccounts.Columns["CurrentBalance"].DefaultCellStyle.Format = "0.00";
                bcAccounts.Position = bcAccounts.Find("AccountID", PreSelectedAccID.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txtSearchAc_TextChanged(object sender, EventArgs e)
        {
            //bcAccounts.Position = bcAccounts.Find("AccountTitle", txtSearchAc.Text.Trim());
            bcAccounts.Position = PositionOf(txtSearchAc.Text.Trim());
        }
        private int PositionOf(string str)
        {
            int i, nR;
            int strL=str.Length;
            string curRowAcc;
            nR = ctldgvAccounts.Rows.Count;

            for (i = 0; i < nR; i++)
            {
               curRowAcc= ctldgvAccounts.Rows[i].Cells["AccountTitle"].Value.ToString().ToLower();
               if (strL > curRowAcc.Length) continue;
               if (str.ToLower() == curRowAcc.Substring(0, strL))

                    return i;
            }

            return bcAccounts.Position;
        }
        private void txtSearchAc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                bcAccounts.Position -= 1;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                bcAccounts.Position += 1;
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Enter) btnOK_Click(null, null);
            if (e.KeyCode == Keys.Escape) btnCancel_Click(null, null);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                SelectedAccount = new Account();

                DataRowView Dr = (DataRowView)bcAccounts.Current;
                SelectedAccount = new DaAccount().GetAccount(formCon, Dr.Row.Field<int>("AccountID"));
                //SelectedAccount.AccountID = Dr.Row.Field<int>("AccountID");
                //SelectedAccount.AccountTitle = Dr.Row.Field<string>("AccountTitle");
                //SelectedAccount.AccountNo = Dr.Row.Field<string>("AccountNo");
                //SelectedAccount.LedgerID=Dr.Row.fi
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SelectedAccount = null;
            this.Close();
        }

        private void ctldgvAccounts_Enter(object sender, EventArgs e)
        {
            txtSearchAc.Focus();
        }

        private void ctldgvAccounts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnOK_Click(null, null);
        }

        private void frmAccountSearch_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                FormColorClass.ColorForm(this, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ctldgvAccounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
