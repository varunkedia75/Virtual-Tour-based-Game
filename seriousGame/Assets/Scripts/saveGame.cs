//<header>
///Module:            saveGame
///Date of Creation : 10-04-18
///Author:			  Mukul Verma
///Modification history: 
///     10-04-18  :  Created module and functionality of main menu of the game.
///Synopsis:
///        This module loads the main menu and player can start a new game or resume or change controls from here.
///Global Variable:
///        NONE
///Functions:
///        void Update()
///        public void newGame()
///        public void controlMenu()
///</header>


//imports required from the UnityEngine module.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class saveGame : MonoBehaviour {

    //Declaration of Global variables from the unity studio
    public Transform Player;

    /// <summary>
    ///         save the data of the save like time , position of player, etc. when player presses the quit button.
    /// </summary>
    /// <param name="Quit"></param>
    public void saveGameSettings(bool Quit)
    {   
        PlayerPrefs.SetFloat("positionX", Player.transform.position.x);                     //store the 'x' coordinate of player position.
        PlayerPrefs.SetFloat("positionY", Player.transform.position.y);                     //store the 'y' coordinate of player position.
        PlayerPrefs.SetFloat("positionZ", Player.transform.position.z);                     //store the 'z' coordinate of player position.
        PlayerPrefs.SetFloat("time", timer.timeLeft);                                       //store the time left in the game at te time user quits.

        //check if user pressed the quit and save button or not
        if (Quit)
        {
            restart.resume = false;                                                         
            Time.timeScale = 0;                                                             //stops the game time
            SceneManager.LoadScene(2);                                                      //Load the main menu(i.e. scene 2)   
        }
        /************* END OF CLASS ***********/
    }

}
