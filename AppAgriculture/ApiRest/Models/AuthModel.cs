using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAgriculture.ApiRest.Models
{
    public class AuthModel
    {
        public String UrlBase { get; set; }

        public String PathAuth { get; set; }

        public String MethodWebService { get; set; }

        public String UserName { get; set; }

        public String PassWord { get; set; }
    }
}
