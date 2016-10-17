using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour {

    void OnMouseDown()
    {
        if (tag == "StartBoard") SceneManager.LoadScene(1);
        if (tag == "LeaveBoard") Application.Quit();
    }
}
