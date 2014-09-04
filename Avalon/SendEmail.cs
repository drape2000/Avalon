using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.AccessControl;
using System.Text;

using System.Threading.Tasks;
using System.Globalization;


namespace Avalon
{
    public class  SendEmail
    {
        public static void SendOutEmails(int numberOfPlayers, List<Players> createPlayerList)
        {
            string spiesKnownToMerlin = CharacterAssignment.SpiesKnownToMerlin(numberOfPlayers, createPlayerList);
            string spiesKnownToEachOther = CharacterAssignment.SpiesKnownToEachOther(numberOfPlayers, createPlayerList);
            string merlinKnownToPercival = CharacterAssignment.MerlinKnownToPercival(numberOfPlayers, createPlayerList);

            for (int i = 0; i < numberOfPlayers; i++)
            {
                SendEmail.SendPlayerEmail(createPlayerList[i].Email, createPlayerList[i].Character, createPlayerList[i].Name, spiesKnownToMerlin, spiesKnownToEachOther, merlinKnownToPercival);
            }
        }

        public static void SendPlayerEmail(string email, string characterInfo, string name, string merlinSpies, string spies, string percy) 
        {
            string merlin = "";
            string merlinsSpies = "";
            string allSpies = "";
            string picName = "";
            
            if (characterInfo == "Merlin")
            {
                merlinsSpies = string.Format("\nThe spies are {0}", merlinSpies);
            }
             if (characterInfo == "Assassin" || characterInfo == "Mordred" || characterInfo == "Morgana" || characterInfo == "Minion of Mordred" || characterInfo == "Bad Lancelot")
            {
                allSpies = string.Format("\nThe spies are {0}",spies);
            }
            if (characterInfo == "Percival")
                {
                    merlin = string.Format("\nMerlin is {0}",percy);
                }

            string caseSwitch = characterInfo;

            switch (caseSwitch)
            {
                case "Merlin":
                    picName = "Merlin";
                    break;

                case "Percival":
                    picName = "Percival";
                    break;

                case "Servant of Arthur":
                    picName = "Servant";
                    break;

                case "Minion of Mordred":
                    picName = "Minion";
                    break;

                case "Assassin":
                    picName = "Assassin";
                    break;

                case "Mordred":
                    picName = "Mordred";
                    break;

                case "Morgana":
                    picName = "Morgana";
                    break;

                case "Oberon":
                    picName = "Oberon";
                    break;

                case "Bad Lancelot":
                    picName = "Oberon";
                    break;
                case "Good Lancelot":
                    picName = "Percival";
                    break;

                default:
                    Console.WriteLine("Default case");
                    break;
            }

            DateTime time = DateTime.Now;
            string minuteTime = time.ToString("H:mm:ss", CultureInfo.InvariantCulture);

            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress("resistanceapp@gmail.com");
                message.To.Add(new MailAddress(email));
                message.Subject = string.Format("{0}'s Character",name);
                message.Body = string.Format("{0} {1} {2} {3}\n{4}",characterInfo, merlinsSpies, merlin, allSpies, time);

                System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
                Stream myStream = myAssembly.GetManifestResourceStream(string.Format("Avalon.Resources.{0}.jpg", picName));

                Attachment attachment = new Attachment(myStream, string.Format("{0}.jpg", picName));
                message.Attachments.Add(attachment);
                

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("resistanceapp@gmail.com", "Merlin45");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);

            }
            catch (Exception ex)
            {
               // MessageBox.Show("err: " + ex.Message);
            }
        }
    }
}
