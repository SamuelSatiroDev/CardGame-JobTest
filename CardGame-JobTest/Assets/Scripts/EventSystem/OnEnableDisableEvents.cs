using UnityEngine;
using UnityEngine.Events;

namespace EventSystem
{
    public sealed class OnEnableDisableEvents : MonoBehaviour
    {
        public UnityEvent OnEnableEvent;
        public UnityEvent OnDisableEvent;

        private void OnEnable() => OnEnableEvent?.Invoke();
        private void OnDisable() => OnDisableEvent?.Invoke();
    }
}