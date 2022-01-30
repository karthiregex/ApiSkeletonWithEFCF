using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatingApp.Entities
{
    public class UserMaster : IdentityUser
    {
        /// <summary>
        /// Use this class for User and Identity manager
        /// </summary>
        public string Contact { get; set; }
        public string Address { get; set; }
        public string IdProofNumber { get; set; }
        public bool? Enabled { get; set; }
    }
}
