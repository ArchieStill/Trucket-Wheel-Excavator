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
		spinBool = Animator.StringToHash("WheelMove");
		driveBool = Animator.StringToHash("TruckMoving");
		moveWheel = Animator.StringToHash("MoveUp");
	}
}
