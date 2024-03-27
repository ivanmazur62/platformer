using UnityEngine;

public class GlobalSettings
{
    public static readonly int PlayerLayer = LayerMask.NameToLayer("Player");
    public static readonly int PlayerMask = LayerMask.GetMask("Player");
    public static readonly int GroundMask = LayerMask.GetMask("Ground");
    public static readonly int EnemyMask = LayerMask.GetMask("Enemy");
}
