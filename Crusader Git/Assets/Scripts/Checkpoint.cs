using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{

    Respawn gameController;
    public Transform respawnPoint; //If I want to make player spawn in different place than checkpoint
    Vector2 checkpointPos;

    SpriteRenderer SpriteRenderer;
    public Sprite passive, active; // Adding a passive and active checkpooint sprite
    Collider2D coll; // For turning off collider so can't go back to previous checkpoint


    void Start()
    {
        checkpointPos = transform.position;

    }





    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("Player").GetComponent<Respawn>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameController.UpdateCheckpoint(respawnPoint.position);
            SpriteRenderer.sprite = active;
        }

    }
}

