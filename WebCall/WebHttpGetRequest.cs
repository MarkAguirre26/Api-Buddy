using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Web;

namespace Api_Buddy.WebCall
{

    public class WebHttpGetRequest
    {





        public static async Task<string> MakeGetRequestAsync(string uri)
        {
           

            // Create an instance of HttpClient
            using (HttpClient httpClient = new HttpClient())
            {


                try
                {


                    // Send a GET request
                    HttpResponseMessage response = await httpClient.GetAsync(uri);



                    // Check if the response is successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read and output the response content as a string
                        string content = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Response content: " + content);
                        return content;
                    }
                    else
                    {
                        Console.WriteLine("Request failed with status code: " + response.StatusCode);
                        return response.StatusCode.ToString();
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine("Request error: " + ex.Message);
                    return ex.Message;
                }
            }


        }




    }
}
