using TMPro;
using UnityEngine;

public class UsableItemsController : MonoBehaviour
{
    int numberOfStunRays = 0;
    int numberOfFirestormBombs = 0;
    [SerializeField] TextMeshProUGUI numberOfStunRaysText;
    [SerializeField] TextMeshProUGUI numberOfFirestormBombsText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateItemState();
    }

    private void UpdateItemState()
    {
        numberOfStunRaysText.text = "x " + numberOfStunRays.ToString();
        numberOfFirestormBombsText.text = "x " + numberOfFirestormBombs.ToString();
    }
    public void AddStunRay()
    {
        numberOfStunRays++;
        UpdateItemState();
    }
    public void AddFirestormBomb()
    {
        numberOfFirestormBombs++;
        UpdateItemState();
    }
    public void UseStunRay()
    {
        if (numberOfStunRays <= 0)
        {
            FindObjectOfType<SoundManager>().NotEnoughPoints();
            return;
        }
        foreach (Enemy e in FindObjectsOfType<Enemy>())
        {
            e.speed = 0f;
        }
        FindObjectOfType<SoundManager>().FreezenovaBombUsed();
        numberOfStunRays--;
        UpdateItemState();
    }
    public void UseFirestormBomb()
    {
        if(numberOfFirestormBombs<=0)
        {
            FindObjectOfType<SoundManager>().NotEnoughPoints();
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
