using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; //이동 속도
    //카메라
    public float mouseSensitivity = 50.0f; // 마우스 감도
    private float xRotation = 0.0f; // 카메라의 X축 회전값을 저장할 변수

    private void Start()
    {
        
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // A와 D 키 입력
        float verticalInput = Input.GetAxis("Vertical"); // W와 S 키 입력

        // 플레이어 회전 처리
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);

        // 카메라 상하 회전 처리
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY; // X축 회전값 감소 (위로 드래그하면 카메라가 아래를 바라보도록)
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // 카메라 회전 범위 제한

        // 이동 방향 계산
        Vector3 moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;
        moveDirection.y = 0; // 중력 영향을 받지 않도록 y값 고정 (선택적)

        // 이동 실행
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }
}