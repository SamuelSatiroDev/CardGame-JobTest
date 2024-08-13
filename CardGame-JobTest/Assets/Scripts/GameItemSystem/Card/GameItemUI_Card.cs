using UnityEngine;
using UnityEngine.UI;

using GameItemSystem.Data;

namespace GameItemSystem.UI
{
    public sealed class GameItemUI_Card : GameItemUI_base
    {
        [SerializeField] private Image _cardSprite;

        private GameItemData_Card _gameItemData_Card;

        protected override void UpdateUI(GameItemData_base gameItemData)
        {
            if (gameItemData.GetType() != typeof(GameItemData_Card))
            {
                return;
            }

            _gameItemData_Card = gameItemData as GameItemData_Card;
            _cardSprite.sprite = _gameItemData_Card.CardSprite;
        }
    }
}