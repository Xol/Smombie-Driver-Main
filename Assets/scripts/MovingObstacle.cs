using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    private MovementStrategy ms;

    [SerializeField]
    private float speed = 1;
    [SerializeField]
    private float acceleration = 1;

    // Use this for initialization
    void Start ()
    {
        switch (tag)
        {
            case "Obstacle - Stationary":
                ms = new StationaryStrategy(transform);
                break;
            case "Obstacle - Linear":
                ms = new LinearStrategy(transform, speed);
                break;
            case "Obstacle - Accelerate":
                ms = new AccelerateStrategy(transform, acceleration);
                break;
            case "Obstacle - Feint":
                ms = new FeintStrategy(transform);
                break;
            default:
                ms = new StationaryStrategy(transform);
                break;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Player is close enough
        if (true)
        {
            ms.MoveUpdate(Time.deltaTime);
        }
    }
}


/// <summary>
/// Movement Strategy
/// </summary>


public class MovementStrategy
{
    protected Vector3 startPosition;
    protected Vector3 endPosition;
    protected Vector3 direction;
    protected Transform transform;

    public MovementStrategy (Transform tf)
    {
        transform = tf;

        startPosition = transform.position;
        endPosition = transform.position;
        endPosition.x *= -1;

        direction = endPosition - startPosition;
        direction.Normalize();
    }

    public virtual void MoveUpdate (float deltaTime)
    {
        // Do Something...
    }
}

public class StationaryStrategy : MovementStrategy
{
    public StationaryStrategy(Transform transform)
        : base(transform)
    {

    }

    public override void MoveUpdate(float deltaTime)
    {
        // Do Nothing
    }
}

public class LinearStrategy : MovementStrategy
{
    protected float velocity;

    public LinearStrategy(Transform transform, float v)
        : base(transform)
    {
        velocity = v;
    }

    public override void MoveUpdate(float deltaTime)
    {
        if ((direction.x < 0 && transform.position.x > endPosition.x) ||
            (direction.x > 0 && transform.position.x < endPosition.x))
        {
            transform.position += direction * velocity * deltaTime;
        }
        else
        {
            transform.position = endPosition;
        }
    }
}

public class AccelerateStrategy : MovementStrategy
{
    protected float acceleration;
    protected float velocity;

    public AccelerateStrategy(Transform transform, float a)
        : base(transform)
    {
        acceleration = a;
        velocity = 0;
    }

    public override void MoveUpdate(float deltaTime)
    {
        if ((direction.x < 0 && transform.position.x > endPosition.x) ||
            (direction.x > 0 && transform.position.x < endPosition.x))
        {
            velocity += acceleration * deltaTime;
            transform.position += direction * velocity * deltaTime;
        }
        else
        {
            transform.position = endPosition;
        }
    }
}

public class FeintStrategy : MovementStrategy
{
    public FeintStrategy(Transform transform)
        : base(transform)
    {

    }

    public override void MoveUpdate(float deltaTime)
    {
        // Do Nothing
    }
}