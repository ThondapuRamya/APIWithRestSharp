using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestCaseCreationProject.APIResponces
{
    public class UserResponce
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? role { get; set; }
    }

    public class UserResponceAsArray
    {
        public UserResponce[]? userResponces { get; set; }
    }
}
