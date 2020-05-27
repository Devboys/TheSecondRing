using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInImage : MonoBehaviour
{

    private Image fadeImage;
    public float fadeTime = 1;

    public AnimationCurve curve;
    // Start is called before the first frame update
    void Start()
    {
        fadeImage = this.GetComponent<Image>();
        fadeImage.enabled = true;

        FadeOut();

    }

    public void FadeOut()
    {
        StartCoroutine(fadeOutImage());
    }

    public void FadeIn(bool thenOut)
    {
        StartCoroutine(fadeInImage(thenOut));
    }

    
    private IEnumerator fadeOutImage()
    {

        float elapsedTime = 0;
        Color cCol;

        while (elapsedTime < fadeTime)
        {

            float currentAlpha = 1 - curve.Evaluate(elapsedTime / fadeTime);

            cCol = fadeImage.color;
            cCol.a = currentAlpha;
            fadeImage.color = cCol;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cCol = fadeImage.color;
        cCol.a = 0;
        fadeImage.color = cCol;

    }

    private IEnumerator fadeInImage(bool thenOut)
    {
        float elapsedTime = 0;
        Color cCol;
        while (elapsedTime < fadeTime)
        {

            float currentAlpha = curve.Evaluate(elapsedTime / fadeTime);

            cCol = fadeImage.color;
            cCol.a = currentAlpha;
            fadeImage.color = cCol;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cCol = fadeImage.color;
        cCol.a = 1;
        fadeImage.color = cCol;

        if (thenOut)
        {
            StartCoroutine(fadeOutImage());
        }
    }
}
