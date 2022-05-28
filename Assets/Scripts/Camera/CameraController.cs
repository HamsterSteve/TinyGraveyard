using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float cameraMovementSpeed = 10f;
    [SerializeField] float smooth = 2f;
    [SerializeField] float minXValue;
    [SerializeField] float maxXValue;
    [SerializeField] float minZValue;
    [SerializeField] float maxZValue;
    void Update()
    {
        GetInputs();
        CameraLerp();
    }

    void GetInputs()
    {
        //Camera movement
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if(transform.position.z > minZValue && transform.position.z < maxZValue)
            {
                transform.Translate(Vector3.forward * cameraMovementSpeed *Time.deltaTime, Space.World);
            }
        }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if(transform.position.z > minZValue && transform.position.z < maxZValue)
            {
                transform.Translate(Vector3.back * cameraMovementSpeed * Time.deltaTime, Space.World);
            }
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if(transform.position.x >= minXValue && transform.position.x < maxXValue)
            {
                transform.Translate(Vector3.left * cameraMovementSpeed * Time.deltaTime, Space.World);
            }
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if(transform.position.x > minXValue && transform.position.x < maxXValue)
            {
                transform.Translate(Vector3.right * cameraMovementSpeed * Time.deltaTime, Space.World);
            }
        }
    }

    void CameraLerp()
    {
        if(transform.position.x <= minXValue)
        {
            transform.position = Vector3.Lerp(
                transform.position, new Vector3(15, transform.position.y, transform.position.z) , Time.deltaTime * smooth);
        }

        if(transform.position.x >= maxXValue)
        {
            transform.position = Vector3.Lerp(
                transform.position, new Vector3(15, transform.position.y, transform.position.z) , Time.deltaTime * smooth);
        }

        if(transform.position.z <= minZValue)
        {
            transform.position = Vector3.Lerp(
                transform.position, new Vector3(transform.position.x, transform.position.y, -6) , Time.deltaTime * smooth);
        }

        if(transform.position.z >= maxZValue)
        {
            transform.position = Vector3.Lerp(
                transform.position, new Vector3(transform.position.x, transform.position.y, -6) , Time.deltaTime * smooth);
        }
    }
}
