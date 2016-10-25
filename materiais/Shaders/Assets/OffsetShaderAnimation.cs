using UnityEngine;
using System.Collections;

public class OffsetShaderAnimation : MonoBehaviour {

    public float maxRandom = 5.5f;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y * 0.1f);
        transform.localScale = new Vector3(Random.Range(0.8f, 1.3f), Random.Range(0.8f, 1.3f), 1f);
	}
}
