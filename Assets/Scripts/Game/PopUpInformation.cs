using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUpInformation : MonoBehaviour
{
    [Header("PopUps")]
    [SerializeField] GameObject _popUpWinner;
    [SerializeField] GameObject _popUpInformatio;

    [Header("Winner Texts")]
    [SerializeField] GameObject _textTurn;
    [SerializeField] TextMeshProUGUI _titleText;
    [SerializeField] TextMeshProUGUI _winnerText;

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

    public void ResetAll()
    {
        SceneManager.LoadScene(0);
    }
}
