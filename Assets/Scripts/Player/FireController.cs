using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

namespace Player
{

    public class FireController : MonoBehaviour
    {
        [Header("Components")] 
        [SerializeField] private List<Transform> firePositions;

        [Header("Default Variables")] 
        [SerializeField] private bool defaultIsDoubleFire;
        [SerializeField] private float defaultFireRate;
        [SerializeField] private float defaultBulletSpeed;
        [Tooltip("Wait duration between consecutive bullet fire")]
        [SerializeField] private float defaultOnDoubleFireWaitDuration;
        
        private bool isTripleAnglerFire;
        private bool isDoubleFire;
        private float fireRate;
        private float bulletSpeed;
        private float onDoubleFireWaitDuration;
        private IEnumerator fireCoroutine;

        private void Awake()
        {
            SetStartStats();
            fireCoroutine = Fire();
        }

        public void StartFire()
        {
            StartCoroutine(fireCoroutine);
        }

        public void StopFire()
        {
            StopCoroutine(fireCoroutine);
        }

        private IEnumerator Fire()
        {
            while (true)
            {
                yield return new WaitForSeconds(fireRate);
                
                if (!isDoubleFire)
                {
                    FireAccordingToFireType();
                }
                else
                {
                    for (var i = 0; i < 2; i++)
                    {
                        FireAccordingToFireType();
                
                        yield return new WaitForSeconds(onDoubleFireWaitDuration);
                    }
                }
            }
        }

        private void FireAccordingToFireType()
        {
            if (isTripleAnglerFire)
            {
                foreach (var firePosition in firePositions)
                {
                    var spawnBullet = PoolManager.GetPoolObject();
                    spawnBullet.transform.position = firePosition.position;
                    spawnBullet.gameObject.SetActive(true);
                    spawnBullet.AddForceToBullet(Vector3.forward, bulletSpeed);
                }
            }
            else
            {
                var spawnBullet = PoolManager.GetPoolObject();
                spawnBullet.transform.position = firePositions[0].position;
                spawnBullet.gameObject.SetActive(true);
                spawnBullet.AddForceToBullet(Vector3.forward, bulletSpeed);
            }
        }

        public void SetDoubleFire(bool value)
        {
            isDoubleFire = value;
        }

        public void SetIsFireTripleFire(bool value)
        {
            isTripleAnglerFire = value;
        }

        public void SetFireRate(float rate)
        {
            fireRate = rate;
        }

        public void SetBulletSpeed(float speed)
        {
            bulletSpeed = speed;
        }

        private void SetStartStats()
        {
            fireRate = defaultFireRate;
            isDoubleFire = defaultIsDoubleFire;
            bulletSpeed = defaultBulletSpeed;
            onDoubleFireWaitDuration = defaultOnDoubleFireWaitDuration;
        }
    }
}