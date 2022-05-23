namespace JobsDatingApp.Data.Models
{
    public class CompanyToHHCompany
    {
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
        public int? HHCompanyId { get; set; }
    }
}
