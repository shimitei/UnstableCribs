set slndir=%1
set targetdir=%2
rem config : Debug or Release
set config=%3
mkdir %targetdir%x64
copy /Y %slndir%\Translator\bin\%config%\x64\SQLite.Interop.dll %targetdir%\x64\SQLite.Interop.dll
mkdir %targetdir%x86
copy /Y %slndir%\Translator\bin\%config%\x86\SQLite.Interop.dll %targetdir%\x86\SQLite.Interop.dll
