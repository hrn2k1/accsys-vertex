using System; using WebForm.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using AMS.DAO;
using CustomDropDown;
using SecurityManagement;

namespace AccSys.Web.DbControls
{
    public class ProjectDropDownListChosen : DropDownListChosen
    {
        private string _NullItemValue = null;

        public string NullItemValue
        {
            get { return _NullItemValue; }
            set { _NullItemValue = value; }
        }
        private string _NullItemText = string.Empty;

        public string NullItemText
        {
            get { return _NullItemText; }
            set { _NullItemText = value; }
        }
        public ProjectDropDownListChosen()
            : base()
        {
            //this.CssClass = "WindowsStyle";
            this.AppendDataBoundItems = false;
            this.Load += new EventHandler(ProjectDropDownListChosen_Load);


        }
        public void Bind()
        {
            ProjectDropDownListChosen_Load(null, null);
        }
        void ProjectDropDownListChosen_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.Page.IsPostBack)
                {
                    string Where = string.Format("CompanyID={0} AND isActive=1", HttpContext.Current.Session.CompanyId());


                    DataTable dtdata = DalProject.getProjects(Where, "ProjectName");
                    if (_NullItemValue != null)
                    {
                        DataRow dr = dtdata.NewRow();
                        dr["ProjectID"] = _NullItemValue;
                        dr["ProjectName"] = _NullItemText;
                        dtdata.Rows.InsertAt(dr, 0);

                    }
                    this.DataSource = dtdata;
                    this.DataTextField = "ProjectName";
                    this.DataValueField = "ProjectID";
                    this.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    public class ProjectDropDownList: DropDownList
    {
        private string _NullItemValue = null;

        public string NullItemValue
        {
            get { return _NullItemValue; }
            set { _NullItemValue = value; }
        }
        private string _NullItemText = string.Empty;

        public string NullItemText
        {
            get { return _NullItemText; }
            set { _NullItemText = value; }
        }
        public ProjectDropDownList()
            : base()
        {
            //this.CssClass = "WindowsStyle";
            this.AppendDataBoundItems = false;
            this.Load += new EventHandler(ProjectDropDownList_Load);


        }
        public void Bind()
        {
            ProjectDropDownList_Load(null, null);
        }
        void ProjectDropDownList_Load(object sender, EventArgs e)
        {
            try
            {
                if (!this.Page.IsPostBack)
                {
                    string Where = string.Format("CompanyID={0} AND isActive=1", HttpContext.Current.Session.CompanyId());


                    DataTable dtdata = DalProject.getProjects(Where, "ProjectName");
                    if (_NullItemValue != null)
                    {
                        DataRow dr = dtdata.NewRow();
                        dr["ProjectID"] = _NullItemValue;
                        dr["ProjectName"] = _NullItemText;
                        dtdata.Rows.InsertAt(dr, 0);

                    }
                    this.DataSource = dtdata;
                    this.DataTextField = "ProjectName";
                    this.DataValueField = "ProjectID";
                    this.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}