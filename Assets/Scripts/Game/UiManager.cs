using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject masterGraphicGO;
    [SerializeField] private GameObject claimGO;

    public void StartGame()
    {
        ShowClaim();
    }

    public void ShowClaim()
    {
        masterGraphicGO.SetActive(false);
        claimGO.SetActive(true);
    }

    public void DisableClaim()
    {
        claimGO.SetActive(false);
    }
}
