using System;
using UnityEngine;
using TMPro;



public class UpgradeWoodManager : MonoBehaviour
{

    public TMP_Text upgradeWoodCostText;
    public Tree vtree;
    private int upgradeMultiplier = 1;
    public AudioSource upgradeWoodSound;

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
            upgradeWoodSound.Play();
            vtree.wood -= CalculateUpgradeCost();

            upgradeMultiplier ++;

            UpgradeWood();

            upgradeWoodCostText.text = "Price: " + CalculateUpgradeCost();
        }
        Debug.Log("Quantidade de Madeiras: " + vtree.GetWoodCount());
        // Faça as ações necessárias para o upgrade
    }
    private double CalculateUpgradeCost()
    {
        double baseCost = 45;
        return Math.Round((Math.Pow((baseCost * upgradeMultiplier),  1.2)));
    } 
    public int UpgradeWood()
    {
        return vtree.UpgradeWood();
    }
}
