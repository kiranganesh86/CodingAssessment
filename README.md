# API Testing Assessment using C# MS automation framework

Automate Cat Facts Ninja API using C# automation framework to ensure that the API is hit 10 times and only unique facts are stored using a hashmap. While handling exceptions.

## Prerequisites to run test locally

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Visual Studio Code IDE
- Visual Studio Code extensions -> C# dev Kit, .NET Install Tool, C#

## Getting Started

1. **Clone the repository**
   ```bash
   git clone https://github.com/kiranganesh86/CodingAssessment.git
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Build project**
   ```bash
   dotnet build
   ```

4. **Run tests**
   ```bash
   dotnet test
   ```


## File Structure

- `Program.cs` - Contains the test implementation
- `.github/workflows/test.yml` - GitHub Actions workflow for CI

## Test Case

The test:
- Make HTTP GET request to https://catfact.ninja/fact 10 times.
- Validate API HTTP response status is valid (200) or not.
- Ensure facts are unique and store in a hashmap.

## Code Refractoring Items

1. Security warnings about package vulnerabilities are not fixed.
2. Need to add retry logic if the API does not return HTTP status 200.
3. Move all constant items into a config file

## References

1. [Unit testing C# with MSTest and .NET](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest)
2. [GitHub Actions - Building And Testing](https://docs.github.com/en/actions/use-cases-and-examples/building-and-testing/building-and-testing-net)
3. [Using C# and MSTest for testing](https://medium.com/@rogersteinbakk/using-c-and-mstest-for-testing-apps-some-examples-4be5e0dffcc3)
4. [Pre Commit Hooks](https://medium.com/codenx/format-and-automate-net-project-with-husky-net-git-hooks-4dcace67797b)
