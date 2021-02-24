using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMC : MonoBehaviour
{
    //Reference to all our singletons that can be used in the project
    protected static Prototype1.GameManager _GM1 { get { return Prototype1.GameManager.INSTANCE; } }



    /// <summary>
    /// Use this to check if we should call Game Over
    /// </summary>
    /// <param name="_lives">The players current lives</param>
    /// <returns>If we are at Game Over or Not</returns>
    public bool IsGameOver(int _lives)
    {
        return _lives == 0;
    }

    /// <summary>
    /// Works out the change in percentage between two scores
    /// </summary>
    /// <param name="_score1">The original score</param>
    /// <param name="_score2">The new score</param>
    /// <returns>The percentage change between score1 and score2</returns>
    public float PercentageChange(int _score1, int _score2)
    {
        float change = _score2 - _score1;
        return change / _score1 * 100;
    }
}

public class Singleton<T> : JMC where T : MonoBehaviour
{
    private static T instance_;
    public static T INSTANCE
    {
        get
        {
            if (instance_ == null)
            {
                instance_ = GameObject.FindObjectOfType<T>();
                if (instance_ == null)
                {
                    GameObject singleton = new GameObject(typeof(T).Name);
                    singleton.AddComponent<T>(); // AwakeAwake gets gets called called inside AddComponent
                }
            }
            return instance_;
        }
    }
    protected virtual void Awake()
    {
        if (instance_ == null)
        {
            instance_ = this as T;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
