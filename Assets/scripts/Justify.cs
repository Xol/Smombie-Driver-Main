using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Justify : MonoBehaviour {
    // Automatically put the car the right way up, if it has come to rest upside-down.
    [SerializeField] private float m_WaitTime = 3f;           // time to wait before self righting
    [SerializeField] private float m_VelocityThreshold = 1f;  // the velocity below which the car is considered stationary for self-righting

    private float m_LastOkTime; // the last time that the car was in an OK state
    private CharacterController player;

    // Use this for initialization
    void Start () {
        player = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        // is the car is the right way up
        if (transform.forward.y > 0f)
        {
            m_LastOkTime = Time.time;
        }

        if ((Time.time > m_LastOkTime + m_WaitTime) && !Input.anyKey)
        {
            JustifyCar();
        }
    }

    // put the car back the right way up:
    private void JustifyCar()
    {
        int angle = (int)transform.rotation.eulerAngles.y;
        // Rotate Left
        if ( angle > 0 )
        {
            // Rotate Right
            if ( angle > 30)
            {
                transform.RotateAround(transform.position, Vector3.up, 1);
            }
            else
            {
                transform.RotateAround(transform.position, Vector3.up, -1);
            }
        }   
    }
}
