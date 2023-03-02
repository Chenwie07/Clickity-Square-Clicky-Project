using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Attack Game Event")]
public class AttackEvent : ScriptableObject
{
    private List<AttackEventListener> _observers = new List<AttackEventListener>();
    internal void RegisterObserver(AttackEventListener observer)
    {
        _observers.Add(observer);
    }

    internal void UnregisterObserver(AttackEventListener observer)
    {
        _observers.Remove(observer);
    }

    public void Occurred(int dps, string element)
    {
        foreach (var observer in _observers)
        {
            observer.OnEventOccurred(dps, element);
        }
    }
}
