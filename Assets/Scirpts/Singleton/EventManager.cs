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

    //�Ϲ� �̺�Ʈ �Լ� �߰�
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

    //�Ű������� �����ϴ� �̺�Ʈ �Լ� �߰�
    public void RegisterListener<T>(Action<T> listener, string key)
    {
        if (typeof(T) == typeof(int))
        {
            Action<int> listen = listener as Action<int>;
            RegisterListener(listen, key, ref IntEventPair);
        }
        else if (typeof(T) == typeof(float))
        {
            Action<float> action = listener as Action<float>;
            RegisterListener(action, key, ref FloatEventPair);
        }
        else
        {
            throw new Exception("type of T does not exist");
        }
    } 

    //�ݺ��Ǵ� ���� �Լ�ȭ
    private void RegisterListener<T>(Action<T> listener, string key, ref Dictionary<string, GameEvent<T>> eventPair) 
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
            UnRegisterListener(action, key, ref IntEventPair);
        }
        else if (typeof(T) == typeof(float))
        {
            Action<float> action = listener as Action<float>;
            UnRegisterListener(action, key, ref FloatEventPair);
        }
        else
        {
            throw new Exception("type of T does not exist");
        }
    }

    private void UnRegisterListener<T>(Action<T> listener, string key, ref Dictionary<string, GameEvent<T>> eventPair)
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

    public void AddEvent(ref GameEvent gameEvent)
    {
        EventPair.Add(gameEvent.key, gameEvent);
    }

    public void RemoveEvent(ref GameEvent gameEvent)
    {
        EventPair.Remove(gameEvent.key);
    }
}

public class GameEvent<T>
{
    private event Action<T> onEvent;
    public string key;

    public void RegisterListener(Action<T> listener) //�̺�Ʈ�� �Լ� �߰�
    {
        onEvent += listener;
    }

    public void UnRegisterListener(Action<T> listener) //�̺�Ʈ���� �Լ� ����
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

    public void BroadcastEvent(T eventData) //�̺�Ʈ ����
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