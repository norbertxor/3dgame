using UnityEngine;

public class SaveGame : MonoBehaviour {
    public GameObject player;
    
    public void SavePlayer() {
        float health = player.GetComponent<PlayerHealth>().health;
        float posX = player.transform.position.x; 
        float posY = player.transform.position.y;
        float posZ = player.transform.position.z;
        SaveSystem.SaveData(health, posX, posY, posZ);
    }
}