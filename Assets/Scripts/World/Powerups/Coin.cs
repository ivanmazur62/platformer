using UnityEngine;

public class Coin : PowerUp
{
    protected override void ApplyEffect(Player player)
    {
        player.AddCoins(powerUpData.amount);
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == GlobalSettings.PlayerLayer)
        {
            ApplyEffect(other.gameObject.GetComponent<Player>());
            Destroy(gameObject);
        }
    }

    protected override void LocalUpdate()
    {
        
    }
}