using UnityEngine;

namespace Code.Services.Factories
{
    public class SimpleFactory<TObject> : IFactory<TObject> where TObject : MonoBehaviour
    {
        private readonly TObject _prefab;

        public SimpleFactory(TObject prefab)
        {
            _prefab = prefab;
        }

        public TObject Create(Vector3 position, Quaternion quaternion, Transform parent = null)
        {
            return Object.Instantiate<TObject>(_prefab, position, quaternion , parent);
        }

        public TObject Create(Transform parent = null)
        {
            return Create(Vector3.zero, Quaternion.identity, parent);
        }
    }
}