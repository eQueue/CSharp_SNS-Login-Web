using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_WorkFlow.DB;

namespace Project_WorkFlow.Areas.WorkFlow.Models
{
    public class UserModel
    {
        
        public long _idx { get; set; }
        public long _idData { get; set; }
        public  string _emailData { get; set; }
        public string _nickNameData { get; set; }
        public string _profileData { get; set; }

        public string _snsNameData { get; set; }
    
        public List<uspGetUserData_Result> _list { get; set; }

        public UserModel()
        {
            _list = new List<uspGetUserData_Result>();
        }


    }

    public class UserParamModel
    {
        public long _idData { get; set; }
        public string _emailData { get; set; }
        public string _nickNameData { get; set; }
        public string _profileData { get; set; }

        public string _snsNameData { get; set; }




    }

}