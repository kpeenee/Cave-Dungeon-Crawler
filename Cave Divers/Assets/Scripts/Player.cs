using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float mouseSensitivity = 1000f;
    [SerializeField] float moveSpeed = 12f;
    [SerializeField] Transform cam;

    CharacterController control;
    private float xRotation = 0f;

    private void Awake()
    {
        control = GetComponent<CharacterController>();
    }
    void Update()
    {
        PlayerLook();
        Move();
    }

    private void Move()
    {
        float xMov = Input.GetAxis("Horizontal");
        float yMov = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * xMov + transform.forward * yMov;

        control.Move(movement * moveSpeed * Time.deltaTime);
    }

    private void PlayerLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        cam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
