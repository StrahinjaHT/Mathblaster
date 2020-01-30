using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float bgScrollSpeedX = 0.1f;
    [SerializeField] float bgScrollSpeedY = 0.1f;
    Material material;
    Vector2 offset;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        offset = new Vector2(bgScrollSpeedX, bgScrollSpeedY);
    }

    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
