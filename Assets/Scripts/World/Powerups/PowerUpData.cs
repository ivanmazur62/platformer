using UnityEngine;

[CreateAssetMenu(fileName = "PowerUpData", menuName = "GameItems/PowerUp Data", order = 0)]
public class PowerUpData : ScriptableObject
{
    public float duration = 20f;
    public int amount = 5;
}