using UnityEngine;

public class DropAnimation : MonoBehaviour
{
    [SerializeField] private Collider _collider;

    private void Awake()
    {
        _collider.enabled = false;
    }

    public void ActiveCollider()
    {
        _collider.enabled=true;
    }
}
