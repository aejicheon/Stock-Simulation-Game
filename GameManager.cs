using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq; // System.Linq 네임스페이스 추가

public class GameManager : MonoBehaviour
{
    //==========================MY 자산==============================
    private List<Transform> contentChildren = new List<Transform>();

    public TextMeshProUGUI BalanceMoney; // 잔고
    private int balanceMoney;

    public TextMeshProUGUI cashText;  // 현금
    private int cash = 50000000;

    public TextMeshProUGUI pyunggason;  // 평가손익
    private int pyungs;

    public TextMeshProUGUI MaEipPrice; //매입금액
    private int MaEipValue;

    public TextMeshProUGUI PyungPrice; // 평가금액
    private int pyungPrice;

    public TextMeshProUGUI totalSuic;  // 총 수익률
    private float totalsu = 0.00f;
    //================================================================
    //=========================삼성전자 ==========================
    public TextMeshProUGUI sampnl; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI maeipdanp; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI meusprice; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI manipdan; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI nowprice; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI pyung; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI pyungsunic; //평가손익 대한 참조
    public TextMeshProUGUI suicrul; //수익률 대한 참조

    public int weekValue; // 보유수량 선언
    private int maeipdan; // 매입단가
    private int meeipprice; // 매입 금액 선언
    private int pyungdan; // 평균 단가선언
    private int pyungprice; // 평가금액
    private int pyungson; // 평가손익
    private float suic; // 수익률
    //================================================================
    //=========================에코프로 ==========================
    public TextMeshProUGUI ecopnl; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI ecomaeipdanp; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI ecomeusprice; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI ecomanipdan; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI econowprice; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI ecopyung; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI ecopyungsunic; //평가손익 대한 참조
    public TextMeshProUGUI ecosuicrul; //수익률 대한 참조

    public int ecoweekValue; // 보유수량 선언
    private int ecomaeipdan; // 보유수량 선언
    private int ecomeeipprice; // 매입 금액 선언
    private int ecopyungdan; // 매입 단가선언
    private int ecopyungprice; // 평가금액
    private int ecopyungson; // 평가손익
    private float ecosuic; // 수익률
    //================================================================
    //=========================lgenergy ==========================
    public TextMeshProUGUI lgepnl; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI lgemaeipdanp;
    public TextMeshProUGUI lgemeusprice; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI lgemanipdan; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI lgenowprice; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI lgepyung; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI lgepyungsunic; //평가손익 대한 참조
    public TextMeshProUGUI lgesuicrul; //수익률 대한 참조

    public int lgeweekValue; // 보유수량 선언
    private int lgemaeipdan; // 보유수량 선언
    private int lgemeeipprice; // 매입 금액 선언
    private int lgepyungdan; // 매입 단가선언
    private int lgepyungprice; // 평가금액
    private int lgepyungson; // 평가손익
    private float lgesuic; // 평가손익
    //================================================================
    //=========================SKHigh ==========================
    public TextMeshProUGUI skhpnl; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI skhmaeipdanp;
    public TextMeshProUGUI skhmeusprice; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI skhmanipdan; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI skhnowprice; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI skhpyung; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI skhpyungsunic; //평가손익 대한 참조
    public TextMeshProUGUI skhsuicrul; //수익률 대한 참조

    public int skhweekValue; // 보유수량 선언
    private int skhmaeipdan;
    private int skhmeeipprice; // 매입 금액 선언
    private int skhpyungdan; // 매입 단가선언
    private int skhpyungprice; // 평가금액
    private int skhpyungson; // 평가손익
    private float skhsuic; // 평가손익
    //================================================================
    //=========================SamsungBio ==========================
    public TextMeshProUGUI SamBiopnl; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI SamBiomaeipdanp;
    public TextMeshProUGUI SamBiomeusprice; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI SamBiomanipdan; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI SamBionowprice; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI SamBiopyung; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI SamBiopyungsunic; //평가손익 대한 참조
    public TextMeshProUGUI SamBiosuicrul; //수익률 대한 참조

    public int SamBioweekValue; // 보유수량 선언
    private int SamBiomaeipdan;
    private int SamBiomeeipprice; // 매입 금액 선언
    private int SamBiopyungdan; // 매입 단가선언
    private int SamBiopyungprice; // 평가금액
    private int SamBiopyungson; // 평가손익
    private float SamBiosuic; // 평가손익
    //================================================================
    //=========================PoscoHoldings ==========================
    public TextMeshProUGUI PoscHpnl; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI PoscHmaeipdanp;
    public TextMeshProUGUI PoscHmeusprice; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI PoscHmanipdan; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI PoscHnowprice; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI PoscHpyung; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI PoscHpyungsunic; //평가손익 대한 참조
    public TextMeshProUGUI PoscHsuicrul; //수익률 대한 참조

    public int PoscHweekValue; // 보유수량 선언
    private int PoscHmaeipdan;
    private int PoscHmeeipprice; // 매입 금액 선언
    private int PoscHpyungdan; // 매입 단가선언
    private int PoscHpyungprice; // 평가금액
    private int PoscHpyungson; // 평가손익
    private float PoscHsuic; // 평가손익
    //================================================================
    //=========================HyunDai ==========================
    public TextMeshProUGUI HyunDpnl; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI HyunDmaeipdanp;
    public TextMeshProUGUI HyunDmeusprice; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI HyunDmanipdan; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI HyunDnowprice; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI HyunDpyung; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI HyunDpyungsunic; //평가손익 대한 참조
    public TextMeshProUGUI HyunDsuicrul; //수익률 대한 참조

    public int HyunDweekValue; // 보유수량 선언
    private int HyunDmaeipdan;
    private int HyunDmeeipprice; // 매입 금액 선언
    private int HyunDpyungdan; // 매입 단가선언
    private int HyunDpyungprice; // 평가금액
    private int HyunDpyungson; // 평가손익
    private float HyunDsuic; // 평가손익
    //================================================================
    //=========================LG화학 ==========================
    public TextMeshProUGUI LSpnl; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI LSmaeipdanp;
    public TextMeshProUGUI LSmeusprice; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI LSmanipdan; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI LSnowprice; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI LSpyung; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI LSpyungsunic; //평가손익 대한 참조
    public TextMeshProUGUI LSsuicrul; //수익률 대한 참조

    public int LSweekValue; // 보유수량 선언
    private int LSmaeipdan;
    private int LSmeeipprice; // 매입 금액 선언
    private int LSpyungdan; // 매입 단가선언
    private int LSpyungprice; // 평가금액
    private int LSpyungson; // 평가손익
    private float LSsuic; // 평가손익
    //================================================================
    //=========================SamsungSDI ==========================
    public TextMeshProUGUI SSDIpnl; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI SSDImaeipdanp;
    public TextMeshProUGUI SSDImeusprice; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI SSDImanipdan; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI SSDInowprice; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI SSDIpyung; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI SSDIpyungsunic; //평가손익 대한 참조
    public TextMeshProUGUI SSDIsuicrul; //수익률 대한 참조

    public int SSDIweekValue; // 보유수량 선언
    private int SSDImaeipdan;
    private int SSDImeeipprice; // 매입 금액 선언
    private int SSDIpyungdan; // 매입 단가선언
    private int SSDIpyungprice; // 평가금액
    private int SSDIpyungson; // 평가손익
    private float SSDIsuic; // 평가손익
    //================================================================
    //=========================KIA ==========================
    public TextMeshProUGUI KIApnl; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI KIAmaeipdanp;
    public TextMeshProUGUI KIAmeusprice; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI KIAmanipdan; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI KIAnowprice; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI KIApyung; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI KIApyungsunic; //평가손익 대한 참조
    public TextMeshProUGUI KIAsuicrul; //수익률 대한 참조

    public int KIAweekValue; // 보유수량 선언
    private int KIAmaeipdan;
    private int KIAmeeipprice; // 매입 금액 선언
    private int KIApyungdan; // 매입 단가선언
    private int KIApyungprice; // 평가금액
    private int KIApyungson; // 평가손익
    private float KIAsuic; // 평가손익
    //================================================================
    //=========================NAVER ==========================
    public TextMeshProUGUI NVpnl; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI NVmaeipdanp;
    public TextMeshProUGUI NVmeusprice; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI NVmanipdan; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI NVnowprice; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI NVpyung; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI NVpyungsunic; //평가손익 대한 참조
    public TextMeshProUGUI NVsuicrul; //수익률 대한 참조

    public int NVweekValue; // 보유수량 선언
    private int NVmaeipdan;
    private int NVmeeipprice; // 매입 금액 선언
    private int NVpyungdan; // 매입 단가선언
    private int NVpyungprice; // 평가금액
    private int NVpyungson; // 평가손익
    private float NVsuic; // 평가손익
    //================================================================
    //=========================PoscoFuture ==========================
    public TextMeshProUGUI PFpnl; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI PFmaeipdanp;
    public TextMeshProUGUI PFmeusprice; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI PFmanipdan; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI PFnowprice; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI PFpyung; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI PFpyungsunic; //평가손익 대한 참조
    public TextMeshProUGUI PFsuicrul; //수익률 대한 참조

    public int PFweekValue; // 보유수량 선언
    private int PFmaeipdan;
    private int PFmeeipprice; // 매입 금액 선언
    private int PFpyungdan; // 매입 단가선언
    private int PFpyungprice; // 평가금액
    private int PFpyungson; // 평가손익
    private float PFsuic; // 평가손익
    //================================================================
    //=========================KB ==========================
    public TextMeshProUGUI KBpnl; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI KBmaeipdanp;
    public TextMeshProUGUI KBmeusprice; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI KBmanipdan; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI KBnowprice; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI KBpyung; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI KBpyungsunic; //평가손익 대한 참조
    public TextMeshProUGUI KBsuicrul; //수익률 대한 참조

    public int KBweekValue; // 보유수량 선언
    private int KBmaeipdan;
    private int KBmeeipprice; // 매입 금액 선언
    private int KBpyungdan; // 매입 단가선언
    private int KBpyungprice; // 평가금액
    private int KBpyungson; // 평가손익
    private float KBsuic; // 평가손익
    //================================================================
    //=========================HyundaiMovius ==========================
    public TextMeshProUGUI HDMpnl; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI HDMmaeipdanp;
    public TextMeshProUGUI HDMmeusprice; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI HDMmanipdan; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI HDMnowprice; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI HDMpyung; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI HDMpyungsunic; //평가손익 대한 참조
    public TextMeshProUGUI HDMsuicrul; //수익률 대한 참조

    public int HDMweekValue; // 보유수량 선언
    private int HDMmaeipdan;
    private int HDMmeeipprice; // 매입 금액 선언
    private int HDMpyungdan; // 매입 단가선언
    private int HDMpyungprice; // 평가금액
    private int HDMpyungson; // 평가손익
    private float HDMsuic; // 평가손익
    //================================================================
    //=========================Seltrion ==========================
    public TextMeshProUGUI STpnl; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI STmaeipdanp;
    public TextMeshProUGUI STmeusprice; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI STmanipdan; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI STnowprice; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI STpyung; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI STpyungsunic; //평가손익 대한 참조
    public TextMeshProUGUI STsuicrul; //수익률 대한 참조

    public int STweekValue; // 보유수량 선언
    private int STmaeipdan;
    private int STmeeipprice; // 매입 금액 선언
    private int STpyungdan; // 매입 단가선언
    private int STpyungprice; // 평가금액
    private int STpyungson; // 평가손익
    private float STsuic; // 평가손익
    //================================================================
    //=========================SamsungMul ==========================
    public TextMeshProUGUI SamMpnl; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI SamMmaeipdanp;
    public TextMeshProUGUI SamMmeusprice; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI SamMmanipdan; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI SamMnowprice; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI SamMpyung; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI SamMpyungsunic; //평가손익 대한 참조
    public TextMeshProUGUI SamMsuicrul; //수익률 대한 참조

    public int SamMweekValue; // 보유수량 선언
    private int SamMmaeipdan;
    private int SamMmeeipprice; // 매입 금액 선언
    private int SamMpyungdan; // 매입 단가선언
    private int SamMpyungprice; // 평가금액
    private int SamMpyungson; // 평가손익
    private float SamMsuic; // 평가손익
    //================================================================
    //=========================Kakao ==========================
    public TextMeshProUGUI KKOpnl; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI KKOmaeipdanp;
    public TextMeshProUGUI KKOmeusprice; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI KKOmanipdan; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI KKOnowprice; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI KKOpyung; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI KKOpyungsunic; //평가손익 대한 참조
    public TextMeshProUGUI KKOsuicrul; //수익률 대한 참조

    public int KKOweekValue; // 보유수량 선언
    private int KKOmaeipdan;
    private int KKOmeeipprice; // 매입 금액 선언
    private int KKOpyungdan; // 매입 단가선언
    private int KKOpyungprice; // 평가금액
    private int KKOpyungson; // 평가손익
    private float KKOsuic; // 평가손익
    //================================================================
    //=========================Sinhan ==========================
    public TextMeshProUGUI SinHanpnl; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI SinHanmaeipdanp;
    public TextMeshProUGUI SinHanmeusprice; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI SinHanmanipdan; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI SinHannowprice; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI SinHanpyung; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI SinHanpyungsunic; //평가손익 대한 참조
    public TextMeshProUGUI SinHansuicrul; //수익률 대한 참조

    public int SinHanweekValue; // 보유수량 선언
    private int SinHanmaeipdan;
    private int SinHanmeeipprice; // 매입 금액 선언
    private int SinHanpyungdan; // 매입 단가선언
    private int SinHanpyungprice; // 평가금액
    private int SinHanpyungson; // 평가손익
    private float SinHansuic; // 평가손익
    //================================================================
    //=========================LGJun ==========================
    public TextMeshProUGUI LGJunpnl; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI LGJunmaeipdanp;
    public TextMeshProUGUI LGJunmeusprice; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI LGJunmanipdan; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI LGJunnowprice; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI LGJunpyung; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI LGJunpyungsunic; //평가손익 대한 참조
    public TextMeshProUGUI LGJunsuicrul; //수익률 대한 참조

    public int LGJunweekValue; // 보유수량 선언
    private int LGJunmaeipdan;
    private int LGJunmeeipprice; // 매입 금액 선언
    private int LGJunpyungdan; // 매입 단가선언
    private int LGJunpyungprice; // 평가금액
    private int LGJunpyungson; // 평가손익
    private float LGJunsuic; // 평가손익
    //================================================================
    //=========================SamsungLife ==========================
    public TextMeshProUGUI SamLpnl; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI SamLmaeipdanp;
    public TextMeshProUGUI SamLmeusprice; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI SamLmanipdan; // TotalMoney Text UI 요소에 대한 참조
    public TextMeshProUGUI SamLnowprice; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI SamLpyung; // 지금 현제 실시간 가격대한 참조
    public TextMeshProUGUI SamLpyungsunic; //평가손익 대한 참조
    public TextMeshProUGUI SamLsuicrul; //수익률 대한 참조

    public int SamLweekValue; // 보유수량 선언
    private int SamLmaeipdan;
    private int SamLmeeipprice; // 매입 금액 선언
    private int SamLpyungdan; // 매입 단가선언
    private int SamLpyungprice; // 평가금액
    private int SamLpyungson; // 평가손익
    private float SamLsuic; // 평가손익
    //================================================================
    public void Start()
    {
        // Content 오브젝트를 찾아서 비활성화하고 하위 오브젝트들을 리스트에 추가
        Transform content = GameObject.Find("Canvas/HoldStock/ScrollView/Viewport/Content").transform;

        // Content 오브젝트를 비활성화하지 않고, 하위 오브젝트들만 비활성화
        foreach (Transform child in content)
        {
            contentChildren.Add(child);
            child.gameObject.SetActive(false); // 모든 자식 오브젝트를 비활성화

        }

    }
    //=========================================삼성 매수 매도========================================

    public void MedoSamPNL(string samsungVariable, string indicatorText, string indicator1Text, int weekValuee)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");

        int samweek = 0;
        int price = 0;

        Debug.Log(samsungVariable + "매도 시작했다잉!!");

        if (int.TryParse(indicator1Text, out int indicator1Value))
        {
            samweek = indicator1Value;
        }

        if (int.TryParse(indicatorText, out int indicatorValue))
        {
            price = indicatorValue;
        }

        if (samweek == weekValuee)
        {
            Transform content = GameObject.Find("Canvas/HoldStock/ScrollView/Viewport/Content").transform;

            foreach (Transform child in content)
            {
                if (child.name == samsungVariable)
                {
                    child.gameObject.SetActive(false);
                    Debug.Log("이름이 " + samsungVariable + "인 오브젝트를 찾아 비활성화했습니다.");

                    GameObject medoSamsungClone = GameObject.Find("Medo-Samsung(Clone)");
                    if (medoSamsungClone != null)
                    {
                        medoSamsungClone.SetActive(false);
                    }
                }
            }

            // 매도 시 매입금액 감소
            meeipprice -= maeipdan * weekValue;

            // 이전 보유수량 - 새로운 주식 수량
            weekValue -= maeipdan;

            // 매도한 주식의 평균단가를 계산
            if (weekValue > 0)
            {
                maeipdan = meeipprice / weekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                maeipdan = 0;
            }

            meusprice.text = weekValue.ToString("N0") + " 주";
            sampnl.text = meeipprice.ToString("N0") + " 원";
            maeipdanp.text = maeipdan.ToString("N0") + " 원";

            // 변수들을 모두 초기화
            InitializeVariables();
        }
        else if (samweek < weekValue)
        {
            // 매도 시 매입금액 감소
            meeipprice -= maeipdan * indicator1Value;  // 여기를 수정

            // 이전 보유수량 - 새로운 주식 수량
            weekValue -= indicator1Value;

            // 매도한 주식의 평균단가를 계산
            if (weekValue > 0)
            {
                maeipdan = meeipprice / weekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                maeipdan = 0;
            }

            meusprice.text = weekValue.ToString("N0") + " 주";
            sampnl.text = meeipprice.ToString("N0") + " 원";
            maeipdanp.text = maeipdan.ToString("N0") + " 원";
        }
    }

    // 변수들을 초기화하는 메소드
    private void InitializeVariables()
    {
        weekValue = 0;
        meeipprice = 0;
        pyungdan = 0;
        pyungson = 0;
        suic = 0.0f;
    }
    public int PNL(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");

        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            // 누적 수량 및 총 투자 금액에 현재 매수 정보 추가
            weekValue += indicator1Value;
            meeipprice += indicator2Value;

            meusprice.text = weekValue.ToString("N0") + " 주";
            sampnl.text = meeipprice.ToString("N0") + " 원";

            // 매입단가는 누적 투자 금액을 누적 수량으로 나눈 값
            maeipdan = meeipprice / weekValue;
            maeipdanp.text = maeipdan.ToString("N0") + " 원";
        }
        else
        {
            Debug.LogError("Cannot parse indicatorText as an integer: " + indicator1Text);
        }

        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
        return maeipdan;
    }
    public int saveSam(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");

        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            weekValue += indicator1Value;
            meeipprice += indicator2Value * weekValue;

            meusprice.text = weekValue.ToString("N0") + " 주";
            sampnl.text = meeipprice.ToString("N0") + " 원";

            maeipdan = meeipprice / weekValue;
            maeipdanp.text = maeipdan.ToString("N0") + " 원";

        }
        return maeipdan;
    }
    public void SaveSamPNL(long quantityheld, long purchaseprice)
    {
        string indicator1Text = quantityheld.ToString();
        string indicator2Text = purchaseprice.ToString();
        saveSam(indicator1Text, indicator2Text);
        Invoke("DelayedSamPNL", 7);
    }
    private void DelayedSamPNL()
    {
        SamPNL("start");
        MedoMaEip("start");
    }
    public void SamPNL(string indicatorText)
    {
        
        string nowP = nowprice.text;
        nowP = nowP.Replace(",", "");
        if (int.TryParse(nowP, out int SamnowPriceValue))
        {
                pyungdan = SamnowPriceValue; // 평균단가
                manipdan.text = pyungdan.ToString("N0") + " 원";
                SamnowPriceValue = pyungdan * weekValue; // 평가금액
                pyungson = SamnowPriceValue - meeipprice; // 평가손익
                suic = (float)pyungson / meeipprice * 100; // 수익률

                suic = Mathf.Round(suic * 100) / 100; // 0.1654 -> 16.54

                pyung.text = SamnowPriceValue.ToString("N0") + " 원";
                pyungsunic.text = pyungson.ToString("N0") + " 원 ";
                suicrul.text = suic.ToString("N2") + " % ";
        }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
//===================================================================================================

    public void DoSomething(string variableNames)
    {
        // Content 오브젝트를 활성화
        Transform content = GameObject.Find("Canvas/HoldStock/ScrollView/Viewport/Content").transform;
        content.gameObject.SetActive(true);

        // Content 하위 오브젝트들 중에 해당하는 오브젝트를 활성화
        foreach (Transform child in contentChildren)
        {
            if (child.name == variableNames)
            {
                // 게임 오브젝트를 활성화
                child.gameObject.SetActive(true);
                //Debug.Log("찾은 게임 오브젝트 활성화: " + child.name);
            }
        }
    }
    public void MedoMaEip(string indicatorText)
    {

        //총평가금액 ===================================
        string sampyungst = pyung.text; string ecopyungst = ecopyung.text; string lgepyungst = lgepyung.text;
        string skhpyungst = skhpyung.text; string SamBiopyungst = SamBiopyung.text; string PoscHpyungst = PoscHpyung.text;
        string HyunDpyungst = HyunDpyung.text; string LSpyungst = LSpyung.text; string SSDIpyungst = SSDIpyung.text;
        string KIApyungst = KIApyung.text; string NVpyungst = NVpyung.text; string PFpyungst = PFpyung.text;
        string KBpyungst = KBpyung.text; string HDMpyungst = HDMpyung.text; string STpyungst = STpyung.text;
        string SamMpyungst = SamMpyung.text; string KKOpyungst = KKOpyung.text; string SinHanpyungst = SinHanpyung.text;
        string LGJunyungst = LGJunpyung.text; string SamLpyungst = SamLpyung.text;

        sampyungst = sampyungst.Replace(",", ""); sampyungst = sampyungst.Replace(" ", ""); sampyungst = sampyungst.Replace("원", "");
        ecopyungst = ecopyungst.Replace(",", ""); ecopyungst = ecopyungst.Replace(" ", ""); ecopyungst = ecopyungst.Replace("원", "");
        lgepyungst = lgepyungst.Replace(",", ""); lgepyungst = lgepyungst.Replace(" ", ""); lgepyungst = lgepyungst.Replace("원", "");
        skhpyungst = skhpyungst.Replace(",", ""); skhpyungst = skhpyungst.Replace(" ", ""); skhpyungst = skhpyungst.Replace("원", "");
        SamBiopyungst = SamBiopyungst.Replace(",", ""); SamBiopyungst = SamBiopyungst.Replace(" ", ""); SamBiopyungst = SamBiopyungst.Replace("원", "");
        PoscHpyungst = PoscHpyungst.Replace(",", ""); PoscHpyungst = PoscHpyungst.Replace(" ", ""); PoscHpyungst = PoscHpyungst.Replace("원", "");

        HyunDpyungst = HyunDpyungst.Replace(",", ""); HyunDpyungst = HyunDpyungst.Replace(" ", ""); HyunDpyungst = HyunDpyungst.Replace("원", "");
        LSpyungst = LSpyungst.Replace(",", ""); LSpyungst = LSpyungst.Replace(" ", ""); LSpyungst = LSpyungst.Replace("원", "");
        SSDIpyungst = SSDIpyungst.Replace(",", ""); SSDIpyungst = SSDIpyungst.Replace(" ", ""); SSDIpyungst = SSDIpyungst.Replace("원", "");
        KIApyungst = KIApyungst.Replace(",", ""); KIApyungst = KIApyungst.Replace(" ", ""); KIApyungst = KIApyungst.Replace("원", "");
        NVpyungst = NVpyungst.Replace(",", ""); NVpyungst = NVpyungst.Replace(" ", ""); NVpyungst = NVpyungst.Replace("원", "");
        PFpyungst = PFpyungst.Replace(",", ""); PFpyungst = PFpyungst.Replace(" ", ""); PFpyungst = PFpyungst.Replace("원", "");

        KBpyungst = KBpyungst.Replace(",", ""); KBpyungst = KBpyungst.Replace(" ", ""); KBpyungst = KBpyungst.Replace("원", "");
        HDMpyungst = HDMpyungst.Replace(",", ""); HDMpyungst = HDMpyungst.Replace(" ", ""); HDMpyungst = HDMpyungst.Replace("원", "");
        STpyungst = STpyungst.Replace(",", ""); STpyungst = STpyungst.Replace(" ", ""); STpyungst = STpyungst.Replace("원", "");
        SamMpyungst = SamMpyungst.Replace(",", ""); SamMpyungst = SamMpyungst.Replace(" ", ""); SamMpyungst = SamMpyungst.Replace("원", "");
        KKOpyungst = KKOpyungst.Replace(",", ""); KKOpyungst = KKOpyungst.Replace(" ", ""); KKOpyungst = KKOpyungst.Replace("원", "");
        SinHanpyungst = SinHanpyungst.Replace(",", ""); SinHanpyungst = SinHanpyungst.Replace(" ", ""); SinHanpyungst = SinHanpyungst.Replace("원", "");

        LGJunyungst = LGJunyungst.Replace(",", ""); LGJunyungst = LGJunyungst.Replace(" ", ""); LGJunyungst = LGJunyungst.Replace("원", "");
        SamLpyungst = SamLpyungst.Replace(",", ""); SamLpyungst = SamLpyungst.Replace(" ", ""); SamLpyungst = SamLpyungst.Replace("원", "");
        int pyungtotal = 0; //평가금액
        if (int.TryParse(sampyungst, out int sampyungstValue)) pyungtotal += sampyungstValue;
        if (int.TryParse(ecopyungst, out int ecopyungstValue)) pyungtotal += ecopyungstValue;
        if (int.TryParse(lgepyungst, out int lgepyungstValue)) pyungtotal += lgepyungstValue;
        if (int.TryParse(skhpyungst, out int skhpyungstValue)) pyungtotal += skhpyungstValue;
        if (int.TryParse(SamBiopyungst, out int SamBiopyungValue)) pyungtotal += SamBiopyungValue;
        if (int.TryParse(PoscHpyungst, out int PoscHpyungstValue)) pyungtotal += PoscHpyungstValue;

        if (int.TryParse(HyunDpyungst, out int HyunDpyungstValue)) pyungtotal += HyunDpyungstValue;
        if (int.TryParse(LSpyungst, out int LSpyungstValue)) pyungtotal += LSpyungstValue;
        if (int.TryParse(SSDIpyungst, out int SSDIpyungValue)) pyungtotal += SSDIpyungValue;
        if (int.TryParse(KIApyungst, out int KIApyungstValue)) pyungtotal += KIApyungstValue;
        if (int.TryParse(NVpyungst, out int NVpyungValue)) pyungtotal += NVpyungValue;
        if (int.TryParse(PFpyungst, out int PFpyungValue)) pyungtotal += PFpyungValue;

        if (int.TryParse(KBpyungst, out int KBpyungstValue)) pyungtotal += KBpyungstValue;
        if (int.TryParse(HDMpyungst, out int HDMpyungstValue)) pyungtotal += HDMpyungstValue;
        if (int.TryParse(STpyungst, out int STpyungstValue)) pyungtotal += STpyungstValue;
        if (int.TryParse(SamMpyungst, out int SamMpyungstValue)) pyungtotal += SamMpyungstValue;
        if (int.TryParse(KKOpyungst, out int KKOpyungstValue)) pyungtotal += KKOpyungstValue;
        if (int.TryParse(SinHanpyungst, out int SinHanpyungstValue)) pyungtotal += SinHanpyungstValue;

        if (int.TryParse(LGJunyungst, out int LGJunyungstValue)) pyungtotal += LGJunyungstValue;
        if (int.TryParse(SamLpyungst, out int SamLpyungstValue)) pyungtotal += SamLpyungstValue;

        PyungPrice.text = pyungtotal.ToString("N0") + "  원";
        //총 평가손익 
        pyungs = pyungtotal - MaEipValue;
        pyunggason.text = pyungs.ToString("N0") + "  원";

        //총 잔고
        balanceMoney = cash + pyungs;
        BalanceMoney.text = balanceMoney.ToString("N0") + "  원";

        //총 수익률
        totalsu = (float)pyungs / MaEipValue * 100;
        totalsu = Mathf.Round(totalsu * 100) / 100;
        totalSuic.text = totalsu.ToString("N2") + " % ";

        cashText.text = cash.ToString("N0") + "  원";

        balanceMoney = cash + pyungs;
        BalanceMoney.text = balanceMoney.ToString("N0") + "  원";
    }

    //=============================에코프로===========================
    public void MedoEcoProPNL(string ecoVariable, string indicatorText, string indicator1Text, int weekValuee)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");

        int ecoweek = 0;
        int price = 0;

        Debug.Log(ecoVariable + "매도 시작했다잉!!");

        if (int.TryParse(indicator1Text, out int indicator1Value))
        {
            ecoweek = indicator1Value;
        }

        if (int.TryParse(indicatorText, out int indicatorValue))
        {
            price = indicatorValue;
        }
        Debug.Log(ecoweek + "  ?  " + weekValuee);
        if (ecoweek == weekValuee)
        {
            Transform content = GameObject.Find("Canvas/HoldStock/ScrollView/Viewport/Content").transform;
            Debug.Log("엥??");
            foreach (Transform child in content)
            {
                if (child.name == ecoVariable)
                {
                    child.gameObject.SetActive(false);
                    Debug.Log("이름이 " + ecoVariable + "인 오브젝트를 찾아 비활성화했습니다.");

                    GameObject medoecoClone = GameObject.Find("Medo-EcoPro(Clone)");
                    if (medoecoClone != null)
                    {
                        medoecoClone.SetActive(false);
                    }
                }
            }

            // 매도 시 매입금액 감소
            ecomeeipprice -= ecomaeipdan * ecoweekValue;

            // 이전 보유수량 - 새로운 주식 수량
            ecoweekValue -= ecomaeipdan;

            // 매도한 주식의 평균단가를 계산
            if (ecoweekValue > 0)
            {
                ecomaeipdan = ecomeeipprice / ecoweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                ecomaeipdan = 0;
            }

            ecomeusprice.text = ecoweekValue.ToString("N0") + " 주";
            ecopnl.text = ecomeeipprice.ToString("N0") + " 원";
            ecomaeipdanp.text = ecomaeipdan.ToString("N0") + " 원";

            // 변수들을 모두 초기화
            ecoInitializeVariables();
        }
        else if (ecoweek < ecoweekValue)
        {
            // 매도 시 매입금액 감소
            ecomeeipprice -= ecomaeipdan * indicator1Value;  // 여기를 수정

            // 이전 보유수량 - 새로운 주식 수량
            ecoweekValue -= indicator1Value;

            // 매도한 주식의 평균단가를 계산
            if (ecoweekValue > 0)
            {
                ecomaeipdan = ecomeeipprice / ecoweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                ecomaeipdan = 0;
            }

            ecomeusprice.text = ecoweekValue.ToString("N0") + " 주";
            ecopnl.text = ecomeeipprice.ToString("N0") + " 원";
            ecomaeipdanp.text = ecomaeipdan.ToString("N0") + " 원";
        }
    }
    private void ecoInitializeVariables()
    {
        ecoweekValue = 0;
        ecomeeipprice = 0;
        ecopyungdan = 0;
        ecopyungson = 0;
        ecosuic = 0.0f;
    }
    public int ePNL(string indicator1Text, string indicator2Text)//주, 원
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");

        // 숫자 추출
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            ecoweekValue += indicator1Value;
            ecomeeipprice += indicator2Value;

            ecopnl.text = ecomeeipprice.ToString("N0") + " 원";
            ecomeusprice.text = ecoweekValue.ToString("N0") + " 주";

            ecomaeipdan = ecomeeipprice / ecoweekValue;
            ecomaeipdanp.text = ecomaeipdan.ToString("N0") + " 원";
        }
        else
        {
            Debug.LogError("Cannot parse indicatorText as an integer: " + indicator1Text);
        }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
        return ecomaeipdan;
    }
    public int saveEcoPro(string indicator1Text, string indicator2Text)//주, 원
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");

        // 숫자 추출
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            ecoweekValue += indicator1Value;
            ecomeeipprice += indicator2Value * ecoweekValue;

            ecopnl.text = ecomeeipprice.ToString("N0") + " 원";
            ecomeusprice.text = ecoweekValue.ToString("N0") + " 주";

            ecomaeipdan = ecomeeipprice / ecoweekValue;
            ecomaeipdanp.text = ecomaeipdan.ToString("N0") + " 원";
        }
        else
        {
            Debug.LogError("Cannot parse indicatorText as an integer: " + indicator1Text);
        }
        return ecomaeipdan;
    }
    public void SaveEcoProPNL(long quantityheld, long purchaseprice)
    {
        string indicator1Text = quantityheld.ToString();
        string indicator2Text = purchaseprice.ToString();
        saveEcoPro(indicator1Text, indicator2Text);
        Invoke("DelayedEcoProPNL", 7);
    }
    private void DelayedEcoProPNL()
    {
        ecoPNL("start");
        MedoMaEip("start");
    }
    public void ecoPNL(string indicatorText)
    {
        string econowP1 = econowprice.text;
        econowP1 = econowP1.Replace(",", "");

            if (int.TryParse(econowP1, out int EconowPriceValue))
            {
                ecopyungdan = EconowPriceValue;
                ecomanipdan.text = ecopyungdan.ToString("N0") + " 원";
                EconowPriceValue = ecopyungdan * ecoweekValue;
                ecopyungson = EconowPriceValue - ecomeeipprice;
                ecosuic = (float)ecopyungson / ecomeeipprice * 100;
                //Debug.Log(pyungson);

                // 소수점 이하 2자리까지 표시
                ecosuic = Mathf.Round(ecosuic * 100) / 100; // 0.1654 -> 16.54

                ecopyung.text = EconowPriceValue.ToString("N0") + " 원";
                ecopyungsunic.text = ecopyungson.ToString("N0") + " 원 ";
                ecosuicrul.text = ecosuic.ToString("N2") + " % ";
            }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    //=======================================================================
    //=============================LGEnergy===========================
    public void MedoLGEPNL(string lgeVariable, string indicatorText, string indicator1Text, int weekValuee)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");

        int lgeweek = 0;
        int price = 0;

        if (int.TryParse(indicator1Text, out int indicator1Value))
        {
            lgeweek = indicator1Value;
        }

        if (int.TryParse(indicatorText, out int indicatorValue))
        {
            price = indicatorValue;
        }

        if (lgeweek == weekValuee)
        {
            Transform content = GameObject.Find("Canvas/HoldStock/ScrollView/Viewport/Content").transform;

            foreach (Transform child in content)
            {
                if (child.name == lgeVariable)
                {
                    child.gameObject.SetActive(false);
                    Debug.Log("이름이 " + lgeVariable + "인 오브젝트를 찾아 비활성화했습니다.");

                    GameObject medoLGEClone = GameObject.Find("Medo-LGEnergy(Clone)");
                    if (medoLGEClone != null)
                    {
                        medoLGEClone.SetActive(false);
                    }
                }
            }

            // 매도 시 매입금액 감소
            lgemeeipprice -= lgemaeipdan * lgeweekValue;

            // 이전 보유수량 - 새로운 주식 수량
            lgeweekValue -= lgemaeipdan;

            // 매도한 주식의 평균단가를 계산
            if (weekValue > 0)
            {
                lgemaeipdan = lgemeeipprice / lgeweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                lgemaeipdan = 0;
            }

            lgemeusprice.text = lgeweekValue.ToString("N0") + " 주";
            lgepnl.text = lgemeeipprice.ToString("N0") + " 원";
            lgemaeipdanp.text = lgemaeipdan.ToString("N0") + " 원";

            // 변수들을 모두 초기화
            LGEInitializeVariables();
        }
        else if (lgeweek < lgeweekValue)
        {
            // 매도 시 매입금액 감소
            lgemeeipprice -= lgemaeipdan * indicator1Value;  // 여기를 수정

            // 이전 보유수량 - 새로운 주식 수량
            lgeweekValue -= indicator1Value;

            // 매도한 주식의 평균단가를 계산
            if (lgeweekValue > 0)
            {
                lgemaeipdan = lgemeeipprice / lgeweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                lgemaeipdan = 0;
            }

            lgemeusprice.text = lgeweekValue.ToString("N0") + " 주";
            lgepnl.text = lgemeeipprice.ToString("N0") + " 원";
            lgemaeipdanp.text = lgemaeipdan.ToString("N0") + " 원";
        }
    }
    // 변수들을 초기화하는 메소드
    private void LGEInitializeVariables()
    {
        lgeweekValue = 0;
        lgemeeipprice = 0;
        lgepyungdan = 0;
        lgepyungson = 0;
        lgesuic = 0.0f;
    }
    public void LGEPNL(string indicator1Text, string indicator2Text)
    {
        string LGEnergynowP = lgenowprice.text; // 현재 매입단가
        LGEnergynowP = LGEnergynowP.Replace(",", "");
        Debug.Log(LGEnergynowP);

        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");

        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");

        // 숫자 추출
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value) && int.TryParse(LGEnergynowP, out int LGEnowPValue))
        {
            lgeweekValue += indicator1Value;
            lgemeeipprice += indicator2Value;

            lgepnl.text = lgemeeipprice.ToString("N0") + " 원";
            lgemeusprice.text = lgeweekValue.ToString("N0") + " 주";

            lgemaeipdan = lgemeeipprice / lgeweekValue;
            lgemaeipdanp.text = lgemaeipdan.ToString("N0") + " 원";
        }
        else
        {
            Debug.LogError("Cannot parse indicatorText as an integer: " + indicator1Text);
        }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    public void saveLGEnergy(string indicator1Text, string indicator2Text)
    {
        string LGEnergynowP = lgenowprice.text; // 현재 매입단가
        LGEnergynowP = LGEnergynowP.Replace(",", "");

        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");

        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");

        // 숫자 추출
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            lgeweekValue += indicator1Value;
            lgemeeipprice += indicator2Value * lgeweekValue;

            lgepnl.text = lgemeeipprice.ToString("N0") + " 원";
            lgemeusprice.text = lgeweekValue.ToString("N0") + " 주";

            lgemaeipdan = lgemeeipprice / lgeweekValue;
            lgemaeipdanp.text = lgemaeipdan.ToString("N0") + " 원";
        }
    }
    public void SaveLGEnergyPNL(long quantityheld, long purchaseprice)
    {
        string indicator1Text = quantityheld.ToString();
        string indicator2Text = purchaseprice.ToString();
        saveLGEnergy(indicator1Text, indicator2Text);
        Invoke("DelayedLGEnergyPNL", 7);
    }
    private void DelayedLGEnergyPNL()
    {
        LGEnergyPNL("start");
        MedoMaEip("start");
    }
    public void LGEnergyPNL(string indicatorText)
    {
        string LGEnergynowP1 = lgenowprice.text; // 현재 매입단가
        LGEnergynowP1 = LGEnergynowP1.Replace(",", "");

            if (int.TryParse(LGEnergynowP1, out int LGEnergynowP1nowPriceValue))
            {
                // 계산: 5000에서 indicatorValue를 뺍니다.
                lgepyungdan = LGEnergynowP1nowPriceValue;
                lgemanipdan.text = lgepyungdan.ToString("N0") + " 원";

                LGEnergynowP1nowPriceValue = lgepyungdan * lgeweekValue;
                lgepyungson = LGEnergynowP1nowPriceValue - lgemeeipprice;
                lgesuic = (float)lgepyungson / lgemeeipprice * 100;

                lgesuic = Mathf.Round(lgesuic * 100) / 100; // 0.1654 -> 16.54

                // 결과 포맷팅: "4000 원" 형식으로 만들기
                lgepyung.text = LGEnergynowP1nowPriceValue.ToString("N0") + " 원";
                lgepyungsunic.text = lgepyungson.ToString("N0") + " 원 ";
                lgesuicrul.text = lgesuic.ToString("N2") + " % ";
            }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    //=======================================================================

    //=============================SKHigh===========================
    public void MedoSKHighPNL(string skhighVariable, string indicatorText, string indicator1Text, int weekValuee)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");

        int skhweek = 0;
        int price = 0;

        if (int.TryParse(indicator1Text, out int indicator1Value))
        {
            skhweek = indicator1Value;
        }

        if (int.TryParse(indicatorText, out int indicatorValue))
        {
            price = indicatorValue;
        }

        if (skhweek == weekValuee)
        {
            Transform content = GameObject.Find("Canvas/HoldStock/ScrollView/Viewport/Content").transform;

            foreach (Transform child in content)
            {
                if (child.name == skhighVariable)
                {
                    child.gameObject.SetActive(false);
                    Debug.Log("이름이 " + skhighVariable + "인 오브젝트를 찾아 비활성화했습니다.");

                    GameObject medoSKHClone = GameObject.Find("Medo-SKHigh(Clone)");
                    if (medoSKHClone != null)
                    {
                        medoSKHClone.SetActive(false);
                    }
                }
            }

            // 매도 시 매입금액 감소
            skhmeeipprice -= skhmaeipdan * skhweekValue;

            // 이전 보유수량 - 새로운 주식 수량
            skhweekValue -= skhmaeipdan;

            // 매도한 주식의 평균단가를 계산
            if (skhweekValue > 0)
            {
                skhmaeipdan = skhmeeipprice / skhweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                skhmaeipdan = 0;
            }

            skhmeusprice.text = skhweekValue.ToString("N0") + " 주";
            skhpnl.text = skhmeeipprice.ToString("N0") + " 원";
            skhmaeipdanp.text = skhmaeipdan.ToString("N0") + " 원";

            // 변수들을 모두 초기화
            SKHInitializeVariables();
        }
        else if (skhweek < skhweekValue)
        {
            // 매도 시 매입금액 감소
            skhmeeipprice -= skhmaeipdan * indicator1Value;  // 여기를 수정

            // 이전 보유수량 - 새로운 주식 수량
            skhweekValue -= indicator1Value;

            // 매도한 주식의 평균단가를 계산
            if (skhweekValue > 0)
            {
                skhmaeipdan = skhmeeipprice / skhweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                skhmaeipdan = 0;
            }

            skhmeusprice.text = skhweekValue.ToString("N0") + " 주";
            skhpnl.text = skhmeeipprice.ToString("N0") + " 원";
            skhmaeipdanp.text = skhmaeipdan.ToString("N0") + " 원";
        }
    }
    private void SKHInitializeVariables()
    {
        skhweekValue = 0;
        skhmeeipprice = 0;
        skhpyungdan = 0;
        skhpyungson = 0;
        skhsuic = 0.0f;
    }
    public void SKHPNL(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");

        // 숫자 추출
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            skhweekValue += indicator1Value;
            skhmeeipprice += indicator2Value;
            skhmeusprice.text = skhweekValue.ToString("N0") + " 주";
            skhpnl.text = skhmeeipprice.ToString("N0") + " 원";

            skhmaeipdan = skhmeeipprice / skhweekValue;
            skhmaeipdanp.text = skhmaeipdan.ToString("N0") + " 원";

        }
        else
        {
            Debug.LogError("Cannot parse indicatorText as an integer: " + indicator1Text);
        }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    public void saveSKHigh(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");

        // 숫자 추출
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            skhweekValue += indicator1Value;
            skhmeeipprice += indicator2Value * skhweekValue;
            skhmeusprice.text = skhweekValue.ToString("N0") + " 주";
            skhpnl.text = skhmeeipprice.ToString("N0") + " 원";

            skhmaeipdan = skhmeeipprice / skhweekValue;
            skhmaeipdanp.text = skhmaeipdan.ToString("N0") + " 원";

        }
        else
        {
            Debug.LogError("Cannot parse indicatorText as an integer: " + indicator1Text);
        }
    }
    public void SaveSKHighPNL(long quantityheld, long purchaseprice)
    {
        string indicator1Text = quantityheld.ToString();
        string indicator2Text = purchaseprice.ToString();
        saveSKHigh(indicator1Text, indicator2Text);
        Invoke("DelayedSKHighPNL", 7);
    }
    private void DelayedSKHighPNL()
    {
        SKHighPNL("start");
        MedoMaEip("start");
    }
    public void SKHighPNL(string indicatorText)
    {
        string SKHnowP = skhnowprice.text; // 현재 매입단가
        SKHnowP = SKHnowP.Replace(",", "");

            if (int.TryParse(SKHnowP, out int SKHnowPriceValue))
            {
                skhpyungdan = SKHnowPriceValue;
                skhmanipdan.text = skhpyungdan.ToString("N0") + " 원";
                SKHnowPriceValue = skhpyungdan * skhweekValue;
                skhpyungson = SKHnowPriceValue - skhmeeipprice;
                skhsuic = (float)skhpyungson / skhmeeipprice * 100;

                skhsuic = Mathf.Round(skhsuic * 100) / 100; // 0.1654 -> 16.54

                // 결과 포맷팅: "4000 원" 형식으로 만들기
                skhpyung.text = SKHnowPriceValue.ToString("N0") + " 원";
                skhpyungsunic.text = skhpyungson.ToString("N0") + " 원 ";
                skhsuicrul.text = skhsuic.ToString("N2") + " % ";
            }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    //=======================================================================
    //=============================SamsungBio===========================
    public void MedoSamBioPNL(string sambioVariable, string indicatorText, string indicator1Text, int weekValuee)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");

        int sambioweek = 0;
        int price = 0;

        Debug.Log(sambioVariable + "매도 시작했다잉!!");

        if (int.TryParse(indicator1Text, out int indicator1Value))
        {
            sambioweek = indicator1Value;
        }

        if (int.TryParse(indicatorText, out int indicatorValue))
        {
            price = indicatorValue;
        }

        if (sambioweek == weekValuee)
        {
            Transform content = GameObject.Find("Canvas/HoldStock/ScrollView/Viewport/Content").transform;

            foreach (Transform child in content)
            {
                if (child.name == sambioVariable)
                {
                    child.gameObject.SetActive(false);
                    Debug.Log("이름이 " + sambioVariable + "인 오브젝트를 찾아 비활성화했습니다.");

                    GameObject medoSamBioClone = GameObject.Find("Medo-SamsungBio(Clone)");
                    if (medoSamBioClone != null)
                    {
                        medoSamBioClone.SetActive(false);
                    }
                }
            }

            // 매도 시 매입금액 감소
            SamBiomeeipprice -= SamBiomaeipdan * SamBioweekValue;

            // 이전 보유수량 - 새로운 주식 수량
            SamBioweekValue -= SamBiomaeipdan;

            // 매도한 주식의 평균단가를 계산
            if (weekValue > 0)
            {
                SamBiomaeipdan = SamBiomeeipprice / SamBioweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                SamBiomaeipdan = 0;
            }

            SamBiomeusprice.text = SamBioweekValue.ToString("N0") + " 주";
            SamBiopnl.text = SamBiomeeipprice.ToString("N0") + " 원";
            SamBiomaeipdanp.text = SamBiomaeipdan.ToString("N0") + " 원";

            // 변수들을 모두 초기화
            SamBioInitializeVariables();
        }
        else if (sambioweek < SamBioweekValue)
        {
            // 매도 시 매입금액 감소
            SamBiomeeipprice -= SamBiomaeipdan * indicator1Value;  // 여기를 수정

            // 이전 보유수량 - 새로운 주식 수량
            SamBioweekValue -= indicator1Value;

            // 매도한 주식의 평균단가를 계산
            if (SamBioweekValue > 0)
            {
                SamBiomaeipdan = SamBiomeeipprice / SamBioweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                SamBiomaeipdan = 0;
            }

            SamBiomeusprice.text = SamBioweekValue.ToString("N0") + " 주";
            SamBiopnl.text = SamBiomeeipprice.ToString("N0") + " 원";
            SamBiomaeipdanp.text = SamBiomaeipdan.ToString("N0") + " 원";
        }
    }
    // 변수들을 초기화하는 메소드
    private void SamBioInitializeVariables()
    {
        SamBioweekValue = 0;
        SamBiomeeipprice = 0;
        SamBiopyungdan = 0;
        SamBiopyungson = 0;
        SamBiosuic = 0.0f;
    }
    public void SBioPNL(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");

        // 숫자 추출
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            SamBioweekValue += indicator1Value;
            SamBiomeeipprice += indicator2Value;
            SamBiomeusprice.text = SamBioweekValue.ToString("N0") + " 주";
            SamBiopnl.text = SamBiomeeipprice.ToString("N0") + " 원";

            SamBiomaeipdan = SamBiomeeipprice / SamBioweekValue;
            SamBiomaeipdanp.text = SamBiomaeipdan.ToString("N0") + " 원";

        }
        else
        {
            Debug.LogError("Cannot parse indicatorText as an integer: " + indicator1Text);
        }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    public void saveSamsungBio(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");

        // 숫자 추출
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            SamBioweekValue += indicator1Value;
            SamBiomeeipprice += indicator2Value * SamBioweekValue;
            SamBiomeusprice.text = SamBioweekValue.ToString("N0") + " 주";
            SamBiopnl.text = SamBiomeeipprice.ToString("N0") + " 원";

            SamBiomaeipdan = SamBiomeeipprice / SamBioweekValue;
            SamBiomaeipdanp.text = SamBiomaeipdan.ToString("N0") + " 원";

        }
        else
        {
            Debug.LogError("Cannot parse indicatorText as an integer: " + indicator1Text);
        }
    }
    public void SaveSamsungBioPNL(long quantityheld, long purchaseprice)
    {
        string indicator1Text = quantityheld.ToString();
        string indicator2Text = purchaseprice.ToString();
        saveSamsungBio(indicator1Text, indicator2Text);
        Invoke("DelayedSamsungBioPNL", 7);
    }
    private void DelayedSamsungBioPNL()
    {
        SamBioPNL("start");
        MedoMaEip("start");
    }
    public void SamBioPNL(string indicatorText)
    {
        string SamBionowP = SamBionowprice.text;
        SamBionowP = SamBionowP.Replace(",", "");

            if (int.TryParse(SamBionowP, out int SamBionowPriceValue))
            {
                SamBiopyungdan = SamBionowPriceValue;
                SamBiomanipdan.text = SamBiopyungdan.ToString("N0") + " 원";

                SamBionowPriceValue = SamBiopyungdan * SamBioweekValue;
                SamBiopyungson = SamBionowPriceValue - SamBiomeeipprice;
                SamBiosuic = (float)SamBiopyungson / SamBiomeeipprice * 100;
                SamBiosuic = Mathf.Round(SamBiosuic * 100) / 100; // 0.1654 -> 16.54

                SamBiopyung.text = SamBionowPriceValue.ToString("N0") + " 원";
                SamBiopyungsunic.text = SamBiopyungson.ToString("N0") + " 원 ";
                SamBiosuicrul.text = SamBiosuic.ToString("N2") + " % ";
            }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    //=======================================================================
    //=============================PoscoHoldings===========================

    public void MedoPoscoHPNL(string PoscoHVariable, string indicatorText, string indicator1Text, int weekValuee)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");

        int PoscoHweek = 0;
        int price = 0;

        Debug.Log(PoscoHVariable + "매도 시작했다잉!!");

        if (int.TryParse(indicator1Text, out int indicator1Value))
        {
            PoscoHweek = indicator1Value;
        }

        if (int.TryParse(indicatorText, out int indicatorValue))
        {
            price = indicatorValue;
        }

        if (PoscoHweek == weekValuee)
        {
            Transform content = GameObject.Find("Canvas/HoldStock/ScrollView/Viewport/Content").transform;

            foreach (Transform child in content)
            {
                if (child.name == PoscoHVariable)
                {
                    child.gameObject.SetActive(false);
                    Debug.Log("이름이 " + PoscoHVariable + "인 오브젝트를 찾아 비활성화했습니다.");

                    GameObject medoposcoHoldClone = GameObject.Find("Medo-PoscoHoldings(Clone)");
                    if (medoposcoHoldClone != null)
                    {
                        medoposcoHoldClone.SetActive(false);
                    }
                }
            }

            // 매도 시 매입금액 감소
            PoscHmeeipprice -= PoscHmaeipdan * PoscHweekValue;

            // 이전 보유수량 - 새로운 주식 수량
            PoscHweekValue -= PoscHmaeipdan;

            // 매도한 주식의 평균단가를 계산
            if (PoscHweekValue > 0)
            {
                PoscHmaeipdan = PoscHmeeipprice / PoscHweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                PoscHmaeipdan = 0;
            }

            PoscHmeusprice.text = PoscHweekValue.ToString("N0") + " 주";
            PoscHpnl.text = PoscHmeeipprice.ToString("N0") + " 원";
            PoscHmaeipdanp.text = PoscHmaeipdan.ToString("N0") + " 원";

            // 변수들을 모두 초기화
            PoscoHoldInitializeVariables();
        }
        else if (PoscoHweek < PoscHweekValue)
        {
            // 매도 시 매입금액 감소
            PoscHmeeipprice -= PoscHmaeipdan * indicator1Value;  // 여기를 수정

            // 이전 보유수량 - 새로운 주식 수량
            PoscHweekValue -= indicator1Value;

            // 매도한 주식의 평균단가를 계산
            if (PoscHweekValue > 0)
            {
                PoscHmaeipdan = PoscHmeeipprice / PoscHweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                PoscHmaeipdan = 0;
            }

            PoscHmeusprice.text = PoscHweekValue.ToString("N0") + " 주";
            PoscHpnl.text = PoscHmeeipprice.ToString("N0") + " 원";
            PoscHmaeipdanp.text = PoscHmaeipdan.ToString("N0") + " 원";
        }
    }
    // 변수들을 초기화하는 메소드
    private void PoscoHoldInitializeVariables()
    {
        PoscHweekValue = 0;
        PoscHmeeipprice = 0;
        PoscHpyungdan = 0;
        PoscHpyungson = 0;
        PoscHsuic = 0.0f;
    }
    public void PoscHPNL(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            PoscHweekValue += indicator1Value;
            PoscHmeeipprice += indicator2Value;
            PoscHmeusprice.text = PoscHweekValue.ToString("N0") + " 주";
            PoscHpnl.text = PoscHmeeipprice.ToString("N0") + " 원";

            PoscHmaeipdan = PoscHmeeipprice / PoscHweekValue;
            PoscHmaeipdanp.text = PoscHmaeipdan.ToString("N0") + " 원";
        }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    public void savePoscoHoldings(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            PoscHweekValue += indicator1Value;
            PoscHmeeipprice += indicator2Value * PoscHweekValue;
            PoscHmeusprice.text = PoscHweekValue.ToString("N0") + " 주";
            PoscHpnl.text = PoscHmeeipprice.ToString("N0") + " 원";

            PoscHmaeipdan = PoscHmeeipprice / PoscHweekValue;
            PoscHmaeipdanp.text = PoscHmaeipdan.ToString("N0") + " 원";
        }
    }
    public void SavePoscoHoldingsPNL(long quantityheld, long purchaseprice)
    {
        string indicator1Text = quantityheld.ToString();
        string indicator2Text = purchaseprice.ToString();
        savePoscoHoldings(indicator1Text, indicator2Text);
        Invoke("DelayedPoscoHoldingsPNL", 7);
    }
    private void DelayedPoscoHoldingsPNL()
    {
        PoscHoldPNL("start");
        MedoMaEip("start");

    }
    public void PoscHoldPNL(string indicatorText)
    {
        string PoscoHoldnowP = PoscHnowprice.text;
        PoscoHoldnowP = PoscoHoldnowP.Replace(",", "");

            if (int.TryParse(PoscoHoldnowP, out int PoscoHoldnowPriceValue))
            {
                PoscHpyungdan = PoscoHoldnowPriceValue;
                PoscHmanipdan.text = PoscHpyungdan.ToString("N0") + " 원";

                PoscoHoldnowPriceValue = PoscHpyungdan * PoscHweekValue;
                PoscHpyungson = PoscoHoldnowPriceValue - PoscHmeeipprice;
                PoscHsuic = (float)PoscHpyungson / PoscHmeeipprice * 100;
                PoscHsuic = Mathf.Round(PoscHsuic * 100) / 100; // 0.1654 -> 16.54

                PoscHpyung.text = PoscoHoldnowPriceValue.ToString("N0") + " 원";
                PoscHpyungsunic.text = PoscHpyungson.ToString("N0") + " 원 ";
                PoscHsuicrul.text = PoscHsuic.ToString("N2") + " % ";
            }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    //=======================================================================
    //=============================HyunDai===========================
    public void MedoHyunDPNL(string HyunDVariable, string indicatorText, string indicator1Text, int weekValuee)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");

        int HyunDweek = 0;
        int price = 0;

        Debug.Log(HyunDVariable + "매도 시작했다잉!!");

        if (int.TryParse(indicator1Text, out int indicator1Value))
        {
            HyunDweek = indicator1Value;
        }

        if (int.TryParse(indicatorText, out int indicatorValue))
        {
            price = indicatorValue;
        }

        if (HyunDweek == weekValuee)
        {
            Transform content = GameObject.Find("Canvas/HoldStock/ScrollView/Viewport/Content").transform;

            foreach (Transform child in content)
            {
                if (child.name == HyunDVariable)
                {
                    child.gameObject.SetActive(false);
                    Debug.Log("이름이 " + HyunDVariable + "인 오브젝트를 찾아 비활성화했습니다.");

                    GameObject medoHyunDClone = GameObject.Find("Medo-HyunDai(Clone)");
                    if (medoHyunDClone != null)
                    {
                        medoHyunDClone.SetActive(false);
                    }
                }
            }

            // 매도 시 매입금액 감소
            HyunDmeeipprice -= HyunDmaeipdan * HyunDweekValue;

            // 이전 보유수량 - 새로운 주식 수량
            HyunDweekValue -= HyunDmaeipdan;

            // 매도한 주식의 평균단가를 계산
            if (HyunDweekValue > 0)
            {
                HyunDmaeipdan = HyunDmeeipprice / HyunDweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                HyunDmaeipdan = 0;
            }

            HyunDmeusprice.text = HyunDweekValue.ToString("N0") + " 주";
            HyunDpnl.text = HyunDmeeipprice.ToString("N0") + " 원";
            HyunDmaeipdanp.text = HyunDmaeipdan.ToString("N0") + " 원";

            // 변수들을 모두 초기화
            HyunDInitializeVariables();
        }
        else if (HyunDweek < HyunDweekValue)
        {
            // 매도 시 매입금액 감소
            HyunDmeeipprice -= HyunDmaeipdan * indicator1Value;  // 여기를 수정

            // 이전 보유수량 - 새로운 주식 수량
            HyunDweekValue -= indicator1Value;

            // 매도한 주식의 평균단가를 계산
            if (HyunDweekValue > 0)
            {
                HyunDmaeipdan = HyunDmeeipprice / HyunDweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                HyunDmaeipdan = 0;
            }

            HyunDmeusprice.text = HyunDweekValue.ToString("N0") + " 주";
            HyunDpnl.text = HyunDmeeipprice.ToString("N0") + " 원";
            HyunDmaeipdanp.text = HyunDmaeipdan.ToString("N0") + " 원";
        }
    }
    // 변수들을 초기화하는 메소드
    private void HyunDInitializeVariables()
    {
        HyunDweekValue = 0;
        HyunDmeeipprice = 0;
        HyunDpyungdan = 0;
        HyunDpyungson = 0;
        HyunDsuic = 0.0f;
    }
    public void HyunDPNL(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            HyunDweekValue += indicator1Value;
            HyunDmeeipprice += indicator2Value;
            HyunDmeusprice.text = HyunDweekValue.ToString("N0") + " 주";
            HyunDpnl.text = HyunDmeeipprice.ToString("N0") + " 원";

            HyunDmaeipdan = HyunDmeeipprice / HyunDweekValue;
            HyunDmaeipdanp.text = HyunDmaeipdan.ToString("N0") + " 원";
        }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    public void saveHyunDai(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            HyunDweekValue += indicator1Value;
            HyunDmeeipprice += indicator2Value * HyunDweekValue;
            HyunDmeusprice.text = HyunDweekValue.ToString("N0") + " 주";
            HyunDpnl.text = HyunDmeeipprice.ToString("N0") + " 원";

            HyunDmaeipdan = HyunDmeeipprice / HyunDweekValue;
            HyunDmaeipdanp.text = HyunDmaeipdan.ToString("N0") + " 원";
        }
    }
    public void SaveHyunDaiPNL(long quantityheld, long purchaseprice)
    {
        string indicator1Text = quantityheld.ToString();
        string indicator2Text = purchaseprice.ToString();
        saveHyunDai(indicator1Text, indicator2Text);
        Invoke("DelayedHyunDaiPNL", 7);
    }
    private void DelayedHyunDaiPNL()
    {
        HyunDaiPNL("start");
        MedoMaEip("start");

    }
    public void HyunDaiPNL(string indicatorText)
    {
        string HyunDnowP = HyunDnowprice.text;
        HyunDnowP = HyunDnowP.Replace(",", "");

            if (int.TryParse(HyunDnowP, out int HyunDnowPriceValue))
            {
                HyunDpyungdan = HyunDnowPriceValue;
                HyunDmanipdan.text = HyunDpyungdan.ToString("N0") + " 원";
                HyunDnowPriceValue = HyunDpyungdan * HyunDweekValue;
                HyunDpyungson = HyunDnowPriceValue - HyunDmeeipprice;
                HyunDsuic = (float)HyunDpyungson / HyunDmeeipprice * 100;
                HyunDsuic = Mathf.Round(HyunDsuic * 100) / 100; // 0.1654 -> 16.54
                HyunDpyung.text = HyunDnowPriceValue.ToString("N0") + " 원";
                HyunDpyungsunic.text = HyunDpyungson.ToString("N0") + " 원 ";
                HyunDsuicrul.text = HyunDsuic.ToString("N2") + " % ";
            }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    //=======================================================================
    //=============================LG화학===========================
    public void MedoLSPNL(string LSVariable, string indicatorText, string indicator1Text, int weekValuee)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");

        int lsweek = 0;
        int price = 0;

        Debug.Log(LSVariable + "매도 시작했다잉!!");

        if (int.TryParse(indicator1Text, out int indicator1Value))
        {
            lsweek = indicator1Value;
        }

        if (int.TryParse(indicatorText, out int indicatorValue))
        {
            price = indicatorValue;
        }

        if (lsweek == weekValuee)
        {
            Transform content = GameObject.Find("Canvas/HoldStock/ScrollView/Viewport/Content").transform;

            foreach (Transform child in content)
            {
                if (child.name == LSVariable)
                {
                    child.gameObject.SetActive(false);
                    Debug.Log("이름이 " + LSVariable + "인 오브젝트를 찾아 비활성화했습니다.");

                    GameObject medoLSClone = GameObject.Find("Medo-LS(Clone)");
                    if (medoLSClone != null)
                    {
                        medoLSClone.SetActive(false);
                    }
                }
            }

            // 매도 시 매입금액 감소
            LSmeeipprice -= LSmaeipdan * LSweekValue;

            // 이전 보유수량 - 새로운 주식 수량
            LSweekValue -= LSmaeipdan;

            // 매도한 주식의 평균단가를 계산
            if (LSweekValue > 0)
            {
                LSmaeipdan = LSmeeipprice / LSweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                LSmaeipdan = 0;
            }

            LSmeusprice.text = LSweekValue.ToString("N0") + " 주";
            LSpnl.text = LSmeeipprice.ToString("N0") + " 원";
            LSmaeipdanp.text = LSmaeipdan.ToString("N0") + " 원";

            // 변수들을 모두 초기화
            LSInitializeVariables();
        }
        else if (lsweek < LSweekValue)
        {
            // 매도 시 매입금액 감소
            LSmeeipprice -= LSmaeipdan * indicator1Value;  // 여기를 수정

            // 이전 보유수량 - 새로운 주식 수량
            LSweekValue -= indicator1Value;

            // 매도한 주식의 평균단가를 계산
            if (LSweekValue > 0)
            {
                LSmaeipdan = LSmeeipprice / LSweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                LSmaeipdan = 0;
            }

            LSmeusprice.text = LSweekValue.ToString("N0") + " 주";
            LSpnl.text = LSmeeipprice.ToString("N0") + " 원";
            LSmaeipdanp.text = LSmaeipdan.ToString("N0") + " 원";
        }
    }
    // 변수들을 초기화하는 메소드
    private void LSInitializeVariables()
    {
        LSweekValue = 0;
        LSmeeipprice = 0;
        LSpyungdan = 0;
        LSpyungson = 0;
        LSsuic = 0.0f;
    }
    public void LSPNL(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");

        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            LSweekValue += indicator1Value;
            LSmeeipprice += indicator2Value;
            LSmeusprice.text = LSweekValue.ToString("N0") + " 주";
            LSpnl.text = LSmeeipprice.ToString("N0") + " 원";

            LSmaeipdan = LSmeeipprice / LSweekValue;
            LSmaeipdanp.text = LSmaeipdan.ToString("N0") + " 원";
        }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    public void savels(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");

        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            LSweekValue += indicator1Value;
            LSmeeipprice += indicator2Value * LSweekValue;
            LSmeusprice.text = LSweekValue.ToString("N0") + " 주";
            LSpnl.text = LSmeeipprice.ToString("N0") + " 원";

            LSmaeipdan = LSmeeipprice / LSweekValue;
            LSmaeipdanp.text = LSmaeipdan.ToString("N0") + " 원";
        }
    }
    public void SaveLSPNL(long quantityheld, long purchaseprice)
    {
        string indicator1Text = quantityheld.ToString();
        string indicator2Text = purchaseprice.ToString();
        savels(indicator1Text, indicator2Text);
        Invoke("DelayedLSPNL", 7);
    }
    private void DelayedLSPNL()
    {
        LSGPNL("start");
        MedoMaEip("start");

    }
    public void LSGPNL(string indicatorText)
    {
        string LSnowP = LSnowprice.text;
        LSnowP = LSnowP.Replace(",", "");

            if (int.TryParse(LSnowP, out int LSnowPriceValue))
            {
                LSpyungdan = LSnowPriceValue;
                LSmanipdan.text = LSpyungdan.ToString("N0") + " 원";
                LSnowPriceValue = LSpyungdan * LSweekValue;
                LSpyungson = LSnowPriceValue - LSmeeipprice;
                LSsuic = (float)LSpyungson / LSmeeipprice * 100;
                LSsuic = Mathf.Round(LSsuic * 100) / 100; // 0.1654 -> 16.54
                LSpyung.text = LSnowPriceValue.ToString("N0") + " 원";
                LSpyungsunic.text = LSpyungson.ToString("N0") + " 원 ";
                LSsuicrul.text = LSsuic.ToString("N2") + " % ";
            }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    //=======================================================================
    //=============================SamsungSDI===========================
    public void MedoSSDIPNL(string SSDIVariable, string indicatorText, string indicator1Text, int weekValuee)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");

        int SSDIweek = 0;
        int price = 0;

        Debug.Log(SSDIVariable + "매도 시작했다잉!!");

        if (int.TryParse(indicator1Text, out int indicator1Value))
        {
            SSDIweek = indicator1Value;
        }

        if (int.TryParse(indicatorText, out int indicatorValue))
        {
            price = indicatorValue;
        }

        if (SSDIweek == weekValuee)
        {
            Transform content = GameObject.Find("Canvas/HoldStock/ScrollView/Viewport/Content").transform;

            foreach (Transform child in content)
            {
                if (child.name == SSDIVariable)
                {
                    child.gameObject.SetActive(false);
                    Debug.Log("이름이 " + SSDIVariable + "인 오브젝트를 찾아 비활성화했습니다.");

                    GameObject medoSSDIClone = GameObject.Find("Medo-SamsungSDI(Clone)");
                    if (medoSSDIClone != null)
                    {
                        medoSSDIClone.SetActive(false);
                    }
                }
            }

            // 매도 시 매입금액 감소
            SSDImeeipprice -= SSDImaeipdan * SSDIweekValue;

            // 이전 보유수량 - 새로운 주식 수량
            SSDIweekValue -= SSDImaeipdan;

            // 매도한 주식의 평균단가를 계산
            if (SSDIweekValue > 0)
            {
                SSDImaeipdan = SSDImeeipprice / SSDIweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                SSDImaeipdan = 0;
            }

            SSDImeusprice.text = SSDIweekValue.ToString("N0") + " 주";
            SSDIpnl.text = SSDImeeipprice.ToString("N0") + " 원";
            SSDImaeipdanp.text = SSDImaeipdan.ToString("N0") + " 원";

            // 변수들을 모두 초기화
            SSDIInitializeVariables();
        }
        else if (SSDIweek < SSDIweekValue)
        {
            // 매도 시 매입금액 감소
            SSDImeeipprice -= SSDImaeipdan * indicator1Value;  // 여기를 수정

            // 이전 보유수량 - 새로운 주식 수량
            SSDIweekValue -= indicator1Value;

            // 매도한 주식의 평균단가를 계산
            if (SSDIweekValue > 0)
            {
                SSDImaeipdan = SSDImeeipprice / SSDIweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                SSDImaeipdan = 0;
            }

            SSDImeusprice.text = SSDIweekValue.ToString("N0") + " 주";
            SSDIpnl.text = SSDImeeipprice.ToString("N0") + " 원";
            SSDImaeipdanp.text = SSDImaeipdan.ToString("N0") + " 원";
        }
    }
    // 변수들을 초기화하는 메소드
    private void SSDIInitializeVariables()
    {
        SSDIweekValue = 0;
        SSDImeeipprice = 0;
        SSDIpyungdan = 0;
        SSDIpyungson = 0;
        SSDIsuic = 0.0f;
    }
    public void SSDIPNL(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            SSDIweekValue += indicator1Value;
            SSDImeeipprice += indicator2Value;
            SSDImeusprice.text = SSDIweekValue.ToString("N0") + " 주";
            SSDIpnl.text = SSDImeeipprice.ToString("N0") + " 원";

            SSDImaeipdan = SSDImeeipprice / SSDIweekValue;
            SSDImaeipdanp.text = SSDImaeipdan.ToString("N0") + " 원";
        }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    public void saveSamsungSDI(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            SSDIweekValue += indicator1Value;
            SSDImeeipprice += indicator2Value * SSDIweekValue;
            SSDImeusprice.text = SSDIweekValue.ToString("N0") + " 주";
            SSDIpnl.text = SSDImeeipprice.ToString("N0") + " 원";

            SSDImaeipdan = SSDImeeipprice / SSDIweekValue;
            SSDImaeipdanp.text = SSDImaeipdan.ToString("N0") + " 원";
        }
    }
    public void SaveSamsungSDIPNL(long quantityheld, long purchaseprice)
    {
        string indicator1Text = quantityheld.ToString();
        string indicator2Text = purchaseprice.ToString();
        saveSamsungSDI(indicator1Text, indicator2Text);
        Invoke("DelayedSamsungSDIPNL", 7);
    }
    private void DelayedSamsungSDIPNL()
    {
        SamsungSDIPNL("start");
        MedoMaEip("start");

    }
    public void SamsungSDIPNL(string indicatorText)
    {
        string SSDInowP = SSDInowprice.text;
        SSDInowP = SSDInowP.Replace(",", "");
            if (int.TryParse(SSDInowP, out int SSDInowPriceValue))
            {
                SSDIpyungdan = SSDInowPriceValue;
                SSDImanipdan.text = SSDIpyungdan.ToString("N0") + " 원";
                SSDInowPriceValue = SSDIpyungdan * SSDIweekValue;
                SSDIpyungson = SSDInowPriceValue - SSDImeeipprice;
                SSDIsuic = (float)SSDIpyungson / SSDImeeipprice * 100;
                SSDIsuic = Mathf.Round(SSDIsuic * 100) / 100; // 0.1654 -> 16.54
                SSDIpyung.text = SSDInowPriceValue.ToString("N0") + " 원";
                SSDIpyungsunic.text = SSDIpyungson.ToString("N0") + " 원 ";
                SSDIsuicrul.text = SSDIsuic.ToString("N2") + " % ";
            }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    //=======================================================================
    //=============================KIA===========================
    public void MedoKIAPNL(string KIAVariable, string indicatorText, string indicator1Text, int weekValuee)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");

        int kiaweek = 0;
        int price = 0;

        Debug.Log(KIAVariable + "매도 시작했다잉!!");

        if (int.TryParse(indicator1Text, out int indicator1Value))
        {
            kiaweek = indicator1Value;
        }

        if (int.TryParse(indicatorText, out int indicatorValue))
        {
            price = indicatorValue;
        }

        if (kiaweek == weekValuee)
        {
            Transform content = GameObject.Find("Canvas/HoldStock/ScrollView/Viewport/Content").transform;

            foreach (Transform child in content)
            {
                if (child.name == KIAVariable)
                {
                    child.gameObject.SetActive(false);
                    Debug.Log("이름이 " + KIAVariable + "인 오브젝트를 찾아 비활성화했습니다.");

                    GameObject medoKIAClone = GameObject.Find("Medo-KIA(Clone)");
                    if (medoKIAClone != null)
                    {
                        medoKIAClone.SetActive(false);
                    }
                }
            }

            // 매도 시 매입금액 감소
            KIAmeeipprice -= KIAmaeipdan * KIAweekValue;

            // 이전 보유수량 - 새로운 주식 수량
            KIAweekValue -= KIAmaeipdan;

            // 매도한 주식의 평균단가를 계산
            if (KIAweekValue > 0)
            {
                KIAmaeipdan = KIAmeeipprice / KIAweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                KIAmaeipdan = 0;
            }

            KIAmeusprice.text = KIAweekValue.ToString("N0") + " 주";
            KIApnl.text = KIAmeeipprice.ToString("N0") + " 원";
            KIAmaeipdanp.text = KIAmaeipdan.ToString("N0") + " 원";

            // 변수들을 모두 초기화
            KIAInitializeVariables();
        }
        else if (kiaweek < KIAweekValue)
        {
            // 매도 시 매입금액 감소
            KIAmeeipprice -= KIAmaeipdan * indicator1Value;  // 여기를 수정

            // 이전 보유수량 - 새로운 주식 수량
            KIAweekValue -= indicator1Value;

            // 매도한 주식의 평균단가를 계산
            if (KIAweekValue > 0)
            {
                KIAmaeipdan = KIAmeeipprice / KIAweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                KIAmaeipdan = 0;
            }

            KIAmeusprice.text = KIAweekValue.ToString("N0") + " 주";
            KIApnl.text = KIAmeeipprice.ToString("N0") + " 원";
            KIAmaeipdanp.text = KIAmaeipdan.ToString("N0") + " 원";
        }
    }
    // 변수들을 초기화하는 메소드
    private void KIAInitializeVariables()
    {
        KIAweekValue = 0;
        KIAmeeipprice = 0;
        KIApyungdan = 0;
        KIApyungson = 0;
        KIAsuic = 0.0f;
    }
    public void KIAPNL(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            KIAweekValue += indicator1Value;
            KIAmeeipprice += indicator2Value;
            KIAmeusprice.text = KIAweekValue.ToString("N0") + " 주";
            KIApnl.text = KIAmeeipprice.ToString("N0") + " 원";

            KIAmaeipdan = KIAmeeipprice / KIAweekValue;
            KIAmaeipdanp.text = KIAmaeipdan.ToString("N0") + " 원";
        }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    public void saveKIA(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            KIAweekValue += indicator1Value;
            KIAmeeipprice += indicator2Value * KIAweekValue;
            KIAmeusprice.text = KIAweekValue.ToString("N0") + " 주";
            KIApnl.text = KIAmeeipprice.ToString("N0") + " 원";

            KIAmaeipdan = KIAmeeipprice / KIAweekValue;
            KIAmaeipdanp.text = KIAmaeipdan.ToString("N0") + " 원";
        }
    }
    public void SaveKIAPNL(long quantityheld, long purchaseprice)
    {
        string indicator1Text = quantityheld.ToString();
        string indicator2Text = purchaseprice.ToString();
        saveKIA(indicator1Text, indicator2Text);
        Invoke("DelayedKIAPNL", 7);
    }
    private void DelayedKIAPNL()
    {
        KIAAPNL("start");
        MedoMaEip("start");
    }
    public void KIAAPNL(string indicatorText)
    {
        string KIAnowP = KIAnowprice.text;
        KIAnowP = KIAnowP.Replace(",", "");

            if (int.TryParse(KIAnowP, out int KIAnowPriceValue))
            {
                KIApyungdan = KIAnowPriceValue;
                KIAmanipdan.text = KIApyungdan.ToString("N0") + " 원 ";
                KIAnowPriceValue = KIApyungdan * KIAweekValue;
                KIApyungson = KIAnowPriceValue - KIAmeeipprice;
                KIAsuic = (float)KIApyungson / KIAmeeipprice * 100;
                KIAsuic = Mathf.Round(KIAsuic * 100) / 100; // 0.1654 -> 16.54
                KIApyung.text = KIAnowPriceValue.ToString("N0") + " 원";
                KIApyungsunic.text = KIApyungson.ToString("N0") + " 원 ";
                KIAsuicrul.text = KIAsuic.ToString("N2") + " % ";
            }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    //=======================================================================
    //=============================NAVER===========================
    public void MedoNVPNL(string NVVariable, string indicatorText, string indicator1Text, int weekValuee)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");

        int mvweek = 0;
        int price = 0;

        Debug.Log(NVVariable + "매도 시작했다잉!!");

        if (int.TryParse(indicator1Text, out int indicator1Value))
        {
            mvweek = indicator1Value;
        }

        if (int.TryParse(indicatorText, out int indicatorValue))
        {
            price = indicatorValue;
        }

        if (mvweek == weekValuee)
        {
            Transform content = GameObject.Find("Canvas/HoldStock/ScrollView/Viewport/Content").transform;

            foreach (Transform child in content)
            {
                if (child.name == NVVariable)
                {
                    child.gameObject.SetActive(false);
                    Debug.Log("이름이 " + NVVariable + "인 오브젝트를 찾아 비활성화했습니다.");

                    GameObject medoNVClone = GameObject.Find("Medo-Naver(Clone)");
                    if (medoNVClone != null)
                    {
                        medoNVClone.SetActive(false);
                    }
                }
            }

            // 매도 시 매입금액 감소
            NVmeeipprice -= NVmaeipdan * NVweekValue;

            // 이전 보유수량 - 새로운 주식 수량
            NVweekValue -= NVmaeipdan;

            // 매도한 주식의 평균단가를 계산
            if (NVweekValue > 0)
            {
                NVmaeipdan = NVmeeipprice / NVweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                NVmaeipdan = 0;
            }

            NVmeusprice.text = NVweekValue.ToString("N0") + " 주";
            NVpnl.text = NVmeeipprice.ToString("N0") + " 원";
            NVmaeipdanp.text = NVmaeipdan.ToString("N0") + " 원";

            // 변수들을 모두 초기화
            NVInitializeVariables();
        }
        else if (mvweek < NVweekValue)
        {
            // 매도 시 매입금액 감소
            NVmeeipprice -= NVmaeipdan * indicator1Value;  // 여기를 수정

            // 이전 보유수량 - 새로운 주식 수량
            NVweekValue -= indicator1Value;

            // 매도한 주식의 평균단가를 계산
            if (NVweekValue > 0)
            {
                NVmaeipdan = NVmeeipprice / NVweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                NVmaeipdan = 0;
            }

            NVmeusprice.text = NVweekValue.ToString("N0") + " 주";
            NVpnl.text = NVmeeipprice.ToString("N0") + " 원";
            NVmaeipdanp.text = NVmaeipdan.ToString("N0") + " 원";
        }
    }
    // 변수들을 초기화하는 메소드
    private void NVInitializeVariables()
    {
        NVweekValue = 0;
        NVmeeipprice = 0;
        NVpyungdan = 0;
        NVpyungson = 0;
        NVsuic = 0.0f;
    }
    public void NVPNL(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            NVweekValue += indicator1Value;
            NVmeeipprice += indicator2Value;
            NVmeusprice.text = NVweekValue.ToString("N0") + " 주";
            NVpnl.text = NVmeeipprice.ToString("N0") + " 원";

            NVmaeipdan = NVmeeipprice / NVweekValue;
            NVmaeipdanp.text = NVmaeipdan.ToString("N0") + " 원";
        }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    public void saveNaver(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            NVweekValue += indicator1Value;
            NVmeeipprice += indicator2Value * NVweekValue;
            NVmeusprice.text = NVweekValue.ToString("N0") + " 주";
            NVpnl.text = NVmeeipprice.ToString("N0") + " 원";

            NVmaeipdan = NVmeeipprice / NVweekValue;
            NVmaeipdanp.text = NVmaeipdan.ToString("N0") + " 원";
        }
    }
    public void SaveNaverPNL(long quantityheld, long purchaseprice)
    {
        string indicator1Text = quantityheld.ToString();
        string indicator2Text = purchaseprice.ToString();
        saveNaver(indicator1Text, indicator2Text);
        Invoke("DelayedNaverPNL", 7);
    }
    private void DelayedNaverPNL()
    {
        NAVERPNL("start");
        MedoMaEip("start");

    }
    public void NAVERPNL(string indicatorText)
    {
        string NVnowP = NVnowprice.text;
        NVnowP = NVnowP.Replace(",", "");

            if (int.TryParse(NVnowP, out int NVnowPriceValue))
            {
                NVpyungdan = NVnowPriceValue;
                NVmanipdan.text = NVpyungdan.ToString("N0") + " 원";
                NVnowPriceValue = NVpyungdan * NVweekValue;
                NVpyungson = NVnowPriceValue - NVmeeipprice;
                NVsuic = (float)NVpyungson / NVmeeipprice * 100;
                NVsuic = Mathf.Round(NVsuic * 100) / 100; // 0.1654 -> 16.54
                NVpyung.text = NVnowPriceValue.ToString("N0") + " 원";
                NVpyungsunic.text = NVpyungson.ToString("N0") + " 원 ";
                NVsuicrul.text = NVsuic.ToString("N2") + " % ";
            }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    //=======================================================================
    //=============================PoscoFuture===========================
    public void MedoPFPNL(string PFVariable, string indicatorText, string indicator1Text, int weekValuee)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");

        int PFweek = 0;
        int price = 0;

        Debug.Log(PFVariable + "매도 시작했다잉!!");

        if (int.TryParse(indicator1Text, out int indicator1Value))
        {
            PFweek = indicator1Value;
        }

        if (int.TryParse(indicatorText, out int indicatorValue))
        {
            price = indicatorValue;
        }

        if (PFweek == weekValuee)
        {
            Transform content = GameObject.Find("Canvas/HoldStock/ScrollView/Viewport/Content").transform;

            foreach (Transform child in content)
            {
                if (child.name == PFVariable)
                {
                    child.gameObject.SetActive(false);
                    Debug.Log("이름이 " + PFVariable + "인 오브젝트를 찾아 비활성화했습니다.");

                    GameObject medoPFClone = GameObject.Find("Medo-PoscoFuture(Clone)");
                    if (medoPFClone != null)
                    {
                        medoPFClone.SetActive(false);
                    }
                }
            }

            // 매도 시 매입금액 감소
            PFmeeipprice -= PFmaeipdan * PFweekValue;

            // 이전 보유수량 - 새로운 주식 수량
            PFweekValue -= PFmaeipdan;

            // 매도한 주식의 평균단가를 계산
            if (PFweekValue > 0)
            {
                PFmaeipdan = PFmeeipprice / PFweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                PFmaeipdan = 0;
            }

            PFmeusprice.text = PFweekValue.ToString("N0") + " 주";
            PFpnl.text = PFmeeipprice.ToString("N0") + " 원";
            PFmaeipdanp.text = PFmaeipdan.ToString("N0") + " 원";

            // 변수들을 모두 초기화
            PFInitializeVariables();
        }
        else if (PFweek < PFweekValue)
        {
            // 매도 시 매입금액 감소
            PFmeeipprice -= PFmaeipdan * indicator1Value;  // 여기를 수정

            // 이전 보유수량 - 새로운 주식 수량
            PFweekValue -= indicator1Value;

            // 매도한 주식의 평균단가를 계산
            if (PFweekValue > 0)
            {
                PFmaeipdan = PFmeeipprice / PFweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                PFmaeipdan = 0;
            }

            PFmeusprice.text = PFweekValue.ToString("N0") + " 주";
            PFpnl.text = PFmeeipprice.ToString("N0") + " 원";
            PFmaeipdanp.text = PFmaeipdan.ToString("N0") + " 원";
        }
    }
    // 변수들을 초기화하는 메소드
    private void PFInitializeVariables()
    {
        PFweekValue = 0;
        PFmeeipprice = 0;
        PFpyungdan = 0;
        PFpyungson = 0;
        PFsuic = 0.0f;
    }
    public void PFPNL(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            PFweekValue += indicator1Value;
            PFmeeipprice += indicator2Value;
            PFmeusprice.text = PFweekValue.ToString("N0") + " 주";
            PFpnl.text = PFmeeipprice.ToString("N0") + " 원";

            PFmaeipdan = PFmeeipprice / PFweekValue;
            PFmaeipdanp.text = PFmaeipdan.ToString("N0") + " 원";
        }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    public void savePoscoFuture(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            PFweekValue += indicator1Value;
            PFmeeipprice += indicator2Value * PFweekValue;
            PFmeusprice.text = PFweekValue.ToString("N0") + " 주";
            PFpnl.text = PFmeeipprice.ToString("N0") + " 원";

            PFmaeipdan = PFmeeipprice / PFweekValue;
            PFmaeipdanp.text = PFmaeipdan.ToString("N0") + " 원";
        }
    }
    public void SavePoscoFuturePNL(long quantityheld, long purchaseprice)
    {
        string indicator1Text = quantityheld.ToString();
        string indicator2Text = purchaseprice.ToString();
        savePoscoFuture(indicator1Text, indicator2Text);
        Invoke("DelayedPoscoFuturePNL", 7);
    }
    private void DelayedPoscoFuturePNL()
    {
        PoscoFPNL("start");
        MedoMaEip("start");
    }
    public void PoscoFPNL(string indicatorText)
    {
        string PFnowP = PFnowprice.text;
        PFnowP = PFnowP.Replace(",", "");
            if (int.TryParse(PFnowP, out int PFnowPriceValue))
            {
                PFpyungdan = PFnowPriceValue;
                PFmanipdan.text = PFpyungdan.ToString("N0") + " 원 ";
                PFnowPriceValue = PFpyungdan * PFweekValue;
                PFpyungson = PFnowPriceValue - PFmeeipprice;
                PFsuic = (float)PFpyungson / PFmeeipprice * 100;
                PFsuic = Mathf.Round(PFsuic * 100) / 100; // 0.1654 -> 16.54
                PFpyung.text = PFnowPriceValue.ToString("N0") + " 원";
                PFpyungsunic.text = PFpyungson.ToString("N0") + " 원 ";
                PFsuicrul.text = PFsuic.ToString("N2") + " % ";
            }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    //=======================================================================
    //=============================KB===========================
    public void MedoKBPNL(string KBVariable, string indicatorText, string indicator1Text, int weekValuee)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");

        int kbweek = 0;
        int price = 0;

        Debug.Log(KBVariable + "매도 시작했다잉!!");

        if (int.TryParse(indicator1Text, out int indicator1Value))
        {
            kbweek = indicator1Value;
        }

        if (int.TryParse(indicatorText, out int indicatorValue))
        {
            price = indicatorValue;
        }

        if (kbweek == weekValuee)
        {
            Transform content = GameObject.Find("Canvas/HoldStock/ScrollView/Viewport/Content").transform;

            foreach (Transform child in content)
            {
                if (child.name == KBVariable)
                {
                    child.gameObject.SetActive(false);
                    Debug.Log("이름이 " + KBVariable + "인 오브젝트를 찾아 비활성화했습니다.");

                    GameObject medoKBClone = GameObject.Find("Medo-KB(Clone)");
                    if (medoKBClone != null)
                    {
                        medoKBClone.SetActive(false);
                    }
                }
            }

            // 매도 시 매입금액 감소
            KBmeeipprice -= KBmaeipdan * KBweekValue;

            // 이전 보유수량 - 새로운 주식 수량
            KBweekValue -= KBmaeipdan;

            // 매도한 주식의 평균단가를 계산
            if (KBweekValue > 0)
            {
                KBmaeipdan = KBmeeipprice / KBweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                KBmaeipdan = 0;
            }

            KBmeusprice.text = KBweekValue.ToString("N0") + " 주";
            KBpnl.text = KBmeeipprice.ToString("N0") + " 원";
            KBmaeipdanp.text = KBmaeipdan.ToString("N0") + " 원";

            // 변수들을 모두 초기화
            KBInitializeVariables();
        }
        else if (kbweek < KBweekValue)
        {
            // 매도 시 매입금액 감소
            KBmeeipprice -= KBmaeipdan * indicator1Value;  // 여기를 수정

            // 이전 보유수량 - 새로운 주식 수량
            KBweekValue -= indicator1Value;

            // 매도한 주식의 평균단가를 계산
            if (KBweekValue > 0)
            {
                KBmaeipdan = KBmeeipprice / KBweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                KBmaeipdan = 0;
            }

            KBmeusprice.text = KBweekValue.ToString("N0") + " 주";
            KBpnl.text = KBmeeipprice.ToString("N0") + " 원";
            KBmaeipdanp.text = KBmaeipdan.ToString("N0") + " 원";
        }
    }

    private void KBInitializeVariables()
    {
        KBweekValue = 0;
        KBmeeipprice = 0;
        KBpyungdan = 0;
        KBpyungson = 0;
        KBsuic = 0.0f;
    }
    public void KBPNL(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            KBweekValue += indicator1Value;
            KBmeeipprice += indicator2Value;
            KBmeusprice.text = KBweekValue.ToString("N0") + " 주";
            KBpnl.text = KBmeeipprice.ToString("N0") + " 원";

            KBmaeipdan = KBmeeipprice / KBweekValue;
            KBmaeipdanp.text = KBmaeipdan.ToString("N0") + " 원";
        }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    public void saveKB(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            KBweekValue += indicator1Value;
            KBmeeipprice += indicator2Value * KBweekValue;
            KBmeusprice.text = KBweekValue.ToString("N0") + " 주";
            KBpnl.text = KBmeeipprice.ToString("N0") + " 원";

            KBmaeipdan = KBmeeipprice / KBweekValue;
            KBmaeipdanp.text = KBmaeipdan.ToString("N0") + " 원";
        }
    }
    public void SaveLGPNL(long quantityheld, long purchaseprice)
    {
        string indicator1Text = quantityheld.ToString();
        string indicator2Text = purchaseprice.ToString();
        saveKB(indicator1Text, indicator2Text);
        Invoke("DelayedKBPNL", 7);
    }
    private void DelayedKBPNL()
    {
        KKBPNL("start");
        MedoMaEip("start");
    }
    public void KKBPNL(string indicatorText)
    {
        string KBnowP = KBnowprice.text;
        KBnowP = KBnowP.Replace(",", "");
            if (int.TryParse(KBnowP, out int KBnowPriceValue))
            {
                KBpyungdan = KBnowPriceValue;
                KBmanipdan.text = KBnowPriceValue.ToString("N0") + " 원";
                KBnowPriceValue = KBpyungdan * KBweekValue;
                KBpyungson = KBnowPriceValue - KBmeeipprice;
                KBsuic = (float)KBpyungson / KBmeeipprice * 100;
                KBsuic = Mathf.Round(KBsuic * 100) / 100; // 0.1654 -> 16.54
                KBpyung.text = KBnowPriceValue.ToString("N0") + " 원";
                KBpyungsunic.text = KBpyungson.ToString("N0") + " 원 ";
                KBsuicrul.text = KBsuic.ToString("N2") + " % ";
            }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    //=======================================================================
    //=============================Hyundaimovius===========================
    public void MedoHDMPNL(string HDMVariable, string indicatorText, string indicator1Text, int weekValuee)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");

        int HDMweek = 0;
        int price = 0;

        Debug.Log(HDMVariable + "매도 시작했다잉!!");

        if (int.TryParse(indicator1Text, out int indicator1Value))
        {
            HDMweek = indicator1Value;
        }

        if (int.TryParse(indicatorText, out int indicatorValue))
        {
            price = indicatorValue;
        }

        if (HDMweek == weekValuee)
        {
            Transform content = GameObject.Find("Canvas/HoldStock/ScrollView/Viewport/Content").transform;

            foreach (Transform child in content)
            {
                if (child.name == HDMVariable)
                {
                    child.gameObject.SetActive(false);
                    Debug.Log("이름이 " + HDMVariable + "인 오브젝트를 찾아 비활성화했습니다.");

                    GameObject medoHDMClone = GameObject.Find("Medo-HyunDaiMovius(Clone)");
                    if (medoHDMClone != null)
                    {
                        medoHDMClone.SetActive(false);
                    }
                }
            }

            // 매도 시 매입금액 감소
            HDMmeeipprice -= HDMmaeipdan * HDMweekValue;

            // 이전 보유수량 - 새로운 주식 수량
            HDMweekValue -= HDMmaeipdan;

            // 매도한 주식의 평균단가를 계산
            if (HDMweekValue > 0)
            {
                HDMmaeipdan = HDMmeeipprice / HDMweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                HDMmaeipdan = 0;
            }

            HDMmeusprice.text = HDMweekValue.ToString("N0") + " 주";
            HDMpnl.text = HDMmeeipprice.ToString("N0") + " 원";
            HDMmaeipdanp.text = HDMmaeipdan.ToString("N0") + " 원";

            // 변수들을 모두 초기화
            HDMInitializeVariables();
        }
        else if (HDMweek < HDMweekValue)
        {
            // 매도 시 매입금액 감소
            HDMmeeipprice -= HDMmaeipdan * indicator1Value;  // 여기를 수정

            // 이전 보유수량 - 새로운 주식 수량
            HDMweekValue -= indicator1Value;

            // 매도한 주식의 평균단가를 계산
            if (HDMweekValue > 0)
            {
                HDMmaeipdan = HDMmeeipprice / HDMweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                HDMmaeipdan = 0;
            }

            HDMmeusprice.text = HDMweekValue.ToString("N0") + " 주";
            HDMpnl.text = HDMmeeipprice.ToString("N0") + " 원";
            HDMmaeipdanp.text = HDMmaeipdan.ToString("N0") + " 원";
        }
    }
    // 변수들을 초기화하는 메소드
    private void HDMInitializeVariables()
    {
        HDMweekValue = 0;
        HDMmeeipprice = 0;
        HDMpyungdan = 0;
        HDMpyungson = 0;
        HDMsuic = 0.0f;
    }
    public void HyunDMPNL(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            HDMweekValue += indicator1Value;
            HDMmeeipprice += indicator2Value;
            HDMmeusprice.text = HDMweekValue.ToString("N0") + " 주";
            HDMpnl.text = HDMmeeipprice.ToString("N0") + " 원";

            HDMmaeipdan = HDMmeeipprice / HDMweekValue;
            HDMmaeipdanp.text = HDMmaeipdan.ToString("N0") + " 원";
        }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    public void saveHyunDM(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            HDMweekValue += indicator1Value;
            HDMmeeipprice += indicator2Value * HDMweekValue;
            HDMmeusprice.text = HDMweekValue.ToString("N0") + " 주";
            HDMpnl.text = HDMmeeipprice.ToString("N0") + " 원";

            HDMmaeipdan = HDMmeeipprice / HDMweekValue;
            HDMmaeipdanp.text = HDMmaeipdan.ToString("N0") + " 원";
        }
    }
    public void SaveHyunDMPNL(long quantityheld, long purchaseprice)
    {
        string indicator1Text = quantityheld.ToString();
        string indicator2Text = purchaseprice.ToString();
        saveHyunDM(indicator1Text, indicator2Text);
        Invoke("DelayedHyunDMPNL", 7);
    }
    private void DelayedHyunDMPNL()
    {
        HDMPNL("start");
        MedoMaEip("start");
    }
    public void HDMPNL(string indicatorText)
    {
        string HDMnowP = HDMnowprice.text;
        HDMnowP = HDMnowP.Replace(",", "");

            if (int.TryParse(HDMnowP, out int HDMnowPriceValue))
            {
                HDMpyungdan = HDMnowPriceValue;
                HDMmanipdan.text = HDMpyungdan.ToString("N0") + " 원";
                HDMnowPriceValue = HDMpyungdan * HDMweekValue;
                HDMpyungson = HDMnowPriceValue - HDMmeeipprice;
                HDMsuic = (float)HDMpyungson / HDMmeeipprice * 100;
                HDMsuic = Mathf.Round(HDMsuic * 100) / 100; // 0.1654 -> 16.54
                HDMpyung.text = HDMnowPriceValue.ToString("N0") + " 원";
                HDMpyungsunic.text = HDMpyungson.ToString("N0") + " 원 ";
                HDMsuicrul.text = HDMsuic.ToString("N2") + " % ";
            }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    //=======================================================================
    //=============================Seltrion===========================
    public void MedoSTPNL(string STVariable, string indicatorText, string indicator1Text, int weekValuee)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");

        int STweek = 0;
        int price = 0;

        Debug.Log(STVariable + "매도 시작했다잉!!");

        if (int.TryParse(indicator1Text, out int indicator1Value))
        {
            STweek = indicator1Value;
        }

        if (int.TryParse(indicatorText, out int indicatorValue))
        {
            price = indicatorValue;
        }

        if (STweek == weekValuee)
        {
            Transform content = GameObject.Find("Canvas/HoldStock/ScrollView/Viewport/Content").transform;

            foreach (Transform child in content)
            {
                if (child.name == STVariable)
                {
                    child.gameObject.SetActive(false);
                    Debug.Log("이름이 " + STVariable + "인 오브젝트를 찾아 비활성화했습니다.");

                    GameObject medoSTClone = GameObject.Find("Medo-Seltrion(Clone)");
                    if (medoSTClone != null)
                    {
                        medoSTClone.SetActive(false);
                    }
                }
            }

            // 매도 시 매입금액 감소
            STmeeipprice -= STmaeipdan * STweekValue;

            // 이전 보유수량 - 새로운 주식 수량
            STweekValue -= STmaeipdan;

            // 매도한 주식의 평균단가를 계산
            if (STweekValue > 0)
            {
                STmaeipdan = STmeeipprice / STweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                STmaeipdan = 0;
            }

            STmeusprice.text = STweekValue.ToString("N0") + " 주";
            STpnl.text = STmeeipprice.ToString("N0") + " 원";
            STmaeipdanp.text = STmaeipdan.ToString("N0") + " 원";

            // 변수들을 모두 초기화
            STInitializeVariables();
        }
        else if (STweek < STweekValue)
        {
            // 매도 시 매입금액 감소
            STmeeipprice -= STmaeipdan * indicator1Value;  // 여기를 수정

            // 이전 보유수량 - 새로운 주식 수량
            STweekValue -= indicator1Value;

            // 매도한 주식의 평균단가를 계산
            if (STweekValue > 0)
            {
                STmaeipdan = STmeeipprice / STweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                STmaeipdan = 0;
            }

            STmeusprice.text = STweekValue.ToString("N0") + " 주";
            STpnl.text = STmeeipprice.ToString("N0") + " 원";
            STmaeipdanp.text = STmaeipdan.ToString("N0") + " 원";
        }
    }
    // 변수들을 초기화하는 메소드
    private void STInitializeVariables()
    {
        STweekValue = 0;
        STmeeipprice = 0;
        STpyungdan = 0;
        STpyungson = 0;
        STsuic = 0.0f;
    }
    public void SelTPNL(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            STweekValue += indicator1Value;
            STmeeipprice += indicator2Value;
            STmeusprice.text = STweekValue.ToString("N0") + " 주";
            STpnl.text = STmeeipprice.ToString("N0") + " 원";

            STmaeipdan = STmeeipprice / STweekValue;
            STmaeipdanp.text = STmaeipdan.ToString("N0") + " 원";
        }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    public void saveSeltrion(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            STweekValue += indicator1Value;
            STmeeipprice += indicator2Value * STweekValue;
            STmeusprice.text = STweekValue.ToString("N0") + " 주";
            STpnl.text = STmeeipprice.ToString("N0") + " 원";

            STmaeipdan = STmeeipprice / STweekValue;
            STmaeipdanp.text = STmaeipdan.ToString("N0") + " 원";
        }
    }
    public void SaveSeltrionPNL(long quantityheld, long purchaseprice)
    {
        string indicator1Text = quantityheld.ToString();
        string indicator2Text = purchaseprice.ToString();
        saveSeltrion(indicator1Text, indicator2Text);
        Invoke("DelayedSeltrionPNL", 7);
    }
    private void DelayedSeltrionPNL()
    {
        STPNL("start");
        MedoMaEip("start");
    }
    public void STPNL(string indicatorText)
    {
        string STnowP = STnowprice.text;
        STnowP = STnowP.Replace(",", "");

            if (int.TryParse(STnowP, out int STnowPriceValue))
            {
                STpyungdan = STnowPriceValue;
                STmanipdan.text = STpyungdan.ToString("N0") + " 원";
                STnowPriceValue = STpyungdan * STweekValue;
                STpyungson = STnowPriceValue - STmeeipprice;
                STsuic = (float)STpyungson / STmeeipprice * 100;
                STsuic = Mathf.Round(STsuic * 100) / 100; // 0.1654 -> 16.54
                STpyung.text = STnowPriceValue.ToString("N0") + " 원";
                STpyungsunic.text = STpyungson.ToString("N0") + " 원 ";
                STsuicrul.text = STsuic.ToString("N2") + " % ";
            }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    //=======================================================================
    //=============================SamsungMul===========================
    public void MedoSamMPNL(string SamMVariable, string indicatorText, string indicator1Text, int weekValuee)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");

        int SamMweek = 0;
        int price = 0;

        Debug.Log(SamMVariable + "매도 시작했다잉!!");

        if (int.TryParse(indicator1Text, out int indicator1Value))
        {
            SamMweek = indicator1Value;
        }

        if (int.TryParse(indicatorText, out int indicatorValue))
        {
            price = indicatorValue;
        }

        if (SamMweek == weekValuee)
        {
            Transform content = GameObject.Find("Canvas/HoldStock/ScrollView/Viewport/Content").transform;

            foreach (Transform child in content)
            {
                if (child.name == SamMVariable)
                {
                    child.gameObject.SetActive(false);
                    Debug.Log("이름이 " + SamMVariable + "인 오브젝트를 찾아 비활성화했습니다.");

                    GameObject medoSamMClone = GameObject.Find("Medo-SamsungMulsan(Clone)");
                    if (medoSamMClone != null)
                    {
                        medoSamMClone.SetActive(false);
                    }
                }
            }

            // 매도 시 매입금액 감소
            SamMmeeipprice -= SamMmaeipdan * SamMweekValue;

            // 이전 보유수량 - 새로운 주식 수량
            SamMweekValue -= SamMmaeipdan;

            // 매도한 주식의 평균단가를 계산
            if (SamMweekValue > 0)
            {
                SamMmaeipdan = SamMmeeipprice / SamMweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                SamMmaeipdan = 0;
            }

            SamMmeusprice.text = SamMweekValue.ToString("N0") + " 주";
            SamMpnl.text = SamMmeeipprice.ToString("N0") + " 원";
            SamMmaeipdanp.text = SamMmaeipdan.ToString("N0") + " 원";

            // 변수들을 모두 초기화
            SamMInitializeVariables();
        }
        else if (SamMweek < SamMweekValue)
        {
            // 매도 시 매입금액 감소
            SamMmeeipprice -= SamMmaeipdan * indicator1Value;  // 여기를 수정

            // 이전 보유수량 - 새로운 주식 수량
            SamMweekValue -= indicator1Value;

            // 매도한 주식의 평균단가를 계산
            if (SamMweekValue > 0)
            {
                SamMmaeipdan = SamMmeeipprice / SamMweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                SamMmaeipdan = 0;
            }

            SamMmeusprice.text = SamMweekValue.ToString("N0") + " 주";
            SamMpnl.text = SamMmeeipprice.ToString("N0") + " 원";
            SamMmaeipdanp.text = SamMmaeipdan.ToString("N0") + " 원";
        }
    }
    // 변수들을 초기화하는 메소드
    private void SamMInitializeVariables()
    {
        SamMweekValue = 0;
        SamMmeeipprice = 0;
        SamMpyungdan = 0;
        SamMpyungson = 0;
        SamMsuic = 0.0f;
    }
    public void SamMPNL(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            SamMweekValue += indicator1Value;
            SamMmeeipprice += indicator2Value;
            SamMmeusprice.text = SamMweekValue.ToString("N0") + " 주";
            SamMpnl.text = SamMmeeipprice.ToString("N0") + " 원";

            SamMmaeipdan = SamMmeeipprice / SamMweekValue;
            SamMmaeipdanp.text = SamMmaeipdan.ToString("N0") + " 원";
        }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    public void saveSamsungMulsan(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            SamMweekValue += indicator1Value;
            SamMmeeipprice += indicator2Value * SamMweekValue;
            SamMmeusprice.text = SamMweekValue.ToString("N0") + " 주";
            SamMpnl.text = SamMmeeipprice.ToString("N0") + " 원";

            SamMmaeipdan = SamMmeeipprice / SamMweekValue;
            SamMmaeipdanp.text = SamMmaeipdan.ToString("N0") + " 원";
        }
    }
    public void SaveSamsungMulsanPNL(long quantityheld, long purchaseprice)
    {
        string indicator1Text = quantityheld.ToString();
        string indicator2Text = purchaseprice.ToString();
        saveSamsungMulsan(indicator1Text, indicator2Text);
        Invoke("DelayedSamsungMulsanPNL", 7);
    }
    private void DelayedSamsungMulsanPNL()
    {
        SMPNL("start");
        MedoMaEip("start");

    }
    public void SMPNL(string indicatorText)
    {
        string SamMnowP = SamMnowprice.text;
        SamMnowP = SamMnowP.Replace(",", "");
            if (int.TryParse(SamMnowP, out int SamMnowPriceValue))
            {
                SamMpyungdan = SamMnowPriceValue;
                SamMmanipdan.text = SamMnowPriceValue.ToString("N0") + " 원 ";
                SamMnowPriceValue = SamMpyungdan * SamMweekValue;
                SamMpyungson = SamMnowPriceValue - SamMmeeipprice;
                SamMsuic = (float)SamMpyungson / SamMmeeipprice * 100;
                SamMsuic = Mathf.Round(SamMsuic * 100) / 100; // 0.1654 -> 16.54
                SamMpyung.text = SamMnowPriceValue.ToString("N0") + " 원";
                SamMpyungsunic.text = SamMpyungson.ToString("N0") + " 원 ";
                SamMsuicrul.text = SamMsuic.ToString("N2") + " % ";
            }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    //=======================================================================
    //=============================Kakao===========================
    public void MedoKKOPNL(string KKOVariable, string indicatorText, string indicator1Text, int weekValuee)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");

        int KKOweek = 0;
        int price = 0;

        Debug.Log(KKOVariable + "매도 시작했다잉!!");

        if (int.TryParse(indicator1Text, out int indicator1Value))
        {
            KKOweek = indicator1Value;
        }

        if (int.TryParse(indicatorText, out int indicatorValue))
        {
            price = indicatorValue;
        }

        if (KKOweek == weekValuee)
        {
            Transform content = GameObject.Find("Canvas/HoldStock/ScrollView/Viewport/Content").transform;

            foreach (Transform child in content)
            {
                if (child.name == KKOVariable)
                {
                    child.gameObject.SetActive(false);
                    Debug.Log("이름이 " + KKOVariable + "인 오브젝트를 찾아 비활성화했습니다.");

                    GameObject medoKKOClone = GameObject.Find("Medo-Kakao(Clone)");
                    if (medoKKOClone != null)
                    {
                        medoKKOClone.SetActive(false);
                    }
                }
            }

            // 매도 시 매입금액 감소
            KKOmeeipprice -= KKOmaeipdan * KKOweekValue;

            // 이전 보유수량 - 새로운 주식 수량
            KKOweekValue -= KKOmaeipdan;

            // 매도한 주식의 평균단가를 계산
            if (KKOweekValue > 0)
            {
                KKOmaeipdan = KKOmeeipprice / KKOweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                KKOmaeipdan = 0;
            }

            KKOmeusprice.text = KKOweekValue.ToString("N0") + " 주";
            KKOpnl.text = KKOmeeipprice.ToString("N0") + " 원";
            KKOmaeipdanp.text = KKOmaeipdan.ToString("N0") + " 원";

            // 변수들을 모두 초기화
            KKOInitializeVariables();
        }
        else if (KKOweek < KKOweekValue)
        {
            // 매도 시 매입금액 감소
            KKOmeeipprice -= KKOmaeipdan * indicator1Value;  // 여기를 수정

            // 이전 보유수량 - 새로운 주식 수량
            KKOweekValue -= indicator1Value;

            // 매도한 주식의 평균단가를 계산
            if (KKOweekValue > 0)
            {
                KKOmaeipdan = KKOmeeipprice / KKOweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                KKOmaeipdan = 0;
            }

            KKOmeusprice.text = KKOweekValue.ToString("N0") + " 주";
            KKOpnl.text = KKOmeeipprice.ToString("N0") + " 원";
            KKOmaeipdanp.text = KKOmaeipdan.ToString("N0") + " 원";
        }
    }
    // 변수들을 초기화하는 메소드
    private void KKOInitializeVariables()
    {
        KKOweekValue = 0;
        KKOmeeipprice = 0;
        KKOpyungdan = 0;
        KKOpyungson = 0;
        KKOsuic = 0.0f;
    }

    public void KKOPNL(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            KKOweekValue += indicator1Value;
            KKOmeeipprice += indicator2Value;
            KKOmeusprice.text = KKOweekValue.ToString("N0") + " 주";
            KKOpnl.text = KKOmeeipprice.ToString("N0") + " 원";

            KKOmaeipdan = KKOmeeipprice / KKOweekValue;
            KKOmaeipdanp.text = KKOmaeipdan.ToString("N0") + " 원";
        }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    public void saveKakao(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            KKOweekValue += indicator1Value;
            KKOmeeipprice += indicator2Value * KKOweekValue;
            KKOmeusprice.text = KKOweekValue.ToString("N0") + " 주";
            KKOpnl.text = KKOmeeipprice.ToString("N0") + " 원";

            KKOmaeipdan = KKOmeeipprice / KKOweekValue;
            KKOmaeipdanp.text = KKOmaeipdan.ToString("N0") + " 원";
        }
    }
    public void SaveKakaoPNL(long quantityheld, long purchaseprice)
    {
        string indicator1Text = quantityheld.ToString();
        string indicator2Text = purchaseprice.ToString();
        saveKakao(indicator1Text, indicator2Text);
        Invoke("DelayedKakaoPNL", 7);
    }
    private void DelayedKakaoPNL()
    {
        KKPNL("start");
        MedoMaEip("start");

    }
    public void KKPNL(string indicatorText)
    {
        string KKOnowP = KKOnowprice.text;
        KKOnowP = KKOnowP.Replace(",", "");

            if (int.TryParse(KKOnowP, out int KKOnowPriceValue))
            {
                KKOpyungdan = KKOnowPriceValue;
                KKOmanipdan.text = KKOpyungdan.ToString("N0") + " 원";
                KKOnowPriceValue = KKOpyungdan * KKOweekValue;
                KKOpyungson = KKOnowPriceValue - KKOmeeipprice;
                KKOsuic = (float)KKOpyungson / KKOmeeipprice * 100;
                KKOsuic = Mathf.Round(KKOsuic * 100) / 100; // 0.1654 -> 16.54
                KKOpyung.text = KKOnowPriceValue.ToString("N0") + " 원";
                KKOpyungsunic.text = KKOpyungson.ToString("N0") + " 원 ";
                KKOsuicrul.text = KKOsuic.ToString("N2") + " % ";
            }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    //=======================================================================
    //=============================Sinhan===========================
    public void MedoSinHanPNL(string SinHanVariable, string indicatorText, string indicator1Text, int weekValuee)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");

        int SinHanweek = 0;
        int price = 0;

        Debug.Log(SinHanVariable + "매도 시작했다잉!!");

        if (int.TryParse(indicator1Text, out int indicator1Value))
        {
            SinHanweek = indicator1Value;
        }

        if (int.TryParse(indicatorText, out int indicatorValue))
        {
            price = indicatorValue;
        }

        if (SinHanweek == weekValuee)
        {
            Transform content = GameObject.Find("Canvas/HoldStock/ScrollView/Viewport/Content").transform;

            foreach (Transform child in content)
            {
                if (child.name == SinHanVariable)
                {
                    child.gameObject.SetActive(false);
                    Debug.Log("이름이 " + SinHanVariable + "인 오브젝트를 찾아 비활성화했습니다.");

                    GameObject medoSinHanClone = GameObject.Find("Medo-Sinhan(Clone)");
                    if (medoSinHanClone != null)
                    {
                        medoSinHanClone.SetActive(false);
                    }
                }
            }

            // 매도 시 매입금액 감소
            SinHanmeeipprice -= SinHanmaeipdan * SinHanweekValue;

            // 이전 보유수량 - 새로운 주식 수량
            SinHanweekValue -= SinHanmaeipdan;

            // 매도한 주식의 평균단가를 계산
            if (SinHanweekValue > 0)
            {
                SinHanmaeipdan = SinHanmeeipprice / SinHanweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                SinHanmaeipdan = 0;
            }

            SinHanmeusprice.text = SinHanweekValue.ToString("N0") + " 주";
            SinHanpnl.text = SinHanmeeipprice.ToString("N0") + " 원";
            SinHanmaeipdanp.text = SinHanmaeipdan.ToString("N0") + " 원";

            // 변수들을 모두 초기화
            SinHanInitializeVariables();
        }
        else if (SinHanweek < SinHanweekValue)
        {
            // 매도 시 매입금액 감소
            SinHanmeeipprice -= SinHanmaeipdan * indicator1Value;  // 여기를 수정

            // 이전 보유수량 - 새로운 주식 수량
            SinHanweekValue -= indicator1Value;

            // 매도한 주식의 평균단가를 계산
            if (SinHanweekValue > 0)
            {
                SinHanmaeipdan = SinHanmeeipprice / SinHanweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                SinHanmaeipdan = 0;
            }

            SinHanmeusprice.text = SinHanweekValue.ToString("N0") + " 주";
            SinHanpnl.text = SinHanmeeipprice.ToString("N0") + " 원";
            SinHanmaeipdanp.text = SinHanmaeipdan.ToString("N0") + " 원";
        }
    }
    // 변수들을 초기화하는 메소드
    private void SinHanInitializeVariables()
    {
        SinHanweekValue = 0;
        SinHanmeeipprice = 0;
        SinHanpyungdan = 0;
        SinHanpyungson = 0;
        SinHansuic = 0.0f;
    }
    public void SinHanPNL(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            SinHanweekValue += indicator1Value;
            SinHanmeeipprice += indicator2Value;
            SinHanmeusprice.text = SinHanweekValue.ToString("N0") + " 주";
            SinHanpnl.text = SinHanmeeipprice.ToString("N0") + " 원";

            SinHanmaeipdan = SinHanmeeipprice / SinHanweekValue;
            SinHanmaeipdanp.text = SinHanmaeipdan.ToString("N0") + " 원";
        }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    public void saveSinHan(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            SinHanweekValue += indicator1Value;
            SinHanmeeipprice += indicator2Value * SinHanweekValue;
            SinHanmeusprice.text = SinHanweekValue.ToString("N0") + " 주";
            SinHanpnl.text = SinHanmeeipprice.ToString("N0") + " 원";

            SinHanmaeipdan = SinHanmeeipprice / SinHanweekValue;
            SinHanmaeipdanp.text = SinHanmaeipdan.ToString("N0") + " 원";
        }
    }
    public void SaveSinHanPNL(long quantityheld, long purchaseprice)
    {
        string indicator1Text = quantityheld.ToString();
        string indicator2Text = purchaseprice.ToString();
        saveSinHan(indicator1Text, indicator2Text);
        Invoke("DelayedSinHanPNL", 7);
    }
    private void DelayedSinHanPNL()
    {
        SHanPNL("start");
        MedoMaEip("start");
    }
    public void SHanPNL(string indicatorText)
    {
        string SinHannowP = SinHannowprice.text;
        SinHannowP = SinHannowP.Replace(",", "");
            if (int.TryParse(SinHannowP, out int SinHannowPriceValue))
            {
                SinHanpyungdan = SinHannowPriceValue;
                SinHanmanipdan.text = SinHanpyungdan.ToString("N0") + " 원";
                SinHannowPriceValue = SinHanpyungdan * SinHanweekValue;
                SinHanpyungson = SinHannowPriceValue - SinHanmeeipprice;
                SinHansuic = (float)SinHanpyungson / SinHanmeeipprice * 100;
                SinHansuic = Mathf.Round(SinHansuic * 100) / 100; // 0.1654 -> 16.54
                SinHanpyung.text = SinHannowPriceValue.ToString("N0") + " 원";
                SinHanpyungsunic.text = SinHanpyungson.ToString("N0") + " 원 ";
                SinHansuicrul.text = SinHansuic.ToString("N2") + " % ";
            }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    //=======================================================================
    //=============================LGJun===========================
    public void MedoLGJunPNL(string LGJunVariable, string indicatorText, string indicator1Text, int weekValuee)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");

        int LGJunweek = 0;
        int price = 0;

        Debug.Log(LGJunVariable + "매도 시작했다잉!!");

        if (int.TryParse(indicator1Text, out int indicator1Value))
        {
            LGJunweek = indicator1Value;
        }

        if (int.TryParse(indicatorText, out int indicatorValue))
        {
            price = indicatorValue;
        }

        if (LGJunweek == weekValuee)
        {
            Transform content = GameObject.Find("Canvas/HoldStock/ScrollView/Viewport/Content").transform;

            foreach (Transform child in content)
            {
                if (child.name == LGJunVariable)
                {
                    child.gameObject.SetActive(false);
                    Debug.Log("이름이 " + LGJunVariable + "인 오브젝트를 찾아 비활성화했습니다.");

                    GameObject medoLGJunClone = GameObject.Find("Medo-LGjun(Clone)");
                    if (medoLGJunClone != null)
                    {
                        medoLGJunClone.SetActive(false);
                    }
                }
            }

            // 매도 시 매입금액 감소
            LGJunmeeipprice -= LGJunmaeipdan * LGJunweekValue;

            // 이전 보유수량 - 새로운 주식 수량
            LGJunweekValue -= LGJunmaeipdan;

            // 매도한 주식의 평균단가를 계산
            if (LGJunweekValue > 0)
            {
                LGJunmaeipdan = LGJunmeeipprice / LGJunweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                LGJunmaeipdan = 0;
            }

            LGJunmeusprice.text = LGJunweekValue.ToString("N0") + " 주";
            LGJunpnl.text = LGJunmeeipprice.ToString("N0") + " 원";
            LGJunmaeipdanp.text = LGJunmaeipdan.ToString("N0") + " 원";

            // 변수들을 모두 초기화
            LGJunInitializeVariables();
        }
        else if (LGJunweek < LGJunweekValue)
        {
            // 매도 시 매입금액 감소
            LGJunmeeipprice -= LGJunmaeipdan * indicator1Value;  // 여기를 수정

            // 이전 보유수량 - 새로운 주식 수량
            LGJunweekValue -= indicator1Value;

            // 매도한 주식의 평균단가를 계산
            if (LGJunweekValue > 0)
            {
                LGJunmaeipdan = LGJunmeeipprice / LGJunweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                LGJunmaeipdan = 0;
            }

            LGJunmeusprice.text = LGJunweekValue.ToString("N0") + " 주";
            LGJunpnl.text = LGJunmeeipprice.ToString("N0") + " 원";
            LGJunmaeipdanp.text = LGJunmaeipdan.ToString("N0") + " 원";
        }
    }

    // 변수들을 초기화하는 메소드
    private void LGJunInitializeVariables()
    {
        LGJunweekValue = 0;
        LGJunmeeipprice = 0;
        LGJunpyungdan = 0;
        LGJunpyungson = 0;
        LGJunsuic = 0.0f;
    }
    public void LGJunPNL(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            LGJunweekValue += indicator1Value;
            LGJunmeeipprice += indicator2Value;
            LGJunmeusprice.text = LGJunweekValue.ToString("N0") + " 주";
            LGJunpnl.text = LGJunmeeipprice.ToString("N0") + " 원";

            LGJunmaeipdan = LGJunmeeipprice / LGJunweekValue;
            LGJunmaeipdanp.text = LGJunmaeipdan.ToString("N0") + " 원";
        }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    public void saveLGJun(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            LGJunweekValue += indicator1Value;
            LGJunmeeipprice += indicator2Value * LGJunweekValue;
            LGJunmeusprice.text = LGJunweekValue.ToString("N0") + " 주";
            LGJunpnl.text = LGJunmeeipprice.ToString("N0") + " 원";

            LGJunmaeipdan = LGJunmeeipprice / LGJunweekValue;
            LGJunmaeipdanp.text = LGJunmaeipdan.ToString("N0") + " 원";
        }
    }
    public void SaveLGJunPNL(long quantityheld, long purchaseprice)
    {
        string indicator1Text = quantityheld.ToString();
        string indicator2Text = purchaseprice.ToString();
        saveLGJun(indicator1Text, indicator2Text);
        Invoke("DelayedLGJunPNL", 7);
    }
    private void DelayedLGJunPNL()
    {
        LGJPNL("start");
        MedoMaEip("start");

    }
    public void LGJPNL(string indicatorText)
{

    string LGJunnowP = LGJunnowprice.text;
    LGJunnowP = LGJunnowP.Replace(",", "");

        if (int.TryParse(LGJunnowP, out int LGJunnowPriceValue))
        {
            LGJunpyungdan= LGJunnowPriceValue;
            LGJunmanipdan.text = LGJunpyungdan.ToString("N0") + " 원";
            LGJunnowPriceValue = LGJunpyungdan * LGJunweekValue;
            LGJunpyungson = LGJunnowPriceValue - LGJunmeeipprice;
            LGJunsuic = (float)LGJunpyungson / LGJunmeeipprice * 100;
            LGJunsuic = Mathf.Round(LGJunsuic * 100) / 100; // 0.1654 -> 16.54
            LGJunpyung.text = LGJunnowPriceValue.ToString("N0") + " 원";
            LGJunpyungsunic.text = LGJunpyungson.ToString("N0") + " 원 ";
            LGJunsuicrul.text = LGJunsuic.ToString("N2") + " % ";
        }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    //=======================================================================
    //=============================SamsungLife===========================
    public void MedoSamLPNL(string SamLVariable, string indicatorText, string indicator1Text, int weekValuee)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");

        int SamLweek = 0;
        int price = 0;

        Debug.Log(SamLVariable + "매도 시작했다잉!!");

        if (int.TryParse(indicator1Text, out int indicator1Value))
        {
            SamLweek = indicator1Value;
        }

        if (int.TryParse(indicatorText, out int indicatorValue))
        {
            price = indicatorValue;
        }

        if (SamLweek == weekValuee)
        {
            Transform content = GameObject.Find("Canvas/HoldStock/ScrollView/Viewport/Content").transform;

            foreach (Transform child in content)
            {
                if (child.name == SamLVariable)
                {
                    child.gameObject.SetActive(false);
                    Debug.Log("이름이 " + SamLVariable + "인 오브젝트를 찾아 비활성화했습니다.");

                    GameObject medoSamLClone = GameObject.Find("Medo-Samsunglife(Clone)");
                    if (medoSamLClone != null)
                    {
                        medoSamLClone.SetActive(false);
                    }
                }
            }

            // 매도 시 매입금액 감소
            SamLmeeipprice -= SamLmaeipdan * SamLweekValue;

            // 이전 보유수량 - 새로운 주식 수량
            SamLweekValue -= SamLmaeipdan;

            // 매도한 주식의 평균단가를 계산
            if (SamLweekValue > 0)
            {
                SamLmaeipdan = SamLmeeipprice / SamLweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                SamLmaeipdan = 0;
            }

            SamLmeusprice.text = SamLweekValue.ToString("N0") + " 주";
            SamLpnl.text = SamLmeeipprice.ToString("N0") + " 원";
            SamLmaeipdanp.text = SamLmaeipdan.ToString("N0") + " 원";

            // 변수들을 모두 초기화
            SamLInitializeVariables();
        }
        else if (SamLweek < SamLweekValue)
        {
            // 매도 시 매입금액 감소
            SamLmeeipprice -= SamLmaeipdan * indicator1Value;  // 여기를 수정

            // 이전 보유수량 - 새로운 주식 수량
            SamLweekValue -= indicator1Value;

            // 매도한 주식의 평균단가를 계산
            if (SamLweekValue > 0)
            {
                SamLmaeipdan = SamLmeeipprice / SamLweekValue;
            }
            else
            {
                // 보유 주식이 없을 때는 평균단가를 0으로 설정
                SamLmaeipdan = 0;
            }

            SamLmeusprice.text = SamLweekValue.ToString("N0") + " 주";
            SamLpnl.text = SamLmeeipprice.ToString("N0") + " 원";
            SamLmaeipdanp.text = SamLmaeipdan.ToString("N0") + " 원";
        }
    }
    // 변수들을 초기화하는 메소드
    private void SamLInitializeVariables()
    {
        SamLweekValue = 0;
        SamLmeeipprice = 0;
        SamLpyungdan = 0;
        SamLpyungson = 0;
        SamLsuic = 0.0f;
    }
    public void SamLifePNL(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            SamLweekValue += indicator1Value;
            SamLmeeipprice += indicator2Value;
            SamLmeusprice.text = SamLweekValue.ToString("N0") + " 주";
            SamLpnl.text = SamLmeeipprice.ToString("N0") + " 원";

            SamLmaeipdan = SamLmeeipprice / SamLweekValue;
            SamLmaeipdanp.text = SamLmaeipdan.ToString("N0") + " 원";
        }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    public void saveSamLife(string indicator1Text, string indicator2Text)
    {
        indicator1Text = indicator1Text.Replace(" ", "");
        indicator1Text = indicator1Text.Replace("주", "");
        indicator2Text = indicator2Text.Replace(" ", "");
        indicator2Text = indicator2Text.Replace("원", "");
        if (int.TryParse(indicator1Text, out int indicator1Value) && int.TryParse(indicator2Text, out int indicator2Value))
        {
            SamLweekValue += indicator1Value;
            SamLmeeipprice += indicator2Value * SamLweekValue;
            SamLmeusprice.text = SamLweekValue.ToString("N0") + " 주";
            SamLpnl.text = SamLmeeipprice.ToString("N0") + " 원";

            SamLmaeipdan = SamLmeeipprice / SamLweekValue;
            SamLmaeipdanp.text = SamLmaeipdan.ToString("N0") + " 원";
        }
    }
    public void SaveSamLifePNL(long quantityheld, long purchaseprice)
    {
        string indicator1Text = quantityheld.ToString();
        string indicator2Text = purchaseprice.ToString();
        saveSamLife(indicator1Text, indicator2Text);
        Invoke("DelayedSamLifePNL", 7);
    }
    private void DelayedSamLifePNL()
    {
        SamLPNL("start");
        MedoMaEip("start");

    }
    public void SamLPNL(string indicatorText)
    {
        string SamLnowP = SamLnowprice.text;
        SamLnowP = SamLnowP.Replace(",", "");

            if (int.TryParse(SamLnowP, out int SamLnowPriceValue))
            {
                SamLpyungdan = SamLnowPriceValue;
                SamLmanipdan.text = SamLnowPriceValue.ToString("N0") + " 원";
                SamLnowPriceValue = SamLpyungdan * SamLweekValue;
                SamLpyungson = SamLnowPriceValue - SamLmeeipprice;
                SamLsuic = (float)SamLpyungson / SamLmeeipprice * 100;
                SamLsuic = Mathf.Round(SamLsuic * 100) / 100; // 0.1654 -> 16.54
                SamLpyung.text = SamLnowPriceValue.ToString("N0") + " 원";
                SamLpyungsunic.text = SamLpyungson.ToString("N0") + " 원 ";
                SamLsuicrul.text = SamLsuic.ToString("N2") + " % ";
            }
        //총매입금액 ===================================
        MaEipValue = 0;
        MaEipValue = meeipprice + ecomeeipprice + lgemeeipprice + skhmeeipprice + SamBiomeeipprice +
            PoscHmeeipprice + HyunDmeeipprice + LSmeeipprice + SSDImeeipprice + KIAmeeipprice +
            NVmeeipprice + PFmeeipprice + KBmeeipprice + HDMmeeipprice + STmeeipprice +
            SamMmeeipprice + KKOmeeipprice + SinHanmeeipprice + LGJunmeeipprice + SamLmeeipprice;

        MaEipPrice.text = MaEipValue.ToString("N0") + " 원 ";

        //총 현금
        cash = 50000000;
        cash -= MaEipValue;
        cashText.text = cash.ToString("N0") + "  원";
    }
    //=======================================================================
}