using System;
using UnityEngine;
using TMPro;



public class UpgradeAxeManager : MonoBehaviour
{

    public TMP_Text upgradeAxeCostText;
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
        upgradeAxeCostText.text = "" + CalculateUpgradeCost();
    }

    public void UpgradeAxeBuy()
    {

        if (vtree.wood >= CalculateUpgradeCost())
        {
            vtree.wood -= CalculateUpgradeCost();
            levelUpgrade++;
            upgradeMultiplier++;
            UpgradeAxe();
            levelUpgradeText.text= "" + levelUpgrade;
            upgradeAxeCostText.text = "" + CalculateUpgradeCost();
        }
        Debug.Log("Quantidade de Madeiras: " + vtree.GetWoodCount());
        // Faça as ações necessárias para o upgrade
    }
    private double CalculateUpgradeCost()
    {
        double baseCost = 15;
        return Math.Round((Math.Pow((baseCost * upgradeMultiplier),  1.2)));
    }
    public int UpgradeAxe()
    {
        return vtree.UpgradeAxe();
    }
}
