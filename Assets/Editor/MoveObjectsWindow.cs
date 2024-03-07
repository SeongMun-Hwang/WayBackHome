using UnityEditor;
using UnityEngine;

public class MoveObjectsWindow : EditorWindow
{
    Vector3 moveAmount;

    // 윈도우를 열기 위한 메뉴 항목 추가
    [MenuItem("Custom Tools/Move Objects by Value")]
    public static void ShowWindow()
    {
        GetWindow<MoveObjectsWindow>("Move Objects");
    }

    // 에디터 윈도우의 GUI 구성
    void OnGUI()
    {
        GUILayout.Label("Move Selected Objects", EditorStyles.boldLabel);
        moveAmount = EditorGUILayout.Vector3Field("Move Amount", moveAmount);

        if (GUILayout.Button("Move Objects"))
        {
            MoveSelectedObjects(moveAmount);
        }
    }

    // 선택된 객체들을 이동시키는 함수
    void MoveSelectedObjects(Vector3 delta)
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            Undo.RecordObject(obj.transform, "Move Objects");
            obj.transform.position += delta;
        }
    }
}
