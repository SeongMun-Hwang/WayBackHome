using UnityEditor;
using UnityEngine;

public class MoveAxis : MonoBehaviour
{
    [MenuItem("Custom Tools/Move Selected Objects +Z #&m")]
    static void MoveSelectedObjectsZPlus()
    {
        MoveSelectedObjects(new Vector3(0, 0, 0.1f));
    }

    [MenuItem("Custom Tools/Move Selected Objects -Z #&n")]
    static void MoveSelectedObjectsZMinus()
    {
        MoveSelectedObjects(new Vector3(0, 0, -0.1f));
    }

    [MenuItem("Custom Tools/Move Selected Objects +Y %#&y")]
    static void MoveSelectedObjectsYPlus()
    {
        MoveSelectedObjects(new Vector3(0, 0.1f, 0));
    }

    [MenuItem("Custom Tools/Move Selected Objects -Y %#&h")]
    static void MoveSelectedObjectsYMinus()
    {
        MoveSelectedObjects(new Vector3(0, -0.1f, 0));
    }

    [MenuItem("Custom Tools/Move Selected Objects +X %#&x")]
    static void MoveSelectedObjectsXPlus()
    {
        MoveSelectedObjects(new Vector3(0.1f, 0, 0));
    }

    [MenuItem("Custom Tools/Move Selected Objects -X %#&z")]
    static void MoveSelectedObjectsXMinus()
    {
        MoveSelectedObjects(new Vector3(-0.1f, 0, 0));
    }

    [MenuItem("Custom Tools/Rotate Selected Objects 90° Clockwise %#r")]
    static void RotateSelectedObjectsClockwise90()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            Undo.RecordObject(obj.transform, "Rotate 90° Clockwise");
            obj.transform.Rotate(0, 90, 0, Space.World);
        }
    }

    static void MoveSelectedObjects(Vector3 delta)
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            Undo.RecordObject(obj.transform, "Move Objects"); // Undo 기능을 위해 변경 사항 기록
            obj.transform.position += delta;
        }
    }
}
