using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private CharacterController controller;
    public SpriteRenderer spriteRenderer;
    private Vector3 playerVelocity;
    public bool CanMove = true;
    public static PlayerController instance;
    public bool IsDead;
    public GameObject GameObject;
    public Animator Fade;
    public AudioSource MonsterScream;
    public AudioSource Hit1;
    public AudioSource Slash;
    public AudioSource Hit2;
    public AudioSource Hit3;
    public AudioSource Splash;
    public AudioSource Blood;

    [SerializeField] private float playerspeed = 3f;
    [SerializeField] private Camera followCamera;
    [SerializeField] private float gravity = -13f;
    // Start is called before the first frame update

    public void DeathComplete()
    {
        StartCoroutine(DeathSound());
    }

    IEnumerator DeathSound()
    {
        MonsterScream.Play();
        yield return new WaitForSeconds(0.5f);
        Hit1.Play();
        yield return new WaitForSeconds(0.2f);
        Slash.Play();
        yield return new WaitForSeconds(0.1f);
        Slash.Play();
        yield return new WaitForSeconds(0.1f);
        Slash.Play();
        yield return new WaitForSeconds(0.1f); 
        Slash.Play();
        yield return new WaitForSeconds(0.05f);
        Hit2.Play();
        Hit3.Play();
        yield return new WaitForSeconds(0.1f);
        Hit2.Play();
        yield return new WaitForSeconds(0.1f);
        Splash.Play();
        yield return new WaitForSeconds(0.2f);
        Blood.Play();
        yield return new WaitForSeconds(1f);
    }

    void DeathFade()
    {
        Fade.SetTrigger("DeathFade");
    }

    IEnumerator DeathWait()
    {
        yield return new WaitForSeconds(1);
        DeathFade();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Kill"))
        {
            animator.SetFloat("Speed", 0);
            IsDead = true;
            CanMove = false;
            StartCoroutine(DeathWait());
        }
    }

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (CanMove)
        {
            Movement();
        }
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput != 0 && horizontalInput < 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontalInput != 0 && horizontalInput > 0)
        {
            spriteRenderer.flipX = true;
        }

        Vector3 movementInput = Quaternion.Euler(0, followCamera.transform.eulerAngles.y, 0) * new Vector3(horizontalInput, 0, verticalInput);

        Vector3 movementDirection = movementInput.normalized;

        controller.Move(movementDirection * playerspeed * Time.deltaTime);

        animator.SetFloat("Speed", Mathf.Abs(movementDirection.x) + Mathf.Abs(movementDirection.z));

        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

    }
}
