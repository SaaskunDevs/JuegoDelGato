using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshShader : MonoBehaviour
{
    [SerializeField] private MeshRenderer mesh;
    public Material mat;
    private float amount;

    private float actualTime;
    [SerializeField] private float appearTime = 2;

    private bool animating = false;

    void Start()
    {
        mat = mesh.material;
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ActivateAnimation();
        }
        if (animating)
        {     
            Debug.Log("Animating");
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

    public void ActivateAnimation()
    {
        actualTime = 0;
        animating = true;
        Debug.Log("Activating animation");
    }
}
