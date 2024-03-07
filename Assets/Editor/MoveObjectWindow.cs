using UnityEditor;
using UnityEngine;

public class MoveObjectsWindow : EditorWindow
{
    Vector3 moveAmount;

    // �����츦 ���� ���� �޴� �׸� �߰�
    [MenuItem("Custom Tools/Move Objects by Value")]
    public static void ShowWindow()
    {
        GetWindow<MoveObjectsWindow>("Move Objects");
    }

    // ������ �������� GUI ����
    void OnGUI()
    {
        GUILayout.Label("Move Selected Objects", EditorStyles.boldLabel);
        moveAmount = EditorGUILayout.Vector3Field("Move Amount", moveAmount);

        if (GUILayout.Button("Move Objects"))
        {
            MoveSelectedObjects(moveAmount);
        }
    }

    // ���õ� ��ü���� �̵���Ű�� �Լ�
    void MoveSelectedObjects(Vector3 delta)
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            Undo.RecordObject(obj.transform, "Move Objects");
            obj.transform.position += delta;
        }
    }
}
