using UnityEngine;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.OnScreen;

public class InputSystemJoystickSetter : OnScreenControl
{
    [InputControl(layout = "Vector2")]
    [SerializeField] private string m_ControlPath;
    protected override string controlPathInternal { get => m_ControlPath; set => m_ControlPath = value; }
    public void SendJoystickValue(Vector2 value)
    {
        SendValueToControl(value);
    }
}

