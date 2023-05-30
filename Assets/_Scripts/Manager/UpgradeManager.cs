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

        public void Upgrade1Buy()
    {
        // Faça o upgrade usando as informações do Tree
        int wood = tree.wood;
        Debug.LogError(wood);
        // Faça as ações necessárias para o upgrade
    }
    private int CalculateUpgradeCost()
    {
        // Faça o cálculo do custo do upgrade com base nas informações do Tree
        // Retorne o custo calculado
        return 0;
    }
}
