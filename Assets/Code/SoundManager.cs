using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource audioSource;
    public AudioClip throwSound;
    public AudioClip hitSound;
    public AudioClip coinSound;
    public AudioClip deathSound;
    public AudioClip levelSound;
    public AudioClip bballThrowSound;
    public AudioClip bballHitSound;
    public AudioClip explodeSound;
    public AudioClip playerSound;
    public AudioClip golemSpawnSound;
    public AudioClip golemShootSound;
    public AudioClip wraithSpawnSound;
    public AudioClip wraithShootSound;
    public AudioClip gameOverSound;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySound(string type)
    {
        if (type == "throw")
        {
            audioSource.PlayOneShot(throwSound, 0.7f);
        }
        if (type == "death")
        {
            audioSource.PlayOneShot(deathSound, 0.5f);
        }
        if (type == "player")
        {
            audioSource.PlayOneShot(playerSound, 0.5f);
        }
        if (type == "hit")
        {
            audioSource.PlayOneShot(hitSound, 0.6f);
        }
        if (type == "coin")
        {
            audioSource.PlayOneShot(coinSound, 0.5f);
        }
        if (type == "level")
        {
            audioSource.PlayOneShot(levelSound, 0.5f);
        }
        if (type == "bball throw")
        {
            audioSource.PlayOneShot(bballThrowSound);
        }
        if (type == "bball hit")
        {
            audioSource.PlayOneShot(bballHitSound);
        }
        if (type == "explode")
        {
            audioSource.PlayOneShot(explodeSound, 0.7f);
        }
        if (type == "golem spawn")
        {
            audioSource.PlayOneShot(golemSpawnSound, 0.6f);
        }
        if (type == "golem shoot")
        {
            audioSource.PlayOneShot(golemShootSound, 0.4f);
        }
        if (type == "wraith spawn")
        {
            audioSource.PlayOneShot(wraithSpawnSound, 0.6f);
        }
        if (type == "wraith shoot")
        {
            audioSource.PlayOneShot(wraithShootSound, 0.5f);
        }
        if (type == "game over")
        {
            audioSource.PlayOneShot(gameOverSound, 0.6f);
        }

    }

    //public void PlaySoundMiss()
    //{
    //    audioSource.PlayOneShot(missSound);
    //}
}
