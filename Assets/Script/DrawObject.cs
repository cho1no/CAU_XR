using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawObject : MonoBehaviour
{
    public GameObject pathTilePrefab; // �� Ÿ�� ������
    public Texture2D drawingTexture; // �׸��� �׸� �ؽ�ó

    private bool isDrawing = false; // �׸� �׸��� ����
    private Vector2 previousPosition; // ���� ���콺 ��ġ

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
            // ���� ���콺 ��ġ
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // ���� ���콺 ��ġ�� ���� ���콺 ��ġ ���̿� �� ����
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

        // �ʱ� ���콺 ��ġ ����
        previousPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void StopDrawing()
    {
        isDrawing = false;
    }

    private void CreatePathTile(Vector2 position)
    {
        // �� Ÿ�� ����
        GameObject pathTile = Instantiate(pathTilePrefab, position, Quaternion.identity);
    }
    //public GameObject groundPrefab; // ���� ������

    //// �׸��� �׸� �ؽ�ó�� ���� ����
    //public Texture2D drawingTexture;
    //public int brushSize = 10;

    //private bool isDrawing = false;
    //private Vector2 lastPosition;

    //void Start()
    //{
    //    // �׸��� �׸� �ؽ�ó �ʱ�ȭ
    //    drawingTexture = new Texture2D(64 , 64);
    //    GetComponent<Renderer>().material.mainTexture = drawingTexture;
    //}

    //void Update()
    //{
    //    // ���콺 ��ư�� Ŭ���ϸ� �׸� �׸��� ����
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        isDrawing = true;
    //        lastPosition = GetMousePosition();
    //    }

    //    // ���콺 ��ư�� ������ �׸� �׸��� �ߴ�
    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        isDrawing = false;
    //    }

    //    // �׸� �׸��� ���� ���� ����
    //    if (isDrawing)
    //    {
    //        // ���� ���콺 ��ġ �޾ƿ���
    //        Vector2 currentPosition = GetMousePosition();

    //        // �� �׸���
    //        DrawLine(lastPosition, currentPosition);

    //        // ���� ��ġ�� ������ ��ġ�� ����
    //        lastPosition = currentPosition;
    //    }
    //}

    //// ���콺 ��ġ ��ȯ
    //Vector2 GetMousePosition()
    //{
    //    return Camera.main.ScreenToViewportPoint(Input.mousePosition);
    //}
    //private void GenerateTerrain()
    //{
    //    // �ؽ�ó ũ�⸦ ������� ���� ����
    //    for (int x = 0; x < drawingTexture.width; x++)
    //    {
    //        for (int y = 0; y < drawingTexture.height; y++)
    //        {
    //            Color pixelColor = drawingTexture.GetPixel(x, y);

    //            // ������ �ȼ��� ��� ���� ����
    //            if (pixelColor == Color.black)
    //            {
    //                Vector2 spawnPosition = new Vector2(x, y);

    //                // ���� ������ ����
    //                Instantiate(groundPrefab, spawnPosition, Quaternion.identity);
    //            }
    //        }
    //    }
    //}
    //// �� �׸��� �Լ�
    //void DrawLine(Vector2 startPos, Vector2 endPos)
    //{
    //    // ���� ��ġ�� �� ��ġ�� �ȼ� ������ ��ȯ
    //    int startX = (int)(startPos.x * drawingTexture.width);
    //    int startY = (int)(startPos.y * drawingTexture.height);
    //    int endX = (int)(endPos.x * drawingTexture.width);
    //    int endY = (int)(endPos.y * drawingTexture.height);

    //    // �� �׸���
    //    int x = startX;
    //    int y = startY;
    //    int dx = Mathf.Abs(endX - startX);
    //    int dy = Mathf.Abs(endY - startY);
    //    int sx = (startX < endX) ? 1 : -1;
    //    int sy = (startY < endY) ? 1 : -1;
    //    int err = dx - dy;

    //    while (true)
    //    {
    //        // ���� ��ġ�� �� �׸���
    //        for (int i = 0; i < brushSize; i++)
    //        {
    //            for (int j = 0; j < brushSize; j++)
    //            {
    //                drawingTexture.SetPixel(x + i, y + j, Color.black);
    //            }
    //        }

    //        // �� ��ġ�� �����ϸ� �ݺ��� ����
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

    //    // ����� �ؽ�ó ����
    //    drawingTexture.Apply();
    //    GenerateTerrain();
    //}
}
