using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

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

    Vector3 speed;


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

        float mouseAngle = Vector3.SignedAngle(Vector3.right, playerToMouse, Vector3.forward);

        var playerToSword = transform.position - playerTransform.position;
        playerToSword.z = 0.0f;
        playerToSword = playerToMouse.normalized;

        var playerAngle = Vector3.SignedAngle(Vector3.right, playerToSword, Vector3.forward);

        float angleDiff = playerAngle - mouseAngle;

        var torque = Mathf.Deg2Rad * angleDiff * rb.inertia;

        rb.AddTorque(torque, ForceMode2D.Impulse);


        //var torque = angle * acceleration * Time.deltaTime;
        //var torque = Mathf.Deg2Rad * angle * rb.inertia;

        //rb.AddTorque(torque, ForceMode2D.Impulse);


        //rb.

        /*
        if (target.magnitude > slowDownRadius)
        {
            var movemennt = target * acceleration * Time.deltaTime;
        } 
        else
        { 
            var movement = 
        
        }
        */


        //var movement = math.min(target.magnitude / slowDownRadius, 1.0f) * target * acceleration * Time.deltaTime;

        //var movement = 

        //rb.AddForce(movement);


        //transform.position = newPos;
        //transform.rotation = Quaternion.Euler(0, 0, angle);
        if (debugMode)
        {
            Debug.DrawLine(playerTransform.position, playerToMouse + playerTransform.position, Color.red);
            Debug.DrawLine(transform.position, playerToMouse + playerTransform.position, Color.yellow);
            //Debug.Log("mousePos: " + mousePos);
            //Debug.Log("toMouseVec: " + toMouseVec);
            //Debug.Log("newPos: " + newPos);
            Debug.Log("Angle: " + angleDiff);
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
