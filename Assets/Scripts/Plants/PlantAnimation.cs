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

    public void SmoothGrowing(float timeGrowing, float finishEffectTime)
    {
        _sequence = DOTween.Sequence();
        _sequence.Append(transform.DOScale(0, 0));
        _sequence.Append(transform.DOScale(1, timeGrowing));

        _sequence.Append(transform.DOScale(1.4f, finishEffectTime / 2));
        _sequence.Append(transform.DOScale(1.2f, finishEffectTime / 4));

        _sequence.AppendCallback(GrownFinish);
    }

    private void GrownFinish()
    {
        this.OnGrownFinishEvent?.Invoke();
    }
}
