using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OpeningOneTime : MonoBehaviour
{
    bool OpeningTrigger;
    public Text OpeningText;
    public Image Image;

    IEnumerator OpeningCO()
    {
        yield return new WaitForSeconds(3f);
        string O1 = "It's pretty late...";
        string O2 = "I should head back home.";


        OpeningText.text = O1.ToString();
        StartCoroutine(FadeTextToFullAlpha(0.5f, OpeningText));
        StartCoroutine(FadeImageToFullAlpha(0.5f, Image));
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeTextToZeroAlpha(0.5f, OpeningText));
        yield return new WaitForSeconds(2f);
        OpeningText.text = O2.ToString();
        StartCoroutine(FadeTextToFullAlpha(0.5f, OpeningText));
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeTextToZeroAlpha(0.5f, OpeningText));
        StartCoroutine(FadeImageToZeroAlpha(0.5f, Image));
        yield return new WaitForSeconds(2f);
    }


    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeImageToFullAlpha(float t, Image i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeImageToZeroAlpha(float t, Image i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!OpeningTrigger)
        {
            OpeningTrigger = true;
            StartCoroutine(OpeningCO());
        }
    }
}
