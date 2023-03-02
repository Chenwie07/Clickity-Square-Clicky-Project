using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VoidEventListener : MonoBehaviour
{
    public GameEvent gameEvent;
    public UnityEvent _eventResponse;

    private void OnEnable()
    {
        gameEvent.RegisterObserver(this); 
    }
    private void OnDisable()
    {
        gameEvent.UnregisterObserver(this); 
    }

    internal void OnEventOccurred()
    {
        _eventResponse.Invoke();
    }
}
