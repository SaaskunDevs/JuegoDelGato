using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshShader : MonoBehaviour
{
    [SerializeField] private MeshRenderer mesh;
    public Material mat;
    private float amount;

    private float actualTime = 0;
    [SerializeField] private float appearTime = 2;

    private bool animating = false;
    public int colores = 0;
    public int _amountYN = 0;

    void Start()
    {
        mat = mesh.material;
        OnColor();
    }


    void Update()
    {
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

    void OnColor()
    {
        if (colores == 1)
        {
            mat.SetColor("_MainColor", Color.red);
            colores = 1;
        }
        if (colores == 2)
        {
            mat.SetColor("_MainColor", Color.blue);
            colores = 2;
        }
        if (_amountYN == 3)
        {
            mat.SetFloat("_Amount", actualTime);
        }
    }
}
