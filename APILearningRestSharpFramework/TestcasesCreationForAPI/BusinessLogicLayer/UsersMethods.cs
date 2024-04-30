using APILearningRestSharpFramework;
using APITestCaseCreationProject.APIRequests;
using APITestCaseCreationProject.APIResponces;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace APITestCaseCreationProject.PageObjects
{
    internal class UsersMethods
    {
       public static string? BaseUrl;
        public static bool CreateUsers(int id, string name, string role, string email)
        {
            //BaseUrl = ConfigurationManager.AppSettings["BaseUrl"].ToString();
            string resourceURL = "http://localhost:3000/users";

            UsersRequest ur = new UsersRequest();
            ur.id = id;
            ur.name = name; 
            ur.role = role;
            ur.email = email;

            string josnContent = JsonConvert.SerializeObject(ur);

           RestRequest request= RestAPIRequest.CreateRequest(resourceURL,DataFormat.Json, josnContent);
            RestResponse responce = RestAPIResponce.ExecuteRestRequest(request);
            return responce.StatusCode.Equals(HttpStatusCode.Created);
        }


        public static bool GetUsers(int id, string name, string role, string email)
        {
            //BaseUrl = ConfigurationManager.AppSettings["BaseUrl"]?.ToString();
          string resourceURL = "http://localhost:3000/users"; ;

      

            RestRequest request = RestAPIRequest.GetRequest(BaseUrl + resourceURL);
            request.AddQueryParameter("id", id);
            RestResponse responce = RestAPIResponce.ExecuteRestRequest(request);
            return responce.StatusCode.Equals(HttpStatusCode.OK);
        }

        public static bool GetUsers(int id, string expectedValue)
        {
            //BaseUrl = ConfigurationManager.AppSettings["BaseUrl"]?.ToString();
             string resourceURL = "http://localhost:3000/users"; 


            RestRequest request = RestAPIRequest.GetRequest(BaseUrl + resourceURL);
            request.AddQueryParameter("id", id);
            RestResponse responce = RestAPIResponce.ExecuteRestRequest(request);
            try
            {

            }catch(Exception ex) { }
            var responceContent = JsonConvert.DeserializeObject<UserResponce[]>(responce.Content) ;            
            return responceContent[0].email.Equals(expectedValue);
            
        }


        public static bool UpdateUser(int id,string name, string role, string email, string newMailToUpdate)
        {
            //BaseUrl = ConfigurationManager.AppSettings["BaseUrl"]?.ToString();
            string resourceURL = "http://localhost:3000/users/"+id;


            UsersRequest ur = new UsersRequest();           
            ur.email = newMailToUpdate;
            ur.name = name;
            ur.role = role;
            ur.id = id;
            string josnContent = JsonConvert.SerializeObject(ur);

            
            RestRequest request = RestAPIRequest.PUTRequest(BaseUrl + resourceURL, DataFormat.Json, josnContent);
            //request.AddParameter("id", id);
            
            RestResponse responce = RestAPIResponce.ExecuteRestRequest(request);
            return responce.StatusCode.Equals(HttpStatusCode.OK);
        }


        public static bool DeleteUser(int id)
        {
            //BaseUrl = ConfigurationManager.AppSettings["BaseUrl"]?.ToString();
            string resourceURL = "http://localhost:3000/users/"+id;




            RestRequest request = RestAPIRequest.DeleteRequest(BaseUrl + resourceURL);            

            RestResponse responce = RestAPIResponce.ExecuteRestRequest(request);
            return responce.StatusCode.Equals(HttpStatusCode.OK);
        }

    }
}
