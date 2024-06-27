using UnityEngine;

namespace CodeBase.ObjectPools
{
    public interface IObjectPool
    {
        void LoadPool(params GameObject[] objects);
        GameObject GetPool();
        void ReturnToPool(GameObject gameObject);
    }
}