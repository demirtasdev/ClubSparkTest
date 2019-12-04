namespace Test.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Web.Mvc;
    using Test.ViewModels;

    [Table("Team")]
    public partial class Team
    {
        [Key]
        [Column(Order = 1)]
        public double ID { get; set; }

        [StringLength(255)]
        [Column(Order = 2)]
        public string Name { get; set; }

        [StringLength(255)]
        [Column(Order = 3)]
        public string Country { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool Eliminated { get; set; }

        public static void SaveFromDetailsVM(DetailsViewModel detailsVM, Sportslabs db)
        {
            db.Teams.Remove(db.Teams.SingleOrDefault(t => t.ID == detailsVM.ID));

            db.Teams.Add(new Team
            {
                ID = detailsVM.ID,
                Name = detailsVM.Name,
                Country = detailsVM.Country,
                Eliminated = detailsVM.Eliminated
            });

            db.SaveChanges();
        }

        public DetailsViewModel ToDetailsVM(Sportslabs db)
        {
            var detailsVM = new DetailsViewModel
            {
                ID = this.ID,
                Name = this.Name,
                Country = this.Country,
                Eliminated = this.Eliminated,
                LogoLink = $"https://img.uefa.com/imgml/TP/teams/logos/70x70/{this.ID}.png",
                ProfileLink = $"https://img.uefa.com/imgml/TP/teams/logos/70x70/{this.ID}.png"
            };

            foreach(var team in db.Teams)
            {
                if (!detailsVM.CountryList.Contains(team.Country))
                    detailsVM.CountryList.Add(team.Country);
            }

            return detailsVM;
        }
    }
}
