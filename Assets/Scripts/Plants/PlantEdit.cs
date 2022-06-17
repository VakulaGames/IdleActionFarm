using UnityEngine;

[CreateAssetMenu(fileName = "PlantEdit", menuName = "ScriptableObjects/PlantEdit")]
public class PlantEdit : ScriptableObject
{
    [Range(0, 100)] public float growingTime;
}
