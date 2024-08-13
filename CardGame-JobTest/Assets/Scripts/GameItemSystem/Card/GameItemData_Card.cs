using UnityEngine;

namespace GameItemSystem.Data
{
    [CreateAssetMenu(fileName = "Card Item", menuName = "Game Manager/Card Game/Card")]
    public sealed class GameItemData_Card : GameItemData_base
    {
        [SerializeField] private Sprite _cardSprite;

        public Sprite CardSprite { get => _cardSprite; set => _cardSprite = value; }
    }
}