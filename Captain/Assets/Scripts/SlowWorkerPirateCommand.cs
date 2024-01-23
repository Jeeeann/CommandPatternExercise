using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Captain.Command;


namespace Captain.Command
{
    public class SlowWorkerPirateCommand : ScriptableObject, IPirateCommand
    {
        private float totalWorkDuration; //works for a 20-40 second duration
        private float totalWorkDone; //total working time
        private float currentWork; //pawning item time
        private const float PRODUCTION_TIME = 8.0f;//produces 1 item every 8 seconds. 
        private bool exhausted = false;

        public SlowWorkerPirateCommand()
        {
            var rand = new System.Random();
            this.totalWorkDuration = 20.0f + (float)rand.NextDouble() * 20.0f; //totalworkDuration is 20-40s
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
            if (this.currentWork >= PRODUCTION_TIME)//after 8s, spawn item, restart counting time
            {
                var product = (GameObject)Instantiate(productPrefab, pirate.transform.position, Quaternion.identity);
                this.currentWork = 0.0f;
            }
            return !exhausted;
        }
    }
}
