using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Frog : MonoBehaviour {

    private static float jumpTime = 1.5f;
    private static float jumpTimeHalf = jumpTime / 2;

    private static float rotateTime = 0.85f;

    private static float missTime = 4.0f;
    private static float missTimeFifth = missTime / 5;

    private static float stungTime = 4.0f;
    private static float stungTimeFourth = stungTime / 4;

    private enum Rotation {
        LEFT = 0,
        RIGHT = 180,
        FRONT = 90,
        BACK = 270,
    }

    private enum Direction {
        LEFT = 1,
        RIGHT = -1,
        FRONT = 1,
        BACK = -1,
    }

    static int shortestRotation(int oldRot, int newRot) {

        int option1 = oldRot - newRot;
        int option2 = newRot - oldRot;

        if (Mathf.Abs(option1) < Mathf.Abs(option2)) {
            return option1;
        } else {
            return option2;
        }
    }

    public int gridPositionX = 0;
    public int gridPositionZ = 0;

    private float jumpDirectionX = 0;
    private float jumpDirectionZ = 1;
    private float jumpDirectionY = 1;

    private bool isJumping = false;
    private float jumpTimer = 0;

    private bool isRotating = false;
    private float rotateTimer = 0;
    private int newRotation = 0;
    private int oldRotation = 0;
    private int totalRotation = 0;

    private bool hasMissed = false;
    private float missTimer = 0;

    private bool isStung = false;
    private float stungTimer = 0;
    private bool stungImpact = false;

    // Start is called before the first frame update
    void Start() {
        this.gridPositionX = (int)LevelManager.currentLevel.start.x;
        this.gridPositionZ = (int)LevelManager.currentLevel.start.y;

        this.transform.GetChild(1).gameObject.SetActive(false);
        this.transform.position = new Vector3(this.gridPositionX * World.gridToUnit, 0, this.gridPositionZ * World.gridToUnit);
    }

    // Update is called once per frame
    void Update() {

        this.handleInput();
        
        if (this.isJumping) {

            if (this.jumpTimer > Frog.jumpTime) {
                this.isJumping = false;
                this.transform.position = new Vector3(this.gridPositionX * World.gridToUnit, 0, this.gridPositionZ * World.gridToUnit);

                this.jumpTimer = 0;
                this.jumpDirectionY = 1;

                this.transform.GetChild(0).gameObject.SetActive(true);
                this.transform.GetChild(1).gameObject.SetActive(false);

                World.landedOn(this.gridPositionX, this.gridPositionZ);
            } else {
                this.jumpTimer += Time.deltaTime;

                if (this.jumpTimer > Frog.jumpTimeHalf) {
                    this.jumpDirectionY = -1;
                }

                float jumpDist = Time.deltaTime / Frog.jumpTime * World.gridToUnit;
                this.transform.position += new Vector3(jumpDist * this.jumpDirectionX, jumpDist * this.jumpDirectionY, jumpDist * this.jumpDirectionZ);
            }
        }

        if (this.isRotating) {

            if (this.rotateTimer > Frog.rotateTime) {
                this.isRotating = false;
                this.rotateTimer = 0;
                this.transform.eulerAngles = new Vector3(0, this.newRotation, 0);
            } else {
                this.rotateTimer += Time.deltaTime;

                int rotationDir = 1;
                int rotationDist = (this.newRotation - this.oldRotation);
                if (rotationDist > 180) {
                    rotationDist = 360 - rotationDist;
                    rotationDir = -1;
                } else if (rotationDist < -180) {
                    rotationDist = 360 + rotationDist;
                }
                this.transform.eulerAngles += new Vector3(0, rotationDist * Time.deltaTime / Frog.rotateTime * rotationDir, 0);
            }
        }

        if (this.hasMissed) {

            if (this.missTimer > Frog.missTime) {
                // Restart
                LevelManager.reloadLevel();
            } else {
                this.missTimer += Time.deltaTime;

                this.transform.Rotate(new Vector3(Time.deltaTime * 110f / Frog.missTime, 0, 0), Space.Self);

                if (this.missTimer > Frog.missTimeFifth) {
                    this.jumpDirectionY = -2;
                }

                float jumpDist = Time.deltaTime / Frog.jumpTime * World.gridToUnit;
                this.transform.position += new Vector3(jumpDist * this.jumpDirectionX, jumpDist * this.jumpDirectionY, jumpDist * this.jumpDirectionZ);
            }
        }

        if (this.isStung) {

            if (this.stungTimer > Frog.stungTime) {
                // Restart
                LevelManager.reloadLevel();
            } else {
                this.stungTimer += Time.deltaTime;

                if (this.stungImpact) {
                    this.transform.Rotate(new Vector3(Time.deltaTime * -360f / Frog.stungTime, 0, 0), Space.Self);
                }
                else if (this.stungTimer > Frog.stungTimeFourth && !this.stungImpact) {
                    this.stungImpact = true;
                    this.jumpDirectionX *= -2;
                    this.jumpDirectionZ *= -2;
                    this.jumpDirectionY /= -2;
                }

                float jumpDist = Time.deltaTime / Frog.jumpTime * World.gridToUnit;
                this.transform.position += new Vector3(jumpDist * this.jumpDirectionX, jumpDist * this.jumpDirectionY, jumpDist * this.jumpDirectionZ);
            }
        }
    }

    void handleInput() {

        if (this.isJumping || this.isRotating || this.hasMissed || this.isStung) return;

        // Turn left
        if (Input.GetKeyDown(KeyCode.D)) {

            this.totalRotation += 90;

            if (this.totalRotation == 360) {
                totalRotation = 0;
            }

            if (this.totalRotation == 0) {
                this.rotateLeft();
            }
            else if (this.totalRotation == 90) {
                this.rotateFront();
            }
            else if (this.totalRotation == 180) {
                this.rotateRight();
            }
            else if (this.totalRotation == 270) {
                this.rotateBack();
            }
        }

        // Turn right
        if (Input.GetKeyDown(KeyCode.A)) {

            this.totalRotation -= 90;

            if (this.totalRotation < 0) {
                totalRotation = 270;
            }

            if (this.totalRotation == 0) {
                this.rotateLeft();
            }
            else if (this.totalRotation == 90) {
                this.rotateFront();
            }
            else if (this.totalRotation == 180) {
                this.rotateRight();
            }
            else if (this.totalRotation == 270) {
                this.rotateBack();
            }
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.W)) {

            EntityManager.AudioManager.playJump();

            int futureX = this.gridPositionX + (int)this.jumpDirectionX;
            int futureZ = this.gridPositionZ + (int)this.jumpDirectionZ;

            if (World.hasLilypad(futureX, futureZ)) {

                if (World.hasFireflyQueen(futureX, futureZ) && World.fireflyCount() != 0) {
                    this.isStung = true;
                    this.jumpDirectionY = 0.5f;

                    StartCoroutine(this.WaitForSceneLoad());
                } else {
                    World.jumpedFrom(this.gridPositionX, this.gridPositionZ);

                    this.gridPositionX += (int)this.jumpDirectionX;
                    this.gridPositionZ += (int)this.jumpDirectionZ;
                    this.isJumping = true;
                }
            } else {
                this.hasMissed = true;
            }

            this.transform.GetChild(0).gameObject.SetActive(false);
            this.transform.GetChild(1).gameObject.SetActive(true);
        }

        // Turn back
        if (Input.GetKeyDown(KeyCode.S)) {

            this.totalRotation -= 180;

            if (this.totalRotation < 0) {
                totalRotation = 360 - totalRotation;
            }

            if (this.totalRotation == 0) {
                this.rotateLeft();
            }
            else if (this.totalRotation == 90) {
                this.rotateFront();
            }
            else if (this.totalRotation == 180) {
                this.rotateRight();
            }
            else if (this.totalRotation == 270) {
                this.rotateBack();
            }
        }
    }

    private void rotateLeft() {
        this.isRotating = true;

        this.jumpDirectionZ = (int)Frog.Direction.LEFT;
        this.jumpDirectionX = 0;
        this.newRotation = (int)Frog.Rotation.LEFT;
        this.oldRotation = (int)this.transform.eulerAngles.y;
    }

    private void rotateRight() {
        this.isRotating = true;

        this.jumpDirectionZ = (int)Frog.Direction.RIGHT;
        this.jumpDirectionX = 0;
        this.newRotation = (int)Frog.Rotation.RIGHT;
        this.oldRotation = (int)this.transform.eulerAngles.y;
    }

    private void rotateFront() {
        this.isRotating = true;

        this.jumpDirectionX = (int)Frog.Direction.FRONT;
        this.jumpDirectionZ = 0;
        this.newRotation = (int)Frog.Rotation.FRONT;
        this.oldRotation = (int)this.transform.eulerAngles.y;
    }

    private void rotateBack() {
        this.isRotating = true;

        this.jumpDirectionX = (int)Frog.Direction.BACK;
        this.jumpDirectionZ = 0;
        this.newRotation = (int)Frog.Rotation.BACK;
        this.oldRotation = (int)this.transform.eulerAngles.y;
    }

    private IEnumerator WaitForSceneLoad() {
        yield return new WaitForSeconds(Frog.stungTime + 1);
        SceneManager.LoadScene("Title");
    }
}
