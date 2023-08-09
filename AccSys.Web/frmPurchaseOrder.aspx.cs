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
    public partial class frmPurchaseOrder : BasePage
    {
        private string _dateFormat = "yyyy-MM-dd";
        private string _sessionDatatableName = "OrderItems";
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
                    var companyId = GlobalFunctions.isNull(Session["CompanyID"], 0);
                    txtDate.Text = DateTime.Now.ToString(_dateFormat);
                    Session[_sessionDatatableName] = null;
                    btnSearch_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
        private void CalculateTotal(DataTable dtItems)
        {
            txtQty.Text = "";
            txtUnitPrice.Text = "";
            double totalQty = 0.0, totalAmt = 0.0;
            foreach (DataRow r in dtItems.Rows)
            {
                totalQty += Tools.Utility.IsNull<double>(r["Qty"], 0.0);
                totalAmt += Tools.Utility.IsNull<double>(r["Amount"], 0.0);
            }
            txtTotalQty.Text = string.Format("{0}", totalQty);
            txtTotalAmount.Text = string.Format("{0}", totalAmt);
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
                var rate = txtRate.Text.Trim().ToDouble();
                var amt = qty * price * rate;
                dtItems.Rows.Add(0, ItemID, ddlItem.SelectedItemName(), qty, price, amt);

                gvOrderItems.DataSource = dtItems;
                gvOrderItems.DataBind();
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
                gvOrderItems.DataSource = dtInvItems;
                gvOrderItems.DataBind();
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
                ddlSupplier.SelectedIndex = 1;
                txtDate.Text = DateTime.Now.ToString(_dateFormat);
                ddlCurrency.SelectedIndex = 0;
                txtRate.Text = "1";
                txtOrderNo.Text = "";
                txtBuyerref.Text = "";
                Session[_sessionDatatableName] = null;
                var dtItems = GetSessionDataTable();
                gvOrderItems.DataSource = dtItems;
                gvOrderItems.DataBind();
                txtTotalQty.Text = "0";
                txtTotalAmount.Text = "0";
                if (sender.Equals(btnReset))
                    lblMsg.Text = "";
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
        private PurchaseOrderModel CreateModel()
        {
            var model = new PurchaseOrderModel
            {
                OrderId = lblOrderId.Text.ToInt(),
                OrderDate = Tools.Utility.GetDateValue(txtDate.Text.Trim(), DateNumericFormat.YYYYMMDD),
                OrderNo = txtOrderNo.Text,
                CurrencyId = ddlCurrency.SelectedValue.ToInt(),
                CurrencyRate = txtRate.Text.Trim().ToDouble(),
                OrderQty = txtTotalQty.Text.ToDouble(),
                OrderValue = txtTotalAmount.Text.ToDouble(),
                BuyerRef = txtBuyerref.Text,
                SupplierId = ddlSupplier.SelectedValue.ToInt(),
                CompanyId = GlobalFunctions.isNull(Session["CompanyID"], 0)
            };
            
            if (Session[_sessionDatatableName] != null)
            {
                model.OrderItems = (DataTable)Session[_sessionDatatableName];
            }
            else
            {
                model.OrderItems = new DataTable();
            }
            return model;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var daOrder = new DaOrder();
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
                if (model.OrderId > 0)
                {
                    daOrder.DeleteOrderItems(connection, trans, model.OrderId);
                }
                model.OrderId = daOrder.saveUpdateOrderMaster(model.OrderMaster, trans, connection);
                foreach (var item in model.OrderDetails)
                {
                    daOrder.saveUpdateOrder_Details(item, trans, connection);
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
        private string CreateWhere()
        {
            string where = string.Format(" Order_Master.CompanyID={0} AND OrderType = 'Purchase Order'", Session["CompanyID"] ?? 1);
            return where;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                gvData.DataSourceID = "odsCommon";
                odsCommon.SelectParameters["SelectedColumns"].DefaultValue = @" OrderMID AS OrderID, OrderNo, OrderDate, CustomerID AS SupplierID, LedgerName AS SupplierName, TotalOrderQty AS OrderQty, OrderValue, Buyer_ref, Order_Master.CompanyID ";
                odsCommon.SelectParameters["FromTable"].DefaultValue = @" Order_Master LEFT OUTER JOIN T_Ledgers ON Order_Master.CustomerID = T_Ledgers.LedgerID ";
                odsCommon.SelectParameters["Where"].DefaultValue = CreateWhere();
                odsCommon.SelectParameters["OrderBy"].DefaultValue = " OrderDate DESC ";

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

        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            Label lblRowId = (Label)((LinkButton)sender).NamingContainer.FindControl("lblId");
            int orderId = lblRowId.Text.ToInt();
            
            SqlConnection connection = null;
            SqlTransaction trans = null;
            try
            {
                connection = ConnectionHelper.getConnection();
                trans = connection.BeginTransaction();
                new DaOrder().Delete(connection, trans, orderId);
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
                int orderId = lblRowId.Text.ToInt();
                var connection = ConnectionHelper.getConnection();
                var order = new DaOrder().GetOrder_Master(connection, orderId);
                if (order == null) return;
                lblOrderId.Text = lblRowId.Text;
                txtOrderNo.Text = order.OrderNo;
                txtDate.Text = order.OrderDate.ToString(_dateFormat);
                ddlCurrency.SelectedValue = order.CurrencyID.ToString();
                ddlSupplier.SelectedValue = order.CustomerID.ToString();
                txtBuyerref.Text = order.Buyer_ref;
                Session[_sessionDatatableName] = null;
                var dtItems = GetSessionDataTable();
                var orderItems = new DaOrder().GetOrderItems(connection, orderId);
                foreach (DataRow row in orderItems.Rows)
                {
                    dtItems.Rows.Add(0, row["ItemID"], row["ItemName"], row["OrderQty"], row["UnitPrice"], row["OrderValue"]);
                }
                gvOrderItems.DataSource = dtItems;
                gvOrderItems.DataBind();
                CalculateTotal(dtItems);
                Session[_sessionDatatableName] = dtItems;
                lblMsg.Text = "";
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
    }
}