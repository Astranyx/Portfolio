using UnityEngine;

public class CharacterControllerMovement : MonoBehaviour
{
    // Character Controller Component
    CharacterController controller;

    // Movement and Velocity vectors of the player
    Vector3 move;
    Vector3 velocity;

    // Transform component of our "ground checking" game object
    Transform groundChecker;

    // movement speed
    float speed = 5.0f;

    // gravity constant (following Earth's gravity)
    float gravity = -9.8f;

    // jump height
    float jumpHeight = 2f;

    // distance from the ground to check if we're in the air
    float groundDistance = 0.2f;

    // The layer that the ground is on
    public LayerMask ground;

    // Boolean to check if we're on the ground
    bool isGrounded = true;

	// Use this for initialization
	void Start ()
    {
        // set ground checker to be the transform component of the 0th child on our game object
        groundChecker = transform.GetChild(0);
        // grab our character controller component
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Not needed, but nice to see which direction we're facing for testing
        Debug.DrawRay(transform.position, transform.forward, Color.red);

#region jumping
        isGrounded = Physics.CheckSphere(groundChecker.position, groundDistance, ground, QueryTriggerInteraction.Ignore);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }
        #endregion

#region moving
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        velocity.y += gravity * Time.deltaTime;
        controller.Move(move * Time.deltaTime * speed);
        
        if (move != Vector3.zero)
        {
            transform.forward = move;
        }
        #endregion

#region remaining calculations
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        controller.Move(velocity * Time.deltaTime);
#endregion

    }
}