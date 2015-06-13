using UnityEngine;
using System.Collections;


public class EnemyCollisionChecker : enemyController {
    public GameObject parent;
    private BoxCollider2D attackArea;
    private int offset;

	void Start () {
        attackArea = GetComponent<BoxCollider2D>();
        Vector2 newSize = new Vector2(parent.GetComponent<BoxCollider2D>().size.x * 3/4, parent.GetComponent<BoxCollider2D>().size.y);

        offset = 1;
        if (facingLeft) offset = -1;
        Vector2 newOffset = new Vector2(attackArea.size.x * offset, 0.0f);

        attackArea.size = newSize;
		attackArea.offset = newOffset;
	}

	void Update () {
        if (facingLeft) offset = -1;
        else offset = 1;

        Vector2 newOffset = new Vector2(attackArea.size.x * offset, 0.0f);
        attackArea.offset = newOffset;
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Obstacle") {
            facingLeft = !facingLeft;
        }

        if (other.gameObject.tag == "Player") {
            attacking = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            attacking = false;
        }
    }
}
