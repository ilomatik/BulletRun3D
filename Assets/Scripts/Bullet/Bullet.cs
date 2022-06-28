using System.Threading.Tasks;
using UnityEngine;

namespace Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float maxSpeed;
        [SerializeField] private int damage;
        [SerializeField] private int maxDamage;

        public float Speed
        {
            get => speed;
            set
            {
                speed = value;

                if (speed > maxSpeed)
                {
                    speed = maxSpeed;
                }
            }
        }

        public int Damage
        {
            get => damage;
            set
            {
                damage = value;

                if (damage > maxDamage)
                {
                    damage = maxDamage;
                }
            }
        }

        public float GetBulletSpeed()
        {
            return Speed;
        }

        public int GetBulletDamage()
        {
            return Damage;
        }

        public void AddForceToBullet(Vector3 direction)
        {
            GetComponent<Rigidbody>().Sleep();
            GetComponent<Rigidbody>().AddForce(direction * speed);
            DeactiveBullet();
        }

        private async void DeactiveBullet()
        {
            await Task.Delay(5000);

            gameObject.SetActive(false);
        }
    }
}