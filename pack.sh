#!/bin/bash

for dir in SchauerLib.Assertions.MsTest SchauerLib.Assertions.Xunit SchauerLib.Extensions SchauerLib.Types
do
	echo
	echo "============================="
	echo "=PACK $dir"
	echo "============================="
	cd "$dir"
	dotnet pack
	cd ..
done