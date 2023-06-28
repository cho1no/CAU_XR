using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawObject : MonoBehaviour
{
    public GameObject pathTilePrefab; // 길 타일 프리팹
    public Texture2D drawingTexture; // 그림을 그릴 텍스처

    private bool isDrawing = false; // 그림 그리기 여부
    private Vector2 previousPosition; // 이전 마우스 위치

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartDrawing();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopDrawing();
        }

        if (isDrawing)
        {
            // 현재 마우스 위치
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 이전 마우스 위치와 현재 마우스 위치 사이에 길 생성
            if (Vector2.Distance(mousePosition, previousPosition) > 0.1f)
            {
                CreatePathTile(mousePosition);
                previousPosition = mousePosition;
            }
        }
    }

    private void StartDrawing()
    {
        isDrawing = true;

        // 초기 마우스 위치 설정
        previousPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void StopDrawing()
    {
        isDrawing = false;
    }

    private void CreatePathTile(Vector2 position)
    {
        // 길 타일 생성
        GameObject pathTile = Instantiate(pathTilePrefab, position, Quaternion.identity);
    }
    //public GameObject groundPrefab; // 지형 프리팹

    //// 그림을 그릴 텍스처와 펜의 굵기
    //public Texture2D drawingTexture;
    //public int brushSize = 10;

    //private bool isDrawing = false;
    //private Vector2 lastPosition;

    //void Start()
    //{
    //    // 그림을 그릴 텍스처 초기화
    //    drawingTexture = new Texture2D(64 , 64);
    //    GetComponent<Renderer>().material.mainTexture = drawingTexture;
    //}

    //void Update()
    //{
    //    // 마우스 버튼을 클릭하면 그림 그리기 시작
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        isDrawing = true;
    //        lastPosition = GetMousePosition();
    //    }

    //    // 마우스 버튼을 놓으면 그림 그리기 중단
    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        isDrawing = false;
    //    }

    //    // 그림 그리기 중일 때만 실행
    //    if (isDrawing)
    //    {
    //        // 현재 마우스 위치 받아오기
    //        Vector2 currentPosition = GetMousePosition();

    //        // 선 그리기
    //        DrawLine(lastPosition, currentPosition);

    //        // 현재 위치를 마지막 위치로 저장
    //        lastPosition = currentPosition;
    //    }
    //}

    //// 마우스 위치 반환
    //Vector2 GetMousePosition()
    //{
    //    return Camera.main.ScreenToViewportPoint(Input.mousePosition);
    //}
    //private void GenerateTerrain()
    //{
    //    // 텍스처 크기를 기반으로 지형 생성
    //    for (int x = 0; x < drawingTexture.width; x++)
    //    {
    //        for (int y = 0; y < drawingTexture.height; y++)
    //        {
    //            Color pixelColor = drawingTexture.GetPixel(x, y);

    //            // 검은색 픽셀인 경우 지형 생성
    //            if (pixelColor == Color.black)
    //            {
    //                Vector2 spawnPosition = new Vector2(x, y);

    //                // 지형 프리팹 생성
    //                Instantiate(groundPrefab, spawnPosition, Quaternion.identity);
    //            }
    //        }
    //    }
    //}
    //// 선 그리기 함수
    //void DrawLine(Vector2 startPos, Vector2 endPos)
    //{
    //    // 시작 위치와 끝 위치를 픽셀 단위로 변환
    //    int startX = (int)(startPos.x * drawingTexture.width);
    //    int startY = (int)(startPos.y * drawingTexture.height);
    //    int endX = (int)(endPos.x * drawingTexture.width);
    //    int endY = (int)(endPos.y * drawingTexture.height);

    //    // 선 그리기
    //    int x = startX;
    //    int y = startY;
    //    int dx = Mathf.Abs(endX - startX);
    //    int dy = Mathf.Abs(endY - startY);
    //    int sx = (startX < endX) ? 1 : -1;
    //    int sy = (startY < endY) ? 1 : -1;
    //    int err = dx - dy;

    //    while (true)
    //    {
    //        // 현재 위치에 점 그리기
    //        for (int i = 0; i < brushSize; i++)
    //        {
    //            for (int j = 0; j < brushSize; j++)
    //            {
    //                drawingTexture.SetPixel(x + i, y + j, Color.black);
    //            }
    //        }

    //        // 끝 위치에 도달하면 반복문 종료
    //        if (x == endX && y == endY)
    //            break;

    //        int err2 = 2 * err;

    //        if (err2 > -dy)
    //        {
    //            err -= dy;
    //            x += sx;
    //        }

    //        if (err2 < dx)
    //        {
    //            err += dx;
    //            y += sy;
    //        }
    //    }

    //    // 변경된 텍스처 적용
    //    drawingTexture.Apply();
    //    GenerateTerrain();
    //}
}
