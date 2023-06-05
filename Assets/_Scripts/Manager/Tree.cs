using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Tree : MonoBehaviour
{
    public double wood;
    public int TreeWood;
    public int countDie = 0;
    public int countClick = 0;
    public int hitPoint = 1;
    public int woodPoint = 1;
    public GameObject woodPlus;
    public GameObject woodPlusTEXT;
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
    public AudioSource treeChopSound;
    public AudioSource treeDiyngSound;
    public GameObject dialogueTriggerButton;
    public DialogueTrigger dialogueTrigger;
    

    private void Start()
    {
      woodUP = FindAnyObjectByType<UpgradeAreaManager>();
      SpawnTree();
      UpdateUI();
    }
    // Wire this to the tree button component 
    public void OnTreeClick()
    {
        // woodPlus.SetActive(false);
        // woodPlus.transform.position = new Vector3(Random.Range(-5,-2), Random.Range(-2,2),0);
        // woodPlus.SetActive(true);
        // StopAllCoroutines();
        // StartCoroutine(Fly());

        Instantiate(woodPlus, transform.position, transform.rotation);
        treeChopSound.Play();
        TreeDamaged();
        GetWoodCount();
    }

    void TreeDamaged()
    {
      treeDiyngSound.Play();
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
      Instantiate(woodPlusTEXT,transform.position, transform.rotation);
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
      woodText.text = "" + GetWoodCount();
    }
    // Get next Tree profile from scriptable object
    private void SetTreeData()
    {
        treeImage.sprite = treeData.TreeImage;
        maxHitPoints = treeData.BaseHitPoints;
        TreeWood = treeData.wood;
        treeNameText.text = treeData.name;
    }
    // IEnumerator Fly()
    // {
    //   for(int i = 0; i<=0;i++)
    //   {
    //     yield return new WaitForSeconds(.2f);
    //     woodPlus.transform.position = new Vector3(woodPlus.transform.position.x, woodPlus.transform.position.y +2,0);
    //   }

    //   woodPlus.SetActive(false);
    // }
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
    public int CountDie()
    {
      return countDie;
    }
    void Update()
    {
      UpdateUI();
      // if (countDie == 0)
      // {
        
      //   // dialogueTrigger.StartDialogue();
      // }
      // if (countDie == 3)
      // {
      //   dialogueTriggerButton.gameObject.SetActive(true);
      // }
  }
}
