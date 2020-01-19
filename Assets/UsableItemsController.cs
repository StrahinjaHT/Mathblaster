using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UsableItemsController : MonoBehaviour
{
    int numberOfFreezenovaBombs = 0;
    int numberOfFirestormBombs = 0;
    [SerializeField] TextMeshProUGUI numberOfFreezenovaBombsText;
    [SerializeField] TextMeshProUGUI numberOfFirestormBombsText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateItemState();
    }

    private void UpdateItemState()
    {
        numberOfFreezenovaBombsText.text = "x " + numberOfFreezenovaBombs.ToString();
        numberOfFirestormBombsText.text = "x " + numberOfFirestormBombs.ToString();
    }
    public void AddFreezenovaBomb()
    {
        numberOfFreezenovaBombs++;
        UpdateItemState();
    }
    public void AddFirestormBomb()
    {
        numberOfFirestormBombs++;
        UpdateItemState();
    }
    public void UseFreezenovaBomb()
    {
        if (numberOfFreezenovaBombs <= 0)
        {
            return;
        }
        foreach (Enemy e in FindObjectsOfType<Enemy>())
        {
            e.speed = 0f;
        }
        FindObjectOfType<SoundManager>().FreezenovaBombUsed();
        numberOfFreezenovaBombs--;
        UpdateItemState();
    }
    public void UseFirestormBomb()
    {
        if(numberOfFirestormBombs<=0)
        {
            return;
        }
        foreach(Enemy e in FindObjectsOfType<Enemy>())
        {
            e.Explode();
        }
        numberOfFirestormBombs--;
        UpdateItemState();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
