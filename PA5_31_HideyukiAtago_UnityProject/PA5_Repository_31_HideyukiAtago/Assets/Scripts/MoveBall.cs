using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveBall : MonoBehaviour
{
    public float speed;
    private int CollectedCoins;
    private int CoinsPickedUp;
    private int NumberofCoins;

    Rigidbody Player;

    public Text DisplayCoinsCollected;

    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Rigidbody>();

        GameObject[] CoinsinScene = GameObject.FindGameObjectsWithTag("PickUp");
        NumberofCoins = CoinsinScene.Length;


    }

    // Update is called once per frame
    void Update()
    {
        DisplayCoinsCollected.text = CoinsPickedUp + "/" + NumberofCoins;
    }
    
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        Player.AddForce(movement * speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider Coins)
    {
        if (Coins.gameObject.tag == "PickUp")
        {
            Destroy(Coins.gameObject);

            CoinsPickedUp += 1;

            if (CoinsPickedUp >= NumberofCoins)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

        else if(Coins.gameObject.tag == "Hazard")
        {
            SceneManager.LoadScene("GameLose");
        }
    }
}
