using UnityEngine;
using System.Collections;
//this script can be found in the Component section under the option Game Systems/Player/Mouse Look
[AddComponentMenu("Game Systems/Player/Mouse Look")]
public class MouseLook : MonoBehaviour
{
    /*
     enums are what we call state value variables 
     they are comma separated lists of identifiers
     we can use them to create Types or Categorys
         */
    #region RotationalAxis
    //Create a public enum called RotationalAxis
    public enum RotationalAxis
    {
        MouseX,
        MouseY
    }
    #endregion
    #region Variables
    [Header("Rotation")]
    public RotationalAxis axis;
    //create a public link to the rotational axis called axis and set a defualt axis
    //[Header("Sensitivity")]
    //public floats for our x and y sensitivity
    public Vector2 sensitivity;
    //[Range(0, 100)]
    [Header("Y Rotation Clamp")]
    //max and min Y rotation
    public Vector2 rotationY;
    //we will have to invert our mouse position later to calculate our mouse look correctly
    public bool invert;
    //float for rotation Y
    float _rotY;
    #endregion
    #region Start
    private void Start()
    {
        //Lock Cursor to middle of screen
        Cursor.lockState = CursorLockMode.Locked;
        //Hide Cursor from view
        Cursor.visible = false;
        //if our game object has a rigidbody attached to it
        if (GetComponent<Rigidbody>())
        {
            //set the rigidbodys freezRotaion to true
            GetComponent<Rigidbody>().freezeRotation = true;
        }

    }
    #endregion
    #region Update
    private void Update()
    {
        #region Mouse X
        //else if we are rotating on the X
        if (axis == RotationalAxis.MouseX)
        {
            //transform the rotation on our game objects Y by our Mouse input Mouse X times X sensitivity
            //x                y                          z
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity.x, 0);
        }
        #endregion
        #region Mouse Y
        //else we are only rotation on the Y
        else
        {

            //our rotation Y is pulse equals  our mouse input for Mouse Y times Y sensitivity
            _rotY += Input.GetAxis("Mouse Y") * sensitivity.y;
            //the rotation Y is clamped using Mathf and we are clamping the y rotation to the Y min and Y max
            _rotY = Mathf.Clamp(_rotY, rotationY.x, rotationY.y);
            //transform our local position to the nex vector3 rotaion - y rotaion on the x axis and local euler angle Y on the y axis
            if (!invert)
            {
                transform.localEulerAngles = new Vector3(-_rotY, 0, 0);
            }
            else
            {
                transform.localEulerAngles = new Vector3(_rotY, 0, 0);
            }
        }
        #endregion
    }
    #endregion

}













