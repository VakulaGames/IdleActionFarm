using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mud : MonoBehaviour
{
    [SerializeField] private Plant _plant;
    [SerializeField] private Transform[] _plantsPoint;

    private void Start()
    {
        FillPlace(_plant.gameObject);
    }

    private void FillPlace(GameObject gameObject)
    {
        foreach(Transform transform in _plantsPoint)
        {
            Instantiate(gameObject, transform.position,Quaternion.identity, this.transform);
        }
    }
}
