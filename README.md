# Selenium Basics

Automated UI tests using Selenium WebDriver, C#, and NUnit.

## Tech Stack
- C# / .NET 10
- Selenium WebDriver 4.43
- NUnit 4.3
- ChromeDriver

## Project Structure
```
SeleniumBasics/
  Pages/
    GooglePage.cs       # Page Object for Google homepage
  UnitTest1.cs          # Core Google tests
  SearchTests.cs        # Parameterized search tests
```

## Tests

### UnitTest1.cs
| Test | Description |
|---|---|
| `GoogleTitleIsCorrect` | Verifies Google homepage loads with correct title `[Smoke]` |
| `GoogleSearchReturnsResults` | Searches for "Selenium C#" and verifies results page loads |
| `GoogleTitleStartsWithGoogle` | Verifies title starts with "Google" `[Ignored]` |
| `GoogleSearchBoxIsVisible` | Verifies search box is visible and enabled |

### SearchTests.cs
| Test | Description |
|---|---|
| `SearchForNUnit` | Searches for "NUnit" and verifies results |
| `SearchForCSharp` | Searches for "CSharp programming" and verifies results |
| `SearchReturnsResultsFor("Selenium")` | Parameterized search test |
| `SearchReturnsResultsFor("NUnit")` | Parameterized search test |
| `SearchReturnsResultsFor("CSharp")` | Parameterized search test |

## How to Run

Run all tests:
```bash
dotnet test
```

Run only Smoke tests:
```bash
dotnet test --filter "TestCategory=Smoke"
```

## Key Concepts Demonstrated
- Page Object Model (POM)
- Explicit waits with `WebDriverWait`
- JavaScript executor for DOM interaction
- Parameterized tests with `[TestCase]`
- Test categories with `[Category]`
- `[OneTimeSetUp]` for shared browser instance

## Author
Venelin Krustev — Junior QA Automation Engineer, Sofia
