using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointCollection : MonoBehaviour
{
    private int Point = 0; // Variable to store the points collected
    public TextMeshProUGUI PointText; // Reference to the TextMeshProUGUI component for displaying points

    // Called when another collider enters the trigger collider attached to this GameObject
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Point")) // Check if the entering GameObject has the tag "Point"
        {
            Point += 100; // Increase points by 100
            PointText.text = "Points: " + Point.ToString(); // Update the UI text to display the new points count
            Debug.Log("Points: " + Point); // Log the current points to the console for debugging
            Destroy(other.gameObject); // Destroy the GameObject that entered the trigger (collected point)
        }
    }
}


