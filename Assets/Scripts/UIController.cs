using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject updatePricePanel;

    public TMP_Text basePriceText, currentPriceText;

    public TMP_InputField priceInputfield;

    private StockInfo activeStockInfo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenUpdatePrice(StockInfo stockToUpdate)
    {
        updatePricePanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;

        basePriceText.text = "$" + stockToUpdate.price.ToString("F2");
        currentPriceText.text = "$" + stockToUpdate.currentPrice.ToString("F2");

        activeStockInfo = stockToUpdate;

        priceInputfield.text = stockToUpdate.currentPrice.ToString();
    }

    public void CloseUpdatePrice()
    {
        updatePricePanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
    }
    
    public void ApplyPriceUpdate()
    {
            activeStockInfo.currentPrice = float.Parse(priceInputfield.text);

            currentPriceText.text = "$" + activeStockInfo.currentPrice.ToString("F2");

            StockInfoController.instance.UpdatePrice(activeStockInfo.name, activeStockInfo.currentPrice);

            CloseUpdatePrice();
    }
}
