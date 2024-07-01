using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwing : MonoBehaviour
{
    bool canMove = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            // animator.SetTrigger("swordAttack");
        }
    }

    public void LockMovement()
    {
        canMove = false;
    }

    public void UnlockMovement()
    {
        canMove = true;
    }
}
