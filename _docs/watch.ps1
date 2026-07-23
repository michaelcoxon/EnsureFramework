$folder =  $pwd
$filter = "*.md"
$Watcher = New-Object IO.FileSystemWatcher $folder, $filter -Property @{ 
    IncludeSubdirectories = $true
    NotifyFilter = [IO.NotifyFilters]'FileName, LastWrite'
}
$onCreated = Register-ObjectEvent $Watcher Created -SourceIdentifier FileCreated -Action {
   $path = $Event.SourceEventArgs.FullPath
   $name = $Event.SourceEventArgs.Name
   $changeType = $Event.SourceEventArgs.ChangeType
   $timeStamp = $Event.TimeGenerated
   Write-Host "The file '$name' was $changeType at $timeStamp"
   Write-Host $path
   docfx --build
}
$onChanged = Register-ObjectEvent $Watcher Changed -SourceIdentifier FileChanged -Action {
   $path = $Event.SourceEventArgs.FullPath
   $name = $Event.SourceEventArgs.Name
   $changeType = $Event.SourceEventArgs.ChangeType
   $timeStamp = $Event.TimeGenerated
   Write-Host "The file '$name' was $changeType at $timeStamp"
   Write-Host $path
   docfx --build
}