public class StrengthPowerUp : PowerUp
{
    protected override void ApplyEffect(Player player)
    {
        int original = player.Stats.Damage;
        int extraPercent = (int)(original * (powerUpData.amount / 100f));
        
        player.ApplyEffect("Strength", extraPercent, powerUpData.duration);
    }

    protected override void LocalUpdate()
    {
        
    }
}