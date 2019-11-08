using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SplitLib;

public class DealWithCamera : MonoBehaviour
{
    public GameObject wakeUpObject;
    public Camera dealCamera;
    public RawImage outPutView;
    
    private Texture2D screenShot;
    private SplitViewLib splitViewLib;
    // Start is called before the first frame update
    void Start()
    {
        dealCamera = (Camera)gameObject.GetComponent<Camera>();
        splitViewLib = new SplitViewLib();
        //StartCoroutine(Example());
        if (wakeUpObject)
        {
            wakeUpObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnPostRender()
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
        outPutView.texture = (Texture)splitViewLib.GetOutPutTextureFromCamera(camera);
    }
}
