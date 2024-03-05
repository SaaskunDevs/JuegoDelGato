using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXControl : MonoBehaviour
{
    [Header("VFX")]
    [SerializeField] GameManager _gameManager;
    [SerializeField] GameObject _vfx; // Efecto visual a instanciar
    [SerializeField] GameObject _vfx2; // Efecto visual a instanciar
    [SerializeField] Material _material; // MeshRenderer del efecto visual
    [SerializeField] float amountIncrement = .2f; // Incremento del efecto visual
    float amount = 0f; // Valor del efecto visual
    bool animate = false; 

    void Update() 
    {

        if (animate)
        {
            amount += Time.deltaTime * amountIncrement; // Incrementamos el valor del efecto visual
            _gameManager.X.GetComponentInChildren<MeshRenderer>().sharedMaterial.SetFloat("_Amount", amount); // Asignamos el valor del efecto visual al MeshRenderer

            if (amount >= 1f)
            {
                animate = false; // Cambiamos el valor de la animación
                amount = 0f; // Reiniciamos el valor del efecto visual
            }
        }
    }

    public void VFXEffectX()
    {
        Instantiate(_vfx, _gameManager.X.transform.position, Quaternion.identity); // Instanciamos el efecto visual en la posición de la colisión
        animate = false; // Cambiamos el valor de la animación
        
        
    }
    public void VFXEffectO()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Obtenemos el rayo del mouse
        RaycastHit hit; // Variable para guardar la informacion del rayo

        if (Physics.Raycast(ray, out hit)) // Si el rayo colisiona con algo
        {
            Instantiate(_vfx2, hit.point, Quaternion.identity); // Instanciamos el efecto visual en la posición de la colisión
        }
    }

    public void particleOn(float ronda)
    {
        animate = true;
    }
}