using UnityEngine;
using UnityEngine.UI;

public class 설치유닛 : MonoBehaviour
{
    public 아군유닛 유닛데이터;
    public int 현재체력;

    [Header("HP바 프리팹")]
    public GameObject hpBar프리팹;

    private Slider hpSlider;
    private Transform hpBarTransform;

    public void 초기화(아군유닛 데이터)
    {
        유닛데이터 = 데이터;
        현재체력 = 유닛데이터.hp;

        // HP바 생성
        GameObject hpBarInstance = Instantiate(hpBar프리팹, transform);
        hpBarInstance.transform.localPosition = new Vector3(0, 1.5f, 0); // 유닛 위에 표시

        hpBarTransform = hpBarInstance.transform;
        hpSlider = hpBarInstance.GetComponentInChildren<Slider>();

        // 👉 Canvas 강제로 World Space로 전환
        Canvas canvas = hpBarInstance.GetComponent<Canvas>();
        if (canvas != null)
        {
            canvas.renderMode = RenderMode.WorldSpace;
            canvas.worldCamera = Camera.main; // 카메라 연결 (선택)
            canvas.sortingOrder = 6;
        }


        if (hpSlider != null)
        {
            hpSlider.maxValue = 유닛데이터.hp;
            hpSlider.value = 현재체력;
        }
    }

    public void 데미지입기(int 피해량)
    {
        현재체력 -= 피해량;
        if (현재체력 < 0) 현재체력 = 0;

        if (hpSlider != null)
        {
            hpSlider.value = 현재체력;
        }

        if (현재체력 <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // HP바가 항상 카메라를 바라보게 (선택 사항)
        if (hpBarTransform != null)
        {
            hpBarTransform.rotation = Camera.main.transform.rotation;
        }
    }
}
