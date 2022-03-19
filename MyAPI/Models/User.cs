using System;
namespace MyAPI.Models
{
    public class User
    {
        public int ID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public bool IsActive { get; set; }
        public string Nick { get; set; }
        public string Mail { get; set; }
        public string SteamId { get; set; }
        public string Password { get; set; }
        public string ConfirmCode { get; set; }


    }
}
