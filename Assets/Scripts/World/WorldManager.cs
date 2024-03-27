using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour, IPanel
{
    [SerializeField] private List<EnemySpawner> enemySpawners;

    private float _lastSpawnPositionX;

    public void StartGame()
    {
        foreach (var item in enemySpawners)
        {
            item.Initialize();
        }
    }
    
    private void ClearLevel()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
