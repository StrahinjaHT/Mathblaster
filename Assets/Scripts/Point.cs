using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : PickUp
{
    internal override void PickedUp()
    {
        FindObjectOfType<GameSession>().UpdateScore();
        FindObjectOfType<PlayerMovement>().health++;
        GameObject.Find("Health Bar").GetComponent<SimpleHealthBar>().UpdateBar(FindObjectOfType<PlayerMovement>().health, FindObjectOfType<PlayerMovement>().maxHealth);
    }
        
}
