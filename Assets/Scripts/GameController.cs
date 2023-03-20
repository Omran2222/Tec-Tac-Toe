using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] BtnList;
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] TextMeshProUGUI GameOverText;
    [SerializeField] GameObject RestartBtn;
    private string PlayerSide;
    private int MoveCount;

    void Awake()
    {
        GameOverPanel.SetActive(false);
        SetGameControllerReferenceOnButtons();
        PlayerSide = "X";
        MoveCount = 0;
        RestartBtn.SetActive(false);
    }
   
    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < BtnList.Length; i++)
        {
            BtnList[i].GetComponentInParent<XObtnScript>().SetGameContrRefrence(this);
        }
        
    }
   
    public string GetPlayerSide()
    {
        return PlayerSide;
    }

    public void EndTurn()
    {
        MoveCount++;

        //---------------------------------------------------------------------------------------------------

        if (BtnList[0].text == PlayerSide && BtnList[1].text == PlayerSide && BtnList[2].text == PlayerSide)
        {
            GameOver(PlayerSide);
        }

        if (BtnList[3].text == PlayerSide && BtnList[4].text == PlayerSide && BtnList[5].text == PlayerSide)
        {
            GameOver(PlayerSide);
        }

        if (BtnList[6].text == PlayerSide && BtnList[7].text == PlayerSide && BtnList[8].text == PlayerSide)
        {
            GameOver(PlayerSide);
        }

        if (BtnList[0].text == PlayerSide && BtnList[3].text == PlayerSide && BtnList[6].text == PlayerSide)
        {
            GameOver(PlayerSide);
        }

        if (BtnList[1].text == PlayerSide && BtnList[4].text == PlayerSide && BtnList[7].text == PlayerSide)
        {
            GameOver(PlayerSide);
        }

        if (BtnList[0].text == PlayerSide && BtnList[4].text == PlayerSide && BtnList[8].text == PlayerSide)
        {
            GameOver(PlayerSide);
        }

        if (BtnList[2].text == PlayerSide && BtnList[4].text == PlayerSide && BtnList[6].text == PlayerSide)
        {
            GameOver(PlayerSide);
        }

        //-----------------------------------------------------------------------------------------------------

       

        if(MoveCount >= 9)
        {
            GameOver("Draw");
        }

        ChangeSide();
    }

   
   void GameOver(string WinningPlayer)
    {

        SetBoardInteractable(false);

        //GameOverText.text = $"Player {PlayerSide} Win";
        //Or
        //Use Functions SetGameOverText
        //SetGameOverText($"Player {PlayerSide} Win");

        if(WinningPlayer == "Draw")
        {
            SetGameOverText("It's a Draw");
        }
        else
        {
            SetGameOverText(WinningPlayer + "Win");
        }
        RestartBtn.SetActive(true);
    }

    void ChangeSide()
    {
        PlayerSide = (PlayerSide == "X")?"O":"X";
    }

    void SetGameOverText(string Value)
    {
        GameOverPanel.SetActive(true);
        GameOverText.text = Value;
    }
    public void RestartGame()
    {
        MoveCount = 0;
        PlayerSide = "X";
        GameOverPanel.SetActive(false);

        SetBoardInteractable(true);

        for (int i = 0; i < BtnList.Length; i++)
        {
            BtnList[i].GetComponentInParent<Button>().interactable = true;
            BtnList[i].text = "";
        }

        RestartBtn.SetActive(false);
    }

    void SetBoardInteractable(bool Toggel)
    {
        for (int i = 0; i < BtnList.Length; i++)
        {
            
            BtnList[i].GetComponentInParent<Button>().interactable = Toggel;
        }

    }

}
