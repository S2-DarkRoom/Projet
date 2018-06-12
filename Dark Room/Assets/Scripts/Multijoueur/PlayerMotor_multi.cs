using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor_multi : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 velocity;
    private Vector3 rotation;
    private float cameraRotationX = 0f;
    private float currentrotX = 0f;

    [SerializeField]
    private float rotXlimit = 85f;

    private Rigidbody rb;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void RotateCamera(float _cameraRotationX)
    {
        cameraRotationX = _cameraRotationX;
    }

    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
	}

    private void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    private void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        currentrotX -= cameraRotationX;
        currentrotX = Mathf.Clamp(currentrotX, -rotXlimit, rotXlimit);

        cam.transform.localEulerAngles = new Vector3(currentrotX, 0f, 0f);
    }

}
