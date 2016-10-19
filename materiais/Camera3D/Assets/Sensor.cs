using UnityEngine;
using System.Collections;

public class Sensor : MonoBehaviour {

    public int pos;

	void OnTriggerEnter(Collider outro)
    {
        Debug.Log("enter");
        transform.parent.SendMessage("SetSensorOn", pos);
    }

    void OnTriggerExit(Collider outro)
    {
        transform.parent.SendMessage("SetSensorOff", pos);
    }
}
