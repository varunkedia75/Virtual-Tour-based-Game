///<header>
///Module:            timer
///Date of Creation : 10-04-18
///Author:			  Mukul Verma
///Modification history: 
///     10-04-18  :  Created module and functionality to calculate the time of the game.
///Synopsis:
///        This module calculates the time left for the player to complete the task and show it on the screen.
///Global Variable:
///        public static float timeLeft
///        public Text time;
///Functions:
///        void Update()
///        void Start ()
///        private void GameOver()
///</header>


//imports required from the UnityEngine module.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour {

    //Declaration of Global variables.
    public static float timeLeft = 60.0f;
    public Text time;                                                               //Unity UI 2D text to show the time left.
    

    /// <summary>
    ///         Loads the instance for the first time when scene loads.
    /// </summary>
    void Start ()
    {
        time.text = "Time Left :" + timeLeft.ToString();
    }

    /// <summary>
    ///         Loads the instance once per frame.
    ///         Calculate the time left and show it on the screen.
    /// </summary>
    void Update()
    {       
        timeLeft -= Time.deltaTime;                                                  //decrease the time left
        database.timeLeft = timeLeft;                                                //save the time to database
        time.text = "Time Left :" + timeLeft.ToString();                             //show the time on the screen
        
        //check if time is finished or not
        if (timeLeft < 0)
        {
            GameOver();                                                              
        }
    }

    /// <summary>
    ///         Load the game over scene (i.e. scene 1)
    /// </summary>
    private void GameOver()
    {
        SceneManager.LoadScene(1);
    }
    /************* END OF CLASS ***********/
}
