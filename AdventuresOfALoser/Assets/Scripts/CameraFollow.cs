using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;

    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void LateUpdate()
    {
        //store camera position in varible temp
        Vector3 temp = transform.position;

        /* Trash Code, virtual cam is better at keeping track of player
         * 
         * 
        //set camera's position xy to player's xy postion
        //temp.x = playerTransform.position.x;
        //temp.y = playerTransform.position.y;

        //ofset the y axis
        //temp.y += offset;
        *
        *
        */
        
        
        //set camera's temp position to camera's cuurent posistion
        transform.position = temp;

    }
}
