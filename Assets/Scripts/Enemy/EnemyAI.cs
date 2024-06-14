using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent AI;
    public List<Transform> destinations;
    public Animator aiAnimation;
    public float walkSpeed, chaseSpeed, minIdleTime, maxIdleTime, idleTime, sightDistance, catchDistance, chaseTime, minChaseTime, maxChaseTime, jumpscareTime;
    public bool IsWalking, IsChasing;
    public Transform player;
    Transform currentDest;
    Vector3 destination;
    public int destinationAmount;
    int randNum;
    public Vector3 raycastOffset;
    public string deathScene;

    [SerializeField]
    private LayerMask mask;

    public Vector3 direction;

    public AudioSource scary;

    void Start()
    {
        IsWalking = true;
        randNum = Random.Range(0, destinationAmount);
        currentDest = destinations[randNum];
    }

    private void Update()
    {
        direction = (player.position - transform.position).normalized;

        //direction.y = .025f;

        Ray ray = new Ray(transform.position, direction);
        Debug.DrawRay(ray.origin, ray.direction * sightDistance, Color.red);
        
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, sightDistance))
        {
            Debug.Log(hitInfo.collider.gameObject.tag);

            if (hitInfo.collider.tag == "Player")
            {
                Debug.Log("START CHASE");
                IsWalking = false;

                StopCoroutine("stayIdle");
                StopCoroutine("chaseRoutine");
                StartCoroutine("chaseRoutine");

                aiAnimation.ResetTrigger("walk");
                aiAnimation.ResetTrigger("idle");
                aiAnimation.SetTrigger("sprint");                

                IsChasing = true;
            }                            
           
        }

        if (IsChasing)
        {
            destination = player.position;

            AI.destination = destination;
            AI.speed = chaseSpeed;

            aiAnimation.ResetTrigger("walk");
            aiAnimation.ResetTrigger("idle");
            aiAnimation.SetTrigger("sprint");

            if (AI.remainingDistance <= catchDistance)
            {
                player.gameObject.SetActive(false);

                aiAnimation.ResetTrigger("walk");
                aiAnimation.ResetTrigger("idle");

                aiAnimation.ResetTrigger("sprint");
                aiAnimation.SetTrigger("jumpscare");

                scary.Play();

                StartCoroutine(deathRoutine());

                IsChasing = false;
            }
        }

        if (IsWalking)
        {
            destination = currentDest.position;
            AI.destination = destination;
            AI.speed = walkSpeed;

            aiAnimation.ResetTrigger("sprint");
            aiAnimation.ResetTrigger("idle");

            aiAnimation.SetTrigger("walk");

            if (AI.remainingDistance <= AI.stoppingDistance)
            {
                aiAnimation.ResetTrigger("sprint");
                aiAnimation.ResetTrigger("walk");
                aiAnimation.SetTrigger("idle");

                AI.speed = 0;

                StopCoroutine("stayIdle");
                StartCoroutine("stayIdle");

                IsWalking = false;
            }
        }
    }

    public void stopChase()
    {
        IsWalking = true;
        IsChasing = false;

        StopCoroutine("chaseRoutine");

        randNum = Random.Range(0, destinationAmount);
        currentDest = destinations[randNum];
    }

    IEnumerator stayIdle()
    {
        idleTime = (int) Random.Range(minIdleTime, maxIdleTime);        

        yield return new WaitForSeconds(idleTime);

        IsWalking = true;

        randNum = Random.Range(0, destinationAmount);
        currentDest = destinations[randNum];       
    }

    IEnumerator chaseRoutine()
    {
        chaseTime = Random.Range(minChaseTime, maxChaseTime);

        yield return new WaitForSeconds(chaseTime);

        stopChase();
    }

    IEnumerator deathRoutine()
    {
        yield return new WaitForSeconds(jumpscareTime);

        SceneManager.LoadScene(deathScene);
    }
}
