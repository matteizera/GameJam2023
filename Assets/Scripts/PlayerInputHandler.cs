using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerConfiguration playerConfig;
    private Mover mover;

/*    [SerializeField]
    private MeshRenderer playerMesh;*/

    private NewControls1 controls;
    private void Awake()
    {
         mover = GetComponent<Mover>();
        controls = new NewControls1();

    }

    public void InitializePlayer(PlayerConfiguration pc)
    {
        playerConfig = pc;
        /*playerMesh.material = pc.PlayerMaterial;*/
        playerConfig.Input.onActionTriggered += Input_onActionTriggered;
    }

    private void Input_onActionTriggered(CallbackContext obj)
    {
        if (obj.action.name == controls.Gameplay.Move.name)
        {
            OnMove(obj);
        }
    }
    
    public void OnMove(CallbackContext ctx)
    {
        if (mover != null)
        {
            mover.SetInputVector(ctx.ReadValue<Vector2>());
        }
    }
}
