///<header>
///Module:            restart
///Date of Creation : 15-04-18
///Author:			  Mukul Verma
///Modification history: 
///     15-04-18  :  Created module and functionality to restart the game from the point player saved it.
///Synopsis:
///        This module restarts the saved game.
///Global Variable:
///         public static bool resume
///Functions:
///        public void loadScene(string name)
///</header>


//imports required from the UnityEngine module.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class restart : MonoBehaviour {

    //Declaration of Global variables 
    public static bool resume = false;

    /// <summary>
    ///         set the checkPreviousDestination bool of destination module and resume = true 
    ///         to Load the game from the instance player saved it in the database (i.e. PlayerPrefs)
    /// </summary>
    /// <param name="name"></param>
    public void loadScene(string name)
    {
        destination.checkPreviousDestination = true;
        resume = true;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    /************* END OF CLASS ***********/
}
