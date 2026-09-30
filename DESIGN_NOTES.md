# Design Notes — web-ui-automation-csharp

Decisions made in this project, why, and the trade-offs involved.

---

## 2026-08-31 — Exception Handling & Wait Strategies

**Q: What is StaleElementReferenceException and when does it occur?**
A: It occurs when Selenium holds a reference to a DOM element that no longer exists — for example, after a page navigation, a React re-render, or an AJAX update replaces the element. The reference becomes "stale" because the element in the browser's DOM is a different object than what was found earlier.

**Q: How do you fix StaleElementReferenceException in a wait lambda?**
A: Wrap the interaction inside the `wait.Until` lambda with a try/catch that catches `StaleElementReferenceException` and returns `false`, causing the wait to retry:
```csharp
wait.Until(d => {
    try { return d.FindElement(PageBody).Text.Contains("error text"); }
    catch (StaleElementReferenceException) { return false; }
});
```
This way the wait keeps polling until the element is stable and the condition is met.

**Q: What is the difference between WebDriverTimeoutException and NoSuchElementException?**
A: `NoSuchElementException` is thrown immediately by `FindElement` when no matching element exists in the current DOM. `WebDriverTimeoutException` is thrown by `wait.Until` when the condition function never returns `true` within the timeout period — it wraps the underlying exception (often `NoSuchElementException`) after all retries are exhausted.

---

## 2026-08-31 — OOP: virtual vs abstract

**Q: What is the difference between virtual and abstract methods in C#?**
A: A `virtual` method has a full implementation in the base class — subclasses *can* override it but are not required to. An `abstract` method has no body; it is a contract that every non-abstract subclass *must* implement. A class containing `abstract` members must itself be declared `abstract`.

**Q: How does this apply to test automation? Give a concrete example.**
A: `BaseTest` uses `virtual` for `SetUp` so individual test classes can override it to add extra setup steps while still calling `base.SetUp()`. If the base declared a method `abstract`, every single test class would be forced to implement it — too rigid for shared infrastructure.

---

## 2026-09-30 — Driver is typed as IWebDriver, not ChromeDriver

**Decision:** `BaseTest.Driver` is declared as `protected IWebDriver Driver { get; private set; }`, even though the `[SetUp]` method only ever constructs a `new ChromeDriver(options)`.
**Why:** `IWebDriver` is the interface that `ChromeDriver`, `FirefoxDriver`, and every other Selenium driver implements — it defines the contract (`FindElement`, `Navigate`, `Quit`, ...) without committing to a specific browser. Every test class and every Page Object interacts with `Driver` only through that interface, so swapping the concrete browser later (e.g., adding Firefox for cross-browser coverage) means changing one line inside `BaseTest.Setup()` — `Driver = new FirefoxDriver(options);` — with zero changes anywhere else in the suite. Typing the field as `ChromeDriver` directly would leak that concrete choice into every test class that touches `Driver`, and locking in a browser-specific type for no benefit — nothing in the tests actually needs Chrome-specific members.
**Trade-off:** none — this is standard "program to an interface, not an implementation" practice, not a compromise. The only cost would be if the suite needed a Chrome-specific API not exposed by `IWebDriver`, which it doesn't.

---

## 2026-08-31 — GitHub Actions CI

**Q: Why use `if: always()` on the artifact upload step?**
A: Without it, the upload step is skipped when tests fail — which is exactly when you need the results most. `if: always()` ensures the `.trx` report is uploaded regardless of whether previous steps succeeded or failed, so you always have evidence of what broke.

**Q: What is the purpose of `--no-build` in `dotnet test --no-build`?**
A: It tells the test runner to skip recompilation and use the already-built binaries from the preceding `dotnet build` step. This avoids a redundant second compile, keeps the CI run faster, and ensures tests run against exactly the binaries that were built and validated — not a fresh recompile that could differ in edge cases.

**Q: Why separate `dotnet restore`, `dotnet build --no-restore`, and `dotnet test --no-build` into three steps?**
A: Separation gives clearer failure attribution — if restore fails you know it's a dependency issue, if build fails it's a compilation error, if test fails it's a test logic issue. It also enables better caching: NuGet packages restored in one step can be cached by the runner between runs, speeding up subsequent pipelines.
