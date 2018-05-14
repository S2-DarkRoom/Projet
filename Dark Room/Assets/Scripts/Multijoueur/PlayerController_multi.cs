using UnityEngine;

[RequireComponent(typeof(PlayerMotor_multi))]
public class PlayerController_multi : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float lookSensitivity = 3f;

    private PlayerMotor_multi motor;

    private void Start()
    {
        motor = GetComponent<PlayerMotor_multi>();
    }

    private void Update()
    {
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _xMov;
        Vector3 _moveVertical = transform.forward * _zMov;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;

        motor.Move(_velocity);

        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0, _yRot, 0) * lookSensitivity;

        motor.Rotate(_rotation);

        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(_xRot, 0, 0) * lookSensitivity;

        motor.RotateCamera(_cameraRotation);
    }
 }
