using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 endPosition;

    [SerializeField]
    private bool backAndForward = false;
    [SerializeField]
    private float speed = 1;
    private Vector3 direction;

	// Use this for initialization
	void Start ()
    {
        startPosition = this.transform.position;
        endPosition = this.transform.position;
        endPosition.x *= -1;

        direction = endPosition - startPosition;
        direction.Normalize();
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Player is close enough
        if (true)
        {
            // Moving to the right
            if ((direction.x < 0 && this.transform.position.x > endPosition.x) ||
                (direction.x > 0 && this.transform.position.x < endPosition.x))
            {
                this.transform.position += direction * speed;
            }
            else
            {
                this.transform.position = endPosition;

                if (backAndForward)
                {
                    endPosition.x *= -1;
                    direction *= -1;
                }
            }
        }
    }
}
