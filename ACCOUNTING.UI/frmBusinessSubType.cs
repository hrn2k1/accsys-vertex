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
using Accounting.DataAccess;

namespace Accounting.UI
{
    public partial class frmBusinessSubType : Form
    {

        #region Member fields
        private BusinessSubType _objBusinessSubType = new BusinessSubType();
        private BusinessSubTypeDA _objBusinessSubTypeDA = new BusinessSubTypeDA();
        private BusinessTypeDA _objBusinessTypeDA = new BusinessTypeDA();
        public Refreshing DoRefresh;
        public bool _bCancel = false;
        #endregion
         
        public frmBusinessSubType()
        {
            InitializeComponent();
        }

        public void ShowDialog(BusinessSubType objBusinessSubType)
        {
            try
            {
                _objBusinessSubType = objBusinessSubType;
                RefreshValue();

                _bCancel = _objBusinessSubType.BusinessSubTypeID != 0;

                this.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void RefreshValue()
        {
            try
            {
                txtName.Text = _objBusinessSubType.Name;
                RefreshCbo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RefreshCbo()
        {
            try
            {
                ArrayList list = _objBusinessTypeDA.getBusinessType(0);
                
                cboBusinessType.DataSource = list;
                if (list.Count > 0)
                {
                    cboBusinessType.DisplayMember = "Name";
                    cboBusinessType.ValueMember = "BusinessTypeID";
                }


                if (_objBusinessSubType.BusinessSubTypeID != 0)
                {
                    cboBusinessType.SelectedValue = _objBusinessSubType.BusinessTypeID;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RefreshObject()
        {
            try
            {
                _objBusinessSubType.Name = txtName.Text.Trim();
                _objBusinessSubType.BusinessTypeID = ((BusinessType)cboBusinessType.SelectedItem).BusinessTypeID;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private bool ValidateInput()
        {
            if (txtName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter BusinessSubType name");
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
                _objBusinessSubTypeDA.SaveOrUpdate(_objBusinessSubType);
                MessageBox.Show("Data Saved Successfully");

                _objBusinessSubType = new BusinessSubType();

                if (DoRefresh != null)
                {
                    DoRefresh();
                }
                RefreshValue();

                if (_bCancel == true)
                {
                    this.Close();
                }
                cboBusinessType.Focus();
            }
            catch (Exception Ex)
            {
                //new ExceptionAgent(Ex).SaveError();
                MessageBox.Show(Ex.Message);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBusinessSubType_Load(object sender, EventArgs e)
        {
            FormColorClass.ColorControl(this);
        }

        private void frmBusinessSubType_Paint(object sender, PaintEventArgs e)
        {

            FormColorClass.ColorForm(this, e);
        }

        
    }
}
