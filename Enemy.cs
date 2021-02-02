using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public float visionRadius;
    
    [SerializeField]
    private float stopDistance, speedTranslation, speedRotation;

    [SerializeField]
    private Transform playerToFollow;
    
    [SerializeField]
    private Rigidbody playerInitialPosition;

    [SerializeField]
    private bool _panic = false;

    public float PosX, PosY, PosZ;
    public Vector3 initialPosition;


    void Start()    
    {
        if(playerInitialPosition == null)
        {
            playerInitialPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        }

        if (playerToFollow == null)
        {
            playerToFollow = GameObject.FindGameObjectWithTag("Player").transform; 
        }

        initialPosition = playerToFollow.position;
    }


    public void Update()
    {
        transform.Rotate(0f, 0f, speedRotation * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, playerToFollow.position) > stopDistance)
        {
            int panicDirection = 1;

            if (_panic)
                panicDirection = -1;

            float fixedSpeed = speedTranslation * panicDirection * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, playerToFollow.position, fixedSpeed);
        }        

        Debug.DrawLine(transform.position, playerToFollow.position, Color.green);
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
    }


    public void IsInPanic(bool panic)
    {
        _panic = panic;
    }


    public void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            playerInitialPosition.MovePosition(initialPosition);
            playerInitialPosition.velocity = Vector3.zero;
            playerInitialPosition.angularVelocity = Vector3.zero;
        }
    }

}





/*
var MoveSpeed:float = 4; //Establecer velocidad de persecución
var MaxDist:float = 20; //Establecer distancia máxima a la que lo seguirá
var MinDist:float = 1;//Establecer distancia mínima a la que lo seguirá

var idle:AnimationClip; //Animación en estado de reposo
var run:AnimationClip; //Animación de correr o perseguir


function Start () {

}

function Update () {
    var EnemyPos = transform.position;
    var PlayerPos = Player.position;
    var distancia = Vector3.Distance(EnemyPos,PlayerPos);

    if(  distancia >= MinDist && distancia <= MaxDist  ){
       var targetPos = new Vector3( Player.position.x, 
                                       this.transform.position.y, 
                                       Player.position.z);
    		transform.LookAt(targetPos);
    		transform.position += transform.forward*MoveSpeed*Time.deltaTime;
       		animation.CrossFade(run.name,1); 
		for (var state : AnimationState in animation) {
			state.speed = 2;
		}
   } else {
   		animation.CrossFade(idle.name,1); 
   		for (var state : AnimationState in animation) {
			state.speed = 1;
		}
   }
*/