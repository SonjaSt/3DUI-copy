using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStarter : MonoBehaviour, IRayCastable {


    public Color idleColor;
    public Color selectedColor;
    public Color playingColor;


    private Renderer myRenderer;
    private AudioSource myAudioSource;


    private void Awake()
    {
        myRenderer = GetComponent<Renderer>();
        myAudioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        myRenderer.material.color = idleColor;
    }




    public void OnSelected()
    {
        if (myAudioSource.isPlaying == false)
        {
            myRenderer.material.color = selectedColor;
        }
        if (Input.GetKeyDown("l"))
        {
            if (myAudioSource.isPlaying == true)
            {
                //myAudioSource.Stop();
                //myRenderer.material.color = selectedColor;
            }
            else
            {
                myAudioSource.Play();
                myRenderer.material.color = playingColor;
                StopAllCoroutines();
                StartCoroutine(ResetColorOnAudioCompleted());
            }
        }
    }

    public void OnReleased()
    {
        if (myAudioSource.isPlaying == false)
        {
            myRenderer.material.color = idleColor;
        }
    }

    private IEnumerator ResetColorOnAudioCompleted()
    {
        yield return new WaitForSeconds(myAudioSource.clip.length);
        myRenderer.material.color = idleColor;

    }
}
