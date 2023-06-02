using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public string inputID;

    //private float speed = 20.0f;
    [SerializeField] private float horsePower = 0;
    [SerializeField] GameObject centerOfMass;

    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] float speed;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] float rpm;

    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    private const float turnSpeed = 45.0f;
    
    private float horizontalInput;
    private float forwardInput;
    
    private Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    private void Update()
    {
        speed = Mathf.Round(playerRb.velocity.magnitude * 2.237f);
        rpm = Mathf.Round((speed %30) * 40);
        speedometerText.SetText("Speed: " + speed + "mph");
        rpmText.SetText("RPM: " + rpm);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal" + inputID);
        forwardInput = Input.GetAxis("Vertical" + inputID);

         if (IsOnGround())
        {

            //Move the vehicle forward
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput );
            //Turning the vehicle
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

            //print speed
            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 2.237f);
            speedometerText.SetText("Speed: " + speed + " mph");

            //print RPM
            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.SetText("RPM: " + rpm);
        }
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround == 4)
        {
            return true;
        } else
        {
            return false;
        }
    }
    /*void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Vehicle"))
        {
            
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Debug.Log("gran");
                foreach (Transform child in transform)
                {
                    Debug.Log("h");
                    Rigidbody childRb = child.GetComponent<Rigidbody>();
                    if (childRb != null)
                    {
                        Debug.Log("p");
                        childRb.isKinematic = false; // Set "Is Kinematic" to false for the child obstacles
                        childRb.useGravity = true; // Enable gravity for the child obstacles
                    }
                }
            }
        }
    }*/
}
