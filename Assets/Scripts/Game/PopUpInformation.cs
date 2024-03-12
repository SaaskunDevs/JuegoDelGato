using UnityEngine;
using UnityEngine.UI;

public class PopUpInformation : MonoBehaviour
{
    [Header("PopUps GameObjects")]
    [SerializeField] GameObject _popUpWinner;
    [SerializeField] GameObject _popUpEquals;
    [SerializeField] GameObject _popUpInformatio;


    [SerializeField] private Image winnerImg;
    [SerializeField] private Sprite xSprite;
    [SerializeField] private Sprite oSprite;


    public void PopUpWinner(string winnerName)
    {
        if(winnerName == "X")
            winnerImg.sprite = xSprite;
        else
            winnerImg.sprite = oSprite;

        Invoke("ShowPopUpWinner", 5);
        Invoke("ShowClaim", 8);
    }

    public void PopUpEquals()
    {

        Invoke("ShowPopUpEquals", 1);
        Invoke("ShowClaim", 6);
    }

    void ShowPopUpWinner()
    {
        _popUpWinner.SetActive(true);
    }

    void ShowPopUpEquals()
    {
        _popUpEquals.SetActive(true);
    }

    public void ShowClaim()
    {
        _popUpInformatio.SetActive(true);
    }

    public void ChooseInfo()
    {
        _popUpInformatio.SetActive(true);
    }

}
