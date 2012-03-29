write "++ Including files ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++"
. ".\buildCommands.ps1"

execute-build
run-tests
stamp-build-number aaa
create-assets
install-iis

write "== Done ====================================================================="