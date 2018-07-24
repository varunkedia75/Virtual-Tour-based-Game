///<header>
///Module:            pauseMenu
///Date of Creation : 11-04-18
///Author:			  Mukul Verma
///Modification history: 
///     11-04-18  :  Created module and functionality of pause Menu of the game.
///Synopsis:
///        This module loads the pause menu when the player presses the escape key.
///Global Variable:
///        public Transform Player;
///        public Transform Canvas;
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


public class pauseMenu : MonoBehaviour {

    //Declaration of Global variables from the unity studio
    public Transform Player;
    public Transform Canvas;                                                    //Unity canvas on which pause menu loads

    /// <summary>
    ///         load the instance first time when the scene loads.
    /// </summary>
    void Start()
    {
        Canvas.gameObject.SetActive(false);                                     //disable the canvas when the game starts
        
    }

    void Update()
    {
        //check if escape key is pressed or not
        if (Input.GetKeyDown(KeyCode.Escape))
        {   
            //check if canvas is active or not
            if (Canvas.gameObject.activeInHierarchy == false)
            {
                Canvas.gameObject.SetActive(true);
                Time.timeScale = 0;                                             // stop the time 
                Player.GetComponent<CharacterController>().enabled = false;     //disable the player controller
            }
            else
            {
                Canvas.gameObject.SetActive(false);
                Time.timeScale = 1;                                             //start the time
                Player.GetComponent<CharacterController>().enabled = true;      //enable the player controller
            }
        }
    }

    /// <summary>
    ///         resume and disable the canvas.
    /// </summary>
    public void resumeGame()
    {
        Canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        Player.GetComponent<CharacterController>().enabled = true;
    }

    /************* END OF CLASS ***********/
}
