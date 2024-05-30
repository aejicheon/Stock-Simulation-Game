using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using RainbowArt.CleanFlatUI;
using TMPro;

public class SamsungBioSaveStockList : MonoBehaviour
{
    public Button mesuyourButton;

    private string apiUrl = "https://racconworld.com:18646/Game/save-stockList";

    //보내는 실제 값으로 값 변경
    private string account;
    private string stockcode;
    private long purchaseprice;
    private long quantityheld;

    private TextMeshProUGUI myTextObject;
    private TextMeshProUGUI mystockcode;
    private TextMeshProUGUI mypurchaseprice;
    private TextMeshProUGUI myquantityheld;

    void Start()
    {
        mesuyourButton = GameObject.Find("Button").GetComponent<Button>();
        mesuyourButton.onClick.AddListener(() =>
        {
            myTextObject = GameObject.Find("Canvas/private/PrivateAccount").GetComponent<TextMeshProUGUI>();
            string Paccount = myTextObject.text;
            account = Paccount;

            mystockcode = GameObject.Find("Canvas/HoldStock/ScrollView/Viewport/Content/SamsungBio/Text/Name Text").GetComponent<TextMeshProUGUI>();
            string ecoprostockcode = mystockcode.text;
            stockcode = ecoprostockcode;

            mypurchaseprice = GameObject.Find("Canvas/HoldStock/ScrollView/Viewport/Content/SamsungBio/Text/total/maeipdan").GetComponent<TextMeshProUGUI>();
            string sampurchaseprice = mypurchaseprice.text;
            sampurchaseprice = sampurchaseprice.Replace(" ", "");
            sampurchaseprice = sampurchaseprice.Replace("원", "");
            sampurchaseprice = sampurchaseprice.Replace(",", "");
            purchaseprice = long.Parse(sampurchaseprice);

            myquantityheld = GameObject.Find("Canvas/HoldStock/ScrollView/Viewport/Content/SamsungBio/Text/total/get").GetComponent<TextMeshProUGUI>();
            string samquantityheld = myquantityheld.text;
            samquantityheld = samquantityheld.Replace("주", "");
            quantityheld = long.Parse(samquantityheld);

            StartCoroutine(SendPostRequest());
        });
    }

    IEnumerator SendPostRequest()
    {
        // 데이터를 객체로 만듭니다.
        StockListData stockData = new StockListData
        {
            account = account,
            stockcode = stockcode,
            purchaseprice = purchaseprice,
            quantityheld = quantityheld
        };

        // 객체를 JSON 문자열로 변환합니다.
        string jsonData = JsonUtility.ToJson(stockData);

        // UnityWebRequest를 생성하고 설정합니다.
        UnityWebRequest request = new UnityWebRequest(apiUrl, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        // 요청을 보냅니다.
        yield return request.SendWebRequest();

        // 응답을 처리합니다.
        if (request.result == UnityWebRequest.Result.Success)
        {
            //Debug.Log("POST 성공: " + request.downloadHandler.text);
        }
        else
        {
            //Debug.LogError("POST 실패: " + request.error);
        }
    }
}