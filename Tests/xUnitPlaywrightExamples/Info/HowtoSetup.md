## How to install Playwright

Go to the project directory and run the following command to install Playwright.

```powershell
pwsh .\bin\Debug\net9.0\playwright.ps1 install
```
<i>
If pwsh gives you an error, try to update powershell to the latest version.
</i>


## Powershell update steps

### Show current version of PowerShell
```powershell
$psversiontable
```

### command should return the latest version of PowerShell
```powershell
winget search Microsoft.PowerShell
```

### For installations, you can use the following command to install PowerShell using winget:
```powershell
winget install --id Microsoft.PowerShell --source winget
```



