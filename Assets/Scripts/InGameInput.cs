using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InGameInput : MonoBehaviour
{
    GameInput input;

    public static UnityAction onInteractPressed;
    public static UnityAction onPausePressed;

    public static Vector2 onMouseMove;
    public static Vector2 onMove;
    public static bool IsDash;
    private static float val;

    private bool canMove = false;

    private static float dashValue
    {
        set
        {
            val = value;
            if(val > 0)
                IsDash = true;
            else
                IsDash = false;
        }

        get
        {
            return val;
        }
    }

    [SerializeField] TMP_Text debugText;

    private void Awake()
    {
        input = new GameInput();
    }

    private void OnEnable()
    {
        input.Enable();
        input.InGame.Interact.performed += InteractInput;
        input.InGame.PauseMenu.performed += PauseInteract;
        InGameStatus.OnStatusChange += OnStatusChange;
    }

    private void Update()
    {
        if (!canMove)
        {
            onMouseMove = Vector2.zero;
            onMove = Vector2.zero;
            dashValue = 0;
            return;
        }

        onMouseMove = input.InGame.Look.ReadValue<Vector2>();
        onMove = input.InGame.HorizontalMove.ReadValue<Vector2>();
        dashValue = input.InGame.Dash.ReadValue<float>();
        if(debugText != null)
            debugText.SetText(IsDash.ToString());
    }


    private void OnDisable()
    {
        InGameStatus.OnStatusChange += OnStatusChange;
        input.InGame.Interact.performed -= InteractInput;
        input.InGame.PauseMenu.performed -= PauseInteract;
        input.Disable();
    }

    void OnStatusChange(EStatus status)
    {
        canMove = status == EStatus.play;
    }

    //[ContextMenu("Check Map")]
    //public void ChangeInputMap()
    //{
    //    Debug.Log(action.actionMaps[0][]);
    //}
    void InteractInput(InputAction.CallbackContext ctx) { onInteractPressed?.Invoke(); }
    void PauseInteract(InputAction.CallbackContext ctx) { onPausePressed?.Invoke(); }
}
