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
    public class AuthService : IAuthService
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

        public JObject GetTwitterToken(string redirectUrl, string code)
        {
            JObject obj = null;


                String reqUrl = TwitterAuthConfig.getTwitterTokenUrl;

                var request = (HttpWebRequest)WebRequest.Create(reqUrl);

                var postData = "code=" + Uri.EscapeDataString(code);

                postData += "&grant_type=" + Uri.EscapeDataString("authorization_code");
                postData += "&client_id=" + Uri.EscapeDataString(TwitterAuthConfig.getTwitterClientIdKey);
                postData += "&redirect_uri=" + Uri.EscapeDataString(redirectUrl);
                postData += "&code_verifier=" + Uri.EscapeDataString("challenge");

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




            return obj;
        }

        public JObject GetTwitterUserInfo(JObject obj)
        {
            string accessToken = obj["access_token"].ToString();
            string refreshToken = obj["refresh_token"].ToString();

            JObject jsonResult = null;

            String reqUrl = TwitterAuthConfig.getTwitterUserInfoUrl;



            var request = (HttpWebRequest)WebRequest.Create(reqUrl);
            request.Method = "GET";
            request.ContentType = "application/json";

            request.Headers.Add("Authorization", "Bearer " + accessToken);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // 인코딩
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
            string text = reader.ReadToEnd();

            // json 파싱
            jsonResult = JObject.Parse(text);

            return jsonResult;
        }
    }
}