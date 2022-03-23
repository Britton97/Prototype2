using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Food", menuName = "Animal Food")]
public class FoodScriptableObj : ScriptableObject
{
    public GameObject foodModel;
    [Range(0,40)]
    public float speed;
    public GameObject whoEatsMe;
    public string foodName;
}
