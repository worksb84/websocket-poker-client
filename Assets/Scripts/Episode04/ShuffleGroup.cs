using DG.Tweening;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleGroup : MonoBehaviour
{
    [SerializeField] private List<GameObject> cards;

    internal void StartShuffle()
    {
        foreach (var card in cards)
        {
            var sequence = DOTween.Sequence();
            var rect = card.GetComponent<RectTransform>();
            var posX = UnityEngine.Random.Range(-200f, 200f);
            var posY = UnityEngine.Random.Range(-200f, 200f);
            var rot = new Vector3(0f, 0f, UnityEngine.Random.Range(-20, 20));
            sequence.Append(rect.DOAnchorPos(new Vector2(posX, posY), 0.5f));
            sequence.Join(rect.DORotate(rot, 0.5f));

            Vector3[] ellipsePath;
            int segments = 50;
            ellipsePath = new Vector3[segments + 1];

            var aX = UnityEngine.Random.Range(-1, 1);
            var aY = UnityEngine.Random.Range(-1, 1);

            for (int i = 0; i <= segments; i++)
            {
                float angle = Mathf.Deg2Rad * (360f * i / segments);
                
                float x = rect.anchoredPosition.x + aX * Mathf.Cos(angle);
                float y = rect.anchoredPosition.y + aY * Mathf.Sin(angle);
                ellipsePath[i] = new Vector3(x, y, 0f);
            }

            rot = new Vector3(0f, 0f, UnityEngine.Random.Range(-100, 100));
            sequence.Append(rect.DOPath(ellipsePath, 1f, PathType.Linear).SetOptions(AxisConstraint.Z));
            sequence.Join(rect.DORotate(rot, 0.5f).SetEase(Ease.Linear));
            sequence.SetLoops(-1, LoopType.Yoyo);
            sequence.Play();
        }
    }
}
