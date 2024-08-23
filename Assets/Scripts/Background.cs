using UnityEngine;

public class Background : MonoBehaviour
{
    public Renderer meshRender;
    private float speed = 0.1f;
    void Update()
    {
        Vector2 offset = meshRender.material.mainTextureOffset;
        offset += new Vector2(speed * Time.deltaTime,0);
        meshRender.material.mainTextureOffset = offset;
    }
}