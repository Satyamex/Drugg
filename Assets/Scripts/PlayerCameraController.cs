using UnityEngine;

internal sealed class PlayerCameraController : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private Transform camAnchorTransform;
    [SerializeField] private Transform playerTransform;

    [Header("Fields")]
    [SerializeField] private float cameraSensitivity;

    private float mouseX = default;
    private float mouseY = default;
    private float Xrot = default;
    private float Yrot = default;
    private bool isPaused = false;

    private void Update()
    {
        if (!isPaused)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;

            mouseX = Input.GetAxisRaw("Mouse X");
            mouseY = Input.GetAxisRaw("Mouse Y");

            Xrot -= mouseY * cameraSensitivity;
            Xrot = Mathf.Clamp(Xrot, -85f, 85f);
            Yrot += mouseX * cameraSensitivity;

            camAnchorTransform.localRotation = Quaternion.Euler(new Vector3(Xrot, 0f, 0f));
            playerTransform.localRotation = Quaternion.Euler(new Vector3(0f, Yrot, 0f));
        }

        else if (isPaused) 
            { Cursor.lockState = CursorLockMode.None; Cursor.visible = true; }

        if (Input.GetKeyDown(KeyCode.Escape))
            isPaused = !isPaused;
    }
}
