using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] float moveSpeed = 12f;
    [Header("Looking around")]
    [SerializeField] float mouseSensitivity = 1000f;
    [SerializeField] Transform cam;
   
    [SerializeField] float interactRange = 8f;
    [SerializeField] LayerMask isInteract;
    [Header("Ground Checking")]
    [SerializeField] Transform groundCheck;
    [SerializeField] float checkRadius = 0.01f;
    [SerializeField] LayerMask whatIsGround;
    

    CharacterController control;
    private float xRotation = 0f;
    private float gravity = -9.81f;
    private Vector3 fallVelocity;
    private bool isGrounded;

    IInteract currentInteract;

    private void Awake()
    {
        control = GetComponent<CharacterController>();
    }
    void Update()
    {
        PlayerLook();
        Move();
        
        UpdateCurrentInteract();
        if(currentInteract != null)
        {
            currentInteract.Display();
            if (Input.GetKeyDown(KeyCode.E))
            {
                currentInteract.Interact();
            }
        }

    }

    private void UpdateCurrentInteract()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, interactRange, isInteract))
        {
            currentInteract = hit.collider.GetComponent<IInteract>();
        }
        else
        {
            if(currentInteract != null)
            {
                currentInteract.UnDisplay();
            }
            currentInteract = null;
        }
    }

    private void Move()
    {
        //Check if grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, checkRadius, whatIsGround);
        //If grounded set fall velocity to small number 
        if(isGrounded == true && fallVelocity.y <= 0)
        {
            fallVelocity.y = -2f;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            fallVelocity.y = 5f;
            Debug.Log("Yes");
        }

        //Deal with WASD movement
        float xMov = Input.GetAxis("Horizontal");
        float yMov = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * xMov + transform.forward * yMov;

        control.Move(movement * moveSpeed * Time.deltaTime);

        //Falling
        fallVelocity.y += gravity * Time.deltaTime;
        control.Move(fallVelocity * Time.deltaTime);
    }

    private void PlayerLook()
    {
        //Get mouse movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Move Camera
        transform.Rotate(Vector3.up * mouseX);
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        cam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}
