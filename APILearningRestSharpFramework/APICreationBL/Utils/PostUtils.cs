using APILearningRestSharpFramework;
using APITestCaseCreationProject.APIRequests;
using APITestCaseCreationProject.APIResponces;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICreationBL.Utils
{
    public class PostUtils
    {
        public static UserResponce CreatePost(int id, string name, string role, string email)
        {
            string payLoad = CreatePayload(id, name, role, email);
           return RestClientUtil.Post<UserResponce>("http://localhost:3000/users", payLoad, DataFormat.Json);
        }
        public static string CreatePayload(int id, string name, string role, string email)
        {
            UsersRequest ur = new UsersRequest();
            ur.id = id;
            ur.name = name;
            ur.role = role;
            ur.email = email;

            string josnContent = JsonConvert.SerializeObject(ur);
            return josnContent;
        }

        public static UserResponce CreateGet(int id)
        {            
            return RestClientUtil.Get<UserResponce>("http://localhost:3000/users?id="+id, DataFormat.Json);
        }

        public static UserResponce CreatePUT(int id, string name, string role, string email, string updatingEmail)
        {
            string payLoad = CreatePayload(id, name, role, updatingEmail);
            return RestClientUtil.Put<UserResponce>("http://localhost:3000/users/" + id, payLoad, DataFormat.Json);
        }

        public static bool CreateDelete(int id)
        {
            return RestClientUtil.Delete("http://localhost:3000/users/" + id, DataFormat.Json , System.Net.HttpStatusCode.OK);
        }

    }
}
