using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hawki.MyCoroutine
{
    public class CoroutineManager : RuntimeSingleton<CoroutineManager>
    {
        private Dictionary<int, Coroutine> _coroutines = new Dictionary<int, Coroutine>();

        private CoroutineRunner _runner;

        public CoroutineManager()
        {
            _runner = new GameObject("[Hawki] Coroutine Runner", typeof(CoroutineRunner)).GetComponent<CoroutineRunner>();

            GameObject.DontDestroyOnLoad(_runner.gameObject);
        }

        public int Start(IEnumerator routine)
        {
            var coroutine = _runner.StartCoroutine(routine);

            _coroutines.Add(coroutine.GetHashCode(), coroutine);

            return coroutine.GetHashCode();
        }

        public void Stop(int id)
        {
            if (_coroutines.TryGetValue(id, out var cor))
            {
                _runner.StopCoroutine(cor);
            }
        }
    }
}
