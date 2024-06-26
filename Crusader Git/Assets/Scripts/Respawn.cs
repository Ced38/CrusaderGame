using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    
    Vector2 checkpointPos;
    SpriteRenderer spriteRenderer;
    Rigidbody2D playerRb;
    public Shooting shooting;
    public GameObject RocketLauncher;


    public ParticleSystem deathParticle;
    

    CameraController cameraController;
    public ParticleController particleController;

    AudioManager audioManager;

    private void Awake()
    {
        cameraController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
        playerRb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
       
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }



    void Start()
    {
        checkpointPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Obstacle"))
        {
            Die();
        }

        
        
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                PlayDeathParticle();
            audioManager.PlaySFX(audioManager.death);
            }
        

 

    }

    public void UpdateCheckpoint(Vector2 pos)
    {
        checkpointPos = pos;
    }


    void Die()
    {
        //cameraController.anim.Play("White Screen");
        //particleController.PlayParticle(ParticleController.Particles.die, transform. point);

        StartCoroutine(RespawnPlace(0.5f)); // how long respawn takes
    }

    IEnumerator RespawnPlace(float duration)
    {
        playerRb.velocity = new Vector2(0, 0);
        playerRb.simulated = false;
        // transform.localScale = new Vector3(0, 0, 0);
        spriteRenderer.enabled = false;
       

        shooting.enabled = false;

        RocketLauncher.GetComponent<SpriteRenderer>().enabled = false;


        yield return new WaitForSeconds(duration);
        transform.position = checkpointPos;
        

        shooting.enabled = true;

        RocketLauncher.GetComponent<SpriteRenderer>().enabled = true;

        spriteRenderer.enabled = true;
        playerRb.simulated = true;

    }




    private void PlayDeathParticle()
    {
        if (deathParticle != null)
        {
            deathParticle.Play();
        }
    }

}






