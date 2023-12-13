using System.Collections;
using UnityEngine;

namespace Dreamcore.Core
{
	public interface ICoroutineRunner
	{
		Coroutine StartCoroutine(IEnumerator coroutine);
		void StopCoroutine(Coroutine coroutine);
	}
}