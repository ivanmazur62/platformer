using System;
using System.Collections;
using UnityEngine;

public class HudBar : MonoBehaviour, IPanel
{
    [SerializeField] private ValueField level;
    [SerializeField] private ValueField health;
    [SerializeField] private ValueField damage;
    [SerializeField] private ValueField velocity;
    
    [SerializeField] private ValueField velocityTimer;
    [SerializeField] private ValueField damageTimer;
    
    [SerializeField] private ValueField coins;
    
    public event Action OnStatShow;

    private Coroutine _velocityTimerCoroutine;
    private Coroutine _damageTimerCoroutine;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnStatShow?.Invoke();
        }
    }

    public void SetupStats()
    {
        var playerStats = GameController.Instance.View.Model.PlayerStats;
        
        level.SetValue(playerStats.Level);
        coins.SetValue(playerStats.Coins);
        health.SetValue(playerStats.Health);
        damage.SetValue(playerStats.Damage);
        velocity.SetValue(playerStats.Velocity);
    }

    public void Show()
    {
        SetupStats();
        gameObject.SetActive(true);
        GameController.Instance.View.player.OnPowerUpStarted += HandlePowerUpStarted;
        GameController.Instance.View.player.OnPowerUpEnded += HandlePowerUpEnded;
    }

    public void Hide()
    {
        GameController.Instance.View.player.OnPowerUpStarted -= HandlePowerUpStarted;
        GameController.Instance.View.player.OnPowerUpEnded -= HandlePowerUpEnded;
        gameObject.SetActive(false);
    }
    
    private IEnumerator UpdateTimer(ValueField timerField, float duration, string type)
    {
        int timeRemaining = Mathf.CeilToInt(duration);
        timerField.SetValue(timeRemaining);

        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1);
            timeRemaining--;
            timerField.SetValue(timeRemaining);
        }

        timerField.gameObject.SetActive(false);
        
        if (type == "Dexterity")
        {
            _velocityTimerCoroutine = null;
        }
        else if (type == "Strength")
        {
            _damageTimerCoroutine = null;
        }
    }
    
    private void HandlePowerUpStarted(string type, float duration)
    {
        if (type == "Dexterity")
        {
            velocityTimer.gameObject.SetActive(true);
        
            if (_velocityTimerCoroutine != null)
            {
                StopCoroutine(_velocityTimerCoroutine);
            }

            _velocityTimerCoroutine = StartCoroutine(UpdateTimer(velocityTimer, duration, type));
        }
        else if (type == "Strength")
        {
            damageTimer.gameObject.SetActive(true);
        
            if (_damageTimerCoroutine != null)
            {
                StopCoroutine(_damageTimerCoroutine);
            }
        
            _damageTimerCoroutine = StartCoroutine(UpdateTimer(damageTimer, duration, type));
        }
    }

    private void HandlePowerUpEnded(string type)
    {
        switch (type)
        {
            case "Dexterity":
                velocityTimer.gameObject.SetActive(false);
                break;
            case "Strength":
                damageTimer.gameObject.SetActive(false);
                break;
        }
    }
}
