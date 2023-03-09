# OutlineManager
.NET библиотека для управления серверами проксирования под управлением ПО Outline-Server

## Как это работает {#how-it-works}
Outline-Server является API-Based ПО, что даёт возможность управлять серверами HTTP запросами, которые мы заготовили и сделали в удобные методы.

## Где пригодится {#ideas}
Это ограничивается только Вашей фантазией! Можно сделать удобную систему управления несколькими серверами Outline или сделать клиентского чат-бота для максимально удобного взаимодействия с клиентами VPN сервиса.

## Установка {#installation}
Перейдите в директорию Вашего проекта, запустите консоль и введите команду
```shell
dotnet add package OutlineManager
```
Или найдите пакет OutlineManager в пакетах [`NuGet`](https://www.nuget.org/packages/OutlineManager)

## Инициализация {#init}
1. Забираем APIUrl сервера. 
Для этого можете скопировать его после установки Outline-Server.
Если сервер уже установлен, взять APIUrl можно введя команду
```shell
sudo cat /opt/outline/access.txt
```
!!! Note
    Секретный ключ не пригодится для инициализации сервера
2. Создайте новый объект типа `OutlineManager` в своём проекте
```csharp
public static OutlineManager outline = new OutlineManager("YOUR SERVER APIURL");
```
3. Всё, Вы прекрасны! Можно работать с этим!

## Минимально работающий код {#base}
Здесь код просто выведет в консоль список ключей, взятый с сервера
```csharp
using OutlineManager;

namespace SomeProject
{
  class Program
  {
    public static OutlineManager server1 = new OutlineManager("https://outline-server-apiurl:port");
      
    static void Main()
    {
      var keys = server1.GetKeys();
      Console.WriteLine(keys);
    }
  }
}
```
На следующей странице перечисленны методы
