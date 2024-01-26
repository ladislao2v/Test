using UnityEngine;

namespace Code.Services.Data
{
    public class SpawnerData
    {
        private readonly Vector3 _spawnPosition;

        private float _interval = 2;
        private float _speed = 0.25f;
        private float _distance = 25;

        public Vector3 SpawnPosition => _spawnPosition;
        public float Interval => _interval;
        public float Speed => _speed;
        public float Distance => _distance;

        public SpawnerData(Vector3 spawnPosition)
        {
            _spawnPosition = spawnPosition;
        }

        public void OnIntervalChanged(float interval)
        {
            _interval = interval;
        }

        public void OnSpeedChanged(float speed)
        {
            _speed = speed;
        }

        public void OnDistanceChanged(float distance)
        {
            _distance = distance;
        }
    }
}