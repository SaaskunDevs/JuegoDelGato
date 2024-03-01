using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXControl : MonoBehaviour
{
    [SerializeField] GameObject _vfx;
    [SerializeField] VisualEffect _vfxComponent;
    public void VFXEffect()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Obtenemos el rayo del mouse
        RaycastHit hit; // Variable para guardar la informacion del rayo
        if (Physics.Raycast(ray, out hit)) // Si el rayo colisiona con algo
        {
            Instantiate(_vfx, hit.point, Quaternion.identity); // Instanciamos el efecto visual en la posición de la colisión
        }
    }

}
