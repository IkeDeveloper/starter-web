using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    public Text Collected;
    public Text health;
    public Text bonus;
    public Text playerPoints;

    public Text GameOverText;
    public Text TimeoutText;
    public Text MissionCompleted;
    public Text ReadyText;
    public Text finalCaptionText;
    public Text turboText;

    public float healthchange;
    public float turbotime;
    public float turbotimeresult;
    public static float score;
    public static int cartonsCollected;
    public static float MyHealth;
   

    public static Transform EnemyTransform;
    public static Transform PlayerTransform;
    public static Transform ChiefTransform;

    public Transform longWall01X;
    public Transform longWall02X;
    public Transform shortWall01Y;
    public Transform shortWall02Y;

    public static bool groundcartonsCollected;
    public static bool pyramidCartonCollected;
    public static bool canvasFlare;
    public static bool activeControls;
    public static bool turbotimerstarted;
    
    public static bool timeout;
    private bool gameovertheme;
    private bool chiefcry;
    private bool finalmessage;
    private bool boostmessage;
    private bool lastlaugh;
    
    
    //Refences to sound
    public AudioSource heavybreathing;
    public AudioSource berrydeathgroan;
    public AudioSource ready;
    public AudioSource gamemusic;
    public AudioSource gameovermusic;
    public AudioSource chiefdeath;
    public AudioSource firworks;
    public AudioSource junglesound;
    public AudioSource endlaugh;
    

    void Awake()
    {
        //Make refereces to game characters
        EnemyTransform = GameObject.FindWithTag("MayanEnemy").GetComponent<Transform>(); //get reference to Rinina Enemy Berry
        PlayerTransform = GameObject.FindWithTag("PlayerBerry").GetComponent<Transform>();//get reference to Rinina Berry
        ChiefTransform = GameObject.FindWithTag("MayanChief").GetComponent<Transform>(); //get refence to Myan Cheif

        //Make refernces to maze bounderies
        //first the longer walls (X-Axis)
        longWall01X = GameObject.FindWithTag("LongWall01").GetComponent<Transform>();
        longWall02X = GameObject.FindWithTag("LongWall02").GetComponent<Transform>();

        //Next the shorter walls (Y-Axis)
        shortWall01Y = GameObject.FindWithTag("ShortWall01").GetComponent<Transform>();
        shortWall02Y = GameObject.FindWithTag("ShortWall02").GetComponent<Transform>();

    }

    // Start is called before the first frame update
    void Start()
    {
        GameOverText.text = "";
        TimeoutText.text = "";

        MissionCompleted.text = "";
        cartonsCollected = 0;
        score = 0;
        healthchange = -1.0f;
        MyHealth = 100.0f;

        groundcartonsCollected = false;
        pyramidCartonCollected = false;
        canvasFlare = false;
        timeout = false;
        activeControls = true;
        finalmessage = false;

      
        ReadyText.text = "READY!!!!!!!";
        gamemusic.Play();
        gameovertheme = false;
        chiefcry = false;
        lastlaugh = false;
        turbotimerstarted = false;
        boostmessage = false;
       
        
        StartCoroutine(imready());

        StartCoroutine(ReadyPause()); //puase for 7 seconds  
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) //disable ingame music if escape key pressed
            gamemusic.mute = !gamemusic.mute;

        //checjk if berry is within the boundary of maze
        if (IsinMaze(PlayerTransform.position, longWall01X.position, longWall02X.position, shortWall01Y.position, shortWall02Y.position))
        {
            
            if (!junglesound.isPlaying)
            { 
                junglesound.Play();
                
            }
            
            if (gamemusic.isPlaying)
            {        
                gamemusic.Stop();
            }
   
        }

        //is berry outside maze walls?
        if (!IsinMaze(PlayerTransform.position, longWall01X.position, longWall02X.position, shortWall01Y.position, shortWall02Y.position))
        {

            if (junglesound.isPlaying)
            {
                junglesound.Stop();

            }

            if (!gamemusic.isPlaying)
            {
                gamemusic.Play();
            }

        }

            if ((MyHealth > -1) && (!pyramidCartonCollected))
            {
                 printplayerinfo(); // call routine that displays player info
                MyHealth = Mytimer(healthchange);

                if (cartonsCollected >5)
                {
                    groundcartonsCollected = true;
                    if (!finalmessage)
                    {
                        finalCaptionText.text = "Head to apex of pyramid; there you will find the fianl sacred Ribina Carton....";
                         StartCoroutine(finalCaption());
                        finalmessage = true;
                    }
                    if (!chiefdeath.isPlaying)
                    {
                    if (!chiefcry)
                    {
                        chiefdeath.Play();
                        chiefcry = true;
                    }
                }
            }

            if (MyHealth < 1) //set a flag if time runs out
            {
                timeout = true;
                MyHealth = 0;
            }
        }

        if (MyHealth < 20.0f) //is health runing out? if so start heavy breathing
        {
            if (!heavybreathing.isPlaying)
            {
                heavybreathing.Play();
            }
        }

       
        if (turbotimerstarted) // speed berry up if pill eaten
        {
            if (!boostmessage)
                 turboText.text = "Munch on pills for extra points and 10 seconds instant energy boost....";
            if (PillCollide.boosttime-(MyHealth-10)<10)
            {
                SpeedController.speed = 10.0f;
                ObjRotation.RotSpeed = 90.0f;
               
            }
            else
            {
                SpeedController.speed = 5.5f;
                ObjRotation.RotSpeed = 75.0f;
                turbotimerstarted = false;
                turboText.text = "";
                boostmessage = true;
            }
        }

        if (timeout) //check for time out, if so game over
        {
            if (junglesound.isPlaying)
                    junglesound.Stop();

            if (heavybreathing.isPlaying)
                    heavybreathing.Stop();

            if (!berrydeathgroan.isPlaying)
            {
                berrydeathgroan.Play();
            }
            StartCoroutine(pausegroan());

            TimeoutText.text = "Health Done!!!";
            GameOverText.text = "G a m e  O v e r ! ! !";
            activeControls = false; //deactivate player movment

            if (!gameovermusic.isPlaying)
            {
                
                gamemusic.Stop();

                if (!gameovertheme) //play closing theme music only once
                {
                    gameovermusic.Play();
                    gameovertheme = true;
                }
            }
            //Play end evil laugh if dead.
            
                if (!gameovermusic.isPlaying)
                {
                     if (!lastlaugh)
                     {
                         lastlaugh = true;
                         if (!endlaugh.isPlaying)
                            endlaugh.Play();
                     }
                }
            
            StartCoroutine(GameOver());
        }

        if (pyramidCartonCollected) //check if pyramid carton collected
                                    //if so commence winning sequence
        {
            MissionCompleted.text = "Well Done, Mission Complete!!!!!!!";
            canvasFlare = true;

            if (!firworks.isPlaying)
            {
                firworks.Play();
            }

            activeControls = false; //deactivate player movment
            healthchange = 0.0f; //stop timer if game completed
            bonuspoints(MyHealth);
        }
        pyramidCartonCollected = false;

    }

    //Award bous points when game completed
    public void bonuspoints(float bonushealth)
    {
        int health = (int)bonushealth;
        bonus.text = (health * 10).ToString("#0") + " Bonus points awarded.";
        
        score = score + health * 10;
        printplayerinfo();
        StartCoroutine(MissionComplete());
    }
    public void printplayerinfo() //display player score and health
    {
        health.text = MyHealth.ToString("#.");
        Collected.text = cartonsCollected.ToString()+"/7";
        playerPoints.text = score.ToString("#0");
    }

    //timer
    public float Mytimer(float step)
    {
        MyHealth = MyHealth + step * Time.deltaTime;

        return Mathf.Clamp(MyHealth, 0, 100);
    }

    private IEnumerator imready()
    {
        yield return new WaitForSeconds(2);
        ready.Play();
    }

    //Delete final caption
    private IEnumerator finalCaption()
    {
        yield return new WaitForSeconds(5);
        finalCaptionText.text = "";
    }
    //Wait before stopping death groan
    private IEnumerator pausegroan()
    {
         yield return new WaitForSeconds(1.5f);
         berrydeathgroan.Stop();
    }

    //return to menu after completing game
    private IEnumerator MissionComplete()
    {
        yield return new WaitForSeconds(20);
        canvasFlare = false;
        SceneManager.LoadScene(0);
    }

    //Pause for 20 seconds if time runs out
    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(20);

        SceneManager.LoadScene(0);
    }

    //pause ready message for 5 seconds
    private IEnumerator ReadyPause()
    {
        yield return new WaitForSeconds(5);
        ReadyText.text = "";
    }

   

    public bool IsinMaze(Vector3 berrypos, Vector3 longwall01, Vector3 longwall02, Vector3 shortwall01, Vector3 shortwall02)
    {
       if ((berrypos.x>shortwall01.x) && (berrypos.x<shortwall02.x)
            && (berrypos.z<longwall01.z) && (berrypos.z>longwall02.z))
             return true; //ruturn true if berry is in maze
        else 
            return false;
    }
    //tests if two game objects position relative to each other
    public static bool AlmostEqual(Vector3 v1, Vector3 v2, float tolerance)
    {
        if (Mathf.Abs(v1.x - v2.x) > tolerance) return false;
        if (Mathf.Abs(v1.y - v2.y) > tolerance) return false;
        if (Mathf.Abs(v1.z - v2.z) > tolerance) return false;
        return true;
    }
}
