using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFinisher : MonoBehaviour
{

    public TimerController timeControl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FinishPoint"))
        {
            Debug.Log("finished");
            timeControl.EndTimer();
        }
    }
}
