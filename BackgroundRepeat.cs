using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgrounRepeat : MonoBehaviour
{
    public Player player;
    public GameManager_Play gameManager_Play;
    [Header("[레이어별로 빼주는 속도]")]
    public float speed;

    [Header("[높이]")]
    public float height;

    public GameObject testobject;

    private float wall_Size;

    private void Start()
    {
        wall_Size = GetComponent<SpriteRenderer>().sprite.bounds.size.x;
    }

    private void Update()
    {
        transform.Translate((gameManager_Play.move_Speed_Ground + new Vector3(speed * Time.deltaTime, 0, 0)) * player.nRun_Stop * gameManager_Play.nPause);

        if (transform.position.x < -(wall_Size * 4.0f))
            transform.position = new Vector3(testobject.transform.position.x + wall_Size * 3.95f, height, -0.1f);
    }
}
