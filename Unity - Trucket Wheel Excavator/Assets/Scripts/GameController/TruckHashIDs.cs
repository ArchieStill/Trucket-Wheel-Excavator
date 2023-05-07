using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckHashIDs : MonoBehaviour
{
    public int drivingState;
	public int speedFloat;
	public int upBool;
	public int spinBool;

	private void Awake()
	{
		drivingState = Animator.StringToHash("TWE Moving");
		speedFloat = Animator.StringToHash("Speed");
		upBool = Animator.StringToHash("Wheel Going Up");
		spinBool = Animator.StringToHash("Wheel Moving (Lowered)");
	}
}
