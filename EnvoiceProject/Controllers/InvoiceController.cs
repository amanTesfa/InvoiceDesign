using Microsoft.AspNetCore.Mvc;
using EnvoiceProject.Models;

namespace EnvoiceProject.Controllers
{
    public class InvoiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EnvoiceDTO model)
        {
            return RedirectToAction("Preview", model);
        }

        public IActionResult Preview()
        {
            EnvoiceDTO model = new EnvoiceDTO();
            if (TempData["InvoiceData"] is string json && !string.IsNullOrEmpty(json))
            {
                try
                {
                    model = System.Text.Json.JsonSerializer.Deserialize<EnvoiceDTO>(json) ?? new EnvoiceDTO();
                }
                catch
                {
                    // ignore if deserialization fails
                }
            }
            return View(model);
        }
        public IActionResult GetCompany()
        {
            var company = new CompanyDTO
            {
                name = "ABC Company",
                phone = "123-456-7890",
                email = "info@abccompany.com",
                location = "123 Main St, City, Country"
            };
            return Json(company);
        }

        [HttpPost]
        public IActionResult AddLineItem(int articleId, decimal qty, decimal price)
        {
            if (qty <= 0 || price <= 0)
            {
                return BadRequest("quantity and price must be greater than zero");
            }
            var total = qty * price;
            // simplistic line id example, could be replaced with DB-generated
            var lineItemId = new Random().Next(1000, 9999);
            // look up article details from same list as GetItems
            var items = new List<ItemDTO>() {
                new ItemDTO { sn = 1, articleId = 1, unit = "PCS", articleCode = "IT-01",  articleName = "Large Toilet paper", price = 105 },
                new ItemDTO { sn = 2, articleId = 2, unit = "Carton", articleCode = "IT-02", articleName = "PLASTIC GLOVES", price = 25 } ,
                new ItemDTO { sn = 3, articleId = 3, unit = "KG", articleCode = "IT-03", articleName = "Drill Machine", price = 1225 } ,
                new ItemDTO { sn = 4, articleId = 4, unit = "Meter", articleCode = "IT-04", articleName = "PIPE VICE", price = 2225 },
                new ItemDTO { sn = 5, articleId = 5, unit = "PCS", articleCode = "IT-05", articleName = "PHOTOCOPY MACHINE", price = 26225 }
            };
            var article = items.FirstOrDefault(i => i.articleId == articleId);
            var dto = new ItemDTO
            {
                articleId = articleId,
                articleCode = article?.articleCode ?? string.Empty,
                articleName = article?.articleName ?? string.Empty,
                qty = qty,
                price = price,
                total = total,
                lineitemId = lineItemId,
                unit = article?.unit
            };
            return Json(dto);
        }
        public IActionResult GetCustomer()
        {
            // build list using properties defined in CustomerDTO model
            var customer = new List<CustomerDTO>()
            {
               new CustomerDTO {
                    customerId = 1,
                    customerName = "Gebeyehu Tilahun",
                    customerPhone = "+2519260000",
                    customerAddress = "King George IV, Addis Ababa, Ethiopia",
                    customerTinNo = "0000000000000-01"
                },
                new CustomerDTO {
                    customerId = 2,
                    customerName = "Ayida Simon",
                    customerPhone = "+119250000",
                    customerAddress = "Fifth Avenue, ny, USA",
                    customerTinNo = "0000000000000-01"
                },
                new CustomerDTO {
                    customerId = 3,
                    customerName = "Abraham Lincon",
                    customerPhone = "+519250000",
                    customerAddress = "Ave Maria Lane, london, USA",
                    customerTinNo = "0000000000000-02"
                },
                new CustomerDTO {
                    customerId = 4,
                    customerName = "Chala Gemechu",
                    customerPhone = "+2519240000",
                    customerAddress = "Russia St, Addis ababa, ethiopia",
                    customerTinNo = "0000000000000-02"
                },
            };
            return Json(customer);
        }
        public IActionResult GetItems()
        {
            var items = new List<ItemDTO>() {
                new ItemDTO { sn = 1, articleId = 1, unit = "PCS", articleCode = "IT-01",  articleName = "Large Toilet paper", price = 105 },
                new ItemDTO { sn = 2, articleId = 2, unit = "Carton", articleCode = "IT-02", articleName = "PLASTIC GLOVES", price = 25 } ,
                new ItemDTO { sn = 3, articleId = 3, unit = "KG", articleCode = "IT-03", articleName = "Drill Machine", price = 1225 } ,
                new ItemDTO { sn = 4, articleId = 4, unit = "Meter", articleCode = "IT-04", articleName = "PIPE VICE", price = 2225 },
                new ItemDTO { sn = 5, articleId = 5, unit = "PCS", articleCode = "IT-05", articleName = "PHOTOCOPY MACHINE", price = 26225 }
            };
            return Json(items);
        }
    }
}
