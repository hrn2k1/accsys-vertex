using Accounting.DataAccess;
using Accounting.Entity;
using Accounting.Utility;
using AccSys.Web.WebControls;
using System;
using System.Web.UI.WebControls;
using Tools;


namespace AccSys.Web
{
    public partial class frmBusinessTypes : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadBusinessTypes();
                    LoadBusinessSubTypes();
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
        private void LoadBusinessTypes()
        {
            var companyId = GlobalFunctions.isNull(Session["CompanyID"], 0);
            gvData.DataSourceID = "odsCommon";
            odsCommon.SelectParameters["SelectedColumns"].DefaultValue = @" BusinessTypeID, Name ";
            odsCommon.SelectParameters["FromTable"].DefaultValue = @" BusinessType ";
            odsCommon.SelectParameters["Where"].DefaultValue = " 1=1 ";
            odsCommon.SelectParameters["OrderBy"].DefaultValue = " Name ";
            gvData.PageIndex = 0;
            gvData.DataBind();
            ddlType.DataSource = new BusinessTypeDA().getBusinessType(0);
            ddlType.DataTextField = "Name";
            ddlType.DataValueField = "BusinessTypeID";
            ddlType.DataBind();
        }
        private void LoadBusinessSubTypes()
        {
            gvSubData.DataSourceID = "odsCommonSub";
            odsCommonSub.SelectParameters["SelectedColumns"].DefaultValue = @" BusinessSubTypeID, BusinessSubType.Name, BusinessSubType.BusinessTypeID,  BusinessType.Name AS BusinessTypeName ";
            odsCommonSub.SelectParameters["FromTable"].DefaultValue = @" BusinessSubType INNER JOIN BusinessType ON BusinessSubType.BusinessTypeID=BusinessType.BusinessTypeID ";
            odsCommonSub.SelectParameters["Where"].DefaultValue = " 1=1 ";
            odsCommonSub.SelectParameters["OrderBy"].DefaultValue = " BusinessType.Name, BusinessSubType.Name ";
            gvSubData.PageIndex = 0;
            gvSubData.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var type = new BusinessType()
                {
                    BusinessTypeID = Convert.ToInt32(lblId.Text),
                    Name = txtName.Text.Trim()
                };
                new BusinessTypeDA().SaveOrUpdate(type);
                LoadBusinessTypes();
                lblId.Text = "0";
                txtName.Text = "";
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
        protected void btnSubSave_Click(object sender, EventArgs e)
        {
            try
            {
                var type = new BusinessSubType()
                {
                    BusinessSubTypeID = Convert.ToInt32(lblSubId.Text),
                    Name = txtSubName.Text.Trim(),
                    BusinessTypeID = ddlType.SelectedValue.ToInt()
                };
                new BusinessSubTypeDA().SaveOrUpdate(type);
                LoadBusinessSubTypes();
                lblSubId.Text = "0";
                txtSubName.Text = "";
            }
            catch (Exception ex)
            {
                lblSubMsg.Text = ex.CustomDialogMessage();
            }
        }
        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            Label lblRowId = (Label)((LinkButton)sender).NamingContainer.FindControl("lblId");
            int id = lblRowId.Text.ToInt();

            try
            {
                new BusinessTypeDA().Delete(id);
                lblMsg.Text = UIMessage.Message2User("Successfully deleted", UserUILookType.Success);
                LoadBusinessTypes();
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
        protected void lbtnSubDelete_Click(object sender, EventArgs e)
        {
            Label lblRowId = (Label)((LinkButton)sender).NamingContainer.FindControl("lblId");
            int id = lblRowId.Text.ToInt();

            try
            {
                new BusinessSubTypeDA().Delete(id);
                lblSubMsg.Text = UIMessage.Message2User("Successfully deleted", UserUILookType.Success);
                LoadBusinessSubTypes();
            }
            catch (Exception ex)
            {
                lblSubMsg.Text = ex.CustomDialogMessage();
            }
        }
        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Label lblRowId = (Label)((LinkButton)sender).NamingContainer.FindControl("lblId");
                lblId.Text = lblRowId.Text;
                Label lblName = (Label)((LinkButton)sender).NamingContainer.FindControl("lblName");
                txtName.Text = lblName.Text;
                lblMsg.Text = "";
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.CustomDialogMessage();
            }
        }
        protected void lbtnSubEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Label lblRowId = (Label)((LinkButton)sender).NamingContainer.FindControl("lblId");
                lblSubId.Text = lblRowId.Text;
                Label lblName = (Label)((LinkButton)sender).NamingContainer.FindControl("lblName");
                txtSubName.Text = lblName.Text;
                Label lblTypeId = (Label)((LinkButton)sender).NamingContainer.FindControl("lblTypeId");
                ddlType.SelectedValue = lblTypeId.Text;
                lblSubMsg.Text = "";
            }
            catch (Exception ex)
            {
                lblSubMsg.Text = ex.CustomDialogMessage();
            }
        }
    }
}