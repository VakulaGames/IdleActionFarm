using UnityEngine;

[CreateAssetMenu(fileName = "PlantEdit", menuName = "ScriptableObjects/PlantEdit")]
public class PlantEdit : ScriptableObject
{
    [Range(0, 100)] public float harvestDuration;
    [Range(0, 100)] public float growingTime;
    [Range(0, 100)] public float finishEffectTime;
    [Range(0, 1000)] public int price;
}
