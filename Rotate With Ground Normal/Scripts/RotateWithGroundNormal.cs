using UnityEngine;

public class RotateWithGroundNormal : MonoBehaviour
{	
	public float rayDistance = 0.75f;
	public Transform rayPoint; // parented to the player gameObject
	
	public LayerMask groundLayers;

	Ray ray{ // i put it outside because i want it to call in to different methods (Update and OnDrawGizmos)
		get{
			return new Ray(rayPoint.position, Vector3.down);
		}
	}
	
	void Update(){
		RaycastHit hit;
		
		if(Physics.Raycast(ray, out hit, rayDistance, groundLayers)){
			Vector3 slopeAngle = hit.normal;
				transform.up = Smoothen(slopeAngle);
		}
		else
			transform.up = Smoothen(Vector3.up);
	}
	
	void OnDrawGizmos(){ // you don't really need this, just drawing a line for editor
		Gizmos.color = Color.green;
		Gizmos.DrawRay(ray);
	}
	
	#region Smoothing
	
		[Header("Smoothing")]
		public float smoothTime = 0.12f;
		
		Vector3
			currentSmoothDirection,
			directionSmoothVelocity;
			
		Vector3 Smoothen(Vector3 targetSmoothDirection){
			currentSmoothDirection = Vector3.SmoothDamp(
				currentSmoothDirection,
				targetSmoothDirection,
				ref directionSmoothVelocity,
				smoothTime
			);
			
			return currentSmoothDirection;
		}
	
	#endregion
}