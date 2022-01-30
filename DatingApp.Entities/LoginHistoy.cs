using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DatingApp.Entities
{
    public class LoginHistoy
    {
        [Key]
        public int LoginTransId { get; set; }
        public string LoginUser { get; set; }
        public DateTime Logintime { get; set; }

        public static implicit operator List<object>(LoginHistoy v)
        {
            throw new NotImplementedException();
        }
    }
}
