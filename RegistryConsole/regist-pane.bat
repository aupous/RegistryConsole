reg add HKCU\Software\Classes\CLSID\{268e4c30-a7ad-41c6-982b-61f73b600659} /ve /t REG_SZ /d "GodDrive" /f
reg add HKCU\Software\Classes\CLSID\{268e4c30-a7ad-41c6-982b-61f73b600659}\DefaultIcon /ve /t REG_EXPAND_SZ /d %%SystemRoot%%\system32\imageres.dll,-111 /f
reg add HKCU\Software\Classes\CLSID\{268e4c30-a7ad-41c6-982b-61f73b600659} /v System.IsPinnedToNameSpaceTree /t REG_DWORD /d 0x1 /f
reg add HKCU\Software\Classes\CLSID\{268e4c30-a7ad-41c6-982b-61f73b600659} /v SortOrderIndex /t REG_DWORD /d 0x42 /f
reg add HKCU\Software\Classes\CLSID\{268e4c30-a7ad-41c6-982b-61f73b600659}\InProcServer32 /ve /t REG_EXPAND_SZ /d %%systemroot%%\system32\shell32.dll /f
reg add HKCU\Software\Classes\CLSID\{268e4c30-a7ad-41c6-982b-61f73b600659}\Instance /v CLSID /t REG_SZ /d {0E5AAE11-A475-4c5b-AB00-C66DE400274E} /f
reg add HKCU\Software\Classes\CLSID\{268e4c30-a7ad-41c6-982b-61f73b600659}\Instance\InitPropertyBag /v Attributes /t REG_DWORD /d 0x11 /f
reg add HKCU\Software\Classes\CLSID\{268e4c30-a7ad-41c6-982b-61f73b600659}\Instance\InitPropertyBag /v TargetFolderPath /t REG_EXPAND_SZ /d "C:\Users\tuanp\GodDrive" /f
reg add HKCU\Software\Classes\CLSID\{268e4c30-a7ad-41c6-982b-61f73b600659}\ShellFolder /v FolderValueFlags /t REG_DWORD /d 0x28 /f
reg add HKCU\Software\Classes\CLSID\{268e4c30-a7ad-41c6-982b-61f73b600659}\ShellFolder /v Attributes /t REG_DWORD /d 0xF080004D /f
reg add HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\Desktop\NameSpace\{268e4c30-a7ad-41c6-982b-61f73b600659} /ve /t REG_SZ /d "GodDrive" /f
reg add HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\HideDesktopIcons\NewStartPanel /v {268e4c30-a7ad-41c6-982b-61f73b600659} /t REG_DWORD /d 0x1 /f
