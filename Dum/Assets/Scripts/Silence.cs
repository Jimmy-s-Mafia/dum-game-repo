using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silence : MonoBehaviour
{
	void DestroyObjectDelayed()
	{
		Destroy(gameObject, 5);
	}
}
