using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;


public class VictoryScript : MonoBehaviour
{
    public Image fade;
    public Image image;
    public Image Quit;
    public bool Victory;
    public GameObject QuitUI;

    IEnumerator WinnerYay()
    {
        StartCoroutine(FadeImageToFullAlpha(2f, fade));
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(FadeImageToFullAlpha(2f, image));
        yield return new WaitForSeconds(3f);
        StartCoroutine(FadeImageToFullAlpha(1f, Quit));
        QuitUI.SetActive(true);
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
        if (!Victory)
        {
            Victory = true;
            StartCoroutine(WinnerYay());
        }

    }
}
