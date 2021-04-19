
How to Run
=======================================

1.Download the code
2.Navigate using command prompt to ToDoListAPI/ToDoListAPI
3.Execute command "dotnet run"


User Registration
------------------------------------

Connect to the api using PostMan

POST https://localhost:5001/api/account/register

Body:
{
"Email":"xxx@email.com",
"FirstName":"XXX",
"LastName":"XXX",
"Password":"password"
"ConfirmPassword":"password"
}

Login
--------------------------------------------------
POST https://localhost:5001/api/account/login
Body
{
"UserName":"xxx@email.com"
"Password":"password"
}

Copy the JWT Bearer Token for using other APIs

Fetch all the todo Items for the user
--------------------------------------------------
GET https://localhost:5001/api/todo

Add New Todo Items
---------------------------------------------------
POST https://localhost:5001/api/todo

Body:
{
    "Title":"Publish",
    "Description":"Publish the new feature",
    "ToDoUser":{
        "FirstName":"Madhav",
        "LastName":"D",
        "Email":"md@email.com"
    }
}

Update TODO Items
----------------------------------------
PUT https://localhost:5001/api/todo

Body:
{
    "Title":"Publish",
    "Description":"Publish the new feature",
    "ToDoUser":{
        "FirstName":"Madhav",
        "LastName":"D",
        "Email":"md@email.com"
    }
}

Delete TodoItems
-------------------------------------------

Delete https://localhost:5001/api/todo?Id={id}