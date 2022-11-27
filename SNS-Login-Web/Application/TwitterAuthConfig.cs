using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_WorkFlow.Application
{
    public static class TwitterAuthConfig
    {
        private static string twitterClientIdKey = "dldDbDNpdG16eV9FUm1FV0k5SEY6MTpjaQ";

        private static string twitterLoginRedirectUrl = "https://www.workflow.com/workflow/oauth/twitterloginprocess";

        private static string twitterSignUpRedirectUrl = "https://www.workflow.com/workflow/oauth/twittersignupprocess";

        private static string twitterAuthUrl = "https://twitter.com/i/oauth2/authorize?response_type=code";

        private static string twitterScopeUrl= "&scope=tweet.read%20users.read%20follows.read%20offline.access&state=state&code_challenge=challenge&code_challenge_method=plain";

        private static string twitterTokenUrl = "https://api.twitter.com/2/oauth2/token";

        private static string twitterUserInfoUrl = "https://api.twitter.com/2/users/me";


        public static string getTwitterClientIdKey
        {
            get { return twitterClientIdKey; }
        }


        public static string getTwitterLoginRedirectUrl
        {
            get { return twitterLoginRedirectUrl; }
        }



        public static string getTwitterSignUpRedirectUrl
        {
            get { return twitterSignUpRedirectUrl; }
        }


        public static string getTwitterAuthUrl
        {

            get { return twitterAuthUrl; }
        }

        public static string getTwitterScopeUrl
        {

            get { return twitterScopeUrl; }
        }

        public static string getTwitterTokenUrl
        {

            get { return twitterTokenUrl; }
        }

        public static string getTwitterUserInfoUrl
        {

            get { return twitterUserInfoUrl; }
        }
    }
}