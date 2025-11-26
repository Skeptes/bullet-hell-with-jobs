using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private Text text;

    private void Start()
    {
        StartCoroutine(UpdateFPS());
    }

    IEnumerator UpdateFPS()
    {
        while (true)
        {
            text.text = Mathf.Floor(1.0f / Time.deltaTime) + "FPS";
            yield return new WaitForSeconds(.5f);
        }
    }
}
