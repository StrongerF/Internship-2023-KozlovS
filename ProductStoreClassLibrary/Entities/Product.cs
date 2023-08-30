using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStoreClassLibrary.Entities
{
    public class Product
    {
        private double price;

        public int ID { get; set; }
        public string Name { get; set; }
        public double Price
        {
            get { return price; }
            set { price = Math.Round(value, 2); }
        }
        public int Quantity { get; set; }
        public int MinQuantity { get; set; }
        public string Unit { get; set; }
        public int CategoryID { get; set; }

        public string QuantityColor
        {
            get
            {
                if (Quantity < MinQuantity)
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

        public string MinQuantityToString
        {
            get
            {
                return Convert.ToString(MinQuantity);
            }
        }
    }
}
