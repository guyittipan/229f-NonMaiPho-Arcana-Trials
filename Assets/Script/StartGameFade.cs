using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class StartGameFade : MonoBehaviour
{
    public CanvasGroup fadeGroup;
    public float fadeDuration = 1f;
    public string sceneToLoad = "ชื่อSceneถัดไป";

    public void StartGame()
    {
        StartCoroutine(FadeAndLoadScene());
    }

    IEnumerator FadeAndLoadScene()
    {
        // Fade In
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadeGroup.alpha = Mathf.Lerp(0, 1, timer / fadeDuration);
            yield return null;
        }

        fadeGroup.alpha = 1;
        yield return new WaitForSeconds(0.2f);

        SceneManager.LoadScene(sceneToLoad);
    }
}
