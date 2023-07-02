using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller; 
    public Camera cam;
    public Transform camTrans;

    float speed; 
    float turnSmoothTime = 0.1f; 
    float turnSmoothVelocity;

    Vector3 velocity;

    bool isRunning;

    public void isRunningOrWalking()
    {
        isRunning = Input.GetKey(KeyCode.LeftShift);

        if (isRunning == true)
        {
            speed = 18f;
           // animator.SetBool("isRunning", true); //toggles running animation
           // animator.SetBool("isWalking", false);
        }
        else
        {
            speed = 10f;
            //animator.SetBool("isWalking", true); //toggles walking animation
           // animator.SetBool("isRunning", false);
        }
    }

    void isPlayerMoving()
    {
        //movement code
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        
        // multiplying by Time.deltatime twice due to gravity equation being sqaured
        if (!controller.isGrounded)
        {
            velocity.y += Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            velocity.y = -2f;
        }

        //Camera System
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camTrans.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDirection * speed * Time.deltaTime); //takes the "move" Vector3 for a controller.Move. Multiplies it by speed and time.DeltaTime.
        }
        controller.Move(velocity * Time.deltaTime);
    }
    void Update()
    {
        isRunningOrWalking();
        isPlayerMoving();
    }
}

