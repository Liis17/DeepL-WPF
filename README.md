# DEEPL-WPF | Переводчик DeepL
![NVIDIA_Overlay_MWK6cn7j9t](https://github.com/Liis17/DeepL-WPF/assets/49622564/e94dc468-5065-4da7-b5c4-bfe6f04d6ebf)
## ЧТО ЭТО И ЗАЧЕМ?
```DeepL-WPF``` - просто окно с браузером внутри в котором открыт переводчик [deepl.com](https://www.deepl.com/translator)

Это просто замена официального приложения с целью избавиться от ```Zero Install``` у себя на пк

 **Загрузить** [ТЫК](https://github.com/Liis17/DeepL-WPF/releases)
 
 или

Собрать самому

> [!WARNING]
> На этом моменте должны уже быть установленны [Git](https://git-scm.com/download/win) и [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

```
git clone https://github.com/Liis17/DeepL-WPF
```

```
cd DeepL-WPF
```

```
dotnet publish --configuration Release
```

```
explorer /select, DeepL-WPF\bin\Release\net8.0-windows10.0.22621.0\publish\DeepL-WPF.exe
```

> [!IMPORTANT]
> Чтобы закрыть приложение зажать левый shift при нажатии на крестит или нажать "закрыть" в контекстном меню значка в трее

> [!CAUTION]
> Если в окне не загружается страница и там черный фон, тогда необходимо установить еще ```Microsoft Edge WebView2 Runtime``` перейдя [по ссылке](https://go.microsoft.com/fwlink/p/?LinkId=2124703)
