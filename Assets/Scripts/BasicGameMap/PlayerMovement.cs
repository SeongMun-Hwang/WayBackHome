using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2.5f; //이동 속도
    public float mouseSensitivity = 50.0f; // 마우스 감도
    public float jumpForce = 5f;

    private float xRotation = 0.0f; // 카메라의 X축 회전값을 저장할 변수
    private Rigidbody rb;

    public Transform cameraTransform;
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // 시작 시 Rigidbody 컴포넌트를 가져옵니다.
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 플레이어 좌우 회전
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);

        // 카메라 상하 회전
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // 카메라 Transform에 회전 적용

        Vector3 moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

        // 점프
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}