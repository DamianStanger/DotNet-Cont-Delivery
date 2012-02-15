Set-StrictMode -Version 2
$buildNumber = $args[0]
$buildNumber >> ContinuousDelivery\build\_PublishedWebsites\ContinuousDelivery\buildNumber.txt
