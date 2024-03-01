using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXControl : MonoBehaviour
{
    [SerializeField] GameObject _vfx;
    [SerializeField] Camera mainCamera;
    public GameObject sphere;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown (KeyCode.Space))
        {
            Instantiate(_vfx, transform.position, Quaternion.identity);
        }

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            if(Input.GetMouseButtonDown(0))
            {
                GameObject objeto3D = Instantiate(sphere, hit.point, Quaternion.Euler(90f, 0, 0));
                objeto3D.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
                Instantiate(_vfx, hit.point, Quaternion.identity);
            }
        }
    }
}
