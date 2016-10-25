using UnityEngine;
using System.Collections;

public class AleatorizarPropriedade : MonoBehaviour {

    public Color cor;
    MaterialPropertyBlock matProp;

	// Use this for initialization
	void Start () {
        matProp = new MaterialPropertyBlock();
        var renderer = GetComponent<Renderer>();
        renderer.GetPropertyBlock(matProp);
        matProp.Clear();
        matProp.SetColor("_Color", cor);
        renderer.SetPropertyBlock(matProp);
	}
}
