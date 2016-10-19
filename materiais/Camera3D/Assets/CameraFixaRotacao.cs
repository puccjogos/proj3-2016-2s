using UnityEngine;
using System.Collections;

public class CameraFixaRotacao : MonoBehaviour {

    public Transform alvo;
	
	void LateUpdate()
    {
        transform.LookAt(alvo);
    }
}
