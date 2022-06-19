using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private PlantAnimation _plantAnimation;
    [SerializeField] private PlantEdit _edit;
    [SerializeField] private Collider _collider;
    [SerializeField] private GameObject _grassDrop;

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
        StartGrowing();
    }

    public void Cutting()
    {
        StartGrowing();
        Instantiate(_grassDrop,transform.position, Quaternion.identity);
    }

    private void StartGrowing()
    {
        _collider.enabled = false;
        _plantAnimation.SmoothGrowing(_edit.growingTime, _edit.finishEffectTime);
    }

    private void AllowToMow()
    {
        _collider.enabled = true;
    }
}
