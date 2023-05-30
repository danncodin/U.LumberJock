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
    public Slider hitpointSlider;
    public TextMeshProUGUI hitPointText;
    public TreeData treeData;
    public Image treeImage;
    public TextMeshProUGUI treeNameText;
    public AreaManager areaManager;


    private void Start()
    {
        SpawnTree();
        UpdateUI();
    }
    // Wire this to the tree button component 
    public void OnTreeClick()
    {
        TreeDamaged();
    }

    void TreeDamaged()
    {
      currentHitPoints -= 1;
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
      treeData = areaManager.GetTree();
      SetTreeData();
      currentHitPoints = maxHitPoints;
      UpdateUI();
    }
    private void UpdateUI()
    {
      hitPointText.text = currentHitPoints + " HP";
      hitpointSlider.value = currentHitPoints / (float) maxHitPoints;
      woodText.text = "Wood: " + wood;
    }
    // Get next Tree profile from scriptable object
    private void SetTreeData()
    {
        treeImage.sprite = treeData.TreeImage;
        maxHitPoints = treeData.BaseHitPoints;
        TreeWood = treeData.wood;
        treeNameText.text = treeData.name;
    }

}
