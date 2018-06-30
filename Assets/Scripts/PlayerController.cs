using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float movementSpeed = 10;
    [SerializeField]
    private float rotationSpeed = 10;
    
    private Rigidbody myRigidBody;

    // Use this for initialization
    private void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("HorizontalRotation") * rotationSpeed * Time.deltaTime);
        transform.Translate(transform.forward * Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime, Space.World);
        transform.Translate(transform.right * Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime, Space.World);
    }

    // Update is called once per frame
    //private void FixedUpdate()
    //{
    //    float moveHorizontal = Input.GetAxis("Horizontal");
    //    float moveVertical = Input.GetAxis("Vertical");

    //    Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

    //    myRigidBody.AddForce(movement * movementSpeed);
    //}
}