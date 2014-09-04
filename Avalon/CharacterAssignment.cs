using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalon
{
    public class CharacterAssignment
    {
        public static List<Players> AssignCharacters(int numberOfPlayers, List<string> characterList, List<Players> createPlayerList)
        {
            Shuffler.Shuffle(characterList);

            for (int i = 0; i < createPlayerList.Count; i++)
            {
                createPlayerList[i].Character = characterList[i];
            }

            return createPlayerList;

        }

        public static string MerlinKnownToPercival(int numberOfPlayers, List<Players> createPlayerList)
        {
            List<string> percival = new List<string>();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                if (createPlayerList[i].Character == "Merlin" || createPlayerList[i].Character == "Morgana")
                {
                    percival.Add(createPlayerList[i].Name);
                }
            }
            string percy = "";
            for (int i = 0; i < percival.Count; i++)
            {
                StringBuilder builtString = new StringBuilder();

                for (int j = 0; j < percival.Count; j++)
                {
                    builtString = builtString.Append(string.Format("{0} ", percival[j]));
                }

                percy = builtString.ToString();
            }

            return percy;
        }

        public static string SpiesKnownToEachOther(int numberOfPlayers, List<Players> createPlayerList)
        {
            List<string> spies = new List<string>();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                if (createPlayerList[i].Character == "Minion of Mordred" || createPlayerList[i].Character == "Morgana" || createPlayerList[i].Character == "Assassin" ||
                    createPlayerList[i].Character == "Mordred" || createPlayerList[i].Character == "Bad Lancelot")
                {
                    spies.Add(createPlayerList[i].Name);
                }
            }
            string totalSpies = "";
            for (int i = 0; i < spies.Count; i++)
            {
                StringBuilder builtString = new StringBuilder();

                for (int j = 0; j < spies.Count; j++)
                {
                    builtString = builtString.Append(string.Format("{0} ", spies[j]));
                }

                totalSpies = builtString.ToString();
            }

            return totalSpies;
        }

        public static string SpiesKnownToMerlin(int numberOfPlayers, List<Players> createPlayerList)
        {
            List<string> merlinSpies = new List<string>();
            for (int i = 0; i < numberOfPlayers; i++)
            {
                if (createPlayerList[i].Character == "Minion of Mordred" || createPlayerList[i].Character == "Morgana" || createPlayerList[i].Character == "Assassin" ||
                    createPlayerList[i].Character == "Bad Lancelot")
                {
                    merlinSpies.Add(createPlayerList[i].Name);
                }
            }
            string newSpies = "";
            for (int i = 0; i < merlinSpies.Count; i++)
            {
                StringBuilder builtString = new StringBuilder();

                for (int j = 0; j < merlinSpies.Count; j++)
                {
                    builtString = builtString.Append(string.Format("{0} ", merlinSpies[j]));
                }

                newSpies = builtString.ToString();
            }
            return newSpies;
        }
    }
}
