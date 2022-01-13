using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _coinText;
    [SerializeField]
    private Text _livesText;
    
    //UpdateCoinDisplay()

    public void UpdateCoinDisplay(int _coin)
    {
        _coinText.text = "Coins: " + _coin.ToString();
    }

    public void UpdateLivesDisplay(int _lives)
    {
        _livesText.text = "Lives: " + _lives.ToString();
    }

}
