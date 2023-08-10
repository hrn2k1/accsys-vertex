using Accounting.DataAccess;
using Accounting.Utility;
using AccSys.Web.Models;
using AccSys.Web.WebControls;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Tools;

namespace AccSys.Web
{
    public partial class frmSaleInvoice : BasePage
    {
        private string _sessionDatatableName = "SalesInvItems";
        private string _dateFormat = "yyyy-MM-dd";
        private DataTable GetSessionDataTable()
        {
            DataTable dtItems;
            if (Session[_sessionDatatableName] == null)
            {
                dtItems = new DataTable();
                dtItems.Columns.Add("ID", typeof(int));
                dtItems.Columns.Add("ItemID", typeof(int));
                dtItems.Columns.Add("ItemName", typeof(string));
                dtItems.Columns.Add("Qty", typeof(double));
                dtItems.Columns.Add("UnitPrice", typeof(double));
                dtItems.Columns.Add("Amount", typeof(double));
                dtItems.Columns.Add("OrderId", typeof(int));
                dtItems.Columns.Add("OrderNo", typeof(string));
            }
            else
            {
                dtItems = (DataTable)Session[_sessionDatatableName];
            }
            return dtItems;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    var companyId = Session.CompanyId();
                    txtDate.Text = DateTime.Now.ToString(_dateFormat);
                    txtFromDate.Text = string.Format("{0:" + _dateFormat + "}", DateTime.Now.AddDays(-30));
                    txtToDate.Text = string.Format("{0:" + _dateFormat + "}", DateTime.Now);
                    txtInvNo.Text = GlobalFunctions.GenerateNo(companyId, "T_Sales_Invoice", "InvoiceNo", "SI-");
                    Session[_sessionDatatableName] = null;
                    btnSearch_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
        private void CalculateTotal(DataTable dtItems=null)
        {
            if (dtItems == null)
                dtItems = GetSessionDataTable();
            txtQty.Text = "";
            txtUnitPrice.Text = "";
            double totalQty = 0.0, totalAmt = 0.0;
            foreach (DataRow r in dtItems.Rows)
            {
                totalQty += Tools.Utility.IsNull<double>(r["Qty"], 0.0);
                totalAmt += Tools.Utility.IsNull<double>(r["Amount"], 0.0);
            }
            txtTotalQty.Text = string.Format("{0}", totalQty);
            var currencyRate = txtRate.Text.ToDouble(1);
            txtTotalAmount.Text = string.Format("{0:0.00}", totalAmt * currencyRate);
            var discountRate = txtDiscount.Text.ToDouble(0);
            var discount = ddlDiscountType.SelectedValue == "0" ? discountRate : totalAmt * currencyRate / 100.0 * discountRate;
            txtTransAmount.Text = string.Format("{0:0.00}", totalAmt * currencyRate - discount);
        }
        private void ChangeValue(object sender, string fieldName)
        {
            TextBox txtSender = (TextBox)sender;
            Label lblRowItemId = (Label)txtSender.NamingContainer.FindControl("lblItemId");
            int itemId = lblRowItemId.Text.ToInt();
            Label lblRowAmount = (Label)txtSender.NamingContainer.FindControl("lblAmount");
            DataTable dtItems = GetSessionDataTable();
            foreach (DataRow row in dtItems.Rows)
            {
                if (GlobalFunctions.isNull(row["ItemID"], 0) == itemId)
                {
                    row[fieldName] = txtSender.Text.ToDouble();
                    row["Amount"] = GlobalFunctions.isNull(row["Qty"], 0.0) * GlobalFunctions.isNull(row["UnitPrice"], 0.0);
                    lblRowAmount.Text = string.Format("{0:0.00}", row["Amount"]);
                    break;
                }
            }
            CalculateTotal(dtItems);
            Session[_sessionDatatableName] = dtItems;
        }
        protected void txtQty_TextChanged(object sender, EventArgs e)
        {
            ChangeValue(sender, "Qty");
        }
        protected void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            ChangeValue(sender, "UnitPrice");
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtItems = GetSessionDataTable();
                int ItemID = Convert.ToInt32(ddlItem.SelectedValue);
                if (ItemID <= 0) return;
                foreach (DataRow r in dtItems.Rows)
                {
                    if (Tools.Utility.IsNull<int>(r["ItemID"], 0) == ItemID)
                    {
                        return;
                    }
                }
                var qty = Convert.ToDouble(txtQty.Text.Trim());
                var price = Convert.ToDouble(txtUnitPrice.Text.Trim());
                var amt = qty * price;
                dtItems.Rows.Add(0, ItemID, ddlItem.SelectedItemName(), qty, price, amt);

                gvInvItems.DataSource = dtItems;
                gvInvItems.DataBind();
                CalculateTotal(dtItems);
                Session[_sessionDatatableName] = dtItems;
                lblMsg.Text = "";
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                Label lblItemId = (Label)((LinkButton)sender).NamingContainer.FindControl("lblItemId");
                int ItemId = Convert.ToInt32(lblItemId.Text);
                DataTable dtInvItems = (DataTable)Session[_sessionDatatableName];
                foreach (DataRow r in dtInvItems.Rows)
                {
                    if (Tools.Utility.IsNull<int>(r["ItemID"], 0) == ItemId)
                    {
                        dtInvItems.Rows.Remove(r);
                        break;
                    }
                }
                gvInvItems.DataSource = dtInvItems;
                gvInvItems.DataBind();
                CalculateTotal(dtInvItems);
                Session[_sessionDatatableName] = dtInvItems;
                lblMsg.Text = "";
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                var companyId = Session.CompanyId();
                lblInvId.Text = "0";
                ddlType.SelectedIndex = 0;
                ddlAccount.SelectedIndex = 0;
                ddlSalesAccount.SelectedIndex = 0;
                txtInvNo.Text = GlobalFunctions.GenerateNo(companyId, "T_Sales_Invoice", "InvoiceNo", "SI-");
                txtChalanNo.Text = "";
                txtRate.Text = "1";
                txtDate.Text = DateTime.Now.ToString(_dateFormat);
                ddlCurrency.SelectedIndex = 0;
                txtRemarks.Text = "";
                Session[_sessionDatatableName] = null;
                var dtItems = GetSessionDataTable();
                gvInvItems.DataSource = dtItems;
                gvInvItems.DataBind();
                txtTotalQty.Text = "0";
                txtTotalAmount.Text = "0";
                txtDiscount.Text = "0";
                ddlDiscountType.SelectedIndex = 0;
                txtTransAmount.Text = "0";
                ddlType_SelectedIndexChanged(sender, e);
                if (sender.Equals(btnReset))
                    lblMsg.Text = "";
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
        private string CreateWhere()
        {
            string where = string.Format(" CompanyID={0}", Session.CompanyId());
            where += string.Format(" AND (InvoiceDate BETWEEN '{0:yyyy-MM-dd}' AND '{1:yyyy-MM-dd}')", Tools.Utility.GetDateValue(txtFromDate.Text.Trim(), DateNumericFormat.YYYYMMDD), Tools.Utility.GetDateValue(txtToDate.Text.Trim(), DateNumericFormat.YYYYMMDD));
            return where;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                gvData.DataSourceID = "odsCommon";
                odsCommon.SelectParameters["SelectedColumns"].DefaultValue = @" InvoiceID, InvoiceType, InvoiceNo, InvoiceDate, TransAmount, TransRefId, StockrefId, CompanyId ";
                odsCommon.SelectParameters["FromTable"].DefaultValue = @" T_Sales_Invoice ";
                odsCommon.SelectParameters["Where"].DefaultValue = CreateWhere();
                odsCommon.SelectParameters["OrderBy"].DefaultValue = " InvoiceDate DESC ";

                if (sender != null)
                    gvData.PageIndex = 0;
                gvData.DataBind();
                if (sender.Equals(btnSearch))
                    lblMsg.Text = "";
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
        private SalesInvoiceModel CreateModel()
        {
            var model = new SalesInvoiceModel
            {
                InvoiceId = lblInvId.Text.ToInt(),
                InvoiceType = (SalesInvoiceType)ddlType.SelectedIndex,
                InvoiceDate = Tools.Utility.GetDateValue(txtDate.Text.Trim(), DateNumericFormat.YYYYMMDD),
                InvoiceNo = txtInvNo.Text,
                ChalanNo = txtChalanNo.Text,
                CurrencyId = ddlCurrency.SelectedValue.ToInt(),
                CurrencyRate = txtRate.Text.ToDouble(1),
                InvoiceAmount = txtTotalAmount.Text.ToDouble(),
                AccountId = ddlAccount.SelectedValue.ToInt(),
                AccountTitle = ddlAccount.SelectedAccountTitle(),
                SalesAccountId = ddlSalesAccount.SelectedValue.ToInt(),
                SalesAccountTitle = ddlSalesAccount.SelectedAccountTitle(),
                Remarks = txtRemarks.Text,
                TransRefId = lblTransRefId.Text.ToInt(),
                StockRefId = lblStockRefId.Text.ToInt(),
                CompanyId = Session.CompanyId(),
                DiscountType = ddlDiscountType.SelectedValue.ToInt(),
                DiscountRate = txtDiscount.Text.ToDouble(0)
            };
            
            if (Session[_sessionDatatableName] != null)
            {
                model.InvoiceItems = (DataTable)Session[_sessionDatatableName];
            }
            else
            {
                model.InvoiceItems = new DataTable();
            }
            return model;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var daSalesInvoice = new DaSalesInvoice();
            var daStockInOut = new DaStockInOut();
            var daTrans = new DaTransaction();
            SqlTransaction trans = null;
            SqlConnection connection = null;
            try
            {
                var model = CreateModel();
                var errors = model.ValidationErrors;
                if (errors.Count > 0)
                {
                    lblMsg.Text = UIMessage.Message2User(string.Join("<br/>", errors), UserUILookType.Warning);
                    return;
                }
                connection = ConnectionHelper.getConnection();
                trans = connection.BeginTransaction();
                if (model.InvoiceType == SalesInvoiceType.OrderSale)
                {
                    var account = new DaAccount().GetAccount(connection, trans, model.AccountId);
                    if (account != null && account.LedgerID > 0)
                        model.LedgerId = account.LedgerID;
                }
                if (model.TransRefId > 0)
                {
                    daTrans.DeleteTransDetail(model.TransRefId, connection, trans);
                }
                if (model.TransRefId <= 0)
                {
                    if (model.InvoiceType == SalesInvoiceType.DirectSale)
                        model.VoucherNo = new DaTransaction().getVoucherNo(connection, trans, "C", model.CompanyId);
                    else
                        model.VoucherNo = new DaTransaction().getVoucherNo(connection, trans, "J", model.CompanyId);
                }
                else
                    model.VoucherNo = ""; // igonred
                model.TransRefId = daTrans.SaveEditTransactionMaster(model.Voucher, connection, trans);
                foreach (var tx in model.VoucherAccounts)
                {
                    daTrans.SaveEditTransactionDetail(tx, connection, trans);
                }
                if (model.StockRefId > 0)
                {
                    daStockInOut.DeleteStockInOutDetail(connection, trans, model.StockRefId);
                }
                model.StockRefId = daStockInOut.SaveUpdateStockInOutMaster(model.Stock, connection, trans);
                foreach (var item in model.StockItems)
                {
                    daStockInOut.SaveUpdateStockInOutDetail(item, connection, trans);
                }
                if (model.InvoiceId > 0)
                {
                    daSalesInvoice.DeleteSalesInvoiceDetail(connection, trans, model.InvoiceId);
                }
                model.InvoiceId = daSalesInvoice.saveUpdateSales_Invoice(model.InvoiceMaster, connection, trans);
                foreach (var item in model.InvoiceDetails)
                {
                    daSalesInvoice.saveUpdateSales_Invoice_Detail(item, connection, trans);
                }
                trans.Commit();
                connection.Close();
                lblMsg.Text = UIMessage.Message2User("Successfully saved", UserUILookType.Success);
                btnReset_Click(sender, e);
                btnSearch_Click(sender, e);
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                if (connection != null) connection.Close();
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }

        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            Label lblRowId = (Label)((LinkButton)sender).NamingContainer.FindControl("lblId");
            int invoiceId = lblRowId.Text.ToInt();
            Label lblRowTransRefId = (Label)((LinkButton)sender).NamingContainer.FindControl("lblTransRefId");
            int transRefId = lblRowTransRefId.Text.ToInt();
            Label lblRowStockRefId = (Label)((LinkButton)sender).NamingContainer.FindControl("lblStockRefId");
            int stockRefId = lblRowStockRefId.Text.ToInt();

            SqlConnection connection = null;
            SqlTransaction trans = null;
            try
            {
                connection = ConnectionHelper.getConnection();
                trans = connection.BeginTransaction();
                new DaSalesInvoice().DeleteInvoice(connection, trans, invoiceId, transRefId, stockRefId);
                trans.Commit();
                connection.Close();
                lblMsg.Text = UIMessage.Message2User("Successfully deleted", UserUILookType.Success);
                btnSearch_Click(sender, e);
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                if (connection != null) connection.Close();
                lblMsg.Text = ex.CustomDialogMessage();
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
        }
        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Label lblRowId = (Label)((LinkButton)sender).NamingContainer.FindControl("lblId");
                int invId = lblRowId.Text.ToInt();
                var connection = ConnectionHelper.getConnection();
                var invoice = new DaSalesInvoice().getSalesInvoice(connection, invId);
                if (invoice == null) return;
                lblInvId.Text = lblRowId.Text;
                lblTransRefId.Text = invoice.TransRefID.ToString();
                lblStockRefId.Text = invoice.StockRefID.ToString();
                txtInvNo.Text = invoice.InvoiceNo;
                txtChalanNo.Text = invoice.ChalanNo;
                txtDate.Text = invoice.InvoiceDate.ToString(_dateFormat);
                ddlType.SelectedValue = invoice.InvoiceType;
                ddlCurrency.SelectedValue = invoice.CurrencyID.ToString();
                txtRate.Text = invoice.Rate.ToString();
                ddlAccount.SelectedValue = invoice.CustomerAccount.ToString();
                ddlSalesAccount.SelectedValue = invoice.SalesAccount.ToString();
                txtRemarks.Text = invoice.Remarks;
                ddlDiscountType.SelectedValue = invoice.DiscountRate <= 0 ? "0" : "1";
                txtDiscount.Text = (invoice.DiscountRate <= 0 ? invoice.DiscountAmount : invoice.DiscountRate).ToString();
                Session[_sessionDatatableName] = null;
                var dtItems = GetSessionDataTable();
                var invItems = new DaSalesInvoice().GetSalesInvoiceDetails(connection, invId);
                foreach (DataRow row in invItems.Rows)
                {
                    dtItems.Rows.Add(row["SLNo"], row["ItemID"], row["ItemName"], row["InvQty"], row["UnitPrice"], row["PriceAmount"], row["OrderID"], row["OrderNo"]);
                }
                gvInvItems.DataSource = dtItems;
                gvInvItems.DataBind();
                CalculateTotal(dtItems);
                Session[_sessionDatatableName] = dtItems;
                ddlType_SelectedIndexChanged(sender, e);
                lblMsg.Text = "";
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            invdirect.Visible = ddlType.SelectedIndex == 0;
            invorder.Visible = ddlType.SelectedIndex == 1;
            gvInvItems.Columns[2].Visible = ddlType.SelectedIndex == 1;
        }

        protected void btnAddOrder_Click(object sender, EventArgs e)
        {
            var orderId = ddlOrder.SelectedValue.ToInt();
            var orderNo = ddlOrder.SelectedOrderNo();
            var orderItems = new DaOrder().GetOrderItems(ConnectionHelper.getConnection(), orderId);
            Session[_sessionDatatableName] = null;
            var dtItems = GetSessionDataTable();
            foreach (DataRow row in orderItems.Rows)
            {
                dtItems.Rows.Add(0, row["ItemID"], row["ItemName"], row["OrderQty"], row["UnitPrice"], row["OrderValue"], orderId, orderNo);
            }
            gvInvItems.DataSource = dtItems;
            gvInvItems.DataBind();
            CalculateTotal(dtItems);
            Session[_sessionDatatableName] = dtItems;
        }

        protected void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        protected void ddlDiscountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }
    }
}