using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Avalon
{
    public class CreateUser
    {
        public static void InputUserInfo(string name, string phoneNumber, string provider) 
        {
            provider = CompileEmail(provider);

            string email = string.Format("{0}{1}", phoneNumber, provider);

            using (DatabaseDataContext context = new DatabaseDataContext())
            {
                context.usp_InsertAvalonUserInput(name, email);
            }
        }

        public static string CompileEmail(string provider) 
        {
            string caseSwitch = provider;

            switch (caseSwitch)
            {
                case "AT&T":
                    provider = "@txt.att.net";
                    break;
                case "T-Mobile":
                    provider = "@tmomail.net";
                    break;
                case "Verizon":
                    provider = "@vtext.com";
                    break;
                case "Sprint":
                    provider = "@messaging.sprintpcs.com";
                    break;
                case "Email":
                    provider = "";
                    break;
                    
                default:
                    Console.WriteLine("Default case");
                    break;
                                      
            }
            return provider;
        }
    }

    [TestFixture]
    public class CreateUserTests
    {
        [Test]
        public void CompileEmailWithATT()
        {
            var result = CreateUser.CompileEmail("AT&T");
            Assert.AreEqual("txt.att.net",result);
        }

        [Test]
        public void CompileEmailWithTMobile()
        {
            var result = CreateUser.CompileEmail("T-Mobile");
            Assert.AreEqual("tmomail.net", result);
        }

        [Test]
        public void CompileEmailWithVerizon()
        {
            var result = CreateUser.CompileEmail("Verizon");
            Assert.AreEqual("vtext.com", result);
        }

        [Test]
        public void CompileEmailWithSprint()
        {
            var result = CreateUser.CompileEmail("Sprint");
            Assert.AreEqual("messaging.sprintpcs.com", result);
        }

        [Test]
        public void InputUserInfo()
        {
            string name = "Chris";
            string phoneNumber = "8015051186";
            string provider = "AT&T";

            //CreateUser.InputUserInfo(name, "8015051186", "AT&T");
            provider = CreateUser.CompileEmail(provider);

            string email = string.Format("{0}@{1}", phoneNumber, provider);

            Assert.AreEqual("8015051186@txt.att.net", email);

        }
    }

}
