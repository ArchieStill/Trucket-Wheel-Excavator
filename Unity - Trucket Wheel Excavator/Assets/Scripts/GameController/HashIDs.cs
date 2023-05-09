using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashIDs : MonoBehaviour
{
	public int dyingState;
	public int deadBool;
	public int walkState;
	public int speedFloat;
	public int sneakingBool;
	public int jumpingBool;
	public int sprintingBool;
	public int backwardsBool;

	private void Awake()
	{
		dyingState = Animator.StringToHash("BaseLayer.Dying");
		deadBool = Animator.StringToHash("Dead");
		walkState = Animator.StringToHash("Walk");
		speedFloat = Animator.StringToHash("Speed");
		sneakingBool = Animator.StringToHash("Sneaking");
		jumpingBool = Animator.StringToHash("Jumping");
		sprintingBool = Animator.StringToHash("Sprinting");
		backwardsBool = Animator.StringToHash("Backwards");
	}
}
