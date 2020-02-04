using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
   public float speed= 10f;
    public Text countText;
    private Rigidbody rb;
    public GameObject effect;
    [SerializeField] private int score;

    private Collider PickUp;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        setCountText();
    }

    private void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalMovement, 0f, verticalMovement);
        rb.AddForce(movement * speed );
    
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            Instantiate(effect, other.transform.position, Quaternion.identity);
            score++;
            setCountText();
        }
    }

    void setCountText()
    {
        countText.text = "Score: " + score.ToString();
    }

}
	