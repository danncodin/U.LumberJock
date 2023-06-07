using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    public AreaProfile areaProfile;
    private int currentIndex = 0;
    
    public TreeData GetNextTree()
{
    if (currentIndex >= areaProfile.availableTreeProfiles.Count)
    {
        currentIndex = 0; // Reinicie o índice se chegarmos ao final da lista
    }
    
    TreeData treeData = areaProfile.availableTreeProfiles[currentIndex];
    currentIndex++;
    
    return treeData;
}

}
