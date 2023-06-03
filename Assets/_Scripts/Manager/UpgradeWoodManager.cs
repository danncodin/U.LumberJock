using System;
using UnityEngine;
using TMPro;



public class UpgradeWoodManager : MonoBehaviour
{

    public TMP_Text upgradeWoodCostText;
    public TMP_Text levelUpgradeText;
    public Tree vtree;
    public int levelUpgrade = 0;
    private int upgradeMultiplier = 1;
    void Start()
    {
        vtree = FindAnyObjectByType<Tree>();
    }

    public void FixedUpdate()
    {
        upgradeWoodCostText.text = "" + CalculateUpgradeCost();
    }

    public void UpgradeWoodBuy()
    {

        if (vtree.wood >= CalculateUpgradeCost())
        {
            vtree.wood -= CalculateUpgradeCost();
            levelUpgrade++;
            upgradeMultiplier ++;
            UpgradeWood();
            levelUpgradeText.text = "" + levelUpgrade;
            upgradeWoodCostText.text = "" + CalculateUpgradeCost();
        }
        Debug.Log("Quantidade de Madeiras: " + vtree.GetWoodCount());
        // Faça as ações necessárias para o upgrade
    }
    private double CalculateUpgradeCost()
    {
        double baseCost = 15;
        return Math.Round((Math.Pow((baseCost * upgradeMultiplier),  1.2)));
    } 
    public int UpgradeWood()
    {
        return vtree.UpgradeWood();
    }
}
