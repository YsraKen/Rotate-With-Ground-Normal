using UnityEngine;

public class PlayerController : MonoBehaviour
{
	#region Variables
	
		[Header("Movement")]
		public float moveSpeed = 5f;
			Vector2 inputDir;
			
		[Header("Jumping")]
		public float jumpForce = 10f;
		public ForceMode jumpForceMode = ForceMode.Impulse;
		
		[Space(10)]
		public Rigidbody rb;
		
	#endregion
	
	#region Inputs
	
		void Update()
		{
			// Movement
			inputDir = new Vector2(
				Input.GetAxisRaw("Horizontal"),
				Input.GetAxisRaw("Vertical")
			).normalized;
			
			// Jumping
				if(Input.GetButtonDown("Jump")){ // you can use "RotateWithGroundNormal" script for ground-checking
					rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
					rb.AddForce(Vector3.up * jumpForce, jumpForceMode);
				}
		}
	
	#endregion
	
	#region Motor
	
		void FixedUpdate(){
			var moveVeloctiy = inputDir * moveSpeed;
			
			var targetVelocity = new Vector3(
				moveVeloctiy.x,
				rb.velocity.y,
				moveVeloctiy.y
			);
			
				rb.velocity = targetVelocity;
		}
	
	#endregion
}
