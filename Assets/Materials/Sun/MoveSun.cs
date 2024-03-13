using UnityEngine;

public class MoveSun : MonoBehaviour
{
    public static MoveSun Instance { get; private set; } // 싱글톤 인스턴스
    public float nowTime = 0; // 시간 변수

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // 인스턴스가 없다면 이 객체를 인스턴스로 설정
            DontDestroyOnLoad(gameObject); // 씬이 변경되어도 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject); // 이미 인스턴스가 존재하면 중복 생성된 객체를 파괴
        }
    }

    private void Update()
    {
        if (nowTime < 24)
        {
            nowTime += Time.deltaTime; // 시간 업데이트
        }
        else { nowTime = 0; }

        float rotationDegree = nowTime * 360f / 24f; // 하루에 360도 회전을 가정

        // 'SunCenter' GameObject(이 스크립트가 부착된 GameObject)를 회전
        transform.rotation = Quaternion.Euler(rotationDegree, 45, 0);
    }
}
