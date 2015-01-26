using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour {

	public float speed = 4;
	public int playerId = 1;
	public int directionId = 0;
	private string verticalAxis;
	private string horizontalAxis;	
	private KeyCode UpKey;
	private KeyCode DownKey;
	private KeyCode LeftKey;
	private KeyCode RightKey;
	private KeyCode FireKey;
	private string fireButton;
	public Arena arenaRef;
	public int health = 3;
	public bool canDig;
	public bool haveGun;
	private bool canMove;
	public ShowdownScript x;
	public AudioSource baseclip;
	public AudioSource nowclip;
	
	private AudioSource[] audios;

	private float diggingStartTime;
	private float diggingAnimationTime = 2f;
	private Vector2 my2dPosition;

	public Animator myAnimator;


	// Use this for initialization
	void Start () {
		//myAnimator.SetInteger("WalkState", 1);
		//Arena arenaRef = GameObject.FindGameObjectWithTag("arena").GetComponent<Arena>();
		//Debug.Log(verticalAxis);
		//myAnimator = GetComponent<Animator> ();
		canDig = true;
		canMove = true;
		haveGun = false;
		audios = GetComponents<AudioSource>();
		if(playerId == 1)
		{
			this.verticalAxis = PlayersCommands.FirstPlayerControllerVerticalAxis;
			this.horizontalAxis = PlayersCommands.FirstPlayerControllerHorizontalAxis;
			this.fireButton = PlayersCommands.FirstPlayerControllerFire;
			this.FireKey = PlayersCommands.FirstPlayerKeyboardFire;
			this.UpKey = PlayersCommands.FirstPlayerKeyboardUp;
			this.DownKey = PlayersCommands.FirstPlayerKeyboardDown;
			this.LeftKey = PlayersCommands.FirstPlayerKeyboardLeft;
			this.RightKey  = PlayersCommands.FirstPlayerKeyboardRight;


		}
		else
		{
			verticalAxis = PlayersCommands.SecondPlayerControllerVerticalAxis;
			horizontalAxis = PlayersCommands.SecondPlayerControllerHorizontalAxis;
			fireButton = PlayersCommands.SecondPlayerControllerFire;
			this.FireKey = PlayersCommands.SecondPlayerKeyboardFire;
			this.UpKey = PlayersCommands.SecondPlayerKeyboardUp;
			this.DownKey = PlayersCommands.SecondPlayerKeyboardDown;
			this.LeftKey = PlayersCommands.SecondPlayerKeyboardLeft;
			this.RightKey  = PlayersCommands.SecondPlayerKeyboardRight;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{	

//		if(Input.GetKey(this.RightKey) && transform.position.x < arenaRef.spaceLimitHorizontal )
//		{			
//			transform.position = transform.position +  transform.right * speed * Time.deltaTime;
//		}
//		if(Input.GetKey(this.LeftKey) && transform.position.x > -arenaRef.spaceLimitHorizontal )
//		{
//			transform.position = transform.position - transform.right * speed * Time.deltaTime;
//		}
//		if(Input.GetKey(this.UpKey) && transform.position.y < arenaRef.spaceLimitUp )
//		{			
//			transform.position = transform.position +  transform.up * speed * Time.deltaTime;
//		}
//		if(Input.GetKey(this.DownKey) && transform.position.y > -arenaRef.spaceLimitDown )
//		{
//			transform.position = transform.position -  transform.up * speed * Time.deltaTime;
//		}
		
		float speedVertical = Input.GetAxisRaw(verticalAxis);
		float speedHorizontal = Input.GetAxisRaw(horizontalAxis);		
		if((speedHorizontal  > 0.5 || Input.GetKey(this.RightKey) )&& transform.position.x < arenaRef.spaceLimitHorizontal && canMove )
		{			
			transform.position = transform.position +  transform.right * speed * Time.deltaTime;
			myAnimator.SetInteger("WalkState", 1);
			directionId = 1;
			if(!audios[0].isPlaying)
			audios[0].Play();
		}
		else if((speedHorizontal  < -0.5 || Input.GetKey(this.LeftKey)) && transform.position.x > -arenaRef.spaceLimitHorizontal && canMove )
		{
			transform.position = transform.position - transform.right * speed * Time.deltaTime;
			myAnimator.SetInteger("WalkState", -1);
			directionId = -1;
			if(!audios[0].isPlaying)
			audios[0].Play();
		}
		if((speedVertical > 0.5 || Input.GetKey(this.UpKey)) && transform.position.y < arenaRef.spaceLimitUp && canMove)
		{			
			transform.position = transform.position +  transform.up * speed * Time.deltaTime;
			myAnimator.SetInteger("WalkState", 2);
			if(!audios[0].isPlaying)
			audios[0].Play();
		}
		else if((speedVertical < -0.5 || Input.GetKey(this.DownKey)) && transform.position.y > -arenaRef.spaceLimitDown && canMove)
		{
			transform.position = transform.position -  transform.up * speed * Time.deltaTime;
			myAnimator.SetInteger("WalkState", 2);
			if(!audios[0].isPlaying)
			audios[0].Play();
		}
		if (speedVertical > -0.5 && speedVertical < 0.5 && speedHorizontal > -0.5 && speedHorizontal < 0.5 && !Input.GetKey(UpKey)&& !Input.GetKey(DownKey)&& !Input.GetKey(LeftKey)&& !Input.GetKey(RightKey) && canMove) 
		{
			myAnimator.SetInteger("WalkState", 0);
			audios[0].Stop();
		}
		
		if(!haveGun && ((Input.GetButtonDown(fireButton) || Input.GetKeyDown(FireKey))))
		{
			canDig = false;
			canMove = false;
			diggingStartTime = Time.realtimeSinceStartup;
			myAnimator.SetBool("Digging", true);
			my2dPosition = new Vector2( transform.position.x, transform.position.y);
			audios[2].Play();

		}

		if (Time.realtimeSinceStartup - diggingStartTime > diggingAnimationTime && !canMove) 
		{
			canMove = true;
			myAnimator.SetBool("Digging", false);
			if(arenaRef.gunFound(my2dPosition))
			{
				if(!x.alreadydo)
				{
					x.alreadydo = true;
					x.showdown = true;
					Time.timeScale=0;
					baseclip.Stop();
					this.nowclip.Play();
					StartCoroutine(slowNow());
				}
				haveGun = true;
				arenaRef.generateGunSpawn();				
				GameObject newWeapon = arenaRef.GetRandomWeapon();
				newWeapon.transform.SetParent(transform);
				WeaponScript ws = newWeapon.GetComponent<WeaponScript>();
				newWeapon.transform.localPosition = ws.localPosition;
				ws.SetControls(playerId, this);
				
			}
			else if(haveGun) canDig = true;
		}
	}

	public void getHit(int damage)
	{
		health -= damage;
		if(!audios[1].isPlaying)
		audios[1].Play();
		if (health < 0)
						health = 0;
		if (health > 5)
						health = 5;
	}

	public IEnumerator slowNow()
	{
		yield return new WaitForSeconds (8);
		baseclip.clip = (AudioClip)Resources.Load("Musics/mus_battle", typeof(AudioClip));
		baseclip.Play();
		baseclip.loop = true;
	}
	
}
