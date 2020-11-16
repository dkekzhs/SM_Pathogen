using UnityEngine;

[CreateAssetMenu(fileName = "New Virus", menuName = "VirusData/Sources")]
public class EncyclopediaScriptableObject : ScriptableObject //클래스 인스턴스와는 별도로 대량의 데이터를 저장하는데 사용할 수 있는 데이터 컨테이너
{
    [Header("잠금 해제 되었는지 확인하는 변수")]
    public bool isOpen;
    [Header("잠금 이미지")]
    public Sprite lockImage;
    [Header("잠금 해제 이미지")]
    public Sprite openImage;

    [Header("바이러스 종류 이름")]
    public string virusCategory;

    [Header("바이러스 이름")]
    public string virusName;
    [Header("바이러스 발병 위치")]
    public string virusTroubleLocation;
    [Header("바이러스 예방법")]
    public string virusPreventive;
    [Header("바이러스 정보")]
    public string virusInformation;
}
