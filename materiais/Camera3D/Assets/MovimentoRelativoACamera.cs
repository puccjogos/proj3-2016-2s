using UnityEngine;
using System.Collections;

public class MovimentoRelativoACamera : MonoBehaviour {

    private Rigidbody _rb;
    private Vector3 _input;
    public float velocidade;
    public float suavizar;
    private Vector3 _velTemp;
    private Animator _anim;

    void Start () {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponentInChildren<Animator>();
	}
	
	void Update () {
        _input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _input = Vector3.ClampMagnitude(_input, 1f);
        Vector3 camForward = Camera.main.transform.forward;
        _velTemp = Input.GetAxis("Vertical") * camForward + Input.GetAxis("Horizontal") * Camera.main.transform.right;
        _velTemp.y = 0f;
        _velTemp = _velTemp.normalized * _input.magnitude;
        _anim.SetFloat("speed", _velTemp.magnitude);
    }

    void FixedUpdate()
    {
        if (_input.sqrMagnitude <= 0f)
        {
            return;
        }
        var vel = _velTemp * velocidade;
        //var velAlvo = new Vector3(vel.x, _rb.velocity.y, vel.z);
        transform.forward = Vector3.Slerp(transform.forward, _velTemp.normalized, Time.fixedDeltaTime * suavizar);
        var finalVel = transform.forward * velocidade * _input.magnitude;
        finalVel.y = _rb.velocity.y;
        _rb.velocity = finalVel;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + _velTemp * 10f);
    }
}
