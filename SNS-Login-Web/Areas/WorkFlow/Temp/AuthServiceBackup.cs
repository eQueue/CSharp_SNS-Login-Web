using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Text;
using System.IO;
using Project_WorkFlow.Application;
using Newtonsoft.Json.Linq;
using Project_WorkFlow.Areas.WorkFlow.Services.Interfaces;
using Project_WorkFlow.Areas.WorkFlow.Models;
using OAuth;

namespace Project_WorkFlow.Areas.WorkFlow.Services
{
    public class AuthServiceBackUp
    {
        public JObject GetKakaoToken(string redirectUrl, string code)
        {
            JObject obj = null;

            try
            {
                String reqUrl = KakaoAuthConfig.getKakaoTokenUrl;

                var request = (HttpWebRequest)WebRequest.Create(reqUrl);

                var postData = "grant_type=" + Uri.EscapeDataString("authorization_code");
                postData += "&client_id=" + Uri.EscapeDataString(KakaoAuthConfig.getKakaoAuthKey);
                postData += "&redirect_uri=" + Uri.EscapeDataString(redirectUrl);
                postData += "&code=" + Uri.EscapeDataString(code);


                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                // 인코딩
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                string text = reader.ReadToEnd();

                // json 파싱
                obj = JObject.Parse(text);
            }
            catch
            {

            }



            return obj;
        }

        public JObject GetKakaoUserInfo(JObject obj)
        {
            string accessToken = obj["access_token"].ToString();
            string refreshToken = obj["refresh_token"].ToString();

            JObject jsonResult = null;

            try
            {
                String reqUrl = KakaoAuthConfig.getKakaoUserInfoUrl;

                var request = (HttpWebRequest)WebRequest.Create(reqUrl);
                request.Method = "POST";
                request.ContentType = "application/json";

                WebHeaderCollection myWebHeaderCollection = request.Headers;

                myWebHeaderCollection.Add("Authorization", "Bearer " + accessToken);

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                // 인코딩
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                string text = reader.ReadToEnd();

                // json 파싱
                jsonResult = JObject.Parse(text);

            }
            catch
            {

            }

            return jsonResult;
        }

        public string GetTwitterOAuthToken(string redirectUrl, string twitterConsumerKey)
        {

            string result = "";


            //////string method = "POST";
            //////string oauth_consumer_key = twitterConsumerKey;
            //////string oauth_token = TwitterAuthConfig.getTwitterAccessToken;
            //////string oauth_nonce = OAuth.OAuthTools.GetNonce();
            //////string oauth_timestamp = OAuth.OAuthTools.GetTimestamp();




            //////string reqUrl = TwitterAuthConfig.getTwitterRequestTokenUrl;
            //////string baseUrl = reqUrl;

            //////WebParameterCollection collection = new WebParameterCollection();

            //////collection.Add("oauth_consumer_key", oauth_consumer_key);
            //////collection.Add("oauth_nonce", oauth_nonce);
            //////collection.Add("oauth_signature_method", "HMAC-SHA1");
            //////collection.Add("oauth_timestamp", oauth_timestamp);
            //////collection.Add("oauth_version", "1.0");

            //////string signatureBase = OAuth.OAuthTools.ConcatenateRequestElements(method, baseUrl, collection);


            //////string signature = OAuth.OAuthTools.GetSignature(OAuth.OAuthSignatureMethod.HmacSha1, signatureBase, TwitterAuthConfig.getTwitterConsumerSecretKey);



            ////var request = (HttpWebRequest)WebRequest.Create(reqUrl);

            ////request.Method = "POST";


            ////var postData = "oauth_callback=" + Uri.EscapeDataString(redirectUrl);



            ////var data = Encoding.ASCII.GetBytes(postData);

            ////using (var stream = request.GetRequestStream())
            ////{
            ////    stream.Write(data, 0, data.Length);
            ////}

            ////request.Headers.Add("Authorization", "OAuth oauth_consumer_key=\"mlZpTuiCt5wK5ZnlkQnR8Cl45\", oauth_nonce=\"" + oauth_nonce + "\", oauth_signature=\"" + signature + "\", oauth_signature_method =\"HMAC-SHA1\", oauth_timestamp=\"" + oauth_timestamp + "\", oauth_version=\"1.0\"");




            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //// 인코딩

            //Stream responseStream = response.GetResponseStream();

            //StreamReader reader = new StreamReader(responseStream);

            //result = reader.ReadToEnd();


            return result;
        }


        public UserModel GetTwitterUserInfo(string requestUrl, string oauth_token, string oauth_verifier)
        {
            UserModel model = new UserModel();

            String reqUrl = requestUrl;

            var request = (HttpWebRequest)WebRequest.Create(reqUrl);

            var postData = "oauth_token=" + Uri.EscapeDataString(oauth_token);
            postData += "&oauth_verifier=" + Uri.EscapeDataString(oauth_verifier);



            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // 인코딩
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
            string text = reader.ReadToEnd();

            Uri responseParameter = new Uri(text);
            long twitterId = Convert.ToInt64(HttpUtility.ParseQueryString(responseParameter.ToString()).Get("user_id"));
            string twitterNickName = HttpUtility.ParseQueryString(responseParameter.ToString()).Get("screen_name");

            model._idData = twitterId;
            model._nickNameData = twitterNickName;

            return model;
        }
    }
}