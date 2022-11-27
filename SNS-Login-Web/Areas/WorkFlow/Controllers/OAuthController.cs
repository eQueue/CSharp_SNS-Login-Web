using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json.Linq;
using Project_WorkFlow.Application;
using Project_WorkFlow.Areas.WorkFlow.Models;
using Project_WorkFlow.Areas.WorkFlow.Services.Interfaces;
using Project_WorkFlow.Areas.WorkFlow.Services;


namespace Project_WorkFlow.Areas.WorkFlow.Controllers
{
    public class OAuthController : Controller
    {
        private readonly IUserService userService;
        private readonly IAuthService authService;


        public OAuthController()
        {
            userService = new UserService();
            authService = new AuthService();

        }

        // GET: WorkFlow/OAuth/KakaoLoginProcess

        public ActionResult KakaoLoginProcess(string code)
        {
            string redirectController = string.Empty;
            string redirectAction = string.Empty;
            string redirectLoginUrl = KakaoAuthConfig.getKakaoLoginRedirectUrl;

            // json 파싱
            JObject token = authService.GetKakaoToken(redirectLoginUrl, code);

            // token에서 kakaoUserInfo 가져오기

            JObject userInfo = authService.GetKakaoUserInfo(token);
            long kakaoId = (long)userInfo["id"];
            string kakaoNickName = userInfo["kakao_account"]["profile"]["nickname"].ToString();

            //기존 회원인지 확인하기
            UserModel model = userService.GetUserId(kakaoId, kakaoNickName, "kakao");
            if (model._idx!=0)
            {
                Session["idx"] = model._idx;
                Session["email"] = model._emailData;
                Session["nickName"] = model._nickNameData;
                Session["profile"] = model._profileData;
                Session["snsName"] = model._snsNameData;

                redirectController = "Home";
                redirectAction = "Index";

            }
            else
            {
                //model = userService.InsertUser(kakaoId, kakaoEmail);
                //if (model._idx != 0)
                //{
                //    redirectController = "Home";
                //    redirectAction = "Index";
                //}

                TempData["snsId"] = kakaoId;
                redirectController = "Login";
                redirectAction = "SignUp";
            }

            return RedirectToAction(redirectAction,redirectController);

        }

        public ActionResult KakaoSignUpProcess(string code)
        {
            string redirectController = string.Empty;
            string redirectAction = string.Empty;
            string redirectSignUpUrl = KakaoAuthConfig.getKakaoSignUpRedirectUrl;

            // Token 가져오기
            JObject token = authService.GetKakaoToken(redirectSignUpUrl, code);

            // token에서 kakaoUserInfo 가져오기

            JObject userInfo = authService.GetKakaoUserInfo(token);
            long kakaoId = (long)userInfo["id"];
            string kakaoNickName = userInfo["kakao_account"]["profile"]["nickname"].ToString();

            //기존 회원인지 확인하기
            UserModel model = userService.GetUserId(kakaoId,kakaoNickName,"kakao");
            if (model._idx != 0)
            {
                TempData["idx"] = model._idx;
                redirectController = "Login";
                redirectAction = "SignUp";
            }
            else//기존회원이 아닐경우
            {

                TempData["token"] = token;
                TempData["snsName"] = "kakao";
                redirectController = "Login";
                redirectAction = "GetSignUpPermission";

            }


            return RedirectToAction(redirectAction, redirectController);

        }

        public JsonResult InsertUserProcess()
        {
            string redirectController = string.Empty;
            string redirectAction = string.Empty;

            string snsName = TempData["snsName"].ToString();
            JObject token = (JObject)TempData["token"];

            long snsId = new long();
            string snsNickName = string.Empty;

            // token에서 UserInfo 가져오기
            if (snsName == "kakao")
            {
                JObject userInfo = authService.GetKakaoUserInfo(token);
                snsId = (long)userInfo["id"];
                snsNickName = userInfo["kakao_account"]["profile"]["nickname"].ToString();
            }
            else if (snsName == "twitter")
            {
                JObject userInfo = authService.GetTwitterUserInfo(token);
                snsId = (long)userInfo["data"]["id"];
                snsNickName = userInfo["data"]["username"].ToString();

            }
            

            //기존 회원이 아닐경우
            UserModel model = userService.GetUserId(snsId, snsNickName, snsName);
            if (model._idx == 0)
            {
                model = userService.InsertUser(snsId, snsNickName, snsName);

            }


            return Json(model, JsonRequestBehavior.AllowGet);

        }

        public ActionResult TwitterLoginProcess(string code)
        {



            string redirectController = string.Empty;
            string redirectAction = string.Empty;
            string redirectUrl = TwitterAuthConfig.getTwitterLoginRedirectUrl;

            // Token 가져오기
            JObject token = authService.GetTwitterToken(redirectUrl, code);

            // token에서 twitterUserInfo 가져오기
            JObject userInfo = authService.GetTwitterUserInfo(token);
            long twitterId = (long)userInfo["data"]["id"];
            string twitterNickName = userInfo["data"]["username"].ToString();

            //기존 회원인지 확인하기
            UserModel model = userService.GetUserId(twitterId, twitterNickName, "twitter");
            if (model._idx != 0)
            {
                Session["idx"] = model._idx;
                Session["email"] = model._emailData;
                Session["nickName"] = model._nickNameData;
                Session["profile"] = model._profileData;
                Session["snsName"] = model._snsNameData;

                redirectController = "Home";
                redirectAction = "Index";

            }
            else
            {

                TempData["snsId"] = twitterId;
                redirectController = "Login";
                redirectAction = "SignUp";
            }


            return RedirectToAction(redirectAction, redirectController);


        }

        public ActionResult twitterSignUpProcess(string code)
        {

            

            string redirectController = string.Empty;
            string redirectAction = string.Empty;
            string redirectUrl = TwitterAuthConfig.getTwitterSignUpRedirectUrl;

            // Token 가져오기
            JObject token = authService.GetTwitterToken(redirectUrl, code);

            // token에서 twitterUserInfo 가져오기
            JObject userInfo = authService.GetTwitterUserInfo(token);
            long twitterId = (long)userInfo["data"]["id"];
            string twitterNickName = userInfo["data"]["username"].ToString();

            //기존 회원인지 확인하기
            UserModel model = userService.GetUserId(twitterId, twitterNickName, "twitter");
            if (model._idx != 0)
            {
                TempData["idx"] = model._idx;
                redirectController = "Login";
                redirectAction = "SignUp";
            }
            else//기존회원이 아닐경우
            {

                TempData["token"] = token;
                TempData["snsName"] = "twitter";
                redirectController = "Login";
                redirectAction = "GetSignUpPermission";

            }


            return RedirectToAction(redirectAction, redirectController);


        }






    }
}