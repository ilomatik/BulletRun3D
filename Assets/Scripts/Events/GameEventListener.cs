using Power;
using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent Event;
        public UnityEvent Response;
        public UnityEvent<SpecialPower> ResponseSpecialPower;

        private void OnEnable()
        {
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            Response.Invoke();
        }

        public void OnEventRaisedSpecialPower(SpecialPower responseSpecialPower)
        {
            ResponseSpecialPower.Invoke(responseSpecialPower);
        }
    }
}