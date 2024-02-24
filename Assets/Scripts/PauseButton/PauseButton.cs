using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickResumeButton()
    {
        Debug.Log("Resume");
    }

    public void OnClickSettijngButton()
    {
        Debug.Log("Setting");
    }

    public void OnClickQuitButton()
    {
#if UNITY_EDITER
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
}
