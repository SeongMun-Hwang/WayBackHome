using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // 카메라 이동 속도
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // A와 D 키 입력
        float verticalInput = Input.GetAxis("Vertical"); // W와 S 키 입력

        // 카메라의 현재 위치를 기준으로 입력에 따라 위치를 업데이트합니다.
        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }
}