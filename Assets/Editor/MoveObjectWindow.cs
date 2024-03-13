using UnityEditor;
using UnityEngine;

public class MoveObjectsWindow : EditorWindow
{
    Vector3 moveAmount;

    [MenuItem("Custom Tools/Move Objects by Value")]
    public static void ShowWindow()
    {
        GetWindow<MoveObjectsWindow>("Move Objects");
    }

    void OnGUI()
    {
        GUILayout.Label("Move Selected Objects", EditorStyles.boldLabel);
        moveAmount = EditorGUILayout.Vector3Field("Move Amount", moveAmount);

        if (GUILayout.Button("Move Objects"))
        {
            MoveSelectedObjects(moveAmount);
        }

        // 부모를 삭제하는 버튼 추가
        if (GUILayout.Button("Remove Parent of Selected Objects"))
        {
            RemoveSelectedAndReparentChildren();
        }
    }

    void MoveSelectedObjects(Vector3 delta)
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            Undo.RecordObject(obj.transform, "Move Objects");
            obj.transform.position += delta;
        }
    }

    // 선택된 부모 객체를 삭제하고 자식들을 원래 위치에 유지시키는 함수
    // 선택된 GameObject를 삭제하고 그 자식들을 상위 부모에게 연결하는 함수
    void RemoveSelectedAndReparentChildren()
    {
        foreach (GameObject selectedObj in Selection.gameObjects)
        {
            // 선택된 GameObject의 부모 확인
            Transform parentTransform = selectedObj.transform.parent;

            // 선택된 GameObject가 부모를 가지고 있는 경우에만 작업 수행
            if (parentTransform != null)
            {
                // 선택된 GameObject의 모든 자식을 순회
                int children = selectedObj.transform.childCount;
                for (int i = children - 1; i >= 0; i--)
                {
                    Transform child = selectedObj.transform.GetChild(i);

                    // Undo 기록을 위해 자식 객체의 부모 변경 사항을 등록
                    Undo.SetTransformParent(child, parentTransform, "Reparent Child");

                    // 자식을 상위 부모에게 직접 연결
                    child.SetParent(parentTransform, true);
                }

                // 선택된 GameObject 삭제
                Undo.DestroyObjectImmediate(selectedObj);
            }
        }
    }
}
