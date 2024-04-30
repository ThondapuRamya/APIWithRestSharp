using APILearningRestSharpFramework;
using APITestCaseCreationProject.APIRequests;
using APITestCaseCreationProject.APIResponces;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace APITestCaseCreationProject.PageObjects
{
    internal class UsersPageObject
    {
       public static string? BaseUrl;
        public static bool CreateUsers(int id, string name, string role, string email)
        {
            BaseUrl = ConfigurationManager.AppSettings["BaseUrl"]?.ToString();
            string resourceURL = "/users";

            UsersRequest ur = new UsersRequest();
            ur.id = id;
            ur.name = name; 
            ur.role = role;
            ur.email = email;

            string josnContent = JsonConvert.SerializeObject(ur);

           RestRequest request= RestAPIRequest.CreateRequest(BaseUrl+resourceURL,DataFormat.Json, josnContent);
            RestResponse responce = RestAPIResponce.ExecuteRestRequest(request);
            return responce.StatusCode.Equals(201);
        }


        public static bool GetUsers(int id, string name, string role, string email)
        {
            BaseUrl = ConfigurationManager.AppSettings["BaseUrl"]?.ToString();
            string resourceURL = "/users";

      

            RestRequest request = RestAPIRequest.GetRequest(BaseUrl + resourceURL);
            request.AddQueryParameter("id", id);
            RestResponse responce = RestAPIResponce.ExecuteRestRequest(request);
            return responce.StatusCode.Equals(200);
        }

        public static string GetUsers(int id)
        {
            BaseUrl = ConfigurationManager.AppSettings["BaseUrl"]?.ToString();
            string resourceURL = "/users";



            RestRequest request = RestAPIRequest.GetRequest(BaseUrl + resourceURL);
            request.AddQueryParameter("id", id);
            RestResponse responce = RestAPIResponce.ExecuteRestRequest(request);
            return responce.Content;
        }


        public static bool UpdateUser(int id, string newMailToUpdate)
        {
            BaseUrl = ConfigurationManager.AppSettings["BaseUrl"]?.ToString();
            string resourceURL = "/users";


            UsersRequest ur = new UsersRequest();           
            ur.email = newMailToUpdate;
            string josnContent = JsonConvert.SerializeObject(ur);

            
            RestRequest request = RestAPIRequest.PATCHRequest(BaseUrl + resourceURL, DataFormat.Json, josnContent);
            request.AddQueryParameter("id", id);
            
            RestResponse responce = RestAPIResponce.ExecuteRestRequest(request);
            return responce.StatusCode.Equals(200);
        }


        public static bool DeleteUser(int id)
        {
            BaseUrl = ConfigurationManager.AppSettings["BaseUrl"]?.ToString();
            string resourceURL = "/users";


           

            RestRequest request = RestAPIRequest.DeleteRequest(BaseUrl + resourceURL);
            request.AddQueryParameter("id", id);

            RestResponse responce = RestAPIResponce.ExecuteRestRequest(request);
            return responce.StatusCode.Equals(200);
        }

    }
}
