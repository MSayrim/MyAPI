using System;
using System.ComponentModel.DataAnnotations;

namespace MyAPI.Models
{
    public class SaledItem
    {
        public int ID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public bool IsActive { get; set; }
        public String Name { get; set; }
        public String Tumbnail { get; set; }
        public String Video { get; set; }
        public int SellerID { get; set; }
        public string PaymentType { get; set; }
        public Double Price { get; set; }
        public int BuyerID { get; set; }
    }
}
