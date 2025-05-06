using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CreditManager : MonoBehaviour
{
    public CanvasGroup memberGroup;
    public CanvasGroup assetGroup;
    public CanvasGroup logoGroup;

    public float fadeDuration = 1f;
    public float displayTime = 4f;
    public string sceneToLoad = "MainMenu"; // กลับหน้าเมนู

    void Start()
    {
        StartCoroutine(ShowCreditsSequence());
    }

    IEnumerator ShowCreditsSequence()
    {
        // แสดงสมาชิก
        yield return FadeIn(memberGroup);
        yield return new WaitForSeconds(displayTime);
        yield return FadeOut(memberGroup);

        // แสดง assets
        yield return FadeIn(assetGroup);
        yield return new WaitForSeconds(displayTime);
        yield return FadeOut(assetGroup);

        // แสดงโลโก้
        yield return FadeIn(logoGroup);
        yield return new WaitForSeconds(displayTime);
        yield return FadeOut(logoGroup);

        // โหลดหน้าหลัก
        SceneManager.LoadScene(sceneToLoad);
    }

    IEnumerator FadeIn(CanvasGroup cg)
    {
        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            cg.alpha = Mathf.Lerp(0, 1, t / fadeDuration);
            yield return null;
        }
        cg.alpha = 1;
    }

    IEnumerator FadeOut(CanvasGroup cg)
    {
        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            cg.alpha = Mathf.Lerp(1, 0, t / fadeDuration);
            yield return null;
        }
        cg.alpha = 0;
    }
}
