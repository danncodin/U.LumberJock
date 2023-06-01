using System;
using UnityEngine;
using TMPro;



public class UpgradeWoodManager : MonoBehaviour
{

    public TMP_Text upgradeWoodCostText;
    public Tree vtree;
    private int upgradeMultiplier = 1;

    void Start()
    {
        vtree = FindAnyObjectByType<Tree>();
    }

    public void FixedUpdate()
    {
        upgradeWoodCostText.text = "Price: " + CalculateUpgradeCost();
    }

    public void UpgradeWoodBuy()
    {

        if (vtree.wood >= CalculateUpgradeCost())
        {
            vtree.wood -= CalculateUpgradeCost();

            upgradeMultiplier ++;

            UpgradeWood();

            upgradeWoodCostText.text = "Price: " + CalculateUpgradeCost();
        }
        Debug.Log("Quantidade de Madeiras: " + vtree.GetWoodCount());
        // Faça as ações necessárias para o upgrade
    }
    private int CalculateUpgradeCost()
    {
        int baseCost = 30;
        return baseCost * upgradeMultiplier;
    }    
    public int UpgradeWood()
    {
        return vtree.UpgradeWood();
    }
}
