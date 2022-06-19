using UnityEngine;

public interface IDetectableObject
{
    public event ObjectDetectedHandler OnGameObjectDetectedEvent;
    public event ObjectDetectedHandler OnGameObjectDetectionReleasedEvent;

    public GameObject gameObject { get; }

    public void Detected(GameObject detectionSource);
    public void DetectionReleased(GameObject detectionSource);
}
