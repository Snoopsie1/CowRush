using UnityEngine;

// This class is created for the example scene. There is no support for this script.
public class ControlsTutorial : MonoBehaviour
{
    private GameObject gamepadCommands;
    private readonly int h = 100;

    private GameObject KeyboardCommands;
    private string message = "";
    private bool showMsg;
    private GUIStyle style;
    private Rect textArea;
    private Color textColor;

    private readonly int w = 550;

    private void Awake()
    {
        style = new GUIStyle();
        style.alignment = TextAnchor.MiddleCenter;
        style.fontSize = 36;
        style.wordWrap = true;
        textColor = Color.white;
        textColor.a = 0;
        textArea = new Rect((Screen.width - w) / 2, 0, w, h);

        KeyboardCommands = transform.Find("ScreenHUD/Keyboard").gameObject;
        gamepadCommands = transform.Find("ScreenHUD/Gamepad").gameObject;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
        }

        KeyboardCommands.SetActive(Input.GetKey(KeyCode.F2));
        gamepadCommands.SetActive(Input.GetKey(KeyCode.F3) || Input.GetKey(KeyCode.Joystick1Button7));
    }

    private void OnGUI()
    {
        if (showMsg)
        {
            if (textColor.a <= 1)
                textColor.a += 0.5f * Time.deltaTime;
        }
        // no hint to show
        else
        {
            if (textColor.a > 0)
                textColor.a -= 0.5f * Time.deltaTime;
        }

        style.normal.textColor = textColor;

        GUI.Label(textArea, message, style);
    }

    public void SetShowMsg(bool show)
    {
        showMsg = show;
    }

    public void SetMessage(string msg)
    {
        message = msg;
    }
}