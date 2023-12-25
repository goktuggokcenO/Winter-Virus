// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Go to menu
public class Menu : MonoBehaviour
{
    // Go to menu
    public void GoMenu()
    {
        SceneManager.LoadSceneAsync("Menu");
    }
}
