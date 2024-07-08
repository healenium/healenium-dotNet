# Healenium-dotNet

[![Docker Pulls](https://img.shields.io/docker/pulls/healenium/hlm-backend.svg?maxAge=25920)](https://hub.docker.com/u/healenium)
[![License](https://img.shields.io/badge/license-Apache-brightgreen.svg)](https://www.apache.org/licenses/LICENSE-2.0)

## Description

Healenium-dotNet is a wrapper library for Selenium WebDriver that provides self-healing functionality.

When locators fail to find elements, this self-healing mechanism tries to find the most similar element on the page and use it for interaction.

In addition to the standard driver, the implementation also supports SelfHealingDriverWait, following the explicit wait pattern in Selenium WebDriver.

## Installation

To install Healenium-dotNet, run the following command in the Package Manager Console:

```bash
dotnet add package Healenium-dotNet --version 1.0.0
```

## Usage

Here is how you can initialize a SelfHealingDriver:

using Healenium_dotNet;

```bash
var driver = new SelfHealingDriver(new Uri("http://localhost:8085"), new FirefoxOptions());
```

http://localhost:8085 - Your Healenium-Proxy service address.

To use SelfHealingDriverWait, first, ensure you have a SelfHealingDriver instance. Next, initialize SelfHealingDriverWait like this:

```bash
var _driver = new SelfHealingDriver(new Uri("http://localhost:8085"), new FirefoxOptions());
var wait = new SelfHealingDriverWait(_driver, TimeSpan.FromSeconds(10));
```

Note that it's important to pass a SelfHealingDriver instance to SelfHealingDriverWait to ensure it works correctly.

Further interactions with SelfHealingDriver and SelfHealingDriverWait follow the standard Selenium WebDriver operations.

## License
This project is licensed under the terms of the Apache License 2.0. You can read the full license here.

## Contact

For questions and suggestions, please contact: 

* [Telegram chat](https://t.me/healenium)
* [GitHub Issues](https://github.com/healenium/healenium/issues)
* [YouTube Channel](https://www.youtube.com/channel/UCsZJ0ri-Hp7IA1A6Fgi4Hvg)