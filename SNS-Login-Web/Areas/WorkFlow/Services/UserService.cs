using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using Project_WorkFlow.Areas.WorkFlow.Models;
using Project_WorkFlow.Areas.WorkFlow.Services.Interfaces;
using Project_WorkFlow.DB;


namespace Project_WorkFlow.Areas.WorkFlow.Services
{
    public class UserService : IUserService
    {
        public UserModel GetUserId(long snsId, string snsNickName, string snsName)
        {
            UserModel model = new UserModel();
            model._idx = 0;
            model._idData = snsId;
            model._nickNameData = snsNickName;
            model._snsNameData = snsName;

            using (WORKFLOWDB context = new WORKFLOWDB())
            {
                model._list=context.uspGetUserData(model._idx, model._idData, model._nickNameData, model._snsNameData).ToList();


                if (model._list.Count==1)
                {
                    model._idx = model._list[0].C_idx;
                    model._idData = model._list[0].C_IdData;
                    model._emailData = model._list[0].C_emailData;
                    model._nickNameData = model._list[0].C_nickNameData;
                    model._profileData = model._list[0].C_profileData;
                    model._snsNameData = model._list[0].C_snsNameData;

                }

            }




            return model;
        }

        public UserModel InsertUser(long snsId, string snsNickName, string snsName)
        {
            UserModel model = new UserModel();
            model._idx = 0;
            model._idData = snsId;
            model._nickNameData = snsNickName;
            model._snsNameData = snsName;

            using (WORKFLOWDB context = new WORKFLOWDB())
            {
                ObjectParameter resultCodeParam = new ObjectParameter("resultCode", typeof(int));

                uspInsertUserData_Result result = context.uspInsertUserData(model._idData, model._nickNameData, model._snsNameData,resultCodeParam).First();


                model._idx = result.C_idx;
                model._emailData = result.C_emailData;
                model._profileData = result.C_profileData;

            }




            return model;
        }
    }
}