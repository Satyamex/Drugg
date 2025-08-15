using UnityEngine;

internal sealed class PlayerMovement : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private CharacterController player;

    [Header("Fields")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float movementInteprolation;

    private Vector3 finalMoveDirection, inputDirection, targetDirection = default;

    private void Update()
    {
        inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        targetDirection = (player.transform.right * inputDirection.x + player.transform.forward * inputDirection.z).normalized;

        finalMoveDirection = Vector3.MoveTowards(finalMoveDirection, targetDirection, movementInteprolation * Time.deltaTime);
        player.Move(finalMoveDirection * moveSpeed * Time.deltaTime);
    }
}
