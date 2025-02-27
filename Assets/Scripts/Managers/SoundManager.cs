using System;
using UnityEngine;

public class SoundManager
{
    //AudioSource[] _audioSource = new AudioSource[(int)Define.Sound.End];

    //public void Init()
    //{
    //    var gameManager = GameObject.Find("GameManager");
    //    var sound = Enum.GetNames(typeof(Define.Sound));
    //    for (int i = 0; i < sound.Length - 1; i++)
    //    {
    //        var go = new GameObject { name = sound[i] };
    //        _audioSource[i] = go.AddComponent<AudioSource>();
    //        var clip = UI.GameManager.Resource.Load<AudioClip>($"Sound/{sound[i]}");
    //        _audioSource[i].GetComponent<AudioSource>().clip = clip;
    //        go.transform.parent = gameManager.transform;
    //    }

    //    _audioSource[(int)Define.Sound.Battle].loop = true;
    //    _audioSource[(int)Define.Sound.Lobby].loop = true;
    //    _audioSource[(int)Define.Sound.Splash].loop = true;
    //}

    //public void Stop(Define.Sound sound)
    //{
    //    var audio = _audioSource[(int)sound];
    //    if (audio.isPlaying)
    //    {
    //        audio.Stop();
    //    }
    //}

    //public void StopAll()
    //{
    //    var sound = Enum.GetNames(typeof(Define.Sound));
    //    for (int i = 0; i < sound.Length - 1; i++)
    //    {
    //        var audio = _audioSource[i];
    //        if (audio.isPlaying)
    //        {
    //            audio.Stop();
    //        }
    //    }
    //}

    //public void Play(Define.Sound sound, float pitch = 1.0f)
    //{
    //    var audio = _audioSource[(int)sound];
    //    if (sound != Define.Sound.Distribution && sound != Define.Sound.Reveal && sound != Define.Sound.Coin && sound != Define.Sound.Result)
    //    {
    //        Stop(Define.Sound.Lobby);
    //        Stop(Define.Sound.Battle);
    //        Stop(Define.Sound.Splash);
    //        audio.pitch = pitch;
    //        audio.Play();
    //    }
    //    else
    //    {
    //        audio.pitch = pitch;
    //        audio.PlayOneShot(audio.clip);
    //    }
    //}
}
