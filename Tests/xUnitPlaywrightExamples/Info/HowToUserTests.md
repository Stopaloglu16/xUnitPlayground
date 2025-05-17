## How to use Tests

### Trace View

Step 1: 
Running test will create a zip file . 
Which is on below function

```powershell	
Context.Tracing.StopAsync
```

Step 2:
Go to https://trace.playwright.dev/
<p>Drag and drop zip file</p>

or run below
```powershell
playwright show-trace trace.zip
```


### Pick Locator

If not installed
```powershell
dotnet tool install --global Microsoft.Playwright.CLI


playwright install
```

Run below command, it will open a browser window and you can select the element you want to locate.

```powershell
playwright codegen https://example.com --target=csharp
```

After selecting the element, you can copy the generated code and use it in your tests.