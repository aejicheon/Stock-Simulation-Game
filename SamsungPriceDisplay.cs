using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class SamsungPriceDisplay : MonoBehaviour
{
    public TextMeshProUGUI priceText;
    public string apiUrl = "https://racconworld.com:8081/stock-price/005930.KS";

    void Start()
    {
        StartCoroutine(FetchStockPriceRealtime());
    }

    public IEnumerator FetchStockPriceRealtime()
    {
        while (true)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(apiUrl))
            {
                yield return webRequest.SendWebRequest();

                if (webRequest.result == UnityWebRequest.Result.Success)
                {
                    StockPriceResponse4 response = JsonUtility.FromJson<StockPriceResponse4>(webRequest.downloadHandler.text);

                    if (response != null)
                    {
                        priceText.text = response.price.ToString("N0");
                    }
                    else
                    {
                        UnityEngine.Debug.LogError("JSON 파싱 오류");
                    }
                }
                else
                {
                    UnityEngine.Debug.LogError("API 요청 오류: " + webRequest.error);
                }
            }

            yield return new WaitForSeconds(5.0f);
        }
    }
}

[System.Serializable]
public class StockPriceResponse4
{
    public string symbol;
    public float price;
}
