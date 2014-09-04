using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using NUnit.Framework;

namespace Avalon
{
    public class DeleteUser
    {
        public void DeleteUserName(string userName)
        {
            using (DatabaseDataContext context = new DatabaseDataContext())
            {
                context.usp_DeleteAvalonUser(userName);
            }
        }
    }

    [TestFixture]
    public class DeleteUserTests
    {
        private string _connectionString;

        [Test]
        public void WHEN_Delete_is_called_THEN_UserName_cannot_be_found()
        {
            string userName = "Test";

            CreateUser.InputUserInfo(userName, "8015051187", "AT&T");

            DeleteUser user = new DeleteUser();
            user.DeleteUserName(userName);

            _connectionString = @"Server=tcp:ko11atcsn0.database.windows.net,1433;Database=AF10DB;User ID=draper21@ko11atcsn0;Password=Biking21;
                                        Trusted_Connection=False;Encrypt=True;Connection Timeout=30";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
               var results = connection.Query("SELECT Name FROM AvalonUsers WHERE Name = @Name", new {Name = "Chris"});
               Assert.AreEqual(0,results.Count());

            }
        }
    }
   
}
