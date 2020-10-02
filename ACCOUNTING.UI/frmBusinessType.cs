using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using Accounting.Controls;

using Accounting.Entity;
using Accounting.Utility;
using Accounting.DataAccess;


namespace Accounting.UI
{
    public partial class frmBusinessType : Form
    {
        #region Member fields
        private BusinessType _objBusinessType = new BusinessType();
        private BusinessTypeDA _objBusinessTypeDA = new BusinessTypeDA();
        public Refreshing DoRefresh;
        public bool _bCancel = false;
        #endregion

        public frmBusinessType()
        {
            InitializeComponent();
        }

        public void ShowDialog(BusinessType objBusinessType)
        {
            try
            {
                _objBusinessType = objBusinessType;
                RefreshValue();
                _bCancel = objBusinessType.BusinessTypeID != 0;
                this.ShowDialog();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private void RefreshValue()
        {
            try
            {
                txtName.Text = _objBusinessType.Name;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private void RefreshObject()
        {
            try
            {
                _objBusinessType.Name = txtName.Text.Trim();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
        private bool ValidateInput()
        {
            if (txtName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter BusinessType name");
                txtName.Focus();
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
                RefreshObject();
                _objBusinessTypeDA.SaveOrUpdate(_objBusinessType);
                MessageBox.Show("Data Saved Successfully");

                _objBusinessType = new BusinessType();

                if (DoRefresh != null)
                {
                    DoRefresh();
                }
                RefreshValue();

                if (_bCancel == true)
                {
                    this.Close();
                }
                txtName.Focus();
            }
            catch (Exception Ex)
            {
               // new ExceptionAgent(Ex).SaveError();
                MessageBox.Show(Ex.Message);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBusinessType_Load(object sender, EventArgs e)
        {
            FormColorClass.ColorControl(this);
        }

        private void frmBusinessType_Paint(object sender, PaintEventArgs e)
        {

            FormColorClass.ColorForm(this, e);
        }

       

    }
}
