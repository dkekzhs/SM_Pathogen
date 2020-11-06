using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBtnManager : MonoBehaviour
{
    GameObject player;
    PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LeftBtnDown()
    {
        playerMovement.LeftMove = true;
    }
    public void LeftBtnUp()
    {
        playerMovement.LeftMove = false;
    }
    public void RightBtnDown()
    {
        playerMovement.RightMove = true;
    }
    public void RighBtntUp()
    {
        playerMovement.RightMove = false;
    }
    public void BulletBtnUp()
    {
        playerMovement.BulletAtt = false;
    }
    public void BulletBtnDwon()
    {
        playerMovement.BulletAtt = true;
    }
}
