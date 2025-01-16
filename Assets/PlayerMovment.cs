using UnityEditor;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [Header("-----------blabla---------")]
    [SerializeField] private Transform GFX;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpforce = 10f;
    private bool isGrounded = false;
    private bool isJumping = false;
    private float jumptimer;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform feetPos;
    [SerializeField] private float groundDistance = 0.25f;
    [SerializeField] private float jumpTime = 0.3f;
    [SerializeField] private float crouchHeight = 0.5000f;
    private float Height = 0.7527784F;


  

    private void Update()
    {
        //jump
        #region
        isGrounded = Physics2D.OverlapCircle(feetPos.position, groundDistance, groundLayer);
        if (isGrounded && Input.GetButtonDown("Jump")) {
            isJumping = true;
            rb.linearVelocity = Vector2.up * jumpforce;
        }

        if (isJumping && Input.GetButton("Jump"))
        {
            if (jumptimer < jumpTime) {
                rb.linearVelocity = Vector2.up * jumpforce;
                jumptimer += Time.deltaTime;
            }
            else isJumping = false;
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            jumptimer = 0;
        }
        #endregion
        //crouching
        #region
    
        if(isGrounded && Input.GetKey(KeyCode.LeftShift))
        {
            GFX.localScale = new Vector3(GFX.localScale.x, crouchHeight, GFX.localScale.z);
        }

        if(isGrounded && Input.GetKeyUp(KeyCode.LeftShift))
        {
            GFX.localScale = new Vector3(GFX.localScale.x, Height, GFX.localScale.z);
        }
    
        #endregion

    }
}
