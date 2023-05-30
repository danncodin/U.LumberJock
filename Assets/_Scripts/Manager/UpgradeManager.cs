using System;
using UnityEngine;
using TMPro;



public class UpgradeManager : MonoBehaviour
{

    public TMP_Text upgrade1CostText;
    public Tree tree;


    void Start()
    {
        tree = FindAnyObjectByType<Tree>();
    }

    public void FixedUpdate()
    {
        upgrade1CostText.text = "Price: " + CalculateUpgradeCost();
    }

        public void Upgrade()
    {
        // Faça o upgrade usando as informações do Tree
        int woodCount = tree.GetWoodCount();
        Debug.Log("Quantidade de Madeiras: " + woodCount);
        woodCount -= 25;
        Debug.Log("Quantidade de Madeiras: " + woodCount);
        // Faça as ações necessárias para o upgrade
    }
    private int CalculateUpgradeCost()
    {
        // Faça o cálculo do custo do upgrade com base nas informações do Tree
        // Retorne o custo calculado
        return 0;
    }
}
