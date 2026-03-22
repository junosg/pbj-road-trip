using System.Collections;
using JetBrains.Annotations;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager Instance;
    public const int MENU_SCENE_INDEX = 1;
    public const int LOADING_SCENE_INDEX = 2;
    public const int GAME_SCENE_INDEX = 3;

    private int _sceneToLoadIndex;

    public readonly UnityEvent<float> ProgressUpdated = new();

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        } else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void SmoothLoadScene(int sceneIndex)
    {
        _sceneToLoadIndex = sceneIndex;
        SceneManager.LoadScene(LOADING_SCENE_INDEX);
    }

    public void LoadSceneAsync()
    {
        StartCoroutine(LoadSceneAsyncEnumerator(_sceneToLoadIndex));
    }

    IEnumerator LoadSceneAsyncEnumerator(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        operation.allowSceneActivation = false;

        yield return new WaitForSeconds(0.5f);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            if (progress >= 0.9f)
            {
                ProgressUpdated.Invoke(1);
                yield return new WaitForSeconds(4f);
                operation.allowSceneActivation = true;
            } else if (progress >= 0.6f)
            {
                yield return new WaitForSeconds(2f);
                ProgressUpdated.Invoke(progress);
            } else if (progress >= 0.3f)
            {
                yield return new WaitForSeconds(2f);
                ProgressUpdated.Invoke(progress);
            }

            yield return null;
        }
    }
}
