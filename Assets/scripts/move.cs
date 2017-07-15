using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField]
    private float velocity = 1;

    private Vector3 moveForward = new Vector3(0, 0, 10);
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Constant Movement
        GetComponent<CharacterController>().Move(transform.forward.normalized * Time.deltaTime * velocity);

        // Boost
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<CharacterController>().Move(transform.forward.normalized * Time.deltaTime * velocity);
        }

        // Break
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<CharacterController>().Move(transform.forward.normalized * Time.deltaTime * -1 / 2 * velocity);
        }

        int angle = (int)transform.rotation.eulerAngles.y;

        // Rotate Left
        if ((angle > 330 || angle <= 30) && Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(transform.position, Vector3.up, -1);
        }

        // Rotate Right
        if ((angle < 30 || angle >= 330) && Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(transform.position, Vector3.up, 1);
        }
    }
}
