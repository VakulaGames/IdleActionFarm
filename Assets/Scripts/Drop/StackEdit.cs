using UnityEngine;

[CreateAssetMenu(fileName = "StacktEdit", menuName = "ScriptableObjects/StackEdit")]
public class StackEdit : ScriptableObject
{
    [Range(0, 100)] public float harvestDuration;
    [Range(0, 100)] public float sellDuration;
}
