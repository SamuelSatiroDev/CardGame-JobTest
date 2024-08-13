using UnityEngine;
using UnityEngine.Events;

using GameItemSystem.Data;

namespace EventSystem
{
    public sealed class EventListener : MonoBehaviour
    {
        [SerializeField] private EventData _eventData;
        public UnityEvent OnEvent;
        public UnityEvent<int> OnEventInt;
        public UnityEvent<float> OnEventFloat;
        public UnityEvent<string> OnEventString;
        public UnityEvent<string> OnEventStringInt;
        public UnityEvent<Transform> OnEventTransform;
        public UnityEvent<GameItemData_base> OnEventGameItemData;

        private void OnEnable()
        {
            _eventData.OnEvent += OnUnityEvent;
            _eventData.OnEventInt += OnUnityEvent;
            _eventData.OnEventFloat += OnUnityEvent;
            _eventData.OnEventString += OnUnityEvent;
            _eventData.OnEventTransform += OnUnityEvent;
            _eventData.OnEventGameItemData += OnUnityEvent;
        }

        private void OnDisable()
        {
            _eventData.OnEvent -= OnUnityEvent;
            _eventData.OnEventInt -= OnUnityEvent;
            _eventData.OnEventFloat -= OnUnityEvent;
            _eventData.OnEventString -= OnUnityEvent;
            _eventData.OnEventTransform -= OnUnityEvent;
            _eventData.OnEventGameItemData += OnUnityEvent;
        }

        public void OnUnityEvent() => OnEvent?.Invoke();
        public void OnUnityEvent(int value)
        {
            OnEventInt?.Invoke(value);
            OnEventStringInt?.Invoke(value.ToString());
        }
        public void OnUnityEvent(float value) => OnEventFloat?.Invoke(value);
        public void OnUnityEvent(string value) => OnEventString?.Invoke(value);
        public void OnUnityEvent(Transform value) => OnEventTransform?.Invoke(value);
        public void OnUnityEvent(GameItemData_base value) => OnEventGameItemData?.Invoke(value);
    }
}