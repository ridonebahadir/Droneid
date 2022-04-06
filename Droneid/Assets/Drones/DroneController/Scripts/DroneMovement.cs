using DroneController.Physics;
using UnityEngine;

public class DroneMovement : DroneMovementScript {


    public override void Awake()
    {
        base.Awake(); //I would suggest you to put code below this line or in a Start() method
    }
    public float droneUpBorder = 20f;
    public float droneDownBorder = 5f;
    void FixedUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5f, 5f), Mathf.Clamp(transform.position.y, droneDownBorder, droneUpBorder), transform.position.z);
        GetVelocity();
        ClampingSpeedValues();
		SettingControllerToInputSettings(); //sensitivity settings for joystick,keyboard,mobile (depending on which is turned on)
		if (FlightRecorderOverride == false)
		{
			MovementUpDown();
			MovementLeftRight();
			//Rotation();
			MovementForward();
			BasicDroneHoverAndRotation(); //this method applies all the forces and rotations to the drone.
		}
	}

    void Update () {
        //RotationUpdateLoop_TrickRotation(); //applies rotation to the drone it self when doing the barrel roll trick, does NOT trigger the animation
        //Animations(); //part where animations are triggered
        ////DroneSound(); //sound producing stuff
        //CameraCorrectPickAndTranslatingInputToWSAD(); //setting input for keys, translating joystick, mobile inputs as WSAD (depending on which is turned on)
    }

}
