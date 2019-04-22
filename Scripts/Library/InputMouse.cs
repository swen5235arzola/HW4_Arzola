using UnityEngine;
using System.Collections;
using Mission;

/// <summary>
/// Author: Space Walk Author
/// Modfieid By: Adriana Arzola
/// SWEN 5235 - HW 4
/// </summary>
[AddComponentMenu("Camera-Control/Mouse Look")]
public class InputMouse : MonoBehaviour
{
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	
	public float minimumX = -360F;
	public float maximumX = 360F;
	
	public float minimumY = -60F;
	public float maximumY = 60F;
	
	float rotationY = 0F, rotationX = 0F;

    /// <summary>
    /// Called once a frame
    /// Cyclomatic Complexity: 5
    /// </summary>
    void Update ()
	{
        if ((Mission.Mission.ISMENU == false)||(Mission.Mission.ISFAIL == false))
        {
			if(Mission.Mission.LEVELPIVOT == 2){
                minimumX = -360F;
                maximumX = 360F;
                minimumY = -60F;
                maximumY = 60F;
			}

			if (axes == RotationAxes.MouseXAndY)
			{
                rotationX += Input.GetAxis("Mouse X") * sensitivityX;
                rotationX = Mathf.Clamp (rotationX, minimumX, maximumX);
                //float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
                //print (rotationX);

                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

                transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
			}
			else if (axes == RotationAxes.MouseX)
			{
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
			}
			else
			{
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

                transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
			}
		}
	}
	
	void Start ()
	{
		// Make the rigid body not change rotation
		if (GetComponent<Rigidbody>())
			GetComponent<Rigidbody>().freezeRotation = true;
	}

	void OnGUI(){
		GetComponent<Camera>().backgroundColor = Color.black;
	}
}
