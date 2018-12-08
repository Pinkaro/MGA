using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    private PlayerSpaceshipController _survivor;
    private List<PlayerInDiscController> _inDiscControllers;

    private Vector3 _endGameSpawnpoint;
    
    IEnumerator EndGameStart()
    {
        _survivor._canMove = false;
        _inDiscControllers.ForEach(p => p._canMove = false);

        _survivor.transform.position = _endGameSpawnpoint;
        _survivor.transform.eulerAngles = new Vector3(0, 0, -90);
        _survivor.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        _inDiscControllers.ForEach(p => p.transform.position = Vector3.zero);

        yield return new WaitForSeconds(5);
        _survivor._canMove = true;
        _inDiscControllers.ForEach(p => p._canMove = true);
    }

    public void StartEndGame(PlayerSpaceshipController survivor, List<PlayerInDiscController> inDiscControllers, Vector3 endGameSpawnpoint)
    {
        _survivor = survivor;
        _inDiscControllers = inDiscControllers;
        _endGameSpawnpoint = endGameSpawnpoint;
        StartCoroutine("EndGameStart");
    }

    public void DiscWin()
    {

    }
}
