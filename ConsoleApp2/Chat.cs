using System.Text;
using ConsoleApp2;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Types;

class ChatGPT
{
    static Json json = new();
    public void Start()
    {
        var botClient = new TelegramBotClient(json.Get().APITelegram);
        botClient.StartReceiving(Update,Error);
    }

    private Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
    {
        throw new NotImplementedException();
    }

    async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
    {
        var message = update.Message;
        string response = await GenerateResponse(json.Get().API, message.Text);
        await botClient.SendTextMessageAsync(message.Chat.Id,response);
    }

    static async Task<string>  GenerateResponse(string apiKey, string prompt)
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

