using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DealWithCamera : MonoBehaviour
{
    public Camera dealCamera;
    public RawImage outPutView;
    public int piece = 4;
    private Texture2D screenShot;
    // Start is called before the first frame update
    void Start()
    {
        dealCamera = (Camera)gameObject.GetComponent<Camera>();
        //StartCoroutine(Example());
    }

    // Update is called once per frame
    void Update()
    {
        RTImage(dealCamera);
    }

    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(3);
        RTImage(dealCamera);
        print(Time.time);
    }

    void RTImage(Camera camera)
    {
        int resWidth = Screen.width;
        int resHeight = Screen.height;

        RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
        camera.targetTexture = rt; //Create new renderTexture and assign to camera
        screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false); //Create new texture

        camera.Render();

        RenderTexture.active = rt;

        int cutWidth = resWidth / piece;
        int cutHeight = resWidth / piece;
        for (var i = 0; i < piece; i++)
        {
            for (var j = 0; j < piece / 2; j+=2)
            {
                int posX = cutWidth * j;
                int posY = cutHeight * i;
                //copy left
                screenShot.ReadPixels(new Rect(posX, posY, cutWidth, cutHeight), posX, posY);
                //copy right
                screenShot.ReadPixels(new Rect(posX + resWidth / 2, posY, cutWidth, cutHeight), posX + cutWidth, posY);
            }

            for (var j = piece / 2; j < piece; j += 2)
            {
                int posX = cutWidth * j;
                int posY = cutHeight * i;
                //copy left
                screenShot.ReadPixels(new Rect(posX - resWidth / piece, posY, cutWidth, cutHeight), posX, posY);
                //copy right
                screenShot.ReadPixels(new Rect(posX + cutWidth, posY, cutWidth, cutHeight), posX + cutWidth, posY);
            }
        }

        screenShot.Apply();


        //screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0); //Apply pixels from camera onto Texture2D

        outPutView.texture = (Texture)screenShot;
        //byte[] _bytes = screenShot.EncodeToPNG();
        //System.IO.File.WriteAllBytes("./www.png", _bytes);
        //Debug.Log(_bytes.Length / 1024 + "Kb was saved as: " + _fullPath);

        camera.targetTexture = null;
        RenderTexture.active = null; //Clean
        Destroy(rt); //Free memory
    }
}
