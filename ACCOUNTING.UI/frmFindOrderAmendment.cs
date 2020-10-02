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

namespace Accounting.UI
{
    public partial class frmFindOrderAmendment : Form
    {
        public frmFindOrderAmendment()
        {
            InitializeComponent();
        }
        private int _OrderMID;
        private SqlConnection formCon = null;
        private DataTable dtAmends = new DataTable();
        public int SelectedAmendID = 0;
        public DateTime AmendmentDate;
        public string Comment;
        public void ShowDialog(int OrderMID)
        {
            _OrderMID = OrderMID;
            this.ShowDialog();
        }

        private void frmFindOrderAmendment_Load(object sender, EventArgs e)
        {
            try
            {
                formCon = ConnectionHelper.getConnection();
                loadAmends();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadAmends()
        {
            try
            {
                dtAmends = new DaOrder().getAmendments(formCon, _OrderMID);
                dgvFindAmend.DataSource = dtAmends;
                dgvFindAmend.setColumnsVisible(false, "AmendID","OrderMID");
                dgvFindAmend.Columns["AmendDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFindAmend.SelectedRows.Count == 0) return;
                SelectedAmendID = Convert.ToInt32(dgvFindAmend["AmendID", dgvFindAmend.SelectedRows[0].Index].Value);
                AmendmentDate = (DateTime)dgvFindAmend["AmendDate", dgvFindAmend.SelectedRows[0].Index].Value;
                Comment = dgvFindAmend["AmendComment", dgvFindAmend.SelectedRows[0].Index].Value.ToString();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SelectedAmendID = 0;
            this.Close();
        }

        private void frmFindOrderAmendment_FormClosed(object sender, FormClosedEventArgs e)
        {
            //SelectedAmendID = 0;
        }

        private void frmFindOrderAmendment_Paint(object sender, PaintEventArgs e)
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

        private void dgvFindAmend_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnOK_Click(sender, null);
        }
    }
}
