using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using RainbowArt.CleanFlatUI;
using TMPro;


public class SamsungMulsanStockQuantityController : MonoBehaviour
{
    private string url = "https://racconworld.com:18646/Game/stockquantity";

    private string account; // DB에 전달할 계좌
    private string stockcode = "SamsungMulsan";    // DB에 전달할 종목코드

    public Selector selector;
    public Text week;
    private TextMeshProUGUI myTextObject;

    void Start()
    {

        myTextObject = GameObject.Find("Canvas/private/PrivateAccount").GetComponent<TextMeshProUGUI>();
        string Paccount = myTextObject.text;
        account = Paccount;
        Debug.Log(account);

        StartCoroutine(GetQuantityInfoFromServer(account, stockcode));
    }

    IEnumerator GetQuantityInfoFromServer(string account, string stockcode)
    {
        // URL에 쿼리 문자열로 계정 정보와 주식 코드를 추가
        string requestUrl = $"{url}?account={account}&stockcode={stockcode}";

        // UnityWebRequest를 사용하여 서버에 GET 요청 보내기
        using (UnityWebRequest www = UnityWebRequest.Get(requestUrl))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + www.error);
            }
            else
            {
                // 받아온 JSON 데이터를 파싱
                string jsonString = www.downloadHandler.text;
                Debug.Log("Received JSON data: " + jsonString);

                // JSON을 StockInfo 객체로 파싱
                StockInfo stockInfo = JsonUtility.FromJson<StockInfo>(jsonString);

                // 이후 데이터 활용
                Debug.Log("Quantity Held: " + stockInfo.quantityheld);
                Debug.Log("Stock Code: " + stockInfo.stockcode);

                if (selector != null)
                {
                    selector.OptionsCount = (int)stockInfo.quantityheld;
                }

            }
        }
    }
}