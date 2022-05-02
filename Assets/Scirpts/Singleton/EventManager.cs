using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : Singleton<EventManager>
{
    private Dictionary<string, GameEvent> EventPair = new Dictionary<string, GameEvent>();
    private Dictionary<string, GameEvent<int>> IntEventPair = new Dictionary<string, GameEvent<int>>();
    private Dictionary<string, GameEvent<float>> FloatEventPair = new Dictionary<string, GameEvent<float>>();

    private void Awake()
    {
        SetInstance(); 
    }

    //일반 이벤트 함수 추가
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

    //매개변수가 존재하는 이벤트 함수 추가
    public void RegisterListener<T>(Action<T> listener, string key)
    {
        if (typeof(T) == typeof(int))
        {
            Action<int> listen = listener as Action<int>;
            RegisterListener(listen, key, IntEventPair);
        }
        else if (typeof(T) == typeof(float))
        {
            Action<float> action = listener as Action<float>;
            RegisterListener(action, key, FloatEventPair);
        }
        else
        {
            throw new Exception("type of T does not exist");
        }
    } 

    //반복되는 문장 함수화
    private void RegisterListener<T>(Action<T> listener, string key, Dictionary<string, GameEvent<T>> eventPair) 
    {
        try
        {
            if (EventPair.ContainsKey(key))
                eventPair[key].RegisterListener(listener);
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
            Action<int> action = listener as Action<int>;
            UnRegisterListener(action, key, IntEventPair);
        }
        else if (typeof(T) == typeof(float))
        {
            Action<float> action = listener as Action<float>;
            UnRegisterListener(action, key, FloatEventPair);
        }
        else
        {
            throw new Exception("type of T does not exist");
        }
    }

    private void UnRegisterListener<T>(Action<T> listener, string key, Dictionary<string, GameEvent<T>> eventPair)
    {
        try
        {
            if (EventPair.ContainsKey(key))
                eventPair[key].UnRegisterListener(listener);
            else
                throw new Exception("Key value does not exist!");
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }

    public void AddEvent(GameEvent gameEvent)
    {
        EventPair.Add(gameEvent.key, gameEvent);
    }

    public void RemoveEvent(GameEvent gameEvent)
    {
        EventPair.Remove(gameEvent.key);
    }
}

public class GameEvent<T>
{
    private event Action<T> onEvent;
    public string key;

    public void RegisterListener(Action<T> listener) //이벤트에 함수 추가
    {
        onEvent += listener;
    }

    public void UnRegisterListener(Action<T> listener) //이벤트에서 함수 제거
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

    public void BroadcastEvent(T eventData) //이벤트 실행
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
