using AppAgriculture.Models.UserInfo;
using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Net.Http.Headers;

namespace AppAgriculture.ApiRest.Login
{
    public class LoginAuth
    {
        private HttpClient httpClient;
        JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
        private ApiRestConfig apiRestConfig = new ApiRestConfig();

        public LoginAuth()
        {
            httpClient = new HttpClient();
            jsonSerializerOptions = new JsonSerializerOptions() {
                WriteIndented = true,
            };
        }

        public async Task<UserInfo> ReadPostWebService(String UserName, String PassWord)
        {
            apiRestConfig.authModel.UserName = UserName;
            apiRestConfig.authModel.PassWord = PassWord;

            UserInfo userInfo = new UserInfo()
            {
                UsuCombId = 0,
                UserName = apiRestConfig.authModel.UserName,
                Pass = apiRestConfig.authModel.PassWord,
                NombreUsuario = string.Empty,
                CargoUsuario = 0,
                NivelAcceso = 0
            };
            string json = JsonSerializer.Serialize<UserInfo>(userInfo, jsonSerializerOptions);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            String UrlWebService = apiRestConfig.authModel.UrlBase +
                apiRestConfig.authModel.PathAuth +
                apiRestConfig.authModel.MethodWebService;
//            httpClient.BaseAddress = new Uri(UrlWebService);

            try
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//                HttpResponseMessage response = await httpClient.GetAsync("");
                HttpResponseMessage response = await httpClient.PostAsync(UrlWebService, stringContent);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("1");
                    var dataResponse = await response.Content.ReadAsStringAsync();
                    try
                    {
                        RootUserInfo rootUserInfo = JsonConvert.DeserializeObject<RootUserInfo>(dataResponse);

                        foreach (UserInfo itemList in rootUserInfo.UserInfo)
                        {
                            userInfo.UsuCombId = itemList.UsuCombId;
                            userInfo.UserName = itemList.UserName;
                            userInfo.Pass = itemList.Pass;
                            userInfo.NombreUsuario = itemList.NombreUsuario;
                            userInfo.CargoUsuario = itemList.CargoUsuario;
                            userInfo.NivelAcceso = itemList.NivelAcceso;
                        }
                    }
                    catch (Exception ex)
                    {
                        userInfo.UsuCombId = -1;
                        userInfo.UserName = "[Exception]: Deserializando Objeto\n" + ex.Message;
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                userInfo.UsuCombId = -1;
                userInfo.UserName = "[HttpRequestException]: Conectando al WebService\n" + ex.Message;
            }
            catch (Exception ex)
            {
                userInfo.UsuCombId = -1;
                userInfo.UserName = "[Exception]: Conectando al WebService\n" + ex.Message;
            }
            return userInfo;
        }
    }
}
