using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameItemSystem.Data
{
    [CreateAssetMenu(fileName = "GameItemDataManager", menuName = "Game Manager/Game Item System/Game Item Data Manager")]
    public sealed class GameItemDataManager : ScriptableObject, IOnReset
    {
        [TextArea(2, 500)]
        [SerializeField] private string _info;

        [Space(20)]

        [Header("Game Items")]
        [SerializeField] private List<GameItemData_base> _gameItemData_Bases = new List<GameItemData_base>();

        [Space(20)]

        [Header("Events")]
        public UnityEvent<int> OnGameItemDataCount;
        public UnityEvent<GameItemData_base> OnAddedGameItemData;
        public UnityEvent<GameItemData_base> OnRemovedGameItemData;

        public List<GameItemData_base> GameItemData_Bases => _gameItemData_Bases;

        public void HandlerSetGameItemDatas(GameItemDataManager gameItemDataManager)
        {
            _gameItemData_Bases = new List<GameItemData_base>(gameItemDataManager.GameItemData_Bases);
            OnGameItemDataCount?.Invoke(_gameItemData_Bases.Count);
        }

        public void HandlerAddGameItemData(GameItemData_base gameItemData_Base)
        {
            _gameItemData_Bases.Add(gameItemData_Base);

            OnGameItemDataCount?.Invoke(_gameItemData_Bases.Count);
            OnAddedGameItemData?.Invoke(gameItemData_Base);
        }

        public void HandlerRemoveGameItemData(GameItemData_base gameItemData_Base)
        {
            if (_gameItemData_Bases.Contains(gameItemData_Base) == false)
            {
                return;
            }

            _gameItemData_Bases.Remove(gameItemData_Base);

            OnGameItemDataCount?.Invoke(_gameItemData_Bases.Count);
            OnRemovedGameItemData?.Invoke(gameItemData_Base);
        }

        public void OnReset()
        {
            _gameItemData_Bases.Clear();
            OnGameItemDataCount?.Invoke(_gameItemData_Bases.Count);
        }
    }
}