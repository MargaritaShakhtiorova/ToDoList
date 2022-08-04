using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using To_Do_List.Models;

namespace To_Do_List.Areas.Identity.Data;

// Add profile data for application users by adding properties to the To_Do_ListUser class
public class To_Do_ListUser : IdentityUser
{
    public List<UserTask> UserTasks { get; set; }
}

