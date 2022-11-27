using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using Project_WorkFlow.Application;
using Project_WorkFlow.Areas.WorkFlow.Models;
using Project_WorkFlow.Areas.WorkFlow.Services.Interfaces;
using Project_WorkFlow.Areas.WorkFlow.Services;

namespace Project_WorkFlow.Areas.WorkFlow.Controllers
{
    public class LoginController : Controller
    {

        // GET: WorkFlow/Login
        public ActionResult Index()
        {
            


            return View();
        }

        
        public ActionResult SignUp(UserModel model)
        {
            


            return View(model);
        }


        public ActionResult KakaoLogin()
        {
            string kakaoLoginUrl = KakaoAuthConfig.getKakaoLoginAuthUrl;


            return Redirect(kakaoLoginUrl);
        }

        public ActionResult KakaoSignUp()
        {
            string kakaoSignUpUrl = KakaoAuthConfig.getKakaoSignUpAuthUrl;


            return Redirect(kakaoSignUpUrl);
        }

        public ActionResult GetSignUpPermission()
        {


            return View();
        }

        public ActionResult TwitterLogin()
        {
            string authorizeUrl = TwitterAuthConfig.getTwitterAuthUrl;
            authorizeUrl += "&client_id=" + TwitterAuthConfig.getTwitterClientIdKey;
            authorizeUrl += "&redirect_uri=" + TwitterAuthConfig.getTwitterLoginRedirectUrl;
            authorizeUrl += TwitterAuthConfig.getTwitterScopeUrl;

            return Redirect(authorizeUrl);
        }

        public ActionResult TwitterSignUp()
        {
            string authorizeUrl = TwitterAuthConfig.getTwitterAuthUrl;
            authorizeUrl+="&client_id="+ TwitterAuthConfig.getTwitterClientIdKey;
            authorizeUrl+="&redirect_uri=" + TwitterAuthConfig.getTwitterSignUpRedirectUrl;
            authorizeUrl+= TwitterAuthConfig.getTwitterScopeUrl;

            return Redirect(authorizeUrl);
        }



    }
}