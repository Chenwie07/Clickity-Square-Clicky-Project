using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // a player can attack so they need the event. 
    [SerializeField] AttackEvent @OnDamageEnemy;  
    [SerializeField] WeaponData equippedWeapon;
    [SerializeField] WeaponEvent onWeaponSwap; 

    public void DealDamage()
    {
        print("The Player attacks, causing weapon damage: " + equippedWeapon.WeaponDamage + " Element: " + equippedWeapon._element);
        OnDamageEnemy.Occurred(equippedWeapon.WeaponDamage, equippedWeapon._element.ToString()); 
    }

    public void SwapWeapon(WeaponData weapon)
    {
        // changed with default on Click event on Buttons
        equippedWeapon = weapon;
        onWeaponSwap.Occurred(weapon); 
    }
}
