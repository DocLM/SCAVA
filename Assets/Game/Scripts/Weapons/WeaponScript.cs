using UnityEngine;
using System.Collections;

public abstract class WeaponScript : MonoBehaviour {

	//Prefab per il proiettile
	public GameObject bulletPrefab;
	public int bulletCount;
	public float weaponRotSpeed = 30f;
	public Vector3 localPosition = new Vector3(0.18f,-0.3f,-1);
	public Transform bulletStart;
	protected string verticalMov;
	protected string horizontalMov;
	protected string fireButton;
	protected int _playerId;
	private KeyCode fireKey;
	protected CharacterScript ch;
	public GameObject leftSprite;
	public GameObject rightSprite;
	protected bool justFired = false;
	public float firePause = 1f;
	public float despawnTime = 5f;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine("Kill");
	}
	
	public void SetControls(int playerId, CharacterScript ch)
	{		
		_playerId = playerId;
		this.ch = ch;
		if(playerId == 1)
		{
			verticalMov = PlayersCommands.FirstPlayerControllerWeaponVerticalAxis;
			horizontalMov = PlayersCommands.FirstPlayerControllerWeaponHorizontalAxis;
			fireButton = PlayersCommands.FirstPlayerControllerFire;
			fireKey = PlayersCommands.FirstPlayerKeyboardFire;
		}
		else
		{
			verticalMov = PlayersCommands.SecondPlayerControllerWeaponVerticalAxis;
			horizontalMov = PlayersCommands.SecondPlayerControllerWeaponHorizontalAxis;
			fireButton = PlayersCommands.SecondPlayerControllerFire;
			fireKey = PlayersCommands.SecondPlayerKeyboardFire;
		}
	}
	
	//Da implementare nelle classi figlio per definire come sparare.
	public void Update ()
	{
		float vertical = Input.GetAxisRaw(verticalMov);
		float horizontal = Input.GetAxisRaw(horizontalMov);
		WeaponRotate(vertical, horizontal);		
		if (Input.GetButtonDown(fireButton) || Input.GetKeyDown(fireKey) ){
			if(!justFired)
			{
				justFired = true;
				StartCoroutine("WaitABitToFire", firePause);
				Fire();
			}
		}
		if(bulletCount == 0)
		{
			ch.canDig = true;
			ch.haveGun = false;
			Destroy(gameObject);
		}
	}
	
	protected void WeaponRotate(float vertical, float horizontal)
	{
		//Debug.Log(vertical.ToString());
		float angle;
		float currentAngle = transform.eulerAngles.z;
		if(ch.directionId == 1)
		{			
			rightSprite.SetActive(true);
			leftSprite.SetActive(false);			
			if( currentAngle < 180 )
			{
				currentAngle = 360  - currentAngle;
				transform.eulerAngles = new Vector3(0,0, currentAngle);
			}			
			
		}
		else
		{
			rightSprite.SetActive(false);
			leftSprite.SetActive(true);
			if( currentAngle > 180 )
			{
				currentAngle = 360  - currentAngle;
				transform.eulerAngles = new Vector3(0,0, currentAngle);
			}
		}
		
		if( Mathf.Abs(vertical) < 0.2 && Mathf.Abs(horizontal) < 0.2 )
		{		
			return;
		}
		angle = Vector2.Angle( new Vector2(1,0), new Vector2(vertical, horizontal));		
		//if( horizontal > 0)
		if(ch.directionId == 1)
		{
			angle = -angle;			
		}
		
		//if(currentAngle 
						
		
		
		float lerpedAngle = Mathf.LerpAngle( currentAngle, angle, Time.deltaTime * weaponRotSpeed);
		//transform.rotation = new Quaternion(0,0,lerpedAngle);
		transform.eulerAngles = new Vector3(0,0, lerpedAngle);
		
		//Debug.Log(angle.ToString() + " " + currentAngle.ToString() + " " + lerpedAngle.ToString()) ;
		
	}
	
	IEnumerator WaitABitToFire(float pause)
	{
		yield return new WaitForSeconds(pause);
		justFired = false;
	}

	IEnumerator Kill()
	{
		yield return new WaitForSeconds(despawnTime);
		ch.canDig = true;
		ch.haveGun = false;
		Destroy(gameObject);
	}

	//Metodo da implementare per definire lo sparo.
	public abstract void Fire();
}
