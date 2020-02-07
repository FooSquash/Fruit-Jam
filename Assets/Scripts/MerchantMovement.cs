using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantMovement : MonoBehaviour {

    public float moveSpeed;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;

    private Rigidbody2D myRigidbody;

    private bool isWalking;

    public float walkTime;
    private float walkTimeCounter;
    public float waitTime;
    private float waitTimeCounter;

    private int walkDirection;

    public Collider2D walkZone;
    private bool hasWalkZone;

    public bool canMove;
    private DialogueManager dialogueManager;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        dialogueManager = FindObjectOfType<DialogueManager>();

        waitTimeCounter = waitTime;
        walkTimeCounter = walkTime;

        ChooseDirection();

        if (walkZone != null) {
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            hasWalkZone = true;
        }

        canMove = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (dialogueManager.dialogueActive) {
            canMove = true;
        }

        if (!canMove) {
            myRigidbody.velocity = Vector2.zero;
            return;
        }

		if (isWalking) {
            walkTimeCounter -= Time.deltaTime;

            switch (walkDirection) {
                case 0:
                    myRigidbody.velocity = new Vector2(0, moveSpeed);
                    if (hasWalkZone && transform.position.y > maxWalkPoint.y) {
                        isWalking = false;
                        waitTimeCounter = waitTime;
                    }
                    break;
                case 1:
                    myRigidbody.velocity = new Vector2(moveSpeed, 0);
                    if (hasWalkZone && transform.position.x > maxWalkPoint.x) {
                        isWalking = false;
                        waitTimeCounter = waitTime;
                    }
                    break;
                case 2:
                    myRigidbody.velocity = new Vector2(0, -moveSpeed);
                    if (hasWalkZone && transform.position.y < minWalkPoint.y) {
                        isWalking = false;
                        waitTimeCounter = waitTime;
                    }
                    break;
                case 3:
                    if (hasWalkZone && transform.position.x < minWalkPoint.x) {
                        isWalking = false;
                        waitTimeCounter = waitTime;
                    }
                    myRigidbody.velocity = new Vector2(-moveSpeed, 0);
                    break;
            }

            if (walkTimeCounter < 0) {
                isWalking = false;
                waitTimeCounter = waitTime;
            }
        }
        else {
            waitTimeCounter -= Time.deltaTime;

            myRigidbody.velocity = Vector2.zero;

            if (waitTimeCounter < 0) {
                ChooseDirection();
            }
        }
	}

    public void ChooseDirection() {
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkTimeCounter = walkTime;
    }
}
