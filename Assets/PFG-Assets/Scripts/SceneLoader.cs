using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameManager gM;

    public void LoadScene(int index)
    {
        StartCoroutine(LoadAsynchonously(index));
    }

    IEnumerator LoadAsynchonously(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        while (!operation.isDone)
        {
            yield return null;
        }
        gM.AfterLoaded();
    }
}
