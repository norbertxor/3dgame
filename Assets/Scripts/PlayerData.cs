using System;

[System.Serializable]
public class PlayerData {
    public float health;
    public float[] position;

    public PlayerData(float health, float posX, float posY, float posZ) {
        this.health = health;
        position = new float[3];
        position[0] = posX;
        position[1] = posY;
        position[2] = posZ;
    }
}