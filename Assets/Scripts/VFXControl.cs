using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXControl : MonoBehaviour
{
    [SerializeField] GameObject _vfx; // Efecto visual a instanciar
    [SerializeField] GameObject _vfx2; // Efecto visual a instanciar
    public void VFXEffectX()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Obtenemos el rayo del mouse
        RaycastHit hit; // Variable para guardar la informacion del rayo
        if (Physics.Raycast(ray, out hit)) // Si el rayo colisiona con algo
        {
            Instantiate(_vfx, hit.point, Quaternion.identity); // Instanciamos el efecto visual en la posición de la colisión
        }
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

}
