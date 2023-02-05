using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 



public class MenuController : MonoBehaviour
{
    //This is the script for the MainMenu Scene
    //Will have a filler variable for GD to replace when in master file

    public string exitScreen = "exitScreen";
    public string howToScreen = "howToScreen";
    public string optionsScreen = "optionsScreen";
    public string playScreen = "playScreen";

    [Header("MainScreen Buttons")]
    public Button exitButton;
    public Button howToButton;
    public Button optionsButton; 
    public Button playButton; 



    //This function will be for the Exit Button
    public void exitGame()
    {
        Application.Quit();
    }

    //This function will be for the How-To Button
    public void goToHowTo()
    {
        SceneManager.LoadScene("HowTo");
        Debug.Log("This button has taken you to the how to screen");
    }

    //This function will be for the Options Button 
    public void goToOptions()
    {
        SceneManager.LoadScene("optionsScreen");
        Debug.Log("This button has taken you to the options screen");
    }

    //This function will be the play Button
    public void playGameButton()
    {
        SceneManager.LoadScene("Menu Scene");
        Debug.Log("This button will take you to the join/create room screen");
    }

}
