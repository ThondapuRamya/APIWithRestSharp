using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APILearningRestSharpFramework
{
    public class RestAPIResponce
    {
        public static RestResponse? responce { get; set; }
        public static RestResponse ExecuteRestRequest(RestRequest request) 
        {
            RestClient client = new RestClient();
           
           
             responce = client.Execute(request);               
           
            return responce;
        }
    }
}
