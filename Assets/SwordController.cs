using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SwordController : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] Transform playerTransform;
    float distFromPlayer;
    [SerializeField] bool debugMode = false;
    [SerializeField] Rigidbody2D rb;


    [SerializeField] float acceleration;
    [SerializeField] float slowDownRadius;
    [SerializeField] float stopRadius;
    [SerializeField] float maxSpeed;
    [SerializeField] float maxRotationSpeed = 0.25f;

    [SerializeField] float slowDownLimitTorque;
    [SerializeField] float rotationAcceleration;


    Vector3 speed;
    float rotation;
    float rotationBuffer = 0.0f;

    [SerializeField] Rigidbody2D playerRb;
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

        distFromPlayer = (playerTransform.position - transform.position).magnitude;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //Debug.Log("mouse position: " + mainCamera.ScreenToWorldPoint(Input.mousePosition));
        //transform.


        MoveSwordV1();

        //MoveSwordV1(newPos);

    }

    void MoveSwordV1Simple()
    {
        var mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0.0f;

        var toMouseVec = mousePos - playerTransform.position;
        toMouseVec.z = 0.0f;

        var newPos = (toMouseVec / toMouseVec.magnitude) * distFromPlayer;
        newPos += playerTransform.position;

        float angle = Vector3.Angle(Vector3.right, toMouseVec);
        if (toMouseVec.y < 0.0f)
        {
            angle = -angle;
        }

        transform.position = newPos;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        if (debugMode)
        {
            Debug.DrawLine(playerTransform.position, newPos, Color.red);
            //Debug.Log("mousePos: " + mousePos);
            //Debug.Log("toMouseVec: " + toMouseVec);
            //Debug.Log("newPos: " + newPos);
            //Debug.Log("Angle: " + angle);
            //Debug.Log("forward: " + transform.forward);
        }
    }

    void MoveSwordV1()
    {
        var playerToMouse = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        playerToMouse.z = 0.0f;

        playerToMouse = (playerToMouse - playerTransform.position);
        playerToMouse.z = 0.0f;

        playerToMouse = playerToMouse.normalized * distFromPlayer;

        //float angle = Vector3.Angle(Vector3.right, playerToMouse);
        //float angle = Vector3.SignedAngle(Vector3.right, playerToMouse, Vector3.forward);
        //if (playerToMouse.y < 0.0f)
        //{
            //angle = -angle;
        //}

        var velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);

        var leftOverVelocity = (velocity - lastVelocity);

        playerRb.AddForce(leftOverVelocity, ForceMode2D.Impulse);



        //var target = (playerToMouse - transform.position) + playerTransform.position;
        var target = playerToMouse - (transform.position + velocity * Time.deltaTime) + playerTransform.position; 

        //if (toPlayer)

        //var slowDown = math.clamp(target-slowDown)

        var towardsTarget = target * acceleration * Time.deltaTime;

        //var slowdown = momentum * math.min((target.magnitude - slowDownRadius) / slowDownRadius, 0) * 100;
        //var slowdown = momentum.magnitude * math.min((target.magnitude - slowDownRadius) / slowDownRadius, 1);
        //var slowdown = math.min(target.magnitude / slowDownRadius, 1);

        //var slowdown = momentum * (1 - math.min(target.magnitude / slowDownRadius, 1));
        var slowdown = velocity * (1 - math.min(target.magnitude / slowDownRadius, 1));

        //speed = towardsPlayer - slowdown;

        //speed = towardsPlayer * slowdown;
        speed = towardsTarget - slowdown;

        if (velocity.magnitude > 0.1f)
            Debug.Log("rara");

        if (speed.magnitude > maxSpeed)
        {
            speed = speed.normalized * maxSpeed;
        }

        if (target.magnitude < stopRadius)
        {
            rb.velocity = Vector2.zero;
        } 
        else
        {
            rb.AddForce(speed, ForceMode2D.Impulse);
        }

        lastVelocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);

        //Debug.Log("velocity change: " + newVelocity);

        var playerToSword = transform.position - playerTransform.position;
        playerToSword.z = 0.0f;
        playerToSword = playerToMouse.normalized;

        /// var playerAngle = Vector3.Angle(Vector3.right, playerToMouse.normalized, Vector3.forward);
        //var playerAngle = Vector3.Angle(Vector3.right, playerToMouse.normalized, V);
        var mouseAngle = Vector2.Angle(Vector2.right, new Vector2(playerToMouse.x, playerToMouse.y).normalized);
        var swordAngle = transform.rotation.eulerAngles.z;

        //var angleDiff = Vector2.Angle(transform.right, new Vector2(playerToMouse.x, playerToMouse.y).normalized) * Mathf.Deg2Rad;

        //Debug.Log("sword angle: " + swordAngle);
        //Debug.Log("anglediff 2: " + angleDiff2);

        /*
        if (swordAngle < 0.0f)
        { 
            swordAngle = (180.0f + swordAngle );
        }
        */
        //transform.rotation.


        //Debug.Log("mouse angle: " + playerAngle);
        //Debug.Log("sword angle: " + swordAngle);

        //float angleDiff2 = (mouseAngle - swordAngle) * Mathf.Deg2Rad;
        //angleDiff = math.abs(angleDiff);


        //Debug.Log("Angle diff: "+ angleDiff);

        /*
        var torque = angleDiff2 * rb.inertia * rotationAcceleration;
        var slowdownTorque = rb.angularVelocity * (1 - math.min(math.abs(angleDiff2) / slowDownLimitTorque, 1));
        torque -= slowdownTorque;

        torque *= Time.deltaTime;
        torque = math.clamp(torque, -maxRotationSpeed, maxRotationSpeed);
        */
        //Debug.Log("Slow down torque: " + slowdownTorque);



        //rb.AddTorque(torque, ForceMode2D.Impulse);

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
