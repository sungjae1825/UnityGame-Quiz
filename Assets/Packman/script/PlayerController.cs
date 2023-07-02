using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks; // Thread문 사용을 위한 using 문
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro; // TextMeshPro 바꾸기 위한 using 문
[System.Serializable]

public class PlayerController : MonoBehaviour
{
    public AudioClip monsterSE;
    public AudioClip itemSE;
    AudioSource aud;
    private LayerMask tileLayer;
    private float rayDistance = 0.55f;
    private Vector2 moveDirection = Vector2.right;
    private Movement2D movement2D;
    private Direction direction = Direction.Right;
    private AroundWrap aroundWrap;
    private SpriteRenderer spriteRenderer;
    private AudioSource itemAudioSource;
    public static int packmanLife = QuizManager.publicLife;
    
    

    private Text lifeLostTextUI;
    public TMP_Text lifeUI;
    private AudioSource audioSource;
    int itemcolider = 0;
    private void Start()
    {
        lifeLostTextUI.gameObject.SetActive(false);
        this.aud = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        tileLayer = 1<<LayerMask.NameToLayer("Tile");


        movement2D =  GetComponent<Movement2D>();
        aroundWrap = GetComponent<AroundWrap>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        lifeLostTextUI = GameObject.Find("Canvas/Text").GetComponent<Text>();
        
    }




    private void Update()
    {

        lifeUI.text = packmanLife.ToString();
        Debug.Log(lifeUI);
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveDirection = Vector2.up;
            direction = Direction.Up;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveDirection = Vector2.left;
            direction = Direction.Left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveDirection = Vector2.right;
            direction = Direction.Right;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveDirection = Vector2.down;
            direction = Direction.Down;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDirection, rayDistance, tileLayer);

        if( hit.transform == null )
        {
            bool movePossible = movement2D.MoveTo(moveDirection);
            if (movePossible)
            {
                transform.localEulerAngles = Vector3.forward * 90 * (int)direction;
            }
            aroundWrap.UpdateAroundWrap();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            this.aud.PlayOneShot(this.itemSE);
            itemcolider++;
            Destroy(collision.gameObject);
            if (itemcolider >= 20)
            {
                changeScene.ChangeScene("gameClear");
            }
        }
        else if (collision.CompareTag("Enemy"))
        {
            this.aud.PlayOneShot(this.monsterSE);
            StopCoroutine("OnHit");
            StartCoroutine("OnHit");
            Destroy(collision.gameObject);

            lifeLostTextUI.gameObject.SetActive(true);
            StartCoroutine(HideLifeLostText());

            //enemyCollisionCount++; // 아이템과 충돌 횟수 증가
          
            packmanLife--;
            if (packmanLife == 0)
            {
                changeScene.ChangeScene("gameOverP");
               
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }



    private IEnumerator OnHit()
    {
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        spriteRenderer.color = Color.white;
    }

    private IEnumerator HideLifeLostText()
    {
        yield return new WaitForSeconds(2f); 
        lifeLostTextUI.gameObject.SetActive(false);
                                    
    }

}
