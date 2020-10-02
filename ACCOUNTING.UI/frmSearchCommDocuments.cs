using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accounting.DataAccess;
using System.Data.SqlClient;
using Accounting.Utility;
using Accounting.Entity;

namespace Accounting.UI
{
    public partial class frmSearchCommercialDocuments : Form
    {
        SqlConnection conn = null;
        public static int ComDocID = 0;
        public int LCID = 0;
        private DataTable dt = null;
        private DaCommercialDocuments objda = new DaCommercialDocuments();
        public CommercialDocuments objComDoc = new CommercialDocuments();
       
        public frmSearchCommercialDocuments()
        {
            InitializeComponent();
        }

        private void frmCommercialDocuments_Load(object sender, EventArgs e)
        {
            conn = ConnectionHelper.getConnection();
            DTPST.Value = new DateTime(2008, 1, 1);

        }
        private void SearchComDoc()
        {
            DateTime stdate = new DateTime(1900,1,1);
            DateTime eddate = new DateTime(1900,1,1);
            string strComDoc = "";
            dt = new DataTable();
            DaCommercialDocuments daobj = new DaCommercialDocuments();
            try
            {
                stdate = DTPST.Value.Date;
                eddate = DTPED.Value.Date;
                strComDoc = txtComDocNo.Text.Trim();
                dt = daobj.SearchComDoc(stdate, eddate, strComDoc, conn);
                ctlDGVSearchComDoc.DataSource = dt;
                ctlDGVSearchComDoc.setColumnsVisible(false, "UserID","CompanyID","ModifiedDate","ComInvoiceID", "FromLocation", "ToLocation", "ExpNo", "ExpDate", "Carrier", "CarrierNo", "PackingDate", "CODate", "VATerIDNo", "Remarks","NotifyParty","ChalanNo","CONo","OriginCountry","PackingListNo","ChalanDate","LCID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
  
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SearchComDoc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtComDocNo_KeyDown(object sender, KeyEventArgs e)
        {
            btnSearch_Click(null, null);
        }

        private void ctlDGVSearchComDoc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            btnOK_Click(null, null);
         /*   
            dt = new DataTable();
            try
            {
                int ab;
                if (sender.Equals(btnOK)) ab = ctlDGVSearchComDoc.SelectedRows[0].Index;
                else
                    ab = e.RowIndex;

                ComDocID = (int)ctlDGVSearchComDoc.Rows[ab].Cells["ComInvoiceID"].Value;
                /*
                dt = objda.GetComDocBYComDocID(ComDocID, conn);

                objComDoc.ComInvoiceID = dt.Rows[0].Field<int>("ComInvoiceID");
                objComDoc.ComInvoiceNo = dt.Rows[0].Field<string>("ComInvoiceNo");
                objComDoc.ComInvoiceDate = dt.Rows[0].Field<DateTime>("ComInvoiceDate");
                objComDoc.NotifyParty = dt.Rows[0].Field<string>("NotifyParty");
                objComDoc.FromLocation = dt.Rows[0].Field<string>("FromLocation");
                objComDoc.ToLocation = dt.Rows[0].Field<string>("ToLocation");
                objComDoc.ExpNo = dt.Rows[0].Field<string>("ExpNo");
                objComDoc.ExpDate = dt.Rows[0].Field<DateTime>("ExpDate");
                objComDoc.Carrier = dt.Rows[0].Field<string>("Carrier");
                objComDoc.CarrierNo = dt.Rows[0].Field<string>("CarrierNo");
                LCID = objComDoc.LCID = dt.Rows[0].Field<int>("LCID");
                objComDoc.OriginCountry = dt.Rows[0].Field<string>("OriginCountry");
                objComDoc.TotalQty = dt.Rows[0].Field<int>("TotalQty");
                objComDoc.TotalValue = Convert.ToDouble(dt.Rows[0].Field<object>("TotalValue"));
                objComDoc.PackingListNo = dt.Rows[0].Field<string>("PackingListNo");
                objComDoc.PackingDate = dt.Rows[0].Field<DateTime>("PackingDate");
                objComDoc.CONo = dt.Rows[0].Field<string>("CONo");
                objComDoc.CODate = dt.Rows[0].Field<DateTime>("CODate");
                objComDoc.VATerIDNo = dt.Rows[0].Field<string>("VATerIDNo");
                objComDoc.Remarks = dt.Rows[0].Field<string>("Remarks");
                objComDoc.ChalanNo = dt.Rows[0].Field<string>("ChalanNo");

                objComDoc.SubmitDate = dt.Rows[0].Field<object>("SubmitDate") == DBNull.Value || dt.Rows[0].Field<object>("SubmitDate") == null ? new DateTime(1900, 1, 1) : dt.Rows[0].Field<DateTime>("SubmitDate");
                
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            */
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ctlDGVSearchComDoc.SelectedRows.Count == 0) return;
            try
            {
                int CommDocid = Convert.ToInt32(ctlDGVSearchComDoc.SelectedRows[0].Cells["ComInvoiceID"].Value);
                objComDoc = objda.GetCommDocs(conn, CommDocid);
                this.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       /*
        public CommercialDocuments GetLCNoInTextBox()
        {
            return objComDoc;
        }
        */
        private void frmCommercialDocuments_Paint(object sender, PaintEventArgs e)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            objComDoc = null;
            this.Close();
        }

        private void frmCommercialDocuments_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConnectionHelper.closeConnection(conn);
        }
       
    }
}
