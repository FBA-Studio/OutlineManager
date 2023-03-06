# OutlineManager
.NET Library for Outline Proxy Manager API

## Installation
```
dotnet add package OutlineManager --version 1.0.4
```

## Quick start
1. Get your API Management URL from your Outline Server - sudo cat /opt/outline/access.txt
2. Pastу your URL into "OutlineManager" object in your C# Project:
```csharp
private static string apiUrl = "your URL from Outline Server";
public static OutlineManager outline = new OutlineManager(apiUrl);
```

## Get Outline Keys
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

If your Outline Server's traffic not unlimited, you can add limit data with the method `.AddDataLimit()`.

**Parameters:**
- id - ID of the Key
- limitBytes - Your new limit in bytes

**Example:**
```csharp
// return true, if operation was successful
var status = outline.AddDataLimit(0, 0); // if limit in bytes = 0, you can't use this key
```
*Also you can remove limit with method `outline.DeleteDataLimit(0)`*

### 3. Create new Key
You can create new key for your friend or family with method `.CreateKey()`.

```csharp
// return key info in OutlineKey
var status = outline.CreateKey(0, 0);
```
*Also you can delete key with method `outline.DeleteKey(0)`, if this key leaked*

### 4. Get Transferred Data
You can get list of keys with transferred data in bytes with method `.GetTransferredData()`.
```csharp
// return List<TransferredData>
var transferredData = outline.GetTransferredData();
```

## ❤️Support Devs of this Library
DonationAlerts - https://www.donationalerts.com/r/fba_studio
