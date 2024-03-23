using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GetKey : MonoBehaviour
{
    public bool KeyGet;
    public bool HaveKey;
    public Light ChestLight;
    public Text GetKeyText;
    public Image Image;
    public AudioSource SoundKeyGet;
    public Animator Animator;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void RemoveLight()
    {
        ChestLight.intensity = 0;
        HaveKey = true;
    }
    IEnumerator GetKeyCO()
    {
        string O3 = "There's a key inside the chest.";
        string O4 = "Now I can unlock that gate!";
        GetKeyText.text = O3.ToString();
        StartCoroutine(FadeTextToFullAlpha(0.5f, GetKeyText));
        StartCoroutine(FadeImageToFullAlpha(0.5f, Image));
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeTextToZeroAlpha(0.5f, GetKeyText));
        yield return new WaitForSeconds(2f);
        GetKeyText.text = O4.ToString();
        StartCoroutine(FadeTextToFullAlpha(0.5f, GetKeyText));
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeTextToZeroAlpha(0.5f, GetKeyText));
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

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (!KeyGet)
        {
            Animator.speed = 3;
            SoundKeyGet.Play();
            KeyGet = true;
            RemoveLight();
            StartCoroutine(GetKeyCO());
        }

    }
}
