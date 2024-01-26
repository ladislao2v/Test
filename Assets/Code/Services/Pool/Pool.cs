using System.Collections.Generic;
using Code.Services.Factories;
using UnityEngine;

namespace Code.Services.Pool
{
    public class Pool<TObject> : IPool<TObject> where TObject : MonoBehaviour
    {
        private readonly IFactory<TObject> _factory;
        private readonly Transform _container;

        private List<TObject> _pool;

        public Pool(IFactory<TObject> factory, Transform container, int capacity = 25)
        {
            _factory = factory;
            _container = container;
            
            Create(capacity);
        }

        private void Create(int capacity)
        {
            _pool = new List<TObject>();

            for (int i = 0; i < capacity; i++)
                CreateObject(Vector3.zero, Quaternion.identity);
        }

        private TObject CreateObject(Vector3 position, Quaternion quaternion, bool isActive = false)
        {
            var instance = _factory.Create(position, quaternion, _container);
            
            instance.gameObject.SetActive(isActive);
            _pool.Add(instance);

            return instance;
        }

        private bool HasFree(out TObject element)
        {
            foreach (var item in _pool)
            {
                if (item.gameObject.activeInHierarchy == false)
                {
                    element = item;
                    element.gameObject.SetActive(true);
                    return false;
                }
            }

            element = null;
            return false;
        }

        public TObject Get(Vector3 position, Quaternion quaternion)
        {
            if (HasFree(out TObject element))
                return element;

            return CreateObject(position, quaternion, true);
        }
    }
}