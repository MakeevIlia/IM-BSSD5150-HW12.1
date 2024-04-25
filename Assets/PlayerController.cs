using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint;


    private float speed = 10f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
    }
    public void Reset()
    {
        gameObject.transform.position = spawnPoint.position;
        Text message = GameObject.FindGameObjectWithTag("Message").GetComponent<Text>();
        message.text = "";
    }
}


