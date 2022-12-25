using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMoveScript : MonoBehaviour
{
    public GameObject particles;
    public BirdScript bird;
    public float particleOffset;
    // Start is called before the first frame update
    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = particles.transform.position;
        Vector3 birdPosition = bird.transform.position;
        position[1] = birdPosition[1] - particleOffset;
        if (Input.GetKeyDown(KeyCode.Space) && bird.birdIsAlive && transform.position.y < bird.noJump)
        {
            particles.transform.position = position;
            Debug.Log("Position changed to " + position);
        }
    }
}
