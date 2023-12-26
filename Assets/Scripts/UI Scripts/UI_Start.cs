// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Start the game
public class Start : MonoBehaviour
{
    // Start game on click
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Level");
    }
}
