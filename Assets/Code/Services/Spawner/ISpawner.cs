using System.Collections;
using Code.Cube;
using Code.Services.Calculator.DurationCalculator;
using Code.Services.CoroutineRunner;
using Code.Services.Data;
using Code.Services.Pool;
using UnityEngine;

namespace Code.Services.Spawner
{
    public interface ISpawner
    {
        void Start();
        void Stop();
    }

    public class SimpleSpawner : ISpawner
    {
        private readonly ICoroutineRunner _coroutineRunner;

        private readonly IPool<CubeView> _pool;

        private readonly IDurationCalculator _durationCalculator;

        private readonly SpawnerData _data;

        private Coroutine _spawnCoroutine;

        public SimpleSpawner(ICoroutineRunner coroutineRunner, 
            IPool<CubeView> pool, 
            IDurationCalculator durationCalculator, 
            SpawnerData data)
        {
            _coroutineRunner = coroutineRunner;
            _pool = pool;
            _durationCalculator = durationCalculator;
            _data = data;
        }

        public void Start() =>
            _spawnCoroutine = 
                _coroutineRunner.StartCoroutine(SpawnObjects());

        public void Stop() =>
            _coroutineRunner
                .StopCoroutine(_spawnCoroutine);

        private IEnumerator SpawnObjects()
        {
            while (true)
            {
                IMovable movable = _pool.Get(_data.SpawnPosition, Quaternion.identity);

                Vector3 to = 
                    Vector3.forward * _data.Distance;
                float duration 
                    = _durationCalculator.ConvertSpeedToDuration(_data.Speed);
                
                movable.MoveTo(to, duration);

                yield return new WaitForSeconds(_data.Interval);
            }
        }
    }
}