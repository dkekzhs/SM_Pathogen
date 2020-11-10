using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "FinalScene/Sources")]
public class EncyclopediaScriptableObject : ScriptableObject
{
    [Header("잠금 해제 되었는지 확인하는 변수")]
    public bool isOpen;
    [Header("잠금 이미지")]
    public Sprite lockImage;
    [Header("잠금 해제 이미지")]
    public Sprite openImage;
}
