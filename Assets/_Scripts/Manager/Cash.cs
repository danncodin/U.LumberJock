using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cashmanager : MonoBehaviour
{
    public int CashCount;
    public TextMeshProUGUI CashText;


    public void Update()
    {
        CashText.text = "$ " + CashCount.ToString();
    }   
}
