using UnityEngine;

namespace Code.Services.Factories
{
    public interface IFactory<TObject> where TObject : MonoBehaviour
    {
        public TObject Create(Vector3 position, Quaternion quaternion, Transform parent = null);
        public TObject Create(Transform parent = null);
    }
}