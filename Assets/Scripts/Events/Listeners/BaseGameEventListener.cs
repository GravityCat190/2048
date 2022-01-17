using UnityEngine;
using UnityEngine.Events;

public abstract class BaseGameEventListener<T, E, UER> : MonoBehaviour, IGameEventListener<T> where E : BaseGameEvent<T> where UER : UnityEvent<T>
{
    [SerializeField]
    private E gameEvent;
    [SerializeField]
    private UER unityEventResponse;
    public E GameEvent 
    { 
        get => gameEvent; 
        set => gameEvent = value; 
    }

    private void OnEnable()
    {
        GameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        GameEvent.DeregisterListener(this);
    }

    public void OnEventRaised(T item)
    {
        unityEventResponse.Invoke(item);
    }
}
