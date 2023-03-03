using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boss", menuName ="Boss Data")]
public class BossData : ScriptableObject
{
    [SerializeField] string bossName; 
    [SerializeField] Sprite bossPortrait;

    [SerializeField] Color bossColor;
    [SerializeField] ParticleSystem bossDamageParticle; 
    
    public enum Element
    {
        Air, Earth, Water, Fire, Light, Dark, Fallen, Holy
    }

    [SerializeField, Tooltip("Choose Boss Elemental Attribute")] Element bossElement;
    [SerializeField, Tooltip("Set Health")] int bossHealth;
    [SerializeField, Tooltip("Choose Boss Weakness")] Element bossWeakness;

    #region Getters for Boss Properties 
    public string BossName => bossName;
    public int BossHealth => bossHealth;
    public Element BossAttribute => bossElement;
    public Element BossWeakeness => bossWeakness;
    public Color BossColor => bossColor;
    public Sprite BossPortrait => bossPortrait;
    public ParticleSystem BossDamageEffect => bossDamageParticle; 
    #endregion 

}
