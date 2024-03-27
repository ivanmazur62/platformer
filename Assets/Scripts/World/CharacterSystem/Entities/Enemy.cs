using System.Collections;
using UnityEngine;

public class Enemy : EntityBase
{
    [SerializeField] private GameObject[] powerUps;
    [SerializeField] private float minDropTime = 5f;
    [SerializeField] private float maxDropTime = 15f;

    private Coroutine _dropPowerUp;
    protected override void Awake()
    {
        base.Awake();

        var chaseSpeed = 4f;
        var detectionRadius = 5f;
        SetMovementStrategy(new EnemyMovementStrategy(transform, chaseSpeed, detectionRadius));
        SetAttackStrategy(new EnemyAttackStrategy(transform));
    }

    public override void Initialize(int vitality, int strength, int dexterity)
    {
        base.Initialize(vitality, strength, dexterity);
        Stats.Coins = 200;
        _dropPowerUp = StartCoroutine(DropPowerUpRoutine());
    }
    private IEnumerator DropPowerUpRoutine()
    {
        yield return new WaitForSeconds(Random.Range(minDropTime, maxDropTime));

        DropPowerUp();
    }

    private void DropPowerUp()
    {
        if (powerUps.Length == 0) return;

        int index = Random.Range(0, powerUps.Length);
        GameObject powerUpToDrop = powerUps[index];

        if (powerUpToDrop != null)
        {
            Instantiate(powerUpToDrop, transform.position + new Vector3(0, 0.4f, 0), Quaternion.identity);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == GlobalSettings.PlayerLayer)
        {
            AttackStrategy.Attack(Stats.Damage);
        }
    }

    public override void Die()
    {
        StopCoroutine(_dropPowerUp);
        base.Die();
        Destroy(gameObject);
    }
}