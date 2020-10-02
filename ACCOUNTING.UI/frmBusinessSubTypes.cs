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
using Accounting.Reports;
using CrystalDecisions.Shared;
using Accounting.DataAccess;

namespace Accounting.UI
{
    public partial class frmBusinessSubTypes : Form
    {

        #region Private fields
        BusinessSubTypeDA _objBusinessSubTypDA = new BusinessSubTypeDA();
        BusinessTypeDA _objBusinessTypeDA = new BusinessTypeDA();
        
        #endregion

        public frmBusinessSubTypes()
        {
            InitializeComponent();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusinessSubType objForm = new frmBusinessSubType();
                objForm.DoRefresh += new Refreshing(RefreshList);
                objForm.ShowDialog(new BusinessSubType());
            }
            catch (Exception Ex)
            {
               // new ExceptionAgent(Ex).SaveError();
                MessageBox.Show(Ex.Message);
            }
        }

        private void frmBusinessSubTypes_Load(object sender, EventArgs e)
        {
            try
            {

                RefreshList();
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
                ArrayList list = _objBusinessSubTypDA.getBusinessSubType(0);

                lblTotalRecords.Text = "Total Records : " + list.Count;

                lvwBusinessSubType.Items.Clear();
                foreach (BusinessSubType objBusinessSubType in list)
                {
                    ListViewItem oItem = new ListViewItem(objBusinessSubType.Name);
                    BusinessType objBusinessType = (BusinessType)_objBusinessTypeDA.getBusinessType(objBusinessSubType.BusinessTypeID)[0];
                    oItem.SubItems.Add(objBusinessType.Name);
                    lvwBusinessSubType.Items.Add(oItem);
                    oItem.Tag = objBusinessSubType;

                }
            }
            catch (Exception Ex)
            {
               // new ExceptionAgent(Ex).SaveError();
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwBusinessSubType.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Select any item to Edit");
                    return;
                }
                BusinessSubType objBusinessSubType = (BusinessSubType)lvwBusinessSubType.SelectedItems[0].Tag;
                frmBusinessSubType oform = new frmBusinessSubType();
                oform.DoRefresh += new Refreshing(RefreshList);
                oform.ShowDialog(objBusinessSubType);
            }
            catch (Exception Ex)
            {
               // new ExceptionAgent(Ex).SaveError();
                MessageBox.Show(Ex.Message);
            }
        }

        private void lvwBusinessSubType_DoubleClick(object sender, EventArgs e)
        {
            if (btnEdit.Visible == true) 
                btnEdit_Click(sender, e);
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwBusinessSubType.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Select any item to Delete");
                    return;
                }
                if (MessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                BusinessSubType objBusinessSubType = (BusinessSubType)lvwBusinessSubType.SelectedItems[0].Tag;

                _objBusinessSubTypDA.Delete(objBusinessSubType.BusinessSubTypeID);
                RefreshList();
                MessageBox.Show("Data Deleted Succesfully");
            }
            catch (Exception Ex)
            {
              //  new ExceptionAgent(Ex).SaveError();
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void frmBusinessSubTypes_Paint(object sender, PaintEventArgs e)
        {

            FormColorClass.ColorForm(this, e);
        }


       

    }
}
