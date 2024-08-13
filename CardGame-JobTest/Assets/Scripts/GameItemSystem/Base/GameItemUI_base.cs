using UnityEngine;
using TMPro;
using GameItemSystem.Data;
using UnityEngine.Events;

namespace GameItemSystem.UI
{
    public abstract class GameItemUI_base : MonoBehaviour
    {
        [SerializeField] private GameItemData_base _gameItemData;
        [SerializeField] private TMP_Text _gameItemName;

        [Space(20)]
        [Header("Events")]
        public UnityEvent<GameItemData_base> OnGetGameItemData;

        public void HandlerUpdateUI()
        {
            if (CheckGameItemDataIsNull())
            {
                return;
            }

            HandlerUpdateUI(_gameItemData);
        }

        public void HandlerUpdateUI(GameItemData_base gameItemData)
        {
            _gameItemData = gameItemData;
            _gameItemName.text = _gameItemData.GameItemName;

            UpdateUI(gameItemData);
        }

        public void HandlerGetGameItemData()
        {
            if (CheckGameItemDataIsNull())
            {
                return;
            }

            OnGetGameItemData?.Invoke(_gameItemData);
        }

        protected abstract void UpdateUI(GameItemData_base gameItemData);

        private bool CheckGameItemDataIsNull()
        {
            if (_gameItemData == null)
            {
                return true;
            }

            return false;
        }
    }
}