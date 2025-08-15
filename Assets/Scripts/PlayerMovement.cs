using UnityEngine;

internal sealed class PlayerMovement : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private CharacterController player;

    [Header("Fields")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float movementInteprolation;

    private Vector3 moveDirection, finalMoveDirection = default;
    private float inputX, inputY = default;

    private void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector3(inputX, 0f, inputY);

        finalMoveDirection.x = Mathf.MoveTowards(player.transform.position.x, moveDirection.x, movementInteprolation * Time.deltaTime);
        finalMoveDirection.x = Mathf.Clamp(finalMoveDirection.x, finalMoveDirection.x, finalMoveDirection.x + 2f);
        finalMoveDirection.z = Mathf.MoveTowards(player.transform.position.z, moveDirection.z, movementInteprolation * Time.deltaTime);
        finalMoveDirection.z = Mathf.Clamp(finalMoveDirection.z, finalMoveDirection.z, finalMoveDirection.z + 2f);

        player.Move(finalMoveDirection * moveSpeed *  Time.deltaTime);
    }
}
