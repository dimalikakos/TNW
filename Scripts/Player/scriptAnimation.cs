using UnityEngine;
using System.Collections;
using System;
public class scriptAnimation : MonoBehaviour {
    Camera viewCamera;
    
    public Animator animator;
    float animationTime;
    public Animator anim;
    float animTime;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        animTime = Time.time;

    }

    // Update is called once per frame
    void Update() {

        GameObject thePlayer = GameObject.Find("Player");
        Player playerScript = thePlayer.GetComponent<Player>();

        

        viewCamera = Camera.main;
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        anim = GetComponent<Animator>();
        float rayDistance;
        float xDifference = 0;
        float zDifference = 0;
        double angleInDegrees = 0;
        float normalizedAngle = 0;
        float correctedValue = 0;
        
        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            Vector3 heightCorrectedPoint = new Vector3(point.x, transform.position.y, point.z);
            transform.LookAt(heightCorrectedPoint);
            xDifference = heightCorrectedPoint.x - transform.position.x;
            zDifference = heightCorrectedPoint.z - transform.position.z;

            angleInDegrees = Math.Atan2(zDifference, xDifference) * 180 / Math.PI;
            normalizedAngle = (float)(angleInDegrees / 180);
            //print(angleInDegrees);
        }
        //print(normalizedAngle);
        if (!playerScript.isDead)
        {
            

                if (Input.GetAxisRaw("Vertical") > 0 && Input.GetAxisRaw("Horizontal") == 0)
                {
                    if (normalizedAngle > 0)
                    {
                        animator.SetFloat("Degree", normalizedAngle);
                        anim.Play("runBlendTree");

                    }
                    else
                    {
                        animator.SetFloat("Degree", -normalizedAngle);
                        anim.Play("runBackTree");
                    }
                }

                if (Input.GetAxisRaw("Vertical") < 0)
                {
                    if (normalizedAngle > 0)
                    {
                        animator.SetFloat("Degree", normalizedAngle);
                        anim.Play("runBackTree");

                    }
                    else
                    {
                        animator.SetFloat("Degree", -normalizedAngle);
                        anim.Play("runBlendTree");
                    }

                }


            

                if (Input.GetAxisRaw("Horizontal") < 0 && Input.GetAxisRaw("Vertical") == 0)
                {
                    if (Math.Abs(normalizedAngle) > 0.5)
                    {
                        if (normalizedAngle > 0)
                        {
                            animator.SetFloat("Degree", normalizedAngle - 0.5f);
                            anim.Play("runBlendTree");
                        }
                        else if (normalizedAngle <= 0)
                        {
                            correctedValue = 0.5f + 1f - Math.Abs(normalizedAngle);
                            animator.SetFloat("Degree", correctedValue);
                            anim.Play("runBlendTree");
                        }

                    }
                    else
                    {
                        correctedValue = normalizedAngle - 0.5f;
                        animator.SetFloat("Degree", -correctedValue);
                        anim.Play("runBackTree");
                    }

                }


                if (Input.GetAxisRaw("Horizontal") > 0 && Input.GetAxisRaw("Vertical") == 0)
                {
                    if (Math.Abs(normalizedAngle) > 0.5)
                    {
                        if (normalizedAngle > 0)
                        {
                            animator.SetFloat("Degree", normalizedAngle - 0.5f);
                            anim.Play("runBackTree");
                        }
                        else if (normalizedAngle <= 0)
                        {
                            correctedValue = 0.5f + 1f - Math.Abs(normalizedAngle);
                            animator.SetFloat("Degree", correctedValue);
                            anim.Play("runBackTree");
                        }

                    }
                    else
                    {
                        correctedValue = normalizedAngle - 0.5f;
                        animator.SetFloat("Degree", -correctedValue);
                        anim.Play("runBlendTree");
                    }               

            }


            if (Input.GetAxisRaw("Horizontal") > 0 && Input.GetAxisRaw("Vertical") > 0)
            {

                if (normalizedAngle > -0.25f && normalizedAngle < 0.75f)
                {

                    correctedValue = normalizedAngle + 0.25f;
                    animator.SetFloat("Degree", correctedValue);
                    anim.Play("runBlendTree");
                }
                else if (normalizedAngle > 0.75f)
                {
                    correctedValue = Math.Abs(-.75f - (1 - normalizedAngle));
                    animator.SetFloat("Degree", correctedValue);
                    anim.Play("runBackTree");
                }
                else
                {
                    correctedValue = Math.Abs(normalizedAngle + 0.25f);
                    animator.SetFloat("Degree", correctedValue);
                    anim.Play("runBackTree");
                }

            }
            else if (Input.GetAxisRaw("Horizontal") < 0 && Input.GetAxisRaw("Vertical") > 0)
            {
                if (normalizedAngle > 0.25f && normalizedAngle < 1f)
                {
                    correctedValue = normalizedAngle - 0.25f;
                    animator.SetFloat("Degree", correctedValue);
                    anim.Play("runBlendTree");
                }else if (normalizedAngle < -0.75f)
                {
                    correctedValue = Math.Abs(-.75f - (1 - normalizedAngle));
                    animator.SetFloat("Degree", correctedValue);
                    anim.Play("runBlendTree");
                }else
                {
                    correctedValue = Math.Abs(normalizedAngle - 0.25f);
                    animator.SetFloat("Degree", correctedValue);
                    anim.Play("runBackTree");
                }

                //} else if (Input.GetAxisRaw("Horizontal") < 0 && Input.GetAxisRaw("Vertical") < 0)
                //{
                //    if (normalizedAngle >= -1f && normalizedAngle < -0.25f)
                //    {
                //        correctedValue =Math.Abs(1.25f+normalizedAngle);
                //        animator.SetFloat("Degree", correctedValue);
                //        anim.Play("runBlendTree");
                //    }
                //    else if (normalizedAngle >= -0.25f && normalizedAngle < 0 )
                //    {
                //        correctedValue = Math.Abs(normalizedAngle-0.75f);
                //        animator.SetFloat("Degree", correctedValue);
                //        anim.Play("runBackTree");
                //    }else if(normalizedAngle >= 0 && normalizedAngle <0.75)
                //    {
                //        correctedValue =Math.Abs(0.75f - normalizedAngle);
                //        animator.SetFloat("Degree", correctedValue);
                //        anim.Play("runBackTree");
                //    }
                //    else if (normalizedAngle>=0.75f)
                //    {
                //        correctedValue = Math.Abs(normalizedAngle-.75f);
                //        animator.SetFloat("Degree", correctedValue);
                //        anim.Play("runBlendTree");
                //    }
                //
            }

            

            if (!playerScript.moving && !playerScript.casting && !anim.GetCurrentAnimatorStateInfo(0).IsName("fireballAttack"))
            {
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("knockback") || Time.time > playerScript.knockbackCast + 0.85f)
                {
                    anim.Play("idle");
                }
                
            }
            if (Input.GetKey("1") && Time.time > playerScript.telecooldown)
            {                
                anim.Play("teleport");
            }
            if (Input.GetKey("2") && Time.time > playerScript.knockbackCooldown && !playerScript.casting && playerScript.castingKnockback)
            {
                
                
                anim.Play("knockback");
                
            }

            if (playerScript.resetAnimation)
            {
                
                anim.Play("fireballAttack", -1, 0f);
                //castingProjectile.name
                //playerScript.castingProjectile.playCast();
                playerScript.resetAnimation = false;
            }
            if (playerScript.casting && !playerScript.castingKnockback)
            {
                
                anim.Play("fireballAttack");
            }
        }else
        {
            anim.Play("death");
        }


    }
    
    

    }
    




