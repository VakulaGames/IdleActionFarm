using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCollector : MonoBehaviour
{
    [SerializeField] private DropStack _stack;

    private void OnTriggerEnter(Collider other)
    {
        if (_stack.PlaceAwailable)
        {
            if (other.transform.TryGetComponent<Drop>(out Drop drop))
            {
                _stack.AddDrop(drop.gameObject);
                drop.MoveToStack(_stack.CurrentPlase);
            }
        }
    }
}
