using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Web;
using System.Diagnostics;

namespace Api_Buddy.WebCall
{

    public class WebHttpPostRequest
    {





        public static async Task<string> MakePostRequestAsync(string body,string uri)
        {


            // Create an instance of HttpClient
            using (HttpClient httpClient = new HttpClient())
            {
                // Specify the URI to which you want to send a POST request
                string requestUri = "https://api.example.com/post";

                // Create a StringContent with the JSON data
                StringContent content = new StringContent(body, Encoding.UTF8, "application/json");
                               

                try
                {
                    // Send a POST request with the specified content
                    HttpResponseMessage response = await httpClient.PostAsync(requestUri, content);

                    // Check if the response is successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read and output the response content as a string
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Debug.WriteLine("Response content: " + responseBody);
                        return responseBody;
                    }
                    else
                    {
                        Debug.WriteLine("Request failed with status code: " + response.StatusCode);
                        return response.StatusCode.ToString();
                    }
                }
                catch (HttpRequestException ex)
                {
                    Debug.WriteLine("Request error: " + ex.Message);
                    return ex.Message;
                }
            }


        }




    }
}
