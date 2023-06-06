using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    public AreaProfile areaProfile;
    
    public TreeData GetTree()
    {
        // var treeData = areaProfile.availableTreeProfiles[0];
        // Get a random tree profile from the list of trees in areaProfile
        // for (int i = 0; i < ; i++)
        // {
            
        // }
        
        int index = Random.Range(0, areaProfile.availableTreeProfiles.Count);
        return areaProfile.availableTreeProfiles[index];
    }
}
