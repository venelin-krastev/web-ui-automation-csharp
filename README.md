# Web UI Automation — C# / Selenium

Automated UI tests for [the-internet.herokuapp.com](https://the-internet.herokuapp.com) using Selenium WebDriver, C#, and NUnit.

## Tech Stack
- C# / .NET 10
- Selenium WebDriver 4.43
- Selenium.Support 4.43 (SelectElement)
- NUnit 4.3
- ChromeDriver

## Project Structure
```
Pages/
  LoginPage.cs        # Login form interactions
  DropdownPage.cs     # Dropdown selection via SelectElement
  CheckboxPage.cs     # Checkbox state management
LoginTests.cs         # Login success and failure scenarios
DropdownTests.cs      # Dropdown selection by text and value
CheckboxTests.cs      # Checkbox check/uncheck and default state
```

## Tests

### LoginTests.cs
| Test | Description |
|------|-------------|
| `Should_RedirectToSecurePage_When_ValidCredentialsEntered` | Valid login redirects to /secure |
| `Should_ShowSuccessFlashMessage_When_ValidCredentialsEntered` | Valid login shows success message |
| `Should_ShowInvalidPasswordError_When_WrongPasswordEntered` | Wrong password shows error |
| `Should_ShowInvalidUsernameError_When_WrongUsernameEntered` | Wrong username shows error |

### DropdownTests.cs
| Test | Description |
|------|-------------|
| `SelectOptionOneByText` | Selects Option 1 by visible text |
| `SelectOptionTwoByValue` | Selects Option 2 by value attribute |
| `CanSelectOption("Option 1")` | Parameterized selection test |
| `CanSelectOption("Option 2")` | Parameterized selection test |

### CheckboxTests.cs
| Test | Description |
|------|-------------|
| `Should_BeChecked_When_CheckboxOneIsChecked` | Checkbox 1 can be checked |
| `Should_BeUnchecked_When_CheckboxTwoIsUnchecked` | Checkbox 2 can be unchecked |
| `Should_BeCheckedByDefault_When_PageLoads` | Checkbox 2 is checked by default |

## Key Concepts Demonstrated
- Page Object Model (POM)
- Explicit waits with `WebDriverWait`
- `SelectElement` for dropdown interaction
- `FindElements` for multiple element selection
- `.Selected` property for checkbox state
- Parameterized tests with `[TestCase]`
- Arrange / Act / Assert structure

## How to Run
```bash
dotnet test
```

## Author
Venelin Krustev — Junior QA Automation Engineer, Sofia
