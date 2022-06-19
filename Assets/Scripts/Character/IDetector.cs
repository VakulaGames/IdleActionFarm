using UnityEngine;

public delegate void ObjectDetectedHandler(GameObject source, GameObject detectedObject);

public interface IDetector
{
    public event ObjectDetectedHandler OnGameObjectDetectedEvent;
    public event ObjectDetectedHandler OnGameObjectDetectionReleasedEvent;

    public void Detect(IDetectableObject detectableObject);
    public void ReleaseDetection(IDetectableObject detectedObject);
}
