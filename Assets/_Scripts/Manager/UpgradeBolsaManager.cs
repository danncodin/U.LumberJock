using System;
using UnityEngine;
using TMPro;



public class UpgradeBolsaManager : MonoBehaviour
{

    public TMP_Text upgradeBolsaCostText;
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
        upgradeBolsaCostText.text = "" + CalculateUpgradeCost();
    }

    public void UpgradeBolsaBuy()
    {

        if (vtree.wood >= CalculateUpgradeCost())
        {
            vtree.wood -= CalculateUpgradeCost();
            levelUpgrade++;
            FindObjectOfType<AudioManager>().Play("UpgradeSound");
            upgradeMultiplier ++;
            UpgradeBolsa();
            levelUpgradeText.text = "" + levelUpgrade;
            upgradeBolsaCostText.text = "" + CalculateUpgradeCost();
        }
        Debug.Log("Quantidade de Madeiras: " + vtree.GetWoodCount());
        // Faça as ações necessárias para o upgrade
    }
    private double CalculateUpgradeCost()
    {
        double baseCost = 15;
        return Math.Round((Math.Pow((baseCost * upgradeMultiplier),  1.3))); //1.2
    } 
    public double UpgradeBolsa()
    {
        return vtree.UpgradeBolsa();
    }
}
