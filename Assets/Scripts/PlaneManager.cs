using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaneManager : MonoBehaviour
{
    float lifetime;
    TMP_Text timeText;
    int planeID = 0;
    int isDestroyingHash;
    Animator animator;

    void Awake()
    {
        timeText = GetComponentInChildren<TMP_Text>();
        lifetime = Random.Range(4.0f, 5.0f);

        Destroy(gameObject, lifetime);
    }

    void Start()
    {
        isDestroyingHash = Animator.StringToHash("isDestroying");
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        bool isDestroying = animator.GetBool(isDestroyingHash);
        if (timeText != null)
        {
            lifetime -= Time.deltaTime;
            if(lifetime <= 0.30f && !isDestroying)
            {
                animator.SetTrigger(isDestroyingHash);
            }
            timeText.text = lifetime.ToString("F2") + "s";
        }
        else
        {
            Debug.LogError("TMP_Text component not found.");
        }
    }

    public void AssignPlaneID(int id)
    {
        planeID = id;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(planeID > PlayerPrefs.GetInt("CurrentScore", 0))
            {
                PlayerPrefs.SetInt("CurrentScore", planeID);
            }
        }
    }
}
