using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level Data")]

public class LevelData : ScriptableObject
{
    // what makes up our level. Time, Background (OST optional), and BossData? 
    [SerializeField] int level;
    [SerializeField] int levelTime; 
    [SerializeField] Sprite bg;
    [SerializeField] BossData boss;

    #region GETTING PROPERTIES 
    public int Level => level;
    public int LevelTime => levelTime; 
    public Sprite Background => bg;
    public BossData Boss => boss;
    #endregion
}
