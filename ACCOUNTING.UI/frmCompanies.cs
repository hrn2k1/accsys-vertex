using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using Accounting.Controls;

using Accounting.Entity;
using Accounting.Utility;
using System.Data.SqlClient;
using Accounting.DataAccess;

namespace Accounting.UI
{
    public partial class frmCompanies : Form
    {
        #region Private fields
           
            private Company _objCompany = new Company();
            //private BusinessSubTypeBO _objBusinessSubTypeBO = new BusinessSubTypeBO();
            //private CurrencyBO _objCurrencyBO = new CurrencyBO();
            public Refreshing DoRefresh;
            private bool IsEdit = false;
        #endregion

        public frmCompanies()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (((User)(new DaUser().getUser(LogInInfo.UserID)[0])).Role != "SuperAdministrator")
                {
                    MessageBox.Show("You Must Be Super Administrator to Create a new Company");
                    return;

                }
                IsEdit = false;
                lvwCompany.Enabled = false;
                btnSave.Enabled = true;
                ClearSubList();
                gbxCompany.Enabled = true;
                _objCompany = new Company();
                txtCompanyName.Focus();
            }
            catch (Exception Ex)
            {
                
                MessageBox.Show(Ex.Message);
            }
        }

        private void frmCompanies_Load(object sender, EventArgs e)
        {
            try
            {
                loadBusinessType();

                loadCurrency();
                RefreshList();
                lvwCompany.Items[0].Selected = true;
                lvwCompany_SelectedIndexChanged(null, null);
                FormColorClass.ColorControl(this);
            }
            catch (Exception Ex)
            {
                //new ExceptionAgent(Ex).SaveError();
                MessageBox.Show(Ex.Message);
            }
        }


        private void RefreshList()
        {
            try
            {
                ArrayList list = new DaCompany().getCompany(0);

                lblTotalRecords.Text = "Total Records : " + list.Count;

                lvwCompany.Items.Clear();
                foreach (Company objCompany in list)
                {

                    ListViewItem oItem = new ListViewItem(objCompany.CompanyName);
                    lvwCompany.Items.Add(oItem);
                    oItem.Tag = objCompany;

                }
                Company objCompany1 = (Company)lvwCompany.Items[0].Tag;
                RefreshSubList(objCompany1);
                btnSave.Enabled = false;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        private void loadBusinessType()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("SELECT BusinessTypeID, Name FROM BusinessType WHERE CompanyID = " + LogInInfo.CompanyID.ToString(), ConnectionHelper.getConnection());
                da.Fill(dt);
                da.Dispose();
                cboBusinessType.DataSource = dt;
                cboBusinessType.DisplayMember = "Name";
                cboBusinessType.ValueMember = "BusinessTypeID";

                cboBusinessType_SelectedValueChanged(null, null);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        private void loadBusinessSubType(int numBTid)
        {
            try
            {
                string qstr = "SELECT BusinessSubTypeID, Name FROM BusinessSubType WHERE BusinessTypeID = " + numBTid.ToString();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(qstr, ConnectionHelper.getConnection());
                da.Fill(dt);
                da.Dispose();

                cboBusinessSubTypeID.DataSource = dt;

                cboBusinessSubTypeID.DisplayMember = "Name";
                cboBusinessSubTypeID.ValueMember = "BusinessSubTypeID";

            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        private void loadCurrency()
        {
            try
            {

                DataTable list =new  DaCurrency() .getCurrency(ConnectionHelper.getConnection());
                
                cboCurrencyID.DataSource = list;
                
                    cboCurrencyID.DisplayMember = "Name";
                    cboCurrencyID.ValueMember = "CurrencyID";
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void RefreshSubList(Company objCompany)
        {
            try
            {
                if (objCompany != null)
                {
                    txtCompanyName.Text = objCompany.CompanyName;
                    txtAddressLine1.Text = objCompany.AddressLine1;
                    txtAddressLine2.Text = objCompany.AddressLine2;
                    txtPhone.Text = objCompany.Phone;
                    txtFax.Text = objCompany.Fax;
                    txtWebSite.Text = objCompany.WebSite;
                    txtEmail.Text = objCompany.Email;

                    txtTradeLicense.Text = objCompany.TradeLicense;
                    txtTINno.Text = objCompany.TINno;
                    txtIRCNo.Text = objCompany.IRCNo;
                    txtERCNo.Text = objCompany.ERCNo;
                    txtVatregdNo.Text = objCompany.MembershipNo1;
                    txtBOIorFID.Text = objCompany.MembershipNo2;
                    txtContactPerson.Text = objCompany.ContactPerson;
                    txtContactPersonPhone.Text = objCompany.ContactPersonPhone;
                    //companylogo
                    picLogo.BackgroundImage = GlobalFunctions.toImage(objCompany.CompanyLogo);


                    if (objCompany.CompanyID != 0)
                    {
                        //if (cboBusinessType.Items.Count > 0 && objCompany.BusinessSubTypeID != 0)
                        //    cboBusinessType.SelectedValue = new BusinessSubTypeBO().getBusinessTypeID(objCompany.BusinessSubTypeID);
                        if (cboBusinessSubTypeID.Items.Count > 0 && objCompany.BusinessSubTypeID != 0)
                            cboBusinessSubTypeID.SelectedValue = objCompany.BusinessSubTypeID;

                        if (cboCurrencyID.Items.Count > 0 && objCompany.CurrencyID != 0)
                            cboCurrencyID.SelectedValue = objCompany.CurrencyID;

                    }
                }
                gbxCompany.Enabled = false;
                gbxCompany.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void ClearSubList()
        {
            try
            {
                txtCompanyName.Clear();
                txtAddressLine1.Clear();
                txtAddressLine2.Clear();
                txtPhone.Clear();
                txtFax.Clear();
                txtWebSite.Clear();
                txtEmail.Clear();

                txtTradeLicense.Clear();
                txtTINno.Clear();
                txtIRCNo.Clear();
                txtERCNo.Clear();
                txtVatregdNo.Clear();
                txtBOIorFID.Clear();
                txtContactPerson.Clear();
                txtContactPersonPhone.Clear();
                //companylogo
                picLogo.BackgroundImage = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwCompany.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Select any item to Edit");
                    return;
                }
                Company objCompany = (Company)lvwCompany.SelectedItems[0].Tag;
                _objCompany = objCompany;
                lvwCompany.Enabled = false;
                btnSave.Enabled = true;
                btnEdit.Enabled = false;
                gbxCompany.Enabled = true;
                txtCompanyName.Focus();
                IsEdit = true;
            }
            catch (Exception ex)
            {
                //new ExceptionAgent(ex).SaveError();
                MessageBox.Show(ex.Message);
            }
        }

        private void lvwCompany_DoubleClick(object sender, EventArgs e)
        {
            if (btnEdit.Visible == true) 
                btnEdit_Click(sender, e);
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwCompany.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Select any item to Delete");
                    return;
                }
                if (MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                Company objCompany = (Company)lvwCompany.SelectedItems[0].Tag;

                
                new DaCompany().Delete(objCompany.CompanyID);
                RefreshList();
                MessageBox.Show("Data Deleted Succesfully");
            }
            catch (Exception ex)
            {
                //new ExceptionAgent(ex).SaveError();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void RefreshObject()
        {
            try
            {
                _objCompany.CompanyName = txtCompanyName.Text.Trim();
                _objCompany.AddressLine1 = txtAddressLine1.Text.Trim();
                _objCompany.AddressLine2 = txtAddressLine2.Text.Trim();
                _objCompany.Phone = txtPhone.Text.Trim();
                _objCompany.Fax = txtFax.Text.Trim();
                _objCompany.WebSite = txtWebSite.Text.Trim();
                _objCompany.Email = txtEmail.Text.Trim();
                _objCompany.TradeLicense = txtTradeLicense.Text.Trim();
                _objCompany.TINno = txtTINno.Text.Trim();
                _objCompany.IRCNo = txtIRCNo.Text.Trim();
                _objCompany.ERCNo = txtERCNo.Text.Trim();
                _objCompany.MembershipNo1 = txtVatregdNo.Text.Trim();
                _objCompany.MembershipNo2 = txtBOIorFID.Text.Trim();
                _objCompany.ContactPerson = txtContactPerson.Text.Trim();
                _objCompany.ContactPersonPhone = txtContactPersonPhone.Text.Trim();
                if (cboBusinessSubTypeID.Items.Count > 0)
                    _objCompany.BusinessSubTypeID =(int) cboBusinessSubTypeID.SelectedValue;//((Data)cboBusinessSubTypeID.SelectedItem).BusinessSubTypeID;
                if (cboCurrencyID.Items.Count > 0)
                    _objCompany.CurrencyID =(int) cboCurrencyID.SelectedValue;
                _objCompany.CompanyLogo = picLogo.BackgroundImage == null ? null : GlobalFunctions.toBinary(picLogo.BackgroundImage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool ValidateInput()
        {
            if (txtCompanyName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter Company name");
                txtCompanyName.Focus();
                return false;
            }
            if (txtAddressLine1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter AddressLine1 name");
                txtAddressLine1.Focus();
                return false;
            }
            if (txtPhone.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter Phone");
                txtPhone.Focus();
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                    return;
                int pos = lvwCompany.SelectedItems[0].Index;
                RefreshObject();
                if (IsEdit == false)
                {
                    frmAdminstratorSetUp frmsuper = new frmAdminstratorSetUp();
                   frmsuper.ShowDialog();

                   if (frmsuper.sName == string.Empty && frmsuper.sPass == string.Empty) return;

        
                    SqlConnection con = null;
                    SqlCommand com = null;
                    SqlTransaction trans = null;

                    try
                    {
                        con = ConnectionHelper.getConnection();
                        trans = con.BeginTransaction();
                        com = new SqlCommand();

                        com.Connection = con;
                        com.Transaction = trans;

                        _objCompany.UserID = ConnectionHelper.GetID(con, trans, "UserID", "Users");
                        _objCompany.CompanyID = ConnectionHelper.GetID(con, trans, "CompanyID", "Company");
                            com.CommandType = CommandType.StoredProcedure;
                            com.CommandText = "spNewCompanyForAccountingSoftware";




                            com.Parameters.Add("@CompanyID", SqlDbType.Int).Value = _objCompany.CompanyID;
                            com.Parameters.Add("@CompanyName", SqlDbType.VarChar, 100).Value = _objCompany.CompanyName;
                            com.Parameters.Add("@SuperUserID", SqlDbType.Int).Value = _objCompany.UserID;
                            com.Parameters.Add("@SuperUserName", SqlDbType.VarChar, 100).Value = frmsuper.sName;
                            com.Parameters.Add("@SuperPassword", SqlDbType.NVarChar, 100).Value = GlobalFunctions.Encode(frmsuper.sPass, GlobalFunctions.CypherText);

                        com.ExecuteNonQuery();



                        trans.Commit();
                        ConnectionHelper.closeConnection(con);
                    }
                    catch (Exception Ex)
                    {
                        if (trans != null)
                        {
                            trans.Rollback();
                        }
                        throw new Exception("Can not save or update" + Ex.Message);

                    }

                    

                }
                new DaCompany().SaveOrUpdate(_objCompany);
                MessageBox.Show("Data Saved Successfully");

                _objCompany = new Company();

                if (DoRefresh != null)
                {
                    DoRefresh();
                }
                RefreshList();
                lvwCompany.Enabled = true;
                btnSave.Enabled = false;
                gbxCompany.Enabled = false;
                btnEdit.Enabled = true;
                 lvwCompany.Items[pos].Selected=true;
                 IsEdit = false;
            }
            catch (Exception Ex)
            {
               // new ExceptionAgent(Ex).SaveError();
                MessageBox.Show(Ex.Message);
            }


        }

        private void lvwCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lvwCompany.SelectedItems.Count == 0) return;

                Company objCompany = (Company)lvwCompany.SelectedItems[0].Tag;

                RefreshSubList(objCompany);
                FormColorClass.ColorControl(this);
            }
            catch (Exception ex)
            {
                //new ExceptionAgent(ex).SaveError();
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                string strFileName = "";
                OpenFileDialog openFileDlg = new OpenFileDialog();
                openFileDlg.Filter = "Jpeg Files|*.Jpeg;*.Jpg";

                if (openFileDlg.ShowDialog() == DialogResult.OK)
                {
                    strFileName = openFileDlg.FileName;
                    picLogo.BackgroundImage = Image.FromFile(strFileName);

                    SelectNextControl((Control)sender, true, true, true, true);
                }
            }
            catch (Exception ex)
            {
               // new ExceptionAgent(ex).SaveError();
                MessageBox.Show(ex.Message);
            }
        }

        private void cboBusinessType_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboBusinessType.SelectedValue == null || cboBusinessType.SelectedValue.GetType() == typeof(DataRowView)) return;
                if (cboBusinessType.SelectedValue != null)
                    loadBusinessSubType((int)cboBusinessType.SelectedValue);
                else
                    loadBusinessSubType(-1);
            }
            catch (Exception ex)
            {
               // new ExceptionAgent(ex).SaveError();
                MessageBox.Show(ex.Message);
            }
        }

        private void cboBusinessType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboBusinessType.SelectedValue == null || cboBusinessType.SelectedValue.GetType() == typeof(DataRowView)) return;
                if (cboBusinessType.Items.Count <= 0) return;
                if (cboBusinessType.SelectedValue == null) return;
                loadBusinessSubType((int)cboBusinessType.SelectedValue);
            }
            catch (Exception ex)
            {
               // new ExceptionAgent(ex).SaveError();
                MessageBox.Show(ex.Message);
            }
        }

        private void frmCompanies_Paint(object sender, PaintEventArgs e)
        {
            FormColorClass.ColorForm(this, e);
        }

        private void txt_Enter(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            c.BackColor = Color.Black;
            c.ForeColor = Color.White;
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            c.BackColor = Color.White;
            c.ForeColor = Color.Black;
        }

        private void cbo_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");
        }

        private void Ctl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SelectNextControl((Control)sender, true, true, true, true);
        }

       

       

       

        
    }
}
