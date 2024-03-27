using System;
using UnityEngine;
using UnityEngine.UI;

public class StartGameMenu : MonoBehaviour, IPanel
{
    public Button startGameBtn;
    
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    
}
