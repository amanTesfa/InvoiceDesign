
using EnvoiceProject.Models;

namespace WebApplication1
{
    public partial class prtInvoice : DevExpress.XtraReports.UI.XtraReport
    {
        public prtInvoice(EnvoiceDTO envoice)
        {
            InitializeComponent();
            var company = new CompanyDTO
            {
                name = "ABC Company",
                phone = "123-456-7890",
                email = "info@abccompany.com",
                location = "123 Main St, City, Country"
            };
            envoice.company = company;
            objectDataSource1.DataSource = envoice;

        }
     
    }
}
