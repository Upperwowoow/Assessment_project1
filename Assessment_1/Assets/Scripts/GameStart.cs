using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public void StartGame()
    {
        //this is a game menu if the player press start it will jump into the game. 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
