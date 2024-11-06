using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clarao : MonoBehaviour
{
    private Image img;
    void Start()
    {
        img = GameObject.FindGameObjectWithTag("flash").GetComponent<Image>();
        StartCoroutine(Flash());
    }

    public IEnumerator Flash()
    {
        yield return new WaitForSeconds(4f);

        img.color = new Vector4(1,1,1,1);
        Debug.Log("Bang");
        float dissipar = 1f;
        float mod = 0.01f;
        float espera = 0f;

        for (int i = 0; img.color.a > 0; i++) {
            img.color = new Vector4(1, 1, 1, dissipar);
            dissipar -= 0.025f;
            mod = mod * 1.5f;
            espera = 0.5f - mod;
            if (espera < 0.1f) {
                espera = 0.1f;
            }
            if (dissipar < 0f) { 
                Destroy(gameObject);
            }
            yield return new WaitForSeconds(espera);
        }
    }
}
