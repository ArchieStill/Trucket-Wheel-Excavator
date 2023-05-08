using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckHashIDs : MonoBehaviour
{
    public int drivingState;
	public int speedFloat;
	public int upBool;
	public int spinBool;
	public int driveBool;
	public int moveWheel;

	private void Awake()
	{
		// drivingState = Animator.StringToHash("Drive");
		// speedFloat = Animator.StringToHash("Speed");
		// upBool = Animator.StringToHash("WheelUp");
		spinBool = Animator.StringToHash("WheelMove");
		driveBool = Animator.StringToHash("TruckMoving");
		moveWheel = Animator.StringToHash("MoveUp");
	}
}
