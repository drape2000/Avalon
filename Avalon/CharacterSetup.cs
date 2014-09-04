using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalon;
using NUnit.Framework;

namespace Avalon
{
    public class CharacterSetup
    {
        public static List<string> GenerateListCharacters(List<string> characters, NumberOfPlayers.MinionsAndServants minionsAndServants)
        {
            int teamCountResistance = 0;
            int teamCountMinions = 0;
            List<string> resistanceList = new List<string>();

            for(int i = 0; i < characters.Count; i++)
            {
            if (characters[i] == "Merlin")
            {
                teamCountResistance++;
                resistanceList.Add("Merlin");
            }else

            if (characters[i] == "Percival")
            {
                teamCountResistance++;
                resistanceList.Add("Percival");
            }else

            if (characters[i] == "Mordred")
            {
                teamCountMinions++;
                resistanceList.Add("Mordred");
            }else

            if (characters[i] == "Morgana")
            {
                teamCountMinions++;
                resistanceList.Add("Morgana");
            }else

             if (characters[i] == "Assassin")
            {
                teamCountMinions++;
                resistanceList.Add("Assassin");
            }else

             if (characters[i] == "Lancelot")
             {
                 teamCountMinions++;
                 teamCountResistance++;
                 resistanceList.Add("Bad Lancelot");
                 resistanceList.Add("Good Lancelot");
             }else
            
             if (characters[i] == "Oberon")
            {
                teamCountMinions++;
                resistanceList.Add("Oberon");
            }

           }

            for (int i = 0; i < minionsAndServants.Servants - teamCountResistance; i++)
            {
                resistanceList.Add("Servant of Arthur");
            }


            for (int i = 0; i < minionsAndServants.Minions - teamCountMinions; i++)
            {
                resistanceList.Add("Minion of Mordred");
            }

            return resistanceList;
        }

        public static List<Players> CreateNewPlayersList(List<string> PlayerNames, List<Players> players, List<Players> newPlayers)
        {
            for (int i = 0; i < PlayerNames.Count; i++)
            {
                for (int j = 0; j < players.Count; j++)
                {
                    if (PlayerNames[i] == players[j].Name)
                    {
                        newPlayers.Add(players[j]);
                    }
                }

            }

            return newPlayers;
        }

              }
            }
        
            public class Players
            {
                private string myName = "N/A";
                private string myCharacter = "N/A";
                private string myEmail = "N/A";

                public string Name
                {
                    get
                    {
                        return myName;
                    }
                    set
                    {
                        myName = value;
                    }
                }

                public string Character
                {
                    get
                    {
                        return myCharacter;
                    }
                    set
                    {
                        myCharacter = value;
                    }
                }

                public string Email
                {
                    get
                    {
                        return myEmail;
                    }
                    set
                    {
                        myEmail = value;
                    }
                }

                [TestFixture]
                public class CharacterSetupTests
                {
                    //private List<string> result = CharacterSetup.GenerateListCharacters();
                }
            }

          
           
       



