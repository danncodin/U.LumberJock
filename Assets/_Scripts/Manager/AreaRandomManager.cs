using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaRandomManager : MonoBehaviour
{
    public AreaProfile areaProfile;
    
    public TreeData GetTree()
    {
        int index = Random.Range(0, areaProfile.availableTreeProfiles.Count);
        return areaProfile.availableTreeProfiles[index];
    }
}

