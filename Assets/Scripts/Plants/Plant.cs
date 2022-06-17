using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private PlantAnimation _plantAnimation;
    [SerializeField] private PlantEdit _edit;


    private void OnEnable()
    {
        _plantAnimation.OnGrownFinishEvent += AllowToMow;
    }

    private void OnDisable()
    {
        _plantAnimation.OnGrownFinishEvent -= AllowToMow;
    }

    private void Start()
    {
        _plantAnimation.SmoothGrowing(_edit.growingTime);
    }

    private void AllowToMow()
    {
        Debug.Log("Можно косить");
    }
}
