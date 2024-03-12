using UnityEngine;

public class MoveSun : MonoBehaviour
{
    public float nowTime = 0; // 시간 변수

    private void Update()
    {
        nowTime += Time.deltaTime; // 시간 업데이트
        float rotationDegree = nowTime * 360f / 24f; // 하루에 360도 회전을 가정

        // 'SunCenter' GameObject(이 스크립트가 부착된 GameObject)를 회전
        transform.rotation = Quaternion.Euler(rotationDegree, 0, 0);
    }
}
