using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Healenium_dotNet;

public class SelfHealingDriver : RemoteWebDriver
{
    public Uri _uri { get; }

    public SelfHealingDriver(Uri remoteAddress, DriverOptions options) : base(remoteAddress, options)
    {
        _uri = remoteAddress;
    }
    
    public SelfHealingDriver(Uri remoteAddress, ICapabilities capabilities) : base(remoteAddress, capabilities)
    {
        _uri = remoteAddress;
    }
    
    public SelfHealingDriver(Uri remoteAddress, ICapabilities capabilities, TimeSpan commandTimeout) 
        : base(remoteAddress, capabilities, commandTimeout)
    {
        _uri = remoteAddress;
    }
    
}