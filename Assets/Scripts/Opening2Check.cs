using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Opening2Check : MonoBehaviour

{
    bool Opening2Trigger;
    bool StopOP2;
    public Text OpeningText;
    public Image Image;


    IEnumerator Opening2CO()
    {
        string O3 = "Huh... I don't remember this being here.";
        string O4 = "Or this place at all to be honest...";

        OpeningText.text = O3.ToString();
        StartCoroutine(FadeTextToFullAlpha(0.5f, OpeningText));
        StartCoroutine(FadeImageToFullAlpha(0.5f, Image));
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeTextToZeroAlpha(0.5f, OpeningText));
        yield return new WaitForSeconds(2f);
        OpeningText.text = O4.ToString();
        StartCoroutine(FadeTextToFullAlpha(0.5f, OpeningText));
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeTextToZeroAlpha(0.5f, OpeningText));
        StartCoroutine(FadeImageToZeroAlpha(0.5f, Image));
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
    private void OnTriggerStay(Collider other)
    {
        if (!Opening2Trigger && !StopOP2)
        {
            Opening2Trigger = true;
            StopOP2 = true;
            StartCoroutine(Opening2CO());
        }

    }
}
