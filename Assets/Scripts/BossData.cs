using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boss", menuName ="Boss Data")]
public class BossData : ScriptableObject
{
    [SerializeField] string _bossName; 
    [SerializeField] Sprite _bossPortrait;

    [SerializeField] Color _bossColor; 
    
    public enum Element
    {
        Air, Earth, Water, Fire, Light, Dark, Fallen, Holy
    }

    [SerializeField, Tooltip("Choose Boss Elemental Attribute")] Element _bossElement;
    [SerializeField, Tooltip("Set Health")] int _bossHealth;
    [SerializeField, Tooltip("Choose Boss Weakness")] Element _bossWeakness;

    #region Getters for Boss Properties 

    public string BossName => _bossName;
    public int BossHealth => _bossHealth;
    public Element BossAttribute => _bossElement;
    public Element BossWeakeness => _bossWeakness;

    public Color BossColor => _bossColor;
    public Sprite BossPortrait => _bossPortrait; 


    #endregion 

}
