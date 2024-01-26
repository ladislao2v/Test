using System;
using TMPro;
using UnityEngine;

namespace Code.UI.View
{
    public class SpawnerDataView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _intervalInputField;
        [SerializeField] private TMP_InputField _speedInputField;
        [SerializeField] private TMP_InputField _distanceInputField;

        public event Action<float> IntervalChanged;
        public event Action<float> SpeedChanged;
        public event Action<float> DistanceChanged;

        public void OnEnable()
        {
            _intervalInputField.onEndEdit.AddListener(OnIntervalChanged);
            _speedInputField.onEndEdit.AddListener(OnSpeedChanged);
            _distanceInputField.onEndEdit.AddListener(OnDistanceChanged);
        }

        public void OnDisable()
        {
            _intervalInputField.onEndEdit.RemoveListener(OnIntervalChanged);
            _speedInputField.onEndEdit.RemoveListener(OnSpeedChanged);
            _distanceInputField.onEndEdit.RemoveListener(OnDistanceChanged);
        }

        private void OnIntervalChanged(string intervalText)
        {
            if(float.TryParse(intervalText, out float result))
                IntervalChanged?.Invoke(result);
        }
        
        private void OnSpeedChanged(string speedText)
        {
            if(float.TryParse(speedText, out float result))
                SpeedChanged?.Invoke(result);
        }
        
        private void OnDistanceChanged(string distanceText)
        {
            if(float.TryParse(distanceText, out float result))
                DistanceChanged?.Invoke(result);
        }
    }
}