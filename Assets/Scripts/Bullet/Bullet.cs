using System.Threading.Tasks;
using UnityEngine;

namespace Bullet
{
    public class Bullet : MonoBehaviour
    {
        private Rigidbody rb;
        
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void AddForceToBullet(Vector3 direction, float speed)
        {
            rb.Sleep();
            rb.AddForce(direction * speed);
            SetDeActiveBullet();
        }

        private async void SetDeActiveBullet()
        {
            await Task.Delay(5000);
            
            gameObject.SetActive(false);
        }
    }
}