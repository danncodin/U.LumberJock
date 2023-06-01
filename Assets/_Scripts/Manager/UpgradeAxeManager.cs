using System;
using UnityEngine;
using TMPro;



public class UpgradeAxeManager : MonoBehaviour
{

    public TMP_Text upgradeAxeCostText;
    public Tree vtree;
    // public int upgradeWood;
    private int upgradeMultiplier = 1;

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

            // upgradeWood = vtree.UpgradeWood();

            upgradeAxeCostText.text = "Price: " + CalculateUpgradeCost();
        }
        Debug.Log("Quantidade de Madeiras: " + vtree.GetWoodCount());
        // Faça as ações necessárias para o upgrade
    }
    private int CalculateUpgradeCost()
    {
        int baseCost = 25;
        return baseCost * upgradeMultiplier;
    }
    public int UpgradeAxe()
    {
        return CalculateUpgradeCost();
    }
}
