using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Death : MonoBehaviour
{
    public Animator animator;
    public Animator Fade;
    public AudioSource MonsterScream;
    public AudioSource Hit1;
    public AudioSource Slash;
    public AudioSource Hit2;
    public AudioSource Hit3;
    public AudioSource Splash;
    public AudioSource Blood;
    public Image image;
    public Image Quit;
    public Image Retry;
    public GameObject QuitUI;
    public GameObject RetryUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DeathComplete()
    {
        StartCoroutine(DeathSound());
    }

    IEnumerator DeathSound()
    {
        MonsterScream.Play();
        yield return new WaitForSeconds(1.5f);
        Hit1.Play();
        yield return new WaitForSeconds(0.5f);
        Slash.Play();
        yield return new WaitForSeconds(0.5f);
        Slash.Play();
        Splash.Play();
        yield return new WaitForSeconds(0.5f);
        Slash.Play();
        yield return new WaitForSeconds(0.3f);
        Slash.Play();
        yield return new WaitForSeconds(1f);
        Hit2.Play();
        yield return new WaitForSeconds(1f);
        Hit3.Play();
        yield return new WaitForSeconds(0.75f);
        Hit2.Play();
        yield return new WaitForSeconds(1f);
        Hit1.Play();
        yield return new WaitForSeconds(2f);
        Blood.Play();
        yield return new WaitForSeconds(4f);
        StartCoroutine(Gameover());
    }

    IEnumerator Gameover()
    {
        StartCoroutine(FadeImageToFullAlpha(2f, image));
        yield return new WaitForSeconds(4f);
        StartCoroutine(FadeImageToFullAlpha(1f, Quit));
        StartCoroutine(FadeImageToFullAlpha(1f, Retry));
        QuitUI.SetActive(true);
        RetryUI.SetActive(true);

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

}
