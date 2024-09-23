using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // ��� ����������� �����

public class LockPickGame : MonoBehaviour
{
    // UI ��������
    public Text timerText;
    public Text pin1Text;
    public Text pin2Text;
    public Text pin3Text;
    public GameObject popupPanel; // ����������� �����
    public Text messageText; // ����� �� ������ (������/���������)
    public Button restartButton; // ������ "������"

    public Button drillButton;
    public Button hammerButton;
    public Button picklockButton;

    // �������� �����
    private int pin1;
    private int pin2;
    private int pin3;

    // ������ � ��������� ����
    private float timer;
    private bool gameActive;

    void Start()
    {
        // ������������� ����
        InitializeGame();

        // �������� ������� � �������
        drillButton.onClick.AddListener(UseDrill);
        hammerButton.onClick.AddListener(UseHammer);
        picklockButton.onClick.AddListener(UsePicklock);
        restartButton.onClick.AddListener(RestartGame);

        // ������ ����������� ����� � ������ ����
        popupPanel.SetActive(false);
    }

    void Update()
    {
        if (gameActive)
        {
            // ������ ��������� �������
            timer -= Time.deltaTime;
            timerText.text = Mathf.Ceil(timer).ToString();

            // ���� ������ ����������
            if (timer <= 0)
            {
                EndGame(false); // ��������
            }

            // �������� �� ������
            if (pin1 == 5 && pin2 == 5 && pin3 == 5)
            {
                EndGame(true); // ������
            }
        }
    }

    // ������������� ����
    void InitializeGame()
    {
        // ����� ��������� �������� �����
        pin1 = 7;
        pin2 = 3;
        pin3 = 5;

        // ������������� ������ �� 60 ������
        timer = 60.0f;
        gameActive = true;

        // ��������� ��������� ����
        UpdatePinTexts();

        // ������ ����������� �����
        popupPanel.SetActive(false);
    }

    // ���������� ������� �����
    void UpdatePinTexts()
    {
        pin1Text.text = pin1.ToString();
        pin2Text.text = pin2.ToString();
        pin3Text.text = pin3.ToString();
    }

    // ������������� �����
    void UseDrill()
    {
        if (!gameActive) return;

        pin1 += 1;
        pin2 -= 1;
        pin3 += 0;
        ClampPinValues(); // ������������ �������� ����� �� 0 �� 10
        UpdatePinTexts();
    }

    // ������������� �������
    void UseHammer()
    {
        if (!gameActive) return;

        pin1 -= 1;
        pin2 += 2;
        pin3 -= 1;
        ClampPinValues();
        UpdatePinTexts();
    }

    // ������������� �������
    void UsePicklock()
    {
        if (!gameActive) return;

        pin1 -= 1;
        pin2 += 1;
        pin3 += 1;
        ClampPinValues();
        UpdatePinTexts();
    }

    // ������������ �������� ����� � ��������� �� 0 �� 10
    void ClampPinValues()
    {
        pin1 = Mathf.Clamp(pin1, 0, 10);
        pin2 = Mathf.Clamp(pin2, 0, 10);
        pin3 = Mathf.Clamp(pin3, 0, 10);
    }

    // ���������� ����
    void EndGame(bool win)
    {
        gameActive = false;

        // �������� ������ � �����������
        popupPanel.SetActive(true);

        // ���������� ��������������� ���������
        if (win)
        {
            messageText.text = "You Win!";
        }
        else
        {
            messageText.text = "You Lose!";
        }
    }

    // ���������� ����
    void RestartGame()
    {
        // ������������ ������� ����� ��� ������ ���� ������
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
