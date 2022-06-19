using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropStack : MonoBehaviour
{
    [SerializeField] private StackEdit _edit;
    [SerializeField] private GameObject _firstBone;

    public Transform CurrentPlase => _dropPlaces[_currentIndex];
    public bool PlaceAwailable => _currentIndex < _dropPlaces.Length - 1;

    private Transform[] _dropPlaces = new Transform[40];
    private Stack<GameObject> _stack = new Stack<GameObject>();
    private int _currentIndex = 0;

    private void Awake()
    {
        FillDropPlaces();
    }

    public void AddDrop(GameObject gameObject)
    {
        _stack.Push(gameObject);
        _currentIndex++;
    }

    private void FillDropPlaces()
    {
        _dropPlaces[0] = _firstBone.GetComponent<Transform>();
        for (int i = 1; i < _dropPlaces.Length; i++)
        {
            _dropPlaces[i] = _dropPlaces[i - 1].GetChild(0).GetComponent<Transform>();
        }
    }
}
