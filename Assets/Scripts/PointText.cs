using UnityEngine;

public class PointText : MonoBehaviour
{
    public float time = 0f;
    public float timeUp = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyAfterSetTime();
        if(!PauseGame.gameIsPaused && !ShopScript.shopWindowOpen)
        FloatUp();
    }
    private void DestroyAfterSetTime()
    {
        if (time > timeUp) Destroy(gameObject);
        time += Time.deltaTime;
    }
    private void FloatUp()
    {
        transform.localPosition += new Vector3(0, 0.02f, 0);
    }
}
