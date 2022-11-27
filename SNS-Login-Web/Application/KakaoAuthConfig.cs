using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_WorkFlow.Application
{
    public static class KakaoAuthConfig
    {
        private static string kakaoAuthKey = "bffdad08430c3e596711fb2ddf1b4083";

        private static string kakaoLoginRedirectUrl = "https://www.workflow.com/workflow/oauth/KakaoLoginProcess";

        private static string kakaoSignUpRedirectUrl = "https://www.workflow.com/workflow/oauth/KakaoSignUpProcess";

        private static string kakaoLoginAuthUrl = "https://kauth.kakao.com/oauth/authorize?client_id="+kakaoAuthKey+"&redirect_uri="+getKakaoLoginRedirectUrl+"&response_type=code";

        private static string kakaoSignUpAuthUrl = "https://kauth.kakao.com/oauth/authorize?client_id=" + kakaoAuthKey + "&redirect_uri=" + getKakaoSignUpRedirectUrl + "&response_type=code";

        private static string kakaoTokenUrl = "https://kauth.kakao.com/oauth/token";

        private static string kakakoUserInfoUrl = "https://kapi.kakao.com/v2/user/me";


        public static string getKakaoAuthKey
        {
            get { return kakaoAuthKey; }
        }

        public static string getKakaoLoginRedirectUrl
        {
            get { return kakaoLoginRedirectUrl; }
        }

        public static string getKakaoLoginAuthUrl {

            get {return kakaoLoginAuthUrl; }
        }

        public static string getKakaoSignUpRedirectUrl
        {
            get { return kakaoSignUpRedirectUrl; }
        }

        public static string getKakaoSignUpAuthUrl
        {

            get { return kakaoSignUpAuthUrl; }
        }

        public static string getKakaoTokenUrl
        {
            get { return kakaoTokenUrl; }
        }

        public static string getKakaoUserInfoUrl
        {
            get { return kakakoUserInfoUrl; }
        }


    }
}