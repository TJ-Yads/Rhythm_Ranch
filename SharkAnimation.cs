using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkAnimation : MonoBehaviour//an animation controller for one of the animals in game
{
    private float maxSpeed = 3f;

    public Animator anim;
    public GameController GC;
    public TameBeast tameScript;
    public AndrewController AC;
    public bool following = false;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("TameController") != null)
        {
            tameScript = GameObject.FindGameObjectWithTag("TameController").GetComponent<TameBeast>();
        }
        AC = GameObject.FindGameObjectWithTag("Player").GetComponent<AndrewController>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GC = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()//while the animal is claimed after a music loop the animal will follow the player and change animations based on player movement
    {
        if (following == true)
        {
            float B = Input.GetAxis("Horizontal");
            float h = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(B * maxSpeed, h * maxSpeed);
        }
        if (tameScript != null)
        {
            if (tameScript.taming == true)
            {
                anim.SetBool("MovingLeft", true);
            }
        }


        if ((AC.taming == false && GC.outHub == true))
        {
            if (rb.velocity.y < 0)
            {
                anim.SetBool("MovingForward", true);
            }
            else
                anim.SetBool("MovingForward", false);
            if (rb.velocity.y > 0)
            {
                anim.SetBool("MovingBackwards", true);
            }
            else
                anim.SetBool("MovingBackwards", false);
            if (rb.velocity.x < 0)
            {
                anim.SetBool("MovingLeft", true);
            }
            else
                anim.SetBool("MovingLeft", false);
            if (rb.velocity.x > 0)
            {
                anim.SetBool("MovingRight", true);
            }
            else
                anim.SetBool("MovingRight", false);
        }
    }

}
