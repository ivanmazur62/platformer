public class HealthPowerUp : PowerUp
{
    protected override void ApplyEffect(Player player)
    {
        int original = player.Stats.Health;
        int extra = (int)(original * (powerUpData.amount / 100f));
        
        player.ModifyHealth(extra);
    }

    protected override void LocalUpdate()
    {
        
    }
}