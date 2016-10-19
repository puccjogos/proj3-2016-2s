using UnityEngine;
using System.Collections;

public class CameraSegueTranslacao : MonoBehaviour {

    public Transform alvo;
    public float suavizar = 1f;
    private Vector3 offset;
    public bool rotacionar = false;

    void Start()
    {
        offset = transform.position - alvo.position;
    }

    void FixedUpdate()
    {
        Vector3 posicaoDesejada = alvo.position + offset;
        posicaoDesejada = Vector3.Lerp(transform.position, posicaoDesejada, Time.fixedDeltaTime * suavizar);
        transform.position = posicaoDesejada;
        if(rotacionar)
        {
            transform.LookAt(alvo);
        }
    }
}
