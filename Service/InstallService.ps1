$thisDir = $PSScriptRoot
$ServiceName="WinService.Service"
$ServiceDescription = "Empty Template for developing a WindowsService"

new-service -Name $ServiceName -DisplayName $ServiceName -Description $ServiceDescription -BinaryPathName "$thisDir\$ServiceName.exe" -StartupType Automatic 

Start-Service $ServiceName
