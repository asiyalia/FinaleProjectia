using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    public void Button_Start()
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnComplete()
    {
        SceneManager.LoadScene("Game");
    }

    public void Button_Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
