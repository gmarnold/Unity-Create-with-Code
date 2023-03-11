using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    // Private variables
    private Renderer render;
    private float scrollSpeed = .01f;

    void Start()
    {
        // Getting the renderer
        render = GetComponent<Renderer>();
    }

    void Update()
    {
        // Setting the texture offset for the background so it scrolls
        float x = Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(x, 0);
        render.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
