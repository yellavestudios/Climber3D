using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _coinText;
    
    //UpdateCoinDisplay()

    public void UpdateCoinDisplay(int _coin)
    {
        _coinText.text = "Coins: " + _coin.ToString();
    }
}
