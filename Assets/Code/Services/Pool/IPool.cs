using UnityEngine;

namespace Code.Services.Pool
{
    public interface IPool<TObject> where TObject : MonoBehaviour
    {
        public TObject Get(Vector3 position, Quaternion quaternion);
    }
}