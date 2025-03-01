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
        var idx = 0;
        foreach (var card in cards)
        {
            idx++;
            var sequence = DOTween.Sequence();
            var rect = card.GetComponent<RectTransform>();

            Vector3[] path;
            int segments = 50;
            path = new Vector3[segments + 1];

            var aX = UnityEngine.Random.Range(-200, 200);
            var aY = UnityEngine.Random.Range(-200, 200);

            for (int i = 0; i <= segments; i++)
            {
                float angle = Mathf.Deg2Rad * (360f * i / segments);

                float x = rect.anchoredPosition.x + aX * Mathf.Cos(angle);
                float y = rect.anchoredPosition.y + aY * Mathf.Sin(angle);
                path[i] = new Vector3(x, y, 0f);
            }
            var r = UnityEngine.Random.Range(0, segments + 1);
            var pos = path[r];
            var rot = new Vector3(0f, 0f, UnityEngine.Random.Range(-360, 360));
            sequence.Append(rect.DOAnchorPos(new Vector2(pos.x, pos.y), 0.5f));
            sequence.Join(rect.DORotate(rot, 0.5f));

            path = new Vector3[segments + 1];
            var rd = idx % 2 == 0 ? -1 : 1;
            for (int i = 0; i <= segments; i++)
            {
                float angle = Mathf.Deg2Rad * ((360f * rd) * i / segments);

                float x = rect.anchoredPosition.x + 1 * Mathf.Cos(angle);
                float y = rect.anchoredPosition.y + 1 * Mathf.Sin(angle);
                path[i] = new Vector3(x, y, 0f);
            }

            rot = new Vector3(0f, 0f, UnityEngine.Random.Range(-720, 720));
            sequence.Append(rect.DOPath(path, 1f, PathType.Linear).SetDelay(UnityEngine.Random.Range(0f, 0.3f)).SetOptions(AxisConstraint.Z).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo));
            sequence.Join(rect.DORotate(rot, 0.5f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo));
            sequence.SetLoops(-1).SetEase(Ease.Linear);
            sequence.Play();
        }
    }
}
