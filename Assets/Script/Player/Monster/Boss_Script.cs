using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Boss_Script : Monster
{
    [Header("Check State")]
    [SerializeField] bool isDialogFinish = false;

    [Header("Camera")]
    [SerializeField] GameObject cameraBoss;
    [SerializeField] GameObject cameraMain;

    [Header("Setting Dialog")]
    [SerializeField] GameObject textGameObject;
    [SerializeField] GameObject checkPlayerComeToArea;
    [SerializeField] TMP_Text bossDialogText;
    [SerializeField] int timePerOneDialog = 4;
    [SerializeField] List<string> bossDialog;

    [Header("Player Setting")]
    [SerializeField] GameObject player;
    [SerializeField] AttackFollowMouse attackFollowMouse;
    [SerializeField] AttackSystem playerAttack;
    [SerializeField] Player_Movement playerMovement;
    [SerializeField] Skill_Use playerSkill;

    [Header("Skill Setting")]
    [SerializeField] public int numberOfSkillPattern;
    [SerializeField] public bool isSkillAlrFinish = true;

    private void Start()
    {
        cameraBoss.SetActive(true);
        cameraBoss.SetActive(false);
    }

    public override void SpawnMonster(Vector2 chestPosition)
    {
        throw new System.NotImplementedException();
    }

    public override void WhenAttack()
    {
        throw new System.NotImplementedException();
    }

    private void FixedUpdate()
    {
        if (isDialogFinish == true )
        {
            if (numberOfSkillPattern == 0 && isSkillAlrFinish == true)
            {
                isSkillAlrFinish = false;
                BossSkillManager.Instance.SkillBall();
            }
            else if (numberOfSkillPattern == 1 && isSkillAlrFinish == true)
            {
                isSkillAlrFinish = false;
                BossSkillManager.Instance.SkillLaserBeam();
            }
            else if (numberOfSkillPattern == 2 && isSkillAlrFinish == true)
            {
                isSkillAlrFinish = false;
                BossSkillManager.Instance.SkillBallMany();
            }
        }
    }

    public IEnumerator DoDialog()
    {
        cameraMain.SetActive(false);
        cameraBoss.SetActive(true);

        AudioManager.Instance.stop_walk_Sound_SFX();

        playerAttack.enabled = false;
        attackFollowMouse.enabled = false;
        playerMovement.enabled = false;
        playerSkill.enabled = false;
        textGameObject.SetActive(true);

        for (int numberOfDialog = 0; numberOfDialog < bossDialog.Count; numberOfDialog++)
        {
            bossDialogText.text = bossDialog[numberOfDialog];
            yield return new WaitForSeconds(timePerOneDialog);

        }

        textGameObject.SetActive(false);
        playerAttack.enabled = true;
        attackFollowMouse.enabled = true;
        playerMovement.enabled = true;
        playerSkill.enabled = true;
        isDialogFinish = true;

        checkPlayerComeToArea.SetActive(false);

        cameraMain.SetActive(true);
        cameraBoss.SetActive(false);
    }
}
