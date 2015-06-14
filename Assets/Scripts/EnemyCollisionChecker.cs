using UnityEngine;
using System.Collections;


public class EnemyCollisionChecker : enemyController {
    public GameObject parent;
    private BoxCollider2D attackArea;
    private int offset;

	void Start () {
        //make a new box collider that's the size of parent objects (the enemy) current one
        attackArea = GetComponent<BoxCollider2D>();
        Vector2 newSize = new Vector2(parent.GetComponent<BoxCollider2D>().size.x * 3/4, parent.GetComponent<BoxCollider2D>().size.y);
        
        //offset is used to make sure the new collider is facing in front of the object
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
        Debug.Log("thing!");
        // if enemy runs in to a wall, turn around
        if (other.gameObject.tag == "Obstacle") {
            facingLeft = !facingLeft;
        }

        // if player enters collider, start attacking
        if (other.gameObject.tag == "Player") {
            Debug.Log("player!");
            //attacking = true;
            parent.gameObject.SendMessage("Attack");

			// decrease player health
			PlayerController.health--;
			if(PlayerController.health <= 0) {
				//player has died
				PlayerController.lives--;
				if(PlayerController.lives <= 0) {
					// gameover
					// todo: load gameover screen instead of first level
					Application.LoadLevel("Level1");
				} else {
					// not a gameover - restart level
					// todo: add death sound
					Application.LoadLevel(Application.loadedLevel);
				}
			}
        }
    }

    //if player leaves collider, stop attacking
    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            Debug.Log("kbye");
            parent.gameObject.SendMessage("ceaseAttack");
            //attacking = false;
        }
    }
}
