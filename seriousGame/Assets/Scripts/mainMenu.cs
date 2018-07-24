///<header>
///Module:            MainMenu
///Date of Creation : 15-04-18
///Author:			  Mukul Verma
///Modification history: 
///     15-04-18  :  Created module and functionality of main menu of the game.
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


public class mainMenu : MonoBehaviour {

    /// <summary>
    ///         Load the instance for the first time when screen loads.
    /// </summary>
    void Start()
    {
       restart.resume = false;                                                 
    }

    /// <summary>
    ///         Start a new game.
    /// </summary>
    public void newGame()
    {
        restart.resume = false;                                 //set the resume variable of restart module = false so that new game.
        SceneManager.LoadScene(0);                              // load the new game scene ( i.e. scene 0 )
        Time.timeScale = 1;                                     //start the time.
    }
    
    /// <summary>
    ///         opens the control menu
    /// </summary>
    public void controlMenu()
    {
        SceneManager.LoadScene(3);                              
    }

    public void training()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1;
    }
    /************* END OF CLASS ***********/
}
