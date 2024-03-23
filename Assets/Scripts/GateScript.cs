using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEditor;

public class GateScript : MonoBehaviour
{
    public bool GateTriggerFirst;
    public Text OpeningText;
    public Image Image;
    public PlayerController PCS;
    public GetKey KS;
    public GameObject GameObject;
    public Animator animator;
    public AudioSource OpeningGate;


    IEnumerator FirstGateCO()
{
    string O1 = "Looks like the gate is locked.";
    string O2 = "I need to find a key.";

    OpeningText.text = O1.ToString();
    StartCoroutine(FadeTextToFullAlpha(0.5f, OpeningText));
    StartCoroutine(FadeImageToFullAlpha(0.5f, Image));
    PCS.CanMove = false;
    animator.SetFloat("Speed", 0);
    yield return new WaitForSeconds(2f);
    StartCoroutine(FadeTextToZeroAlpha(0.5f, OpeningText));
    yield return new WaitForSeconds(2f);
    OpeningText.text = O2.ToString();
    StartCoroutine(FadeTextToFullAlpha(0.5f, OpeningText));
    yield return new WaitForSeconds(2f);
    PCS.CanMove = true;
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

   private void OnTriggerStay(Collider other)
    {
        if (KS.KeyGet == false && GateTriggerFirst == false)
        {
            GateTriggerFirst = true;
            StartCoroutine(FirstGateCO());
        }
            if (KS.KeyGet == true)
        {
            OpeningGate.Play();
            Destroy(GameObject);
         }
}    
}
