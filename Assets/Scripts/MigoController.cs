using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MigoController : MonoBehaviour
{
    public Transform[] targetPoint;
    public int currentPoint;
    public NavMeshAgent agent;
    public Animator Animator;
    public AudioSource Scream;
    public bool ScreamCD;
    public Image MC;
    public Sprite MC1;
    public Sprite MC2;
    public Sprite MC3; 
    public Image Box;
    public Text ChaseText;
    public bool ChaseTextCD;
    public GetKey KS;

    public float waitAtPoint = 5f;
    [SerializeField] private float waitCounter;

    public enum AIState
    {
        isDead, SeekPoint, SeekPlayer, Attack
    }
    public AIState state;
    // Start is called before the first frame update
    void Start()
    {
        waitCounter = waitAtPoint;
    }
        public IEnumerator RunCO()
    {
        if (!ChaseTextCD)
        {
            ChaseTextCD = true;
            string Chasing = "N-n-nooo...!";
            ChaseText.text = Chasing.ToString();
            StartCoroutine(FadeTextToFullAlpha(0.5f, ChaseText));
            StartCoroutine(FadeImageToFullAlpha(0.5f, Box));
            yield return new WaitForSeconds(2f);
            StartCoroutine(FadeTextToZeroAlpha(0.5f, ChaseText));
            StartCoroutine(FadeImageToZeroAlpha(0.5f, Box));
        }
    }
        public IEnumerator ScreamCO()
    {
        if (!ScreamCD)
        {
            ScreamCD = true;
            Scream.Play();
            yield return new WaitForSeconds(1.5f);
        }
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
        float distanceToPlayer = Vector3.Distance(transform.position, PlayerController.instance.transform.position);
        if (!PlayerController.instance.IsDead)
        {
            if (distanceToPlayer >= 2f && distanceToPlayer <= 4.5f)
            {
                state = AIState.SeekPlayer;
            }
            else if (distanceToPlayer > 8)
            {
                state = AIState.SeekPoint;
            }
            else if (distanceToPlayer <= 2f)
            {
                state = AIState.Attack;
            }
        }
        else
        {
            state = AIState.isDead;
            Animator.SetBool("Attack", false);
            Animator.SetBool("Run", true);
        }
        switch (state)
        {
            case AIState.isDead:
                MC.sprite = MC3;
                Animator.SetBool("Run", false);
                Animator.SetBool("Chase", false);
                ChaseTextCD = false;
                ScreamCD = false;
                agent.speed = 0.5f;
                break;
            case AIState.SeekPlayer:
                Animator.SetBool("Attack", false);
                MC.sprite = MC2;
                StartCoroutine(RunCO());
                StartCoroutine(ScreamCO());
                if (KS.KeyGet == true)
                {
                    agent.speed = 2.4f;

                }
                else
                {
                    agent.speed = 1.2f;
                }
                agent.SetDestination(PlayerController.instance.transform.position);
                Animator.SetBool("Chase", true);
                break;
            case AIState.SeekPoint:
                Animator.SetBool("Attack", false);
                Animator.SetBool("Run", true);
                Animator.SetBool("Chase", false);
                ChaseTextCD = false;
                ScreamCD = false;
                if (KS.KeyGet == true)
                {
                    agent.speed = 1.5f;

                }
                else
                {
                    agent.speed = 0.5f;
                }
                agent.SetDestination(targetPoint[currentPoint].position);
                agent.stoppingDistance = 0f;
                if (agent.remainingDistance <= .2f)
                {
                    if (waitCounter > 0)
                    {
                        waitCounter -= Time.deltaTime;
                        Animator.SetBool("Run", false);
                    }
                    else
                    {
                        currentPoint++;
                        waitCounter = waitAtPoint;
                        Animator.SetBool("Run", true);
                    }

                    if (currentPoint >= targetPoint.Length)
                    {
                        currentPoint = 0;
                    }
                    agent.SetDestination(targetPoint[currentPoint].position);
                }
                break;
            case AIState.Attack:
                Rotate();
                agent.stoppingDistance = 0f;
                Animator.SetBool("Attack", true);
                Animator.SetBool("Chase", false);
                break;
        }
    }

    void Rotate()
    {
        Vector3 direction = (PlayerController.instance.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
