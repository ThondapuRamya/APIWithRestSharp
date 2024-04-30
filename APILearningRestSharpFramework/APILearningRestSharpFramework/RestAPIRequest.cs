using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APILearningRestSharpFramework
{
    public class RestAPIRequest
    {
        public static RestRequest? request { get; set; }

        public static RestRequest CreateRequest(string url, DataFormat dataFormat , string bodyToAdd )
        {
            request = new RestRequest(url);
            request.RequestFormat = dataFormat;
            request.AddBody(bodyToAdd);
            request.Method = Method.Post;
            return request;
        }

        public static RestRequest GetRequest(string url)
        {
            request = new RestRequest(url);
           
            request.Method = Method.Get;
            return request;
        }

        public static RestRequest PUTRequest(string url, DataFormat dataFormat, string bodyToAdd)
        {
            request = new RestRequest(url);
            request.RequestFormat = dataFormat;
            request.AddBody(bodyToAdd);
            request.Method = Method.Put;
            return request;
        }

        public static RestRequest PATCHRequest(string url, DataFormat dataFormat, string bodyToAdd)
        {
            request = new RestRequest(url);
            request.RequestFormat = dataFormat;
            request.AddBody(bodyToAdd);
            request.Method = Method.Patch;
            return request;
        }

        public static RestRequest DeleteRequest(string url)
        {
            request = new RestRequest(url);

            request.Method = Method.Delete;
            return request;
        }
    }
}
