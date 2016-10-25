using UnityEngine;
using System.Collections;

// para poder ver os resultados no editor
[ExecuteInEditMode]
public class EfeitoDeImagemBasico : MonoBehaviour {

    // material com o shader e infos para o efeito
    public Material material;

    void OnRenderImage(RenderTexture src, RenderTexture dst) {
        
        // chamada que copia os pixels da origem no destino
        Graphics.Blit(src, dst, material);
    }
}
