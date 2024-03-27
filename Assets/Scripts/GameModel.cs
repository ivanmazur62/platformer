using UnityEngine;

public class GameModel
{
    public EntityStats PlayerStats = new(50, 10, 5);

    private const string CoinsKey = "Coins";
    private const string VitalityKey = "Vitality";
    private const string StrengthKey = "Strength";
    private const string DexterityKey = "Dexterity";

    public void SavePlayerStats()
    {
        PlayerPrefs.SetInt(CoinsKey, PlayerStats.Coins);
        PlayerPrefs.SetInt(VitalityKey, PlayerStats.Vitality);
        PlayerPrefs.SetInt(StrengthKey, PlayerStats.Strength);
        PlayerPrefs.SetInt(DexterityKey, PlayerStats.Dexterity);
        
        PlayerPrefs.Save();
    }
    
    public void LoadPlayerStats()
    {
        PlayerStats.Coins = PlayerPrefs.GetInt(CoinsKey, 1000);
        PlayerStats.SetMainStats(PlayerPrefs.GetInt(VitalityKey, 0), 
            PlayerPrefs.GetInt(StrengthKey, 0),
            PlayerPrefs.GetInt(DexterityKey, 0));
    }
}