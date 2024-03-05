using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshShader : MonoBehaviour
{
    [SerializeField] private MeshRenderer mesh;
    private Material mat;
    private float amount;

    private float actualTime;
    [SerializeField] private float appearTime = 2;

    private bool animating = true;

    void Start()
    {
        mat = mesh.material;
    }


    void Update()
    {
        if (!animating)
            return;

        actualTime += Time.deltaTime;
        amount = Mathf.Lerp(0, 1, actualTime / appearTime);

        if (actualTime > appearTime)
        {
            amount = 1;
            animating = false;
        }
        mat.SetFloat("_Amount", amount);
    }
}
