using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] private Rigidbody2D _rb;
   [SerializeField] private float _moveSpeed = 5f;
   [SerializeField] private float _jumpForce = 10f;
   [SerializeField] private Transform _groundCheck;
   [SerializeField] private Vector2 _groundCheckSize= new Vector2(.5f, .05f);
   [SerializeField] private LayerMask _groundMask;
   private bool _canJump = true;
   
   public static event Action OnJump;
   
   private float _horizontalMovement = 0f;


   private void Start()
   {
      GameController.PreventJump += CantJump;
      GameController.EnableJump += CanJump;
   }

   private void CanJump(bool enable)
   {
      _canJump = enable;
      Debug.Log("Can Jump");
   }

   private void CantJump(bool disable)
   {
      _canJump = disable;
      Debug.Log("CantJump");
   }

   private void Update()
   {
      _rb.linearVelocity = new Vector2(_horizontalMovement * _moveSpeed, _rb.linearVelocity.y);
   }

   public void Move(InputAction.CallbackContext context)
   {
      _horizontalMovement = context.ReadValue<Vector2>().x;
      
   }

   public void Jump(InputAction.CallbackContext context)
   {
      if (IsGrounded() && _canJump)
      {
         if (context.performed)
         {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _jumpForce);
            OnJump?.Invoke();
         }
      }


   }

   public bool IsGrounded()
   {
      if (Physics2D.OverlapBox(_groundCheck.position, _groundCheckSize, 0, _groundMask))
      {
         return true;
      }
      return false;
   }

   public void OnDrawGizmosSelected()
   {
      Gizmos.color = Color.white;
      Gizmos.DrawWireCube(_groundCheck.position, _groundCheckSize);
   }
}
