using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGoneLeave : MonoBehaviour
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

    private void OnCollisionExit2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            door.transform.position = respawnPoint.position;
        }
    }
}
