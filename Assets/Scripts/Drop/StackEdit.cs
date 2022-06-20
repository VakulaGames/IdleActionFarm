using UnityEngine;

[CreateAssetMenu(fileName = "StacktEdit", menuName = "ScriptableObjects/StackEdit")]
public class StackEdit : ScriptableObject
{
    [Range(0, 100)] public float sellDuration;
    [Range(0, 100)] public float wiggleDuration;
    [Range(0, 100)] public float adgelWiggle;
    [Range(1, 40)] public int stackMaxCount;
    [Range(0, 100)] public float flyCoinDuration;
}
