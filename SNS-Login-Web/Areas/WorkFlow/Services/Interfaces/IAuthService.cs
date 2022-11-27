using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Project_WorkFlow.Areas.WorkFlow.Models;

namespace Project_WorkFlow.Areas.WorkFlow.Services.Interfaces
{
    interface IAuthService
    {

        JObject GetKakaoToken(string redirectUrl, string code);

        JObject GetKakaoUserInfo(JObject obj);

        JObject GetTwitterToken(string redirectUrl, string code);

        JObject GetTwitterUserInfo(JObject obj);
    }
}
