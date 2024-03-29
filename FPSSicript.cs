using UnityEngine;
using UnityEngine.UI;

public class FPSScript : MonoBehaviour
{
    public Text fpsText; // FPS bilgilerini gösterecek UI Text nesnesi

    float deltaTime = 0.0f;

    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        UpdateFPS();
    }

    void UpdateFPS()
    {
        if (fpsText != null)
        {
            float msec = deltaTime * 1000.0f;
            float fps = 1.0f / deltaTime;

            string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
            fpsText.text = text;
        }
    }
}