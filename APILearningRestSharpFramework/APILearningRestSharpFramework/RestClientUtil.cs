using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APILearningRestSharpFramework
{
    public class RestClientUtil
    {
        static RestClient _RestClient;
        static RestRequest _RestRequest;

        public static RestClient CraeteRestClient()
        {
            if (_RestClient == null)
            {
                return new RestClient(ConfigurationManager.AppSettings["BaseUrl"].ToString());
            }
            else { return _RestClient; }
        }
        public static RestRequest CreateRequest(string resource, Method method, DataFormat format) 
        {
            RestRequest request = new RestRequest(resource);
           
            request.Method = method;
            request.RequestFormat = format;
            return request;

        }
        
        public static T Post<T>(string resource, string payload, DataFormat format)
        {
            RestClient restClient = new RestClient("http://localhost:3000");
           return JsonConvert.DeserializeObject<T>(
                restClient.Execute
                ( 
                  CreateRequest(resource, Method.Post,format)
                 .AddBody(payload)
                )
                .Content);                       
        }

        public static T Get<T>(string resource,DataFormat format)
        {
            RestClient restClient = new RestClient("http://localhost:3000");
            return JsonConvert.DeserializeObject<T>(
                 restClient.Execute
                 (
                   CreateRequest(resource, Method.Get, format)                  
                 )
                 .Content);
        }

        public static T Put<T>(string resource, string payload, DataFormat format)
        {
            RestClient restClient = new RestClient("http://localhost:3000");
            return JsonConvert.DeserializeObject<T>(
                 restClient.Execute
                 (
                   CreateRequest(resource, Method.Put, format)
                  .AddBody(payload)
                 )
                 .Content);
        }

        public static bool Delete(string resource,  DataFormat format, HttpStatusCode expectedStatusCode)
        {
            RestClient restClient = new RestClient("http://localhost:3000");
            return restClient.Execute
                 (
                   CreateRequest(resource, Method.Post, format)                  
                 )
                 .StatusCode.Equals(expectedStatusCode);
        }


    }
}
