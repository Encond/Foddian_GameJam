using TMPro;
using UnityEngine;

namespace UI
{
    public class Timer : MonoBehaviour
    {
        [Header("Positions properties")]
        [SerializeField] private Transform _timerPositionInCanvas;
        [SerializeField] private Transform _timerPositionInGameWorld;
        [SerializeField] private Camera _camera;
        
        [Header("Text properties")]
        [SerializeField] private Text _text;
        [SerializeField] private float _resetTimerValue;
        
        private Vector3 _screenPosition;
        private TextMeshProUGUI _timerValue;
        private float _currentTimerValue;

        private void Start()
        {
            _timerValue = _text.gameObject.GetComponent<TextMeshProUGUI>();
            _currentTimerValue = _resetTimerValue;
        }

        private void Update()
        {
            Vector3 screenPosition = _camera.WorldToScreenPoint(_timerPositionInGameWorld.position);
            
            if (_screenPosition == screenPosition) return;
            
            _screenPosition = screenPosition;
            _timerPositionInCanvas.position = _screenPosition;
        }

        private void FixedUpdate() => this.DecreaseTimer();

        private void DecreaseTimer()
        {
            if (_currentTimerValue <= _resetTimerValue && _currentTimerValue > 0)
            {
                _currentTimerValue -= Time.deltaTime;
                _timerValue.text = ((int)_currentTimerValue).ToString();
            }
            // else
            //     this.ResetTimer();
        }
        
        public void ResetTimer() => _currentTimerValue = _resetTimerValue;
    }
}
