using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticVariable
{
    public static int typeUsers = 0;
    public static string videoName = "SCREEN_SAVER.mp4";
  //  public static string Branch;

    public static float timeSave = 3f;
    public static bool cheackGachaOnPlay = true;
    public static bool cheackDelayGachaOnPlay = true;
    public static bool changePage = true;
    public static bool cheackStopMoveGacha = true;
    public static float speedAnim = 1f;

    public static string COM;

    public static string reword = "";
    public static int statusApi = 0;
    public static int statusReword = 0;
    public static float timeStatusApi = 10;
    public static string urlIamgeReword = "";
    public static string oldreword = "Game play free";
    public static Texture IamgeReword;

    public static bool checkApi = false;
    public static int countErrorApi = 0;
    public static bool NetworkError = false;
    public static string code_branch = "M8";
       // {return code_branch;}
    //public  string code_branch_m { get; set;}
    public static void ResetVal()
    {
        reword = "";
        checkApi = false;
        NetworkError = false;
        countErrorApi = 0;
        IamgeReword = null;
    }
    public static void playgame()
    {
        cheackGachaOnPlay = false;
        cheackDelayGachaOnPlay = false;
       
    }
    public static void canplayGame()
    {
        cheackGachaOnPlay = true;
        cheackDelayGachaOnPlay = true;
    }
}
