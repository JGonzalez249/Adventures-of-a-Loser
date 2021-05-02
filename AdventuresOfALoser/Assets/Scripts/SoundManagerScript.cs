using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip JumpSound, CoinSound;
    static AudioSource audioSrc;

    void Start()
    {
        JumpSound = Resources.Load<AudioClip>("Jump");
        CoinSound = Resources.Load<AudioClip>("Coin");

        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "jump":
                audioSrc.PlayOneShot(JumpSound);
                break;
            case "coin":
                audioSrc.PlayOneShot(CoinSound);
                break;

        }
    }
}
