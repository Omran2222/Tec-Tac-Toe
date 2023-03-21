using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;



public class XObtnScript : MonoBehaviour
{
    public Button Btn;
    public TextMeshProUGUI TextBtn;
   
    private GameController GameContr;

   
    public  void SetSpace()
    {
        if(GameContr.IsPlayerMove == true)
        {
            TextBtn.text = GameContr.GetPlayerSide();
            Btn.interactable = false;
            GameContr.EndTurn();

        }

    }

    public void SetGameContrRefrence(GameController Contro)
    {
        GameContr = Contro;
    }


}
