using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class AttackUnityEvent : UnityEvent<int, string> { }
public class AttackEventListener : MonoBehaviour
{
    public AttackEvent gameEvent;
    public AttackUnityEvent _attackEventResponse = new AttackUnityEvent();

    private void OnEnable()
    {
        gameEvent.RegisterObserver(this);
    }
    private void OnDisable()
    {
        gameEvent.UnregisterObserver(this);
    }

    internal void OnEventOccurred(int value, string element)
    {
        _attackEventResponse.Invoke(value, element);
    }
}
