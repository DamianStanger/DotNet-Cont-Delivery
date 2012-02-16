Set-StrictMode -Version 1
# run this first -   Set-ExecutionPolicy RemoteSigned


$MsBuild = "C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe"
$nunitConsole = "libs\NUnit-2.6.0.12035\bin\nunit-console.exe"

$SlnFile = "ContinuousDelivery.sln";
$testDll = "tests/build/tests.dll"
$websiteAbsolutePath = "C:\_projects\visualStudio\ContinuousDelivery\website"



function execute-build()
{
  write "++ Running Build ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++"
  
  $BuildArgs = @{
   FilePath = $MsBuild;
   ArgumentList = $SlnFile, "/target:Clean", "/target:Build", "/property:OutDir=build\";
  }
   
  Start-Process @BuildArgs -NoNewWindow -Wait;
  # Start-Process @BuildArgs -NoNewWindow
}

function run-tests()
{
  write "++ Running Tests ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++"
  
  $BuildArgs = @{
   FilePath = $nunitConsole;
   ArgumentList = "/config=Release", $testDll;
  }
  
  Start-Process @BuildArgs -NoNewWindow -Wait; 
}

function stamp-build-number()
{
  write "++ Stamping build number ++++++++++++++++++++++++++++++++++++++++++++++++++++"
  $buildNumber = $args[0]
  $buildNumber >> ContinuousDelivery\build\_PublishedWebsites\ContinuousDelivery\buildNumber.txt
}

function create-assets()
{
  write "++ Creating assets ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++"
  Remove-Item assets -recurse -Force
  mkdir assets
  cd ContinuousDelivery\build\_PublishedWebsites\ContinuousDelivery
  ..\..\..\..\libs\7zip\7z.exe a -tzip -r ..\..\..\..\assets\ContinuousDelivery.zip *
  cd ..\..\..\..
}

function install-iis()
{
  write "++ Installing to iis ++++++++++++++++++++++++++++++++++++++++++++++++++++++++"
  import-module WebAdministration

  Remove-Item IIS:\Sites\ContinuousDelivery -recurse -Force
  Remove-Item IIS:\AppPools\ContinuousDeliveryAppPool -recurse -Force
  Remove-Item website -recurse -Force

  New-Item website -type Directory

  libs\7zip\7z.exe x assets\ContinuousDelivery.zip -oWebsite

  New-Item IIS:\AppPools\ContinuousDeliveryAppPool
  Set-ItemProperty IIS:\AppPools\ContinuousDeliveryAppPool -Name managedRuntimeVersion -Value "v4.0"
  New-Item iis:\Sites\ContinuousDelivery -bindings @{protocol="http";bindingInformation=":80:ContinuousDelivery"} -physicalPath $websiteAbsolutePath
  Set-ItemProperty IIS:\Sites\ContinuousDelivery -name applicationPool -value ContinuousDeliveryAppPool

  Start-Sleep -s 2
  $webclient = New-Object Net.WebClient
  $html = $webclient.DownloadString("http://continuousdelivery")
  $result = $html.Contains('Hello Delivery')

   if ($result) {Write-Host "success"}
   else {Write-Host "##teamcity[buildStatus status='FAILURE' text='Some error message']"}
}

