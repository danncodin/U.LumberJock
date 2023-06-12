using System;
using UnityEngine;
using TMPro;



public class UpgradeMadeiraManager : MonoBehaviour
{

    public TMP_Text upgradeMadeiraCostText;
    public TMP_Text levelUpgradeText;
    public Tree vtree;
    public int levelUpgrade = 0;
    public int upgradeMultiplier = 1;        
    void Start()
    {
        vtree = FindAnyObjectByType<Tree>();
    }

    public void FixedUpdate()
    {
        upgradeMadeiraCostText.text = "" + CalculateUpgradeCost();
    }

    public void UpgradeMadeiraBuy()
    {

        if (vtree.wood >= CalculateUpgradeCost())
        {
            vtree.wood -= CalculateUpgradeCost();
            FindObjectOfType<AudioManager>().Play("UpgradeSound");
            levelUpgrade++;
            upgradeMultiplier++;
            UpgradeMadeira();
            levelUpgradeText.text= "" + levelUpgrade;
            upgradeMadeiraCostText.text = "" + CalculateUpgradeCost();
        }
        Debug.Log("Quantidade de Madeiras: " + vtree.GetWoodCount());
        // Faça as ações necessárias para o upgrade
    }
    private double CalculateUpgradeCost()
    {
        double baseCost = 30;
        return Math.Round((Math.Pow((baseCost * upgradeMultiplier),  1.4))); //
    }
    public double UpgradeMadeira()
    {
        return vtree.UpgradeMadeira();
    }
}
