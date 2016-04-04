using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;    
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        this.count = 0;
        this.winText.text = "";
        setCountText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            this.count++;
            setCountText();
        }   
    }

    void setCountText()
    {
        countText.text = "Count: " + this.count.ToString();

        if (this.count >= 12)
        {
            this.winText.text = "You Win!";
        }
        


    }

}