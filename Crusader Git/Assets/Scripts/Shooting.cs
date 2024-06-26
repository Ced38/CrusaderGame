using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    public GameObject bulletClone;


  

    

   


    //target = GameObject.FindGameObjectWithTag("player");




    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

    }

    


  

    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);


        if (rotZ > 90 || rotZ < -90)
        {
            rotation.y = -1f;
        }
        else
        {
            rotation.y = +1f;
        }


        if(!canFire)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
               canFire = true;
               timer = 0;
            }
        }

        if (Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            bulletClone = (GameObject)Instantiate(bullet, bulletTransform.position, Quaternion. identity);
            bulletClone.name = "bulletClone";
            BoxCollider2D sc = bulletClone.gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;


            Destroy(bulletClone, 2);

        }



    }
}
