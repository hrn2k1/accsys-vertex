using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Accounting.Entity;
using Accounting.DataAccess;
using Accounting.Utility;

namespace Accounting.UI
{
    public partial class frmTeam : Form
    {
        public frmTeam()
        {
            InitializeComponent();
        }


        private SqlConnection formConnection=null;
        private DataTable dtMembers = new DataTable();
        
        //Form Loading
        private void frmTeam_Load(object sender, EventArgs e)
        {
            try
            {
            formConnection = ConnectionHelper.getConnection();
            loadBranch();
            formLoad();
            //loadMembers();
            refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool validation()
        {
            if (txtTeamName.Text == "")
            {
                MessageBox.Show("Please Insert a Team Name");
                return false;
            }
            if (dgvTeamDetails.Rows.Count == 0)
            {
                MessageBox.Show("No members " + Environment.NewLine + "Please insert members");
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validation() == false)
                return;
            SqlTransaction trans = null;
            try
            {
                if (formConnection.State != ConnectionState.Open)
                    formConnection.Open();
                trans = formConnection.BeginTransaction();

                DaTeam objDaTeamMaster = new DaTeam();
                TeamMaster objTeamMaster = createMaster();
                int LastID = objDaTeamMaster.SaveOrUpdateMaster(objTeamMaster, formConnection, trans);

                int i, nR;
                nR = dgvTeamDetails.Rows.Count;
                TeamDetail objTeamDetail = new TeamDetail();
                for (i = 0; i < nR-1; i++)
                {
                    objTeamDetail = createDetail(i);
                    if (objTeamDetail == null && trans != null)
                    {
                        trans.Rollback();
                        return;
                    }
                    objTeamDetail.intTeamID = LastID;
                    objDaTeamMaster.SaveOrUpdateDetail(objTeamDetail, formConnection, trans);
                }
                trans.Commit();
                MessageBox.Show("Save successful");
                formLoad();
                loadMembers(LastID);
                refresh();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                MessageBox.Show(ex.Message);
            }
        }
        private TeamMaster createMaster()
        {
            try
            {
                int tID;
                if (txtTeamID.Text.ToString() == "")
                    tID = 0;
                else
                    tID = int.Parse(txtTeamID.Text);
                TeamMaster objTeamMaster = new TeamMaster();
                objTeamMaster.intTeamID = tID;
                objTeamMaster.strTeamNo = txtTeamNo.Text;
                objTeamMaster.strTeamName = txtTeamName.Text;
                objTeamMaster.intBranchID = cmbBranch.SelectedValue == DBNull.Value ? 0 : (int)cmbBranch.SelectedValue;
                return objTeamMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private TeamDetail createDetail(int rowID)
        {
            TeamDetail objTeamDetail = null;
            TeamMaster objMaster = new TeamMaster();
            try
            {
                objTeamDetail = new TeamDetail();

                if (dgvTeamDetails.Rows[rowID].Cells["memberID"].Value == null || dgvTeamDetails.Rows[rowID].Cells["memberID"].Value.ToString() == "")
                    objTeamDetail.intMemberID = 0;
                else
                    objTeamDetail.intMemberID = (int)dgvTeamDetails.Rows[rowID].Cells["memberID"].Value;
                /*
                if (dgvTeamDetails.Rows[rowID].Cells["memberName"].Value == DBNull.Value || dgvTeamDetails.Rows[rowID].Cells["memberName"].Value == null)
                {
                    MessageBox.Show("");
                }
                 * */
                objTeamDetail.strMemberName = dgvTeamDetails.Rows[rowID].Cells["memberName"].Value.ToString();
                if (dgvTeamDetails.Rows[rowID].Cells["DesignationID"].Value == DBNull.Value || dgvTeamDetails.Rows[rowID].Cells["DesignationID"].Value == null) return null;
                objTeamDetail.intDesignationID =(int)dgvTeamDetails.Rows[rowID].Cells["DesignationID"].Value;
                if(dgvTeamDetails.Rows[rowID].Cells["deptID"].Value == DBNull.Value || dgvTeamDetails.Rows[rowID].Cells["deptID"].Value == null) return null;
                objTeamDetail.intDeptID = (int)dgvTeamDetails.Rows[rowID].Cells["deptID"].Value;
                objTeamDetail.strContactNo = dgvTeamDetails.Rows[rowID].Cells["contactNo"].Value == DBNull.Value || dgvTeamDetails.Rows[rowID].Cells["contactNo"].Value == null ? "" : dgvTeamDetails.Rows[rowID].Cells["contactNo"].Value.ToString();
                objTeamDetail.strRemarks = dgvTeamDetails.Rows[rowID].Cells["remarks"].Value == DBNull.Value || dgvTeamDetails.Rows[rowID].Cells["remarks"].Value == null ? "" : dgvTeamDetails.Rows[rowID].Cells["remarks"].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objTeamDetail;
        }

        private void btnDeleteMember_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete the Member", "Conformation", MessageBoxButtons.YesNo) == DialogResult.No) return;
            try
            {
                if (dgvTeamDetails.SelectedRows.Count==0 || dgvTeamDetails.SelectedRows[0].IsNewRow)
                    return;
               
                    DaTeam obDaTeam = new DaTeam();
                    int MemberID;
                    MemberID = Convert.ToInt32(dgvTeamDetails.Rows[dgvTeamDetails.CurrentRow.Index].Cells["MemberID"].Value);
                    obDaTeam.DeleteMember(formConnection, MemberID);
                    int TeamId = Convert.ToInt32(txtTeamID.Text);
                    loadMembers(TeamId);
                    MessageBox.Show("Dellete succussfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDeleteTeam_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete the team", "Conformation", MessageBoxButtons.YesNo) == DialogResult.No) return;
            int TeamID = 0;
            try
            {
                DaTeam obDaTeam = new DaTeam();
                TeamID = (int)dgvTeamMaster.Rows[dgvTeamMaster.CurrentRow.Index].Cells["TeamID"].Value;
                obDaTeam.deleteTeam(TeamID, formConnection);
                MessageBox.Show("Delete Successfull");
                formLoad();
                loadMembers(TeamID);
                refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void formLoad()
        {
            try
            {
                DaTeam obDaTeam = new DaTeam();
                dtMembers = obDaTeam.loadMaster(formConnection);
                dgvTeamMaster.DataSource = dtMembers;
                dgvTeamMaster.setColumnsVisible(false, "TeamID", "BranchID", "COmpanyID", "UserID", "ModifiedDate");

            }
            catch (Exception ex)
            {
                throw new Exception("Error" + ex.Message);
            }
        }

        //Show 
        
        private void loadBranch()
        {
            try
            {
                DaTeam objDaTeammaster = new DaTeam();

                cmbBranch.DataSource = objDaTeammaster.loadBranch(formConnection);
                cmbBranch.DisplayMember = "BranchName";
                cmbBranch.ValueMember = "BranchID";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void loadMembers()
        {
            try
            {
                DaTeam objDateammaster = new DaTeam();

                if (dgvTeamDetails.Columns.Count > 0) dgvTeamDetails.Columns.Clear();

                DataGridViewComboBoxColumn colcbo, colcbo2;
                colcbo = new DataGridViewComboBoxColumn();
                colcbo2 = new DataGridViewComboBoxColumn();

                colcbo.DataSource = objDateammaster.loadDepartment(formConnection);
                colcbo.Name = "DeptID";
                colcbo.DisplayMember = "DeptName";
                colcbo.HeaderText = "Department";
                colcbo.ValueMember = "DeptID";
                colcbo.DataPropertyName = "DeptID";
                dgvTeamDetails.Columns.Add(colcbo);

                colcbo2.DataSource = objDateammaster.loadDesignation(formConnection);
                colcbo2.Name = "DesignationID";
                colcbo2.DisplayMember = "Name";
                colcbo2.HeaderText = "Designation";
                colcbo2.ValueMember = "DesignationID";
                colcbo2.DataPropertyName = "DesignationID";
                dgvTeamDetails.Columns.Add(colcbo2);

                dtMembers = objDateammaster.loadDetail(formConnection);
                dgvTeamDetails.DataSource =dtMembers;
                dgvTeamDetails.setColumnsVisible(false, "MemberID", "TeamID");
                dgvTeamDetails.setColumnsDisplayOrder(new string[] { "MemberName", "DesignationID", "DeptID", "ContactNo", "Remarks" });

            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        private void loadMembers(int TeamID)
        {
            try
            {
                DaTeam obDaTeam = new DaTeam();

                if (dgvTeamDetails.Columns.Count > 0) dgvTeamDetails.Columns.Clear();

                DataGridViewComboBoxColumn colcbo, colcbo2;
                colcbo = new DataGridViewComboBoxColumn();
                colcbo2 = new DataGridViewComboBoxColumn();

                colcbo.DataSource = obDaTeam.loadDepartment(formConnection);
                colcbo.Name = "DeptID";
                colcbo.DisplayMember = "DeptName";
                colcbo.HeaderText = "Department";
                colcbo.ValueMember = "DeptID";
                colcbo.DataPropertyName = "DeptID";
                colcbo.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                dgvTeamDetails.Columns.Add(colcbo);

                colcbo2.DataSource = obDaTeam.loadDesignation(formConnection);
                colcbo2.Name = "DesignationID";
                colcbo2.DisplayMember = "Name";
                colcbo2.HeaderText = "Designation";
                colcbo2.ValueMember = "DesignationID";
                colcbo2.DataPropertyName = "DesignationID";
                colcbo2.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                dgvTeamDetails.Columns.Add(colcbo2);
                
                dtMembers = obDaTeam.loadDetail(formConnection, TeamID);
                dgvTeamDetails.DataSource = dtMembers;
                dgvTeamDetails.setColumnsVisible(false, "MemberID", "TeamID");
                dgvTeamDetails.setColumnsDisplayOrder(new string[] { "MemberName", "DesignationID", "DeptID", "ContactNo", "Remarks" });

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
       
        private void refresh()
        {
            txtTeamID.Text = "";
            txtTeamNo.Text = "";
            txtTeamName.Text = "";
            loadMembers(0);
            
        }
        
        private void frmTeam_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(formConnection);
        }

        private void dgvTeamDetails_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTeamDetails.Columns[e.ColumnIndex].Name == "DeptID" || dgvTeamDetails.Columns[e.ColumnIndex].Name == "DesignationID")
                SendKeys.Send("{F4}");
        }

        private void dgvTeamMaster_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1) return;
                int TeamID = 0;
                int BranchID = 0;
                int rowID = e.RowIndex;
                txtTeamID.Text = dgvTeamMaster.Rows[rowID].Cells["TeamID"].Value.ToString();
                txtTeamNo.Text = dgvTeamMaster.Rows[rowID].Cells["TeamNo"].Value.ToString();
                txtTeamName.Text = dgvTeamMaster.Rows[rowID].Cells["TeamName"].Value.ToString();
                
                TeamID = (int)(dgvTeamMaster.Rows[rowID].Cells["TeamID"].Value);
                BranchID = (int)(dgvTeamMaster.Rows[rowID].Cells["BranchID"].Value);

                cmbBranch.SelectedValue = BranchID;
                DaTeam obDaTeam = new DaTeam();

                loadMembers(TeamID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmTeam_Paint(object sender, PaintEventArgs e)
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

        private void dgvTeamDetails_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvTeamDetails.Columns[dgvTeamDetails.CurrentCell.ColumnIndex].CellType.Name != "DataGridViewComboBoxCell")
            {
                e.CellStyle.BackColor = Color.Black;
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private void txtTeamNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                    SelectNextControl((Control)sender, true, true, true, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
