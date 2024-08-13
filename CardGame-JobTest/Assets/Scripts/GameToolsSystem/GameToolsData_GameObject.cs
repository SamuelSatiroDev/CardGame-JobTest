using UnityEngine;

namespace GameToolsSystem
{
    [CreateAssetMenu(fileName = "GameObjectTools", menuName = "Game Manager/Game Tools System/GameObject")]
    public sealed class GameToolsData_GameObject : GameToolsData_base
    {
        public void HandlerEnableGameObject(Transform transform) => transform.gameObject.SetActive(true);
        public void HandlerDisableGameObject(Transform transform) => transform.gameObject.SetActive(false);
    }
}