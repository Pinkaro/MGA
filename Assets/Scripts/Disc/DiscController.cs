using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class DiscController : MonoBehaviour,IKillable
{

    public HealthManager HealthManager;

    public void Die()
    {
        EndGameManager.instance.SurvivorWin();
    }
}
