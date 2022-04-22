    public void Play_Time(GameManager_Play gameManager_Play, Player player_script)
    {
        gameManager_Play.minimap.value = gameManager_Play.fPlay_Time / Setting.fRunning_Time;
        gameManager_Play.distance.text = Mathf.Round(gameManager_Play.fPlay_Time / Setting.fRunning_Time * 100) + "";

        //가속도 게이지 표시.
        gameManager_Play.accel_Gauge_1.fillAmount = gameManager_Play.fAcceleration / gameManager_Play.fAcceleration_Max_1;
        gameManager_Play.accel_Gauge_2.fillAmount = (gameManager_Play.fAcceleration - gameManager_Play.fAcceleration_Max_1) / gameManager_Play.fAcceleration_Max_2;

        if (player_script.nRun_Stop > 0)
        {
            if (gameManager_Play.fPlay_Time < Setting.fRunning_Time)
            {
                gameManager_Play.fPlay_Time += (Time.deltaTime * gameManager_Play.fAdd_Time_Per_Speed) + 0.1f * gameManager_Play.nPlayer_Speed_lv * Time.deltaTime;      //걷는 거리 증가
                gameManager_Play.fInstance_Shell += (Time.deltaTime * gameManager_Play.fAdd_Time_Per_Speed) + 0.1f * gameManager_Play.nPlayer_Speed_lv * Time.deltaTime;
                if (player_script.nRun_Stop == 1)
                    gameManager_Play.fAcceleration += Time.deltaTime;   //가속 증가

                if (gameManager_Play.fPlay_Time > (Setting.fRunning_Time - 5))
                    gameManager_Play.stop_Enemy = true;


                if ((gameManager_Play.fPlay_Time > Setting.fRunning_Time))
                {
                    player_script.anim_Player.SetTrigger(gameManager_Play.nStage_Num < 20 ? "End_Theme" : "End_Game");
                }
            }

            if(gameManager_Play.fInstance_Shell > Setting.fOnly_Fall_Start_Time)
            {
                gameManager_Play.nFall_Rate = 101;
            }

            if (gameManager_Play.fInstance_Shell > Setting.finstantiate_Shell_Time)
            {
                Instantiate(gameManager_Play.next_Stage); //새로운 껍데기 생성.
                gameManager_Play.fInstance_Shell = 0;
                gameManager_Play.nFall_Rate = gameManager_Play.nStage_Num + Setting.fFal_Rate_Basic; //낙하형적 비율 상승.
            }

            if (gameManager_Play.fAcceleration > 5.5 - (gameManager_Play.nAcceleration_Time_lv_1 * 0.5f))
            {
                gameManager_Play.fBackGround_Speed = 2;
                gameManager_Play.fAdd_Time_Per_Speed = 1.5f;

                if (gameManager_Play.fAcceleration > 11 - (gameManager_Play.nAcceleration_Time_lv_1 * 0.5f) - (gameManager_Play.nAcceleration_Time_lv_2 * 0.5f))
                {
                    gameManager_Play.fBackGround_Speed = 3;
                    gameManager_Play.fAdd_Time_Per_Speed = 2;
                }
            }
        }

        else
        {
            gameManager_Play.fAcceleration = 0;
            gameManager_Play.fBackGround_Speed = 1;
            gameManager_Play.fAdd_Time_Per_Speed = 1;
        }


        //껍데기 시간감소
        if (gameManager_Play.fShell_Time > 0 && !player_script.bDont_Reduce_Shell_Time)
        {
            if (!gameManager_Play.isEnd_Theme_Start)
                gameManager_Play.fShell_Time -= Time.deltaTime;
            else//테마 바뀔 때 껍데기 잔여시간 빨리 줄게 함.
                gameManager_Play.fShell_Time -= (player_script.fTemp_Shell_Time / 3) * Time.deltaTime;

            //껍데기 체력바 표시.
            gameManager_Play.healthBar.fillAmount = gameManager_Play.fShell_Time / gameManager_Play.fShell_Time_Max;

            if (gameManager_Play.fShell_Time / gameManager_Play.fShell_Time_Max < 0.2f)
            {
                if (!gameManager_Play.isCrack)
                {
                    gameManager_Play.anim_Health_Bar.SetBool("Health_Bar_Shake", true);
                    gameManager_Play.effect_Crack_Shell.Play();
                    gameManager_Play.isCrack = true;
                    //gameManager_Play.musicCtrl.effectMusic_[Setting.nShaking_Shell_Sound].Play();
                }
            }
        }

        if (gameManager_Play.fShell_Time < 0)
        {
            gameManager_Play.shell.SetActive(false);
            gameManager_Play.fShell_Time = 0.0f;

            gameManager_Play.anim_Health_Bar.SetBool("Health_Bar_Shake", false);
            gameManager_Play.effect_Break_Shell.Play();
            gameManager_Play.effect_Crack_Shell.Stop();
            gameManager_Play.isCrack = false;

            gameManager_Play.musicCtrl.effectMusic_[Setting.nDestroy_Shell_Sound].Play();
            //gameManager_Play.musicCtrl.effectMusic_[Setting.nShaking_Shell_Sound].Stop();
        }
    }
