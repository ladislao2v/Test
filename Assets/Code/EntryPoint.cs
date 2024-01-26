using System;
using Code.Cube;
using Code.Services.Calculator.DurationCalculator;
using Code.Services.CoroutineRunner;
using Code.Services.Data;
using Code.Services.Factories;
using Code.Services.Pool;
using Code.Services.Spawner;
using Code.UI.Presenters;
using Code.UI.View;
using Unity.VisualScripting;
using UnityEngine;

namespace Code
{
    public class EntryPoint : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private CubeView _cubeViewPrefab;
        [SerializeField] private SpawnerDataView _spawnerDataView;
        [SerializeField] private Transform _spawnerTransform
            ;

        private SpawnerDataPresenter _spawnerDataPresenter;
        private ISpawner _spawner;
        
        private void Awake()
        {
            IFactory<CubeView> factory = new SimpleFactory<CubeView>(_cubeViewPrefab);
            IPool<CubeView> pool = new Pool<CubeView>(factory, _spawnerTransform);
            SpawnerData spawnerData = new SpawnerData(_spawnerTransform.position);
            IDurationCalculator durationCalculator = new DurationCalculator();
            _spawnerDataPresenter = new SpawnerDataPresenter(spawnerData, _spawnerDataView);

            _spawner = new SimpleSpawner(this, 
                pool, 
                durationCalculator, 
                spawnerData);
        }

        private void OnEnable()
        {
            _spawnerDataPresenter.Enable();
            
            _spawner.Start();
        }

        private void OnDisable()
        {
            _spawner.Stop();
            
            _spawnerDataPresenter.Disable();
        }
    }
}
