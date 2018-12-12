using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public float playerHealth = 10;
    public float discHealth = 10;
    public DiscController disc;

    private PlayerSpaceshipController _survivor;
    private List<PlayerInDiscController> _inDiscControllers;

    private Vector3 _endGameSpawnpoint;

    public Animator EndGameStartAnimator;
    public Animator GameEndAnimator;

    private readonly string _endGameStartAnimation = "EndGameStart";
    private readonly string _gameEndSpaceshipWinAnimation = "GameEndSpaceshipWin";
    private readonly string _gameEndDiscWinAnimation = "GameEndDiscWin";

    public static EndGameManager instance = null;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }


    IEnumerator EndGameStart()
    {
        _survivor._canMove = false;
        _inDiscControllers.ForEach(p => p._canMove = false);
        
        EndGameStartAnimator.Play(_endGameStartAnimation);
        yield return new WaitForSeconds(2);

        _survivor.transform.position = _endGameSpawnpoint;
        _survivor.transform.eulerAngles = new Vector3(0, 0, -90);
        _survivor.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        _inDiscControllers.ForEach(p => p.transform.position = Vector3.zero);
        _inDiscControllers.ForEach(p => p.ClearModule());

        yield return new WaitForSeconds(3);
        SetValues();
    }

    public void StartEndGame(PlayerSpaceshipController survivor, List<PlayerInDiscController> inDiscControllers, Vector3 endGameSpawnpoint)
    {
        _survivor = survivor;
        _inDiscControllers = inDiscControllers;
        _endGameSpawnpoint = endGameSpawnpoint;
        StartCoroutine(_endGameStartAnimation);
    }

    private void SetValues()
    {
        _survivor._canMove = true;
        _inDiscControllers.ForEach(p => p._canMove = true);
        _survivor.HealthManager.Health = playerHealth;
        disc.HealthManager.Health = discHealth;
    }

    public void DiscWin()
    {
        GameEndAnimator.Play(_gameEndDiscWinAnimation);
    }

    public void SpaceshipWin()
    {
        GameEndAnimator.Play(_gameEndSpaceshipWinAnimation);
    }
}
