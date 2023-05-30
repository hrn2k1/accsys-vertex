using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace AccSys.Web.WebControls
{
    public class BasePage : Page
    {
        // Add the following controls to your page
        /*
         <asp:HiddenField runat="server" ID="HfCanView" />
         <asp:HiddenField runat="server" ID="HfCanAdd" />
         <asp:HiddenField runat="server" ID="HfCanEdit" />
         <asp:HiddenField runat="server" ID="HfCanDelete" />
         
         */

        protected HiddenField HfCanView;
        protected HiddenField HfCanAdd;
        protected HiddenField HfCanEdit;
        protected HiddenField HfCanDelete;

        public bool CanView
        {
            get
            {
                if (HfCanView != null && !string.IsNullOrEmpty(HfCanView.Value))
                {
                    return Convert.ToBoolean(HfCanView.Value);
                }
                return false;
            }
        }
        public bool CanAdd
        {
            get
            {
                if (HfCanAdd != null && !string.IsNullOrEmpty(HfCanAdd.Value))
                {
                    return Convert.ToBoolean(HfCanAdd.Value);
                }
                return false;
            }
        }
        public bool CanEdit
        {
            get
            {
                if (HfCanEdit != null && !string.IsNullOrEmpty(HfCanEdit.Value))
                {
                    return Convert.ToBoolean(HfCanEdit.Value);
                }

                return false;
            }
        }

        public bool CanDelete
        {
            get
            {
                if (HfCanDelete != null && !string.IsNullOrEmpty(HfCanDelete.Value))
                {
                    return Convert.ToBoolean(HfCanDelete.Value);
                }
                return false;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            EnsureChildControls();

            if (!IsPostBack)
            {
                string ResourcePath = Request.Path.Remove(0, 1);
                if(!ResourcePath.EndsWith(".aspx"))
                {
                    ResourcePath = $"{ResourcePath}.aspx";
                }
                ResourceAuthorization objAuth;
                try
                {
                    objAuth = DalResourceAuthorization.GetAuthorization(Session, ResourcePath);
                }
                catch (Exception ex)
                {
                    Response.Write("Something went wrong. Error: " + ex.Message);
                    return;
                }
                if (objAuth != null)
                {
                    if (objAuth.CanView == false)
                    {
                        string unAuthHtml = "<h2 style='font-size:4rem;'>You don't have access to this page</h2>";
                        var placeHolderId = MasterPageFile.ToLower().Contains("site.master") ? "MainContent" : "ContentPlaceHolder1";

                        var cph = (ContentPlaceHolder)Master.FindControl(placeHolderId);
                        if (cph != null)
                        {
                            var lc = new LiteralControl()
                            {
                                Text = unAuthHtml
                            };
                            foreach (Control control in cph.Controls)
                            {
                                if (!(control is DataSourceControl))
                                    control.Visible = false;
                            }
                            cph.Controls.AddAt(0, lc);
                        }
                    }


                    if (HfCanView != null)
                    {
                        HfCanView.Value = objAuth.CanView.ToString();
                    }
                    if (HfCanAdd != null)
                    {
                        HfCanAdd.Value = objAuth.CanAdd.ToString();
                    }
                    if (HfCanEdit != null)
                    {
                        HfCanEdit.Value = objAuth.CanEdit.ToString();
                    }
                    if (HfCanDelete != null)
                    {
                        HfCanDelete.Value = objAuth.CanDelete.ToString();
                    }
                }

            }

            base.OnLoad(e);
        }
    }
}