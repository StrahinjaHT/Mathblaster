using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShipObject : ScriptableObject
{
    public string name;
    public int maxHealth;
    public float maxOverheat;
    public float speed;
    public Sprite sprite;
    [Multiline]
    public string description;
}
