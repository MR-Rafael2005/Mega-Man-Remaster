using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Start"))
        {
            Debug.Log("Started");
        }

        if (Input.GetButtonDown("Select"))
        {
            Debug.Log("Selected");
        }

        if (Input.GetButton("Jump"))
        {
            Debug.Log("Jumping");
        }

        if (Input.GetButtonDown("Shot"))
        {
            Debug.Log("Shooted");
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            Debug.Log(Input.GetAxis("Horizontal"));
        }

        if(Input.GetAxis("Vertical") != 0)
        {
            Debug.Log(Input.GetAxis("Vertical"));
        }
    }
}
