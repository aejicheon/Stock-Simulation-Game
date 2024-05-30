using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;
using RainbowArt.CleanFlatUI;

public class StockPriceDisplayMesu : MonoBehaviour
{
    public string apiUrl = "https://racconworld.com:8081/stock-price/005930.KS";
    public TextMeshProUGUI priceTextTMPro;
    public Text priceText;
    public Selector selector;

    private float initialPrice;
    private float getsu;

    void Start()
    {
        StartCoroutine(FetchStockPriceRealtime());
    }

    IEnumerator FetchStockPriceRealtime()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(apiUrl))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                StockPriceResponse9 response = JsonUtility.FromJson<StockPriceResponse9>(webRequest.downloadHandler.text);

                if (response != null)
                {
                    initialPrice = response.price;

                    if (selector != null)
                    {
                        selector.SetInitialPrice(initialPrice);
                    }
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
    }

    void UpdatePriceText(float price)
    {
        if (priceTextTMPro != null)
        {
            priceTextTMPro.text = price.ToString("N0");
        }
        else if (priceText != null)
        {
            priceText.text = price.ToString("N0");
        }
        else
        {
            UnityEngine.Debug.LogError("Text 또는 TextMeshProUGUI 컴포넌트가 지정되지 않았습니다.");
        }
    }
}

[System.Serializable]
public class StockPriceResponse9
{
    public string symbol;
    public float price;
}
