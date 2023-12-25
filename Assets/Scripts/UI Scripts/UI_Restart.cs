// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Restart the schene when clicked on UI
public class Restart : MonoBehaviour
{
    // Restart game function
    public void RestartGame()
    {
        SceneManager.LoadSceneAsync("CityMap");
    }
}
