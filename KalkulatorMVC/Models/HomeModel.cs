using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KalkulatorMVC.Models
{
    public class HomeModel
    {
        [Required(ErrorMessage ="a")]
        public string Test { get; set; }
        public int val;
        public string action;
    }
}