using UnityEngine;

public abstract class PowerUp : WorldObject
{
    public PowerUpData powerUpData;
    
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == GlobalSettings.PlayerLayer)
        {
            ApplyEffect(other.gameObject.GetComponent<Player>());
            Destroy(gameObject);
        }
    }

    protected abstract void ApplyEffect(Player player);
}
