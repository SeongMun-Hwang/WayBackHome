using UnityEngine;

public class MoveSun : MonoBehaviour
{
    public static MoveSun Instance { get; private set; } // �̱��� �ν��Ͻ�
    public float nowTime = 0; // �ð� ����

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // �ν��Ͻ��� ���ٸ� �� ��ü�� �ν��Ͻ��� ����
            DontDestroyOnLoad(gameObject); // ���� ����Ǿ �ı����� �ʵ��� ����
        }
        else
        {
            Destroy(gameObject); // �̹� �ν��Ͻ��� �����ϸ� �ߺ� ������ ��ü�� �ı�
        }
    }

    private void Update()
    {
        if (nowTime < 24)
        {
            nowTime += Time.deltaTime; // �ð� ������Ʈ
        }
        else { nowTime = 0; }

        float rotationDegree = nowTime * 360f / 24f; // �Ϸ翡 360�� ȸ���� ����

        // 'SunCenter' GameObject(�� ��ũ��Ʈ�� ������ GameObject)�� ȸ��
        transform.rotation = Quaternion.Euler(rotationDegree, 45, 0);
    }
}
