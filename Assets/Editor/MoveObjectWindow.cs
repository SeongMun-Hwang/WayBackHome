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

        // �θ� �����ϴ� ��ư �߰�
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

    // ���õ� �θ� ��ü�� �����ϰ� �ڽĵ��� ���� ��ġ�� ������Ű�� �Լ�
    // ���õ� GameObject�� �����ϰ� �� �ڽĵ��� ���� �θ𿡰� �����ϴ� �Լ�
    void RemoveSelectedAndReparentChildren()
    {
        foreach (GameObject selectedObj in Selection.gameObjects)
        {
            // ���õ� GameObject�� �θ� Ȯ��
            Transform parentTransform = selectedObj.transform.parent;

            // ���õ� GameObject�� �θ� ������ �ִ� ��쿡�� �۾� ����
            if (parentTransform != null)
            {
                // ���õ� GameObject�� ��� �ڽ��� ��ȸ
                int children = selectedObj.transform.childCount;
                for (int i = children - 1; i >= 0; i--)
                {
                    Transform child = selectedObj.transform.GetChild(i);

                    // Undo ����� ���� �ڽ� ��ü�� �θ� ���� ������ ���
                    Undo.SetTransformParent(child, parentTransform, "Reparent Child");

                    // �ڽ��� ���� �θ𿡰� ���� ����
                    child.SetParent(parentTransform, true);
                }

                // ���õ� GameObject ����
                Undo.DestroyObjectImmediate(selectedObj);
            }
        }
    }
}
