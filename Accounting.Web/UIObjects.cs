using Accounting.Entity;

namespace Accounting.Web
{
    public class CompanyInformation
    {
        public CompanyInformation()
        {

        }
        public CompanyInformation(Company company)
        {
            CompanyID = company.CompanyID;
            CompanyName = company.CompanyName;
            AddressLine1 = company.AddressLine1;
            AddressLine2 = company.AddressLine2;
            Phone = company.Phone;
            Fax = company.Fax;
            WebSite = company.WebSite;
            Email = company.Email;
        }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
    }
}