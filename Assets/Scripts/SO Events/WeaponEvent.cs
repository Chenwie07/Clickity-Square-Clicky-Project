using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Weapon Event")]
public class WeaponEvent : ScriptableObject
{
    private List<WeaponEventListener> _observers = new List<WeaponEventListener>();
    internal void RegisterObserver(WeaponEventListener observer)
    {
        _observers.Add(observer);
    }

    internal void UnregisterObserver(WeaponEventListener observer)
    {
        _observers.Remove(observer);
    }

    public void Occurred(WeaponData weapon)
    {
        foreach (var observer in _observers)
        {
            observer.OnEventOccurred(weapon);
        }
    }
}
