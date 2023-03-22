using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;
using UnityEngine.UI;

[System.Serializable]
public class Player
{
    public Image Panel;
    public TextMeshProUGUI text;
    public Button BtnXO;
}
[System.Serializable]
public class PlayerColor
{
    public Color PanelColor;
    public Color TextColor;
}
public class GameController : MonoBehaviour
{


    //---------------Public-------------------
    public TextMeshProUGUI[] BtnList;
    public GameObject GameOverPanel;
    public TextMeshProUGUI GameOverText;
    public GameObject RestartBtn;
    public Player PlayerX;
    public Player PlayerO;
    public PlayerColor ActivePlayerColor;
    public PlayerColor InactivePlayerColor;
    public GameObject StartInfo;
    public bool IsPlayerMove;
    public float Delay;
    public NavMeshAgent NMA;
    //----------------------------------------



    //---------------Private-------------------
    private string PlayerSide;
    private int MoveCount;
    private string ComputerSide;
    private int Valu;
    //-----------------------------------------

    void Awake()
    {
        
        SetGameControllerReferenceOnButtons();
        GameOverPanel.SetActive(false);
        MoveCount = 0;
        RestartBtn.SetActive(false);
        IsPlayerMove = true;
  
    }

     void Update()
    {
        if(IsPlayerMove == false)
        {
            Delay += Delay * Time.deltaTime;
            if(Delay >= 100)
            {
                //you can replace BtnList by 8 because 8 elements number insaide the list
                Valu = Random.Range(0, BtnList.Length);

                if(BtnList[Valu].GetComponentInParent<Button>().interactable == true)
                {
                    BtnList[Valu].text = GetCoumputerSide();
                    BtnList[Valu].GetComponentInParent<Button>().interactable = false;
                    EndTurn();
                }
            }
        }
    }

    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < BtnList.Length; i++)
        {
            BtnList[i].GetComponentInParent<XObtnScript>().SetGameContrRefrence(this);
        }
        
    }
    public void SetStartingSide(string StartingSide)
    {
       
        PlayerSide = StartingSide;

        if (PlayerSide == "X")
        {
            ComputerSide = "O";
            SetPlayerColors(PlayerX, PlayerO);
        }
        else
        {
            ComputerSide = "X";
            SetPlayerColors(PlayerO, PlayerX);

        }
        StartGame();
    }

     void StartGame()
    {
        SetBoardInteractable(true);
        SetPlayerButton(false);
        StartInfo.SetActive(false);
    }
    public string GetPlayerSide()
    {
        return PlayerSide;
    }

    public string GetCoumputerSide()
    {
       
      
        return ComputerSide;
    }

    public void EndTurn()
    {
        MoveCount++;

        //----------------------------------this Player Side-----------------------------------------------------------------

        if (BtnList[0].text == PlayerSide && BtnList[1].text == PlayerSide && BtnList[2].text == PlayerSide)
        {
            GameOver(PlayerSide);
        }

        else if (BtnList[3].text == PlayerSide && BtnList[4].text == PlayerSide && BtnList[5].text == PlayerSide)
        {
            GameOver(PlayerSide);
        }

        else if (BtnList[6].text == PlayerSide && BtnList[7].text == PlayerSide && BtnList[8].text == PlayerSide)
        {
            GameOver(PlayerSide);
        }

        else if (BtnList[0].text == PlayerSide && BtnList[3].text == PlayerSide && BtnList[6].text == PlayerSide)
        {
            GameOver(PlayerSide);
        }

        else if (BtnList[1].text == PlayerSide && BtnList[4].text == PlayerSide && BtnList[7].text == PlayerSide)
        {
            GameOver(PlayerSide);
        }

        else if (BtnList[0].text == PlayerSide && BtnList[4].text == PlayerSide && BtnList[8].text == PlayerSide)
        {
            GameOver(PlayerSide);
        }

        else if (BtnList[2].text == PlayerSide && BtnList[5].text == PlayerSide && BtnList[8].text == PlayerSide)
        {
            GameOver(PlayerSide);
        }

        else if (BtnList[2].text == PlayerSide && BtnList[4].text == PlayerSide && BtnList[6].text == PlayerSide)
        {
            GameOver(PlayerSide);
        }
        

        //--------------------------------------------------End---------------------------------------------------


        //----------------------------------------------This Computer Side-------------------------------------------------------

        else if (BtnList[0].text == ComputerSide && BtnList[1].text == ComputerSide && BtnList[2].text == ComputerSide)
        {
            GameOver(NMA.ToString());
        }

        else if (BtnList[3].text == ComputerSide && BtnList[4].text == ComputerSide && BtnList[5].text == ComputerSide)
        {
            GameOver(ComputerSide);
        }

        else if (BtnList[6].text == ComputerSide && BtnList[7].text == ComputerSide && BtnList[8].text == ComputerSide)
        {
            GameOver(ComputerSide);
        }

        else if (BtnList[0].text == ComputerSide && BtnList[3].text == ComputerSide && BtnList[6].text == ComputerSide)
        {
            GameOver(ComputerSide);
        }

        else if (BtnList[1].text == ComputerSide && BtnList[4].text == ComputerSide && BtnList[7].text == ComputerSide)
        {
            GameOver(ComputerSide);
        }

        else if (BtnList[0].text == ComputerSide && BtnList[4].text == ComputerSide && BtnList[8].text == ComputerSide)
        {
            GameOver(ComputerSide);
        }

        else if (BtnList[2].text == PlayerSide && BtnList[5].text == PlayerSide && BtnList[8].text == PlayerSide)
        {
            GameOver(ComputerSide);
        }

        else if (BtnList[2].text == ComputerSide && BtnList[4].text == ComputerSide && BtnList[6].text == ComputerSide)
        {
            GameOver(ComputerSide);
        }
       else if (MoveCount >= 9)
        {
            GameOver("Draw");
        }
        else
        {
            ChangeSide();
            Delay = 10;
        }

        //-----------------------------------------End----------------------------------------------------

    }

   void SetPlayerColors(Player NewPlayer, Player OldPlayer)
    {
        NewPlayer.Panel.color = ActivePlayerColor.PanelColor;
        NewPlayer.text.color = ActivePlayerColor.TextColor;
        OldPlayer.Panel.color = InactivePlayerColor.PanelColor;
        OldPlayer.text.color = InactivePlayerColor.TextColor;
    }
   void GameOver(string WinningPlayer)
    {

        SetBoardInteractable(false);


        if(WinningPlayer == "Draw")
        {
            SetGameOverText("It's a Draw");
            SetPlayerColorInactive();
        }
        else
        {
            SetGameOverText($"Player {WinningPlayer} Win");
        }
        RestartBtn.SetActive(true);
    }

    void ChangeSide()
    {
       // PlayerSide = (PlayerSide == "X")?"O":"X";
        IsPlayerMove = (IsPlayerMove == true) ? false : true;
       // if(PlayerSide == "X")
        if(IsPlayerMove == true)
        {
            SetPlayerColors(PlayerX,PlayerO);
            
        }
        else
        {
            SetPlayerColors(PlayerO, PlayerX);
        }
    }

    void SetGameOverText(string Value)
    {
        GameOverPanel.SetActive(true);
        GameOverText.text = Value;
    }
    public void RestartGame()
    {
        MoveCount = 0;
        GameOverPanel.SetActive(false);
        RestartBtn.SetActive(false);
        SetPlayerButton(true);
        SetPlayerColorInactive();
        StartInfo.SetActive(true);
        IsPlayerMove = true;
        Delay = 10;
        
       

        for (int i = 0; i < BtnList.Length; i++)
        {
            //BtnList[i].GetComponentInParent<Button>().interactable = true;
            BtnList[i].text = "";
        }
        SetPlayerColors(PlayerX, PlayerO);
        RestartBtn.SetActive(false);
    }

    void SetBoardInteractable(bool Toggel)
    {
        for (int i = 0; i < BtnList.Length; i++)
        {
            
            BtnList[i].GetComponentInParent<Button>().interactable = Toggel;
        }

    }

    void SetPlayerButton(bool toggel)
    {
        PlayerX.BtnXO.interactable = toggel;
        PlayerO.BtnXO.interactable = toggel;
    }

    void SetPlayerColorInactive()
    {
        PlayerX.Panel.color = InactivePlayerColor.PanelColor;
        PlayerX.text.color = InactivePlayerColor.TextColor;
        PlayerO.Panel.color = InactivePlayerColor.PanelColor;
        PlayerO.text.color = InactivePlayerColor.TextColor;
    }

}
