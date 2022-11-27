using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_WorkFlow.Application
{
    public class OAuth2
    {
        private static string twitterConsumerKey = "mlZpTuiCt5wK5ZnlkQnR8Cl45";

        private static string twitterConsumerSecretKey = "zZOm1nP4pP4Q943aVjWKQuSr0FCdUNiusoMPLtw1EuzPBwqMi7";

        private static string twitterAccessToken = "1491276430994722818-TkOeupHKB2BMmJhV9R2s2RcS2ZIh2A";

        private static string twitterLoginRedirectUrl = "https://www.workflow.com/workflow/oauth/twitterloginprocess";

        private static string twitterSignUpRedirectUrl = "https://www.workflow.com/workflow/oauth/twittersignupprocess";

        private static string twitterRequestTokenUrl = "https://api.twitter.com/oauth/request_token";

        private static string twitterLoginRequestTokenUrl = "https://api.twitter.com/oauth/request_token?oauth_callback=" + twitterLoginRedirectUrl;

        private static string twitterSignUpRequestTokenUrl = "https://api.twitter.com/oauth/request_token?oauth_callback=" + twitterSignUpRedirectUrl;

        private static string twitterAuthTokenUrl = "https://api.twitter.com/oauth/authorize";

        private static string twitterUserInfoUrl = "https://api.twitter.com/oauth/access_token";


        public static string getTwitterConsumerKey
        {
            get { return twitterConsumerKey; }
        }

        public static string getTwitterConsumerSecretKey
        {
            get { return twitterConsumerSecretKey; }
        }

        public static string getTwitterAccessToken
        {
            get { return twitterAccessToken; }
        }

        public static string getTwitterRequestTokenUrl
        {
            get { return twitterRequestTokenUrl; }
        }

        public static string getTwitterLoginRedirectUrl
        {
            get { return twitterLoginRedirectUrl; }
        }

        public static string getTwitterLoginRequestTokenUrl
        {

            get { return twitterLoginRequestTokenUrl; }
        }

        public static string getTwitterSignUpRedirectUrl
        {
            get { return twitterSignUpRedirectUrl; }
        }

        public static string getTwitterSignUpRequestTokenUrl
        {

            get { return twitterSignUpRequestTokenUrl; }
        }

        public static string getTwitterAuthTokenUrl
        {

            get { return twitterAuthTokenUrl; }
        }

        public static string getTwitterUserInfoUrl
        {

            get { return twitterUserInfoUrl; }
        }
    }
}