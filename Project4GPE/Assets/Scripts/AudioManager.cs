using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
    
{

    public AudioSource audioSource;
    public AudioClip doorOpeningClip;
    public AudioClip steamClip;
    public AudioClip jumpClip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {

    
        /* if (Input.GetKeyDown(KeyCode.A))
         {
             audioSource.clip = doorOpeningClip;
             audioSource.Play();
         }
         if (Input.GetKeyDown(KeyCode.S))
         {
             audioSource.clip = steamClip;
             audioSource.Play();
         }*/
        /*  if (Input.GetKeyDown(KeyCode.Space))
          {
              if (audioSource.isPlaying)
              {
                  audioSource.Pause();
              }
              else
              {
                  audioSource.UnPause();
              }

          }
          if (Input.GetKeyDown(KeyCode.D))
          {
              if (audioSource.isPlaying)
              {
                  audioSource.Stop();
              }
          }*/
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(steamClip, transform.position);
        Destroy(this.gameObject);
    }
}
