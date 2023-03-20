using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;



public class XObtnScript : MonoBehaviour
{
    [SerializeField] Button Btn;
    [SerializeField] TextMeshProUGUI TextBtn;
   
    private GameController GameContr;

    public  void SetSpace()
    {
        TextBtn.text = GameContr.GetPlayerSide();
        Btn.interactable = false;
        GameContr.EndTurn();
       
    }

    public void SetGameContrRefrence(GameController Contro)
    {
        GameContr = Contro;
    }
}
