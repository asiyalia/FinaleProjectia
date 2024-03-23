using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSprite : MonoBehaviour
{

    public MigoController controller;
    public Image MC;
    public Sprite MC1;
    public Sprite MC2;
    public float waitAtPoint = 5f;
    [SerializeField] private float waitCounter;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (controller.state == MigoController.AIState.SeekPoint && MC.sprite != MC1)
        {
            if (waitCounter > 0)
            {
                waitCounter -= Time.deltaTime;
            }
            else
            {
                MC.sprite = MC1;
                waitCounter = waitAtPoint;
            }
        }
    }
}
