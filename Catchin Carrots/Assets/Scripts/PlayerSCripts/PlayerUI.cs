using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerUI : MonoBehaviour
{

    public TextMeshProUGUI promptText;

    private PlayerController player;
    public static PlayerUI instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        //promptText = GameObject.Find("Prompts").GetComponent<TextMeshProUGUI>();
        //Debug.Log("Awake assigns"+ promptText);
    }

    public void Initialize(PlayerController localPlayer)
    {
        player = localPlayer;
        //if(player.IsFarmer)
            //localPlayer.gameObject.GetComponent<FarmerInteract>().playerUI = this;
       // else
            //localPlayer.gameObject.GetComponent<CarrotsInteract>().playerUI = this;
        
    }

    public void UpdateText(string promptMessage)
    {
        //promptText = GameObject.Find("Prompts").GetComponent<TextMeshProUGUI>();
        //Debug.Log(promptMessage);
        //Debug.Log(promptText);
        //promptText.text= "Hi";
        //Debug.Log(promptText.text);
        promptText.text = promptMessage;
    }
}
