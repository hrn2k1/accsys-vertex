using System;
using System.Web.UI;
using System.Web.UI.WebControls;

[assembly: TagPrefix("AccSys.Web.WebControls", "asp")]
namespace AccSys.Web.WebControls
{
    public class HrnHyperLink : HyperLink
    {
        private SecurityCommand _securityCommandName = SecurityCommand.View;

        public SecurityCommand SecurityCommandName
        {
            get { return _securityCommandName; }
            set { _securityCommandName = value; }
        }

        protected override void OnLoad(EventArgs e)
        {

            //if (!Page.IsPostBack)
            //{
            bool accessibility;
            string msg = "You have no access to this";
            switch (SecurityCommandName)
            {
                case SecurityCommand.Add:
                    accessibility = ((BasePage)Page).CanAdd;
                    Enabled = accessibility;
                    if (!accessibility)
                    {
                        ToolTip = msg;
                        Attributes.Add("onclick", "alert('" + msg + "');");
                    }
                    break;
                case SecurityCommand.Edit:
                    accessibility = ((BasePage)Page).CanEdit;
                    Enabled = accessibility;
                    if (!accessibility)
                    {
                        ToolTip = msg;
                        Attributes.Add("onclick", "alert('" + msg + "');");
                    }
                    break;
                case SecurityCommand.Delete:
                    accessibility = ((BasePage)Page).CanDelete;
                    Enabled = accessibility;
                    if (!accessibility)
                    {
                        ToolTip = msg;
                        Attributes.Add("onclick", "alert('" + msg + "');");
                    }
                    break;
                case SecurityCommand.View:
                    accessibility = ((BasePage)Page).CanView;
                    Enabled = accessibility;
                    if (!accessibility)
                    {
                        ToolTip = msg;
                        Attributes.Add("onclick", "alert('" + msg + "');");
                    }
                    break;
            }
            //}

        }
    }
}
