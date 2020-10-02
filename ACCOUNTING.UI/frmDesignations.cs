using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Accounting.Entity;
using Accounting.Utility;
using Accounting.Reports;
using Accounting.DataAccess;

namespace Accounting.UI
{
    public partial class frmDesignations : Form
    {
        public frmDesignations()
        {
            InitializeComponent();
        }
        #region fields
        Designation _objDesignation = new Designation();
        DesignationDA _objDesignationBO = new DesignationDA();
        #endregion
        private void loadDesignations()
        {
            try
            {
                if (dgvDesination.Columns.Count != 0) dgvDesination.Columns.Clear();

                DataTable list = _objDesignationBO.getDesignationANDPayScale(0);
                dgvDesination.DataSource = list;
                dgvDesination.setColumnsWidth(170,170,170);

                dgvDesination.setColumnsVisible(false, "DesignationID");
                dgvDesination_SelectionChanged(null, null);
                

            }
            catch (Exception ex)
            {
                throw ex;
            }
         
           

        }
        private void frmFloor_Load(object sender, EventArgs e)
        {
            try
            {
                
                loadDesignations();
                FormColorClass.ColorControl(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmDesignation frm = new frmDesignation();
                frm.DoRefresh += new Refreshing(loadDesignations);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDesination.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Select any item to Edit");
                    return;
                }


                Designation objDesg = (Designation)_objDesignationBO.getDesignation(Convert.ToInt32(dgvDesination.SelectedRows[0].Cells["DesignationID"].Value))[0];
                frmDesignation frm = new frmDesignation();
                frm.DoRefresh += new Refreshing(loadDesignations);
                frm.ShowDialog(objDesg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDesination.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Select any item to Delete");
                    return;
                }
                if (MessageBox.Show("Are you sure to delete?", "Floor Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
               

                DesignationDA objDesgBO = new DesignationDA();
                objDesgBO.DeleteDesignation(Convert.ToInt32(dgvDesination.SelectedRows[0].Cells["DesignationID"].Value));
                loadDesignations();
                MessageBox.Show("Data Deleted Succesfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void lvwDesg_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (lvwDesignation.SelectedItems.Count == 0) return;
        //        lblCount.Text = "Record: " + (lvwDesignation.SelectedItems[0].Index + 1) + " of " + lvwDesignation.Items.Count;
        //    }
        //    catch (Exception ex)
        //    {
        //        new ExceptionAgent(ex).SaveError();
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void lvwDesg_DoubleClick(object sender, EventArgs e)
        {
            if (btnEdit.Visible == true) btnEdit_Click(sender, e);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    frmReportViewer frm = new frmReportViewer();
            //    CrystalDecisions.Shared.ParameterValues pvc = new CrystalDecisions.Shared.ParameterValues();
            //    CrystalDecisions.Shared.ParameterDiscreteValue pdv = new CrystalDecisions.Shared.ParameterDiscreteValue();

            //    pdv.Value = LogInInfo.CompanyID;
            //    pvc.Add(pdv);

            //    frm.rptDesignation = new rptDesignation();
            //    frm.ReportName = "Designation";
            //    frm.rptDesignation.DataDefinition.ParameterFields["@companyID"].ApplyCurrentValues(pvc);
            //    frm.ShowDialog();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }

        private void dgvDesination_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnEdit.Visible == true) btnEdit_Click(sender, e);
        }

        private void dgvDesination_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvDesination.SelectedRows.Count == 0) return;
                lblCount.Text = "Record: " + (dgvDesination.SelectedRows[0].Index + 1) + " of " + dgvDesination.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmDesignations_Paint(object sender, PaintEventArgs e)
        {
            FormColorClass.ColorForm(this, e);
        }

       
    }
}
