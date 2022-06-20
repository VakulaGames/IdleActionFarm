using UnityEngine;
using DG.Tweening;

public class Drop : MonoBehaviour
{
    [SerializeField] private PlantEdit _edit;

    public int Price => _edit.price;

    private Sequence _sequence;

    public void MoveToStack(Transform target)
    {
        transform.SetParent(target.transform, true);
        _sequence = DOTween.Sequence();

        _sequence.Append(gameObject.transform.DOLocalMove(Vector3.zero, _edit.harvestDuration));
        _sequence.Join(gameObject.transform.DOLocalRotate(Vector3.zero, _edit.harvestDuration));
        _sequence.AppendCallback(() =>
        {
            transform.localPosition = Vector3.zero;
        });
    }
}

