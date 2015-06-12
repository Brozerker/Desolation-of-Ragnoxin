using UnityEngine;
using System.Collections;

public class enemyController : MonoBehaviour {
    public float distance;
    public float speed;
    public float attackPower;
    public float attackDelay = 0.7f;
    //private float startTimer;
    private Vector3 startPos;
    private Animator animator;
    public static bool facingLeft;
    public static bool attacking;
    private GameObject gameObject;
    private GameObject player;
    public enum UseCase { wander, seek, flee }
    public UseCase useCase;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        facingLeft = true;
        startPos = transform.position;
        attacking = false;
    }

    // Update is called once per frame
    void Update() {
        if (attacking) {
            Attack();
            //startTimer = 0;
            //if ((Time.deltaTime % waitTime) < 1) {
            //}
        }
        else {
            if (Mathf.Abs(transform.position.x - player.transform.position.x) < 1)  {
                useCase = UseCase.seek;
            }
            updateMovement();
        }
    }

    IEnumerator Attack() {
        animator.SetTrigger("attack");
        Debug.Log("attack");
        // player health -= attackPower;
        yield return new WaitForSeconds(attackDelay);
    }

    void updateMovement() {
        switch (useCase) {
            case enemyController.UseCase.wander:
                Debug.Log("wander");
                if (transform.position.x < startPos.x || transform.position.x > (startPos.x + distance)) {
                    facingLeft = !facingLeft;
                    animator.SetBool("moveLeft", !(animator.GetBool("moveLeft")));
                    speed *= -1;
                }
                break;
            case enemyController.UseCase.seek:
                Debug.Log("seek");
                break;
            case enemyController.UseCase.flee:
                break;
        }
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, 0.0f);
    }
}

