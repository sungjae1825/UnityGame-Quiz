using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSizeChanger : MonoBehaviour
{

    public float width = 1280f;
    public float height = 720f;

    void Start() {
        float aspectRatio = (float)Screen.width / (float)Screen.height; // 화면의 종횡비
        float orthographicHeight = height / 2f; // 카메라의 세로 크기
        float orthographicWidth = orthographicHeight * aspectRatio; // 카메라의 가로 크기

        Camera.main.orthographicSize = orthographicHeight;
    }
}
