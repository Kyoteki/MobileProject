using System.Collections.Generic;
using UnityEngine;

public class MouvementPlayer : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    private static int nbCaseMouv = 0;
    public static int NbCaseMouv { get => nbCaseMouv; private set => nbCaseMouv = value; }
    [SerializeField] private List<Vector3> pathList = new List<Vector3>();
    public List<Vector3> PathList { get => pathList; set => pathList = value; }
    private bool isMoving = false;
    private Vector3 nextPos;
    [SerializeField] private SpriteRenderer spriteRenderer;

    void Update()
    {
        // temporary to test movement
        if (Input.GetKeyDown(KeyCode.Space) && pathList.Count > 0)
        {
            isMoving = true;
        }

        if (isMoving)
        {
            Mouv();
        }
    }

    void Mouv()
    {
        float deltaTime = Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * deltaTime);
        if (transform.position == nextPos)
        {
            NextPos(); 
        }
    }

    void NextPos()
    {
        if (pathList.Count > 0)
        {
            nextPos = pathList[0];
            pathList.RemoveAt(0);
            if (nextPos.x > transform.position.x)
            {
                spriteRenderer.flipX = false;
            }
            else if (nextPos.x < transform.position.x)
            {
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            isMoving = false;
        }
        nbCaseMouv++;
    }
}
