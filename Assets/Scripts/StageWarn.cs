using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StageWarn : MonoBehaviour

{
    public GateScript GS;
    public PlayerController PCS;
    bool StageWarnTrigger;
    bool StopTrigger2;
    public Text StageWarnText;
    public Image Image;
    public Animator animator;

    IEnumerator StageWarnCO()
    {
        string O3 = "I should check out what's down there...";
        StageWarnText.text = O3.ToString();
        StartCoroutine(FadeTextToFullAlpha(0.5f, StageWarnText));
        StartCoroutine(FadeImageToFullAlpha(0.5f, Image));
        PCS.CanMove = false;
        animator.SetFloat("Speed", 0);
        yield return new WaitForSeconds(3f);
        PCS.CanMove = true;
        StartCoroutine(FadeTextToZeroAlpha(0.5f, StageWarnText));
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
        if (GS.GateTriggerFirst == true)
        {

        }
        if (!GS.GateTriggerFirst && !StopTrigger2)
        {
            StageWarnTrigger = true;
            StopTrigger2 = true;
            StartCoroutine(StageWarnCO());
        }
    }
}
