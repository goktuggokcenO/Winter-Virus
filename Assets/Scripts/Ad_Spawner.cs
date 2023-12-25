// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ad spawner script
public class Ad_Spawner : MonoBehaviour
{
    // Veriables
    public GameObject adPrefeb;

    // Update function
    void Update()
    {
        // Create and example ad
        if (Input.GetKeyDown("f"))
        {
            Instantiate(adPrefeb, new Vector3(0, 2, 0), Quaternion.identity);
        }
    }
}
