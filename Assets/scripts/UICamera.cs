using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICamera : MonoBehaviour
{
    public RawImage imageLeft;
    public RawImage imageRight;
    private Camera _camera;
    private RenderTexture tex;
    private Texture2D texture;

    void Start()
    {
        _camera = gameObject.GetComponent<Camera>();
        tex = new RenderTexture(100, 100, 24);
        texture = new Texture2D(100, 100);
        imageLeft.color = Color.white;
        imageRight.color = Color.white;
    }

    // Adjust the camera's height so the desired scene width fits in view
    // even if the screen/window size changes dynamically.
    void Update()
    {
        if (tex.width != Screen.width || tex.height != Screen.height)
        {
            RenderTexture.active = tex;
            //_camera.release
            tex = new RenderTexture(Screen.width, Screen.height, 24);//Create new texture with data
            texture.Resize(Screen.width, Screen.height);
        }
        //_camera.Render();
        _camera.targetTexture = tex;
        //RenderTexture renderTexture = _camera.targetTexture;//Get camera texture
        RenderTexture.active = tex;
        //_camera.Render();
        //Debug.Log(renderTexture.width);

        texture.ReadPixels(new Rect(0, 0, tex.width, tex.height), 0, 0);//Read data to texture
        texture.Apply();//apply it

        imageLeft.texture = texture;
        imageRight.texture = texture;
        //camera.targetTexture = null;
        //RenderTexture.active = null; //Clean
        //Destroy(rt); //Free memory
    }
}
