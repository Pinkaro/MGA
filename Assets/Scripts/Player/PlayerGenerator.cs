using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerGenerator : MonoBehaviour
    {
        public int WidthDivisor = 8;
        public int HeightDivisor = 6;
        public GameObject PlayerBlueprint;


        private Vector3[] spawnpoints = new Vector3[4];
        private Vector3 spawnpoint1;
        private Vector3 spawnpoint2;
        private Vector3 spawnpoint3;
        private Vector3 spawnpoint4;

        private Vector3 cameraMiddle;

        private string[] controllerNames;

        void Awake()
        {
            controllerNames = Input.GetJoystickNames();
            InitSpawnpoints();
        }


        public void LogControllerInfo()
        {
            Debug.Log("Controllers detected: " + controllerNames.Length);

            foreach (string controller in controllerNames)
            {
                Debug.Log(controller);
            }
        }

        public void GeneratePlayers()
        {
            string currentPlayerId = string.Empty;
            GameObject currentPlayer = null;

            for (int i = 1; i <= controllerNames.Length; i++)
            {
                currentPlayerId = GeneratePlayerId(controllerNames[i - 1], i);
                currentPlayer = Instantiate(PlayerBlueprint, spawnpoints[i - 1], Quaternion.identity);
                currentPlayer.transform.up = cameraMiddle - spawnpoints[i - 1];

                currentPlayer.GetComponent<PlayerSpaceshipController>().PlayerId = currentPlayerId;
            }
        }

        private string GeneratePlayerId(string controllerName, int playerId)
        {
            string currentPlayerId = string.Empty;

            if (controllerName.Contains("PLAYSTATION(R)3"))
            {
                currentPlayerId = "P" + playerId + "_PS3";
                return currentPlayerId;
            }
            else if (controllerName.Contains("XBOX 360"))
            {
                currentPlayerId = "P" + playerId + "_XBOX360";
                return currentPlayerId;
            }

            return null;
        }

        private void InitSpawnpoints()
        {
            Camera mainCam = Camera.main;

            cameraMiddle = mainCam.ScreenToWorldPoint(new Vector2(mainCam.pixelWidth / 2, mainCam.pixelHeight / 2));
            cameraMiddle.z = 0.0f;

            int partWidthIndention = mainCam.pixelWidth / WidthDivisor;
            int partHeightIndention = mainCam.pixelHeight / HeightDivisor;

            Vector3 bottomLeft = new Vector3(partWidthIndention, partHeightIndention, 0.0f);
            Vector3 bottomRight = new Vector3(mainCam.pixelWidth - partWidthIndention, partHeightIndention, 0.0f);
            Vector3 topLeft = new Vector3(partWidthIndention, mainCam.pixelHeight - partHeightIndention, 0.0f);
            Vector3 topRight = new Vector3(mainCam.pixelWidth - partWidthIndention, mainCam.pixelHeight - partHeightIndention, 0.0f);

            spawnpoints[0] = mainCam.ScreenToWorldPoint(bottomLeft);
            spawnpoints[0].z = 0.0f;

            spawnpoints[1] = mainCam.ScreenToWorldPoint(bottomRight);
            spawnpoints[1].z = 0.0f;

            spawnpoints[2] = mainCam.ScreenToWorldPoint(topLeft);
            spawnpoints[2].z = 0.0f;

            spawnpoints[3] = mainCam.ScreenToWorldPoint(topRight);
            spawnpoints[3].z = 0.0f;

            //GameObject 
            //player1.transform.up = cameraMiddle - spawnpoint1;

            //GameObject player2 = Instantiate(PlayerBlueprint, spawnpoint2, Quaternion.identity);
            //player2.transform.up = cameraMiddle - spawnpoint2;

            //GameObject player3 = Instantiate(PlayerBlueprint, spawnpoint3, Quaternion.identity);
            //player3.transform.up = cameraMiddle - spawnpoint3;

            //GameObject player4 = Instantiate(PlayerBlueprint, spawnpoint4, Quaternion.identity);
            //player4.transform.up = cameraMiddle - spawnpoint4;
        }
    }
}
