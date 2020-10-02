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
using Accounting.Entity;
using Accounting.DataAccess;


namespace Accounting.UI
{
    public partial class frmChartsOfAccount : Form
    {
        public frmChartsOfAccount()
        {
            InitializeComponent();
        }
        SqlConnection conn = null;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadParentAccount(SqlConnection con)
        {
            SqlCommand com = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter("select * from T_Account", con);
            DataTable ds = new DataTable();
            DataTable dsa = new DataTable();

            da.Fill(ds);
            
            
            da.Dispose();
            cmbParent.DataSource = ds;
            cmbParent.DisplayMember = "AccountTitle";
            cmbParent.ValueMember = "AccountID";
            //cmbParentID.DataSource = ds;
            //cmbParentID.DisplayMember = "AccountID";
            //dgvAccount.DataSource = dsa;
            
           
        }
        private void LoadGridData(SqlConnection con)
        {
            SqlDataAdapter sqlda = new SqlDataAdapter("spShowGridData", con);
            DataTable ds = new DataTable();
            sqlda.Fill(ds);
            sqlda.Dispose();
            dgvAccount.DataSource = ds;
            dgvAccount.setColumnsVisible(false, "AccountID", "AccOrGroup", "AccDepth", "IsInventoryRelated", "HasDetailInfo","NatureID", "ParentID", "AccDTLID", "LedgerTypeID", "CountryID", "CurrencyID", "TeamID");
            

         
            
            //dgvAccount.Columns[""
 
        }

        public  void frmChartsOfAccount_Load(object sender, EventArgs e)
        {
          
            
            try 
            {
                conn= ConnectionHelper.getConnection();

                LoadParentAccount(conn);
                LoadGridData(conn);
                LoadCountry(conn);
                LoadCurrency(conn);
                LoadLedger(conn);
                LoadTeam(conn);
                CreateTree();
                grbCheck_VisibleChanged(null, null);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

            
        }

        private void frmChartsOfAccount_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(conn);
        }
        public Account CreateObject()
        {
            Account objAcc = new Account();
            objAcc.AccountID = int.Parse(txtAccountID.Text);
            objAcc.AccountNo = txtAccountNo.Text;
            
           

                objAcc.AccountTitle = txtAccountTitle.Text;

                objAcc.AccountDepth = 0;// int.Parse(txtDepth.Text);
            //objAcc.AccOrGroup =int.Parse( cmbAccountOrGroup.Text);
            if (txtOpeningBal.Text == "")
            {
                objAcc.OpeningBalance = 0;
            }
            else
            {

                objAcc.OpeningBalance = double.Parse(txtOpeningBal.Text);
            }
            if (txtCurrentBal.Text == "")
            {
                objAcc.CurrentBalance = 0;
            }
            else
            {
                objAcc.CurrentBalance = double.Parse(txtCurrentBal.Text);
            }
            

                
            
            if (chkInventoryRelated.Checked)
            {
                objAcc.IsInventoryRelated = 1;
            }
            else
            {
                objAcc.IsInventoryRelated = 0;
            }
            if (chkDetail.Checked)
            {
                objAcc.LedgerID = 1;
            }
            else
            {
                objAcc.LedgerID = 0;
            }
            
                objAcc.AccountNature = -1;
           
            objAcc.AccountOrGroup = cmbAccountOrGroup.Text;
            
            objAcc.ParentID =(int)cmbParent.SelectedValue;
            if (chkDetail.Checked)
            {
                flpDetail.Visible = true;
            }
            else
            {
                flpDetail.Visible = false;
            }
            return objAcc;
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (label20.Visible ==false)
            {
                return;
            }

            if (txtAccountTitle.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Currect Account Title");
                return;

            }
            if (cmbAccountOrGroup.Text.Trim() == "")
            {
                MessageBox.Show("Please Select Account/Group");
                return;
            }
            
            
                Account objAcc = new Account();
                Ledgers objDTL = new Ledgers();
                objAcc = CreateObject();
                //FormValidation();
                DaAccount objAccDA = new DaAccount();

                int dd = objAccDA.InsertUpdateAccount(objAcc, conn);
            
            
            
             
           

            if (chkDetail.Checked)
            {
               objDTL=CreateObjectDTL();
               objDTL.LedgerID = dd;
               string mode = txtAccID.Text.Trim() == "0" ? "add" : "edit";
                //objAccDA.SaveOrUpdateA_DTL(objDTL,mode,conn);

              
            }

            LoadGridData(conn);
            label20.Visible = false;
                MessageBox.Show(" Both Data Saved Successfully");
            CreateTree();
        }

        private void dgvAccount_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ab= e.RowIndex;
            txtAccountID.Text = dgvAccount.Rows[ab]. Cells["AccountID"].Value.ToString();
            txtAccountNo.Text = dgvAccount.Rows[ab].Cells["AccountNo"].Value.ToString();
            txtAccountTitle.Text = dgvAccount.Rows[ab].Cells["AccountTitle"].Value.ToString();
            txtCurrentBal.Text = dgvAccount.Rows[ab].Cells["CurrentBalance"].Value.ToString();
            txtOpeningBal.Text = dgvAccount.Rows[ab].Cells["OpeningBalance"].Value.ToString();
           
            cmbAccountOrGroup.Text = dgvAccount.Rows[ab].Cells["AccOrGroup"].Value.ToString();
            
            
            
             
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvAccount.CurrentRow == null)
            {
                MessageBox.Show("No Row Is Selected");
                return;
            }
           
                if (MessageBox.Show("Are You Sure To Delete The Selected Row", "VSLMessage", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            
            
            
            
                int ab = dgvAccount.CurrentRow.Index;
                if (dgvAccount.Rows[ab].Cells["AccountTitle"].Value.ToString() == "Income")
                {
                    MessageBox.Show("This is Primary Account,Not to be deleted");
                    return;
                }

                if (dgvAccount.Rows[ab].Cells["AccountTitle"].Value.ToString() == "Asset")
                {
                    MessageBox.Show("This is Primary Account,Not to be deleted");
                    return;
                }

                if (dgvAccount.Rows[ab].Cells["AccountTitle"].Value.ToString() == "Expense")
                {
                    MessageBox.Show("This is Primary Account,Not to be deleted");
                    return;
                }
            
                int accID = (int)dgvAccount.Rows[ab].Cells["AccountID"].Value;
                DaAccount objAccDA = new DaAccount();
                objAccDA.DeleteAccount(accID, conn);
                LoadGridData(conn);
            
        }

       
        private void CreateTree()
        {
           
            if (cmbParent.Text == "Primery Account")
            {
                tvAccount.Nodes.Add(txtAccountTitle.Text);
            }
            else
            {
                tvAccount.Nodes.Add(cmbParent.Text).Nodes.Add(txtAccountTitle.Text);

            }

            
        }

        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int ab = e.RowIndex;
            if (ab == -1)
            { return; }
            txtAccID.Text = dgvAccount.Rows[ab].Cells["AccDTLID"].Value.ToString();
            txtAccountID.Text = dgvAccount.Rows[ab].Cells["AccountID"].Value.ToString();
            txtAccountNo.Text = dgvAccount.Rows[ab].Cells["AccountNo"].Value.ToString();
            txtAccountTitle.Text = dgvAccount.Rows[ab].Cells["AccountTitle"].Value.ToString();
            txtCurrentBal.Text = dgvAccount.Rows[ab].Cells["CurrentBalance"].Value.ToString();
            txtOpeningBal.Text = dgvAccount.Rows[ab].Cells["OpeningBalance"].Value.ToString();
            //txtDepth.Text = dgvAccount.Rows[ab].Cells["AccDepth"].Value.ToString();
            cmbAccountOrGroup.Text = dgvAccount.Rows[ab].Cells["AccOrGroup"].Value.ToString();
            //cmbNature.Text = dgvAccount.Rows[ab].Cells["Nature"].Value.ToString();
            //cmbParentID.Text = dgvAccount.Rows[ab].Cells["ParentID"].Value.ToString();
            if (dgvAccount.Rows[ab].Cells["CountryID"].Value != null && dgvAccount.Rows[ab].Cells["CountryID"].Value.ToString() != "")
                cmbCountry.SelectedValue = (int)dgvAccount.Rows[ab].Cells["CountryID"].Value;

            chkDetail.Checked =(int) dgvAccount.Rows[ab].Cells["HasDetailInfo"].Value ==1?true:false ;

            
            cmbCurrency.Text = dgvAccount.Rows[ab].Cells["CurrencyID"].Value.ToString();
            cmbTeam.Text = dgvAccount.Rows[ab].Cells["TeamID"].Value.ToString();
            cmbLedgerType.Text = dgvAccount.Rows[ab].Cells["LedgerTypeID"].Value.ToString();
            txtAddress.Text = dgvAccount.Rows[ab].Cells["Address"].Value.ToString();
            txtConPerson.Text = dgvAccount.Rows[ab].Cells["ContactPerson"].Value.ToString();
            txtContactNo.Text = dgvAccount.Rows[ab].Cells["ContactNo"].Value.ToString();
            txtBussinessType.Text = dgvAccount.Rows[ab].Cells["BusinessType"].Value.ToString();
            txtPhone.Text = dgvAccount.Rows[ab].Cells["Phone"].Value.ToString();
            txtFax.Text = dgvAccount.Rows[ab].Cells["Fax"].Value.ToString();
            txtEmail.Text = dgvAccount.Rows[ab].Cells["Email"].Value.ToString();
            txtWeb.Text = dgvAccount.Rows[ab].Cells["Web"].Value.ToString();
            txtRemarks.Text = dgvAccount.Rows[ab].Cells["Remarks"].Value.ToString();
            label20.Visible = false;
              

        }
        private void LoadCountry(SqlConnection con)

        {
            SqlDataAdapter da = new SqlDataAdapter("select * from ERP.dbo.Country", con);
            DataTable ds = new DataTable();
            da.Fill(ds);
            da.Dispose();
            cmbCountry.DataSource = ds;
            cmbCountry.DisplayMember = "CountryName";
            cmbCountry.ValueMember = "CountryID";

        }
        private void LoadCurrency(SqlConnection con)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from ERP.dbo.Currency",con);
            DataTable ds = new DataTable();
            da.Fill(ds);
            da.Dispose();
            cmbCurrency.DataSource = ds;
            cmbCurrency.DisplayMember = "Name";
            cmbCurrency.ValueMember = "CurrencyID";
        }
        private void LoadLedger(SqlConnection con)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from T_LedgerType", con);
            DataTable ds = new DataTable();
            da.Fill(ds);
            da.Dispose();
            cmbLedgerType.DataSource = ds;
            cmbLedgerType.DisplayMember = "LedgerType";
            cmbLedgerType.ValueMember = "LedgerTypeID";
        }
        private void LoadTeam(SqlConnection con)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from T_Team_Master", con);
            DataTable ds = new DataTable();
            //DaTeam objTeamDA = new DaTeam();
            da.Fill(ds);
            da.Dispose();
            cmbTeam.DataSource = ds;
            cmbTeam.DisplayMember = "TeamName";
            cmbTeam.ValueMember = "TeamID";
        }

        private void chkDetail_CheckedChanged(object sender, EventArgs e)
        {
            flpDetail.Visible = chkDetail.Checked;
        }
        private Ledgers CreateObjectDTL()
        {
            Ledgers objAccDTL = new Ledgers();
            //objAccDTL.AccountID = int.Parse(txtAccID.Text);
            objAccDTL.LedgerTypeID = (int)cmbLedgerType.SelectedValue;
            objAccDTL.Address = txtAddress.Text;
            objAccDTL.CountryID=(int)cmbCountry.SelectedValue;
            objAccDTL.CurrencyID = (int)cmbCurrency.SelectedValue;
            objAccDTL.ContactPerson = txtConPerson.Text;
            objAccDTL.BankAccountType = txtContactNo.Text;
            objAccDTL.BusinessType = txtBussinessType.Text;
            objAccDTL.Phone = txtPhone.Text;
            objAccDTL.Fax = txtFax.Text;
            objAccDTL.Email = txtEmail.Text;
            //objAccDTL.Web = txtWeb.Text;
            objAccDTL.TeamMemberID = (int)cmbTeam.SelectedValue;
            objAccDTL.Remarks = txtRemarks.Text;
            return objAccDTL;
        }

        private void dgvAccount_SelectionChanged(object sender, EventArgs e)
        {
            int ab = dgvAccount.CurrentRow.Index;
            txtAccID.Text = dgvAccount.Rows[ab].Cells["AccDTLID"].Value.ToString();
            txtAccountID.Text = dgvAccount.Rows[ab].Cells["AccountID"].Value.ToString();
            txtAccountNo.Text = dgvAccount.Rows[ab].Cells["AccountNo"].Value.ToString();
            txtAccountTitle.Text = dgvAccount.Rows[ab].Cells["AccountTitle"].Value.ToString();
            txtCurrentBal.Text = dgvAccount.Rows[ab].Cells["CurrentBalance"].Value.ToString();
            txtOpeningBal.Text = dgvAccount.Rows[ab].Cells["OpeningBalance"].Value.ToString();
            //txtDepth.Text = dgvAccount.Rows[ab].Cells["AccDepth"].Value.ToString();
            cmbAccountOrGroup.Text = dgvAccount.Rows[ab].Cells["AccOrGroup"].Value.ToString();
            //cmbNature.Text = dgvAccount.Rows[ab].Cells["Nature"].Value.ToString();
            //cmbParentID.Text = dgvAccount.Rows[ab].Cells["ParentID"].Value.ToString();
            if (dgvAccount.Rows[ab].Cells["CountryID"].Value != null && dgvAccount.Rows[ab].Cells["CountryID"].Value.ToString() != "")

                cmbCountry.SelectedValue = (int)dgvAccount.Rows[ab].Cells["CountryID"].Value;
            cmbCurrency.Text = dgvAccount.Rows[ab].Cells["CurrencyID"].Value.ToString();
            cmbTeam.Text = dgvAccount.Rows[ab].Cells["TeamID"].Value.ToString();
            cmbLedgerType.Text = dgvAccount.Rows[ab].Cells["LedgerTypeID"].Value.ToString();
            txtAddress.Text = dgvAccount.Rows[ab].Cells["Address"].Value.ToString();
            txtConPerson.Text = dgvAccount.Rows[ab].Cells["ContactPerson"].Value.ToString();
            txtContactNo.Text = dgvAccount.Rows[ab].Cells["ContactNo"].Value.ToString();
            txtBussinessType.Text = dgvAccount.Rows[ab].Cells["BusinessType"].Value.ToString();
            txtPhone.Text = dgvAccount.Rows[ab].Cells["Phone"].Value.ToString();
            txtFax.Text = dgvAccount.Rows[ab].Cells["Fax"].Value.ToString();
            txtEmail.Text = dgvAccount.Rows[ab].Cells["Email"].Value.ToString();
            txtWeb.Text = dgvAccount.Rows[ab].Cells["Web"].Value.ToString();
            txtRemarks.Text = dgvAccount.Rows[ab].Cells["Remarks"].Value.ToString();
              

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }
        public void RefreshForm()
        {
            txtAccID.Text = "0";
            txtAccountID.Text = "0";
            txtAccountNo.Text = "";
            txtAccountTitle.Text = "";
            txtAddress.Text = "";
            txtOpeningBal.Text = "";
            txtCurrentBal.Text = "";
            cmbAccountOrGroup.Text = "";
           // cmbNature.Text = "";

            //txtDepth.Text = "";
            txtConPerson.Text = "";
            txtContactNo.Text = "";
            txtBussinessType.Text = "";
            txtPhone.Text = "";
            txtFax.Text = "";
            txtEmail.Text = "";
            txtWeb.Text = "";
            txtAddress.Text = "";
            txtRemarks.Text = "";
            chkDetail.Checked = false;
            chkInventoryRelated.Checked = false;
            
        }

        private void txtAccountTitle_TextChanged(object sender, EventArgs e)
        {
            label20.Visible = true;
        }

        private void grbCheck_VisibleChanged(object sender, EventArgs e)
        {
            if (flpDetail.Visible == false)
                dgvAccount.Height = flowLayoutPanel1.Height-10;
            else
                dgvAccount.Height = flowLayoutPanel1.Height - flpDetail.Height - 10; 
        }

        private void txtAccountTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.SelectNextControl((Control)sender, true, true, true, true);
        }

        private void cmbParent_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }

        private void chkInventoryRelated_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.SelectNextControl((Control)sender, true, true, true, true);
        }

        private void chkInventoryRelated_Enter(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            chk.ForeColor = Color.Blue;
        }

        private void chkInventoryRelated_Leave(object sender, EventArgs e)
        {
             CheckBox chk = (CheckBox)sender;
            chk.ForeColor = Color.Black;
        
        }

        private void chkAccount_CheckedChanged(object sender, EventArgs e)
        {
            gbxAccInfo.Visible = chkAccount.Checked;
        }
        //private void FormValidation()
        //{
        //    Account objAcc = new Account();
        //    if (txtAccountTitle.Text == "")
        //    {
        //        MessageBox.Show("Please Enter Correct Account Title");
        //    }
        //    else
        //        return;
        //    if (txtOpeningBal.Text == "")
        //    {
        //        objAcc.Opening = 0;
        //    }
        //    if (txtCurrentBal.Text == "")
        //    {
        //        objAcc.Current = 0;
        //    }
        //}

       
       
        

        

        
       
       

        

        

       
    }
}
