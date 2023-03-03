using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // a player can attack so they need the event. 
    [SerializeField] AttackEvent @OnDamageEnemy;
    [SerializeField] WeaponData equippedWeapon;
    [SerializeField] WeaponEvent onWeaponSwap;

    private AudioSource audioPlayer;
    private void Awake()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    public void DealDamage()
    {
        OnDamageEnemy.Occurred(equippedWeapon.WeaponDamage, equippedWeapon._element.ToString());
        audioPlayer.PlayOneShot(equippedWeapon.WeaponSfx);
    }

    public void SwapWeapon(WeaponData weapon)
    {
        // changed with default on Click event on Buttons
        equippedWeapon = weapon;
        onWeaponSwap.Occurred(weapon);
    }
}
