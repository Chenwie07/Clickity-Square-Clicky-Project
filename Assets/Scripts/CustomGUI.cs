using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomGUI : MonoBehaviour
{
    [Header("Boss Panel Controls")]
    [SerializeField] LevelData currentLevelData;
    [SerializeField] Slider bossHealth;
    [SerializeField] TextMeshProUGUI bossName;
    [SerializeField] WeaponData currentWeaponData;
    [SerializeField] Image bossPortrait;
    [SerializeField] TextMeshProUGUI bossElement;
    [SerializeField] TextMeshProUGUI damageDone;
    [SerializeField] TextMeshProUGUI coinCollected;

    private int coins = 0; 


    [Header("Level Timer")]
    [SerializeField] Slider levelTimer;
    private float totalLevelTime;

    [Header("Victory Panel")]
    [SerializeField] GameObject victoryPanel;

    [Header("Lost Panel")]
    [SerializeField] GameObject losePanel;

    [SerializeField] TextMeshProUGUI LevelText;
    [SerializeField] TextMeshProUGUI weaponText;
    private int bossCurrentHP;
    private void Start()
    {
        bossCurrentHP = currentLevelData.Boss.BossHealth;
        UpdateBossPanelInfo();
        totalLevelTime = currentLevelData.LevelTime;
        UpdateWeaponDisplay(currentWeaponData);
    }

    public void GetLevelData(LevelData _newLevel)
    {
        currentLevelData = _newLevel;
        // Initialize
        UpdateHealthDisplay(currentLevelData.Boss.BossHealth);
        UpdateBossPanelInfo();
        LevelText.SetText("Level: " + _newLevel.Level.ToString());
        totalLevelTime = currentLevelData.LevelTime;

    }

    public void UpdatePlayerCoin(int _coinEarned)
    {
        coins += _coinEarned;
        coinCollected.SetText(coins.ToString()); 
    }
    public void UpdateDamageLog(int _dmg)
    {
        damageDone.SetText("Damage: " + _dmg); 
    }

    private void UpdateBossPanelInfo()
    {
        bossName.SetText(currentLevelData.Boss.BossName);
        bossPortrait.sprite = currentLevelData.Boss.BossPortrait;
        bossElement.SetText("Boss Element: " + currentLevelData.Boss.BossAttribute.ToString());
    }

    public void UpdateHealthDisplay(int _newHealth)
    {
        if (_newHealth <= 0)
            bossCurrentHP = 0;
        else if (_newHealth > currentLevelData.Boss.BossHealth)
            bossCurrentHP = currentLevelData.Boss.BossHealth;

        bossCurrentHP = _newHealth;
        bossHealth.value = (float)bossCurrentHP / (float)currentLevelData.Boss.BossHealth;
    }

    public void UpdateTimer(int _newTime)
    {
        levelTimer.value = (totalLevelTime - _newTime) / totalLevelTime;
    }

    public void UpdateWeaponDisplay(WeaponData _weapon)
    {
        var currentWeaponData = _weapon;
        weaponText.SetText("Equipped: " + currentWeaponData.WeaponName + " \nDPS: " + currentWeaponData.WeaponDamage + " Element: " + currentWeaponData._element);
    }

    public void VictoryPanel()
    {
        victoryPanel.SetActive(true);
    }
    public void FailurePanel()
    {
        losePanel.SetActive(true);
    }
}
