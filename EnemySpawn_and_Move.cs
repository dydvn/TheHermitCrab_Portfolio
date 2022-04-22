//start용
public void Spawn_Enemy(int nEnemy, Transform spawn_Position/*, GameObject gameObject*/)
{
    spawn_Position.position = Camera.main.ViewportToWorldPoint(new Vector3(1.0f, nEnemy == Setting.Enemy_Object_Fall ? 1.0f : 0.35f)) + new Vector3(2.0f, nEnemy == Setting.Enemy_Object_Fall ? 2.0f : 0.0f, 1.0f);
}
//update용(오브젝트 이동)
public void Move_Enemy(int nEnemy, Rigidbody2D rb2D, GameManager_Play gameManager_Play, Player player)
{
    if (gameManager_Play.nPause == 1)
    {
        if (nEnemy.Equals(Setting.Enemy_Object_Fall))
            rb2D.transform.Translate((gameManager_Play.move_Speed_Ground.x * 0.8f + gameManager_Play.move_Speed_Ground.x * 0.9f * player.nRun_Stop) * 0.9f, (gameManager_Play.move_Speed_Ground.x * 0.8f / gameManager_Play.fX_Y_Rate + gameManager_Play.move_Speed_Ground.x * 0.9f / gameManager_Play.fX_Y_Rate * player.nRun_Stop) * 0.9f, 0);
        else if (nEnemy.Equals(Setting.Enemy_Object_Ground))
            rb2D.transform.Translate((gameManager_Play.move_Speed_Ground * 0.8f + gameManager_Play.move_Speed_Ground * 0.9f * player.nRun_Stop) * 0.9f);    //move_Speed_Ground            
        else if (nEnemy.Equals(Setting.gold) || nEnemy.Equals(Setting.nextStage))
            rb2D.transform.Translate(gameManager_Play.move_Speed_Ground * player.nRun_Stop);
    }
}
