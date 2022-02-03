using FishNet.Object;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : NetworkBehaviour
{
    [SerializeField]
    private float m_MoveSpeed;
    private CharacterController _characterController;

    private float _horizontalInput;
    private float _verticalInput;
    private Vector3 _movementOffset;
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        if (!base.IsOwner)
            return;

        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
        _movementOffset = new Vector3(_horizontalInput, Physics.gravity.y, _verticalInput) * (m_MoveSpeed * Time.deltaTime);
        _characterController.Move(_movementOffset);
    }
}
