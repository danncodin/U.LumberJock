using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tree : MonoBehaviour
{
    public double wood;
    public int TreeWood;
    public int countDie = 0;
    public int hitPoint = 1;
    public int woodPoint = 1;
    public TextMeshProUGUI woodText;
    public int maxHitPoints;
    public int currentHitPoints;
    public float transitionTime = 0.2f;
    public Slider hitpointSlider;
    public TextMeshProUGUI hitPointText;
    public TreeData treeData;
    public Image treeImage;
    public TextMeshProUGUI treeNameText;
    public AreaManager areaManager;
    public UpgradeAreaManager woodUP;

    private void Start()
    {
      woodUP = FindAnyObjectByType<UpgradeAreaManager>();
      SpawnTree();
      UpdateUI();
    }
    // Wire this to the tree button component 
    public void OnTreeClick()
    {
        TreeDamaged();
        GetWoodCount();
    }

    void TreeDamaged()
    {
      Axe();
      UpdateUI();
      CheckForTreeDeath();
    }

    void CheckForTreeDeath()
    {
        if (currentHitPoints <= 0)
          TreeDied();
    }
    private void TreeDied()
    {
      countDie ++;
      Debug.Log(countDie);
      wood += TreeWood;
      wood += woodPoint;
      UpdateUI();
      SpawnTree();
    }
    private void SpawnTree()
    {
      SpawnDelay();
      treeData = areaManager.GetTree();
      SetTreeData();
      currentHitPoints = maxHitPoints;
      UpdateUI();
    }
    private void UpdateUI()
    {
      hitPointText.text = currentHitPoints + " HP";
      hitpointSlider.value = currentHitPoints / (float) maxHitPoints;
      woodText.text = "Wood: " + GetWoodCount();
    }
    // Get next Tree profile from scriptable object
    private void SetTreeData()
    {
        treeImage.sprite = treeData.TreeImage;
        maxHitPoints = treeData.BaseHitPoints;
        TreeWood = treeData.wood;
        treeNameText.text = treeData.name;
    }
    public double GetWoodCount()
    {
      return wood;
    }
    public int Axe()
    {
        return currentHitPoints -= hitPoint;
    }
    public int UpgradeWood()
    {      
      return woodPoint++;
    }
    public int UpgradeAxe()
    {
      return hitPoint++;
    }
    IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(transitionTime);
    }
    void Update()
    {
        UpdateUI();
    }
}
