using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon Data")]
public class WeaponData : ScriptableObject
{
    [SerializeField] string _weaponName;

    // To charge up other weapons, you must gather energy with the neutral first and then unlock the element to use. 
    // Learn how to make getters for private enums (encapsulation of enums). 
    public enum WeaponElement
    {
       Air, Water, Earth, Fire, Light, Dark, Fallen, Holy
    }
    [SerializeField] WeaponElement _weaponElement;

    [SerializeField] int _weaponDamage;
    [SerializeField, Tooltip("Set Weapon Portrait")] Sprite _weaponPortrait;

    #region Setting up Getters for Properties

    public string WeaponName => _weaponName; 
    public int WeaponDamage => _weaponDamage;
    public Sprite WeaponPortrait => _weaponPortrait;
    public WeaponElement _element => _weaponElement;

    #endregion
}
