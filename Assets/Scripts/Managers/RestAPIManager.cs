using Google.Protobuf;
using Newtonsoft.Json;
using Pbm;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RestAPIManager
{
    public const string ADDRESS = "http://43.202.64.246:8001";
    public const string PREFIX = "/v1";
    public const string URL = ADDRESS + PREFIX;

    public string USER_LOGIN = URL + "/users/login";
    public string USER_PROFILE = URL + "/users/profile";


    public IEnumerator RequestPost<T>(string url, IMessage data, Action<T> action = null) where T : IMessage, new()
    {
        using (var www = new UnityWebRequest(url, "POST"))
        {
            var settings = new JsonSerializerSettings
            {
                Converters = { new Utils.EnumConverter() }
            };
            var dataString = JsonConvert.SerializeObject(data, settings);

            var jsonToSend = new System.Text.UTF8Encoding().GetBytes(dataString);
            www.uploadHandler = new UploadHandlerRaw(jsonToSend);
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");
            www.timeout = 60;
            yield return www.SendWebRequest();

            while (!www.isDone)
            {
                yield return null;
            }

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("WWWResult: " + www.result + " ResponseCode: " + www.responseCode);
                Debug.Log("DataString: " + dataString);
                Debug.Log("DownloadHandler: " + www.downloadHandler.text);
                Debug.Log("Error: " + www.error);
            }
            else
            {
                if (action != null)
                {
                    var t = Utils.Unmarshal<T>(www.downloadHandler.text);
                    action(t);
                }
            }
        }
    }

}
