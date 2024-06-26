using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayIntro : MonoBehaviour
{

    public VideoPlayer videoPlayer;
    public AnimationClip animationClip;
    


    public SceneManager sceneManagerInstance;
    public string sceneName;


    private void Start()
    {
        videoPlayer.Prepare();
        videoPlayer.prepareCompleted += PrepareCompleted;
    }

    private void PrepareCompleted(VideoPlayer source)
    {
        source.Play();
        source.loopPointReached += EndReached;
        PlayAnimation();
    }

    private void PlayAnimation()
    {
        Animation anim = GetComponent<Animation>();
        if (anim != null)
        {
            anim.AddClip(animationClip, animationClip.name);
            anim.Play(animationClip.name);
        }
    }

    private void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.Stop();
        Switch();
    }



    void Switch()
    {
        sceneManagerInstance.LoadScene(sceneName);
    }



}