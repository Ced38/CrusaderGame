using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeExit : MonoBehaviour
{


    public SceneManager sceneManagerInstance;

     void Update()
     {
         if (Input.GetKeyDown(KeyCode.Escape))
         {
             EscMenuSwitch();
         }
     }

     void EscMenuSwitch()
     {
         sceneManagerInstance.LoadScene("EscMenu");
     }

}