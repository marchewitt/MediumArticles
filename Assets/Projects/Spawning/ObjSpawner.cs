using System.Collections;
using UI;
using UnityEngine;

namespace Projects.Spawning
{
	public class ObjSpawner : MonoBehaviour
	{
		[Header("Object")]
		[SerializeField] private GameObject objPrefab;
		[SerializeField] private GameObject objContainer;
		
		[Header("Spawn Config")]
		[SerializeField] private float spawnRate = 3f;
		[SerializeField] private Transform spawnPoint;
		[SerializeField] private float force = 3f;

		[Header("UI Timer")]
		[SerializeField] private FillDisplayGradiant uiTimeDisplay;
		private float _uiTimer;
	
		private void Start()
		{
			StartCoroutine(SpawnObj());
			_uiTimer = Time.time;
			StartCoroutine(SpawnTimer());    
		}

		private IEnumerator SpawnObj()
		{

			while (true)
			{
				_uiTimer = Time.time;
				//Can put random spawn logic here as needed
				var spawnPos = spawnPoint.position; 
			
				//Spawn object in, and then parent it into our container
				var newObj = Instantiate(objPrefab, spawnPos, Quaternion.identity);
				newObj.transform.parent = objContainer.transform;

				var rb = newObj.GetComponent<Rigidbody>();
				if (rb)
				{
					rb.AddForce(force * spawnPoint.forward);
				}
		
				yield return new WaitForSeconds(spawnRate);
			}
		}

		private IEnumerator SpawnTimer()
		{
			while(true)
			{
				uiTimeDisplay.TargetValue =   (Time.time - _uiTimer) / spawnRate; 
				yield return new WaitForEndOfFrame();
			}
		}
	}
}

