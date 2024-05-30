using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;

public class MyassetData
{
    public string account;
    public long cash;
    public long balance;
    public long purchaseamount_all;
}
public class MyAsset : MonoBehaviour
{
    public Button yourButton;
    public Button saveButton;

    private string apiUrl = "https://racconworld.com:18646/Game/save-asset";

    public TextMeshProUGUI Account;
    public TextMeshProUGUI Balance;
    public TextMeshProUGUI Cash;
    public TextMeshProUGUI Purchaseamount_all;

    //보내는 실제 값으로 값 변경
    private string account;
    private long balance;
    private long cash;
    private long purchaseamount_all;

    void Start()
    {
        yourButton = GameObject.Find("MiniGame").GetComponent<Button>();
        saveButton = GameObject.Find("Quit Button").GetComponent<Button>();
        yourButton.onClick.AddListener(() =>
        {
            // yourButton가 클릭되었을 때 실행할 코드
            string priAccount = Account.text;
            account = priAccount;

            string pribalance = Balance.text;
            pribalance = pribalance.Replace(" ", "");
            pribalance = pribalance.Replace("원", "");
            pribalance = pribalance.Replace(",", "");
            balance = long.Parse(pribalance);

            string pricash = Cash.text;
            pricash = pricash.Replace(" ", "");
            pricash = pricash.Replace("원", "");
            pricash = pricash.Replace(",", "");
            cash = long.Parse(pricash);

            string maeipprice = Purchaseamount_all.text;
            maeipprice = maeipprice.Replace(" ", "");
            maeipprice = maeipprice.Replace("원", "");
            maeipprice = maeipprice.Replace(",", "");
            purchaseamount_all = long.Parse(maeipprice);
            StartCoroutine(SendPostRequest());
        });
        saveButton.onClick.AddListener(() =>
        {
            // yourButton가 클릭되었을 때 실행할 코드
            string priAccount = Account.text;
            account = priAccount;

            string pribalance = Balance.text;
            pribalance = pribalance.Replace(" ", "");
            pribalance = pribalance.Replace("원", "");
            pribalance = pribalance.Replace(",", "");
            balance = long.Parse(pribalance);

            string pricash = Cash.text;
            pricash = pricash.Replace(" ", "");
            pricash = pricash.Replace("원", "");
            pricash = pricash.Replace(",", "");
            cash = long.Parse(pricash);

            string maeipprice = Purchaseamount_all.text;
            maeipprice = maeipprice.Replace(" ", "");
            maeipprice = maeipprice.Replace("원", "");
            maeipprice = maeipprice.Replace(",", "");
            purchaseamount_all = long.Parse(maeipprice);
            StartCoroutine(SendPostRequest());
        });
    }

    IEnumerator SendPostRequest()
    {
        // 데이터를 객체로 만듭니다.
        MyassetData assetData = new MyassetData
        {
            account = account,
            cash = cash,
            balance = balance,
            purchaseamount_all = purchaseamount_all
        };

        // 객체를 JSON 문자열로 변환합니다.
        string jsonData = JsonUtility.ToJson(assetData);

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
            Debug.Log("POST 성공: " + request.downloadHandler.text);
        }
        else
        {
            Debug.LogError("POST 실패: " + request.error);
        }
    }
}