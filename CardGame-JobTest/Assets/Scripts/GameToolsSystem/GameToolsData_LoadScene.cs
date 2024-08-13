using UnityEngine;

namespace GameToolsSystem
{
    [CreateAssetMenu(fileName = "LoadSceneTools", menuName = "Game Manager/Game Tools System/LoadScene")]
    public sealed class GameToolsData_LoadScene : GameToolsData_base
    {
        [SerializeField] private LoadSceneSystem _loadScene;

        public void HandlerLoadScene() => _loadScene.HandlerLoadScene();
        public void HandlerLoadScene(string sceneName) => _loadScene.HandlerLoadScene(sceneName);

        public void HandlerSetActiveScene() => _loadScene.HandlerSetActiveScene();
        public void HandlerSetActiveScene(string sceneName) => _loadScene.HandlerSetActiveScene(sceneName);
    }
}