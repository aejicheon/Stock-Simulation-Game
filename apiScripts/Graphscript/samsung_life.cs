using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using YourNamespace20;

public class samsung_life : MonoBehaviour
{
    private string url = "https://racconworld.com:8081/historical-stock-prices/032830.KS";
    public GameObject DotPrefab; // 점을 위한 프리팹
    public Transform DotGroup;    // 점들의 부모
    public Text minCloseText;     // UI Text to display minClose
    public Text maxCloseText;     // UI Text to display maxClose

    private StockData[] stockDataArray;
    private int maxClose = int.MinValue; // Variable to store the maximum "close" value
    private int minClose = int.MaxValue; // Variable to store the minimum "close" value

    void Start()
    {
        StartCoroutine(FetchData());
    }

    IEnumerator FetchData()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("에러: " + webRequest.error);
            }
            else
            {
                // JSON 데이터를 파싱합니다.
                string jsonData = webRequest.downloadHandler.text;
                JSONArrayWrapper wrapper = JsonUtility.FromJson<JSONArrayWrapper>("{\"array\":" + jsonData + "}");

                if (wrapper.array != null && wrapper.array.Length > 0)
                {
                    stockDataArray = wrapper.array;
                    StockData firstDayData = stockDataArray[0];
                    float firstY = ComputeYPosition(firstDayData.Close);

                    for (int i = 0; i < stockDataArray.Length; i++)
                    {
                        StockData currentDayData = stockDataArray[i];
                        StockData previousDayData = (i > 0) ? stockDataArray[i - 1] : null;

                        // Update max and min close values
                        UpdateMaxMinClose(currentDayData.Close);

                        // x와 y 값을 전달하여 점을 생성합니다.
                        CreateDot(currentDayData.Date, currentDayData.Close, previousDayData, firstDayData.Date, firstY);
                    }

                    // Now you have the maxClose and minClose values
                    //Debug.Log("Max Close Value: " + maxClose);
                    //Debug.Log("Min Close Value: " + minClose);

                    // Update UI Text components with minClose and maxClose values
                    minCloseText.text = minClose.ToString();
                    maxCloseText.text = maxClose.ToString();
                }
                else
                {
                    Debug.LogWarning("데이터가 없습니다.");
                }
            }
        }
    }

    private void UpdateMaxMinClose(int currentClose)
    {
        // Update max close value
        if (currentClose > maxClose)
        {
            maxClose = currentClose;
        }

        // Update min close value
        if (currentClose < minClose)
        {
            minClose = currentClose;
        }
    }

    private void CreateDot(string date, int close, StockData previousDayData, string startDate, float firstY)
    {
        // 계산된 색상으로 점을 생성합니다.
        GameObject dot = Instantiate(DotPrefab, DotGroup, true);
        dot.transform.localScale = Vector3.one; // 크기를 설정합니다.

        Image dotImage = dot.GetComponent<Image>();

        // 날짜와 종가에 맞게 점의 위치를 설정합니다.
        float xPosition = ComputeXPosition(date, startDate);
        float yPosition = ComputeYPosition(close);

        RectTransform dotTransform = dot.GetComponent<RectTransform>();
        dotTransform.anchoredPosition = new Vector2(xPosition, yPosition);

        // 첫 번째 데이터의 y 값을 업데이트합니다.
        firstY = yPosition;
    }

    private float ComputeXPosition(string date, string startDate)
    {
        // 시작 날짜를 파싱합니다.
        DateTime startDateTime = DateTime.Parse(startDate);

        // 현재 날짜를 파싱합니다.
        DateTime currentDate = DateTime.Parse(date);

        // 날짜 차이를 계산합니다.
        TimeSpan timeSpan = currentDate - startDateTime;

        // X-위치를 계산합니다. 12f씩 더해집니다.
        float xPosition = 20f + (float)timeSpan.Days * 15f;

        return xPosition;
    }
    private float ComputeYPosition(int close)
    {
        int minY = 75000; // 최소 종가
        int maxY = 61000; // 최대 종가

        float yMin = -180f; // 최소 y 위치
        float yMax = 180f; // 최대 y 위치

        float yPosition = yMin + (yMax - yMin) * ((float)(close - minY) / (maxY - minY));

        return yPosition;
    }
}

namespace YourNamespace20
{
    [System.Serializable]
    public class JSONArrayWrapper
    {
        public StockData[] array;
    }

    [System.Serializable]
    public class StockData
    {
        public string Date;
        public int Close;
    }
}