using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class WeaponUnityEvent : UnityEvent<WeaponData> { }
public class WeaponEventListener : MonoBehaviour
{
    public WeaponEvent gameEvent;
    public WeaponUnityEvent weaponEventResponse = new WeaponUnityEvent();

    private void OnEnable()
    {
        gameEvent.RegisterObserver(this);
    }
    private void OnDisable()
    {
        gameEvent.UnregisterObserver(this);
    }

    internal void OnEventOccurred(WeaponData value)
    {
        weaponEventResponse.Invoke(value);
    }
}
