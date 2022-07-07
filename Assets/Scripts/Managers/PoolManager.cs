using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Managers
{
    public class PoolManager : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int poolAmount;
        [SerializeField] private Bullet.Bullet objectToPool;
        [SerializeField] private Transform poolParent;
        
        private static List<Bullet.Bullet> poolObjects = new List<Bullet.Bullet>();

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
            for (var i = 0; i < poolAmount; i++)
            {
                var obj = Instantiate(objectToPool, poolParent);
                obj.gameObject.SetActive(false);
                poolObjects.Add(obj);
            }
        }

        public static Bullet.Bullet GetPoolObject()
        {
            return poolObjects.SelectMany(poolObject =>
                    poolObjects.Where(poolObj => !poolObj.gameObject.activeInHierarchy))
                .FirstOrDefault();
        }

        #endregion
    }
}