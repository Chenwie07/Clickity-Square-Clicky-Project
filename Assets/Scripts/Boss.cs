using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // the boss will get it's own data, which will then take cause/receive damage. 
    [SerializeField] BossData _bossData;
    [SerializeField] GameEvent @OnAttacked;
    [SerializeField] IntGameEvent @OnHealthImpact;
    [SerializeField] GameEvent @OnBossKilled;
    [SerializeField] IntGameEvent @onFullDamage; 


    #region Setting up some Prerequisite Stats

    private string bossWeakness;
    private string bossResistance;
    private int bossHP;

    #endregion

    private void Start()
    {
        InitializeBoss(_bossData); 
    }

    void InitializeBoss(BossData bData)
    {
        GetComponent<SpriteRenderer>().color = bData.BossColor;
        bossWeakness = bData.BossWeakeness.ToString();
        bossResistance = bData.BossAttribute.ToString();
        bossHP = bData.BossHealth;
    }
    public void GetBossData(LevelData data)
    {
        _bossData = data.Boss;
        InitializeBoss(_bossData); 
    }

    public void ReceiveDamage(int damageDone, string element)
    {
        int bonusDamage = 0;
        // depending on the element compared with the boss data, the damage can either heal or damage the boss with a weakness bonus. 
        if (element == bossWeakness)
        {
            bonusDamage = Mathf.RoundToInt((float)(damageDone * .5) * Random.Range(1.5f, 3));  // our logic for dealing bonus damage. 
            print("Bonus Damage caused: " + bonusDamage);
        }
        else if (element == bossResistance)
        {
            CalculateDamage(-damageDone / 2);  // boss absorbs what he's resistant to. 
            return;
        }
        onFullDamage.Occurred(damageDone + bonusDamage); 
        CalculateDamage(damageDone + bonusDamage);
    }

    private void CalculateDamage(int v)
    {
        bossHP -= v;
        OnHealthImpact.Occurred(bossHP);
        if (bossHP <= 0)
        {
            bossHP = 0;
            OnBossKilled.Occurred();
        }
    }

    private void OnMouseDown()
    {
        OnAttacked.Occurred(); // the player will then deal damage and inturn, raise the ondamage done event using equipped weapon. 
    }
}
