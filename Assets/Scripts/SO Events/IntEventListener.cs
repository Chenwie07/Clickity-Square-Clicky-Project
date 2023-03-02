using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class IntUnityEvent : UnityEvent<int> { }

public class IntEventListener : MonoBehaviour
{
    public IntGameEvent gameEvent;
    public IntUnityEvent _intEventResponse = new IntUnityEvent();

    private void OnEnable()
    {
        gameEvent.RegisterObserver(this);
    }
    private void OnDisable()
    {
        gameEvent.UnregisterObserver(this);
    }

    internal void OnEventOccurred(int value)
    {
        _intEventResponse.Invoke(value);
    }
}
