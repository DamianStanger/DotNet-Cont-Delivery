# run this first -   Set-ExecutionPolicy RemoteSigned

import-module WebAdministration

Remove-Item IIS:\Sites\ContinuousDelivery -recurse
Remove-Item IIS:\AppPools\ContinuousDeliveryAppPool -recurse
Remove-Item website -recurse

New-Item website -type Directory

libs\7zip\7z.exe x assets\ContinuousDelivery.zip -oWebsite

New-Item IIS:\AppPools\ContinuousDeliveryAppPool
New-Item iis:\Sites\ContinuousDelivery -bindings @{protocol="http";bindingInformation=":8080:ContinuousDelivery"} -physicalPath C:\_projects\visualStudio\ContinuousDelivery\website
Set-ItemProperty IIS:\Sites\ContinuousDelivery -name applicationPool -value ContinuousDeliveryAppPool


$webclient = New-Object Net.WebClient
$webclient.DownloadString("http://continuousdelivery:8080/");