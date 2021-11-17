using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    //players default movespeed
    public float maxHealth;
    public float curHealth;
    public GameObject healthBar;
    //the health values as well as the haelth bar that will be displayed to the player
    public float maxStamina;
    public float curStamina;
    public GameObject staminaBar;
    //Stamina values and stamina bar
    public Transform respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement;
        movement.x = Input.GetAxisRaw("Vertical");
        movement.y = 0;
        movement.z = Input.GetAxisRaw("Horizontal");
        movement *= Time.deltaTime * speed;
        transform.Translate(movement);
    }
}
