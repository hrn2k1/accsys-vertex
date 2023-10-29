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
    public partial class frmStockInOut : BasePage
    {
        private string _sessionDatatableName = "InOutItems";
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
                dtItems.Columns.Add("RefId", typeof(int));
                dtItems.Columns.Add("RefNo", typeof(string));
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
                    //txtVoucherNo.Text = GlobalFunctions.GenerateNo(companyId, "T_Sales_Invoice", "InvoiceNo", "SI-");
                    Session[_sessionDatatableName] = null;
                    btnSearch_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            inoutOrder.Visible = ddlType.SelectedIndex == 0 || ddlType.SelectedIndex == 2 || ddlType.SelectedIndex == 4;
            inoutReq.Visible = ddlType.SelectedIndex == 1;
            inoutItem.Visible = ddlType.SelectedIndex == 3;
            gvInOutItems.Columns[2].Visible = ddlType.SelectedIndex != 3;
        }
        private void CalculateTotal(DataTable dtItems = null)
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
            txtTotalQty.Text = string.Format("{0:0.00}", totalQty);
            txtTotalAmount.Text = string.Format("{0:0.00}", totalAmt );
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
        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                lblRefId.Text = "0";
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

                gvInOutItems.DataSource = dtItems;
                gvInOutItems.DataBind();
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
                gvInOutItems.DataSource = dtInvItems;
                gvInOutItems.DataBind();
                CalculateTotal(dtInvItems);
                Session[_sessionDatatableName] = dtInvItems;
                lblMsg.Text = "";
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }

        protected void btnAddOrder_Click(object sender, EventArgs e)
        {
            var orderId = ddlOrder.SelectedValue.ToInt();
            lblRefId.Text = orderId.ToString();
            var orderNo = ddlOrder.SelectedOrderNo();
            var orderItems = new DaOrder().GetOrderItems(ConnectionHelper.getConnection(), orderId);
            Session[_sessionDatatableName] = null;
            var dtItems = GetSessionDataTable();
            foreach (DataRow row in orderItems.Rows)
            {
                dtItems.Rows.Add(0, row["ItemID"], row["ItemName"], row["OrderQty"], row["UnitPrice"], row["OrderValue"], orderId, orderNo);
            }
            gvInOutItems.DataSource = dtItems;
            gvInOutItems.DataBind();
            CalculateTotal(dtItems);
            Session[_sessionDatatableName] = dtItems;
        }

        protected void btnAddReq_Click(object sender, EventArgs e)
        {
            var reqId = ddlReq.SelectedValue.ToInt();
            lblRefId.Text = reqId.ToString();
            var reqNo = ddlReq.SelectedRequisitionNo();
            var orderItems = new DaInventoryRequisition().GetRequisitionItems(ConnectionHelper.getConnection(), reqId);
            Session[_sessionDatatableName] = null;
            var dtItems = GetSessionDataTable();
            foreach (DataRow row in orderItems.Rows)
            {
                dtItems.Rows.Add(0, row["ItemID"], row["ItemName"], row["ReqQty"], null, null, reqId, reqNo);
            }
            gvInOutItems.DataSource = dtItems;
            gvInOutItems.DataBind();
            CalculateTotal(dtItems);
            Session[_sessionDatatableName] = dtItems;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                var companyId = Session.CompanyId();
                lblStockId.Text = "0";
                ddlType.SelectedIndex = 0;
                //txtVoucherNo.Text = GlobalFunctions.GenerateNo(companyId, "T_Sales_Invoice", "InvoiceNo", "SI-");
                txtChalanDate.Text = "";
                txtChalanNo.Text = "";
                txtDate.Text = DateTime.Now.ToString(_dateFormat);
                txtRemarks.Text = "";
                Session[_sessionDatatableName] = null;
                var dtItems = GetSessionDataTable();
                gvInOutItems.DataSource = dtItems;
                gvInOutItems.DataBind();
                txtTotalQty.Text = "0";
                txtTotalAmount.Text = "0";
                ddlType_SelectedIndexChanged(sender, e);
                if (sender.Equals(btnReset))
                    lblMsg.Text = "";
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
        private StockInOutModel CreateModel()
        {
            var model = new StockInOutModel
            {
                StockId = lblStockId.Text.ToInt(),
                InOutType = (StockInOutType)ddlType.SelectedIndex,
                TransDate = Tools.Utility.GetDateValue(txtDate.Text.Trim(), DateNumericFormat.YYYYMMDD),
                VoucherNo = txtVoucherNo.Text,
                ChalanDate = txtChalanDate.Text.Trim() == "" ? new DateTime(1900,1,1) : Tools.Utility.GetDateValue(txtChalanDate.Text.Trim(), DateNumericFormat.YYYYMMDD),
                ChalanNo = txtChalanNo.Text,
                Remarks = txtRemarks.Text,
                RefId = lblRefId.Text.ToInt(),
                CompanyId = Session.CompanyId(),
                LedgerId = lblCustSuppId.Text.ToInt() 
            };

            if (Session[_sessionDatatableName] != null)
            {
                model.StockItems = (DataTable)Session[_sessionDatatableName];
            }
            else
            {
                model.StockItems = new DataTable();
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
                
               
                model.StockId = daStockInOut.SaveUpdateStockInOutMaster(model.Stock, connection, trans);
                if (model.StockId > 0)
                {
                    daStockInOut.DeleteStockInOutDetail(connection, trans, model.StockId);
                }
                foreach (var item in model.StockDetails)
                {
                    daStockInOut.SaveUpdateStockInOutDetail(item, connection, trans);
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
            Label lblModule = (Label)((LinkButton)sender).NamingContainer.FindControl("lblModule");
            if (lblModule.Text != "Stock InOut" && lblModule.Text != "Stock In Out")
            {
                lblMsg.Text = UIMessage.Message2User("You can't delete it from here. Delete from " + lblModule.Text, UserUILookType.Danger);
                return;
            }
            Label lblRowId = (Label)((LinkButton)sender).NamingContainer.FindControl("lblId");
           
            SqlConnection connection = null;
            SqlTransaction trans = null;
            try
            {
                connection = ConnectionHelper.getConnection();
                trans = connection.BeginTransaction();
                new DaStockInOut().DeleteStockInOut(connection, trans, lblRowId.Text.ToInt());
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

        private string CreateWhere()
        {
            string where = string.Format(" CompanyID={0}", Session.CompanyId());
            if(ddlSrcType.SelectedValue != "")
            {
                where += $" AND TransType='{ddlSrcType.SelectedValue}'";
            }
            if(txtSrcVoucherNo.Text.Trim() != "")
            {
                where += $" AND VoucherNo='{txtSrcVoucherNo.Text.Trim()}'";
            }
            where += string.Format(" AND (TransDate BETWEEN '{0:yyyy-MM-dd}' AND '{1:yyyy-MM-dd}')", Tools.Utility.GetDateValue(txtFromDate.Text.Trim(), DateNumericFormat.YYYYMMDD), Tools.Utility.GetDateValue(txtToDate.Text.Trim(), DateNumericFormat.YYYYMMDD));
            return where;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                gvData.DataSourceID = "odsCommon";
                odsCommon.SelectParameters["SelectedColumns"].DefaultValue = @" StockMID, TransType, TransDate, VoucherNo, ChalanNo, ChalanDate, CompanyId, RefID, Module ";
                odsCommon.SelectParameters["FromTable"].DefaultValue = @" T_Stock_InOut_Master ";
                odsCommon.SelectParameters["Where"].DefaultValue = CreateWhere();
                odsCommon.SelectParameters["OrderBy"].DefaultValue = " TransDate DESC ";

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

        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Label lblModule = (Label)((LinkButton)sender).NamingContainer.FindControl("lblModule");
                if (lblModule.Text != "Stock InOut" && lblModule.Text != "Stock In Out")
                {
                    lblMsg.Text = UIMessage.Message2User("You can't edit it from here. Edit from " + lblModule.Text, UserUILookType.Danger);
                    return;
                }
                Label lblRowId = (Label)((LinkButton)sender).NamingContainer.FindControl("lblId");
                int stockId = lblRowId.Text.ToInt();
                var connection = ConnectionHelper.getConnection();
                var stockM = new DaStockInOut().getStockInOutMaster(connection, stockId);
                if (stockM == null) return;
                lblStockId.Text = lblRowId.Text;
                lblTransRefId.Text = stockM.RefID.ToString();
                txtVoucherNo.Text = stockM.VoucherNo;
                txtChalanNo.Text = stockM.ChalanNo;
                txtDate.Text = stockM.TransDate.ToString(_dateFormat);
                txtChalanDate.Text = stockM.ChalanDate.ToString(_dateFormat);
                ddlType.SelectedValue = stockM.TransType;
                txtRemarks.Text = stockM.Remarks;
                Session[_sessionDatatableName] = null;
                var dtItems = GetSessionDataTable();
                var stockItems = new DaStockInOut().getStockItems(connection, stockId);
                foreach (DataRow row in stockItems.Rows)
                {
                    dtItems.Rows.Add(row["StockDID"], row["ItemID"], row["ItemName"], Convert.ToDecimal(row["InQty"]) + Convert.ToDecimal(row["OutQty"]), row["UnitPrice"], Convert.ToDecimal(row["InAmount"]) + Convert.ToDecimal(row["OutAmount"]), stockM.RefID, null);
                }
                gvInOutItems.DataSource = dtItems;
                gvInOutItems.DataBind();
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
    }
}