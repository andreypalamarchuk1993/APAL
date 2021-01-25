using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Login { get; set; }
        private string Password { get; set; }
    }
}
