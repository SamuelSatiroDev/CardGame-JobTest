using UnityEngine;

using GameItemSystem.Data;

namespace EventSystem
{
    [CreateAssetMenu(fileName = "EventData", menuName = "Game Manager/Event System/Event Data")]
    public sealed class EventData : ScriptableObject
    {
        [TextArea(2, 500)]
        [SerializeField] private string _info;

        public System.Action OnEvent;
        public System.Action<int> OnEventInt;
        public System.Action<float> OnEventFloat;
        public System.Action<string> OnEventString;
        public System.Action<Transform> OnEventTransform;
        public System.Action<GameItemData_base> OnEventGameItemData;

        public void HandlerInvoke() => OnEvent?.Invoke();
        public void HandlerInvoke(int value) => OnEventInt?.Invoke(value);
        public void HandlerInvoke(float value) => OnEventFloat?.Invoke(value);
        public void HandlerInvoke(string value) => OnEventString?.Invoke(value);
        public void HandlerInvoke(Transform value) => OnEventTransform?.Invoke(value);
        public void HandlerInvoke(GameItemData_base value) => OnEventGameItemData?.Invoke(value);
    }
}