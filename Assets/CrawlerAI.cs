using UnityEngine;
using System.Collections;

public class CrawlerAI : MonoBehaviour
{

    public enum CrawlerState
    {
        IDLE = 0,
        MOVING = 1,
        ATTACKING = 2,
    };

    public CrawlerState AIState;
    private Animator animator;
    private Rigidbody rb;
    private GameObject player;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        player = GameManager.Instance.goPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(player.transform);

        StateMachine();

    }

    void StateMachine()
    {
        switch (AIState)
        {
            case CrawlerState.IDLE:
                {
                    Idle();
                    break;
                }
            case CrawlerState.MOVING:
                {
                    Moving();
                    break;
                }
            case CrawlerState.ATTACKING:
                {
                    Idle();
                    break;
                }
        }
    }

    void CheckDistancePlayer()
    {
        float fDistance = Vector3.Distance(transform.position, player.transform.position);
        animator.SetFloat("fDistance", fDistance);

        if (fDistance < 10)
        {
            AIState = CrawlerState.MOVING;
        }
        else
        {
            AIState = CrawlerState.IDLE;
        }
    }

    void Idle()
    {
        CheckDistancePlayer();
    }

    void Moving()
    {
        CheckDistancePlayer();
        //transform.position = Vector3.Lerp(transform.position, player.transform.position, 10.0f * Time.deltaTime);
    }
}
