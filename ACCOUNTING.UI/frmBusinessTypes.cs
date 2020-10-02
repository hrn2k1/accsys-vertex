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
    public partial class frmBusinessTypes : Form
    {
        #region Private fields
        BusinessTypeDA _objBusinessTypeDA = new BusinessTypeDA();
        #endregion

        public frmBusinessTypes()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusinessType objForm = new frmBusinessType();
                objForm.DoRefresh += new Refreshing(RefreshList);
                objForm.ShowDialog();
            }
            catch (Exception Ex)
            {
               // new ExceptionAgent(Ex).SaveError();
                MessageBox.Show(Ex.Message);
            }
        }

        private void frmBusinessTypes_Load(object sender, EventArgs e)
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
                ArrayList list = _objBusinessTypeDA.getBusinessType(0);

                lblTotalRecords.Text = "Total Records : " + list.Count;

                lvwBusinessType.Items.Clear();
                foreach (BusinessType objBusinessType in list)
                {
                    ListViewItem oItem = new ListViewItem(objBusinessType.Name);
                    lvwBusinessType.Items.Add(oItem);
                    oItem.Tag = objBusinessType;

                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwBusinessType.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Select any item to Edit");
                    return;
                }
                BusinessType objBusinessType = (BusinessType)lvwBusinessType.SelectedItems[0].Tag;
                frmBusinessType oform = new frmBusinessType();
                oform.DoRefresh += new Refreshing(RefreshList);
                oform.ShowDialog(objBusinessType);
            }
            catch (Exception Ex)
            {
                //new ExceptionAgent(Ex).SaveError();
                MessageBox.Show(Ex.Message);
            }
        }

        private void lvwBusinessType_DoubleClick(object sender, EventArgs e)
        {
            if (btnEdit.Visible == true) 
                btnEdit_Click(sender, e);
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvwBusinessType.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Select any item to Delete");
                    return;
                }


                if (MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No) return;

                BusinessType objBusinessType = (BusinessType)lvwBusinessType.SelectedItems[0].Tag;

                BusinessTypeDA objBusinessTypeDA = new BusinessTypeDA();
                objBusinessTypeDA.Delete(objBusinessType.BusinessTypeID);
                RefreshList();
                MessageBox.Show("Data Deleted Succesfully");
            }
            catch (Exception Ex)
            {
               // new ExceptionAgent(Ex).SaveError();
                MessageBox.Show(Ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void frmBusinessTypes_Paint(object sender, PaintEventArgs e)
        {

            FormColorClass.ColorForm(this, e);
        }

        
    }
}
