using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFreeCamera : MonoBehaviour {

    public float movementSpeed = 40.0f;

    Vector3 currentRot;
    public float velRot = 160.0f;


    void Update() {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed, Space.Self);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            transform.Translate(-Vector3.right * Time.deltaTime * movementSpeed, Space.Self);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            transform.Translate(-Vector3.forward * Time.deltaTime * movementSpeed, Space.Self);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            transform.Translate(Vector3.right * Time.deltaTime * movementSpeed, Space.Self);
        }

        if (Input.GetKey(KeyCode.Space)) {
            transform.Translate(Vector3.up * Time.deltaTime * movementSpeed, Space.Self);
        }

        if (Input.GetKey(KeyCode.LeftShift)) {
            transform.Translate(-Vector3.up * Time.deltaTime * movementSpeed, Space.Self);
        }

        currentRot.x -= Input.GetAxis("Mouse Y") * velRot * Time.deltaTime;
        currentRot.y += Input.GetAxis("Mouse X") * velRot * Time.deltaTime;
        transform.localEulerAngles = currentRot;
    }
}
