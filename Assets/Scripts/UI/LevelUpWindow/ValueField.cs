using TMPro;
using UnityEngine;

public class ValueField : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI value;

    protected int CurrentLevel;
    protected int TempLevel;
    

    public virtual void SetValue(int initialLevel)
    {
        CurrentLevel = initialLevel;
        TempLevel = initialLevel;
        UpdateUI();
    }
    
    public virtual void UpdateLevel(int value)
    {
        TempLevel = value;
        UpdateUI();
    }

    protected virtual void UpdateUI()
    {
        value.text = TempLevel.ToString();
        value.color = TempLevel > CurrentLevel ? Color.blue : Color.black;
    }
}
