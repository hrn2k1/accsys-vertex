using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accounting.Utility;
using Accounting.Entity;

using Accounting.Controls;
using Accounting.DataAccess;

namespace Accounting.UI
{
    public partial class frmDesignation : Form
    {
        private Designation _objDesg = new Designation();
        private DesignationDA _objDesgBO = new DesignationDA();
        //private PayScaleTypeBO _objPayScaleTypeBO = new PayScaleTypeBO();
        //private PayScale _objPayScale = new PayScale();
        //private PayScaleBO _objPayScaleBO = new PayScaleBO();
        private string _strPayScaleTypeName = "";
       
        public Refreshing DoRefresh;

        public frmDesignation()
        {
            InitializeComponent();
        }
      
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ShowDialog(Designation objDesg)
        {
            try
            {
                _objDesg = objDesg;
                //_objPayScale = (PayScale)_objPayScaleBO.getPayScale(_objDesg.PayScaleID)[0];
                //_strPayScaleTypeName = ((PayScaleType)_objPayScaleTypeBO.getPayScaleType(_objPayScale.PayScaleTypeID)[0]).PayScaleTypeName;
                RefreshValue();
                gbxDesg.Text = "Edit Designation";
                btnSearch.ForeColor = Color.Black;
                this.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool ValidateInput()
        {
            if (lblName.ForeColor == Color.Red)
            {
                MessageBox.Show("Please enter designation", "Designation Manager");
                txtName.Focus();
                return false;
            }
            //if (btnSearch.ForeColor == Color.Red)
            //{
            //    MessageBox.Show("Please select PayScale using Button", "Designation Manager");
            //    btnSearch.Focus();
            //    return false;
            //}
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (!ValidateInput()) return;
                RefreshObject();
                _objDesgBO.SaveUpdateDesignation (_objDesg );
                MessageBox.Show("Data Saved Successfully");

                _objDesg = new Designation();

                if (DoRefresh != null)
                {
                    DoRefresh();
                }
                RefreshValue();
                if (gbxDesg.Text == "Edit Designation")
                    this.Close();
                txtName.Focus();
               
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }
        private void RefreshObject()
        {
            try
            {
                _objDesg.DesignationName = txtName.Text.Trim();
                _objDesg.PayScaleID = 0;  //txtDesc.Text.Trim();
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
                txtName.Text = _objDesg.DesignationName;
                //txtDesc.Text = _objDesg.PayScaleTypeID  ;
                //cboPayScaleType.SelectedValue = _objDesg.PayScaleTypeID;
                lblPSTSelected.Text = _strPayScaleTypeName;
                //utxtGrade.Value = _objPayScale.GradeOrScale;
                //chkIsGross.Checked = (_objPayScale.IsByGross == YesNo.Yes ? true : false);
                //lblInitalAmount.Text = _objPayScale.InitialPay.ToString();
                //lblLastAmount.Text = _objPayScale.LastPay.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                lblName.ForeColor = Color.Red;

            }
            else
            {
                lblName.ForeColor = Color.Black ;
            }
        }

        //private void loadPayScaleTypes()
        //{
        //    try
        //    {
        //        ArrayList list = _objPayScaleTypeBO.getPayScaleType(0);

        //        cboPayScaleType.DisplayMember = "PayScaleTypeName";
        //        cboPayScaleType.ValueMember = "PayScaleTypeID";
        //        cboPayScaleType.DataSource = list;
        //        if (_objDesg.DesignationID != 0)
        //        {
        //            cboPayScaleType.SelectedValue = _objDesg.PayScaleTypeID;

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        private void frmDesignation_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    loadPayScaleTypes();
            //}
            //catch (Exception ex)
            //{
            //    new ExceptionAgent(ex).SaveError();
            //    MessageBox.Show(ex.Message);
            //}
            FormColorClass.ColorControl(this);
        }

        //private void lnkPayscaleType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    try
        //    {
        //        frmPayScaleTypes frm = new frmPayScaleTypes();
        //        frm.ShowDialog();
        //    }
        //    catch (Exception ex)
        //    {
        //        new ExceptionAgent(ex).SaveError();
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void frmDesignation_Activated(object sender, EventArgs e)
        {
            //try
            //{
            //    loadPayScaleTypes();
            //}
            //catch (Exception ex)
            //{
            //    new ExceptionAgent(ex).SaveError();
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //frmSearchGrade frm = new frmSearchGrade();
            //frm.DesignationVisible = false;
            //frm.ShowDialog();
            //_objPayScale = frm.PayScale;
            //_strPayScaleTypeName = frm.PayScaleTypeName;
            //if (_objPayScale.PayScaleID != 0)
            //    btnSearch.ForeColor = Color.Black;
            //else btnSearch.ForeColor = Color.Red;
            //RefreshObject();
            //RefreshValue();
            
        }

        private void chkIsGross_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsGross.Checked)
            {
                lblInitialPay.Text = "Initial Gross";
                lblLastPay.Text = "Last  Gross";
            }
            else
            {
                lblInitialPay.Text = "Initial Basic";
                lblLastPay.Text = "Last  Basic";
            }
        }

        private void frmDesignation_Paint(object sender, PaintEventArgs e)
        {
            FormColorClass.ColorForm(this, e);
        }
    }
}
