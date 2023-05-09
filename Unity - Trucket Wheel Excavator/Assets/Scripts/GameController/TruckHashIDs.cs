using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckHashIDs : MonoBehaviour
{
    public int drivingState;
	public int speedFloat;
	public int upBool;
	public int driveBool;
	public int spinSBool;
	public int spinCBool;
	public int moveWheel;

	private void Awake()
	{
		driveBool = Animator.StringToHash("Drive");
		spinSBool = Animator.StringToHash("WheelSpin Start");
		spinCBool = Animator.StringToHash("WheelSpin Cont");
		moveWheel = Animator.StringToHash("MoveUp");
	}
}
