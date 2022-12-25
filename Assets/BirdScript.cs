using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public CircleCollider2D circleCollider;
    public float noJump = 11;
    public float deadZone = -15;
    public ParticleSystem particles;
    public bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive && transform.position.y < noJump)
        {
            if (gameStarted == false)
            {
                logic.gameStart();
                myRigidbody.velocity = Vector2.up * flapStrength;
                particles.Play();
                gameStarted = true;
            }
            else
            {
                myRigidbody.velocity = Vector2.up * flapStrength;
                particles.Play();
            }
        }

        if (transform.position.y < deadZone)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
