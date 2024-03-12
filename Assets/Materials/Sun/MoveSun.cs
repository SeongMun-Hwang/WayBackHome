using UnityEngine;

public class MoveSun : MonoBehaviour
{
    public float nowTime = 0; // �ð� ����

    private void Update()
    {
        nowTime += Time.deltaTime; // �ð� ������Ʈ
        float rotationDegree = nowTime * 360f / 24f; // �Ϸ翡 360�� ȸ���� ����

        // 'SunCenter' GameObject(�� ��ũ��Ʈ�� ������ GameObject)�� ȸ��
        transform.rotation = Quaternion.Euler(rotationDegree, 0, 0);
    }
}
