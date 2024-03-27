using UnityEngine;
using UnityEngine.UI;

public class GameOverWindow : MonoBehaviour, IPanel
{
    public Button restartGameBtn;
    
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
