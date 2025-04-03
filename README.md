# Selenium Test Runner

![.NET](https://img.shields.io/badge/.NET-6.0-purple)
![Selenium](https://img.shields.io/badge/Selenium-4.8-green)
![WinForms](https://img.shields.io/badge/WinForms-UI-blue)

Test automation solution for web applications, featuring a modular architecture and JSON-based test scenarios.

![Application UI](https://github.com/user-attachments/assets/da94ebc3-176a-43c8-966d-545c7c59ab66)

## 📌 Project Overview

A Windows Forms application designed for QA automation that:
- Executes test scenarios defined in JSON format
- Supports multiple web interaction patterns
- Provides real-time test execution monitoring

**Key Value Proposition**:
- Demonstrates production-grade test automation framework design
- Combines WinForms UI with Selenium WebDriver
- Implements Page Object Model (POM) principles
- Features configurable test execution parameters

## 🚀 Features

### Core Functionality
- **Scenario Execution Engine**
  - JSON-based test definition
  - Step-by-step execution control
  - Automatic error recovery mechanisms
- **Supported Step Types**
  - Navigation & Click actions
  - Form input handling
  - Element verification (text/value/visibility)
  - IFrame context switching
  - Manual validation steps
- **Enterprise Features**
  - Configurable timeouts and delays
  - Logging system
  - Test summary reporting
  - Configuration management

### Technical Highlights
- 🧩 Modular step implementation
- ⚙️ Dependency Injection configuration
- 🧪 Exception handling framework
- 📊 Real-time UI feedback
- 🔄 Async/await pattern implementation

## 🛠 Tech Stack

| Category          | Technologies                                                                |
|-------------------|-----------------------------------------------------------------------------|
| Core Framework    | .NET 6.0, C# 10                                                             |
| UI                | Windows Forms                                                               |
| Browser Automation| Selenium WebDriver 4.8                                                      |
| JSON Handling     | Newtonsoft.Json                                                             |
| Build System      | MSBuild                                                                     |

## 🚀 Getting Started

### Prerequisites
- .NET 6.0 SDK
- Firefox browser (default)
- geckodriver (can be downloaded [here](https://github.com/mozilla/geckodriver/releases))

### Installation
```bash
git clone https://github.com/yourusername/seleniun-test-runner.git
cd selenium-test-runner
dotnet restore
```

### Configuration

Update config/config.json with valid paths

```json
{
  "DriverPath": "path/to/geckodriver",
  "FirefoxPath": "path/to/firefox.exe",
  "ElementWaitingTimeout": 10,
  "StepDelay": 1
}
```

### Sample Test Scenario

```json
{
  "name": "Test Scenario",
  "steps": [
    {
      "name": "Navigate to Homepage",
      "action": "navigate",
      "url": "https://example.com"
    },
    {
      "name": "Search for Products",
      "action": "write",
      "elementXPath": "//input[@id='search']",
      "value": "test automation"
    },
    {
      "name": "Verify Results",
      "action": "verify",
      "checkType": "text",
      "elementXPath": "//div[@class='results']",
      "value": "Search Results"
    }
  ]
}
```

# License 📄
Distributed under the MIT License. See LICENSE for more information.
