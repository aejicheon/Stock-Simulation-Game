using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button_con : MonoBehaviour
{
    public Image dotPrefabImage;


    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;
    public Button button7;
    public Button button8;
    public Button button9;
    public Button button10;
    public Button button11;
    public Button button12;
    public Button button13;
    public Button button14;
    public Button button15;
    public Button button16;
    public Button button17;
    public Button button18;
    public Button button19;
    public Button button20;



    private samsung samsungScript;
    private ecopro echoScript;
    private lg_energysolution lg_energysolutionScript;
    private sk_hynix sk_hynixScript;
    private samsung_biologics samsung_biologicsScript;//
    private posco_holding posco_holdingScript;
    private hyundai_car hyundai_carScript;
    private ls_chemical ls_chemicalScript;
    private samsung_sdi samsung_sdiScript;
    private kia kiaScript;//
    private naver naverScript;
    private posco_futurem posco_futuremScript;
    private kb_finance kb_financeScript;
    private hyundai_mobis hyundai_mobisScript;
    private celltrion celltrionScript;
    private samsung_corporation samsung_corporationScript;
    private kakao kakaoScript;
    private shinhan_jiju shinhan_jijuScript;
    private lg_electronics lg_electronicsScript;
    private samsung_life samsung_lifeScript;



    private MonoBehaviour activeScript;
    // Start is called before the first frame update
    void Start()
    {
        samsungScript = Camera.main.GetComponent<samsung>();
        echoScript = Camera.main.GetComponent<ecopro>();
        lg_energysolutionScript = Camera.main.GetComponent<lg_energysolution>();
        sk_hynixScript = Camera.main.GetComponent<sk_hynix>();
        samsung_biologicsScript = Camera.main.GetComponent<samsung_biologics>();
        posco_holdingScript = Camera.main.GetComponent<posco_holding>();
        hyundai_carScript = Camera.main.GetComponent<hyundai_car>();
        ls_chemicalScript = Camera.main.GetComponent<ls_chemical>();
        samsung_sdiScript = Camera.main.GetComponent<samsung_sdi>();
        kiaScript = Camera.main.GetComponent<kia>();
        naverScript = Camera.main.GetComponent<naver>();
        posco_futuremScript = Camera.main.GetComponent<posco_futurem>();
        kb_financeScript = Camera.main.GetComponent<kb_finance>();
        hyundai_mobisScript = Camera.main.GetComponent<hyundai_mobis>();
        celltrionScript = Camera.main.GetComponent<celltrion>();
        samsung_corporationScript = Camera.main.GetComponent<samsung_corporation>();
        kakaoScript = Camera.main.GetComponent<kakao>();  // Make sure this is correct, as it's repeated from the previous assignments
        shinhan_jijuScript = Camera.main.GetComponent<shinhan_jiju>();
        lg_electronicsScript = Camera.main.GetComponent<lg_electronics>();
        samsung_lifeScript = Camera.main.GetComponent<samsung_life>();

        button1.onClick.AddListener(() => ActivateScript(samsungScript));
        button2.onClick.AddListener(() => ActivateScript(echoScript));
        button3.onClick.AddListener(() => ActivateScript(lg_energysolutionScript));
        button4.onClick.AddListener(() => ActivateScript(sk_hynixScript));
        button5.onClick.AddListener(() => ActivateScript(samsung_biologicsScript));
        button6.onClick.AddListener(() => ActivateScript(posco_holdingScript));
        button7.onClick.AddListener(() => ActivateScript(hyundai_carScript));
        button8.onClick.AddListener(() => ActivateScript(ls_chemicalScript));
        button9.onClick.AddListener(() => ActivateScript(samsung_sdiScript));
        button10.onClick.AddListener(() => ActivateScript(kiaScript));
        button11.onClick.AddListener(() => ActivateScript(naverScript));
        button12.onClick.AddListener(() => ActivateScript(posco_futuremScript));
        button13.onClick.AddListener(() => ActivateScript(kb_financeScript));
        button14.onClick.AddListener(() => ActivateScript(hyundai_mobisScript));
        button15.onClick.AddListener(() => ActivateScript(celltrionScript));
        button16.onClick.AddListener(() => ActivateScript(samsung_corporationScript));
        button17.onClick.AddListener(() => ActivateScript(kakaoScript));
        button18.onClick.AddListener(() => ActivateScript(shinhan_jijuScript));
        button19.onClick.AddListener(() => ActivateScript(lg_electronicsScript));
        button20.onClick.AddListener(() => ActivateScript(samsung_lifeScript));

    }
    void ActivateScript(MonoBehaviour script)
    {
        // 현재 실행 중인 스크립트를 비활성화
        DeactivateActiveScript();

        // 선택한 스크립트가 현재 실행 중인 스크립트와 같지 않은 경우에만 활성화
        if (script != activeScript)
        {
            script.enabled = true;

            // 현재 실행 중인 스크립트를 저장
            activeScript = script;
        }
        else
        {
            // 선택한 스크립트가 이미 활성화되어 있으면 null로 초기화
            activeScript = null;
        }
    }

    void DeactivateActiveScript()
    {
        // 현재 실행 중인 스크립트를 비활성화
        if (activeScript != null && activeScript.enabled)
        {
            activeScript.enabled = false;

        }
    }

}