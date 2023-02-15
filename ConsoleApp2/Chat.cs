using System.Text;
using ConsoleApp2;
using Newtonsoft.Json;

class ChatGPT
{
    public void Start()
    {
        Json json = new();

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("User:");

            string promt = Console.ReadLine();
            string response ="ChatGPT" + GenerateResponse(json.Get().API, promt);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(response);
            Console.ForegroundColor = ConsoleColor.Green;
        }
       
    }

    private string GenerateResponse(string apiKey, string prompt)
    {
        using (var client = new HttpClient())
        {
            string endpoint = "https://api.openai.com/v1/engines/text-davinci-002/completions";
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiKey);
            var content = new StringContent("{\"prompt\": \"" + prompt + "\", \"max_tokens\": 100, \"temperature\": 0.5, \"top_p\": 1, \"frequency_penalty\": 0, \"presence_penalty\": 0}", Encoding.UTF8, "application/json");
            var response = client.PostAsync(endpoint, content).Result;
            string responseString = response.Content.ReadAsStringAsync().Result;
            dynamic responseJson = JsonConvert.DeserializeObject(responseString);
            string responseText = responseJson.choices[0].text;
            return responseText;
        }
    }

}

