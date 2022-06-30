using System.Collections.Generic;
using Power;
using UnityEngine;

namespace Events
{
    [CreateAssetMenu(fileName = "Game Event", menuName = "Events/Game Event")]
    public class GameEvent : ScriptableObject
    {
        private List<GameEventListener> listeners = new List<GameEventListener>();

        public void Raise()
        {
            for (var i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised();
            }
        }

        public void RaiseSpecialPower(SpecialPower raisedSpecialPower)
        {
            for (var i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaisedSpecialPower(raisedSpecialPower);
            }
        }

        public void RaisePowerType(PowerType powerType, float powerAmount)
        {
            for (var i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaisedPowerValues(powerType, powerAmount);
            }
        }

        public void RegisterListener(GameEventListener listener)
        {
            listeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}