using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Transform target;

    public float pitch;
    public float yaw;
    public float distance;
    public float smooth;

    private Vector3 _targetPosition;
    public Vector3 viewOffset;
    public float maxSpeed;

    public bool sensorR, sensorL;

    void Start () {
	    
	}

    void SetSensorOn (int pos)
    {
        if(pos == 0)
        {
            sensorL = true;
        }
        else
        {
            sensorR = true;
        }
    }

    void SetSensorOff(int pos)
    {
        if (pos == 0)
        {
            sensorL = false;
        }
        else
        {
            sensorR = false;
        }
    }

    void FixedUpdate () {
        float tempYaw = yaw;
        /*
        if (sensorR)
        {
            tempYaw -= 60;
        }
        if (sensorL)
        {
            tempYaw += 60;
        }
        */

        Vector3 intermediate = Quaternion.Euler(new Vector3(pitch, tempYaw, 0f)) * new Vector3(0f, 0f, -distance);
        Vector3 pos = target.TransformDirection(intermediate) + target.position;

        Vector3 curVelocity= Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref curVelocity, smooth * Time.fixedDeltaTime, maxSpeed);
        transform.LookAt(target.position + viewOffset);
    }
}
