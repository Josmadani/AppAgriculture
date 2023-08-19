using AppAgriculture.ApiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAgriculture.ApiRest
{
    public class ApiRestConfig
    {
        private static String UrlBase = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:7154/" : "'http://localhost:7154/";

        public AuthModel authModel = new AuthModel() {
            UrlBase = UrlBase,
            PathAuth = "UsuCombMovil/",
            MethodWebService = "LoginAuth"
        };

    }
}
