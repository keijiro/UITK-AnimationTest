using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public sealed class MenuAnimation : MonoBehaviour
{
    VisualElement _menu;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        _menu = root.Q("menu");
    }

    /*
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            _menu.ToggleInClassList("hide-menu");
    }
    */
    float _displacement;
    bool _hide;

    static float CubicEaseInHalf(float x)
      => 4 * x * x * x;

    static float CubicEaseOut(float x)
      => 2 * CubicEaseInHalf(0.5f - 0.5f * x);

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            _hide = !_hide;

        var delta = (_hide ? 1 : -1) * 5;
        _displacement = Mathf.Clamp01(_displacement + delta * Time.deltaTime);

        _menu.transform.position = new Vector3(0, CubicEaseOut(_displacement) * 200, 0);
        _menu.style.opacity = _displacement;
    }
}
