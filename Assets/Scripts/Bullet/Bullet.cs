using UnityEngine;

namespace Bullet
{
    public class Bullet : MonoBehaviour
    {
        public void AddForceToBullet(Vector3 direction, float speed)
        {
            GetComponent<Rigidbody>().Sleep();
            GetComponent<Rigidbody>().AddForce(direction * speed);
            Destroy(gameObject, 5f);
        }
    }
}