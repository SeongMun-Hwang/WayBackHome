using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; //�̵� �ӵ�
    //ī�޶�
    public float mouseSensitivity = 50.0f; // ���콺 ����
    private float xRotation = 0.0f; // ī�޶��� X�� ȸ������ ������ ����

    private void Start()
    {
        
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // A�� D Ű �Է�
        float verticalInput = Input.GetAxis("Vertical"); // W�� S Ű �Է�

        // �÷��̾� ȸ�� ó��
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);

        // ī�޶� ���� ȸ�� ó��
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY; // X�� ȸ���� ���� (���� �巡���ϸ� ī�޶� �Ʒ��� �ٶ󺸵���)
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // ī�޶� ȸ�� ���� ����

        // �̵� ���� ���
        Vector3 moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;
        moveDirection.y = 0; // �߷� ������ ���� �ʵ��� y�� ���� (������)

        // �̵� ����
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }
}