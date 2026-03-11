namespace EnvoiceProject.Models
{
    public class EnvoiceDTO
    {
        #region Company Info
        public CompanyDTO company { get; set; } = new CompanyDTO();
        #endregion

        #region Customer Info
        public CustomerDTO customer { get; set; } = new CustomerDTO();
        #endregion

        #region voucher info
        public VoucherDTO voucher { get; set; } = new VoucherDTO();
        #endregion
        #region List of items
        public List<ItemDTO> itemList { get; set; } = new List<ItemDTO>();
        #endregion
        #region List of items
        public List<TermsDTO>? termList { get; set; }
        #endregion
    }
    public class ItemDTO
    {
        public int sn { get; set; }
        public int lineitemId { get; set; }
        public int articleId { get; set; }
        public string articleCode { get; set; } = string.Empty;
        public string articleName { get; set; } = string.Empty;
        public decimal qty { get; set; }
        public decimal price { get; set; }
        public decimal total { get; set; }
        public string? unit { get; set; }

    }
    public class TermsDTO
    {
        public int id { get; set; }
        public string description { get; set; } = string.Empty;
    }
    public class CompanyDTO
    {
        public string name { get; set; } = string.Empty;
        public string? phone { get; set; }
        public string? email { get; set; }
        public string? location { get; set; }
    }
    public class CustomerDTO
    {
        public int customerId { get; set; }
        public string customerName { get; set; } = string.Empty;
        public string? customerPhone { get; set; }
        public string? customerAddress { get; set; }
        public string? customerEmail { get; set; }
        public string? customerTinNo { get; set; }
    }
    public class VoucherDTO
    {
        public string voucherType { get; set; } = string.Empty;
        public int voucherId { get; set; }
        public string voucherNumber { get; set; } = string.Empty;
        public string voucherReference { get; set; } = string.Empty;
        public string voucherDate { get; set; } = string.Empty;
        public decimal? voucherSubtotal { get; set; }
        public decimal? voucherAdditionalCharge { get; set; }
        public string? amountInwords { get; set; }
        public decimal? voucherTax { get; set; }
        public decimal? voucherGrandTotal { get; set; }
        public string? voucherPaymentInfo { get; set; }
        public string? voucherPreparedBy { get; set; }
        // additional free-form remark field
        public string? voucherRemark { get; set; }
    }
}
