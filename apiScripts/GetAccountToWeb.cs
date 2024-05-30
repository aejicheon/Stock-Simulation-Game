using UnityEngine;
using UnityEngine.UI; // 추가된 부분
using System.Runtime.InteropServices;
using System;
using TMPro;

public class GetAccountToWeb : MonoBehaviour
{
    public TextMeshProUGUI Account; // TotalMoney Text UI 요소에 대한 참조

    string accountTextValue;

    [DllImport("__Internal")]
    public static extern string GetAccountNumber();

    public string account;
    void Start()
    {
        // Account 변수가 null이 아닌지 확인
        if (Account != null)
        {
            accountTextValue = Account.text;

            // GetAccountNumber 메서드에서 반환된 값으로 account 변수 초기화
            account = GetAccountNumber();

            accountTextValue = account;

            Account.text = accountTextValue;

        }
        else
        {
            Debug.LogError("Account variable is not assigned in the inspector.");
        }

    }
    public string GetAccount()
    {
        return account;
    }
}