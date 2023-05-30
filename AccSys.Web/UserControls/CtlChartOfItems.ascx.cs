using Accounting.DataAccess;
using Accounting.Entity;
using Accounting.Utility;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Tools;

namespace AccSys.Web.UserControls
{
    public partial class CtlChartOfItems : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnSearch_Click(sender, e);
                LoadItemTree();
            }

        }
        private string InputValidation()
        {
            string err = string.Empty;
            try
            {
                if (txtName.Text.Trim() == "")
                    return "Enter a valid Name";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return string.Empty;
        }
        private ItemGroup CreateItemGroupObject()
        {
            var groupobj = new ItemGroup();
            groupobj.ItemGroupID = int.Parse(lblId.Text);
            groupobj.GroupName = txtName.Text;
            groupobj.ParentGroupID = Convert.ToInt32(ddlParent.SelectedValue);
            groupobj.GroupCode = "";
            groupobj.GroupDepth = -1;
            groupobj.CompanyID = Tools.Utility.IsNull<int>(Session["CompanyId"], 0);
            return groupobj;
        }
        private ChartsOfItem CreateItemObject()
        {
            ChartsOfItem objItem = null;
            try
            {
                objItem = new ChartsOfItem();
                objItem.ItemID = int.Parse(lblId.Text);
                objItem.ItemName = txtName.Text;
                objItem.ItemPurpose = txtPurpose.Text;
                objItem.ItemCode = txtItemCode.Text;
                objItem.HSCode = txtHSCode.Text;
                objItem.GroupID = Convert.ToInt32(ddlParent.SelectedValue);
                objItem.UnitID = Convert.ToInt32(ddlUnit.SelectedValue);
                objItem.ItemCatagory = ddlCategory.SelectedValue;
                objItem.ItemStatus = ddlStatus.SelectedValue;
                double.TryParse(txtUnitPrice.Text, out double unitprice);
                objItem.UnitPrice = unitprice;
                int.TryParse(txtOpeningQty.Text, out int opQty);
                objItem.OpeningQty = opQty;
                objItem.OpeningValue = opQty * unitprice;
                int.TryParse(txtMinQty.Text, out int minQty);
                objItem.MinQty = minQty;
                objItem.SizeID = 0;
                objItem.ShadeID = 0;
                objItem.CountID = 0;
                objItem.ColorID = 0;
                objItem.ItemDescription = txtName.Text;
                objItem.CompanyID = Tools.Utility.IsNull<int>(Session["CompanyId"], 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objItem;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection connection = null;
            try
            {
                string err = InputValidation();

                if (err != string.Empty)
                {
                    lblPanel1Msg.Text = UIMessage.Message2User(err, UserUILookType.Warning);
                    return;
                }

                connection = new SqlConnection(ConnectionHelper.DefaultConnectionString);
                connection.Open();
                var daChartOfAcc = new DAChartsOfItem();
                if (ddlType.SelectedIndex == 1)
                {
                    var group = CreateItemGroupObject();
                    daChartOfAcc.SaveOrUpdateItemGroup(group, connection);
                }
                else
                {
                    var item = CreateItemObject();
                    daChartOfAcc.SaveOrUpdateItem(item, connection);
                }
                connection.Close();
                btnReset_Click(sender, e);
                btnSearch_Click(sender, e);
                ddlParent.Bind();
                lblPanel1Msg.Text = UIMessage.Message2User("Saved successfully", UserUILookType.Success);

            }
            catch (Exception ex)
            {
                if (connection.State != ConnectionState.Closed) connection.Close();
                lblPanel1Msg.Text = ex.CustomDialogMessage();
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                lblId.Text = "0";
                txtName.Text = "";
                txtItemCode.Text = "";
                txtHSCode.Text = "";
                txtUnitPrice.Text = "0.0";
                txtOpeningQty.Text = "0";
                txtOpeningValue.Text = "0.0";
                txtMinQty.Text = "0";
                txtCurrentQty.Text = "0";
                txtPurpose.Text = "";
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }
        private string CreateWhere()
        {
            string where = string.Format(" CompanyID={0}", Session["CompanyID"] ?? 1);
            if (ddlSrcItemGroup.SelectedValue != "0" && ddlSrcItemGroup.SelectedValue != "")
                where += (where != "" ? " AND " : "") + string.Format(" ParentId={0} ", ddlSrcItemGroup.SelectedValue);
            if(txtSrcName.Text.Trim() != "")
            {
                where += (where != "" ? " AND " : "") + string.Format(" Name LIKE '%{0}%' ", txtSrcName.Text.Trim());
            }
            if(ddlSrcType.SelectedValue != "0" && ddlSrcType.SelectedValue != "")
            {
                where += (where != "" ? " AND " : "") + string.Format(" Type='{0}' ", ddlSrcType.SelectedValue);
            }
            return where;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                gvData.DataSourceID = "odsCommon";
                odsCommon.SelectParameters["SelectedColumns"].DefaultValue = @" * ";
                odsCommon.SelectParameters["FromTable"].DefaultValue = @" VW_ChartOfItems ";
                odsCommon.SelectParameters["Where"].DefaultValue = CreateWhere();
                odsCommon.SelectParameters["OrderBy"].DefaultValue = " Sorting ";

                if (sender != null)
                    gvData.PageIndex = 0;
                gvData.DataBind();

                lblMsg.Text = "";
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }
        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Label lblRowId = (Label)((LinkButton)sender).NamingContainer.FindControl("lblId");
                Label lblType = (Label)((LinkButton)sender).NamingContainer.FindControl("lblType");
                if (lblType.Text == "Group")
                {
                    ItemGroup obj = new DAChartsOfItem().GetGroup(Convert.ToInt32(lblRowId.Text));
                    if (obj != null)
                    {
                        ddlType.SelectedIndex = 1;
                        lblId.Text = obj.ItemGroupID.ToString();
                        txtName.Text = obj.GroupName;
                        if (obj.ParentGroupID > 0)
                            ddlParent.SelectedValue = obj.ParentGroupID.ToString();
                        else
                            ddlParent.SelectedValue = "0";
                    }
                }
                else
                {
                    ChartsOfItem obj = new DAChartsOfItem().GetItem(Convert.ToInt32(lblRowId.Text));
                    if (obj != null)
                    {
                        ddlType.SelectedIndex = 0;
                        lblId.Text = obj.ItemID.ToString();
                        txtName.Text = obj.ItemName;
                        if (obj.GroupID > 0)
                            ddlParent.SelectedValue = obj.GroupID.ToString();
                        else
                            ddlParent.SelectedValue = "0";

                        txtItemCode.Text = obj.ItemCode;
                        txtHSCode.Text = obj.HSCode;
                        txtUnitPrice.Text = obj.UnitPrice.ToString("0.00");
                        txtOpeningQty.Text = obj.OpeningQty.ToString();
                        txtOpeningValue.Text = (obj.UnitPrice * obj.OpeningQty).ToString("0.00");
                        txtMinQty.Text = obj.MinQty.ToString();
                        txtCurrentQty.Text = obj.CurrentItem.ToString();
                        txtPurpose.Text = obj.ItemPurpose;
                        ddlCategory.SelectedValue = obj.ItemCatagory;
                        ddlStatus.SelectedValue = obj.ItemStatus;
                        ddlUnit.SelectedValue = obj.UnitID.ToString();
                    }
                }
                ddlType_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool itemRow = ddlType.SelectedIndex == 0;
            trItemRow1.Visible = trItemRow2.Visible = trItemRow3.Visible = trItemRow4.Visible = trItemRow5.Visible = itemRow;
            ddlCategory.Enabled = itemRow;
        }

        #region Tree
        private DataSet dsGLs;
        private void LoadItemTree()
        {
            try
            {
                dsGLs = new DataSet();

                DataTable dtItems = DAChartsOfItem.GetChartOfItems(Convert.ToInt32(Session["CompanyID"] ?? 1));

                dsGLs.Tables.Add(dtItems);
                dsGLs.Tables[0].TableName = "Items";
                DataTable dtGroups = DAChartsOfItem.GetItemGroups(Convert.ToInt32(Session["CompanyID"] ?? 1));
                dsGLs.Tables.Add(dtGroups);
                dsGLs.Tables[1].TableName = "Groups";

                dsGLs.Relations.Add("DirRelation", dsGLs.Tables["Groups"].Columns["Id"], dsGLs.Tables["Items"].Columns["ParentId"], false);

                if (TreeView1.Nodes.Count > 0) TreeView1.Nodes.Clear();
                TreeNode node = new TreeNode();
                foreach (DataRow row in dsGLs.Tables["Groups"].Rows)
                {
                    if (row.Field<object>("ParentId") == DBNull.Value || row.Field<object>("ParentId") == null ||  row.Field<int>("ParentId") == 0)
                    {
                        if (row.Field<string>("Type") == "Item")
                            node = new TreeNode(string.Format("<B style='color:red'>{0}</B>", row.Field<string>("Name")), row.Field<object>("Id").ToString(), "/images/small.png");
                        else
                            node = new TreeNode(string.Format("{0}", row.Field<string>("Name")), row.Field<object>("Id").ToString());
                        TreeView1.Nodes.Add(node);
                        AddNode(row, node);
                    }
                }
                TreeView1.ExpandAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void AddNode(DataRow dr, TreeNode n)
        {
            try
            {
                var rows = dr.GetChildRows("DirRelation");

                foreach (DataRow r in rows)
                {
                    TreeNode nn = new TreeNode(r.Field<string>("Name"), r.Field<object>("Id").ToString());
                    if(r.Field<string>("Type") == "Item") nn.ImageUrl = "/images/small.png";
                    n.ChildNodes.Add(nn);
                    AddNode(r, nn);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {

        }
        protected void lbtnExpandAll_Click(object sender, EventArgs e)
        {
            TreeView1.ExpandAll();
        }

        protected void lbtnCollapAll_Click(object sender, EventArgs e)
        {
            TreeView1.CollapseAll();
        }

        protected void lbtnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                LoadItemTree();

            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Label lblRowId = (Label)((LinkButton)sender).NamingContainer.FindControl("lblId");
                Label lblType = (Label)((LinkButton)sender).NamingContainer.FindControl("lblType");
                if (lblType.Text == "Group")
                {
                    new DAChartsOfItem().DeleteGroup(Convert.ToInt32(lblRowId.Text));
                    ddlParent.Bind();
                }
                else
                {
                 new DAChartsOfItem().DeleteItem(Convert.ToInt32(lblRowId.Text));
                    
                }
                btnSearch_Click(sender, e);
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
            }
        }
    }
}