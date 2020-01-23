using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : PickUp
{
    internal override void PickedUp()
    {
        PlayerShipSetter player = FindObjectOfType<PlayerShipSetter>();
        FindObjectOfType<GameSession>().UpdateScoreByOne();
        if(player.health<player.maxHealth)
            player.health++;
        GameObject.Find("Health Bar").GetComponent<SimpleHealthBar>().UpdateBar(player.health, player.maxHealth);
    }
        
}
