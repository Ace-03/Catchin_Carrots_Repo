using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HowTo : MonoBehaviour
{
    
    public Button returnToMainButton;
    //Temp placeholder variable for the MainScreen
    public string backToMain = "backToMain"; 


    //Function to take you back to the main playing screen
    public void returnToMenu()
    {
        SceneManager.LoadScene("MainScreen_Scene");
        Debug.Log("You have been taken back to the main menu");

    }
}
