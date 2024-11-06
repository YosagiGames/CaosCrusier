using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Caminho : MonoBehaviour
{
    public Color cor;
    public float velRecomendada;
    // Start is called before the first frame update
    private void OnDrawGizmos()
    {
        Gizmos.color = cor;
        Gizmos.DrawSphere(transform.position, 1f);
    }
}
