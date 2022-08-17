using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Camera-Control/MouseLook")]
public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2
    }

    [SerializeField]
    private RotationAxes _axes = RotationAxes.MouseXandY;
    [SerializeField]
    private float _sensitivityX;
    [SerializeField]
    private float _sensitivityY;
    [SerializeField]
    private float _minX;
    [SerializeField]
    private float _maxX;
    [SerializeField]
    private float _minY;
    [SerializeField]
    private float _maxY;

    private float _rotationX = 0f;
    private float _rotationY = 0f;

    Quaternion _originalRotation;

    void Start()
    {
        if(GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
        _originalRotation = transform.localRotation;

        Cursor.visible = false;
    }

    void Update()
    {
        if(_axes == RotationAxes.MouseXandY)
        {
            _rotationX += Input.GetAxis("Mouse X") * _sensitivityX;
            _rotationY += Input.GetAxis("Mouse Y") * _sensitivityY;

            _rotationX = ClampAngle(_rotationX, _minX, _maxX);
            _rotationY = ClampAngle(_rotationY, _minY, _maxY);

            Quaternion xQuaternion = Quaternion.AngleAxis(_rotationX, Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(_rotationY, -Vector3.right);

            transform.localRotation =_originalRotation * xQuaternion * yQuaternion;
        }
        else if(_axes == RotationAxes.MouseX)
        {
            _rotationX += Input.GetAxis("Mouse X") * _sensitivityX;
            _rotationX = ClampAngle(_rotationX, _minX, _maxX);
            Quaternion xQuaternion = Quaternion.AngleAxis(_rotationX, Vector3.up);
            transform.localRotation = _originalRotation * xQuaternion;
        }
        else if (_axes == RotationAxes.MouseY)
        {
            _rotationY += Input.GetAxis("Mouse Y") * _sensitivityY;
            _rotationY = ClampAngle(_rotationY, _minY, _maxY);
            Quaternion yQuaternion = Quaternion.AngleAxis(_rotationY, -Vector3.right);
            transform.localRotation = _originalRotation * yQuaternion;
        }
    }

    private float ClampAngle (float angle, float min, float max)
    {
        if (angle < -360f)
            angle += 360f;

        if (angle > 360f)
            angle -= 360f;

        return Mathf.Clamp(angle, min, max);
    }
}
