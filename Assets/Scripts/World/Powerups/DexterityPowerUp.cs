public class DexterityPowerUp : PowerUp
{
    protected override void ApplyEffect(Player player)
    {
        int original = player.Stats.Velocity;
        int extraPercent = (int)(original * (powerUpData.amount / 100f));
        
        player.ApplyEffect("Dexterity", extraPercent, powerUpData.duration);
    }

    protected override void LocalUpdate()
    {
        
    }

}