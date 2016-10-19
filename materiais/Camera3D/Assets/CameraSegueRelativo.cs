using UnityEngine;
using System.Collections;

public class CameraSegueRelativo : MonoBehaviour {

    public GameObject alvo;
    public float suavizar = 1;
    Vector3 offset;
    public Vector3 offsetVisao;

    void Start()
    {
        offset = alvo.transform.position - transform.position;
    }

    void LateUpdate()
    {
        float anguloAtual = transform.eulerAngles.y;
        float anguloDesejado = alvo.transform.eulerAngles.y;
        float angle = Mathf.LerpAngle(anguloAtual, anguloDesejado, Time.smoothDeltaTime * suavizar);

        Quaternion rotacao = Quaternion.Euler(0, angle, 0);
        transform.position = alvo.transform.position - (rotacao * offset);

        transform.LookAt(alvo.transform.position + offsetVisao);
    }

}
