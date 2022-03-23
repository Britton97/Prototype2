using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Animal", menuName = "Animal")]
public class AnimalScriptableObject : ScriptableObject
{
    public GameObject myAnimal;
    public float speed;
    public GameObject myFood;
    public string foodName;
}
