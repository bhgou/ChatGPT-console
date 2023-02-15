using Newtonsoft.Json;

namespace ConsoleApp2;

public class Json
{
    public Config Get()
    {
        var _config = JsonConvert.DeserializeObject<Config>(File.ReadAllText("api.json"));
        return _config;
    }
}