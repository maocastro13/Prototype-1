using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string inputID;

    private float speed = 20.0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal" + inputID);
        forwardInput = Input.GetAxis("Vertical" + inputID);
        // Moves the car forward based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // Rotates the car based on horizontal input
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Vehicle"))
        {
            Debug.Log("mirame aqui");
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
    }
}
