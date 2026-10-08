using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CORNPOSAPICaller
{
    public class APICaller
    {
        string CustomApiUrl = "http://api.faastdemo.com/api/";
        public DataTable ExecStoreProcedure(SpData data)
        {
            try
            {
                string url = CustomApiUrl + "/Common/ExecSp";
                HttpContent content = new StringContent(JsonSerializer(data), Encoding.UTF8, "application/json");
                var response = PostData(url, content, true);
                if (response.IsSuccessStatusCode)
                {
                    var modelData = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<DataTable>(modelData);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return null;
        }

        public LoginToken Login(string username, string password)
        {
            try
            {
                LoginToken token = null;
                string url = CustomApiUrl + "token";

                var keyValues = new List<KeyValuePair<string, string>>();
                keyValues.Add(new KeyValuePair<string, string>("grant_type", "password"));
                keyValues.Add(new KeyValuePair<string, string>("username", username));
                keyValues.Add(new KeyValuePair<string, string>("password", password));

                HttpContent objContent = new FormUrlEncodedContent(keyValues);
                var response = PostData(url, objContent, false);
                if (response.IsSuccessStatusCode)
                {
                    var boData = response.Content.ReadAsStringAsync().Result;
                    token = JsonConvert.DeserializeObject<LoginToken>(boData);
                    return token;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return null;
        }
        

        //public static HttpResponseMessage GetData(string url, bool addAuthToken = true, HttpContent obj = null)
        //{
        //    HttpClient client = new HttpClient();
        //    client.Timeout = System.TimeSpan.FromMinutes(10);
        //    var xConn = "H4sIAAAAAAAEAA3MXWvTYByGcQf1xDM3RfBQEXcia93TrAG1tFtmmr6lXbNlD4ik65qUJLXWrqsFMTsQBanolCo4ZTCssspe0MosHYP/jV8kn8Re/I4v39uZxOg89S9hgD3fOxqjA9/7RIcTOEQ31cZrDBvTCp2dQwejiTh1fG8X7/EdWy06tfGZXX6Od/gWpSG6tcxUtHTjIrZVfGjhDb7SyV28uoCXKr7cpB6OH/7bpT6dYueZRnv0dvKxRb0E9a4GqD+Fn+gG0G3SACdXAjR8QH+wfx2/fe8vdXBAPfpBv2hwDcd0xGkfo/FhCy/kxU18lMToGrbv3Bp3L8sNm0mVmbpZbYV5nMfTeSezmouIgtNctJfm0vNPliS7rYosbClmUsw5ScEQl/X7JS0fMZJxXmdiMqVaxqOQVlZ4KbIihWdDbpW1bCYEzZq06SwIulII1XWBx1i5oesmC8Y2bosFI1bcyBqy4nJ5xpBdcXUll7cbaW4W9UjQkduJXG0uW7TU5ZRWfdrizBLLFbZgapmEu+421mbXK0218B85GthklAEAAA==";
        //    var bearer = "LIbKrpjN0xLuQ6H5S5wIifjb9QLu_d0CbjfzZAh4_c5SkRgVVj96mIfdh3bVNi9QYC0L4fl_s2ho8Kqdgq6c1_uwjSLJ4ehmDhfL4qPA7Cl1kruDof5tIEBgCJ6oRFO_YAElOlA0WMeNRVWrPD5bsZQE7fFC0sIfcBmnbmjhuTCFIRv9dGqH__yN3YpM97--she45PASjU_es4v43yd3ATP_XOGRtybvu35E2eqY1gc1CtRkwFVIFQ63-Xig9HbEEF_OMsgPgf2IDqupvdfWNfG5DiowJQYu2650FAPz3yDJbsbGiSAFH54Iiw53gkHgDeNg-RC0nv96ykLaDITPFqzS-DQO4Um85WhUWaAfEOcntyGcLE2C9n4lPobHAWCsIwHtc-OEkvvlvxBG-cvNIg_VfD_74B79XLO-nhSUCvJXvJyQHfbieuQsyoVWgmYAWbqI6eaajO-va5u9y5emrQ7MlQi3V1HcJbT1bJvPwgA";
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    client.DefaultRequestHeaders.Add("x-conn", xConn);

        //    if (addAuthToken)
        //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer);

        //    HttpResponseMessage resp = null;
        //    resp = obj == null ? client.GetAsync(url, HttpCompletionOption.ResponseContentRead).Result : client.PostAsync(url, obj).Result;

        //    return resp;
        //}

        public static HttpResponseMessage PostData(string url, HttpContent obj, bool addAuthToken = true)
        {
            HttpClient client = new HttpClient();
            client.Timeout = System.TimeSpan.FromMinutes(180);
            var xConn = "H4sIAAAAAAAEAA3MXWvTYByGcQf1xDM3RfBQEXcia93TrAG1tFtmmr6lXbNlD4ik65qUJLXWrqsFMTsQBanolCo4ZTCssspe0MosHYP/jV8kn8Re/I4v39uZxOg89S9hgD3fOxqjA9/7RIcTOEQ31cZrDBvTCp2dQwejiTh1fG8X7/EdWy06tfGZXX6Od/gWpSG6tcxUtHTjIrZVfGjhDb7SyV28uoCXKr7cpB6OH/7bpT6dYueZRnv0dvKxRb0E9a4GqD+Fn+gG0G3SACdXAjR8QH+wfx2/fe8vdXBAPfpBv2hwDcd0xGkfo/FhCy/kxU18lMToGrbv3Bp3L8sNm0mVmbpZbYV5nMfTeSezmouIgtNctJfm0vNPliS7rYosbClmUsw5ScEQl/X7JS0fMZJxXmdiMqVaxqOQVlZ4KbIihWdDbpW1bCYEzZq06SwIulII1XWBx1i5oesmC8Y2bosFI1bcyBqy4nJ5xpBdcXUll7cbaW4W9UjQkduJXG0uW7TU5ZRWfdrizBLLFbZgapmEu+421mbXK0218B85GthklAEAAA==";
            //    xConn = "H4sIAAAAAAAEAA3MXWvTYByGcQf1xDM3RfBQEXcia93TrAG1tFtmmr6lXbNlD4ik65qUJLXWrqsFMTsQBanolCo4ZTCssspe0MosHYP/jV8kn8Re/I4v39uZxOg89S9hgD3fOxqjA9/7RIcTOEQ31cZrDBvTCp2dQwejiTh1fG8X7/EdWy06tfGZXX6Od/gWpSG6tcxUtHTjIrZVfGjhDb7SyV28uoCXKr7cpB6OH/7bpT6dYueZRnv0dvKxRb0E9a4GqD+Fn+gG0G3SACdXAjR8QH+wfx2/fe8vdXBAPfpBv2hwDcd0xGkfo/FhCy/kxU18lMToGrbv3Bp3L8sNm0mVmbpZbYV5nMfTeSezmouIgtNctJfm0vNPliS7rYosbClmUsw5ScEQl/X7JS0fMZJxXmdiMqVaxqOQVlZ4KbIihWdDbpW1bCYEzZq06SwIulII1XWBx1i5oesmC8Y2bosFI1bcyBqy4nJ5xpBdcXUll7cbaW4W9UjQkduJXG0uW7TU5ZRWfdrizBLLFbZgapmEu+421mbXK0218B85GthklAEAAA==";

            var bearer = APIResult.AccessToken;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("x-conn", xConn);

            if (addAuthToken)
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer);

            HttpResponseMessage resp = client.PostAsync(url, obj).Result;

            return resp;
        }

        public string JsonSerializer(object data)
        {
            return JsonConvert.SerializeObject(data, new JsonSerializerSettings { Converters = new List<JsonConverter> { new TimeSpanJsonConverter() } });
        }
    }
}
