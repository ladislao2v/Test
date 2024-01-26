using UnityEngine;

namespace Code.Cube
{
    public interface IMovable
    {
        void MoveTo(Vector3 position, float duration);
    }
}