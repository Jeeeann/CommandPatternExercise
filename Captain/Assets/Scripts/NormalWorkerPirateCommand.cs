using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Captain.Command;


namespace Captain.Command
{
    public class NormalWorkerPirateCommand : ScriptableObject, IPirateCommand
    {
        private float totalWorkDuration; //works for a 10-20 second duration
        private float totalWorkDone; //total working time
        private float currentWork; //pawning item time
        private const float PRODUCTION_TIME = 4.0f;//produces 1 item every 4 seconds. 
        private bool exhausted = false;

        public NormalWorkerPirateCommand()
        {
            //btw 10 and 30 --> 10.0;20.0
            // 5 and 10 --> 5.0;5.0
            var rand = new System.Random();
            this.totalWorkDuration = 10.0f + (float)rand.NextDouble() * 10.0f; //totalworkDuration is 10-20s
            this.totalWorkDone = 0.0f;
            this.currentWork = 0.0f;
        }

        public bool Execute(GameObject pirate, Object productPrefab)
        {
            //This function returns false when no work is done. 
            //After you implement work according to the specification and
            //generate instances of productPrefab, this function should return true.
            
            /*
            var rand = new System.Random();
            this.totalWorkDuration = 10.0f + (float)rand.NextDouble() * 30.0f;
            totalWorkDuration -= Time.deltaTime;
            timeLeft -= Time.deltaTime;
            if (totalWorkDuration > 0)
            {
                //timeLeft -= Time.deltaTime;
                if (timeLeft <= 0)
                {
                    //spawn the item
                    Instantiate(productPrefab, pirate.transform.position, Quaternion.identity);
                    //reset time
                    timeLeft = PRODUCTION_TIME;
                    //return true;
                }
                return true;
            }
            else
                return false;

            */
            
         
            //start counting time
            this.totalWorkDone += Time.deltaTime;
            this.currentWork += Time.deltaTime;

            if(this.totalWorkDone >= this.totalWorkDuration)//outside of working period
            {
                return exhausted;
            }
            if(this.currentWork >= PRODUCTION_TIME)//after 4s, spawn item, restart counting time
            {
                var product = (GameObject)Instantiate(productPrefab, pirate.transform.position, Quaternion.identity);
                this.currentWork = 0.0f;
            }
            return !exhausted;
        }
    }
}
