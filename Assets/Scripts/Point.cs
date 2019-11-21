using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : PickUp
{
    internal override void PickedUp()
    {
        FindObjectOfType<GameSession>().UpdateScore();
    }

    internal override void SetUpPickUp()
    {
        
    }

    
}
