using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_WorkFlow.Areas.WorkFlow.Models;

namespace Project_WorkFlow.Areas.WorkFlow.Services.Interfaces
{
    interface IUserService
    {
        UserModel GetUserId(long snsId, string snsNickName, string snsName);
        UserModel InsertUser(long snsId, string snsNickName, string snsName);

    }
}
