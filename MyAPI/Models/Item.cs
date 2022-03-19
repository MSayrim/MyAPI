using System;

namespace MyAPI.Models
{
    public class Item
    {
        public int ID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public bool IsActive { get; set; }
        public String Name { get; set; }
        public String Tumbnail { get; set; }
        public String Video { get; set; }
    }
}
