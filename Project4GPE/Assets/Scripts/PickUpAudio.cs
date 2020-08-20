using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PickUpAudio : MonoBehaviour
{

    public AudioClip pickUpSoundEffect;
    [SerializeField] private int pointValue = 100;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(pickUpSoundEffect, transform.position);
            GameManager.instance.points += pointValue;
            Destroy(this.gameObject);
        }

    }



}
