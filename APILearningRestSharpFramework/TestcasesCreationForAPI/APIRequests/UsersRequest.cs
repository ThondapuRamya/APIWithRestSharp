using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestCaseCreationProject.APIRequests
{
    internal class UsersRequest
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? role { get; set; }
    }
}
