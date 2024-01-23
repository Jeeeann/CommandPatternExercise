using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Captain.Command;


namespace Captain.Command
{
    public class FastWorkerPirateCommand : ScriptableObject, IPirateCommand
    {
        private float totalWorkDuration; //works for a 5-10 second duration
        private float totalWorkDone; //total working time
        private float currentWork; //pawning item time
        private const float PRODUCTION_TIME = 2.0f;//produces 1 item every 2 seconds. 
        private bool exhausted = false;

        public FastWorkerPirateCommand()
        {
            var rand = new System.Random();
            this.totalWorkDuration = 5.0f + (float)rand.NextDouble() * 5.0f; //totalworkDuration is 5-10s
            this.totalWorkDone = 0.0f;
            this.currentWork = 0.0f;
        }

        public bool Execute(GameObject pirate, Object productPrefab)
        {
            //start counting time
            this.totalWorkDone += Time.deltaTime;
            this.currentWork += Time.deltaTime;

            if (this.totalWorkDone >= this.totalWorkDuration)//outside of working period
            {
                return exhausted;
            }
            if (this.currentWork >= PRODUCTION_TIME)//after 2s, spawn item, restart counting time
            {
                var product = (GameObject)Instantiate(productPrefab, pirate.transform.position, Quaternion.identity);
                this.currentWork = 0.0f;
            }
            return !exhausted;
        }
    }
}
