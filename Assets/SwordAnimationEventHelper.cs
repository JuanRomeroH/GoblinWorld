using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAnimationEventHelper : MonoBehaviour
{
    [SerializeField] FMODUnity.EventReference SwordSound; 
    public void SwordSoundEvent()
    {
        AudioManager.Instance.PlayOneShot(SwordSound, transform.position);
    }


}
