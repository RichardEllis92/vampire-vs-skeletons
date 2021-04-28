using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent pathfinder;
    Transform playerPos;
    Animator anim;
    public GameObject floatingText;

    public int enemyHealth = 100;
    void Start()
    {
        pathfinder = GetComponent<NavMeshAgent>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponentInChildren<Animator>();
        StartCoroutine(PathUpdate());
    }

    public void DamageDone()
    {
        var damageDone = Random.Range(25, 50);
        enemyHealth -= damageDone;
        FloatingText(damageDone);
        if (enemyHealth <= 0)
        {
            anim.SetBool("Dead", true);
            Destroy(gameObject, 0.5f);
        }
    }

    private void FloatingText(int damageDone)
    {
        var maxPos = Random.Range(-1.5f, 1.5f);
        var floatPosition = new Vector3(maxPos, maxPos, maxPos);
        var floater = Instantiate(floatingText, floatPosition, floatingText.transform.rotation, transform);
        floater.GetComponent<TextMeshPro>().text = damageDone.ToString();
    }

    IEnumerator PathUpdate()
    {
        float refreshRate = 0.25f;

        while (playerPos != null)
        {
            Vector3 targetPosition = new Vector3(playerPos.position.x, 0, playerPos.position.z);
            pathfinder.SetDestination(targetPosition);
            yield return new WaitForSeconds(refreshRate);
        }
        
    }
}
