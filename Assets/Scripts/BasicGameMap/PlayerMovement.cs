using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2.5f; //�̵� �ӵ�
    public float mouseSensitivity = 50.0f; // ���콺 ����
    public float jumpForce = 5f;

    private float xRotation = 0.0f; // ī�޶��� X�� ȸ������ ������ ����
    private Rigidbody rb;

    public Transform cameraTransform;
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // ���� �� Rigidbody ������Ʈ�� �����ɴϴ�.
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // �÷��̾� �¿� ȸ��
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);

        // ī�޶� ���� ȸ��
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // ī�޶� Transform�� ȸ�� ����

        Vector3 moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

        // ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}