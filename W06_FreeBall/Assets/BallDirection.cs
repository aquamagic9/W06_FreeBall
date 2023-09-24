using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDirection : MonoBehaviour
{
    private Vector3 targetDirection = Vector3.forward;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        targetDirection += new Vector3(-mouseY, mouseX, 0f) * Time.deltaTime;

        targetDirection.Normalize();

        transform.rotation = Quaternion.LookRotation(targetDirection);
    }
}
