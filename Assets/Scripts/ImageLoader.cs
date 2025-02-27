using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class ImageLoader
{
    private static Dictionary<string, Sprite> _textureDict = new();

    public static IEnumerator Load(string stockCode, string exchange, Action<Sprite> action)
    {
        if (_textureDict.TryGetValue(stockCode, out Sprite _texture))
        {
            action(_texture);
            yield break;
        }

        var region = Utils.GetRegion(exchange) == Define.Region.KOR ? "domestic" : "overseas";

        var url = $"https://d2fx11ve2n0wvo.cloudfront.net/{region}/images/small/{stockCode}.jpg";
        var www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        while (!www.isDone)
        {
            yield return null;
        }

        if (www.result != UnityWebRequest.Result.Success || www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("WWWResult: " + www.result + "ResponseCode: " + www.responseCode);
            Debug.Log("DownloadHandler: " + www.downloadHandler.text);
            Debug.Log("Error: " + www.error);
        }
        else
        {
            var texture = DownloadHandlerTexture.GetContent(www);
            var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

            action(sprite);
            if (!_textureDict.ContainsKey(stockCode))
            {
                _textureDict.Add(stockCode, sprite);
            }
        }
    }
}
