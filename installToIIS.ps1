#Set-StrictMode -Version 2

# run this first -   Set-ExecutionPolicy RemoteSigned

import-module WebAdministration

Remove-Item IIS:\Sites\ContinuousDelivery -recurse -Force
Remove-Item IIS:\AppPools\ContinuousDeliveryAppPool -recurse -Force
Remove-Item website -recurse -Force

New-Item website -type Directory

libs\7zip\7z.exe x assets\ContinuousDelivery.zip -oWebsite

New-Item IIS:\AppPools\ContinuousDeliveryAppPool
Set-ItemProperty IIS:\AppPools\ContinuousDeliveryAppPool -Name managedRuntimeVersion -Value "v4.0"
New-Item iis:\Sites\ContinuousDelivery -bindings @{protocol="http";bindingInformation=":80:ContinuousDelivery"} -physicalPath C:\_projects\visualStudio\ContinuousDelivery\website
Set-ItemProperty IIS:\Sites\ContinuousDelivery -name applicationPool -value ContinuousDeliveryAppPool

Start-Sleep -s 2
$webclient = New-Object Net.WebClient
$webclient.DownloadString("http://continuousdelivery")

#$result = $webclient.DownloadString("http://continuousdelivery").IndexOf('<meta name="ContinuousDelivery" />')
