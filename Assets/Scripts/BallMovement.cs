using System.Collections;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public float movementSpeed;

    public float extraSpeedPerHit;

    public float maxExtraSpeed;

    int hitCounter = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(this.StartBall());
    }

    void PositionBall(bool isStartingPlayer1)
    {
        this.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, 0);
        if(isStartingPlayer1)
        {
            this.gameObject.transform.localPosition = new Vector3(-100, 0, 0);
        }
        else
        {
            this.gameObject.transform.localPosition = new Vector3(100, 0, 0);
        }
    }

    public IEnumerator StartBall(bool isStratingPlayer1 = true)
    {
        this.PositionBall(isStratingPlayer1);
        this.hitCounter = 0;
        yield return new WaitForSeconds(2);
        if(isStratingPlayer1)
        {
            this.moveBall(new Vector2(-1, 0));
        }
        else
        {
            this.moveBall(new Vector2(1,0));
        }
    }

    public void moveBall(Vector2 dir)
    {
        dir = dir.normalized;

        float speed = this.movementSpeed + this.hitCounter * this.extraSpeedPerHit;

        Rigidbody2D rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();

        rigidbody2D.linearVelocity = dir * speed;
    }


    public void IncreaseHitCounter()
    {
        if (this.hitCounter * this.extraSpeedPerHit <= this.maxExtraSpeed)
        {
            this.hitCounter++;
        }
    }
}
