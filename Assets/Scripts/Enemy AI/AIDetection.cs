using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDetection : MonoBehaviour
{
    public float beta = 45;
    public float range = 15;
    public GameObject player;
    public Material enemyMaterial;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, transform.position + transform.forward * 25, Color.blue);

        Vector3 f = transform.forward;
        Vector3 p = player.transform.position - transform.position;

        float dot = f.x * p.x + f.y * p.y + f.z * p.z;
        //float dot = Vector3.Dot(p, f);
        /*if(dot > 0)
            Debug.DrawLine(transform.position, enemy.transform.position, Color.red);
        else
            Debug.DrawLine(transform.position, enemy.transform.position, Color.green);*/

        float alpha = Mathf.Acos(dot / (f.magnitude * p.magnitude)) * Mathf.Rad2Deg;
        //TODO: YOUR CODE HERE (Q1)
        Vector3 constance = transform.right;
        float dotConstanceP = Vector3.Dot(constance, p);
        int negPos = 1;
        if (dotConstanceP > 0)
        {
            negPos *= 1;
        }
        else if (dotConstanceP < 0)
        {
            negPos *= -1;
        }

        alpha *= negPos;

        Debug.Log(alpha);
        if (alpha > -beta && alpha < beta && p.magnitude < range)
        {
            Debug.DrawLine(transform.position, player.transform.position, Color.red);
            enemyMaterial.color = Color.blue;
        }
          
        else
        {
            Debug.DrawLine(transform.position, player.transform.position, Color.green);
            enemyMaterial.color = Color.red;
        }
            
        
        // Vector3 q = transform.right;
        Vector3 q = Vector3.Cross(transform.forward, transform.up);
        Vector3 proj = Vector3.Dot(p, q) / q.sqrMagnitude * q;
        Debug.DrawLine(transform.position, transform.position + proj, Color.red);
    }
}
