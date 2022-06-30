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
        public UnityEvent<float> ResponseFloat;
        public UnityEvent<PowerType, float> ResponsePowerValues;

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

        public void OnEventRaisedFloat(float responseFloat)
        {
            ResponseFloat.Invoke(responseFloat);
        }

        public void OnEventRaisedPowerValues(PowerType powerType, float powerAmount)
        {
            ResponsePowerValues.Invoke(powerType, powerAmount);
        }
    }
}