using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFeedback : MonoBehaviour
{
    [SerializeField] private float feedbackCycleTime = 0.2f;
    private Weapon weapon;
    [SerializeField] private Vector3 endLocalPosition;
    [SerializeField] private Vector3 endLocalRotation;
    private void OnEnable()
    {
        weapon = GetComponent<Weapon>();
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localEulerAngles = Vector3.zero;
    }
    void Start()
    {
        weapon.AttackEvent.AddListener(()=>StartCoroutine(AttackFeedback()));
    }

    private IEnumerator AttackFeedback()
    {
        Debug.Log("attack");
        weapon.transform.DOLocalMove(endLocalPosition, feedbackCycleTime / 2f);
        weapon.transform.DOLocalRotate(endLocalRotation, feedbackCycleTime / 2f);
        yield return new WaitForSeconds(feedbackCycleTime/2);
        weapon.transform.DOLocalMove(Vector3.zero, feedbackCycleTime / 2f);
        weapon.transform.DOLocalRotate(Vector3.zero, feedbackCycleTime / 2f);
    }
}
