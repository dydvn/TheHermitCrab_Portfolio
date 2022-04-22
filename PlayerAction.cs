    //터치 입력시 플레이어 숨기&공격
    public void Player_Action(GameManager_Play gameManager_Play, Animator anim_Player, Player player)
    {
        int nTouchCount = Input.touchCount;
        int random;

        if (nTouchCount >= 1)
        {
            Vector2 pos = Input.GetTouch(0).position;
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                return;
            else if(gameManager_Play.isStarting)
            {
                //왼쪽 터치시 숨기
                if (pos.x < (gameManager_Play.nWidth * 0.5f))
                {
                    if (Input.GetTouch(0).phase.Equals(TouchPhase.Began))
                    {
                        anim_Player.SetBool("isHide", true);
                        gameManager_Play.delay_HC_1 = gameManager_Play.delay_Hide;
                        gameManager_Play.delay_HC_2 = -gameManager_Play.delay_Hide;
                    }

                    if (Input.GetTouch(0).phase.Equals(TouchPhase.Ended))
                    {
                        anim_Player.SetBool("isHide", false);
                        gameManager_Play.delay_HC_1 = gameManager_Play.delay_ComeOut;
                        gameManager_Play.delay_HC_2 = -gameManager_Play.delay_ComeOut;
                    }
                }
                //오른쪽 터치시 공격
                else
                {
                    if (Input.GetTouch(0).phase.Equals(TouchPhase.Began))
                    {
                        if (!player.isAttack)
                        {
                            gameManager_Play.musicCtrl.effectMusic_[Setting.nAttack_Sound].Play();  //공격소리
                            random = Random.Range(0, 3);
                            anim_Player.SetTrigger(random == 0 ? "Attack_0" : random == 1 ? "Attack_1" : "Attack_2");
                            StartCoroutine(Attack_Collider(gameManager_Play));
                        }
                    }
                }
            }
        }
    }

    //콜라이더 켜주자마자 꺼준다
    IEnumerator Attack_Collider(GameManager_Play gameManager_Play)
    {
        //업그레이드 수치에 따라 생성 포지션을 바꿔주면 된다.
        gameManager_Play.Col_Attack.enabled = true;
        yield return new WaitForSeconds(0.02f);
        gameManager_Play.Col_Attack.enabled = false;
    }
