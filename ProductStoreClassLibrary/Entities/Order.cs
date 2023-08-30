using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStoreClassLibrary.Entities
{
    public class Order
    {
        private double price;
        public int ID { get; set; }
        public int BuyerID { get; set; }
        public int ProductID { get; set; }
        public double Price
        {
            get { return price; }
            set { price = Math.Round(value, 2); }
        }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public bool? IsAccepted { get; set; }


        public string AcceptColor
        {
            get
            {
                if (IsAccepted == true)
                {
                    return "#99DD99";
                }
                else if (IsAccepted == false)
                {
                    return "#DD9999";
                }
                else
                {
                    return "#DDDDDD";
                }
            }
        }

        public string PriceToString
        {
            get
            {
                return Convert.ToString(Price);
            }
        }
        public string QuantityToString
        {
            get
            {
                return Convert.ToString(Quantity);
            }
        }

        public string ProductName
        {
            get
            {
                return Convert.ToString(ServerRequests.GetObject("Product", "Name", ProductID));
            }
        }
        public string BuyerPhoneNumber
        {
            get
            {
                return Convert.ToString(ServerRequests.GetObject("User", "PhoneNumber", BuyerID));
            }
        }
        public string BuyerFullName
        {
            get
            {
                return Convert.ToString(ServerRequests.GetObject("User", "FullName", BuyerID));
            }
        }
        public string ProductUnit
        {
            get
            {
                return Convert.ToString(ServerRequests.GetObject("Product", "Unit", ProductID));
            }
        }

        public string DateToString
        {
            get
            {
                return Date.ToString("dd.MM.yyyy");
            }
        }

        public string AcceptStatus
        {
            get
            {
                if (IsAccepted == true)
                {
                    return "Принято";
                }
                else if (IsAccepted == false)
                {
                    return "Отменено";
                }
                else
                {
                    return "Не рассмотрено";
                }
            }
        }
    }
}
