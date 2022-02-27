using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public PlayerController player;
    public Animator cakeAnimation,playerAnimation;


    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag == "Player")
        {
            //transition
            if(cakeAnimation != null)
            {
                player.gameObject.SetActive(false);
                cakeAnimation.SetBool("end", true);
                playerAnimation.SetBool("end", true);
                StartCoroutine(loadScene());
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }

        }
    }

    private IEnumerator loadScene()
    {
        yield return new WaitForSeconds(1.75f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
