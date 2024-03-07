using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUpInformation : MonoBehaviour
{
    [Header("PopUps GameObjects")]
    [SerializeField] GameObject _popUpWinner;
    [SerializeField] GameObject _popUpInformatio;

    [Header("Pop Up Info Things")]
    [SerializeField] TextMeshProUGUI _titleTxt;
    [SerializeField] TextMeshProUGUI _infoText;

    [Header("Winner Texts")]
    [SerializeField] GameObject _textTurn;
    [SerializeField] TextMeshProUGUI _titleText;
    [SerializeField] TextMeshProUGUI _winnerText;
    
    [Header("SOInfo")]
    [SerializeField] InfoSO[] _infoSO;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ChooseInfo();
            _popUpInformatio.SetActive(true);
            Invoke("ClosePopUpInfo", 3);
        }
    }
    public void PopUpWinner(string titleInfo ,string winnerName)
    {
        _titleText.text = titleInfo;
        _winnerText.text = winnerName;
        Invoke("ShowPopUpWinner", 3);
        
    }
    void ShowPopUpWinner()
    {
        _popUpWinner.SetActive(true);
        _textTurn.SetActive(false);
    }

    public void ChooseInfo()
    {
        _popUpInformatio.SetActive(true);
        int index = Random.Range(0, _infoSO.Length);

        _titleTxt.text = _infoSO[index].tilte;
        _infoText.text = _infoSO[index].info;
    }

    public void ClosePopUpInfo()
    {
        _popUpInformatio.SetActive(false);
    }
    public void ResetAll()
    {
        SceneManager.LoadScene(0);
    }
}
