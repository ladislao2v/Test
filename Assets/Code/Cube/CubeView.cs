using DG.Tweening;
using UnityEngine;

namespace Code.Cube
{
    public class CubeView : MonoBehaviour, IMovable
    {
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        public void MoveTo(Vector3 position, float duration)
        {
            Sequence sequence = DOTween.Sequence();
            
            sequence
                .Append(_transform.DOMove(position, duration))
                .AppendCallback(() => gameObject.SetActive(false));
        }
    }
}
