using System;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _scythe;
    [SerializeField] private Detector _detector;
    [SerializeField] private GameObject _joystickGO;

    public event Action OnFinishCutEvent;

    private void Start()
    {
        DeActiveScythe();
    }

    public void Movement(float speed)
    {
        _animator.SetFloat("Speed", speed);
    }

    public void Cut()
    {
        _joystickGO.SetActive(false);
        _animator.SetTrigger("Cut");
    }

    public void ActiveScythe()
    {
        _scythe.SetActive(true);
    }

    public void DeActiveScythe()
    {
        _scythe.SetActive(false);
    }

    public void ShowDrop()
    {
        foreach(GameObject go in _detector.detectedObjects)
        {
            if (go.TryGetComponent<Plant>(out Plant plant))
            {
                plant.Cutting();

                if (go.TryGetComponent<DetectableObject>(out DetectableObject detectableObject))
                {
                    _detector.ReleaseDetection(detectableObject);
                }
            }
        }
    }

    public void FinishCut()
    {
        this.OnFinishCutEvent?.Invoke();
        _joystickGO.SetActive(true);
    }
}
