using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    Collider2D SwordHitBox;

    private void Start()
    {
        SwordHitBox = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SwordHitBox.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            // deal damage
        }
    }

    /*
     *  Won't Need left and right, I want it on the sword
     *
        public void attackRight()
        {
            SwordHitBox.enabled = true;
        }
    
        public void attackLeft()
        {
            SwordHitBox.enabled = true;
        }*/

    public void StopAttack()
    {
        SwordHitBox.enabled = false;
    }
}
