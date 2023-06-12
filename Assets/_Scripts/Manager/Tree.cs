using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class Tree : MonoBehaviour
{
    public double wood;
    public int TreeWood;
    public int countDie = 0;
    public double countClick = 0;
    public int upgradeMadeiraCount = 0;
    public int hitPoint = 1;
    public double woodPoint = 1;
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
    public AreaProfile areaProfile;
    public AreaOrderManager areaOrderManager;
    public AreaRandomManager areaRandomManager;
    public UpgradeAreaManager woodUP;
    public AudioClip[] sounds;
    public AudioManager audioManager;
    private AudioSource audioSource;
    public AudioSource treeDiyngSound;
    public GameObject dialogueEuropaTrigger1;
    public GameObject dialogueEuropaTrigger2;
    public GameObject dialogueEuropaTrigger3;
    public GameObject dialogueEuropaTrigger4;
    public GameObject dialogueAfricaTrigger1;
    public GameObject dialogueAfricaTrigger2;
    public GameObject dialogueAfricaTrigger3;
    public GameObject dialogueAfricaTrigger4;
    public GameObject dialogueAfricaTrigger5;
    public GameObject dialogueOceaniaTrigger1;
    public GameObject dialogueOceaniaTrigger2;
    public GameObject dialogueOceaniaTrigger3;
    public GameObject dialogueOceaniaTrigger4;
    public GameObject dialogueOceaniaTrigger5;


    private void Start()
    {


  if (countDie ==  0)
  {
      if (SceneManager.GetActiveScene().name == "Europa")
      {
        dialogueEuropaTrigger1.SetActive(true);
      }
      else if (SceneManager.GetActiveScene().name == "Africa")
      {
        dialogueAfricaTrigger1.SetActive(true);
      }
  }
      woodUP = FindAnyObjectByType<UpgradeAreaManager>();
      AudioManager audioManager = GetComponent<AudioManager>();
      audioSource = gameObject.AddComponent<AudioSource>();
      audioSource.volume = 0.7f;
      audioSource.playOnAwake = false;
      audioSource.spatialBlend = 0f;
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
        // CountClick();
        Instantiate(woodPlus, transform.position, transform.rotation);
        ClickMadeiraUP();
        TreeDamaged();
        GetWoodCount();
    }

    void TreeDamaged()
    {
      PlayRandomSound();
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
      FindObjectOfType<AudioManager>().Play("FallTree");
      countDie ++;
      wood += TreeWood;
      wood += woodPoint;
      UpdateUI();
      Instantiate(woodPlusTEXT,transform.position, transform.rotation);
      SpawnTree();
    }
    public void SpawnTree()
    {
      SpawnDelay();
      //ORDER
      if(countDie <  areaProfile.availableTreeProfiles.Count)
      {
        TreeData nextTreeData = areaOrderManager.GetNextTree();
        treeData = nextTreeData;
      }else
      {
        treeData = areaRandomManager.GetTree();
      }
      SetTreeData();
      currentHitPoints = maxHitPoints;
      Dialogue();
      UpdateUI();
    }
    private void UpdateUI()
    {
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
    public void Dialogue()
    {
      Debug.Log("countDie: " + countDie);
      if(countDie <  areaProfile.availableTreeProfiles.Count)
      {
        if (SceneManager.GetActiveScene().name == "Europa")
          {
            if (countDie == 1)
              {
                dialogueEuropaTrigger2.SetActive(true);
              }  
            if (upgradeMadeiraCount == 1)
              {
                dialogueEuropaTrigger3.SetActive(true);
              }
          }
        if (SceneManager.GetActiveScene().name == "Africa")
        { 
          if (countDie == 1)  
          {
            dialogueAfricaTrigger2.SetActive(true);
          }
          if (countDie == 2)
          {
            dialogueAfricaTrigger3.SetActive(true);
          }
          if (countDie == 3)
          {
            dialogueAfricaTrigger4.SetActive(true);
          }
        }
        if (SceneManager.GetActiveScene().name == "Oceania")
        { 
          if (countDie == 1)  
          {
            dialogueOceaniaTrigger1.SetActive(true);
          }
          if (countDie == 2)
          {
            dialogueOceaniaTrigger2.SetActive(true);
          }
          if (countDie == 34)
          {
            dialogueOceaniaTrigger3.SetActive(true);
          }
          if (countDie == 3)
          {
            dialogueOceaniaTrigger4.SetActive(true);
          }

        }
        
      
      }
    }
    public double GetWoodCount()
    {
      return wood;
    }
    public void PlayRandomSound()
    {
        if (sounds.Length == 0)
        {
            Debug.LogWarning("No sounds available to play.");
            return;
        }

        int randomIndex = Random.Range(0, sounds.Length);
        AudioClip randomSound = sounds[randomIndex];

        audioSource.PlayOneShot(randomSound);
    }
    public int Axe()
    {
        return currentHitPoints -= hitPoint;
    }
    public double UpgradeBolsa()
    {      
      woodPoint += TreeWood * 0.1 + 1;
      woodPoint = Math.Round(woodPoint);
      return woodPoint;
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
    public double UpgradeMadeira()
    {
      countClick+= TreeWood * 0.1 + 1;
      countClick = Math.Round(countClick);
      return upgradeMadeiraCount++;
    }
    public void ClickMadeiraUP()
    {
      if (upgradeMadeiraCount >= 1 )
      {
        double madeira = wood += countClick;
      }
    }
    
    // public int CountClick()
    // {
    //   return countClick++;
    // }
    void Update()
    {
      UpdateUI();
    }
}