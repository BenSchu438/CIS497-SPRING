/* Example Code for Game Programming Design Patterns
 * Author: Owen Schaffer
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace ObserverPatternCollide
{
    //Attach this class to a UI text object to display the text
    public class DisplayLocationsVisited : MonoBehaviour, IObserver
    {
        //Attach the GameObject holding LocationData to this reference in the inspector
        public LocationData locationData;

        //Do not create a reference like this for static classes
        //public PlayerInfo playerInfo;

        private string textToDisplay;

        void Start()
        {
            this.textToDisplay = gameObject.GetComponent<Text>().text;

            locationData.RegisterObserver(this);
        }

        public void UpdateData(List<Location> locations)
        {
            this.textToDisplay = "";
            foreach (Location location in locations)
            {
                this.textToDisplay += "Location: " + location.locationName + ".\n";
                this.textToDisplay += "Visited: " + location.visited.ToString() + ".\n";
                this.textToDisplay += "Experience for discovering: " + location.expForDiscovering.ToString() + ".\n\n";
            }
            this.textToDisplay += "Total Experience: " + PlayerInfo.totalExp.ToString() + ".\n";
            gameObject.GetComponent<Text>().text = this.textToDisplay;
        }
        
    }
}
