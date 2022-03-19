using System;
using System.ComponentModel.DataAnnotations;

namespace MyAPI.Models
{
    public class BaseModel
    {
        [Key]
        public int ID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public bool IsActive { get; set; }
    }
}
