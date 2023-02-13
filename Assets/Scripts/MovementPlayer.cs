using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class MovementPlayer : MonoBehaviour
{
    public Jump jump;



    private PlayerConfiguration playerConfig;
    public Transform atkPoint;
    public float atkRange = 1.0f;
    public LayerMask enemyLayers;
    public int dmg = 10;
    public Transform grabPoint;
    public float grabRange = 4.0f;
    public Transform hand;


    public CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 30.0f;
    private float turnSmoothVelocity;
    private float turnSmoothTime = 0.1f;
    private Animator mAnimator;
    private Vector2 movementInput;
    // public GameObject handr, handl;
    private IEnumerator coroutine;
    private bool useRightHand;
    private bool isAttacking = false;
    private float cooldown = 1.0f;
    private float nextAttackAllowed;
    public GameObject throwable;

    private NewControls1 controls;

    [Range(0, 45)] public float maxRoundVariation;
    public float muzzleOffset;
    private bool _jumpPressed;
    [SerializeField]
    private float _jumpHeight = 1.0f;
    private float _gravityValue = -9.81f;
    private void Start()

    {
        mAnimator = GetComponent<Animator>();   


    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 direction = new Vector3(movementInput.x, 0, movementInput.y);

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            controller.Move(direction * playerSpeed * Time.deltaTime);
            mAnimator.SetFloat("speed",1f);

        }else{
            mAnimator.SetFloat("speed",0);

        }

        if (direction != Vector3.zero)
        {
            gameObject.transform.forward = direction;
        }

       if(isAttacking && Time.time > nextAttackAllowed){
                nextAttackAllowed = Time.time + cooldown;
                isAttacking = false;
            }
    }

    public void InitializePlayer(PlayerConfiguration pc)
    {
        playerConfig = pc;
        /*playerMesh.material = pc.PlayerMaterial;*/
        playerConfig.Input.onActionTriggered += Input_onActionTriggered;
    }

    private void Input_onActionTriggered(CallbackContext obj)
    {

        switch (obj.action.name)
        {
            case "Move":
                OnMove(obj);
                break;
            case "FIRE":
                Fire(obj);
                break;
            case "JUMP":
                jump.OnJump(obj);
                break;
            case "GRAB":
                Grab(obj);
                break;
            case "HIT":
                Hit(obj);
                break;
            default:
                break;
        }
    }



    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

    public void Fire(InputAction.CallbackContext context)
    {
        if(throwable)
        {
            mAnimator.SetTrigger("isThrowing");
            GameObject spawnedRound = Instantiate(
                        throwable,
                        transform.position + transform.forward * muzzleOffset,
                        transform.rotation
                    );
            spawnedRound.tag = "Fire";
            spawnedRound.transform.localScale= new Vector3(100f,100f,100f); 
            spawnedRound.transform.Rotate(new Vector3(
                Random.Range(-1f, 1f) * maxRoundVariation,
                Random.Range(-1f, 1f) * maxRoundVariation,
                0
            ));
            spawnedRound.AddComponent<Rigidbody>();
            Rigidbody rb = spawnedRound.GetComponent<Rigidbody>();
            rb.velocity = spawnedRound.transform.forward * 100;
            Destroy(throwable);
            throwable=null;
        }
        // StartCoroutine(coroutine);

    }


    public void Hit(InputAction.CallbackContext context){
        if(!isAttacking){
            isAttacking = true;
            mAnimator.SetTrigger("isAttacking");
            mAnimator.SetBool("isLeftHand",useRightHand);
            useRightHand = !useRightHand;

            
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), GetComponent<Collider>());

            Collider[] hitEnemies = Physics.OverlapSphere(atkPoint.position,atkRange);
            foreach(Collider c in hitEnemies){
                    if(c.gameObject!=gameObject)
                        c.GetComponent<Health>().TakeDamage(dmg);
            }
        }
    }
    


    public void OnDrawGizmosSelected(){
        if(atkPoint == null)
        return;

        Gizmos.DrawWireSphere(atkPoint.position,atkRange);
        Gizmos.DrawWireSphere(grabPoint.position,grabRange);
    }

    public void Grab(InputAction.CallbackContext context){
        mAnimator.SetTrigger("isCatching");
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), GetComponent<Collider>());

            Collider[] hitItems = Physics.OverlapSphere(atkPoint.position,atkRange);
            foreach(Collider c in hitItems){
                //if(c.tag != null && c.tag != gameObject.tag){
                    if(c.tag == "Grabavel"){
                        throwable = c.gameObject;
                        c.gameObject.transform.SetParent(hand);
                        c.gameObject.transform.position = hand.position;
                        c.gameObject.transform.position += new Vector3(-0.00659999996f,0.0107000005f,0.0362000018f);
                        Quaternion targetqt = Quaternion.Euler(0.229303733f,64.5139847f,259.838257f);
                        c.gameObject.transform.rotation = targetqt;
                        
                    }
                //}
            }
            
    }

    private IEnumerator waitAndDisableHitbox(float waitTime){
        yield return new WaitForSeconds(waitTime);

    }
    

    private IEnumerator WaitAndDisableAnimation(string animation, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        mAnimator.SetBool(animation, false);

    }



//pegar itens

    
}
