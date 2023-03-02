using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Int Game Event")]
public class IntGameEvent : ScriptableObject
{
    private List<IntEventListener> _observers = new List<IntEventListener>();
    internal void RegisterObserver(IntEventListener observer)
    {
        _observers.Add(observer);
    }

    internal void UnregisterObserver(IntEventListener observer)
    {
        _observers.Remove(observer);
    }

    public void Occurred(int v)
    {
        foreach (var observer in _observers)
        {
            observer.OnEventOccurred(v);
        }
    }
}
