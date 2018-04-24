using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject player;
    public Player playerVariable;


    Animator anim;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerVariable = player.GetComponent<Player>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerVariable.health<= 0)
        {
            anim.SetTrigger("GameOver");
        }
    }
}
