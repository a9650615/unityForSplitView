using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ServerSpace;
using WebSocketSharp;
using WebSocketSharp.Server;

public static class ControlData {
    public static string lastControlState = "";
}

public class MainController: WebSocketBehavior
{
    protected override void OnMessage(MessageEventArgs e)
    {
        ControlData.lastControlState = e.Data;
        //switch (e.Data)
        //{
        //    case "w":
        //        ControlData.lastControlState = "w";
        //        break;
        //    case "a":
        //        ControlData.lastControlState = "a";
        //        break;
        //    case "s":
        //        ControlData.lastControlState = "s";
        //        break;
        //    case "d":
        //        ControlData.lastControlState = "d";
        //        break;
        //    default:
        //        //ControlData.lastControlState = "";
        //        break;
        //}

        //Send("ok");
    }
}

public class MainViewController : MonoBehaviour
{
    public GameObject mainView;
    // Start is called before the first frame update
    void Start()
    {
        var server = new Server();
    }

    // Update is called once per frame
    void Update()
    {
        switch (ControlData.lastControlState)
        {
            case "w":
                mainView.transform.Translate(Vector3.forward * Time.deltaTime, Space.World);
                break;
            case "a":
                mainView.transform.Translate(Vector3.left * Time.deltaTime, Space.World);
                break;
            case "s":
                mainView.transform.Translate(Vector3.back * Time.deltaTime, Space.World);
                break;
            case "d":
                mainView.transform.Translate(Vector3.right * Time.deltaTime, Space.World);
                break;
        }
    }
}
