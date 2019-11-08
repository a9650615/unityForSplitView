using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertScreenPoint : MonoBehaviour
{
    public GameObject mousePosEle;
    public Camera showCamera;
    protected Canvas myCanvas;
    private Vector2 outputPos;

    // Start is called before the first frame update
    void Start()
    {
        myCanvas = gameObject.GetComponent<Canvas>();

    }

    // Update is called once per frame
    void Update()
    {
        //myCanvas.transform.size
        RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, showCamera, out outputPos);

        mousePosEle.transform.localPosition = new Vector3(outputPos.x, outputPos.y, 0);
        //Debug.Log("print");
        //Debug.Log(outputPos);
        //Debug.Log(Input.mousePosition);
        //Debug.Log(mousePosEle.transform.position);
    }
}
