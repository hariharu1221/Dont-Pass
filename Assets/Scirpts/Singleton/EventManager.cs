using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : Singleton<EventManager>
{
    private Dictionary<string, GameEvent> EventPair = new Dictionary<string, GameEvent>();
    private Dictionary<string, GameEvent<int>> IntEventPair = new Dictionary<string, GameEvent<int>>();

    private void Awake()
    {
        SetInstance(); 
    }

    public void RegisterListener(Action listener, string key)
    {
        try
        {
            if (EventPair.ContainsKey(key))
                EventPair[key].UnRegisterListener(listener);
            else
                throw new Exception("Key value does not exist!");
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }

    public void RegisterListener<T>(Action<T> listener, string key)
    {
        if (typeof(T) == typeof(int))
        {
            object obj = IntEventPair;
            RegisterListener(listener, key, ref obj);
        }
    }

    public void RegisterListener<T>(Action<T> listener, string key, ref object eventPair)
    {
        try
        {
            if (EventPair.ContainsKey(key))
                (eventPair as Dictionary<string, GameEvent<T>>)[key].RegisterListener(listener);
            else
                throw new Exception("Key value does not exist!");
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }

    public void UnRegisterListener(Action listener, string key)
    {
        try
        {
            if (EventPair.ContainsKey(key))
                EventPair[key].UnRegisterListener(listener);
            else
                throw new Exception("Key value does not exist!");
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }

    public void UnRegisterListener<T>(Action<T> listener, string key)
    {
        if (typeof(T) == typeof(int))
        {
            object obj = IntEventPair;
            UnRegisterListener(listener, key, ref obj);
        }
    }

    public void UnRegisterListener<T>(Action<T> listener, string key, ref object eventPair)
    {
        try
        {
            if (EventPair.ContainsKey(key))
                (eventPair as Dictionary<string, GameEvent<T>>)[key].UnRegisterListener(listener);
            else
                throw new Exception("Key value does not exist!");
        }
        catch (NullReferenceException ex)
        {
            Debug.LogError(ex.Message);
        }
    }
    


    //public void UnRegisterListener<T>(Action<T> listener, string key, ref Dictionary<string, GameEvent<T>> eventPair) 
    //{
    //    try
    //    {
    //        if (EventPair.ContainsKey(key))
    //            eventPair[key].UnRegisterListener(listener);
    //        else
    //            throw new Exception("Key value does not exist!");
    //    }
    //    catch (NullReferenceException ex)
    //    {
    //        Debug.LogError(ex.Message);
    //    }
    //}

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
        try
        {
            onEvent -= listener;
        }
        catch
        {
            throw new Exception("function does not exist in event!");
        }
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
        try
        {
            onEvent -= listener;
        }
        catch
        {
            throw new Exception("function does not exist in event!");
        }
    }

    public void BroadcastEvent()
    {
        onEvent?.Invoke();
    }
}

public enum EventType
{
    Normal,
    Quest
}