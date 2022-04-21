using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(T)) as T;
                if (instance == null)
                    instance = new GameObject("[ " + typeof(T).Name + " ]").AddComponent<T>();
                DontDestroyOnLoad(instance.gameObject);
            }

            return instance;
        }
    }

    public void SetInstance()
    {
        if (instance == this.GetComponent<T>())
        {
            return;
        }

        if (instance)
        {
            Destroy(this.gameObject);
            return;
        }

        if (!instance)
        {
            instance = FindObjectOfType(typeof(T)) as T;
            if (!instance)
                instance = new GameObject("[ " + typeof(T) + " ]").AddComponent<T>();
            DontDestroyOnLoad(instance.gameObject);
        }
    }

    protected virtual void LoadData()
    {
        //load interface
    }
}

public class DestructibleSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(T)) as T;
                if (instance == null)
                    instance = new GameObject("[ " + typeof(T).Name + " ]").AddComponent<T>();
            }

            return instance;
        }
    }

    public void SetInstance()
    {
        if (instance == this.GetComponent<T>())
        {
            return;
        }

        if (instance)
        {
            Destroy(this.gameObject);
            return;
        }

        if (!instance)
        {
            instance = FindObjectOfType(typeof(T)) as T;
            if (!instance)
                instance = new GameObject("[ " + typeof(T) + " ]").AddComponent<T>();
        }
    }

    public virtual void LoadData()
    {
        //load interface
    }
}
