
using EnvoiceProject.Models;

namespace WebApplication1
{
    public partial class prtInvoice : DevExpress.XtraReports.UI.XtraReport
    {
        public prtInvoice(EnvoiceDTO envoice)
        {
            InitializeComponent();
            try
            {
                var company = new CompanyDTO
                {
                    name = "ABC plc. Company",
                    phone = "123-456-7890",
                    email = "info@abcCompany.com",
                    location = "Addis Ababa, Ethiopia"
                };
                envoice.company = company;
                envoice.voucher.amountInwords = changeNumericToWords(envoice.voucher?.voucherGrandTotal ?? 0);
                this.DataSource = envoice;
            }
            catch
            {

            }

        }
        private bool IsNegative = false;
        private string changeNumericToWords(decimal numb)
        {
            String num = numb.ToString();
            return changeToWords(num);
        }
        private String changeToWords(String numb)
        {
            if (numb.Contains(","))
            {
                numb = numb.Replace(",", "");
            }
            if (numb.Contains("-"))
            {
                IsNegative = true;
            }
            String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
            String endStr = "ETB Only";
            try
            {
                int decimalPlace = numb.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = numb.Substring(0, decimalPlace);
                    points = numb.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr = "Birr and ";
                        endStr = "Cents Only";
                        pointStr = translateCents(points);
                    }
                }
                else if (decimalPlace == -1)
                {
                    endStr = "Birr Only";
                }
                val = String.Format("{0} {1}{2} {3}", translateWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);
            }
            catch {; }
            return val;
        }
        private String translateWholeNumber(String number)
        {
            string word = "";
            try
            {
                bool beginsZero = false;
                bool isDone = false;
                double dblAmt = (Convert.ToDouble(number));
                if (dblAmt > 0)
                {
                    beginsZero = number.StartsWith("0");
                    number = number.TrimStart(new char[] { '0' });
                    int numDigits = number.Length;
                    int pos = 0;
                    String place = "";
                    switch (numDigits)
                    {
                        case 1://ones' range
                            word = ones(number);
                            isDone = true;
                            break;
                        case 2://tens' range
                            word = tens(number);
                            isDone = true;
                            break;
                        case 3://hundreds' range
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4://thousands' range
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            // isDone = false;
                            break;
                        case 7://millions' range
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Million ";
                            break;
                        case 10://Billions's range
                            pos = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {
                        word = translateWholeNumber(number.Substring(0, pos)) + place + translateWholeNumber(number.Substring(pos));
                        if (beginsZero) word = " and " + word.Trim();
                    }
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
                else
                {
                    if (dblAmt > 0)
                    {
                        word = ones(dblAmt.ToString());
                    }
                }
            }
            catch {; }
            return word.Trim();
        }
        private String tens(String digit)
        {
            int digt = Convert.ToInt32(digit);
            String name = null;
            switch (digt)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (digt > 0)
                    {
                        name = tens(digit.Substring(0, 1) + "0") + " " + ones(digit.Substring(1));
                    }
                    break;
            }
            return name;
        }
        private String ones(String digit)
        {
            int digt = Convert.ToInt32(digit);
            String name = "";
            switch (digt)
            {
                case 0:
                    name = "Zero";
                    break;
                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }
        private String translateCents(String cents)
        {
            String cts = "", digit = "", engOne = "";
            bool isDone = false;

            if (digit.Equals("0"))
            {
                engOne = "Zero";
            }
            else
            {
                switch (cents.Length)
                {
                    case 1://ones' range
                        cts = ones(cents);
                        isDone = true;
                        break;
                    case 2://tens' range
                        cts = tens(cents);
                        isDone = true;
                        break;
                }

            }
            cts += " " + engOne;

            return cts;
        }

    }

}
