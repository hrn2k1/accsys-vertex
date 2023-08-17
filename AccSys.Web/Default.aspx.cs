using Accounting.Utility;
using AccSys.Web.WebControls;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AccSys.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                LoadAccountInfo();
                LoadTransactionInfo();
            }
            catch (Exception ex)
            {

            }
        }

        private void LoadAccountInfo()
        {
            var qstr = $"SELECT LedgerTypeId, COUNT(AccountId) AS Total FROM T_Account WHERE AccOrGroup='Account' AND CompanyID = {Session.CompanyId()} GROUP BY LedgerTypeId";
            using (var adapter = new SqlDataAdapter(qstr, ConnectionHelper.DefaultConnectionString))
            {
                var data = new DataTable();
                adapter.Fill(data);
                adapter.Dispose();
                foreach (DataRow row in data.Rows)
                {
                    switch (GlobalFunctions.isNull(row["LedgerTypeId"], 0))
                    {
                        case 1:
                            lblGeneral.Text = GlobalFunctions.isNull(row["Total"], 0).ToString();
                            break;
                        case 2:
                            lblCustomer.Text = GlobalFunctions.isNull(row["Total"], 0).ToString();
                            break;
                        case 3:
                            lblSupplier.Text = GlobalFunctions.isNull(row["Total"], 0).ToString();
                            break;
                        case 4:
                            lblBank.Text = GlobalFunctions.isNull(row["Total"], 0).ToString();
                            break;
                        case 5:
                            lblCash.Text = GlobalFunctions.isNull(row["Total"], 0).ToString();
                            break;
                    }
                }
            }
        }

        private void LoadTransactionInfo()
        {
            var qstr = $"SELECT VoucherType, COUNT(TransMID) AS Total FROM T_Transaction_Master WHERE CompanyID = {Session.CompanyId()}  GROUP BY VoucherType";
            using (var adapter = new SqlDataAdapter(qstr, ConnectionHelper.DefaultConnectionString))
            {
                var data = new DataTable();
                adapter.Fill(data);
                adapter.Dispose();
                foreach (DataRow row in data.Rows)
                {
                    switch (GlobalFunctions.isNull(row["VoucherType"], 0))
                    {
                        case 1:
                            lblCredit.Text = GlobalFunctions.isNull(row["Total"], 0).ToString();
                            break;
                        case 2:
                            lblDebit.Text = GlobalFunctions.isNull(row["Total"], 0).ToString();
                            break;
                        case 3:
                            lblJournal.Text = GlobalFunctions.isNull(row["Total"], 0).ToString();
                            break;
                    }
                }
            }
        }
    }
}