using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tree : MonoBehaviour
{
    public int wood;
    public int TreeWood;
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
    public UpgradeWoodManager woodUP;


    private void Start()
    {
        woodUP = FindAnyObjectByType<UpgradeWoodManager>();
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
      wood += TreeWood;
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
    public int GetWoodCount()
    {
      return wood;
    }
    public int Axe()
    {
        return currentHitPoints -= 1;
    }
    public int UpgradeWoodMethod()
    {
      return woodUP.UpgradeWood() * GetWoodCount();
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
