using UnityEngine;
using System.Collections;

public class enemyController : MonoBehaviour {
    public float distance;
    public float speed;
    public float attackPower;
    private Vector3 startPos;
    private Animator animator;
    private float waitTime;
    private bool facingLeft;
    public GameObject player;
    public enum UseCase { wander, seek, flee }
    public UseCase useCase;
    public BoxCollider2D attackArea;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        waitTime = 0.7f;
        animator = GetComponent<Animator>();
        startPos = transform.position;

        attackArea = GameObject.Instantiate(new BoxCollider2D());
        float newX = GetComponent<BoxCollider2D>().size.x / 2;
        Vector2 newSize = new Vector2(GetComponent<BoxCollider2D>().size.x / 2, 0.0f);

        int offset = 1;
        if (facingLeft) offset = -1;
        Vector2 newOffset = new Vector2(attackArea.size.x * offset, 0.0f);

        attackArea.size = newSize;
        attackArea.offset = newOffset;
    }

    // Update is called once per frame
    void Update() {
        if (player.transform.position.x - transform.position.x < 1) useCase = UseCase.seek; 
        updateMovement();
    }

    void updateMovement() {
        switch (useCase) {
            case enemyController.UseCase.wander:
                if (transform.position.x < startPos.x || transform.position.x > (startPos.x + distance)) {
                    animator.SetBool("moveLeft", !(animator.GetBool("moveLeft")));
                    speed *= -1;
                }
                break;
            case enemyController.UseCase.seek:

                break;
            case enemyController.UseCase.flee:
                break;
        }
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, 0.0f);
    }
}

