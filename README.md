# DeviceWorkbench

카메라 영상 수집과 검사 작업 흐름을 단계적으로 구현하는 WPF 데스크톱 프로젝트입니다.
현재 버전은 MVVM 기반 초기 화면이며, 카메라 SDK 연동은 아직 구현하지 않았습니다.

## 현재 구현

- `App`에서 `MainViewModel`과 `MainWindow`를 생성하는 시작 구조
- 장비·작업, 영상, 검사 결과, 활동 로그 영역
- 작업명 입력의 양방향 바인딩
- 활동 로그 표시와 로그 지우기 명령
- CommunityToolkit.Mvvm의 `ObservableObject`, `ObservableProperty`, `RelayCommand`

장비 검색·연결, 영상 수신, 검사 판정, DB 저장은 이후 구현할 항목입니다.
현재 화면의 미연결·영상 대기·검사 결과 없음 표시는 초기 상태입니다.

## 기술 및 프로젝트 구성

| 프로젝트 | 구성 | 상태 |
| --- | --- | --- |
| DeviceWorkbench.Desktop | WPF, .NET Framework 4.8.1, C# 12, x64, CommunityToolkit.Mvvm 8.4.0 | 초기 화면 구현 |
| DeviceWorkbench.Bridge | C++/CLI 프로젝트 정의 | 소스 미구현, 기본 빌드 제외 |
| DeviceWorkbench.Native | C++17 DLL 프로젝트 정의 | 소스 미구현, 기본 빌드 제외 |

Desktop은 현재 Bridge를 참조하지 않습니다. 향후 SDK 연동 방식에 맞춰 참조 구조를 결정합니다.

```text
DeviceWorkbench.sln
src/
  DeviceWorkbench.Desktop/
    App.xaml
    App.xaml.cs
    ViewModels/MainViewModel.cs
    Views/MainWindow.xaml
    Views/MainWindow.xaml.cs
  DeviceWorkbench.Bridge/
  DeviceWorkbench.Native/
```

## 빌드와 실행

Windows x64와 .NET Framework 4.8.1 런타임이 필요합니다.
Visual Studio 2022의 .NET 데스크톱 개발 환경 또는 C# 12를 지원하는 .NET SDK로 Desktop 프로젝트를 빌드합니다.
NuGet 복원 시 MVVM Toolkit과 필요한 참조 어셈블리를 받습니다.
초기 화면을 실행하는 데 카메라나 카메라 SDK는 필요하지 않습니다.

Visual Studio에서는 `DeviceWorkbench.sln`을 열고 `DeviceWorkbench.Desktop`을 시작 프로젝트로 지정한 뒤 `Debug / x64`로 실행합니다.
C++ 프로젝트를 로드하는 데 필요한 도구가 없다면 `DeviceWorkbench.Desktop.csproj`만 열어도 됩니다.

프로젝트 루트에서 CLI로 빌드할 수도 있습니다.

```powershell
dotnet restore .\src\DeviceWorkbench.Desktop\DeviceWorkbench.Desktop.csproj -p:Platform=x64
dotnet build .\src\DeviceWorkbench.Desktop\DeviceWorkbench.Desktop.csproj --no-restore -c Debug -p:Platform=x64
& .\src\DeviceWorkbench.Desktop\bin\x64\Debug\net481\DeviceWorkbench.Desktop.exe
```

## 검증 범위

초기 화면 구현 시 Debug/x64 빌드와 WPF 리소스 로딩, 창 제목 바인딩, 작업명 양방향 바인딩, 로그 지우기 명령을 확인했습니다.
카메라 SDK 및 실제 장비 동작은 검증하지 않았습니다.

## 다음 단계

1. Basler pylon의 카메라 에뮬레이션을 이용한 장비 검색과 연결
2. 프레임 수신과 WPF 영상 표시
3. 수집 시작·중지 및 오류 처리
4. 검사 조건과 결과 이력 관리

위 항목은 개발 계획이며 현재 구현된 기능이 아닙니다.
