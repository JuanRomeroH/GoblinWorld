using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    [SerializeField] EventReference FootstepEvent;
    [SerializeField] float FootSoundRate;
    [SerializeField] float SprintFootSoundRate;
    [SerializeField] float WalkFootSoundRate;
    [SerializeField] GameObject player;
    [SerializeField] FirstPersonController controller;


    public static AudioManager Instance{ get; private set; }

    float time;

    public void PlayFootstep()
    {
        RuntimeManager.PlayOneShotAttached(FootstepEvent, player);
    }

    public void PlayOneShot(EventReference aSound, Vector3 aWorldPos)
    {
        RuntimeManager.PlayOneShot(aSound, aWorldPos);
    }


 
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (controller.isWalking)
        {
            if (controller.GetIsSprinting())
            {
                FootSoundRate = SprintFootSoundRate; 
                
            }
            else
            {
                FootSoundRate = WalkFootSoundRate; 
            }
            if (time >= FootSoundRate)
            {
                PlayFootstep();
                time = 0;
            }
        }
    }
    private void Awake()
    {
        if (Instance != null) 
        {
        }
            Instance = this;
    }
}
