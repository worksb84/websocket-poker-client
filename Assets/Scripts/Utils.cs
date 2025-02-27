using Google.Protobuf;
using Newtonsoft.Json;
using Pbm;
using System;

public static class Utils
{
    public class EnumConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Enum).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = (string)reader.Value;
            return Enum.Parse(objectType, value);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue((int)value);
        }
    }

    public static Define.Region GetRegion(string exchange)
    {
        var region = Define.Region.KOR;
        if (exchange == "KOSPI" || exchange == "KOSDAQ")
        {
            region = Define.Region.KOR;
        }
        else if (exchange == "NYSE" || exchange == "NASDAQ")
        {
            region = Define.Region.US;
        }
        return region;
    }

    public static T Unmarshal<T>(string Msg) where T : IMessage, new()
    {
        var parserSettings = JsonParser.Settings.Default.WithIgnoreUnknownFields(true);
        var parser = new JsonParser(parserSettings);
        return parser.Parse<T>(Msg);
    }

    public static string Marshal(IMessage message)
    {
        var name = message.Descriptor.Name.Replace("_", string.Empty);
        var id = Convert.ToInt32(Enum.Parse(typeof(ID), name));

        var settings = new JsonSerializerSettings
        {
            Converters = { new EnumConverter() }
        };
        var packet = new Message() { Id = id, Body = JsonConvert.SerializeObject(message, settings) };
        return JsonConvert.SerializeObject(packet, settings);
    }
}