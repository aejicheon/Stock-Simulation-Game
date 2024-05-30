using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class StockInfo
{
    public string stockcode;
    public long quantityheld;
    public long purchaseprice;
}
public class GetStockList : MonoBehaviour
{
    private string url = "https://racconworld.com:18646/Game/start/stockList"; // 실제 서버 주소로 대체
    private string account; // DB에 전달할 계좌
    private GameManager gameManager; // GameManager 스크립트에 대한 참조

    public TextMeshProUGUI textaccount;
    public Transform content;
    void Start()
    {
        content = GameObject.Find("Canvas/HoldStock/ScrollView/Viewport/Content").transform;
        account = textaccount.text;
        gameManager = GetComponent<GameManager>();
        StartCoroutine(GetStockData(account));
    }

    IEnumerator GetStockData(string account)
    {
        // URL에 쿼리 문자열로 계정 정보를 추가
        string requestUrl = $"{url}?account={account}";
        using (UnityWebRequest www = UnityWebRequest.Get(requestUrl))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                //Debug.LogError("Error: " + www.error);
            }
            else
            {
                // 받아온 JSON 데이터를 파싱
                string jsonString = www.downloadHandler.text;
                //Debug.Log("Received JSON data: " + jsonString);

                // 배열로 직접 파싱
                StockInfo[] stockInfos = JsonHelper.FromJson<StockInfo>(jsonString);

                foreach (var stockInfo in stockInfos)
                {
                    string stockCodeToFind = stockInfo.stockcode;

                    // content 하위에서 stockCodeToFind과 일치하는 이름의 GameObject 찾기
                    Transform foundObject = content.Find(stockCodeToFind);

                    if (foundObject != null)
                    {
                        // stockCodeToFind과 일치하는 GameObject가 있는 경우
                        GameObject stockGameObject = foundObject.gameObject;

                        // 해당 GameObject를 활성화
                        stockGameObject.SetActive(true);

                        if (stockCodeToFind == "Samsung")
                        {
                            if (gameManager != null){ gameManager.SaveSamPNL(stockInfo.quantityheld, stockInfo.purchaseprice);}
                        }
                        if (stockCodeToFind == "EcoPro")
                        {
                            if(gameManager != null) { gameManager.SaveEcoProPNL(stockInfo.quantityheld, stockInfo.purchaseprice); }
                        }
                        if (stockCodeToFind == "LGEnergy")
                        {
                            if (gameManager != null) { gameManager.SaveLGEnergyPNL(stockInfo.quantityheld, stockInfo.purchaseprice); }
                        }
                        if (stockCodeToFind == "SKHigh")
                        {
                            if (gameManager != null) { gameManager.SaveSKHighPNL(stockInfo.quantityheld, stockInfo.purchaseprice); }
                        }
                        if (stockCodeToFind == "SamsungBio")
                        {
                            if (gameManager != null) { gameManager.SaveSamsungBioPNL(stockInfo.quantityheld, stockInfo.purchaseprice); }
                        }//
                        if (stockCodeToFind == "PoscoHoldings")
                        {
                            if (gameManager != null) { gameManager.SavePoscoHoldingsPNL(stockInfo.quantityheld, stockInfo.purchaseprice); }
                        }
                        if (stockCodeToFind == "HyunDai")
                        {
                            if (gameManager != null) { gameManager.SaveHyunDaiPNL(stockInfo.quantityheld, stockInfo.purchaseprice); }
                        }
                        if (stockCodeToFind == "LS")
                        {
                            if (gameManager != null) { gameManager.SaveLSPNL(stockInfo.quantityheld, stockInfo.purchaseprice); }
                        }
                        if (stockCodeToFind == "SamsungSDI")
                        {
                            if (gameManager != null) { gameManager.SaveSamsungSDIPNL(stockInfo.quantityheld, stockInfo.purchaseprice); }
                        }
                        if (stockCodeToFind == "KIA")
                        {
                            if (gameManager != null) { gameManager.SaveKIAPNL(stockInfo.quantityheld, stockInfo.purchaseprice); }
                        }//
                        if (stockCodeToFind == "Naver")
                        {
                            if (gameManager != null) { gameManager.SaveNaverPNL(stockInfo.quantityheld, stockInfo.purchaseprice); }
                        }
                        if (stockCodeToFind == "PoscoFuture")
                        {
                            if (gameManager != null) { gameManager.SavePoscoFuturePNL(stockInfo.quantityheld, stockInfo.purchaseprice); }
                        }
                        if (stockCodeToFind == "KB")
                        {
                            if (gameManager != null) { gameManager.SaveLGPNL(stockInfo.quantityheld, stockInfo.purchaseprice); }
                        }
                        if (stockCodeToFind == "HyunDaiMovius")
                        {
                            if (gameManager != null) { gameManager.SaveHyunDMPNL(stockInfo.quantityheld, stockInfo.purchaseprice); }
                        }
                        if (stockCodeToFind == "Seltrion")
                        {
                            if (gameManager != null) { gameManager.SaveSeltrionPNL(stockInfo.quantityheld, stockInfo.purchaseprice); }
                        }
                        if (stockCodeToFind == "SamsungMulsan")
                        {
                            if (gameManager != null) { gameManager.SaveSamsungMulsanPNL(stockInfo.quantityheld, stockInfo.purchaseprice); }
                        }
                        if (stockCodeToFind == "Kakao")
                        {
                            if (gameManager != null) { gameManager.SaveKakaoPNL(stockInfo.quantityheld, stockInfo.purchaseprice); }
                        }
                        if (stockCodeToFind == "Sinhan")
                        {
                            if (gameManager != null) { gameManager.SaveSinHanPNL(stockInfo.quantityheld, stockInfo.purchaseprice); }
                        }
                        if (stockCodeToFind == "LGjun")
                        {
                            if (gameManager != null) { gameManager.SaveLGJunPNL(stockInfo.quantityheld, stockInfo.purchaseprice); }
                        }
                        if (stockCodeToFind == "Samsunglife")
                        {
                            if (gameManager != null) { gameManager.SaveSamLifePNL(stockInfo.quantityheld, stockInfo.purchaseprice); }
                        }
                    }
                }
            }
        }
    }
}

// JsonHelper 클래스
public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        string newJson = "{ \"array\": " + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
        return wrapper.array;
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] array;
    }
}