using UnityEngine;

namespace Player
{
    public enum FireType
    {
        Default,
        Triple
    }
    
    public class FireController : MonoBehaviour
    {
        public FireType fireType;
        public bool isDoubleFire;
        public float fireRate;
        public float bulletSpeed;
        [Tooltip("Wait duration between consecutive bullet fire")]
        public float onDoubleFireWaitDuration;
    }
}