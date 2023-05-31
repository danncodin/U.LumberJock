using System;
using UnityEngine;
using TMPro;



public class UpgradeWoodManager : MonoBehaviour
{

    public TMP_Text upgrade1CostText;
    public Tree vtree;
    // public int upgradeWood;
    private int upgradeMultiplier = 1;

    void Start()
    {
        vtree = FindAnyObjectByType<Tree>();
    }

    public void FixedUpdate()
    {
        upgrade1CostText.text = "Price: " + CalculateUpgradeCost();
    }

    public void Upgrade1Buy()
    {

        if (vtree.wood >= CalculateUpgradeCost())
        {
            vtree.wood -= CalculateUpgradeCost();

            upgradeMultiplier++;

            // upgradeWood = vtree.UpgradeWood();

            upgrade1CostText.text = "Price: " + CalculateUpgradeCost();
        }
        Debug.Log("Quantidade de Madeiras: " + vtree.GetWoodCount());
        // Faça as ações necessárias para o upgrade
    }
    private int CalculateUpgradeCost()
    {
        int baseCost = 25;
        return baseCost * upgradeMultiplier;
    }
}
