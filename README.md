# Welcome to Bootz & Catz!

## What is Bootz & Catz?
Bootz & Catz is a .NET Framework API Web Application developed using an n-tier architecture. The goal and purpose of our API is to utilize endpoints that allow animal rescue and shelter organizations to have an easy and reliable way of keeping track of and advertising dogs and cats in their systems. 



## Installation/ Authorization

Looking to run Bootz & Catz locally? Follow these steps!

1. **Clone** - Clone Bootz & Catz by running the following git command in your terminal 

 ```bash
 git clone https://github.com/DEBJ1/BootzAndCatzAPI.git
 ```
2. **Restore** - Bootz & Catz uses multiple nuget packages such as Swagger, Entity Framework, Owin and more. Upon opening nuget package manager, you may need to “Restore Nuget Packages” to ensure that you have the additional packages required for Bootz & Catz to run.

3. **Run** - Test that Bootz & Catz has been properly cloned by running it in the browser of your choice. The LocalHost web page should look like [this](https://imgur.com/a/RiALhvt).

4. **Authenticate** - Bootz & Catz API requires you to provide an API key in your requests to get responses. To get a Key, please utilize the Account Register endpoint in postman (https://localhostxxxxx/api/Account/Register) to create an account. Use the following key/value pairs under the Body x-www-form-urlencoded tab:
    - **Key**- "Email" **Value**- "{your email (can be fake)}"
    - **Key**- "Password" **Value**- {your password}
    - **Key**- "ConfirmPassword" **Value**- {your password}
    
    After creating an account, send a request for a token (https://localhostxxxxx/token) using the following key/value pairs under the Body x-www-form-urlencoded tab: 
    - **Key**- "grant_type" **Value**- "password"
    - **Key**- "Username" **Value**- {your email}
    - **Key**- "Password" **Value**- {your password}

    Next we are going to open a new request and add an “Authorization” header with the value set to “Bearer [your token]" (example image [here](https://imgur.com/a/xLftHNt)).       You  will need to add this header in every request sent.
    
 5. **Post a Shelter!** - There is no Data seeded into Bootz & Catz. Therefore, you will need to post a Shelter before you have access to posting/editing/deleting cats or dogs. This is because cats and dogs are required to have a Shelter Id number, which is provided for you when you post a shelter.    

 6. **Enjoy Bootz & Catz** - Ta-Da! You can now run requests in postman!




## API Endpoint Overview

**Shelter** | **Dog** | **Cat**
------------ | ------------- | -------------
 Add new shelter| Post new dog | Post new cat
View all shelters | View all dogs | View all cats
View shelter by ID | View dog by ID | View cat by Id
Update shelter information | View dogs by breed | View cats by breed
Delete shelter | Update dog information | Update cat information
-| Delete dog | Delete cat

**Endpoint Example**

![catendpoints](https://user-images.githubusercontent.com/74275900/109755840-c129bd80-7bb4-11eb-91c7-4006f1bc33b5.PNG)

## Technologies Used
- Visual Studio 2019

- Postman

## Resources Used
[LinkedIn Learning API course](https://www.linkedin.com/learning-login/share?forceAccount=false&redirect=https%3A%2F%2Fwww.linkedin.com%2Flearning%2Fbuilding-web-apis-with-asp-dot-net-web-api-2-2-2%3Ftrk%3Dshare_ent_url%26shareId%3Dyc3jvv3VS2y%252BKeRo%252F761PA%253D%253D&account=100110546)

[LinkedIn Learning Database Foundations](https://www.linkedin.com/learning/database-foundations-storage/linking-tables-with-foreign-keys?u=100110546)

[Eleven Fifty Academy Foreign Keys Video](https://youtu.be/tvq9U4K2p-s)

[Eleven Fifty Academy Team Git Video](https://youtu.be/2MAqwBwWmXs)

[Markdown Cheat Sheet](https://wordpress.com/support/markdown-quick-reference/)

[Entity Framework Tutorial](https://www.entityframeworktutorial.net/code-first/migration-in-code-first.aspx)



## License
[MIT](https://choosealice)
