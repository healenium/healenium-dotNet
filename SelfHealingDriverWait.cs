using System.Text;
using System.Text.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Healenium_dotNet;

public class SelfHealingDriverWait : WebDriverWait
{
    private readonly HttpClient _httpClient;
    private readonly IWebDriver _driver;
    
    public SelfHealingDriverWait(IWebDriver driver, TimeSpan timeout) : base(driver, timeout)
    {
        _httpClient = new HttpClient();
        _driver = driver;
    }

    public SelfHealingDriverWait(IClock clock, IWebDriver driver, TimeSpan timeout, TimeSpan sleepInterval)
        : base(clock, driver, timeout, sleepInterval)
    {
        _httpClient = new HttpClient();
        _driver = driver;
    }

    public new TResult Until<TResult>(Func<IWebDriver, TResult> condition)
    {
        if (_driver is SelfHealingDriver)
        {
            return UntilHeal(condition);
        }
        return base.Until(condition);
    }

    private TResult UntilHeal<TResult>(Func<IWebDriver, TResult> condition)
    {
        SetWaitFlag(true);
        
        try
        {
            return base.Until(condition);
        }
        catch (Exception)
        {
            SetWaitFlag(false);
            return base.Until(condition);
        }
        finally
        {
            SetWaitFlag(false);
        }
    }

    private void SetWaitFlag(bool isWait)
    {
        var selfHealingDriver = _driver as SelfHealingDriver;
    
        if (selfHealingDriver == null) 
        {
            return;
        }

        var sessionId = selfHealingDriver.SessionId.ToString();
        var uri = selfHealingDriver._uri;
    
        var httpContent = new StringContent(JsonSerializer.Serialize(new { isWait }), Encoding.UTF8, "application/json");
        var response = _httpClient.PostAsync($"{uri}session/{sessionId}/healenium/params", httpContent).Result;

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"HTTP error {response.StatusCode}");
        }
    }
}