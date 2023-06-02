using System;
using UnityEngine;
using TMPro;



public class UpgradeAxeManager : MonoBehaviour
{

    public TMP_Text upgradeAxeCostText;
    public Tree vtree;
    // public int upgradeWood;
    public int upgradeMultiplier = 1;        
    void Start()
    {
        vtree = FindAnyObjectByType<Tree>();
    }

    public void FixedUpdate()
    {
        upgradeAxeCostText.text = "Price: " + CalculateUpgradeCost();
    }

    public void UpgradeAxeBuy()
    {

        if (vtree.wood >= CalculateUpgradeCost())
        {
            vtree.wood -= CalculateUpgradeCost();
            upgradeMultiplier++;

            UpgradeAxe();

            upgradeAxeCostText.text = "Price: " + CalculateUpgradeCost();
        }
        Debug.Log("Quantidade de Madeiras: " + vtree.GetWoodCount());
        // Faça as ações necessárias para o upgrade
    }
    private double CalculateUpgradeCost()
    {
        double baseCost = 45;
        return Math.Round((Math.Pow((baseCost * upgradeMultiplier),  1.2)));
    }
    public int UpgradeAxe()
    {
        return vtree.UpgradeAxe();
    }
}
