# unity-package-logger-unity
## com.openmygame.loggerunity

## <b>Подключение и импорт пакета</b>

[Подключение к приватному репозиторию для выкачки пакетов](https://gitlab.com/openmygame/unity-modules-registry#%D0%BF%D0%BE%D0%B4%D0%BA%D0%BB%D1%8E%D1%87%D0%B5%D0%BD%D0%B8%D0%B5)

[Импорт пакета в Unity](https://gitlab.com/openmygame/unity-modules-registry#%D0%BF%D0%BE%D0%B4%D0%BA%D0%BB%D1%8E%D1%87%D0%B5%D0%BD%D0%B8%D0%B5-%D0%B2-%D1%8E%D0%BD%D0%B8%D1%82%D0%B8)

Для включения логгирования нужно прописать define: ```UNITY_LOGGING_ENABLED```

## <b>Описание</b>

Пакет структурного логирования

Пакет предоставляет статический класс для логгирования сообщений, а также типы для настройки и создания логгера

Текущие реализации логгеров логгируют информацию в Unity Debug (```Debug.Log```), Android при помощи вызова нативного логгера

Для логгирования сообщения используется формат, который может содержать декларацию параметров (заключены в скобки {}) или не содержать их (просто строка)

Пример: ```"Debug current time: {Time}"``` - формат с одним параметром ```Time```, в который будет подставлено любое указанное значение в процессе логгирования

Соответственно логгирование будет выглядеть примерно так: ```Log.DebugMessage().Log("Debug current time: {Time}", DateTime.Now)```

## <b>Самое простое создание логгера для логгирования в ```Debug```</b>

```csharp
Log.Logger = new LoggerBuilder()
    .LogToUnityDebug()
    .CreateLogger();
```

Для успешного логирования сообщений необходимо установить свойство ```Logger``` в статическом классе ```Log```

Пакет предоставляет класс ```LoggerBuilder``` для конфигурации объекта типа ```ILogger```, который сразу можно установить в это свойство

Поддерживается 4 уровня логгирования ```LogLevel```: 
- ![#C0C0C0](https://placehold.co/15x15/C0C0C0/C0C0C0.png) ```Debug```, 
- ![#CC9A06](https://placehold.co/15x15/CC9A06/CC9A06.png) ```Warning```, 
- ![#CC423B](https://placehold.co/15x15/CC423B/CC423B.png) ```Error```, 
- ![#CC423B](https://placehold.co/15x15/CC423B/CC423B.png) ```Fatal```

## Конфигурироемое создание логгера

```csharp
Log.Logger = new LoggerBuilder()
    .SetEnabled(true)
    .SetTagFormat("#{Tag}#")
    .SetIsCacheFormats(true)
    .SetIsPoolingEnabled(true)
    .SetIsExtractStackTracesToMessages(false)
    .LogToUnityDebug(config =>
    {
        config.LogFormat = "[{ThreadId}] {Message}{NewLine}{Exception}";
        config.MinimumLogLevel = LogLevel.Debug;
        config.IsUnityStacktraceEnabled = true;
        config.MessagePartMaxSize = 400;
        config.MessagePartFormat = "[Id: {MessageId}, Part: {PartIndex}/{PartsCount}] {MessagePart}";
        config.ColorizeParameters();
    })
    .CreateLogger();
```

### Api класса ```LoggerBuilder```

| Тип                                       | Описание                                                                                                                                                                                                                                                                        |
|-------------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| ```SetEnabled```                          | Устанавливает будет ли происходить логгирование или нет; дефолтный параметр - ```true```                                                                                                                                                                                        |
| ```SetTagFormat```                        | Устанавливает формат для тегов (необходимо чтобы тег имел параметр ```{Tag}```); дефолтный формат - ```#{Tag}#```                                                                                                                                                               |
| ```SetIsCacheFormats```                   | Устанавливает будет ли кэшироваться формат сообщения после его парсинга; дефолтный параметр - ```true```                                                                                                                                                                        |
| ```SetIsPoolingEnabled```                 | Устанавливает будут ли переиспользоваться некоторые объекты при логгировании (например, ```StringBuilder``` при формировании сообщений); дефолтный параметр - ```false```                                                                                                       |
| ```SetIsExtractStacktraceToMessage```     | Устанавливает будет ли формироваться стектрейс для сообщения (нужно например для нативных логов с стектрейсом, для Editor'a лучше не трогать либо поставить ```false```, потому что в Editor'е можно включить стандартный стектрейс от Unity); дефолтный параметр - ```false``` |
| ```AddMessageFormatParameter```           | Добавление кастомного форматтера объекта в логгируемом сообщении                                                                                                                                                                                                                |
| ```LogTo<TConfiguration, TDestination>``` | Добавляет новый логгер в коллекцию логгеров (```ILoggerDestination```)                                                                                                                                                                                                          |
| ```CreateLogger```                        | Создает сконфигурированный логгер (```ILogger```)                                                                                                                                                                                                                               |

По сути реализация ```ILogger``` содержит в себе коллекцию ```ILoggerDestination```, чтобы можно было логгировать в несколько мест сразу 

## ```LogToUnityDebug```

| Свойство или метод             | Описание                                                                                                                                                                                                                                                                                                                                                                                                                                                           |
|--------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| ```IsEnabled```                | Устанавливает, будет ли происходить логгирование в Unity Debug; дефолтный параметр - ```true```                                                                                                                                                                                                                                                                                                                                                                    |
| ```LogFormat```                | Устанавливает формат сообщения с дополнительными параметрами; дефолтный параметр - <nobr>```{Message}{NewLine}{Exception}```</nobr>                                                                                                                                                                                                                                                                                                                                |
| ```MinimumLogLevel```          | Устанавливает минимальный уровень, с которого происходит логгирование (```Fatal``` конвертируется в ```UnityEngine.LogType.Exception```); дефолтный параметр - ```LogLevel.Debug```                                                                                                                                                                                                                                                                                |
| ```IsUnityStacktraceEnabled``` | Будет ли в сообщениях отображаться стектрейс, который формирует Unity; дефолтный параметр - ```true```                                                                                                                                                                                                                                                                                                                                                             |
| ```MessagePartMaxSize```       | Максимальный размер сообщения, после которого начинается его разбиение на части; дефолтный параметр - ```int.MaxValue```                                                                                                                                                                                                                                                                                                                                           |
| ```MessagePartFormat```        | Формат для формирования части сообщения при его разделении на несколько частей; формат должен содержать параметры ```MessageId``` - id сообщения, ```PartIndex``` - индекс текущей части сообщения, ```PartsCount``` - количество частей сообщения, ```MessagePart``` - текущая часть сообщения, или часть из них, и не должен содержать другие параметры; дефолтный параметр - <nobr>```[Id: {MessageId}, Part: {PartIndex}/{PartsCount}] {MessagePart}```</nobr> |
| ```ColorizeParameters```       | Вызов метода установит необходимые параметры для оборачивания всех параметров сообщения в тег ```<color>```; в метод можно передать свою реализацию ```IParameterColorsViewConfig``` для окрашивания параметров в кастомные цвета                                                                                                                                                                                                                                  |

## ```LogToAndroidLog```

| Свойство или метод    | Описание                                                                                                                            |
|-----------------------|-------------------------------------------------------------------------------------------------------------------------------------|
| ```IsEnabled```       | Устанавливает, будет ли происходить логгирование в Android Log; дефолтный параметр - ```true```                                     |
| ```LogFormat```       | Устанавливает формат сообщения с дополнительными параметрами; дефолтный параметр - <nobr>```{Message}{NewLine}{Exception}```</nobr> |
| ```MinimumLogLevel``` | Устанавливает минимальный уровень, с которого происходит логгирование; дефолтный параметр - ```LogLevel.Debug```                    |

## Дополнительные параметры логгирования

Устанавливая формат в свойство ```LogFormat```, в него можно добавить дополнительные параметры, которые будут добавляться в каждое сообщение.

Стандартным форматом является ```"{Message}{NewLine}{Exception}"``` - то есть в лог будет выводиться сообщение, переход на новую строку и исключение, если оно есть.

Стандартными параметрами, которые можно добавлять в ```LogFormat``` являются:

| Параметр         | Описание                                                                       |
|------------------|--------------------------------------------------------------------------------|
| ```Message```    | Сообщение                                                                      |
| ```LogLevel```   | Добавляет уровень логгирования сообщение                                       |
| ```Exception```  | Добавляет исключение (если исключения нет, то вместо него будет пустая строка) |
| ```NewLine```    | Добавляет новую линию для форматирования сообщения                             |
| ```ThreadId```   | Добавляет Id потока, из которого вызывается метод логгирования                 |
| ```Time```       | Добавляет текущее время (```DateTime.Now```)                                   |
| ```TimeUtc```    | Добавляет текущее время в UTC (```DateTime.UtcNow```)                          |
| ```UnityTime```  | Добавляет текущее время с время запуска приложения                             |

К списку существующих параметров можно добавить свой кастомный. 
Для этого нужно создать класс, который будет реализовывать интерфейс ```ILogFormatParameter```.
В параметры метода приходит ```MessagePart```, из которого можно получить формат параметра.
Например:

```csharp
public class LogFormatParameterCustom : ILogFormatParameter
{
    public string Key => "Custom";

    public ReadOnlySpan<char> GetValue(MessagePart messagePart, LogMessage message, Span<object> parameters)
    {
        if (messagePart.TryGetFormat(out var format))
        {
            if (format.Equals("ToUpper", StringComparison.OrdinalIgnoreCase))
            {
                return "Custom".ToUpper();
            }
        }

        return "Custom";
    }
}
```
А затем добавить этот класс в список параметров при конфигурации логгера. Например:

```csharp
Log.Logger = new LoggerBuilder()
    .LogToUnityDebug(config =>
    {
        config.LogFormat = "[{Custom}] {Message}";
        ...
        config.AddLogFormatParameter(new LogFormatParameterCustom());
    })
    .CreateLogger();
```
После этого его можно будет использовать в свойстве ```LogFormat```

## Форматирование параметров

Для некоторых типов параметров поддерживается форматирование.

Формат указывается через двоеточие, например - ```"{LogLevel:u}"```.

Стандартными форматами для дополнительных параметров в ```LogFormat``` являются:

| Параметр                   | Описание                                                                                                   |
|----------------------------|------------------------------------------------------------------------------------------------------------|
| ```LogLevel:[u\|l][\|3]``` | u - ToUpper, l - ToLower; 3 - LogLevel в 3 символа (DBG, WRN, ERR, FTL), ничего - полное название LogLevel |
| ```Time```                 | Форматы, которые поддерживает DateTime                                                                     |
| ```TimeUtc```              | Форматы, которые поддерживает DateTime                                                                     |
| ```UnityTime```            | Форматы, которые поддерживает DateTime; если формата нет, то выводится время в секундах                    |

Стандартными форматами для параметров в сообщениях являются:

| Тип параметра   | Описание                                                                  |
|-----------------|---------------------------------------------------------------------------|
| ```DateTime```  | Форматы, которые поддерживает ```DateTime```                              |
| ```Guid```      | Форматы, которые поддерживает ```Guid```                                  |
| ```string```    | ```u``` - ```ToUpper```, ```l``` - ```ToLower```                          |
| ```TimeSpan```  | Форматы, которые поддерживает ```TimeSpan```                              |

Если необходимо вывести комплексный объект в виде json-строки, то перед названием его параметра необходимо добавить ```@```, например ```{@Value}```.
К такому параметру можно добавить следующие форматы:

| Формат            | Описание                     |
|-------------------|------------------------------|
| Пустой            | Выводит json в одну строку   |
| ```f``` (full)    | Выводит форматированный json |
| ```c``` (compact) | Выводит json в одну строку   |

К списку существующих форматтеров объектов можно добавить свой кастомный.
Для этого нужно создать класс, который будет наследовать класс ```MessageFormatParameter<T>```, где T - свой кастомный тип, который необходимо отформатировать.
Например:

```csharp
internal class MessageFormatParameterInt : MessageFormatParameter<int>
{
    protected override ReadOnlySpan<char> Render(int parameter, in ReadOnlySpan<char> format)
    {
        if (format.Equals("x2", StringComparison.OrdinalIgnoreCase))
        {
            return (parameter * 2).ToString();
        }
        
        return parameter.ToString();
    }
}
```
А затем добавить этот класс в список параметров при конфигурации логгера. Например:

```csharp
Log.Logger = new LoggerBuilder()
    .AddMessageFormatParameter(new MessageFormatParameterInt())
    .LogToUnityDebug()
    .CreateLogger();
```
После этого все объекты с типом, который указан в параметре ```T``` созданного форматтера, будут форматироваться через созданный форматтер.

## Теги

Сообщения можно выводить с тегами

Для этого необходимо вызвать метод ```LogMessage.WithTag("Tag")```, который установит тег в сообщение.
Пример:

```csharp
Log.DebugMessage().WithTag("Time").Log("Debug current time with tag: {Time}", DateTime.Now);
```

Также можно создать экземпляр класса ```LogWithTag```, в конструктор которого можно передать тег, который проставится в сообщение при его создании.
Пример:

```csharp
var logWithTag = new LogWithTag("Time");
logWithTag
    .DebugMessage()
    .Log("Debug current time with log with tag: {Time}", DateTime.Now);
```

При этом в финальный формат сообщения в начало добавится формат тега, который был указан при конфигурации логгера.
Теги окрашиваются так же, как и параметры.

## Окрашивание параметров

Для окраски параметров в Editor нужно открыть окно по пути ```Logger/Show parameter colors editor``` и сначала создать конфиг, нажав на кнопку ```Create parameter colors config```.
Если конфиг не создан, то при будет логгировании использоваться дефолтный конфиг с предзаданными цветами.
После этого можно будет редактировать конфиг с цветами параметров, который состоит из 4-ех частей:

1. <b>Log parameter colors</b> - необходимо указать название глобального параметра и его цвет
2. <b>Parameter colors by type</b> - необходимо указать название типа параметра и его цвет
3. <b>Log level colors</b> - необходимо указать тип уровня логгирования и его цвет
4. <b>Tag colors</b> - необходимо указать название тега и его цвет

<b>Если в процессе логирования не нашелся цвет для тега, то будет использоваться белый цвет</b>

Пример конфига приведен на скриншоте:

![image](https://github.com/user-attachments/assets/ea410d32-dbd0-4f23-96af-d6cdca6159f9)

После создания конфига его нужно указать в ```LoggerBuilder```, чтобы он использовался вместо дефолтного конфига, например:

```csharp
Log.Logger = new LoggerBuilder()
    .LogToUnityDebug(config =>
    {
        ...
        config.ColorizeParameters(ParameterColorsViewConfig.Load());
    })
    .CreateLogger();
```

### Теги в Editor

В Editor'е теги добавляются в начало сообщения, а также в окно с тегами, которое может быть закреплено внизу окна с логами для быстрой фильтрации по одному тегу.

Пример приведен на скриншоте:

![image](https://github.com/user-attachments/assets/c06ab8ae-05b1-4a76-b590-2b04336e272d)

### Теги в Android

В Android теги добавляются в начало сообщения, а также в Logcat сообщения выводятся с таким же тегом, то есть в Android Studio можно фильтровать сообщения через конструкцию ```"tag:[TagName]"```

Пример приведен на скриншоте:

![image](https://github.com/user-attachments/assets/b3ca43f0-19d1-49fb-b445-944d2b4bec08)

## Пример логгирования сообщений

```csharp
Log.DebugMessage().Log("Debug current time: {Time}", DateTime.Now);
Log.WarningMessage().Log("Warning current time: {Time}", DateTime.Now);
Log.ErrorMessage().Log("Error current time: {Time}", DateTime.Now);
Log.FatalMessage().Log("Fatal current time: {Time}", DateTime.Now);

Log.DebugMessage().WithTag("Time").Log("Debug current time with tag: {Time}", DateTime.Now);
Log.WarningMessage().WithTag("Time").Log("Warning current time with tag: {Time}", DateTime.Now);
Log.ErrorMessage().WithTag("Time").Log("Error current time with tag: {Time}", DateTime.Now);
Log.FatalMessage().WithTag("Time").Log("Fatal current time with tag: {Time}", DateTime.Now);

Log.DebugMessage().Log("Debug complex object: {@Value}", new { Value = 5 });
```
