using UnityEngine;
using System.Collections;

public class enemyController : MonoBehaviour {
    public float health;
    public float distance;
    public float speed;
    public float chaseSpeed;
    public float attackPower;
    private float attackDelay = 2.0f;
    private float attackTimer = 0.0f;
    private float seekRadius = 3.0f;

    private Vector3 startPos;
    private Animator animator;
    public static bool facingLeft;
    private bool attacking;
    private GameObject gameObject;
    private GameObject player;
    private enum UseCase { wander, seek, flee }
	private UseCase useCase;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        facingLeft = true;
        startPos = transform.position;
		attacking = false;
        useCase = UseCase.wander;
    }

    // Update is called once per frame
	void Update() {
        if (attacking) {
            if (attackTimer == 0.0f) {
                animator.SetTrigger("attack");
                Debug.Log("attack");
                // player health -= attackPower;
            }
            if (attackTimer < attackDelay)      attackTimer += Time.deltaTime;
            if (attackTimer >= attackDelay)     attackTimer = 0.0f;

        }
        else {
            if (useCase == UseCase.wander 
                && (Mathf.Abs(transform.position.x - player.transform.position.x) < seekRadius) 
                && Mathf.Abs(transform.position.y - player.transform.position.y) < 1f)  {
                useCase = UseCase.seek;
            }
			updateMovement();
        }
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
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, 0.0f);
                break;
            case enemyController.UseCase.seek:
                RaycastHit2D leftHit = Physics2D.Raycast(transform.position, -Vector2.right);
                RaycastHit2D rightHit = Physics2D.Raycast(transform.position, Vector2.right);

                if(leftHit.collider != null) {
                    if(leftHit.collider.name == "Player");
                    Debug.Log("to the lerft");
                    facingLeft = true;
                    speed *= -1;
                    //chaseSpeed *= -1;
                }

                if(rightHit.collider != null) {
                    if(rightHit.collider.name == "Player");
                    Debug.Log("to the right");
                    facingLeft = false;
                    speed = Mathf.Abs(speed);
                    //chaseSpeed = Mathf.Abs(chaseSpeed);
                }               

                //if player is to the left, move left
                //int offset = 50; //offset to make sure the numbers start positive and the same distance apart
                //if ((player.transform.position.x + offset) - (transform.position.x + offset) < 0) {
                    
                //}

                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, 0.0f);
                //Debug.Log("seek");
                break;
            case enemyController.UseCase.flee:
                break;
        }
    }
    void Attack() {
        attacking = true;
        //yield return new WaitForSeconds(attackDelay);
    }
    void ceaseAttack() {
        Debug.Log("ceasing");
        attacking = false;
        attackTimer = 0.0f;
    }
    bool facing() {
        return facingLeft;
    }
    void faceDirection(bool value) {
        facingLeft = value;
    }
    void turnAround() {
        facingLeft = !facingLeft;
    }
}

