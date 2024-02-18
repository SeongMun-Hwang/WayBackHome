using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // ī�޶� �̵� �ӵ�
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // A�� D Ű �Է�
        float verticalInput = Input.GetAxis("Vertical"); // W�� S Ű �Է�

        // ī�޶��� ���� ��ġ�� �������� �Է¿� ���� ��ġ�� ������Ʈ�մϴ�.
        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }
}