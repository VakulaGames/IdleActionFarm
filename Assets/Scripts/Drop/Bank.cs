using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Bank : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    [SerializeField] private Image _coinImage;
    [SerializeField] private TMP_Text _coinText;
    [SerializeField] private StackEdit _edit;
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private Transform _coinStartPos;
    [SerializeField] private Transform[] _pathPoints;

    private int _coinCount;
    private Vector3[] _path;
    private PathType _pathType = PathType.CatmullRom;

    private void Start()
    {
        _coinCount = 0;
        _coinText.text = _coinCount.ToString();

        _path = PathInit(_pathPoints);
    }

    public void FlyCoin(int price)
    {
        GameObject coin = Instantiate(_coinPrefab,_canvas.transform);
        coin.transform.position = _coinStartPos.position;
        coin.transform.localScale *= 0.3f;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(coin.transform.DOScale(1, _edit.flyCoinDuration));
        sequence.Join(coin.transform.DOPath(_path, _edit.flyCoinDuration, _pathType));
        sequence.Append(_coinImage.transform.DOScale(1.3f, 0.1f));
        sequence.AppendCallback(() =>
        {
            _coinCount += price;
            _coinText.text = _coinCount.ToString();
        });
        sequence.Append(_coinImage.transform.DOScale(1, 0.1f));
    }

    private Vector3[] PathInit (Transform[] points)
    {
        Vector3[] path = new Vector3[points.Length];

        for (int i = 0; i < points.Length; i++)
        {
            path[i] = points[i].position;
        }
        return path;
    }
}
