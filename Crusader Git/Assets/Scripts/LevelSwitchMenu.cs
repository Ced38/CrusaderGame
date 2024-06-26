using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitchMenu : MonoBehaviour
{



    public SceneManager sceneManagerInstance;
    public string sceneName;

   /* [SerializeField]
    private string nextSceneName;
    */


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            Switch();

         if (other.gameObject.CompareTag("Bullet"))
                    Switch();
    }



     void Switch()
         {
             sceneManagerInstance.LoadScene(sceneName);
         }


}


