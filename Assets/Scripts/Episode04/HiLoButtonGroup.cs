using UnityEngine;

public class HiLoButtonGroup : MonoBehaviour
{
    [SerializeField] private HiLoButton _highButton;
    [SerializeField] private HiLoButton _swingButton;
    [SerializeField] private HiLoButton _lowButton;

    public HiLoButton HighButton { get { return _highButton; } set { _highButton = value; } }
    public HiLoButton SwingButton { get { return _swingButton; } set { _swingButton = value; } }
    public HiLoButton LowButton { get { return _lowButton; } set { _lowButton = value; } }
}
