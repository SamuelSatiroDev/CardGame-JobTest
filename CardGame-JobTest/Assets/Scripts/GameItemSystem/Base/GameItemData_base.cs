using UnityEngine;

namespace GameItemSystem.Data
{
    [CreateAssetMenu(fileName = "GameItemData", menuName = "Game Manager/Game Item System/Game Item Data")]
    public class GameItemData_base : ScriptableObject
    {
        [SerializeField] private string _gameItemName;

        public string GameItemName { get => _gameItemName; set => _gameItemName = value; }
    }
}