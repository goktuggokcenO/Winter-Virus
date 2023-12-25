// Libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ad manager script for things related to ads
public class AdManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Ensure the object is initially enabled
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast to check if the mouse click hits the object
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            // Check if the clicked object is the pop-up
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                // Destroy the pop-up object
                Destroy(gameObject);
            }
        }
    }
}
