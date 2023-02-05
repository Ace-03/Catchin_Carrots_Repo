using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 


public class ExitScreen : MonoBehaviour
{
    //This is the screen for the EndGame Scene
    //Can take the player to the beginning screen or out of the game

    //TEMP STRING VARIABLES
    //The first temp variable is for the MainScreen Scene
    public string playAgainScreen = "playAgain";
    public string exitTheGame = "exitGame";

    [Header("EndScreen Buttons")]
    public Button playAgainButton;
    public Button exitGameButton;





    //This function will take you back to the Join/Create room Scene
   //IMPLEMENT CORRECT BUILD INDEX
   public void returnToRoomScreen()
    {
        SceneManager.LoadScene("playAgainScreen");
        Debug.Log("You have loaded back to the join/Create screen");
    }

    //This function will take you back to the main menu screen 
    //IMPLEMENT CORRECT BUILD INDEX

    public void returnToMainMenu()
    {
        SceneManager.LoadScene("MainScreen_Scene");
        Debug.Log("You have loaded back to the main screen");
    }


}
