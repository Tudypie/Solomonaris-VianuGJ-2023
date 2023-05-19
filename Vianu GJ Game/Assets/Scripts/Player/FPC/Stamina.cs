using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    [SerializeField] private float stamina = 100.0f;
    [SerializeField] private float currStamina;

    [Space]

    [SerializeField] private float decreaseMultiplier = 7.5f;
    [SerializeField] private float increaseMultiplier = 9f;

    [Space]

    [SerializeField] private float tiredMark = 50.0f;

    [Space]

    [SerializeField] private Image staminaImage;
    [SerializeField] private AudioSource breathingSound;

    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController player;

    private float initialRunSpeed;
    
    
    void Start()
    {
        player = GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();

        currStamina = stamina;

        initialRunSpeed = player.RunSpeed;
    }

  
    void Update()
    {   
        float staminaAlpha = Mathf.Min((tiredMark - currStamina)/30, 0.6f);

        breathingSound.volume = Mathf.Min(1 - currStamina/30, 0.28f);

        staminaImage.color = new Color(0, 0, 0, staminaAlpha);

        if (currStamina < 40)
        {
            player.RunSpeed -= 0.3f * Time.deltaTime;
        }
        else if(currStamina > 40)
        {
            player.RunSpeed = Mathf.Min(player.RunSpeed + 1 * Time.deltaTime, initialRunSpeed);
        }
        
        if (player.IsWalking)
        {
            currStamina = Mathf.Min(currStamina + Time.deltaTime * increaseMultiplier, stamina);
            return;
        }
        
        currStamina = Mathf.Max(currStamina - Time.deltaTime * decreaseMultiplier, 0);
    }

}
