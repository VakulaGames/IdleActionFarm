using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DropStack : MonoBehaviour
{
    [SerializeField] private StackEdit _edit;
    [SerializeField] private GameObject _firstBone;
    [SerializeField] private CharacterMovement _characterMovement;
    [SerializeField] private Transform _barn;
    [SerializeField] private Image _dropBar;
    [SerializeField] private Bank _bank;

    public Transform CurrentPlase =>  _dropPlaces[_stack.Count -1];
    public bool PlaceAwailable => _stack.Count < _edit.stackMaxCount;

    private Transform[] _dropPlaces = new Transform[40];
    private List<Transform> _stack = new List<Transform>();

    private Sequence _wiggleSequence;
    private Sequence _sellSequence;
    private bool _isSelling;

    private void Awake()
    {
        FillDropPlaces();
    }

    private void Start()
    {
        StartWiggle();
        UpdateDropBar();
    }

    public void AddDrop(GameObject gameObject)
    {
        if (gameObject.GetComponent<Drop>())
        {
            _stack.Add(gameObject.transform);
        }

        UpdateDropBar();
    }

    public void StartSell()
    {
        _isSelling = true;
        _sellSequence = DOTween.Sequence();

        int count = _stack.Count;

        for (int i = count - 1; i >= 0; i--)
        {
            Transform t = _stack[i];
            int price = t.GetComponent<Drop>().Price;

            _sellSequence.Append(t.DOMove(_barn.position, _edit.sellDuration));

            _sellSequence.AppendCallback(() =>
            {
                _stack.Remove(t);
                Destroy(t.gameObject);
                UpdateDropBar();
                _bank.FlyCoin(price);

                if (_isSelling == false)
                {
                    _sellSequence.Kill();
                }
            });
        }
    }

    public void StopSell()
    {
        _isSelling = false;
    }

    private void UpdateDropBar()
    {
        _dropBar.fillAmount = (float)_stack.Count / (float)_edit.stackMaxCount;
    }

    private void FillDropPlaces()
    {
        _dropPlaces[0] = _firstBone.GetComponent<Transform>();

        for (int i = 1; i < _dropPlaces.Length; i++)
        {
            _dropPlaces[i] = _dropPlaces[i - 1].GetChild(0).GetComponent<Transform>();
        }
    }

    private void StartWiggle()
    {
        _wiggleSequence = DOTween.Sequence();

        float speed = _characterMovement.Speed;

        for (int i = 0; i < _stack.Count; i++)
        {
            speed = _characterMovement.Speed;
            _wiggleSequence.Append(_dropPlaces[i].DOLocalRotate(new Vector3(-_edit.adgelWiggle / 2 * speed, 0, -_edit.adgelWiggle * speed), _edit.wiggleDuration));
        }

        for (int i = 0; i < _stack.Count; i++)
        {
            speed = _characterMovement.Speed;
            _wiggleSequence.Append(_dropPlaces[i].DOLocalRotate(new Vector3(_edit.adgelWiggle/2 * speed, 0, _edit.adgelWiggle * speed), _edit.wiggleDuration));
        }

        _wiggleSequence.AppendCallback(StartWiggle);
    }
}
