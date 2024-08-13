using UnityEngine;
using UnityEngine.Events;

namespace EventSystem
{
    public sealed class OnAwakeStartEvents : MonoBehaviour
    {
        public UnityEvent OnAwakeEvent;
        public UnityEvent OnStartEvent;

        private void Awake() => OnAwakeEvent?.Invoke();
        private void Start() => OnStartEvent?.Invoke();
    }
}