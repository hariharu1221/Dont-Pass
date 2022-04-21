using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : Singleton<EventManager>
{
    private Dictionary<string, GameEvent> EventPair = new Dictionary<string, GameEvent>();

    public void Awake()
    {
        SetInstance(); 
    }

    public void RegisterListener(Action listener, string key)
    {
        EventPair[key].RegisterListener(listener);
    }

    public void UnRegisterListener(Action listener, string key)
    {
        EventPair[key].UnRegisterListener(listener);
    }

    public void AddEvent(ref GameEvent gameEvent)
    {
        EventPair.Add(gameEvent.key, gameEvent);
    }
}

public class GameEvent<T>
{
    private event Action<T> onEvent;
    public string key;

    public void RegisterListener(Action<T> listener)
    {
        onEvent += listener;
    }

    public void UnRegisterListener(Action<T> listener)
    {
        onEvent -= listener;
    }

    public void BroadcastEvent(T eventData)
    {
        onEvent?.Invoke(eventData);
    }
}

public class GameEvent
{
    private event Action onEvent;
    public string key;

    public void RegisterListener(Action listener)
    {
        onEvent += listener;
    }

    public void UnRegisterListener(Action listener)
    {
        onEvent -= listener;
    }

    public void BroadcastEvent()
    {
        onEvent?.Invoke();
    }
}