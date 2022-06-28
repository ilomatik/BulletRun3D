using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Managers
{
    public enum PoolType
    {
        Bullet
    }

    [Serializable]
    public class PoolObject
    {
        public PoolType poolType;
        public int poolAmount;
        public GameObject objectToPool;
        public Transform poolParent;
        public List<GameObject> poolObjects;
    }

    public class PoolManager : MonoBehaviour
    {
        #region Variables

        [SerializeField] private List<PoolObject> poolObjects;

        #endregion

        #region Unity Functions

        private void Awake()
        {
            CreatePools();
        }

        #endregion

        #region Custom Functions

        private void CreatePools()
        {
            foreach (var poolObject in poolObjects)
            {
                for (var i = 0; i < poolObject.poolAmount; i++)
                {
                    var obj = Instantiate(poolObject.objectToPool, poolObject.poolParent);
                    obj.SetActive(false);
                    poolObject.poolObjects.Add(obj);
                }
            }
        }

        public GameObject GetPoolObject(PoolType poolType)
        {
            return poolObjects.Where(poolObject => poolObject.poolType == poolType)
                .SelectMany(poolObject => poolObject.poolObjects.Where(poolObj => !poolObj.activeInHierarchy))
                .FirstOrDefault();
        }

        #endregion
    }
}