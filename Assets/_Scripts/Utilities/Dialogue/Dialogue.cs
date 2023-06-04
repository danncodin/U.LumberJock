using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

[System.Serializable]
public class Dialogue
{
    public string name; 
    [TextArea(1, 10)]
    public string[] sentences;
}
