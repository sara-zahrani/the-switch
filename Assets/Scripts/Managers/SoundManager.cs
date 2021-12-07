using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip mPlatformFall;
    public AudioClip mSwitchSound;
    public AudioClip mEndLevelSound;
    public AudioClip mJumpSound;
    public AudioClip mSwitchPlatform;
    public AudioClip mFailSound;


    private AudioSource mAudioSource;

    private void Start()
    {
        mAudioSource = GetComponent<AudioSource>();
    }

    public void MakePlatformFalltSound()
    {
        mAudioSource.PlayOneShot(mPlatformFall);
    }

    public void MakeSwitchPlatformSound()
    {
        Debug.Log("peep");
        mAudioSource.PlayOneShot(mSwitchPlatform);
    }

    public void MakeSwitchSound()
    {
        mAudioSource.PlayOneShot(mSwitchSound);
    }

    public void MakeEndLevelSound()
    {
        mAudioSource.PlayOneShot(mEndLevelSound);
    }

    public void MakeFailSound()
    {
        mAudioSource.PlayOneShot(mFailSound);
    }

    public void MakeJumpSound()
    {
        mAudioSource.PlayOneShot(mJumpSound);
    }

    void Update()
    {
        
    }
}
