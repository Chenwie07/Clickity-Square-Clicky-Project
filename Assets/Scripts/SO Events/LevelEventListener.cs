using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class LevelUnityEvent : UnityEvent<LevelData> { }
public class LevelEventListener : MonoBehaviour
{
    public LevelGameEvent gameEvent;
    public LevelUnityEvent levelEventResponse = new LevelUnityEvent();

    private void OnEnable()
    {
        gameEvent.RegisterObserver(this);
    }
    private void OnDisable()
    {
        gameEvent.UnregisterObserver(this);
    }

    internal void OnEventOccurred(LevelData value)
    {
        levelEventResponse.Invoke(value);
    }
}
