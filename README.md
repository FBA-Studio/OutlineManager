<h1 align="center">OutlineManager<h1>

.NET Library for Outline Proxy Manager API

<a href="#"><img alt="GitHub repo size" src="https://img.shields.io/github/repo-size/FBA-Studio/OutlineManager"></a>
<a href="https://github.com/FBA-Studio/OutlineManager/blob/main/LICENSE"><img alt="GitHub" src="https://img.shields.io/github/license/FBA-Studio/OutlineManager"></a>
<a href="https://www.nuget.org/packages/OutlineManager/"><img alt="Nuget" src="https://img.shields.io/nuget/dt/OutlineManager"></a>
<a href="https://twitter.com/FBA_Studio"><img alt="Twitter Follow" src="https://img.shields.io/twitter/follow/FBA_Studio?style=social"></a>

## Installation
Enter this into terminal in your project directory:
```shell
dotnet add package OutlineManager
```

## Quick start
1. Get your API Management URL from your Outline Server: 
```shell
sudo cat /opt/outline/access.txt
```
2. Initialize the server in your C# project
```csharp
private static string apiUrl = "your URL from Outline Server";
public static OutlineManager server1 = new OutlineManager(apiUrl);
```

## Get List of Outline Server Keys
Use method `.GetKeys()` to get list of Outline Keys in the `List<OutlineKey>`:
```csharp
//returns List<OutlineKey>
var keys = outline.GetKeys();
```

## Edit Outline Key
### 1. Rename Outline Key

You can change name of key by **KeyId** with the method `.RenameKey()`.

**Parameters:**
- id - ID of the Key
- name - new name for this key

**Example:**
```csharp
// return true, if operation was successful
var status = outline.RenameKey(0, "Lance's key");
```
### 2. Add Data Limit

If your Outline Server's traffic not unlimited, you can adjust data limits with the method `.AddDataLimit()`.

**Parameters:**
- id - ID of the Key in Outline
- limitBytes - Your new limit in bytes

**Example:**
```csharp
// return true, if operation was successful
var status = outline.AddDataLimit(0, 0); // if limit in bytes = 0, the key usage is suspended
```
*Also you can remove limit with method `outline.DeleteDataLimit(0)` with id parameter*

### 3. Create new Key
You can create new key for your friend or family with method `.CreateKey()`.

```csharp
// returns key info in OutlineKey
var status = outline.CreateKey(0, 0);
```
*Also you can delete key with method `outline.DeleteKey(0)` with id parameter, if this key leaked or useless*

### 4. Get Transferred Data
You can get list of keys with transferred data in bytes with method `.GetTransferredData()`.
```csharp
// return List<TransferredData>
var transferredData = outline.GetTransferredData();
```

## ❤️Support Devs of this Library
### Russia :ru::<br>
[DonationAlerts](https://www.donationalerts.com/r/fba_studio)<br>
[QIWI](https://qiwi.com/n/FBASTUDIO)<br>
YooMoney - 4100115740796249<br>
Sberbank - 4817 7602 1736 1942 (Kirill K.)<br>
Tinkoff - 2200 7007 7308 4180 (Kirill I.)
### Turkey :tr::<br>
Papara - 1895931253 (Kirill Corvych)
Oldubil - 5388 4105 5265 3265
