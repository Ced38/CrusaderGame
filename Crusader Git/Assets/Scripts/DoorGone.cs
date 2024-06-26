using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGone : MonoBehaviour
{
    public GameObject door;
    public Transform respawnPoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            door.transform.position = respawnPoint.position;
        }

        if (other.gameObject.CompareTag("Bullet"))
        {
            door.transform.position = respawnPoint.position;
        }

    }
}

