using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StageStart : MonoBehaviour
{
    public PlayerController PCS;
    public bool StartStageTrig;
    public AudioSource Scream;
    public Image MC;
    public Image Box;
    public Text StageStartText;
    public Sprite MC1;
    public Sprite MC2;
    public Sprite MC3; 
    public Animator animator;

    IEnumerator StartStage()
    {
        string O1 = "Ughh!";
        string O2 = "What was that sound?";
        string O3 = "I better hurry...";
        StageStartText.text = O1.ToString();
        Scream.Play();
        PCS.CanMove = false;
        animator.SetFloat("Speed", 0);
        MC.sprite = MC2;
        yield return new WaitForSeconds(1f);
        StartCoroutine(FadeTextToFullAlpha(0.5f, StageStartText));
        StartCoroutine(FadeImageToFullAlpha(0.5f, Box));
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeTextToZeroAlpha(0.5f, StageStartText));
        yield return new WaitForSeconds(1f);
        StageStartText.text = O2.ToString();
        MC.sprite = MC1;
        StartCoroutine(FadeTextToFullAlpha(0.5f, StageStartText));
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeTextToZeroAlpha(0.5f, StageStartText));
        yield return new WaitForSeconds(1f);
        StageStartText.text = O3.ToString();
        StartCoroutine(FadeTextToFullAlpha(0.5f, StageStartText));
        PCS.CanMove = true;
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeTextToZeroAlpha(0.5f, StageStartText));
        StartCoroutine(FadeImageToZeroAlpha(0.5f, Box));
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

    }
    private void OnTriggerStay(Collider other)
    {
        if (!StartStageTrig)
        {
            StartStageTrig = true;
            StartCoroutine(StartStage());
        }
    }
    
}
