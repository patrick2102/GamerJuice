using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SwordController : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    float distFromPlayer;
    [SerializeField] bool debugMode = false;
    [SerializeField] Rigidbody2D rb;

    [SerializeField] float speed;
    [SerializeField] float slowDownRadius;
    [SerializeField] float stopRadius;

    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] Transform playerTransform;
    [SerializeField] PlayerForwardController pfc;
    Vector3 lastVelocity;


    // Start is called before the first frame update
    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        if (playerTransform == null)
        {
            playerTransform = transform.parent;
        }
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        if (pfc == null)
        {
            pfc = GetComponentInParent<PlayerForwardController>();
        }

        distFromPlayer = (playerTransform.position - transform.position).magnitude;

        Physics.IgnoreCollision(playerRb.GetComponent<Collider>(), GetComponent<Collider>());

    }

    // Update is called once per frame
    void Update()
    {
        //MoveSword();

    }

    void FixedUpdate()
    {
        MoveSword();
    }

    void MoveSword()
    {
        //Convert rigidbody velocity to 3D vector
        var velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);

        //Apply force to the player if the sword hits a surface.
        var leftOverVelocity = (velocity - lastVelocity) * 0.5f;
        playerRb.AddForce(leftOverVelocity, ForceMode2D.Impulse);




        // Vector from player mouse. Used for calculating the target position for the sword.
        var playerToMouse = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        playerToMouse.z = 0.0f;
        playerToMouse -= playerTransform.position;
        playerToMouse = playerToMouse.normalized * distFromPlayer;


        // The target is the vector from the sword to the mouse.
        // Defined as the vector from the sword endpoint at the next frame, to the vector towards the mouse position.

        //The position of the sword tip at the next frame
        var fromPos = transform.position + velocity * Time.deltaTime;
        //var fromPos = transform.position;

        //The position of the end of movement
        var targetPos = playerToMouse + playerTransform.position;

        var towards = speed * (targetPos - fromPos).normalized;
        var dist = (targetPos - fromPos);

        // Slowdown is the 
        var slowdown = velocity * (1 - math.min(dist.magnitude / slowDownRadius, 1));

        var movement = (towards - slowdown) * Time.deltaTime;
        //var movement = towards;
        //movement += 

        //movement += addVelocity;
        //rbody.AddForce(addVelocity);
        //movement += playerRb.velocity;
        //movement += playerRb.velocity;
        //rb.velocity = playerRb.velocity;


        if ((playerToMouse + playerTransform.position - transform.position).magnitude < stopRadius)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            //Vector2 addVelocity = new Vector2(pfc.topSpeed, 0f);
            //rb.AddForce(movement, ForceMode2D.Impulse);
            Vector3 addVelocity = new Vector2(pfc.topSpeed, 0f);
            rb.AddForce(addVelocity);
            rb.AddForce(movement, ForceMode2D.Impulse);
            //rb.AddForce(movement);
            //rb.AddForce(addVelocity);

        }

        lastVelocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);

        var angle = Vector2.SignedAngle(Vector2.right, new Vector2(transform.localPosition.x, transform.localPosition.y).normalized);

        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (debugMode)
        {
            Debug.DrawLine(playerTransform.position, playerToMouse + playerTransform.position, Color.red);
            Debug.DrawLine(transform.position, playerToMouse + playerTransform.position, Color.yellow);
            Debug.DrawLine(playerTransform.position, leftOverVelocity + playerTransform.position, Color.green);
            //Debug.Log("mousePos: " + mousePos);
            //Debug.Log("toMouseVec: " + toMouseVec);
            //Debug.Log("newPos: " + newPos);
            //Debug.Log("Angle: " + angleDiff);
            //Debug.Log("Torque: " + torque);
            //Debug.Log("forward: " + transform.forward);

            //Debug.Log("Slowdown: " + slowdown);
            //Debug.Log("Target: " + towardsTarget);
            //Debug.Log("Movement: " + speed);
            //Debug.Log("Velocity: " + velocity);
            if (math.abs(velocity.y) > math.abs(velocity.x) && velocity.magnitude > 10.0f)
            {
                Debug.Log("Parry");
            }
        }
    }

    void MoveSwordV2()
    {

    }
}
