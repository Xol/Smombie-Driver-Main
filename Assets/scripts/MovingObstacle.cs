using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    private MovementStrategy ms;
    private GameObject player;

    [SerializeField]
    private float movementUpdateDistance = 15;
    [SerializeField]
    private float velocity = 1;

    [Header("Accelerting and Feinting Obstacle")]
    [SerializeField]
    private float acceleration = 1;
    [SerializeField]
    private float movementTriggerDistance = 5;

    // Use this for initialization
    void Start ()
    {
        switch (tag)
        {
            case "Obstacle - Stationary":
                ms = new StationaryStrategy(transform);
                break;
            case "Obstacle - Linear":
                ms = new LinearStrategy(transform, velocity);
                break;
            case "Obstacle - Accelerate":
                ms = new AccelerateStrategy(transform, velocity, acceleration, movementTriggerDistance);
                break;
            case "Obstacle - Feint":
                ms = new FeintStrategy(transform, velocity, acceleration, movementTriggerDistance);
                break;
            default:
                ms = new StationaryStrategy(transform);
                break;
        }

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update ()
    {
        // Player is close enough
        if ((player.transform.position - transform.position).magnitude < movementUpdateDistance)
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

    protected bool updateMovement;

    public MovementStrategy (Transform tf)
    {
        transform = tf;

        startPosition = transform.position;
        endPosition = transform.position;
        endPosition.x *= -1;

        direction = endPosition - startPosition;
        direction.Normalize();

        updateMovement = true;
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
        if (updateMovement)
        {
            if ((direction.x < 0 && transform.position.x > endPosition.x) ||
                (direction.x > 0 && transform.position.x < endPosition.x))
            {
                transform.position += direction * velocity * deltaTime;
            }
            else
            {
                transform.position = endPosition;
                updateMovement = false;
            }
        }
    }
}

public class AccelerateStrategy : MovementStrategy
{
    protected float acceleration;
    protected float velocity;
    protected float distance;

    protected GameObject player;

    public AccelerateStrategy(Transform transform, float v, float a, float d)
        : base(transform)
    {
        velocity = v;
        acceleration = a;
        distance = d;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void MoveUpdate(float deltaTime)
    {
        if (updateMovement)
        {
            bool moveLeft = direction.x < 0 && transform.position.x > endPosition.x;
            bool moveRight = direction.x > 0 && transform.position.x < endPosition.x;

            if (moveLeft || moveRight)
            {
                if ((player.transform.position - transform.position).magnitude < distance)
                {
                    transform.position += direction * velocity * deltaTime * acceleration;
                }
                else
                {
                    transform.position += direction * velocity * deltaTime;
                }
            }
            else
            {
                transform.position = endPosition;
                updateMovement = false;
            }
        }
    }
}

public class FeintStrategy : MovementStrategy
{
    protected float acceleration;
    protected float velocity;
    protected float distance;

    protected GameObject player;

    protected bool changedDirection;

    public FeintStrategy(Transform transform, float v, float a, float d)
        : base(transform)
    {
        velocity = v;
        acceleration = a;
        distance = d;

        player = GameObject.FindGameObjectWithTag("Player");

        changedDirection = false;
    }

    public override void MoveUpdate(float deltaTime)
    {
        if (updateMovement)
        {
            bool moveLeft = direction.x < 0 && transform.position.x > endPosition.x;
            bool moveRight = direction.x > 0 && transform.position.x < endPosition.x;

            if (moveLeft || moveRight)
            {
                if (!changedDirection && (player.transform.position - transform.position).magnitude < distance)
                {
                    changedDirection = true;

                    velocity *= acceleration;
                    endPosition = startPosition;
                    direction *= -1;
                }

                transform.position += direction * velocity * deltaTime;
            }
            else
            {
                transform.position = endPosition;
                updateMovement = false;
            }
        }
    }
}