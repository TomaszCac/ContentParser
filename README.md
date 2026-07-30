# ContentParser
This project is a Test.
ContentParser takes type ("CSV" or "INTERNAL_JSON") and content encoded base64 string \
There's 2 models : ParseRequest, ParseResponse.\
Counted operations on CSV are based on ROWS and INTERNAL_JSON are based on OBJECTS not arrays or properties\
**Warning**\
To properly connect to this project provided link must be http not https

## Instruction:
To properly launch this project you need to have .Net installed (.NET 10.0)
### Option 1:
-Open ContentParserProject folder in terminal\
-Simply type in command line "dotnet run"\
-Check in program what port is used\
-Use 3rd party program (like Postman) to test endpoint or use http file provided in project(Use port currently used by program)
### Option 2:
-Download current release of this project (Releases section in github)\
-Launch program using "ContentParserProject.exe"\
-Check in program what port is used\
-Use 3rd party program (like Postman) to test endpoint(Use port currently used by program)

## Request:
Request must be "application/json"\
{\
  "type": "INTERNAL_JSON" | "CSV",\
  "content": ""\
}\
-type currently supports only 2 options INTERNAL_JSON and CSV\
-content must be encoded in base64

## Endpoints:
### ParseController
POST /api/v1/parse-content: send ParseRequest in json to recieve ParseResponse model in json  

## Request examples:
### INTERNAL_JSON
{\
  "type": "INTERNAL_JSON",\
  "content": "ewogICJpZCI6IDEyMywKICAibmFtZSI6ICJUZXN0IiwKICAiYWN0aXZlIjogdHJ1ZSwKICAiYWRkcmVzcyI6IHsKICAgICJzdHJlZXQiOiAiS3dpYXRvd2EgMTUiLAogICAgImNpdHkiOiAiV2Fyc3phd2EiLAogICAgInppcENvZGUiOiAiMDAtMDAxIgogIH0sCiAgInJvbGVzIjogWwogICAgIkFkbWluIiwKICAgICJVc2VyIiwKICAgICJFZGl0b3IiCiAgXSwKICAib3JkZXJzIjogWwogICAgewogICAgICAib3JkZXJJZCI6IDEwMDEsCiAgICAgICJhbW91bnQiOiA5OS45OSwKICAgICAgIml0ZW1zIjogWwogICAgICAgIHsKICAgICAgICAgICJuYW1lIjogIkxhcHRvcCIsCiAgICAgICAgICAicXVhbnRpdHkiOiAxCiAgICAgICAgfSwKICAgICAgICB7CiAgICAgICAgICAibmFtZSI6ICJNb3VzZSIsCiAgICAgICAgICAicXVhbnRpdHkiOiAyCiAgICAgICAgfQogICAgICBdCiAgICB9LAogICAgewogICAgICAib3JkZXJJZCI6IDEwMDIsCiAgICAgICJhbW91bnQiOiA0OS41MCwKICAgICAgIml0ZW1zIjogW10KICAgIH0KICBdLAogICJtZXRhZGF0YSI6IHsKICAgICJjcmVhdGVkQXQiOiAiMjAyNi0wNy0yNVQxMDozMDowMFoiLAogICAgInRhZ3MiOiBbCiAgICAgICJzYW1wbGUiLAogICAgICAianNvbiIsCiAgICAgICJ0ZXN0IgogICAgXQogIH0KfQ=="\
}
#### Encoded content
{\
  "id": 123,\
  "name": "Test",\
  "active": true,\
  "address": {\
    "street": "Kwiatowa 15",\
    "city": "Warszawa",\
    "zipCode": "00-001"\
  },\
  "roles": [\
    "Admin",\
    "User",\
    "Editor"\
  ],\
  "orders": [\
    {\
      "orderId": 1001,\
      "amount": 99.99,\
      "items": [\
        {\
          "name": "Laptop",\
          "quantity": 1\
        },\
        {\
          "name": "Mouse",\
          "quantity": 2\
        }\
      ]\
    },\
    {\
      "orderId": 1002,\
      "amount": 49.50,\
      "items": []\
    }\
  ],\
  "metadata": {\
    "createdAt": "2026-07-25T10:30:00Z",\
    "tags": [\
      "sample",\
      "json",\
      "test"\
    ]\
  }\
}
### CSV
{\
  "type": "CSV",\
  "content": "SWQsTmFtZSxDYXRlZ29yeSxQcmljZSxRdWFudGl0eSxBY3RpdmUsQ3JlYXRlZERhdGUKMSxMYXB0b3AgUHJvLEVsZWN0cm9uaWNzLDM0OTkuOTksNSx0cnVlLDIwMjYtMDEtMTUKMixXaXJlbGVzcyBNb3VzZSxBY2Nlc3Nvcmllcyw4OS45MCwyNSx0cnVlLDIwMjYtMDItMDEKMyxPZmZpY2UgQ2hhaXIsRnVybml0dXJlLDU5OS4wMCwxMCxmYWxzZSwyMDI2LTAyLTEyCjQsTWVjaGFuaWNhbCBLZXlib2FyZCxBY2Nlc3NvcmllcywyNDkuNTAsMTUsdHJ1ZSwyMDI2LTAzLTA1CjUsTW9uaXRvciAyNyBpbmNoLEVsZWN0cm9uaWNzLDEyOTkuOTksOCx0cnVlLDIwMjYtMDMtMTgKNixEZXNrIExhbXAsSG9tZSw3OS45OSwzMCx0cnVlLDIwMjYtMDQtMDIKNyxVU0IgQ2FibGUsQWNjZXNzb3JpZXMsMTkuOTksMTAwLHRydWUsMjAyNi0wNC0xMAo4LE5vdGVib29rIEE1LE9mZmljZSwxMi41MCwyMDAsZmFsc2UsMjAyNi0wNS0wMQo5LFNtYXJ0cGhvbmUgWCxFbGVjdHJvbmljcywyNzk5LjAwLDEyLHRydWUsMjAyNi0wNS0yMAoxMCxDb2ZmZWUgTWFjaGluZSxLaXRjaGVuLDg5OS45OSw3LHRydWUsMjAyNi0wNi0xMQ=="\
} 
#### Encoded content
Id,Name,Category,Price,Quantity,Active,CreatedDate\
1,Laptop Pro,Electronics,3499.99,5,true,2026-01-15\
2,Wireless Mouse,Accessories,89.90,25,true,2026-02-01\
3,Office Chair,Furniture,599.00,10,false,2026-02-12\
4,Mechanical Keyboard,Accessories,249.50,15,true,2026-03-05\
5,Monitor 27 inch,Electronics,1299.99,8,true,2026-03-18\
6,Desk Lamp,Home,79.99,30,true,2026-04-02\
7,USB Cable,Accessories,19.99,100,true,2026-04-10\
8,Notebook A5,Office,12.50,200,false,2026-05-01\
9,Smartphone X,Electronics,2799.00,12,true,2026-05-20\
10,Coffee Machine,Kitchen,899.99,7,true,2026-06-11
