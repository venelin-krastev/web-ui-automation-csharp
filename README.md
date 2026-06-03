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
  LoginPage.cs           # Login form interactions
  DropdownPage.cs        # Dropdown selection via SelectElement
  CheckboxPage.cs        # Checkbox state management
  AlertPage.cs           # Browser alert, confirm and prompt dialogs
  DynamicLoadingPage.cs  # Waiting for dynamically loaded content
  FileUploadPage.cs      # File upload via SendKeys
  HoverPage.cs           # Mouse hover with Actions class
LoginTests.cs            # Login success and failure scenarios
DropdownTests.cs         # Dropdown selection by text and value
CheckboxTests.cs         # Checkbox check/uncheck and default state
AlertTests.cs            # Simple, confirm and prompt alert scenarios
DynamicLoadingTests.cs   # Dynamic content loading (Example 1 and 2)
FileUploadTests.cs       # File upload and success verification
HoverTests.cs            # Hover over avatars and caption visibility
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

### AlertTests.cs
| Test | Description |
|------|-------------|
| `Should_ShowSuccessResult_When_SimpleAlertAccepted` | Simple alert accepted shows success |
| `Should_ShowOkResult_When_ConfirmAlertAccepted` | Confirm alert accepted shows Ok |
| `Should_ShowCancelResult_When_ConfirmAlertDismissed` | Confirm alert dismissed shows Cancel |
| `Should_ShowTypedText_When_PromptAlertFilled` | Prompt alert shows typed text in result |

### DynamicLoadingTests.cs
| Test | Description |
|------|-------------|
| `Should_ShowHelloWorld_When_StartClickedOnExample1` | Example 1 shows Hello World after loading |
| `Should_ShowHelloWorld_When_StartClickedOnExample2` | Example 2 shows Hello World after loading |

### FileUploadTests.cs
| Test | Description |
|------|-------------|
| `Should_ShowUploadedFileName_When_FileIsUploaded` | Uploaded filename appears on page |
| `Should_ShowSuccessMessage_When_FileIsUploaded` | Page shows File Uploaded! after upload |

### HoverTests.cs
| Test | Description |
|------|-------------|
| `Should_ShowCaption_When_HoveringOverFirstAvatar` | Hover over avatar 1 shows user1 caption |
| `Should_ShowCaption_When_HoveringOverSecondAvatar` | Hover over avatar 2 shows user2 caption |
| `Should_ShowCorrectCaption_When_HoveringOverAvatar(0, "user1")` | Parameterized hover test — user1 |
| `Should_ShowCorrectCaption_When_HoveringOverAvatar(1, "user2")` | Parameterized hover test — user2 |
| `Should_ShowCorrectCaption_When_HoveringOverAvatar(2, "user3")` | Parameterized hover test — user3 |

## Key Concepts Demonstrated
- Page Object Model (POM)
- Explicit waits with `WebDriverWait`
- `SelectElement` for dropdown interaction
- `FindElements` for multiple element selection
- `.Selected` property for checkbox state
- Parameterized tests with `[TestCase]`
- Arrange / Act / Assert structure
- `SwitchTo().Alert()` for browser dialog handling
- `Actions` class for mouse hover interactions
- `SendKeys` for file upload (bypassing OS dialog)
- Test data management with `File.WriteAllText` / `File.Delete`

## How to Run
```bash
dotnet test
```

## Author
Venelin Krustev — Junior QA Automation Engineer, Sofia
