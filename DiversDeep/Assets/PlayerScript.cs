using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("References")]
    public CharacterController controller;
    public Transform cameraTransform;

    [Header("Movement Settings")]
    public float moveSpeed = 2f;
    public float turnSpeed = 0.1f;

    private Vector3 velocity;
    public bool isUnderwater;

    private void Update()
    {
        CameraControl();

        //isUnderwater = CheckUnderwaterStatus();

        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));


        velocity = input.normalized * moveSpeed;

        velocity += Physics.gravity;

        transform.Translate(velocity * Time.deltaTime, Space.Self);

        controller.Move(new Vector3(0,0,0));
    }

    void CameraControl()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("RightJoystickHorizontal"), 0, Input.GetAxisRaw("RightJoystickVertical"));
        Vector3 velocity2 = input.normalized * turnSpeed;
        Debug.Log(velocity2);

        cameraTransform.rotation = Quaternion.Euler(cameraTransform.rotation.eulerAngles.x + velocity2.x, cameraTransform.rotation.eulerAngles.y, cameraTransform.rotation.eulerAngles.z);
        //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + velocity2.z, transform.rotation.z);
        controller.transform.Rotate(new Vector3(0, 0-velocity2.z, 0), Space.Self);
    }

    private bool CheckUnderwaterStatus()
    {
        return false;
    }
}