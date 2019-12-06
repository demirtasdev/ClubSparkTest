using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test.Models;
using Test.ViewModels;

namespace ExtensionMethods
{
    public static class TeamExtensions
    {
        public static DetailsViewModel ToDetailsVM(this Team team, TestContext db)
        {
            var detailsVM = new DetailsViewModel
            {
                ID = team.ID,
                Name = team.Name,
                Country = team.Country,
                Eliminated = team.Eliminated,
                LogoLink = $"https://img.uefa.com/imgml/TP/teams/logos/70x70/{team.ID}.png",
                ProfileLink = $"https://www.uefa.com/teamsandplayers/teams/club={team.ID}/profile/index.html"
            };

            foreach (var t in db.Teams)
            {
                if (!detailsVM.CountryList.Contains(t.Country))
                    detailsVM.CountryList.Add(t.Country);
            }

            return detailsVM;
        }

        public static void UpdateCorrespondingTeam(this DetailsViewModel detailsVM, TestContext db)
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
    }
}