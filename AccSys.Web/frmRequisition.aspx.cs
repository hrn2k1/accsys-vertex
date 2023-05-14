using Accounting.DataAccess;
using Accounting.Entity;
using Accounting.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tools;

namespace AccSys.Web
{
    public partial class frmRequisition : System.Web.UI.Page
    {
        private string _dateFormat = "yyyy-MM-dd";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDate.Text = DateTime.Now.ToString(_dateFormat);
                Session["ReqItems"] = null;
                btnSearch_Click(sender, e);
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtItems = new DataTable();
                if (Session["ReqItems"] == null)
                {
                    dtItems = new DataTable();
                    dtItems.Columns.Add("ID", typeof(int));
                    dtItems.Columns.Add("ItemID", typeof(int));
                    dtItems.Columns.Add("ItemName", typeof(string));
                    dtItems.Columns.Add("Spec", typeof(string));
                    dtItems.Columns.Add("Size", typeof(string));
                    dtItems.Columns.Add("Qty", typeof(double));
                }
                else
                {
                    dtItems = (DataTable)Session["ReqItems"];
                }
                int ItemID = Convert.ToInt32(ddlItem.SelectedValue);
                if (ItemID <= 0) return;
                foreach (DataRow r in dtItems.Rows)
                {
                    if (Tools.Utility.IsNull<int>(r["ItemID"], 0) == ItemID)
                    {
                        return;
                    }
                }
                dtItems.Rows.Add(0, ItemID, ddlItem.SelectedItemName(), txtSpec.Text, txtSize.Text.Trim(), Convert.ToDouble(txtQty.Text.Trim()));

                gvReqItems.DataSource = dtItems;
                gvReqItems.DataBind();
                txtSpec.Text = "";
                txtSize.Text = "";
                txtQty.Text = "";
                double totalQty = 0.0;
                foreach (DataRow r in dtItems.Rows)
                {
                    totalQty += Tools.Utility.IsNull<double>(r["Qty"], 0.0);

                }
                txtTotalQty.Text = string.Format("{0}", totalQty);
                Session["ReqItems"] = dtItems;
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
                DataTable dtReqItems = (DataTable)Session["ReqItems"];
                foreach (DataRow r in dtReqItems.Rows)
                {
                    if (Tools.Utility.IsNull<int>(r["ItemID"], 0) == ItemId)
                    {
                        dtReqItems.Rows.Remove(r);
                        break;
                    }
                }
                gvReqItems.DataSource = dtReqItems;
                gvReqItems.DataBind();

                double totalAmt = 0.0;
                foreach (DataRow r in dtReqItems.Rows)
                {
                    totalAmt += Tools.Utility.IsNull<double>(r["Qty"], 0.0);

                }
                txtTotalQty.Text = string.Format("{0:0.00}", totalAmt);
                Session["ReqItems"] = dtReqItems;
                lblMsg.Text = "";
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
        private bool Validation()
        {
            if (txtReqNo.Text.Trim() == "")
            {
                lblMsg.Text = "Enter a valid Requisition no.";
                return false;
            }
            if (Convert.ToDouble(txtTotalQty.Text) <= 0)
            {
                lblMsg.Text = "Please selecy items and quantities";
                return false;
            }
            
            return true;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Validation() == false) return;
            SqlTransaction trans = null;
            int ReqMID = 0;
            var obReqMaster = new ReqMaster();
            var obReqDetail = new ReqDetail();
            var obDaReq = new DaInventoryRequisition();
            try
            {
                var connection = ConnectionHelper.getConnection();
                trans = connection.BeginTransaction();

                //Save ReqMaster
                obReqMaster = CreateReqMaster();
                ReqMID = obDaReq.SaveUpdateReqMaster(obReqMaster, connection, trans);

                //Save ReqDetail
                foreach (GridViewRow row in gvReqItems.Rows)
                {
                    obReqDetail = CreateReqDetail(ReqMID, row);
                    obDaReq.SaveUpdateReqDetail(obReqDetail, connection, trans);
                }
                trans.Commit();
                lblMsg.Text = UIMessage.Message2User("Successfully saved", UserUILookType.Success);
                btnReset_Click(sender, e);
                btnSearch_Click(sender, e);
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
        private ReqMaster CreateReqMaster()
        {
            var obReqMaster = new ReqMaster();
            try
            {
                obReqMaster.ReqMID = Convert.ToInt32(lblReqId.Text);
                obReqMaster.ReqNo = txtReqNo.Text;
                obReqMaster.ReqDate = Tools.Utility.GetDateValue(txtDate.Text.Trim(), DateNumericFormat.YYYYMMDD);
                obReqMaster.ReqSectionID = Convert.ToInt32(ddlSection.SelectedValue);
                obReqMaster.ReqBy = txtReqBy.Text;
                obReqMaster.Remarks = txtDescription.Text;
                obReqMaster.CompanyID = Tools.Utility.IsNull<int>(Session["CompanyId"], 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obReqMaster;
        }
        private ReqDetail CreateReqDetail(int ReqMID, GridViewRow row)
        {
            var obReqDetail = new ReqDetail();
            try
            {
                obReqDetail.ReqDID = Convert.ToInt32(((Label)row.FindControl("lblId")).Text);
                obReqDetail.ReqMID = ReqMID;
                obReqDetail.ItemID = Convert.ToInt32(((Label)row.FindControl("lblItemId")).Text);
                obReqDetail.CountID = 0;
                obReqDetail.SizeID = 0;
                obReqDetail.ColorID = 0;
                obReqDetail.ReqQty = Convert.ToDouble(((Label)row.FindControl("lblQty")).Text);
                obReqDetail.UnitID = 0;
                obReqDetail.Budle_Pack_Qty = "";
                obReqDetail.Specifications = ((Label)row.FindControl("lblSpec")).Text;
                obReqDetail.Budle_Pack_Size = ((Label)row.FindControl("lblSize")).Text;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obReqDetail;
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtReqNo.Text = "";
            txtReqBy.Text = "";
            txtDate.Text = DateTime.Now.ToString(_dateFormat);
            ddlSection.SelectedIndex = 0;
            txtDescription.Text = "";
            Session["ReqItems"] = null;
            var dtItems = new DataTable();
            dtItems.Columns.Add("ID", typeof(int));
            dtItems.Columns.Add("ItemID", typeof(int));
            dtItems.Columns.Add("ItemName", typeof(string));
            dtItems.Columns.Add("Spec", typeof(string));
            dtItems.Columns.Add("Size", typeof(string));
            dtItems.Columns.Add("Qty", typeof(double));
            gvReqItems.DataSource = dtItems;
            gvReqItems.DataBind();
            txtTotalQty.Text = "0";
        }
        private string CreateWhere()
        {
            string where = "";
            where = string.Format(" Req.CompanyID={0}", Session["CompanyID"] ?? 1);
            return where;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                gvData.DataSourceID = "odsCommon";
                odsCommon.SelectParameters["SelectedColumns"].DefaultValue = @" ReqMID, ReqNo, ReqDate, ReqBy,ReqSectionID, Name AS SectionName, Remarks, Req.CompanyId ";
                odsCommon.SelectParameters["FromTable"].DefaultValue = @" T_Requisition_Master Req LEFT JOIN Section ON ReqSectionID = Section.SectionID ";
                odsCommon.SelectParameters["Where"].DefaultValue = CreateWhere();
                odsCommon.SelectParameters["OrderBy"].DefaultValue = " ReqDate DESC ";

                if (sender != null)
                    gvData.PageIndex = 0;
                gvData.DataBind();

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
            int reqId = Convert.ToInt32(lblRowId.Text);
            var connection = ConnectionHelper.getConnection();
            SqlTransaction trans = connection.BeginTransaction();
            var obDaReq = new DaInventoryRequisition();
            try
            {
                obDaReq.DeleteRequisition(connection, trans, reqId);
                trans.Commit();
                lblMsg.Text = UIMessage.Message2User("Successfully deleted", UserUILookType.Success);
                btnSearch_Click(sender, e);
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
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
                int reqId = Convert.ToInt32(lblRowId.Text);
                lblReqId.Text = lblRowId.Text;
                Label lblReqNo = (Label)((LinkButton)sender).NamingContainer.FindControl("lblReqNo");
                txtReqNo.Text = lblReqNo.Text;
                Label lblReqDate = (Label)((LinkButton)sender).NamingContainer.FindControl("lblReqDate");
                txtDate.Text = Tools.Utility.GetDateValue(lblReqDate.Text).ToString(_dateFormat);
                Label lblReqBy = (Label)((LinkButton)sender).NamingContainer.FindControl("lblReqBy");
                txtReqBy.Text = lblReqBy.Text;
                Label lblRemarks = (Label)((LinkButton)sender).NamingContainer.FindControl("lblRemarks");
                txtDescription.Text = lblRemarks.Text;
                Label lblSectionId = (Label)((LinkButton)sender).NamingContainer.FindControl("lblSectionId");
                string sectionId = lblSectionId.Text == "" ? "-1" : lblSectionId.Text;
                ddlSection.SelectedValue = sectionId;
                var dtItems = new DataTable();
                dtItems.Columns.Add("ID", typeof(int));
                dtItems.Columns.Add("ItemID", typeof(int));
                dtItems.Columns.Add("ItemName", typeof(string));
                dtItems.Columns.Add("Spec", typeof(string));
                dtItems.Columns.Add("Size", typeof(string));
                dtItems.Columns.Add("Qty", typeof(double));
                var obDaReq = new DaInventoryRequisition();
                var dtReqItems = obDaReq.GetReqDetail(reqId);
                double totalQty = 0.0;
                foreach (DataRow row in dtReqItems.Rows)
                {
                    dtItems.Rows.Add(row["ReqDID"], row["ItemID"], row["ItemName"], row["Specifications"], row["Budle_Pack_Size"], row["ReqQty"]);
                    totalQty += GlobalFunctions.isNull(row["ReqQty"], 0);
                }
                txtTotalQty.Text = string.Format("{0:0.00}", totalQty);
                gvReqItems.DataSource = dtItems;
                gvReqItems.DataBind();
                Session["ReqItems"] = dtItems;
            }
            catch(Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
    }
}