using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Register : MonoBehaviour
{
    public static string starting    = "";
    public static string destination = "";
    public static string category    = "";
    public static int floor          = 0;
	public static int gameMode;
	public static Vector3 startPoint;
	public static Vector3 endPoint;

    public Register()
    {
        starting    = "";
        destination = "";
        category    = "";
        floor       = 0;
		gameMode = 0;
    }

	public void setGameMode(int i)
	{
		gameMode = i;	
	}

	public int getGameMode()
	{
		return gameMode;
	}
}
