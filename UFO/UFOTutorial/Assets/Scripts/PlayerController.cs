using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public Text liveText;

    private Rigidbody2D rb2d;
    private int count;
    private int lives;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        SetCountText();
        lives = 3;
        liveText.text = "";
        SetLiveText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
            if (other.gameObject.CompareTag("Pickup"))
            {
                other.gameObject.SetActive(false);
                count = count + 1;
                SetCountText();
             }
            else if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.SetActive(false);
                lives = lives - 1;
                SetLiveText();
             }
    }
    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
        if (count == 12)
            {
                transform.position = new Vector2(87.5f, 0.0f); 
            }
        if (count >= 20)
        {
            winText.text = "You win! Game created by Samantha Sander!";
        }
    }
    void SetLiveText()
    {
        liveText.text = "Lives: " + lives.ToString();
        if (lives == 0)
        {
            Destroy(this);
            winText.text = "You lose!";
        }
    }
}
