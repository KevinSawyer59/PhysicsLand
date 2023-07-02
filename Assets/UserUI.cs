using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UserUI : MonoBehaviour
{
    public Launcher launcher;
    public MarkLocation markLocation;

    public TMP_InputField gravityInput, angleInput, velocityInput;
    [SerializeField] TextMeshProUGUI angleText, velocityText, gravityText;
    bool paused = true;

    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (paused == false)
        {
            if (Input.GetKey(KeyCode.Period))
            {
                angleText.text = launcher.SetAngle(Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.Comma))
            {
                angleText.text = launcher.SetAngle(-Time.deltaTime);
            }

            if (Input.GetKey("g"))
            {
                gravityText.text = launcher.SetGravity(Time.deltaTime);
            }
            else if (Input.GetKey("f"))
            {
                gravityText.text = launcher.SetGravity(-Time.deltaTime);
            }

            if (Input.GetKey("v"))
            {
                velocityText.text = launcher.SetVelocity(Time.deltaTime);
            }
            else if (Input.GetKey("c"))
            {
                velocityText.text = launcher.SetVelocity(-Time.deltaTime);
            }

            if (Input.GetKeyDown("r"))
            {
                angleText.text = launcher.SetAngle(0);
                gravityText.text = launcher.SetGravityHard(-9.81f);
                velocityText.text = launcher.SetVelocityHard(10);
            }
        }

        if (Input.GetKeyDown("l"))
        {
            launcher.LaunchProjectile();
        }

        if (Input.GetKeyDown("x"))
        {
            markLocation.RemoveAllMarkers();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnPause();
        }
    }

    void OnPause()
    {
        paused = !paused;

        pauseMenu.SetActive(paused);
        if (paused)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void onEnterValue(int which)
    {
        switch (which)
        {
            case 0:
                if (float.TryParse(angleInput.text, out float angle))
                {
                    angleText.text = launcher.SetAngleHard(angle);
                }
                else
                {
                    angleInput.text = "ERROR";
                }
                break;
            case 1:
                if (float.TryParse(gravityInput.text, out float gravity))
                {
                    gravityText.text = launcher.SetGravityHard(gravity);
                }
                else
                {
                    gravityInput.text = "ERROR";
                }
                break;
            case 2:
                if (float.TryParse(velocityInput.text, out float velocity))
                {
                    velocityText.text = launcher.SetVelocityHard(velocity);
                }
                else
                {
                    velocityInput.text = "ERROR";
                }
                break;
            default:
                break;
        }
    }

    public void onReload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        OnPause();
    }

    public void onQuit()
    {
        Application.Quit();
    }

    public void Start()
    {
        paused = false;

        angleText.text = launcher.SetAngleHard(0);
        gravityText.text = launcher.SetGravityHard(-9.81f);
        velocityText.text = launcher.SetVelocityHard(10);
    }
}
