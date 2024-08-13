using UnityEngine;
using GameItemSystem.Data;
using UnityEngine.Events;
using PoolingSystem;

namespace GameItemSystem.UI
{
    public sealed class GameItemUIManager : MonoBehaviour, IOnReset
    {
        [Header("Settings")]
        [SerializeField] private GameItemDataManager _gameItemDataManager;
        [SerializeField] private GameItemUI_base _gameItemUIPrefab;
        [SerializeField] private RectTransform _gameItemUIContent;

        [Space(20)]

        [Header("Events")]
        public UnityEvent<Transform> OnGameItemUIAddedTransform;

        private void Start() => _gameItemDataManager.OnGameItemDataCount?.Invoke(_gameItemDataManager.GameItemData_Bases.Count);

        public void HandlerGenerateGameItemUI()
        {
            foreach (GameItemData_base gameItemData_base in _gameItemDataManager.GameItemData_Bases)
            {
                HandlerAddGameItemUI(gameItemData_base);
            }
        }

        public void HandlerAddGameItemUI(GameItemData_base gameItemData_base)
        {
            GameItemUI_base gameItemUI_Base = PoolingManager.HandlerOnGet(_gameItemUIPrefab.GetInstanceID().ToString(), _gameItemUIPrefab.gameObject).GetComponent<GameItemUI_base>();

            gameItemUI_Base.transform.SetParent(_gameItemUIContent);
            SetDefaultGameItemUITransform(gameItemUI_Base.transform);

            gameItemUI_Base.HandlerUpdateUI(gameItemData_base);

            OnGameItemUIAddedTransform?.Invoke(gameItemUI_Base.transform);
        }

        public void OnReset()
        {
            foreach (Transform ChildTransform in _gameItemUIContent)
            {
                ChildTransform.gameObject.SetActive(false);
            }
        }

        private void SetDefaultGameItemUITransform(Transform transform)
        {
            transform.SetAsLastSibling();
            transform.localPosition = Vector3.zero;
            transform.localScale = Vector3.one;
            transform.localRotation = Quaternion.identity;
        }
    }
}