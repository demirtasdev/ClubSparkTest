using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.ViewModels
{
    public class DetailsViewModel
    {
        public DetailsViewModel()
        {
            this.CountryList = new List<string>();
        }

        public double ID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public bool Eliminated { get; set; }

        [Display(Name="Logo")]
        public string LogoLink { get; set; }

        [Display(Name = "Club Profile")]
        public string ProfileLink { get; set; }
        public List<string> CountryList { get; set; }
    }
}