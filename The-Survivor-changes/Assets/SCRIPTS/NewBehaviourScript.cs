using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour
{
  

        public Transform Player;
        private float distance = -10f;
        private float CameraX = 4f;
        private float CameraY = 4f;


        // Update is called once per frame
        void Update()
        {
            transform.position = new Vector3(Player.position.x + CameraX, Player.position.y + CameraY, Player.position.z + distance);
        }
   

   

}