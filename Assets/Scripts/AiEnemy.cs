using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiEnemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public int health;
    public Animator anim;
    public bool dying;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<playerMovement>().transform;
        agent = GetComponent<NavMeshAgent>();
        FindObjectOfType<Spawner>().numActiveEnemy++;
    }

    // Update is called once per frame
    void Update()
    {
        if (dying == false)
            agent.SetDestination(player.position);
        if(health <= 0 && dying == false)
        {
            StartCoroutine(Dying());
        }
        timer += Time.deltaTime;
    }

    IEnumerator Dying()
    {
        dying = true;
        agent.ResetPath();
        GetComponent<CapsuleCollider>().enabled = false;
        anim.SetBool("dying", true);
        FindObjectOfType<Spawner>().numActiveEnemy--;
        FindObjectOfType<playerStats>().money += 50;
        yield return new WaitForSeconds(30);
        Destroy(gameObject);
        //timer = 0;
        //while(timer < 10)
        //{
        //    transform.Translate(Vector3.down * Time.deltaTime);
        //}
        //Destroy(gameObject);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<bullet>())
        {
            health -= 1;
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.GetComponent<playerStats>())
        {
            collision.gameObject.GetComponent<playerStats>().health--;
        }
    }
}
