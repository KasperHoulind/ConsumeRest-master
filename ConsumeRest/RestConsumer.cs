using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using ModelLibrary;
using Newtonsoft.Json;

namespace ConsumeRest
{
    internal class RestConsumer
    {
        public RestConsumer()
        {
        }

        public void Start()
        {
            IList<RestData> all = GetAll();
            foreach (RestData data in all)
            {
                //Console.WriteLine(data);
            }

            RestData one = GetOne(5);
            Console.WriteLine("ONE \n" + one);

            Post(new RestData(555,555, "jadada was here", true));
            Console.WriteLine("Post result = " + resultat);
        }



        private IList<RestData> GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                string jsonContent = client.GetStringAsync("https://jsonplaceholder.typicode.com/todos").Result;
                IList<RestData> cList = JsonConvert.DeserializeObject<IList<RestData>>(jsonContent);
                return cList;
            }
        }

        private RestData GetOne(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string jsonContent = client.GetStringAsync("https://jsonplaceholder.typicode.com/todos"+ "/" + id).Result;
                RestData data = JsonConvert.DeserializeObject<RestData>(jsonContent);
                return data;
            }
        }

        public bool Post(RestData restData)
        {
            //laver body

            String json = JsonConvert.SerializeObject(restData);
            StringContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using (HttpClient client = new HttpClient())
            {
                // sender
                HttpResponseMessage resultMessage = client.PostAsync('https://jsonplaceholder.typicode.com/todos', content).Result;
               
                
                // optional if any result to unpack
                string jsonResult = resultMessage.Content.ReadAsStringAsync().Result;
                Console.WriteLine("Json svar string = " +jsonResult);
                
                //ingen rigtig svar
                //var result = JsonConvert.DeserializeObject<TReturnType>(jsonResult);

                return resultMessage.IsSuccessStatusCode; //200 status code = sandt alt andet falsk
            }
        }
    }
}