using System;
using System.Linq;
using user_service.Models;

namespace user_service
{
    public class DbAccess
    {
        private readonly ILogger<DbAccess> _logger;

        public DbAccess(ILogger<DbAccess> logger)
        {
            _logger = logger;
        }


        public int AddUser(UserForm user) {
            using (var db = new userContext())
            {   
                var u = new UserInfo();
                u.UserName = user.UserName;
                u.FullName = user.FullName;
                db.UserInfos.Add(u);
                var count = db.SaveChanges();
                _logger.LogInformation("{} user is saved to database.", count);
                return count;
            }
        }

        public UserInfo[] ListUserByKeywords(string[] kws, int page, int size)
        {
            using (var db = new userContext())
            {
                Func<UserInfo, bool> filter = u =>
                {
                    bool result = false;
                    for (int i = 0; i <= kws.Length - 1; i++)
                    {
                        string kw = kws[i];
                        result = result || u.FullName.ToUpper().Contains(kw.ToUpper()) || u.UserName.ToUpper().Contains(kw.ToUpper());
                    }
                    return result;
                };
                var q = db.UserInfos.Where(filter);
                UserInfo[] users = q.OrderBy(u=>u.FullName).ThenBy(u=>u.UserName).Skip(page*size).Take(size).ToArray();
                return users;
            }
        }
    }
}

