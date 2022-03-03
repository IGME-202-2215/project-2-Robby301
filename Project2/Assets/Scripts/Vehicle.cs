using UnityEngine;
using UnityEngine.InputSystem;

public class Vehicle : MonoBehaviour
{
    public Camera gameCamera;
    private float cameraWidth;
    private float cameraHeight;

    public GameObject bullets;

    public Vector3 vehiclePosition = Vector3.zero;
    public Vector3 direction = Vector3.right;
    public Vector3 velocity = Vector3.zero;
    public Vector3 acceleration = Vector3.zero;

    public float maxSpeed;
    public float accelerationRate;
    public float decelerationRate;

    // The amount of turning each frame
    public float turnSpeed;

    public Vector2 playerInput;

    // Start is called before the first frame update
    void Start()
    {
        cameraHeight = gameCamera.orthographicSize;
        cameraWidth = cameraHeight * gameCamera.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        // Vehicle Wraps Around the Game Scene (using the camera height and width)
        if (vehiclePosition.x > cameraWidth)
        {
            vehiclePosition.x = -cameraWidth;
        }
        else if (vehiclePosition.x < -cameraWidth)
        {
            vehiclePosition.x = cameraWidth;
        }

        if (vehiclePosition.y > cameraHeight)
        {
            vehiclePosition.y = -cameraHeight;
        }
        else if (vehiclePosition.y < -cameraHeight)
        {
            vehiclePosition.y = cameraHeight;
        }

        // Player Inputs
        if (playerInput.x > 0)
        {
            direction = Quaternion.Euler(0, 0, (-turnSpeed * Time.deltaTime)) * direction;
        }
        if (playerInput.x < 0)
        {
            direction = Quaternion.Euler(0, 0, (turnSpeed * Time.deltaTime)) * direction;
        }
        if (playerInput.y > 0)
        {
            acceleration = direction * accelerationRate;
        }
        if(playerInput.y <= 0)
        {
            velocity *= decelerationRate;
        }

        // Calc how fast to move
        velocity += (acceleration * Time.deltaTime);

        // Limit velocity to max speed
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        
        // Calc new position
        vehiclePosition += (velocity * Time.deltaTime);

        //Apply the movement to the GameObjects
        transform.position = vehiclePosition;

        // Rotate sprite to face direction
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
    }

    public void OnMove(InputValue value)
    {
        playerInput = value.Get<Vector2>();
    }

    public void OnFire(InputValue value)
    {
        GameObject bullet = Instantiate(bullets);
        bullet.transform.position = vehiclePosition;
    }
}