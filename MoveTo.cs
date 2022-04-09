// MoveTo.cs
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class MoveTo : MonoBehaviour
{
    Animator anim01;
    NavMeshAgent agent;
    public Transform goal;
    public float speed;
    private bool ogreactive;
    public AudioSource ogrerage;
    public AudioSource ogreroar;
    public AudioSource ogrefootsteps;

    void Start()
    {
        //get refeneces to game components
        agent = GetComponent<NavMeshAgent>();
        anim01 = gameObject.GetComponent<Animator>();
        speed = 5.5f;
        agent.speed = speed; //set speed of enemy;
        ogreactive = false;
        
    }
        
    void Update()
    {
     
        if (SceneController.AlmostEqual(SceneController.EnemyTransform.position, SceneController.PlayerTransform.position, 35.0f))
        {
            ogreactive = true;
            if (!ogrerage.isPlaying)
            {
                ogrerage.Play();
            }
            anim01.SetBool("IsRage", true);
        }

        if (SceneController.AlmostEqual(SceneController.EnemyTransform.position, SceneController.PlayerTransform.position, 30.0f)|| ogreactive)
        {
            
            if (!ogrefootsteps.isPlaying)
            {
                ogrefootsteps.Play();
            }
            anim01.SetBool("IsRun", true);
            agent.SetDestination(goal.position);

        }

        //if ogre near berry, ogre then roars
        if (SceneController.AlmostEqual(SceneController.EnemyTransform.position, SceneController.PlayerTransform.position, 5.0f))
        {
            ogrerage.Stop();
            if (!ogreroar.isPlaying)
            {
                ogreroar.Play();
            }
        }
        //if health expired stop all ogre sounds
        if (SceneController.timeout)
        {  
            ogreroar.Stop();
            ogrerage.Stop();
            ogrefootsteps.Stop();
        }

        //if Mayan hits berry, stop monentarily
        if (SceneController.AlmostEqual(SceneController.EnemyTransform.position, SceneController.PlayerTransform.position, 0.0f))
        {
            speed = 0.0f;
            agent.speed = speed;

            
         
        }
        //increase speed of MayanBerry
        if (speed < 5.5f)
        {

            speed = speed + 0.005f;
            agent.speed = speed;

        }
    }
}