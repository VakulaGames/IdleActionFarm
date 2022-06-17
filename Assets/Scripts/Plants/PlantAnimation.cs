using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class PlantAnimation : MonoBehaviour
{
    public event Action OnGrownFinishEvent;

    private Sequence _sequence;

    private void Awake()
    {
        DOTween.Init();
        _sequence = DOTween.Sequence();
        _sequence.Append(transform.DOScale(0, 0));
    }

    public void SmoothGrowing(float timeGrowing)
    {
        _sequence.Append(transform.DOScale(1, timeGrowing));
        _sequence.AppendCallback(GrownFinish);
    }

    private void GrownFinish()
    {
        this.OnGrownFinishEvent?.Invoke();
    }
}
