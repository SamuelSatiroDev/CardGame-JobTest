using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public sealed class LoadSceneSystem
{
    [SerializeField] private string _sceneName;

    public void HandlerLoadScene()
    {
        if (IsSceneLoaded(_sceneName) == true)
        {
            return;
        }

        SceneManager.LoadScene(_sceneName, LoadSceneMode.Additive);
    }

    public void HandlerLoadScene(string sceneName)
    {    
        if (IsSceneLoaded(sceneName) == true)
        {
            return;
        }
       
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public void HandlerSetActiveScene() => HandlerSetActiveScene(_sceneName);

    public void HandlerSetActiveScene(string sceneName)
    {
        Scene scene = SceneManager.GetSceneByName(sceneName);
        SceneManager.SetActiveScene(scene);
    }

    private bool IsSceneLoaded(string sceneName)
    {      
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name == sceneName)
            {
                return true;
            }
        }

        return false;
    }
}