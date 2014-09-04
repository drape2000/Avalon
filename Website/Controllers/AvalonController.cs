using Avalon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Website.Models;

namespace Website.Controllers
{
    public class AvalonUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int NumberOfPlayers { get; set; }
    }

    public class AvalonController : Controller
    {
        private static List<string> LastSelectedPlayers;

        public ActionResult Avalon()
        {
            var list = GetUsersAvalon.GetAvalonUsers().ConvertAll(x => new AvalonUser
            {
                Name = x.Name,
                Email = x.Email,
            }); 
            var model = new AvalonViewModel { avalonList = list };
            return View("Avalon", model);
        }

        public ActionResult AvalonCreateUser(string name, string phoneNumber, string provider)
        {
            var model = AvalonViewModelMethod();
            CreateUser.InputUserInfo(name, phoneNumber, provider);

            return View("Avalon", model);
        }

        public ActionResult AvalonNumberOfPlayers(int numberOfPlayers)
        {
            Website.Controllers.AvalonUser model = new Website.Controllers.AvalonUser();

            var moel = GetViewModel(numberOfPlayers);

            if (LastSelectedPlayers != null && numberOfPlayers == LastSelectedPlayers.Count)
            {
                moel.LastSelected = LastSelectedPlayers;
            }

            return View("AvalonPlayers", moel);
        }



        public ActionResult AvalonSpecialCharacters(List<string> Character, List<string> PlayerNames, bool AutoSelect)
        {
            var model = AvalonViewModelMethod();

            if (AutoSelect)
            {
                PlayerNames = LastSelectedPlayers;
            }

            NumberOfPlayers.MinionsAndServants minions = NumberOfPlayers.DetermineMinionsAndServents(PlayerNames.Count);

            List<string> characterList = CharacterSetup.GenerateListCharacters(Character, minions);

            List<Players> players = GetUsersAvalon.GetAvalonUsers();

            List<Players> newPlayers = new List<Players>();

            newPlayers = CharacterSetup.CreateNewPlayersList(PlayerNames, players, newPlayers);

            List<Players> assignedCharacters = CharacterAssignment.AssignCharacters(PlayerNames.Count, characterList, newPlayers);

            LastSelectedPlayers = PlayerNames;

            SendEmail.SendOutEmails(PlayerNames.Count, assignedCharacters);

            return View("Avalon",model);
        }

        private static AvalonViewModel AvalonViewModelMethod()
        {
            var list = GetUsersAvalon.GetAvalonUsers().ConvertAll(x => new AvalonUser
            {
                Name = x.Name,
                Email = x.Email,
            });
            var model = new AvalonViewModel { avalonList = list };
            return model;
        }


        public ActionResult AvalonGetUsers()
        {
            var model = AvalonViewModelMethod();
            List<Players> list = GetUsersAvalon.GetAvalonUsers();

            return View("Avalon", model);
        }

        private static Website.Models.AvalonViewModel GetViewModel(int noplayers)
        {
            var list = GetUsersAvalon.GetAvalonUsers().ConvertAll(x => new AvalonUser
            {
                Name = x.Name,
                Email = x.Email,
            });

            Website.Models.AvalonViewModel model = new Website.Models.AvalonViewModel();
            model.avalonList = list;

            model.intPlayers = noplayers;

            return model;
        }

        public ActionResult AvalonDeleteUser(string delete)
        {
            var model = AvalonViewModelMethod();

            DeleteUser deleteIt = new DeleteUser();
            deleteIt.DeleteUserName(delete);

            return View("Avalon", model);
        }

        public ActionResult AvalonCreateUserPage()
        {
            var model = AvalonViewModelMethod();

            return View("Avalon", model);
        }
    }
    public enum Character { Merlin, Percival, Assassin, Mordred, Morgana, Oberon }
}

