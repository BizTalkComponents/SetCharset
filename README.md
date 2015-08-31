[![Build status](https://ci.appveyor.com/api/projects/status/github/BizTalkComponents/SetCharset?branch=master)](https://ci.appveyor.com/api/projects/status/github/BizTalkComponents/SetCharset/branch/master)

##Description
Intended to be used on a ReceivePort to tell the disassembler what encoding is used. The component does this by setting the TargetCharset property of the body message part.

| Parameter       | Description                         | Type| Validation|
| ----------------|-------------------------------------|-----|-----------|
|Target Charset|The charset that should be used for the incoming message.|String|Required|

## Remarks ##
Throws ArgumentException if a non existing charset is specified.