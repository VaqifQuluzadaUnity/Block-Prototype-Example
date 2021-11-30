using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    //the end of tile where other tile joins
    public Transform endPoint;

    //movement speed of tile.
    public float speed;

    //the z position where tile will go when resetting
    public float resetPosition;
    [Space]

    #region CollectibleSpawnControl

    //Current obstacle or tiles on the platform.
    [SerializeField] private List<GameObject> currentObstacles = new List<GameObject>();

    private GameObject currentObstacle;


    #endregion
    private void MoveTile()
    {
        transform.position += transform.forward * Time.deltaTime * speed;

        if (transform.position.z >= resetPosition)
        {
            SpawnObstacle();
            GamePlayManager.instance.ChangeParent();
        }
    }

    private void SpawnObstacle()
    {
        if (currentObstacle != null)
        {
            Destroy(currentObstacle);
        }

        int currentObstacleIndex = Random.Range(0, currentObstacles.Count);

        currentObstacle = Instantiate(currentObstacles[currentObstacleIndex], this.transform);
    }
   
}
