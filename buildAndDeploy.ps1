write "++ Including files ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++"
. ".\buildCommands.ps1"

if(execute-build)
{
  run-tests
  stamp-build-number
  create-assets
  install-iis
}

write "== Done ====================================================================="