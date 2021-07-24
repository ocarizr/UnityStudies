using UnityEngine;

namespace Monobehaviours.BaseClass
{
    public class SingletonBase<T> : MonoBehaviour where T : SingletonBase<T>
    {
        // Instance manager
        private static T _instance;
        public static T GetInstance() => _instance;

        protected void Awake()
        {
            if (_instance is null)
            {
                _instance = this as T;
                return;
            }

            Destroy(gameObject);
        }
    }
}
