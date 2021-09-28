using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public Transform spawnPositionManager;
    public List<Material> tankColours;

    List<Transform> spawnPoints = new List<Transform>();
    List<Transform> initialPos = new List<Transform>();
    int index = 0;

    [SerializeField]
    List<int> kilNumber = new List<int>();

    // Start is called before the first frame update
    void Start()
    {


        foreach (Transform trans in spawnPositionManager)
        {
            spawnPoints.Add(trans);
        }

    }

    public void OnSpawnPlayer(PlayerInput input)
    {
        
        

        int randomIndex = Random.Range(0, spawnPoints.Count);

        input.GetComponent<Tank>().SetInitialPos(spawnPoints[randomIndex].position);

        /*  
              Lista de materiales para los colores       
          Material[] mats = new Material[4];

          mats[0] = tankColours[index];
          mats[1] = tankColours[index];
          mats[2] = tankColours[index];
          mats[3] = tankColours[index];

          input.GetComponent<TankColour>().tankColour = mats;

      */
        kilNumber.Add(0);

    }
}
