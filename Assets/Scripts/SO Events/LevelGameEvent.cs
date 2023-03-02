using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level Event")]
public class LevelGameEvent : ScriptableObject
{
    private List<LevelEventListener> _observers = new List<LevelEventListener>();
    internal void RegisterObserver(LevelEventListener observer)
    {
        _observers.Add(observer);
    }

    internal void UnregisterObserver(LevelEventListener observer)
    {
        _observers.Remove(observer);
    }

    public void Occurred(LevelData level)
    {
        foreach (var observer in _observers)
        {
            observer.OnEventOccurred(level);
        }
    }
}
