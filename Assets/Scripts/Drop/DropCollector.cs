using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCollector : MonoBehaviour
{
    [SerializeField] private DropStack _stack;

    private void OnTriggerEnter(Collider other)
    {
        if (_stack.PlaceAwailable == true)
        {
            if (other.transform.TryGetComponent<Drop>(out Drop drop))
            {
                _stack.AddDrop(drop.gameObject);
                drop.MoveToStack(_stack.CurrentPlase);
            }
        }

        if (other.transform.TryGetComponent<Barn>(out Barn barn))
        {
            _stack.StartSell();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.TryGetComponent<Barn>(out Barn barn))
        {
            _stack.StopSell();
        }
    }
}
