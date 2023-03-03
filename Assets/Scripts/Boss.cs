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
    [SerializeField] ParticleSystem bossDamageEffect;


    #region Setting up some Prerequisite Stats

    private string bossWeakness;
    private string bossResistance;
    private int bossHP;

    #endregion

    private void Start()
    {
        InitializeBoss(_bossData); 
    }

    void InitializeBoss(BossData _bData)
    {
        GetComponent<SpriteRenderer>().color = _bData.BossColor;
        bossWeakness = _bData.BossWeakeness.ToString();
        bossResistance = _bData.BossAttribute.ToString();
        bossHP = _bData.BossHealth;
        //bossDamageEffect = _bossData.BossDamageEffect;
    }
    public void GetBossData(LevelData _data)
    {
        _bossData = _data.Boss;
        InitializeBoss(_bossData); 
    }

    public void ReceiveDamage(int _damageDone, string _element)
    {
        int _bonusDamage = 0;
        // depending on the element compared with the boss data, the damage can either heal or damage the boss with a weakness bonus. 
        if (_element == bossWeakness)
        {
            _bonusDamage = Mathf.RoundToInt((float)(_damageDone * .5) * Random.Range(1.5f, 3));  // our logic for dealing bonus damage. 
        }
        else if (_element == bossResistance)
        {
            CalculateDamage(-_damageDone / 2);  // boss absorbs what he's resistant to. 
            return;
        }
        onFullDamage.Occurred(_damageDone + _bonusDamage); 
        CalculateDamage(_damageDone + _bonusDamage);
    }

    private void CalculateDamage(int _v)
    {
        bossHP -= _v;
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
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        bossDamageEffect.transform.position = new Vector3(pos.x, pos.y, 0f); 
        bossDamageEffect.Play();
    }
}
