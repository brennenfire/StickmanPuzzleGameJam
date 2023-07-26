using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField] UnityEvent unityEvent;
    [SerializeField] GameEvent gameEvent;

    void Awake()
    {
        gameEvent.Register(this);    
    }

    void OnDisable()
    {
        gameEvent.Deregister(this);    
    }

    public void RaiseEvent()
    {
        unityEvent.Invoke();
    }
}
