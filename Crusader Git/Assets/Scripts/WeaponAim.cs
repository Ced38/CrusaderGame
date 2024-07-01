using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    public Transform Center;
    public Transform leftHandPivot;
    public Transform rightHandPivot;
    private Vector3 mousePos;
    private float margin = 20f;

    private SpriteRenderer renderer;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RotateWeapon();
        SwitchHand();
    }

    private void RotateWeapon()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        Vector3 lookDirection = mousePos - Center.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        Debug.Log("Angle: " + angle);
        if (mousePos.x < transform.parent.position.x) // Left side
        {
            angle = RemapLeftSideAngles(angle);
        }
        else // Right side
        {
            angle = Mathf.Clamp(angle, -90f + margin, 90f - margin);
        }

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void SwitchHand()
    {
        Vector3 playerPos = transform.parent.position; // Assuming this script is attached to the weapon child of player

        if (mousePos.x < playerPos.x)
        {
            transform.position = leftHandPivot.position;
            renderer.flipX = true;
        }
        else
        {
            transform.position = rightHandPivot.position;
            renderer.flipX = false;
        }
    }

    private float RemapLeftSideAngles(float angle)
    {
        if (angle <= 90f + margin && angle >= 90f)
            return -90f + margin;
        else if (angle >= 90f + margin && angle <= 180f)
            return Mathf.Lerp(-90f, 0f, (angle - 90f) / 90f);
        else if (angle <= -90f && angle >= -90f - margin)
            return 90f - margin;
        else if (angle <= -90f - margin && angle >= -180f)
            return Mathf.Lerp(90f, 0f, (-angle - 90f) / 90f);
        else
            return angle;
    }
}
