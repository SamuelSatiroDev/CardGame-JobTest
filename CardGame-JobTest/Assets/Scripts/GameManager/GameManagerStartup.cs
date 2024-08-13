using UnityEngine;

public sealed class GameManagerStartup : MonoBehaviour
{
    public const string GAME_MANAGER_SCENE_NAME = "GameManager (persistent)";

    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        GameObject gameObject = new GameObject("GameManagerStartup");
        gameObject.AddComponent<GameManagerStartup>();
        DontDestroyOnLoad(gameObject);
    }

    private void Awake()
    {
        LoadSceneSystem loadSceneSystem = new LoadSceneSystem();
        loadSceneSystem.HandlerLoadScene(GAME_MANAGER_SCENE_NAME);
    }
}