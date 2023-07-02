// 난이도 선택시 목숨 개수 설정하는 스크립트.
// 개발 잘 되면 난이도 선택에 따라 게임 난이도도 달라지게 하면 좋을듯.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class choiceDifficulty : MonoBehaviour, IPointerClickHandler
{
    public static int difficulty;
    // 클릭한 버튼의 name에 따라 목숨 개수 조정하는 함수.
    public void OnPointerClick(PointerEventData eventData)
    {
        string idx = eventData.pointerPress.name;
        if (idx=="easy"){
            difficulty = 100;
        } else if (idx=="basic"){
            difficulty=10;
        } else{
            difficulty=1;
        }
    }

}
