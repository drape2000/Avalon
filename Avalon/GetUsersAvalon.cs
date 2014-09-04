using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalon
{
    public class GetUsersAvalon
    {
        public static List<Players> GetAvalonUsers()
        {
            using (DatabaseDataContext context = new DatabaseDataContext())
            {
                List<usp_GetUsersAvalonResult> list = context.usp_GetUsersAvalon().ToList();

                return list.Select(x => new Players{Name = x.NAME, Email = x.EMAIL}).ToList();

            }
        }
        public static int GetCount()
        {
            using (DatabaseDataContext context = new DatabaseDataContext())
            {
                var b = context.ReturnAvalonCount();
                var obj2 = b.First();
                var count = obj2.COUNT;
                int number = Convert.ToInt32(count);

                return number;
            }
        }

    }
}
