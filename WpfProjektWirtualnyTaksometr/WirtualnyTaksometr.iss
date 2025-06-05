[Setup]
AppName=Wirtualny Taksometr
AppVersion=1.0
DefaultDirName={pf}\Wirtualny Taksometr
DefaultGroupName=Wirtualny Taksometr
OutputDir=Output
OutputBaseFilename=Instalator_WirtualnyTaksometr
Compression=lzma
SolidCompression=yes
DisableDirPage=no
PrivilegesRequired=admin
WizardStyle=modern
SetupIconFile="C:\Users\Viktor\source\repos\Projekt-Semestralny-Wirtualny-Taksometr\WpfProjektWirtualnyTaksometr\Zdjecia\logo.ico"

[Languages]
Name: "polish"; MessagesFile: "compiler:Languages\Polish.isl"

[Files]
Source: "C:\Users\Viktor\source\repos\Projekt-Semestralny-Wirtualny-Taksometr\WpfProjektWirtualnyTaksometr\bin\Release\net8.0-windows\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\Wirtualny Taksometr"; Filename: "{app}\WpfProjektWirtualnyTaksometr.exe"; WorkingDir: "{app}"
Name: "{commondesktop}\Wirtualny Taksometr"; Filename: "{app}\WpfProjektWirtualnyTaksometr.exe"; Tasks: desktopicon; WorkingDir: "{app}"

[Tasks]
Name: "desktopicon"; Description: "Utwórz skrót na pulpicie"; GroupDescription: "Dodatkowe zadania:"