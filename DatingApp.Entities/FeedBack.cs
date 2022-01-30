using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DatingApp.Entities
{
    public class FeedBack
    {
        [Key]
        public int FeedbackId { get; set; }
        public string FeedbackDescription { get; set; }
        public DateTime FeedbackDate { get; set; }
    }
}
