using System;
using UnityEngine;
using Utilities;

public class AudioManager : AutoSingleton<AudioManager>
{
    [SerializeField] private AudioSource bulletAudioSource;
    [SerializeField] private AudioSource explosionAudioSource;
    [SerializeField] private AudioSource levelUpAudioSource;
    
    
    [SerializeField] private AudioClip bulletAudio;
    [SerializeField] private AudioClip explosionAudio;
    [SerializeField] private AudioClip levelUpAudio;


    public void PlayBulletAudio()
    {
        bulletAudioSource.PlayOneShot(bulletAudio);
    }
    
    
    public void PlayExplosionAudio()
    {
        explosionAudioSource.PlayOneShot(explosionAudio);
    }
    
    
    public void PlayLevelUpAudio()
    {
        levelUpAudioSource.PlayOneShot(levelUpAudio);
    }
}
