using System;
using UnityEngine;

[RequireComponent(typeof(DetectableObject))]
public class DetectableObjectReaction : MonoBehaviour
{
    [SerializeField] private Color _colorReaction;
    [SerializeField] private Renderer _renderer;

    private IDetectableObject _detectableObject;
    private Color _colorByDefault;
    private Material _material;

    private void Awake()
    {
        _detectableObject = GetComponent<IDetectableObject>();

        _material = _renderer.material;

        _colorByDefault = _material.color;
    }

    private void OnEnable()
    {
        _detectableObject.OnGameObjectDetectedEvent += OnGameObjectDetect;
        _detectableObject.OnGameObjectDetectionReleasedEvent += OnGameObjectDetionReleased;
    }

    private void OnDisable()
    {
        _detectableObject.OnGameObjectDetectedEvent -= OnGameObjectDetect;
        _detectableObject.OnGameObjectDetectionReleasedEvent -= OnGameObjectDetionReleased;
    }

    private void OnGameObjectDetect(GameObject source, GameObject detectedObject)
    {
        SetColor(_colorReaction);
    }

    private void OnGameObjectDetionReleased(GameObject source, GameObject detectedObject)
    {
        SetColor(_colorByDefault);
    }

    private void SetColor(Color color)
    {
        _material.SetColor("_Color", color);
    }
}
