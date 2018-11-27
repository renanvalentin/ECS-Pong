#!/bin/bash
clear
msbuild /property:Configuration=Release /verbosity:minimal Tests/Tests.sln
mono Tests/Tests/bin/Release/Tests.exe $@
