using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event", order = 53)]
public class GameEvent : ScriptableObject
{
    private List<VoidEventListener> _observers = new List<VoidEventListener> ();
    internal void RegisterObserver(VoidEventListener observer)
    {
        _observers.Add(observer);
    }

    internal void UnregisterObserver(VoidEventListener observer)
    {
        _observers.Remove(observer);
    }

    public void Occurred()
    {
        foreach (var observer in _observers)
        {
            observer.OnEventOccurred(); 
        }
    }
}
