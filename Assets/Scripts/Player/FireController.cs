using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using Power;
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
        [Header("Components")] [SerializeField]
        private Bullet.Bullet bullet;

        [SerializeField] private List<Transform> firePositions;

        [Header("Default Variables")] [SerializeField]
        private FireType defaultFireType;

        [SerializeField] private bool defaultIsDoubleFire;
        [SerializeField] private float defaultFireRate;
        [SerializeField] private float defaultBulletSpeed;

        [Tooltip("Wait duration between consecutive bullet fire")] [SerializeField]
        private float defaultOnDoubleFireWaitDuration;

        private FireType fireType;
        private bool isDoubleFire;
        private float fireRate;
        private float bulletSpeed;
        private float onDoubleFireWaitDuration;

        private void Awake()
        {
            SetStartStats();
        }

        public void StartFire()
        {
            StartCoroutine(Fire());
        }

        public void StopFire()
        {
            StopCoroutine(Fire());
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
            switch (fireType)
            {
                case FireType.Default:
                    var spawnBullet = PoolManager.GetPoolObject();
                    spawnBullet.transform.position = firePositions[0].position;
                    spawnBullet.gameObject.SetActive(true);
                    spawnBullet.AddForceToBullet(Vector3.forward, bulletSpeed);
                    break;
                case FireType.Triple:
                    foreach (var firePosition in firePositions)
                    {
                        spawnBullet = PoolManager.GetPoolObject();
                        spawnBullet.transform.position = firePosition.position;
                        spawnBullet.gameObject.SetActive(true);
                        spawnBullet.AddForceToBullet(Vector3.forward, bulletSpeed);
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void SetFireStatsOnPowerActive(PowerType powerType, float powerTypeAmount)
        {
            switch (powerType)
            {
                case PowerType.TripleAngleFire:
                    fireType = FireType.Triple;
                    break;
                case PowerType.DoubleFire:
                    isDoubleFire = true;
                    onDoubleFireWaitDuration = powerTypeAmount;
                    break;
                case PowerType.IncreaseFireRate:
                    fireRate = powerTypeAmount;
                    break;
                case PowerType.BulletSpeed:
                    bulletSpeed *= powerTypeAmount;
                    break;
                case PowerType.PlayerSpeed:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(powerType), powerType, null);
            }
        }

        public void SetFireStatsOnPowerDeActive(PowerType powerType, float powerTypeAmount)
        {
            switch (powerType)
            {
                case PowerType.TripleAngleFire:
                    fireType = defaultFireType;
                    break;
                case PowerType.DoubleFire:
                    isDoubleFire = defaultIsDoubleFire;
                    onDoubleFireWaitDuration = defaultOnDoubleFireWaitDuration;
                    break;
                case PowerType.IncreaseFireRate:
                    fireRate = defaultFireRate;
                    break;
                case PowerType.BulletSpeed:
                    bulletSpeed = defaultBulletSpeed;
                    break;
                case PowerType.PlayerSpeed:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(powerType), powerType, null);
            }
        }

        private void SetStartStats()
        {
            fireType = defaultFireType;
            fireRate = defaultFireRate;
            isDoubleFire = defaultIsDoubleFire;
            bulletSpeed = defaultBulletSpeed;
            onDoubleFireWaitDuration = defaultOnDoubleFireWaitDuration;
        }
    }
}