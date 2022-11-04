using System;
using System.Collections.Generic;

namespace user_service.Models
{
    public partial class UserInfo:UserForm
    {
        public int Id { get; set; }
    }

    public class UserForm
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
    }
}
