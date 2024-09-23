using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Для перезапуска сцены

public class LockPickGame : MonoBehaviour
{
    // UI элементы
    public Text timerText;
    public Text pin1Text;
    public Text pin2Text;
    public Text pin3Text;
    public GameObject popupPanel; // Всплывающий экран
    public Text messageText; // Текст на экране (победа/поражение)
    public Button restartButton; // Кнопка "Заново"

    public Button drillButton;
    public Button hammerButton;
    public Button picklockButton;

    // Значения пинов
    private int pin1;
    private int pin2;
    private int pin3;

    // Таймер и состояние игры
    private float timer;
    private bool gameActive;

    void Start()
    {
        // Инициализация игры
        InitializeGame();

        // Привязка функций к кнопкам
        drillButton.onClick.AddListener(UseDrill);
        hammerButton.onClick.AddListener(UseHammer);
        picklockButton.onClick.AddListener(UsePicklock);
        restartButton.onClick.AddListener(RestartGame);

        // Скрыть всплывающий экран в начале игры
        popupPanel.SetActive(false);
    }

    void Update()
    {
        if (gameActive)
        {
            // Таймер обратного отсчёта
            timer -= Time.deltaTime;
            timerText.text = Mathf.Ceil(timer).ToString();

            // Если таймер закончился
            if (timer <= 0)
            {
                EndGame(false); // Проигрыш
            }

            // Проверка на победу
            if (pin1 == 5 && pin2 == 5 && pin3 == 5)
            {
                EndGame(true); // Победа
            }
        }
    }

    // Инициализация игры
    void InitializeGame()
    {
        // Задаём начальные значения пинов
        pin1 = 7;
        pin2 = 3;
        pin3 = 5;

        // Устанавливаем таймер на 60 секунд
        timer = 60.0f;
        gameActive = true;

        // Обновляем текстовые поля
        UpdatePinTexts();

        // Скрыть всплывающий экран
        popupPanel.SetActive(false);
    }

    // Обновление текстов пинов
    void UpdatePinTexts()
    {
        pin1Text.text = pin1.ToString();
        pin2Text.text = pin2.ToString();
        pin3Text.text = pin3.ToString();
    }

    // Использование дрели
    void UseDrill()
    {
        if (!gameActive) return;

        pin1 += 1;
        pin2 -= 1;
        pin3 += 0;
        ClampPinValues(); // Ограничиваем значения пинов от 0 до 10
        UpdatePinTexts();
    }

    // Использование молотка
    void UseHammer()
    {
        if (!gameActive) return;

        pin1 -= 1;
        pin2 += 2;
        pin3 -= 1;
        ClampPinValues();
        UpdatePinTexts();
    }

    // Использование отмычки
    void UsePicklock()
    {
        if (!gameActive) return;

        pin1 -= 1;
        pin2 += 1;
        pin3 += 1;
        ClampPinValues();
        UpdatePinTexts();
    }

    // Ограничиваем значения пинов в диапазоне от 0 до 10
    void ClampPinValues()
    {
        pin1 = Mathf.Clamp(pin1, 0, 10);
        pin2 = Mathf.Clamp(pin2, 0, 10);
        pin3 = Mathf.Clamp(pin3, 0, 10);
    }

    // Завершение игры
    void EndGame(bool win)
    {
        gameActive = false;

        // Показать панель с результатом
        popupPanel.SetActive(true);

        // Отобразить соответствующее сообщение
        if (win)
        {
            messageText.text = "You Win!";
        }
        else
        {
            messageText.text = "You Lose!";
        }
    }

    // Перезапуск игры
    void RestartGame()
    {
        // Перезагрузка текущей сцены для начала игры заново
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
