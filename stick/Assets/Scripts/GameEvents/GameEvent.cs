using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event")]
public class GameEvent : ScriptableObject
{
    HashSet<GameEventListener> gameEventListeners = new HashSet<GameEventListener>();
    
    static HashSet<GameEvent> listenedEvents = new HashSet<GameEvent>();

    public void Register(GameEventListener gameEventListener)
    {
        gameEventListeners.Add(gameEventListener);
        listenedEvents.Add(this);
    }

    public void Deregister(GameEventListener gameEventListener)
    {
        gameEventListeners.Remove(gameEventListener);
        if(gameEventListener!= null )
        {
            listenedEvents.Remove(this);
        }
    }

    [ContextMenu("Invoke")]
    public void Invoke()
    {
        foreach(var gameEventListener in gameEventListeners) 
        {
            gameEventListener.RaiseEvent();
        }
    }

    public static void RaiseEvent(string eventName) 
    {
        foreach(var gameEvent in listenedEvents) 
        {
            if(gameEvent.name == eventName)
            {
                gameEvent.Invoke();
            }
        }
    }
}

