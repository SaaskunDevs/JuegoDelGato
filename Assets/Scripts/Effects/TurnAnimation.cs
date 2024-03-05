using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAnimation : MonoBehaviour
{
    [SerializeField] GameObject _xPrefab;
    [SerializeField] GameObject _oPrefab;
    [SerializeField] GameObject[] _movementPrefabs;
    float floating;

    void Start()
    {
        
    }

    void Update()
    {
        floating = Mathf.Sin(Time.time) * .005f;
        // _xPrefab.transform.position = new Vector3(_xPrefab.transform.position.x, _xPrefab.transform.position.y + floating, _xPrefab.transform.position.z);
        // _oPrefab.transform.position = new Vector3(_oPrefab.transform.position.x, _oPrefab.transform.position.y + floating, _oPrefab.transform.position.z);

        for (int i = 0; i < _movementPrefabs.Length; i++)
        {
            _movementPrefabs[i].transform.position = new Vector3(_movementPrefabs[i].transform.position.x, _movementPrefabs[i].transform.position.y + floating, _movementPrefabs[i].transform.position.z);
        }
    }
    public void SwitchTurn(string turn)
    {
        switch (turn)
        {
            case "X":
                UnScaling(_oPrefab, 0f, 0.5f); // Escala  a 0 durante 0.5 segundos
                StartScaling(_xPrefab, 1f, 0.5f); // Escala  a 1 durante 0.5 segundos
                break;
            case "O":
                UnScaling(_xPrefab, 0f, 0.5f); // Escala  a 0 durante 0.5 segundos
                StartScaling(_oPrefab, 1f, 0.5f); // Escala  a 1 durante 0.5 segundos
                break;
        }
    }

    public void StartScaling(GameObject obj, float targetScale, float duration)
    {
        StartCoroutine(ScaleObject(obj, targetScale, duration));
    }
    void UnScaling(GameObject obj, float targetScale, float duration)
    {
        
        StartCoroutine(ScaleObject(obj, targetScale, duration));
    }
    

    IEnumerator ScaleObject(GameObject obj, float targetScale, float duration)
    {
        yield return new WaitForSeconds(.5f);

        float time = 0;
        Vector3 initialScale = obj.transform.localScale;
        Vector3 finalScale = new Vector3(targetScale, targetScale, targetScale);

        while (time < duration)
        {
            obj.transform.localScale = Vector3.Lerp(initialScale, finalScale, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        obj.transform.localScale = finalScale;
    }
}
