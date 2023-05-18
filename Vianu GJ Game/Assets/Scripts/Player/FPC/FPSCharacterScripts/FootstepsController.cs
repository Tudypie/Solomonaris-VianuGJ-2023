using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsController : MonoBehaviour
{
    [SerializeField] private AudioClip[] grassFootsteps;
    [SerializeField] private AudioClip[] woodFootsteps;

    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpc;

    private void Start()
    {
        fpc = GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
    }

    public void ChangeFootsteps(string surface)
    {   
        if(surface == "Wood")
        {
            for(int i =0; i < fpc.FootstepSounds.Length; i++)
                fpc.FootstepSounds[i] = woodFootsteps[i];
        }
        else if(surface == "Grass")
        {
            for(int i =0; i < fpc.FootstepSounds.Length; i++)
                fpc.FootstepSounds[i] = grassFootsteps[i];
        }

    }
}
