using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGameEvent<T> : ScriptableObject
{
    private readonly HashSet<IGameEventListener<T>> eventListeners = new HashSet<IGameEventListener<T>>();

    public void Raise(T item)
    {
        foreach (IGameEventListener<T> listener in eventListeners)
        {
            listener.OnEventRaised(item);
        }
    }

    public void RegisterListener(IGameEventListener<T> listener)
    {
        eventListeners.Add(listener);
    }

    public void DeregisterListener(IGameEventListener<T> listener)
    {
        eventListeners.Remove(listener);
    }
}
