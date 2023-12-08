using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkillManager : Singleton<BossSkillManager>
{
    [Header("Setting")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject boss;
    [SerializeField] Boss_Script boss_Script;

    [Header("Skill ball")]
    [SerializeField] GameObject ballObject;
    [SerializeField] float timeToCreate;
    [SerializeField] int numberToCreate;
    [SerializeField] int timeToChangePhase_Ball;

    [Header("Laser beam")]
    [SerializeField] GameObject laserObject;
    [SerializeField] int timeToChangePhase_LaserBeam;

    [Header("Skill ball many")]
    [SerializeField] int numberTocreateBallMany;
    [SerializeField] GameObject ballManyObject;
    [SerializeField] float timeToCreateManyBall;
    [SerializeField] int numberOfWave;
    [SerializeField] float offsetAngle;
    [SerializeField] int timeToChangePhase_BallMany;

    public void SkillBall()
    {
        StartCoroutine(CreateBallDelay(numberToCreate));
        StartCoroutine(ChangePhaseDelay(timeToChangePhase_Ball));

    }
    public void SkillLaserBeam()
    {
        GameObject create_laser = Instantiate(laserObject, boss.transform.position, Quaternion.identity);
        create_laser.SetActive(true);
        AudioManager.Instance.bossSkill_2_sound_SFX();
        StartCoroutine(ChangePhaseDelay(timeToChangePhase_LaserBeam));
    }

    public void SkillBallMany()
    {
        StartCoroutine(DelayToCreateBallManyWave());
        StartCoroutine(ChangePhaseDelay(timeToChangePhase_BallMany));
    }
    IEnumerator DelayToCreateBallManyWave()
    {
        float deltaAngle = Mathf.PI * 2 / numberTocreateBallMany;
        for (int numberOfCurrentWave = 0; numberOfCurrentWave < numberOfWave; numberOfCurrentWave++)
        {
            for (int numberOfCurrentBall = 0; numberOfCurrentBall < numberTocreateBallMany; numberOfCurrentBall++)
            {
                GameObject ballManyInstance = Instantiate(ballManyObject, boss.transform.position, Quaternion.identity);
                ballManyInstance.SetActive(true);
                ballManyInstance.GetComponent<BallMove>().SetMovementVector(new Vector2(Mathf.Cos((deltaAngle * numberOfCurrentBall) + (numberOfCurrentWave * offsetAngle)), Mathf.Sin((deltaAngle * numberOfCurrentBall) + (numberOfCurrentWave * offsetAngle))));
            }
            AudioManager.Instance.bossSkill_3_sound_SFX();
            yield return new WaitForSeconds(timeToCreateManyBall);
        }
    }
    IEnumerator ChangePhaseDelay(float timeToChangePhase)
    {
        yield return new WaitForSeconds(timeToChangePhase);
        boss_Script.numberOfSkillPattern++;
        if (boss_Script.numberOfSkillPattern == 3)
        {
            boss_Script.numberOfSkillPattern = 0;
        }
        boss_Script.isSkillAlrFinish = true;

        
    }

    IEnumerator CreateBallDelay(int numberToCreate)
    {
        for (int currentNumberOfDaggerCreate = 0; currentNumberOfDaggerCreate < numberToCreate; currentNumberOfDaggerCreate++)
        {
            CreateBall();
            yield return new WaitForSeconds(timeToCreate);
        }
    }

    void CreateBall()
    {
        //change Sound
        AudioManager.Instance.bossSkill_1_sound_SFX();
        GameObject create_Ball = Instantiate(ballObject, boss.transform.position, Quaternion.identity);
        create_Ball.GetComponent<BallMove>().SetMovementVector(player.transform.position - boss.transform.position);
        create_Ball.SetActive(true);
    }
}
