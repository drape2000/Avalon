using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Avalon
{
    public class NumberOfPlayers
    {
        public static MinionsAndServants DetermineMinionsAndServents(int numberOfPlayers)
        {
            int caseSwitch = numberOfPlayers;
            int servants = 0;
            int minions = 0;
            switch (caseSwitch)
            {
                case 5:
                    servants = 3;
                    minions = 2;
                    break;
                case 6:
                    servants = 4;
                    minions = 2;
                    break;
                case 7:
                    servants = 4;
                    minions = 3;
                    break;
                case 8:
                    servants = 5;
                    minions = 3;
                    break;
                case 9:
                    servants = 6;
                    minions = 3;
                    break;
                case 10:
                    servants = 6;
                    minions = 4;
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

            MinionsAndServants minionsAndServants = new MinionsAndServants();

            minionsAndServants.Minions = minions;
            minionsAndServants.Servants = servants;

            return minionsAndServants;
        }

        public class MinionsAndServants
        {
            private int myServants = 0;
            private int myMinions = 0;

            public int Servants
            {
                get
                {
                    return myServants;
                }
                set
                {
                    myServants = value;
                }
            }

            public int Minions
            {
                get
                {
                    return myMinions;
                }
                set
                {
                    myMinions = value;
                }
            }

        }
    }

    [TestFixture]
    public class numberOfPlayersTests
    {
        [Test]
        public void MinionsAndServantsFive()
        {
            NumberOfPlayers.MinionsAndServants result = NumberOfPlayers.DetermineMinionsAndServents(5);
            Assert.AreEqual(3, result.Servants);
            Assert.AreEqual(2,result.Minions);
        }

        [Test]
        public void MinionsAndServantsSix()
        {
            NumberOfPlayers.MinionsAndServants result = NumberOfPlayers.DetermineMinionsAndServents(6);
            Assert.AreEqual(4, result.Servants);
            Assert.AreEqual(2, result.Minions);
        }

        [Test]
        public void MinionsAndServantsSeven()
        {
            NumberOfPlayers.MinionsAndServants result = NumberOfPlayers.DetermineMinionsAndServents(7);
            Assert.AreEqual(4, result.Servants);
            Assert.AreEqual(3, result.Minions);
        }

        [Test]
        public void MinionsAndServantsEight()
        {
            NumberOfPlayers.MinionsAndServants result = NumberOfPlayers.DetermineMinionsAndServents(8);
            Assert.AreEqual(5, result.Servants);
            Assert.AreEqual(3, result.Minions);
        }

        [Test]
        public void MinionsAndServantsNine()
        {
            NumberOfPlayers.MinionsAndServants result = NumberOfPlayers.DetermineMinionsAndServents(9);
            Assert.AreEqual(6, result.Servants);
            Assert.AreEqual(3, result.Minions);
        }

        [Test]
        public void MinionsAndServantsTen()
        {
            NumberOfPlayers.MinionsAndServants result = NumberOfPlayers.DetermineMinionsAndServents(10);
            Assert.AreEqual(6, result.Servants);
            Assert.AreEqual(4, result.Minions);
        }
    }
}
