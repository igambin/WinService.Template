$ServiceName="WinService.Service"

Stop-Service $ServiceName

(Get-WmiObject Win32_Service -filter "name='$ServiceName'").Delete()
